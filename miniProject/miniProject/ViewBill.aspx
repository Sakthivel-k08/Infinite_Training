<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewBill.aspx.cs" Inherits="miniProject.ViewBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Last N Bills</h2>

    <asp:TextBox ID="txtN" runat="server" placeholder="Enter N"></asp:TextBox><br />
    <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Bills" OnClick="btnRetrieve_Click" /><br />

    <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
