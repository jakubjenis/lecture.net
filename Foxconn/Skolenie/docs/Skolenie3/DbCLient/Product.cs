using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Xml;
using SQLLib;

namespace DbCLient
{
    public class Product
    {
        public string Nazov;
        private string popis;
        public double Cena;
        private int id_Kategoria;
        private string imageURL;

        public bool IsValid { 
            get;
            private set;
        }

        public Product(XmlNode node)
        {
            IsValid = true;
            try
            {
                var val = node.SelectSingleNode("name");
                if (val != null && !string.IsNullOrEmpty(val.InnerText))
                {
                    Nazov = val.InnerText;
                }
                else
                {
                    IsValid = false;
                }

                val = node.SelectSingleNode("description");
                popis = val != null ? val.InnerText : "";

                val = node.SelectSingleNode("price_GBP");
                if (val == null || !double.TryParse(val.InnerText, out Cena))
                {
                    IsValid = false;
                }

                id_Kategoria = 4;
                imageURL = val != null ? node.SelectSingleNode("default_image").InnerText : "";
            }
            catch (Exception)
            {
                Console.WriteLine("CHYBA_PARSE");
                IsValid = false;
            }
        }

        private bool DownloadImage(string url, string fileName)
        {
                var res = (HttpWebResponse)CreateRequest(url).GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    using (var input = res.GetResponseStream())
                    {
                        using (var output = File.OpenWrite(fileName))
                        {
                            input.CopyTo(output);
                        }
                    }
                    return true;
                }
            return false;
        }

        public HttpWebRequest CreateRequest(string url)
        {
            var wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Accept = "image/*";
            wr.UserAgent = "Mozilla/5.0";
            wr.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            wr.Headers.Add(HttpRequestHeader.AcceptLanguage, "sk-SK");
            wr.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            return wr;
        }

        public bool Save(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                Console.WriteLine("closed");
            }

            try
            {
                String[] splitURL = imageURL.Split('/');
                String fileName = "img/" + splitURL[splitURL.Length - 1];
                DownloadImage(imageURL, fileName);
                var rd = Execute.NonQuerySP(
                    "SP_AddProdukt", conn,
                    new SqlParameter("@Nazov", Nazov),
                    new SqlParameter("@Cena", Cena),
                    new SqlParameter("@Popis", popis),
                    new SqlParameter("@id_Kategoria", id_Kategoria),
                    new SqlParameter("@ObrazokUrl", fileName)); 
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("CHYBA_SAVE");
                return false;
            }
        }

    }


}
