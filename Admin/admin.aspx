<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="DB.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet1.css">
</head>
<body>
    <form id="adminForm" runat="server">
        <div class="adminBox">
            <asp:Label ID="check" runat="server" Text="세션X"></asp:Label>

            <div><a href="Logout.aspx">로그아웃</a></div><br/>
            <div><a href="Candidate.aspx">후보자 등록</a></div><br/>
            <div><a href="Key.aspx">암호키생성</a></div><br/>
            <div><a href="Student.aspx">인원등록</a></div><br/>
            <div><a href="Result.aspx">결과확인</a></div><br/>
            <div><a href="Clear.aspx">초기화</a></div><br/>
        </div>
    </form>
    
</body>
</html>
