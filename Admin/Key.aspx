<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Key.aspx.cs" Inherits="DB.Key" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>암호키 생성</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet1.css">
</head>
<body>
    <form id="keyForm" runat="server" method="post">
        <div>
            <asp:TextBox ID="key" runat="server"></asp:TextBox>
            <asp:Button ID="keyBtn" runat="server" Text="암호키 생성" onclick="keyBtn_Click"/>
            <hr />
            <asp:Label ID="dbcheck1" runat="server"></asp:Label><br />

        </div>
    </form>
</body>
</html>
