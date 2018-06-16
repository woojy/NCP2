<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Candidate.aspx.cs" Inherits="DB.Candidate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet2.css">
</head>
<body>
    <form id="candidateForm" runat="server">
        <div id="candidate" runat="server">
            후보명 : <asp:TextBox ID="name1" runat="server"></asp:TextBox><br /><br />
            학과명 : <asp:DropDownList ID="major1" runat="server">
                        <asp:ListItem Value="인터랙티브미디어과" Selected>인터랙티브미디어과</asp:ListItem>
                        <asp:ListItem Value="뉴미디어디자인과">뉴미디어디자인과</asp:ListItem>
                        <asp:ListItem Value="뉴미디어솔루션과">뉴미디어솔루션과</asp:ListItem>
                     </asp:DropDownList><br /><br />
            공약 : <asp:TextBox ID="commitment1" runat="server"></asp:TextBox><br /><br />
            후보이미지 : <asp:FileUpload id="img1" runat="server"/>
        </div>
        <br />
        <asp:Button id="candidateBtn" Text="등록하기" OnClick="candidateBtn_Click" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="뒤로가기"/>
        <hr />
        <asp:Label ID="imgpath1" runat="server" Text="이미지 경로"/>
        <asp:Label ID="dbcheck" runat="server" Text="dbcheck"/>
        <asp:Label ID="imgcheck" runat="server" Text="imgcheck"></asp:Label>
        <asp:Image ID="realimg" runat="server"/>
    </form>
</body>
</html>
