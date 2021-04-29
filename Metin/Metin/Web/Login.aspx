<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Metin.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Template/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table cellspacing="0" cellpadding="0" width="800" height="400" border="0">

                <tr>
                    <td style="vertical-align: central" align="center">
                        <div class="login">
                            <h1>Login</h1>
                            <form method="post" action="">
                                <p>
                                    <input runat="server" type="text" id="txtUsername" value="" placeholder="Username or Email">
                                </p>
                                <p>
                                    <input runat="server" type="password" id="txtPassword" value="" placeholder="Password">
                                </p>
                                <p class="submit">
                                    &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                </p>
                                <p class="hata">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                </p>
                            </form>
                        </div>
                        <br />                       
                        <p aria-orientation="horizontal">
                                    <asp:Label ID="Label2" runat="server" ForeColor="White" Font-Bold="True" Font-Size="Medium">Normal Login</asp:Label>

                        </p>
                            <p aria-orientation="horizontal">
                                    <asp:Label ID="Label3" runat="server" ForeColor="White" Font-Bold="False" Font-Size="Medium"> Username : metin   -   Password : 252525 </asp:Label>
                                &nbsp;</p>
                            <p>
                                    <asp:Label ID="Label1" runat="server" ForeColor="White" Font-Bold="True" Font-Size="Medium">Admin Login</asp:Label>

                        </p>
                            <p>
                                    <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Bold="False" Font-Size="Medium">Username : admin   -   Password : 123 </asp:Label>
                                &nbsp;</p>

                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
