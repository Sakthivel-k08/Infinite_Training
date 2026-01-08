<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="miniProject.AddBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Electricity Bill</h2>

    <asp:TextBox ID="txtConsumerNumber" runat="server" placeholder="Consumer Number"></asp:TextBox><br />
    <asp:TextBox ID="txtConsumerName" runat="server" placeholder="Consumer Name"></asp:TextBox><br />
    <asp:TextBox ID="txtUnits" runat="server" placeholder="Units Consumed"></asp:TextBox><br />

    <asp:Button ID="btnAddBill" runat="server" Text="Add Bill" OnClick="btnAddBill_Click" /><br />
    <asp:Button ID="btnViewBill" runat="server" Text="View Bills" OnClick="btnViewBill_Click" /><br />

    <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
