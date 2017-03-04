<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style ="text-align:center">
    
        <asp:Label ID="Label1" runat="server" Text="User_Name "></asp:Label>
        <asp:TextBox ID="user_name_txt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password "></asp:Label>
        <asp:TextBox ID="pass_txt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log in " />
        <br />
        <br />
        <br />
    
    </div>
        <p>
            &nbsp;</p>
        <p style ="text-align:center">
            <asp:Label ID="Label3" runat="server" EnableTheming="False" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
