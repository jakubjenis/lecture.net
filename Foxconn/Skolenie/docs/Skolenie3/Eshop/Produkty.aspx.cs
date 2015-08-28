using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLLib;

namespace Eshop
{
    public partial class Produkty : System.Web.UI.Page
    {
        public class Produkt
        {
            public string Nazov { get; set; }
            public double Cena { get; set; }
            public string Popis { get; set; }
            public string ImageURL { get; set; }
        }

        public List<Produkt> ProduktList = new List<Produkt>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Connection.Init("Server=Revizie.ukf.sk,1433;Database=Skolenie;User Id=Skolenie;Password=12345;");
            using (var conn = Connection.GetOpen())
            {
                using (var rd = Execute.Reader("SELECT TOP "+ Request["Top"] +" p.Nazov, p.Cena, p.Popis, o.URL FROM Produkt p JOIN Obrazok o ON p.id_Obrazok = o.ID",conn))
                {
                    while (rd.Read())
                    {
                        ProduktList.Add(new Produkt
                            {
                                Nazov=rd["Nazov"].ToString(),
                                Cena=double.Parse(rd["Cena"].ToString()),
                                Popis=rd["Popis"].ToString(),
                                ImageURL=rd["URL"].ToString()
                            });
                    }
                }
            }
            repProdukty.DataSource = ProduktList;
            repProdukty.DataBind();
        }
    }
}