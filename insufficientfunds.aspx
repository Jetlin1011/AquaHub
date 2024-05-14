<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insufficientfunds.aspx.cs" Inherits="Aquahub.insufficientfunds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 88px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Insufficient funds!!

            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Home" CssClass="auto-style1" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
