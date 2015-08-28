<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eshop.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
     vitajte s nasom e-shope<br/>
     <a href="Produkty.aspx?top=10" class="cerveny">Produkty 1-10</a><br/>
     <a href="Produkty.aspx?top=20" class="cerveny">Produkty 1-20</a><br/>
 <p><asp:Label id="lbl1" runat="server" /></p>
</asp:Content>
