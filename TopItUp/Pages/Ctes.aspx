<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ctes.aspx.vb" Inherits="TopItUp.Ctes" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
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

        .auto-style131 {
            font-size: small;
            color:white;
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

        .auto-style160 {
            width: 269px;
        }

        .auto-style167 {
            font-size: medium;
            width: 53px;
        }

        .auto-style168 {
            text-align: center;
            font-weight: bold;
        }

        .auto-style169 {
            width: 1023px;
            text-align: center;
        }

        .auto-style172 {
        }

        .auto-style174 {
            width: 475px;
            text-align: center;
        }

        .auto-style178 {
            font-size: x-small;
        }

        .auto-style188 {
            width: 2978px;
        }

        .auto-style189 {
            font-size: 8pt;
            text-align: left;
        }

        .auto-style190 {
            font-size: x-small;
            text-align: right;
        }

        .auto-style184 {
            font-size: x-small;
            text-align: center;
        }

        .auto-style179 {
            font-size: 8pt;
        }

        .auto-style185 {
            font-weight: normal;
        }

        .auto-style191 {
            font-size: x-small;
            text-align: center;
            height: 24px;
        }

        .auto-style192 {
            font-size: 8pt;
            height: 24px;
        }

        .auto-style193 {
            height: 24px;
        }

        .auto-style194 {
            font-size: x-small;
            text-align: right;
            width: 71px;
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>
</head>
<script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Scripts/Validaciones.js"></script>
<body style="margin-top: 0; background-color:#666666;">
    <form id="form1" runat="server" style="font-family: 'Century Gothic'">
        <table id="tblBackground" runat="server" class="auto-style12" border="0" align="center">
            <tr>
                <td class="auto-style87">
                    <table class="auto-style12">
                        
                            <td class="auto-style100">
                                <asp:Image ID="imglogox" runat="server" />
                                <%--<img alt="" src="../Images/logomits.png" />--%>
                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                </asp:ScriptManager>
                            </td>
                            <td class="auto-style91">
                                <div style="float: left; text-align: left; color: #000000;">
                                    <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                </div>
                               </td> <td>
                                   <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr width="100%" style="display:none">
                            <td colspan="3" width="100%" background="../Images/TiraAzul.png">
                                <table id="tblSaldos" background="../Images/TiraAzul.png" runat="server" align="center">
                                    <tr>
                                        <td rowspan="3"><strong>Cliente:</strong></td>
                                        <td rowspan="3" style="text-align: center">
                                            <asp:Label ID="lblCteConnected" runat="server" Style="text-align: right; font-size: small; color: #FFFFFF;" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td rowspan="3" style="text-align: left">&nbsp;</td>
                                        <td rowspan="3" style="text-align: right"><strong>Tipo:</strong></td>
                                        <td rowspan="3">&nbsp;</td>
                                        <td class="auto-style158">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td rowspan="3" class="auto-style160" style="text-align: right"><strong style="text-align: right">Saldo actualizado a:</strong></td>
                                        <td>&nbsp;</td>
                                        <td class="auto-style155">
                                            <asp:Label ID="lblFechaSaldo" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td class="auto-style152">&nbsp;</td>
                                        <td class="auto-style157"><strong>Usuario Conectado:</strong></td>
                                        <td class="auto-style126">
                                            <asp:Label ID="lblUsrConnected" runat="server" Style="text-align: right; font-size: small; color: #FFFFFF;" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td style="text-align: right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style158">
                                            <asp:Label ID="lblTipoUser" runat="server" Style="text-align: left" Width="100%" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td class="auto-style154">
                                            <asp:Label ID="lblTime" runat="server" Width="100%" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td class="auto-style153">&nbsp;</td>
                                        <td class="auto-style156"><strong>Duración de la sesión:</strong></td>
                                        <td class="auto-style105">
                                            <asp:Label ID="lblDuracionSesion" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                        <td style="text-align: right">&nbsp;</td>
                                        <td>&nbsp;</td>
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
                                            <asp:Label ID="lblSaldoCliente" runat="server" Style="text-align: right; font-weight: 700; font-size: 12pt;" Font-Names="Century Gothic"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                         
            <ctrlMenu:TopBar runat="server" ID="TopBar" />

                        <tr background="../Images/semitransparente.png">
                            <td class="auto-style126" colspan="3" style="font-family: 'Century Gothic'">
                                <span class="auto-style125" style="font-family: 'Century Gothic'">
                                    <br />
                                    &nbsp;Clientes / Alta y Baja&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                <asp:Button ID="btnViewGridUsersByCliente0" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="ALTA DE CLIENTE" ToolTip="Consultar, modificar y borrar Cliente" Width="161px" />
                                &nbsp;<asp:Button ID="btnViewGridUsersByCliente" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="VER LISTA DE CLIENTES" ToolTip="Consultar, modificar y borrar Cliente" Width="161px" />
                            </td>
                        </tr>
                        <tr background="../Images/semitransparente.png">
                            <td valign="top" class="auto-style110" style="font-family: 'Century Gothic'">
                                <%--   <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
                                <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                    <tbody>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img3"><span class="auto-style131"> </span></td>
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
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img4"><span class="auto-style131"> </span></td>
                                            <td><a href="EdoCta.aspx" runat="server" id="A1"><span class="auto-style131">Estado de Cuenta</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img5"><span class="auto-style131"> </span></td>
                                            <td><a href="AtCtes.aspx" runat="server" id="A2"><span class="auto-style131">Atención a Clientes</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img6"><span class="auto-style131"> </span></td>
                                            <td><a href="Ctes.aspx" runat="server" id="A3"><span class="auto-style131">Alta Clientes</span></a></td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img2"><span class="auto-style131"> </span></td>
                                            <td><a href="CtesConsulta.aspx" runat="server" id="A12"><span class="auto-style131">Lista Clientes</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img7"><span class="auto-style131"> </span></td>
                                            <td><a href="Deps.aspx" runat="server" id="A4"><span class="auto-style131">Depósitos</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img8"><span class="auto-style131"> </span></td>
                                            <td><a href="Tras.aspx" runat="server" id="A5"><span class="auto-style131">Traspasos</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img9"><span class="auto-style131"> </span></td>
                                            <td><a href="reportes.aspx" runat="server" id="A6"><span class="auto-style131">Informes</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img10"><span class="auto-style131"> </span></td>
                                            <td><a href="DesbloqueaUser.aspx" runat="server" id="A7"><span class="auto-style131">Desbloquear Usuario</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img11"><span class="auto-style131"> </span></td>
                                            <td><a href="Cajas.aspx" runat="server" id="A8"><span class="auto-style131">Cajeros</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img12"><span class="auto-style131"> </span></td>
                                            <td><a href="Noticias.aspx" runat="server" id="A9"><span class="auto-style131">Noticias</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img13"><span class="auto-style131"> </span></td>
                                            <td><a href="CambiarPsw.aspx" runat="server" id="A10"><span class="auto-style131">Cambiar contraseña</span></a></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style149">&nbsp;</td>
                                            <td>
                                                <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img14"><span class="auto-style131"> </span></td>
                                            <td><a href="Salir.aspx" runat="server" id="opc10"><span class="auto-style131">Salir / Cerrar Sesión</span></a></td>
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
                            <td class="auto-style105" colspan="2" style="font-family: 'Century Gothic'">
                                <table id="tblOpcion1" runat="server" visible="false">
                                    <td>
                                        <tr>
                                            <td class="auto-style172"></td>
                                            <td class="auto-style188">Nombre del nuevo cliente<br />
                                                <asp:TextBox ID="txtNombre" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="25px" MaxLength="250"></asp:TextBox>
                                                <br />
                                                Dirección Completa<br />
                                                <asp:TextBox ID="txtDireccionCompeta" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="68px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                                <br />
                                                Nombre del usuario asignado<br />
                                                <asp:TextBox ID="txtUserAsignado" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="25px" MaxLength="250"></asp:TextBox>
                                                <br />
                                                RFC<br />
                                                <asp:TextBox ID="txtRFC" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="25px" MaxLength="13"></asp:TextBox>
                                                Teléfonos de contacto<br />
                                                <asp:TextBox ID="txtTelefonoContacto" Style="text-align: right; font-size: medium;" runat="server" Width="100%" Height="25px" TextMode="Phone" MaxLength="500"></asp:TextBox>
                                                <br />
                                                Correo electrónico (opcional)<br />
                                                <asp:TextBox ID="txtCorreoElec" Style="text-align: right; font-size: medium;" runat="server" Width="100%" Height="25px" TextMode="Email" MaxLength="250"></asp:TextBox>
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
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style167"></td>
                                            <td>&nbsp;</td>
                                            <td class="auto-style169" rowspan="2">Nivel Superior 
                                                <asp:TextBox ID="txtNombreCteNivelSuperior" Style="text-align: left; font-size: x-small;" runat="server" Width="100%" Height="25px" Enabled="False"></asp:TextBox>
                                                <asp:DropDownList ID="ddlCtes" runat="server" AutoPostBack="True" Height="25px" Width="100%" Visible="False">
                                                </asp:DropDownList>
                                                <br />
                                                <br />
                                                <br />

                                                <table border="0" align="center">
                                                    <tr>
                                                        <td class="auto-style131" colspan="4" style="text-align: center"><strong>TELEFONÍAS :: PRIVILEGIOS</strong></td>
                                                    </tr>
                                                    <tr class="auto-style178">
                                                        <td class="auto-style168">
                                                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style168">TELEFONÍA</td>
                                                        <td class="auto-style168">COMISIÓN MÁXIMA</td>
                                                        <td class="auto-style168">COMISIÓN</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style191">
                                                            <asp:CheckBox ID="chkTelcel" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style192">TELCEL</td>
                                                        <td class="auto-style157"><strong class="auto-style185">
                                                            <asp:Label ID="lblComMaxTelcel" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td class="auto-style193">
                                                            <asp:TextBox ID="txtComTelcel" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="chkMovi" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">MOVISTAR</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblComMaxMovi" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtComMovi" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="chkIusa" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">IUSACELL</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblComMaxIusa" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtComIusa" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="chkNextel" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">NEXTEL</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblComMaxNextel" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtComNextel" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="chkUnefon" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">UNEFON</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblComMaxUnefon" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtComUnefon" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <%--NUEVAS COMPAÑIAS INICIO --%>

                                               

                                                     <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="cboxvirgin" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">VIRGIN</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblcomvirgin" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtcomvirgin" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                     <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="cboxcierto" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">CIERTO</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblcomcierto" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtcomcierto" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                     <tr>
                                                        <td class="auto-style184">
                                                            <asp:CheckBox ID="cboxmaztiempo" runat="server" AutoPostBack="True" Font-Names="Century Gothic" />
                                                        </td>
                                                        <td class="auto-style179">MAZTIEMPO</td>
                                                        <td class="auto-style156"><strong class="auto-style185">
                                                            <asp:Label ID="lblcommaztiempo" runat="server" Font-Names="Century Gothic"></asp:Label>
                                                        </strong>%</span></td>
                                                        <td>
                                                            <asp:TextBox ID="txtcommaztiempo" runat="server" Width="40px" CssClass="auto-style178" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <%--FIN NUEVAS COMPAÑIAS --%>

                                                </table>
                                                <br />
                                                <br />
                                                Razón social<br />
                                                <asp:DropDownList ID="ddlCatRazonSocial" runat="server" AutoPostBack="True" Height="25px" Width="100%">
                                                </asp:DropDownList>
                                                <br />
                                                <br />
                                                Contraseña asignada<br />
                                                <asp:TextBox ID="txtPsw" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="25px" TextMode="Password" MaxLength="75"></asp:TextBox>
                                                <br />
                                                Repita Contraseña Asignada<br />
                                                <asp:TextBox ID="txtPswConfirm" Style="text-align: left; font-size: medium;" runat="server" Width="100%" Height="25px" TextMode="Password" MaxLength="75"></asp:TextBox>
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
                                            <td class="auto-style174" rowspan="2">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <table>
                                                    <tr><td style="width:20px"></td><td>
                                                           <asp:Panel ID="Panel1" runat="server" Height="405px" Width="326px">

                                                    <div style="overflow-y:scroll; height:400px">

                                                        <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" DataKeyNames="PK_CAT_SERVICIO" GridLines="None">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                 
                                                                  <asp:TemplateField >
                                                                      <HeaderTemplate >
                                                                          <asp:CheckBox ID="cboxallservicio" ClientIDMode="Static" runat="server" />
                                                                      </HeaderTemplate>
                                                                      <ItemTemplate>
                                                                          <asp:CheckBox ID="cboxservicio" CssClass="classservicios" runat="server" />
                                                                      </ItemTemplate>
                                                                  </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Servicio"  DataField="DESCRIPCION" />
                                                              
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

                                                    <%--<table border="0" align="center">
                                                        <tr>
                                                            <td class="auto-style131" colspan="6" style="text-align: center"><strong>SERVICIOS :: PRIVILEGIOS</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cboxCheckAll" AutoPostBack="true" Checked="true" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">TAG Viaducto Bicentenario :: 100 MXN</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox3" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">TAG Viaducto Bicentenario :: 200 MXN</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox4" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">TAG Viaducto Bicentenario :: 300 MXN</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox5" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Axtel</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox6" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Cablemas</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox7" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Crédito Hipotecario</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox8" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Eco Gas</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox9" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Gas Natural</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox10" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Tesorería GDF</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox11" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Luz CFE</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox12" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Telmex</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox13" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Televisión Telnor</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox14" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Televisión Maxcom</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox15" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Megacable</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox16" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">SKY</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'"></td>
                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">
                                                                <asp:CheckBox ID="CheckBox17" runat="server" Checked="True" Font-Names="Century Gothic" /></td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Dish</td>
                                                            <td class="auto-style156"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style194">
                                                                <asp:CheckBox ID="CheckBox18" runat="server" Checked="True" Font-Names="Century Gothic" />
                                                            </td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">Ve TV</td>
                                                            <td class="auto-style156" style="font-family: 'Century Gothic'">&nbsp;</td>

                                                            <td class="auto-style190" style="font-family: 'Century Gothic'">&nbsp;</td>
                                                            <td class="auto-style189" style="font-family: 'Century Gothic'">&nbsp;</td>
                                                            <td class="auto-style156">&nbsp;</td>
                                                            <tr>
                                                                <td class="auto-style190" colspan="5">
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
                                                                    <asp:Label ID="lblMessage" runat="server" Height="16px" Style="color: #006600; font-size: medium; font-weight: 700; text-align: left;" Width="100%"></asp:Label>
                                                                    <asp:Button ID="btnActivarCte" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="ACTIVAR CLIENTE" ToolTip="Activar Cliente" Width="139px" />
                                                                    <br />
                                                                </td>
                                                                <td class="auto-style156">&nbsp;</td>
                                                            </tr>
                                                    </table>--%>
                                                    <asp:Label ID="lblMessage" runat="server" Height="16px" Style="color: #006600; font-size: medium; font-weight: 700; text-align: left;" Width="100%"></asp:Label>
                                                                    <asp:Button ID="btnActivarCte" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="ACTIVAR CLIENTE" ToolTip="Activar Cliente" Width="139px" />
                                                    <br />
                                                    <br />
                                                </asp:Panel>
                                                     </td></tr>
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
                                        </tr>
                                        <tr>
                                            <td class="auto-style172" colspan="4">&nbsp;</td>
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
                </td>
            </tr>
        </table>
        </td>
                                    </tr>
                                    </table>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
        <script src="../Scripts/Validaciones.js"></script>

        
    </form>
    <script>
       
        $(function () {
            $(document).on("change", "#cboxallservicio", function () {
                
                if ($(this).is(":checked"))
                {
                    $(".classservicios").children().prop("checked", true);
                }
                else
                {
                    $(".classservicios").children().prop("checked", false);
                }

            });
        });

    </script>
</body>
</html>
