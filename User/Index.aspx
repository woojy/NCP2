<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DB.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>metoo 첫화면</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet1.css">
</head>
<body>
    <form id="IndexForm" name="IndexForm" runat="server">
        
        <h2>안녕하세요! METOO 전자 투표입니다.</h2>
        <br /><br />
        
        <div class="indexForm">
        <asp:TextBox ID="start" runat="server"/><br /><br /><br />
        <asp:Button ID="startBtn" runat="server" Text="시작하기" onclick="startBtn_Click"/><br /><br />
        <asp:Label ID="check" runat="server" Text="키를 입력해주세요"></asp:Label><br />
        </div>
        
        <asp:Label ID="dbcheck" runat="server"></asp:Label><br />

    </form>
</body>
</html>
