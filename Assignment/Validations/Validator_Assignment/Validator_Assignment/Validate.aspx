<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ValidationApp.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validators - Microsoft Internet Explorer</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f0f0f0;
            padding: 30px;
        }
        .form-box {
            background-color: whitesmoke;
            border: 1px solid #ccc;
            padding: 20px;
            width: 350px;
        }
        label {
            display: block;
            margin-top: 10px;
        }
        .error {
            color: red;
            font-size: 11px;
        }
        .validation-summary {
            margin-top: 20px;
            background-color: #fff0f0;
            border: 1px solid red;
            padding: 10px;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-box">
            <h1 style="color:deepskyblue">Insert your details </h1>

            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName"
                ErrorMessage="* Required" CssClass="error" />

            <label>Family Name:</label>
            <asp:TextBox ID="txtFamily" runat="server" />
            <asp:CustomValidator ID="valFamily" runat="server" ControlToValidate="txtFamily"
                OnServerValidate="ValidateFamilyName" ErrorMessage="* differs from name" CssClass="error" />

            <label>Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" />
            <asp:RegularExpressionValidator ID="valAddress" runat="server" ControlToValidate="txtAddress"
                ValidationExpression=".{2,}" ErrorMessage="* at least 2 chars" CssClass="error" />

            <label>City:</label>
            <asp:TextBox ID="txtCity" runat="server" />
            <asp:RegularExpressionValidator ID="valCity" runat="server" ControlToValidate="txtCity"
                ValidationExpression=".{2,}" ErrorMessage="* at least 2 chars" CssClass="error" />

            <label>Zip Code:</label>
            <asp:TextBox ID="txtZip" runat="server" />
            <asp:RegularExpressionValidator ID="valZip" runat="server" ControlToValidate="txtZip"
                ValidationExpression="^\d{5}$" ErrorMessage="* (xxxxx)" CssClass="error" />

            <label>Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" />
            <asp:RegularExpressionValidator ID="valPhone" runat="server" ControlToValidate="txtPhone"
                ValidationExpression="^\d{2}-\d{7}$|^\d{3}-\d{7}$" ErrorMessage="* (xx-xxxxxxx / xxx-xxxxxxx)" CssClass="error" />

            <label>E-Mail:</label>
            <asp:TextBox ID="txtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="* example@example.com" CssClass="error" />

            <br/><br />
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" style="border:1px solid;background-color:deepskyblue"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary"
                HeaderText="ValidationSum" />
        </div>
    </form>
</body>
</html>
