<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Produkty.aspx.cs" Inherits="Eshop.Produkty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    Produkty<br/>
    <table>
    <asp:Repeater runat="server" ID="repProdukty">
        <ItemTemplate>
            <tr>
                <td>
                    <img width="120px" height="100px" src='<%# Eval("ImageURL") %>'/>
                </td>
                <td>
                    <a href="#"><%# Eval("Nazov") %></a><br/>
                    <%# Eval("Popis")%><br/>
                    <%# Eval("Cena") %> Eur
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
