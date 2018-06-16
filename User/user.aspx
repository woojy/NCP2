<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="WebApplication2.user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>투표화면</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet1.css">

</head>
<body>

        <form id="form1" runat="server" method="post">
            <div>
                학번<input type="text" name="num" placeholder="학번입력 ex)3101"/>
            </div><br />
            <asp:Button ID ="btnSqlConnection" runat="server" 
                Text="전송" OnClick="btn_Click"/>
            <hr />
        </form>
    
        <asp:Label ID="aa" runat="server"></asp:Label><br />
        <asp:Label ID="dbcheck" runat="server"></asp:Label><br />
        <asp:Label ID="Label1" runat="server"></asp:Label><br />
</body>
</html>
