<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductApp.ProductViewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
   <style>
    body {
        font-family: Arial;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;   
        align-items: center;       
        height: 100vh;             
        background-color: #f0f0f0; 
    }

    .container {
        width: 400px;
        padding: 20px;
        border: 1px solid #ccc;
        background-color: #f9f9f9;
        text-align: center;        
        box-shadow: 0 0 10px rgba(0,0,0,0.1); 
    }

    label {
        display: block;
        margin-top: 10px;
        text-align: left;         
    }

    img {
        margin-top: 10px;
        width: 200px;
        height: 200px;
        border: 1px solid #ddd;
        display: block;
        margin-left: auto;
        margin-right: auto;       
    }

    .price-label {
        margin-top: 10px;
        font-weight: bold;
        color: green;
        display: block;
    }

    h3 {
        margin-bottom: 15px;
    }

    .container select,
    .container button {
        margin-top: 10px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Select a Product</h3>

            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Image ID="imgProduct" runat="server" />

            <br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />

            <asp:Label ID="lblPrice" runat="server" CssClass="price-label" />
        </div>
    </form>
</body>
</html>
