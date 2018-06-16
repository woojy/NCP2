<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clear.aspx.cs" Inherits="DB.Clear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet2.css">
</head>
<body>
    <form id="clearForm" runat="server">
        <asp:Button ID="candidateClear" runat="server" Text="후보자 데이터 삭제" OnClick="candidateClear_Click" /><br /><br />
        <asp:Button ID="studentClear" runat="server" Text="인원 데이터 삭제" onclick="studentClear_Click" /><br /><br />
        <asp:Button ID="keyClear" runat="server" Text="암호 데이터 삭제" OnClick="keyClear_Click" /><br /><br />
        <asp:Button ID="resultClear" runat="server" Text="투표결과 데이터 삭제" onclick="resultClear_Click" /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="뒤로가기" onclick="back_Click"/><br /><br />
    <hr />
        <asp:Label ID="db1" runat="server" Text="db1X"></asp:Label>
        <asp:Label ID="db2" runat="server" Text="db2X"></asp:Label>
        <asp:Label ID="db3" runat="server" Text="db3X"></asp:Label>
        <asp:Label ID="db4" runat="server" Text="db4X"></asp:Label>
  

    </form>
    <hr />
</body>
</html>
