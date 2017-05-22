<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Recarga.aspx.vb" Inherits="TopItUp.Recarga" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 92%;
        }
        .auto-style2 {
            width: 174px;
        }
        .auto-style3 {
            font-size: small;
        }
        .auto-style4 {
            font-size: medium;
        }
          .auto-style163 {
              font-size: 8pt;
              text-align: right;
          }

          .auto-style164 {
            font-size: small;
            text-align: right;
        }
        .auto-style165 {
            width: 120px;
        }
        .auto-style166 {
            font-size: medium;
            width: 120px;
        }
        .auto-style167 {
            width: 164px;
        }
        .auto-style168 {
            font-size: medium;
            width: 164px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style167">
                                <asp:LinkButton ID="lnkBtnTiempoAire" runat="server" CssClass="auto-style4">Compra de Tiempo Aire</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style168">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style168">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style168">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style168">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style168">&nbsp;</td>
                        </tr>
                    </table>
                    <br class="auto-style4" />
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style165">
                                <asp:RadioButton ID="rbTelcel" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="TELCEL" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbMovi" runat="server" AutoPostBack="True" CssClass="auto-style3" TabIndex="1" Text="MOVISTAR" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style166">
                                <asp:RadioButton ID="rbIusa" runat="server" AutoPostBack="True" CssClass="auto-style3" TabIndex="2" Text="IUSACELL" />
                            </td>
                            <td class="auto-style4">
                                <asp:RadioButton ID="rbNextel" runat="server" AutoPostBack="True" CssClass="auto-style3" TabIndex="3" Text="NEXTEL" />
                            </td>
                        </tr>
                    </table>
                    <br class="auto-style3" />
                    <strong><span class="auto-style3">MONTO A RECARGAR</span></strong><br class="auto-style3" />
                    <asp:RadioButton ID="rb10" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="10" />
                    <span class="auto-style3">&nbsp;&nbsp;&nbsp; </span>
                    <asp:RadioButton ID="rb20" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="20" />
                    <span class="auto-style3">&nbsp;&nbsp;&nbsp; </span>
                    <asp:RadioButton ID="rb50" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="50" />
&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rb100" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="100" />
&nbsp;&nbsp;
                    <asp:RadioButton ID="rb150" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="150" />
&nbsp;&nbsp;
                    <asp:RadioButton ID="rb200" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="200" />
                    <br class="auto-style3" />
                    <asp:RadioButton ID="rb300" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="300" />
                    <span class="auto-style3">&nbsp; </span>
                    <asp:RadioButton ID="rb500" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="500" />
                    <span class="auto-style3">&nbsp; </span>
                    <asp:RadioButton ID="rb750" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="750" />
&nbsp;&nbsp;
                    <asp:RadioButton ID="rb1000" runat="server" AutoPostBack="True" CssClass="auto-style3" Text="1000" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br class="auto-style3" />
                    <br class="auto-style3" />
                    <span class="auto-style164"><strong>NÚMERO CELULAR</strong></span><br class="auto-style3" />
                    <asp:TextBox ID="txtNumber" CssClass="soloNumeros" style="text-align:right; font-size: small;" runat="server" Width="49%" Height="25px"></asp:TextBox>
                                                                        <br class="auto-style3" />
                    <br class="auto-style3" />
                    <strong><span class="auto-style164">CONFIRMAR NÚMERO<br />
                    </span><span class="auto-style163"><asp:TextBox ID="txtConfirmNumber" CssClass="soloNumeros" style="text-align:right; font-size: small;" runat="server" AutoPostBack="True" Width="49%" Height="25px"></asp:TextBox>
                                                                        </span>
                                                                        </strong>
                    <br class="auto-style3" />
                    <br class="auto-style3" />
                                                                    <asp:Button ID="btnAplicarRecarga" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" style="color: #FFFFFF; background-color: #002142; text-align: center;" Text="Aplicar" ToolTip="De click para realizar la recarga" Width="139px" CssClass="auto-style3" />
                                                                                    </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
