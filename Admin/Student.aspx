<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="DB.Admin.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet1.css">
</head>
<body>
    <form id="stuForm" runat="server" method="post">
        <table>
            <tr>
                <th>1학년</th>
                <th>2학년</th>
                <th>3학년</th>
            </tr>
            <tr>
                <td>1반 <asp:TextBox ID="stu11" runat="server" required></asp:TextBox></td>
                <td>1반 <asp:TextBox ID="stu21" runat="server" required></asp:TextBox></td>
                <td>1반 <asp:TextBox ID="stu31" runat="server" required></asp:TextBox></td>
            </tr>
            <tr>
                <td>2반 <asp:TextBox ID="stu12" runat="server" required></asp:TextBox></td>
                <td>2반 <asp:TextBox ID="stu22" runat="server" required></asp:TextBox></td>
                <td>2반 <asp:TextBox ID="stu32" runat="server" required></asp:TextBox></td>
            </tr>
            <tr>
                <td>3반 <asp:TextBox ID="stu13" runat="server" required></asp:TextBox></td>
                <td>3반 <asp:TextBox ID="stu23" runat="server" required></asp:TextBox></td>
                <td>3반 <asp:TextBox ID="stu33" runat="server" required></asp:TextBox></td>
            </tr>
            <tr>
                <td>4반 <asp:TextBox ID="stu14" runat="server" required></asp:TextBox></td>
                <td>4반 <asp:TextBox ID="stu24" runat="server" required></asp:TextBox></td>
                <td>4반 <asp:TextBox ID="stu34" runat="server" required></asp:TextBox></td>
            </tr>
            <tr>
                <td>5반 <asp:TextBox ID="stu15" runat="server" required></asp:TextBox></td>
                <td>5반 <asp:TextBox ID="stu25" runat="server" required></asp:TextBox></td>
                <td>5반 <asp:TextBox ID="stu35" runat="server" required></asp:TextBox></td>
            </tr>
            <tr>
                <td>6반 <asp:TextBox ID="stu16" runat="server" required></asp:TextBox></td>
                <td>6반 <asp:TextBox ID="stu26" runat="server" required></asp:TextBox></td>
                <td>6반 <asp:TextBox ID="stu36" runat="server" required></asp:TextBox></td>
            </tr>
        </table>
        <br /><br /><br />
        <asp:Button ID="StuBtn" runat="server" Text="등록" onclick="StuBtn_Click" />
        <asp:Button ID="Button1" runat="server" Text="뒤로가기" onclick="StuBtn_Click" />
    </form>

    <asp:Label ID="dbcheck" runat="server" Text="db연동 X"></asp:Label>




</body>
</html>
