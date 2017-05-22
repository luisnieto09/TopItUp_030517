<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PagoServ.aspx.vb" Inherits="TopItUp.PagoServ" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #002142;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #002142;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #002142;
                border: 1px solid #002142;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

        .auto-style12 {
            width: 85%;
            font-size: 9pt;
        }

        a:link {
            color: black;
            background-color: transparent;
            text-decoration: none;
        }

        A:link {
            color: black;
        }

        A:visited {
            color: black;
        }

        A:active {
            color: black;
        }

        A:hover {
            color: black;
        }

        .auto-style91 {
        }

        .nav-justified {
            width: 20%;
            height: 15px;
        }

        #tblSaldos {
            color: #FFFFFF;
            background-color: #FFFFFF;
            width: 95%;
            height: 60px;
        }

        .auto-style100 {
        }

        .auto-style105 {
            text-align: left;
        }

        .auto-style109 {
            width: 538px;
        }

        #tblOpcion1 {
            width: 984px;
            height: 240px;
        }

        .auto-style110 {
            width: 435px;
            text-align: left;
        }

        #tblMenu {
            height: 321px;
            width: 181px;
        }

        .auto-style125 {
            font-size: x-large;
        }

        .auto-style126 {
            text-align: left;
            height: 24px;
        }

        .auto-style150 {
            height: 24px;
        }

        .auto-style152 {
            height: 24px;
            width: 15px;
        }

        .auto-style153 {
            width: 15px;
        }

        .auto-style154 {
            width: 17px;
        }

        .auto-style155 {
            height: 24px;
            width: 17px;
        }

        .auto-style156 {
            text-align: right;
        }

        .auto-style157 {
            height: 24px;
            text-align: right;
        }

        .auto-style158 {
            width: 208px;
        }

        .auto-style159 {
            height: 24px;
            width: 208px;
        }

        .auto-style160 {
            width: 269px;
        }

        .auto-style161 {
        }

        .auto-style162 {
            text-align: left;
        }

        .auto-style163 {
            width: 398px;
        }

        .auto-style164 {
            font-size: small;
        }

        .auto-style165 {
            font-size: 15pt;
            width: 435px;
        }

        .auto-style166 {
            text-align: right;
            width: 426px;
        }

        .auto-style167 {
            width: 426px;
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>
</head>
<body style="background-color:#666666;">
    <form id="form1" runat="server">
        <div>

            <table runat="server" id="tblBackground" class="auto-style12" border="0" align="center" style="font-family: 'Century Gothic'">
                <tr>
                    <td class="auto-style86">
                        <table>
                            <tr>
                                <td class="auto-style165" style="font-family: 'century gothic'">
                                    <asp:Image ID="imglogox" runat="server" />
                                    <%--<img alt="" src="../Images/logomits.png" />--%><br />
                                    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                </td>
                                <td class="auto-style91">
                                    <div style="float: left; text-align: left; color: #000000;">
                                        <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                    </div>
                                </td>
                                <td>
        <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />

                                </td>
                                <td>
                                    <%--<img alt="" src="../Images/logoTelcel.png" /></td>--%>
                            </tr>

                            <tr width="100%" style="display:none">
                                <td colspan="3" width="100%" background="../Images/TiraAzul.png" style="font-family: 'century gothic'">
                                    <table id="tblSaldos" background="../Images/TiraAzul.png" runat="server" align="center">
                                        <tr>
                                            <td rowspan="3"><strong>Cliente:</strong></td>
                                            <td rowspan="3" style="text-align: center">
                                                <asp:Label ID="lblCteConnected" runat="server" Style="text-align: right; font-size: small; color: #FFFFFF;" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                            <td rowspan="3" style="text-align: left">&nbsp;</td>
                                            <td rowspan="3" style="text-align: right"><strong>Tipo:</strong></td>
                                            <td rowspan="3">&nbsp;</td>
                                            <td class="auto-style159">&nbsp;</td>
                                            <td class="auto-style150">&nbsp;</td>
                                            <td rowspan="3" class="auto-style160" style="text-align: right"><strong style="text-align: right">Saldo actualizado a:</strong></td>
                                            <td class="auto-style150">&nbsp;</td>
                                            <td class="auto-style155">
                                                <asp:Label ID="lblFechaSaldo" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                            <td class="auto-style152">&nbsp;</td>
                                            <td class="auto-style157"><strong>Usuario Conectado:</strong></td>
                                            <td class="auto-style126">
                                                <asp:Label ID="lblUsrConnected" runat="server" Style="text-align: right; font-size: small; color: #FFFFFF;" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style159">
                                                <asp:Label ID="lblTipoUser" runat="server" Style="text-align: left" Width="100%" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                            <td class="auto-style150"></td>
                                            <td class="auto-style150"></td>
                                            <td class="auto-style155">
                                                <asp:Label ID="lblTime" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                            <td class="auto-style152">&nbsp;</td>
                                            <td class="auto-style157"><strong>Duración de la sesión:</strong></td>
                                            <td class="auto-style126">
                                                <asp:Label ID="lblDuracionSesion" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style158">
                                                <asp:Label ID="lblSaldoGlobal" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Visible="False" Font-Names="Century Gothic">Saldo Global: $ </asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td class="auto-style154">&nbsp;</td>
                                            <td class="auto-style153">&nbsp;</td>
                                            <td class="auto-style156"><strong>Monto Disponible:</strong></td>
                                            <td class="auto-style105">
                                                <asp:Label ID="lblSaldoCliente" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Font-Names="Century Gothic"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <ctrlMenu:TopBar runat="server" ID="TopBar" />

                            <tr background="../images/semitransparente.png">
                                <td class="auto-style126" colspan="3" style="font-family: 'century gothic'">
                                    <span class="auto-style125">
                                        <br />
                                        &nbsp;Pago de Servicios</span></td>
                            </tr>
                            <tr background="../images/semitransparente.png">
                                <td valign="top" class="auto-style110" style="font-family: 'century gothic'">
                                    <%--  <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
                                    <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                        <tbody>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img5"><span class="auto-style131"> </span></td>
                                                <td><a href="TAElectronico.aspx" runat="server" id="opc1"><span class="auto-style131">Compra de Tiempo Aire</span></a></td>
                                            </tr>
                                            <% 
                                                If Not Session("servcol") Is Nothing Then
                                                    Response.Write(Session("servcol").ToString())
                                                End If
                                            %>
                                            <tr runat="server" id="filaBanco">
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img1"><span class="auto-style131"> </span></td>
                                                <td><a href="ctasBancariass.aspx" runat="server" id="A11"><span class="auto-style131">Bancos</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img6"><span class="auto-style131"> </span></td>
                                                <td><a href="EdoCta.aspx" runat="server" id="A1"><span class="auto-style131">Estado de Cuenta</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img7"><span class="auto-style131"> </span></td>
                                                <td><a href="AtCtes.aspx" runat="server" id="A2"><span class="auto-style131">Atención a Clientes</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img8"><span class="auto-style131"> </span></td>
                                                <td><a href="Ctes.aspx" runat="server" id="A3"><span class="auto-style131">Alta Clientes</span></a></td>
                                            </tr>
                                              <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img2"><span class="auto-style131"> </span></td>
                                                <td><a href="Ctesconsulta.aspx" runat="server" id="A12"><span class="auto-style131">Lista Clientes</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img9"><span class="auto-style131"> </span></td>
                                                <td><a href="Deps.aspx" runat="server" id="A4"><span class="auto-style131">Depósitos</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img10"><span class="auto-style131"> </span></td>
                                                <td><a href="Tras.aspx" runat="server" id="A5"><span class="auto-style131">Traspasos</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img11"><span class="auto-style131"> </span></td>
                                                <td><a href="reportes.aspx" runat="server" id="A6"><span class="auto-style131">Informes</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img12"><span class="auto-style131"> </span></td>
                                                <td><a href="DesbloqueaUser.aspx" runat="server" id="A7"><span class="auto-style131">Desbloquear Usuario</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img13"><span class="auto-style131"> </span></td>
                                                <td><a href="Cajas.aspx" runat="server" id="A8"><span class="auto-style131">Cajeros</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img14"><span class="auto-style131"> </span></td>
                                                <td><a href="Noticias.aspx" runat="server" id="A9"><span class="auto-style131">Noticias</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img15"><span class="auto-style131"> </span></td>
                                                <td><a href="CambiarPsw.aspx" runat="server" id="A10"><span class="auto-style131">Cambiar contraseña</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style149">&nbsp;</td>
                                                <td>
                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img16"><span class="auto-style131"> </span></td>
                                                <td><a href="salir.aspx" runat="server" id="opc10"><span class="auto-style131">Salir / Cerrar Sesión</span></a></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style130"></td>
                                                <td class="auto-style130"></td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr class="auto-style131">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />

                                    <br />
                                </td>
                                <td class="auto-style105" colspan="2">
                                    <table id="tblOpcion1">
                                        <tr>
                                            <td class="auto-style166" style="font-family: 'Century Gothic'">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <span class="auto-style164">SERVICIO<strong><br />
                                                    <br />
                                                    <br />
                                                </strong>IMPORTE<strong><br />
                                                    <br />
                                                </strong>
                                                </span>
                                                <br />
                                                <span class="auto-style164">REFERENCIA<br />
                                                    <br />
                                                    CORREO ELECTRÓNICO (OPCIONAL)</span><br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style162" colspan="2">
                                                <br />
                                                <asp:DropDownList ID="ddlServicio" runat="server" AutoPostBack="True" Height="35px" Width="215px"></asp:DropDownList>
                                                <%--<table style="text-align: left; height: 61px; width: 347px;" align="right">
                                                                    <tr>
                                                                        <td class="auto-style123">
                                                                            Compañía</td>
                                                                        <td class="auto-style96" colspan="4">
                                                                            Monto a recargar</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style139" colspan="5">
                                                                            </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style161">
                                                                <asp:Label ID="lblCompany" runat="server" Font-Bold="True" Text="TELCEL" style="text-align: center"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style162">
                                                                            <asp:Image ID="imgOpc20On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" /><asp:Image ID="imgOpc20Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td class="auto-style162">
                                                                            <asp:ImageButton ID="btn20" runat="server" ImageUrl="../Images/20.png" />
                                                                        </td>
                                                                        <td class="auto-style162">
                                                                            <asp:Image ID="imgOpc150On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc150Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td class="auto-style162">
                                                                            <asp:ImageButton ID="btn150" runat="server" ImageUrl="../Images/150.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style124" rowspan="3">
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc30On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc30Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btnRec30" runat="server" ImageUrl="../Images/30.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc200On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc200Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btn200" runat="server" ImageUrl="../Images/200.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc50On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc50Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btnRec50" runat="server" ImageUrl="../Images/50.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc300On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc300Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btn300" runat="server" ImageUrl="../Images/300.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc100On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc100Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btnRec100" runat="server" ImageUrl="../Images/100.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Image ID="imgOpc500On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                            <asp:Image ID="imgOpc500Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="btn500" runat="server" ImageUrl="../Images/500.png" />
                                                                        </td>
                                                                    </tr>
                                                                </table>--%><%-- <table>
                                                                    <tr>
                                                                        <td><table>
                                                                    <tr><td class="auto-style162">Viaducto Bicentenario Recarga 100</td><td class="auto-style163">
                                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="../Images/puntooff.png" runat="server" /> </td><td class="auto-style162"></td></tr>
                                                                    <tr><td>Viaducto Bicentenario Recarga 200</td><td class="auto-style163">
                                                                        <asp:ImageButton ID="ImageButton2" ImageUrl="../Images/puntooff.png" runat="server" style="width: 10px" /></td><td></td></tr>
                                                                    <tr><td>Viaducto Bicentenario Recarga 300</td><td class="auto-style136"><asp:ImageButton ID="ImageButton3" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Telefonía AXTEL</td><td class="auto-style136"><asp:ImageButton ID="ImageButton4" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Televisión CABLEMAS</td><td class="auto-style136"><asp:ImageButton ID="ImageButton5" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Crédito Hipotecario INFONAVIT</td><td class="auto-style136"><asp:ImageButton ID="ImageButton6" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Gas Ecogas</td><td class="auto-style136"><asp:ImageButton ID="ImageButton7" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>GAS NATURAL</td><td class="auto-style136"><asp:ImageButton ID="ImageButton8" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>GOBIERNO TESORERIA DEL GDF</td><td class="auto-style136"><asp:ImageButton ID="ImageButton9" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    


                                                                </table></td>
                                                                        <td class="auto-style164">
                                                                            <table>
                                                                    <tr><td>Luz CFE</td><td class="auto-style136"><asp:ImageButton ID="ImageButton10" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Telefonía TELMEX</td><td class="auto-style136"><asp:ImageButton ID="ImageButton11" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Telefonía TELNOR(BC)</td><td class="auto-style136"><asp:ImageButton ID="ImageButton12" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Television MAXCOM</td><td class="auto-style136"><asp:ImageButton ID="ImageButton13" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Television MEGACABLE</td><td class="auto-style136"><asp:ImageButton ID="ImageButton14" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Television SKY/VTV</td><td class="auto-style136"><asp:ImageButton ID="ImageButton15" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Televisión DISH</td><td class="auto-style136"><asp:ImageButton ID="ImageButton16" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>
                                                                    <tr><td>Televisión VETV</td><td class="auto-style136"><asp:ImageButton ID="ImageButton17" ImageUrl="../Images/puntooff.png" runat="server" /></td><td></td></tr>            
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>--%>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="txtNumber" CssClass="soloNumeros" Style="text-align: right; font-size: x-large;" runat="server" Width="100px" Height="25px"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="txtConfirmNumber" Style="text-align: right; font-size: x-large;" runat="server" AutoPostBack="True" Width="215px" Height="25px"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="txtCorreoInforme" runat="server" Style="text-align: right; font-size: x-large;" Width="215px" Height="25px"></asp:TextBox>
                                                <br />
                                                <asp:Label ID="lblEstado" runat="server" Style="font-weight: 700; font-size: small;" Width="100%"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnAplicar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="PAGAR" ToolTip="Aplicar el pago del servicio seleccionado" Width="139px" />
                                                <br />
                                                <asp:Label ID="lblMessage" Width="100%" runat="server" Style="color: #006600; font-size: small; font-weight: 700;" Height="16px"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style162" rowspan="4">
                                                <asp:Image ID="imgInfoRefServicioSelec" runat="server" />
                                            </td>
                                            <td class="auto-style109" rowspan="3" background="../Images/continente.png">
                                                <%--<div style="overflow: hidden; height: 20px">--%><%--<div style="height:20px">
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="36px" Width="610px" style="text-align: center; font-size: 9pt;" DataSourceID="sqlDB">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="Fecha" SortExpression="FECHA" >
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA" >
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO" >
                                                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO" >
                                                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="COMPANIA" HeaderText="Compañía" SortExpression="COMPANIA" >
                                                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FOLIO_TRANS" HeaderText="Folio/Trans." ReadOnly="True" SortExpression="FOLIO_TRANS" >
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                </asp:GridView>
                                                                </div>--%>
                                                <div style="overflow: auto; width: 630px; height: 164px; align: left;">
                                                    <asp:GridView ShowHeader="true" ID="grdResumenRecargas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="65px" Width="610px" Style="text-align: left; font-size: 9pt;" DataSourceID="sqlDB">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="Fecha" SortExpression="FECHA">
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NUMERO" HeaderText="Referencia" SortExpression="NUMERO">
                                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO">
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="COMPANIA" HeaderText="Servicio" SortExpression="COMPANIA">
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FOLIO_TRANS" HeaderText="Folio/Trans." ReadOnly="True" SortExpression="FOLIO_TRANS">
                                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                </div>
                                                <asp:SqlDataSource ID="sqlDB" runat="server" ConnectionString="Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;user id=AppTopItUp; password=.TopItUp2017**.!;timeout=500000;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="Get_TransServiceByUSer" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:SessionParameter DefaultValue="-1" Name="vpPkUserConnected" SessionField="USR_CONNECTED" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>

                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />

                                            </td>
                                        </tr>
                                        <td class="auto-style167">&nbsp;</td>
                                        <td class="auto-style161" colspan="2">
                                            <br />
                                            <br />
                                        </td>
                                        <tr>
                                            <td class="auto-style167">&nbsp;</td>
                                            <td class="auto-style163">&nbsp;</td>
                                            <td class="auto-style163">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center" class="auto-style167">&nbsp;</td>
                                            <td style="text-align: center" class="auto-style163">&nbsp;</td>
                                            <td style="text-align: center" class="auto-style163">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                   <tr>
                            <td>
                                <table style="width:100%">
                                    <tr><td align="right">

                            <img src="../Images/logomits.png" />
                            </td>
                            <td style="width:20px"></td></tr>
                                </table>
                            </td>
                       </tr>
            </table>

            </td></tr>
            
            </table>
        </div>

        <script src="../Scripts/jquery-1.10.2.min.js"></script>
        <script src="../Scripts/Validaciones.js"></script>

        <ajaxToolkit:ModalPopupExtender ID="mpeDatosPlan" runat="server" TargetControlID="pnlDetalleAux"
            PopupControlID="pnlDetalle" OkControlID="btnYes" BackgroundCssClass="modalBackground" DropShadow="true" />
        <asp:Panel runat="server" ID="pnlDetalleAux" Style="display: none">
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlDetalle" CssClass="modalPopup" Style="display: none;">
            <div class="header">
                Anuncio
            </div>
            <div class="body">
                <asp:Label ID="lblAnuncio" runat="server" Text=""></asp:Label>
            </div>
            <div class="footer" align="right">
                <asp:Button ID="btnYes" runat="server" Text="Aceptar" CssClass="yes" />
                <%--<asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
            </div>
        </asp:Panel>

    </form>

</body>
</html>
