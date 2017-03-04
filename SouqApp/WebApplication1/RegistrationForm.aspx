<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="WebApplication1.RegistrationForm" %>
  <%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
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

        <asp:Label Visible="false" ID="lblResult" runat="server" />
          <recaptcha:RecaptchaControl
              ID="RecaptchaControl1"
              runat="server"
              Theme="red"
              PublicKey="6LfsDg8UAAAAAHmdrGlITNs-yChDsuCQ9_wl6b4h"
              PrivateKey="6LfsDg8UAAAAAM3ObhhZXhpeR47M2IHbt1ASHWkO"
              />
        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
        <br />
        <br />

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register Me" />
        <br />
        <br />
        <br />
    
    </div>
        <p>
            <asp:GridView ID="gv_result" runat="server">
            </asp:GridView>
      </p>

  

    </form>
</body>
</html>
