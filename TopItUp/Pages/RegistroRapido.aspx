<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroRapido.aspx.vb" Inherits="TopItUp.RegistroRapido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 161px;
            height: 99px;
        }

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
            font-size: small;
        }

        .auto-style6 {
            font-size: small;
            width: 23px;
        }

        .auto-style7 {
            width: 301px;
        }

        .auto-style8 {
            width: 300px;
        }

        .auto-style9 {
            width: 265px;
        }

        .auto-style10 {
            font-size: small;
            width: 178px;
        }

        .auto-style11 {
            font-size: small;
            width: 79px;
        }

        .auto-style12 {
            width: 359px;
        }

        .auto-style13 {
            font-size: large;
            color: #FFFFFF;
            width: 350px;
            border: none;
            border-color: none;
        }

        .auto-stylomedio {
            width: 100px;
        }
    </style>
</head>
<body style="background: url('../Images/fondo.png')">
    <form id="form1" style="background-image: url('../Images/fondo.png')" runat="server">

        <div>
            <%--      <img src="../Images/fondo.png" />--%>
            <div style="font-family: 'Century Gothic'; background-image: url('../Images/fondo.png'); font-size: medium; font-style: normal; color: #666666; background-color: #FFFFFF">
                <table style="width: 100%">
                    <tr style="width: 100%">
                        <td style="text-align: center; background-color: whitesmoke; width: 100%">
                            <%-- <img alt="" class="auto-style1" src="../Images/logomits.png" /></td>--%>
                            <img src="../Images/logosml-u87.png" />
                            <img src="../Images/logo_telcel.png" />
                            <img src="../Images/logo_movistar.png" />
                            <img src="../Images/logo_iusacel.png" />
                            <img src="../Images/logo_nextel.png" />
                            <img src="../Images/logo_unefon.png" />
                    </tr>
                </table>
                <br />
                <span class="auto-style3">
                    <br />

                </span>
                <br />
                <br />
                <br />
                <div>
                    <table>
                        <tr>
                            <td class="auto-style13">Nombre</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtnombre" runat="server" Width="100%"></asp:TextBox></td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">Correo electronico</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Giro del negocio</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtGiro" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">Dirección negocio</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtDireccionNegocio" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Estado</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtEstado" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">Municipio</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtMunicipio" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Código postal</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtCP" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">Teléfono casa</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtTelefonoCasa" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Teléfono celular</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtTelefonoCelular" runat="server" Width="100%"></asp:TextBox></td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">¿Vende por internet?</td>
                            <td class="auto-style13">
                                <asp:DropDownList ID="ddlVendeporInternet" runat="server" CssClass="auto-style5" Height="16px" Width="73px">
                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Tipo de persona</td>
                            <td class="auto-style13">
                                <asp:DropDownList ID="ddlTipoPersona" runat="server" Height="18px" Width="73px">
                                    <asp:ListItem Value="1" Text="Fisica"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Moral"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-stylomedio">&nbsp;</td>
                            <td class="auto-style13">¿Requiere factura?</td>
                            <td>
                                <asp:DropDownList ID="ddlRequiereFactura" AutoPostBack="true" runat="server" Height="18px" Width="73px">
                                    <asp:ListItem Value="0" Text="NO"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="SI"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="auto-style3">
                    <span class="auto-style13">D</span><span class="auto-style13">ATOS PARA FACTURA </span>
                    <table style="width: 800px">
                        <tr>
                            <td class="auto-style13">Nombre / Razón Social</td>
                            <td class="auto-style13">&nbsp;<asp:TextBox ID="txtNombreFactura" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style13">Dirección</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtDireccionFactura" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">RFC</td>
                            <td class="auto-style13">&nbsp;<asp:TextBox ID="txtRFCFactura" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style13">&nbsp;Teléfono</td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtTelefonoFactura" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <table>
                    <tr>
                        <td style="width: 690px;"></td>
                        <td>
                            <asp:Button ID="btnAceptar" runat="server" Text="Registrar" BackColor="White" BorderColor="Silver" BorderStyle="Solid" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblMensaje" runat="server" Text="" Style="font-weight: 700; color:white;  font-size: small"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div style="width: 100%; height: 100%">
                    <table style="margin: 0 auto 0 auto; width: 100%; height: 100%;">
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <img alt="" src="../Images/logomits.png" /></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
