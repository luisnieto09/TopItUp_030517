<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Activacion.aspx.vb" Inherits="TopItUp.Activacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 102px;
            height: 41px;
        }
        .auto-style3 {
            font-size: medium;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            font-size: large;
            color: #FFFFFF;
        }
    </style>

</head>
<body>
    <form id="form1" style="background-image:url('../Images/fondo.png'); text-align:center " runat="server">
     
      <br />
      <br />
        <div style="font-family: 'Century Gothic'; font-size: medium; font-style: normal; color: #666666; background-image:url('../Images/fondo.png')">
            <br />
              <table class="auto-style4">
                <tr>
                    <td style="text-align: center; background-color:whitesmoke ">
                        <img src="../Images/logosml-u87.png" />
                        <img src="../Images/logo_telcel.png" />
                        <img src="../Images/logo_movistar.png" />
                        <img src="../Images/logo_iusacel.png" />
                        <img src="../Images/logo_nextel.png" />
                        <img src="../Images/logo_unefon.png" />

                    </td>
                </tr>
            </table>
            <br />
        <table class="auto-style5">
            <tr><td class="auto-style5">Correo electronico</td><td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                 </td></tr>
            <tr><td>Clave de activación</td><td>
                <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td></td><td align="right">
                <asp:Button ID="btnAceptar" runat="server" Text="Activar" BackColor="White" BorderColor="Silver" BorderStyle="Solid" CssClass="auto-style3" />
             </td></tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblmessage" style="color:white" runat="server" Text=""></asp:Label>
                        <br />
            <br />
            <br />
            <table class="auto-style4">
                <tr>
                    <td colspan="2" style="text-align: center">
                        <img alt="" class="auto-style2" src="../Images/logomits.png" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
