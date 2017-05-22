<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Noticias.aspx.vb" Culture="Auto" UICulture="Auto" EnableEventValidation="false" Inherits="TopItUp.Noticias1" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/Validaciones.js"></script>
    <title>Noticias</title>
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

        #progress {
            z-index: 500;
            background-color: gray;
            filter: alpha(opacity=60);
            opacity: 0.6;
            z-index: 999;
            position: absolute;
            top: 0pt;
            left: 0pt;
            border: solid 1px black;
            padding: 5px 5px 5px 5px;
            text-align: center;
        }

        #progressBackgroundFilter {
            position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: #000;
            filter: alpha(opacity=50);
            opacity: 0.5;
            z-index: 1000;
        }

        #processMessage {
            position: fixed;
            top: 30%;
            left: 43%;
            padding: 10px;
            width: 14%;
            z-index: 1001;
            background-color: #fff;
            border: solid 1px #000;
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
            width: 189px;
            height: 32px;
        }

        .auto-style162 {
            width: 196px;
            height: 32px;
            text-align: right;
        }

        .auto-style164 {
            background-color: #FFFFFF;
            height: 20px;
        }

        .auto-style165 {
            font-size: small;
        }

        .auto-style166 {
            height: 32px;
        }

        .auto-style167 {
            font-size: small;
            height: 170px;
            text-align: right;
            width: 284px;
        }

        .auto-style168 {
            height: 170px;
        }

        .auto-style171 {
            width: 196px;
            height: 32px;
            text-align: left;
        }

        .auto-style172 {
            height: 32px;
            width: 301px;
        }

        .auto-style173 {
            width: 301px;
        }

        .auto-style174 {
            width: 141px;
        }

        .auto-style180 {
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>

    <script type="text/javascript">
        function ValidaFecha_Cliente(source, clientside_arguments) {
            clientside_arguments.IsValid = false;
            clientside_arguments.IsValid = validaFechaDDMMAAAA(clientside_arguments.Value)
            return clientside_arguments.IsValid;
        }

        function ValidaFecha_Cliente2(source, clientside_arguments) {
            clientside_arguments.IsValid = false;
            clientside_arguments.IsValid = validaFechaDDMMAAAA(clientside_arguments.Value)
            return clientside_arguments.IsValid;
        }
    </script>
</head>
<body style="background-color:#666666;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" EnablePartialRendering="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upmain" runat="server">
            <ContentTemplate>
                <table runat="server" id="tblBackground" class="auto-style12" border="0" align="center" style="font-family: 'Century Gothic'">
                    <tr>
                        <td class="auto-style87">
                            <table class="auto-style12" style="font-family: 'CENTURY Gothic'">
                                <tr>
                                    <td class="auto-style86" style="font-family: 'century gothic'">
                                        <table>
                                            <tr>
                                                <td class="auto-style100" style="font-family: 'century gothic'">
                                                    <asp:Image ID="imglogox" runat="server" />
                                                    <%--<img alt="" src="../Images/logomits.png" />--%>
                                                </td>
                                                <td class="auto-style91">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                <td>
                                                    <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" /></td>
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
                                                                <asp:Label ID="lblFechaSaldo" runat="server" Font-Names="Century Gothic" Style="text-align: right"></asp:Label>
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
                                                        &nbsp;Noticias</span></td>
                                            </tr>
                                            <tr background="../images/semitransparente.png">
                                                <td valign="top" class="auto-style110" style="font-family: 'century gothic'">
                                                    <%-- <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
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
                                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img17"><span class="auto-style131"> </span></td>
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
                                                                    <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img18"><span class="auto-style131"> </span></td>
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
                                                    <table style="width: 950px">
                                                        <tr>
                                                            <td background="../Images/TiraAzul.png" colspan="6" style="text-align: center" class="auto-style164">
                                                                <asp:Label runat="server" ID="lblDescBusqNot" Text="BÚSQUEDA DE NOTICIAS" Style="color: #FFFFFF; font-size: small; font-weight: 700;"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right" class="auto-style172"><span class="auto-style165">FECHA DE INICIO</span> </td>
                                                            <td class="auto-style171">
                                                                <asp:TextBox ID="txtFechaIni" runat="server"></asp:TextBox>
                                                                <img src="../images/ico_calendar.png" id="img1" alt="" />
                                                                <ajaxToolkit:CalendarExtender runat="server" ID="dtxFecha_Inicio" TargetControlID="txtFechaIni"
                                                                    PopupButtonID="img1" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="rfvtFecha_Inicio" ValidationGroup="vgBusquedaNoticias" runat="server" ControlToValidate="txtFechaIni"
                                                                    CssClass="label" ErrorMessage='El campo "Fecha Inicio" es requerido' ToolTip='El campo "Fecha Inicio" es requerido'
                                                                    Display="None" SetFocusOnError="true">
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="vceFecha_Inicio" TargetControlID="rfvtFecha_Inicio">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                <asp:CustomValidator ID="cvFecha_Inici" ValidationGroup="vgBusquedaNoticias" runat="server" SetFocusOnError="true" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy"
                                                                    Display="None" ControlToValidate="txtFechaIni"
                                                                    ClientValidationFunction="ValidaFecha_Cliente">
                                                                </asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="vceFecha_InicioV" TargetControlID="cvFecha_Inici">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            <td class="auto-style166"></td>
                                                            <td style="text-align: right" class="auto-style166">&nbsp;</td>
                                                            <td class="auto-style161">&nbsp;<ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtFechaFin"
                                                                PopupButtonID="img2" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style172" style="text-align: right"><span class="auto-style165">FECHA FINAL</span> </td>
                                                            <td class="auto-style171">
                                                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                                                <img src="../images/ico_calendar.png" id="img2" alt="" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaFin" CssClass="label" Display="None" ErrorMessage="El campo &quot;Fecha Fin&quot; es requerido" SetFocusOnError="true" ToolTip="El campo &quot;Fecha Fin&quot; es requerido" ValidationGroup="vgBusquedaNoticias">*
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidaFecha_Cliente2" ControlToValidate="txtFechaFin" Display="None" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy" SetFocusOnError="true" ValidationGroup="vgBusquedaNoticias">
                                                                </asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="CustomValidator1">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            <td class="auto-style166">&nbsp;</td>
                                                            <td class="auto-style166" style="text-align: right">&nbsp;</td>
                                                            <td class="auto-style161">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style172" style="text-align: right">&nbsp;</td>
                                                            <td class="auto-style162">
                                                                <asp:Button ID="btnBuscar" runat="server" BorderColor="#003366" CausesValidation="true" Font-Bold="False" Font-Names="Century Gothic" Height="28px" OnClick="btnBuscar_Click" Style="color: #FFFFFF; background-color: #002142" Text="BUSCAR" ToolTip="Buscar noticias" ValidationGroup="vgBusquedaNoticias" Width="139px" />
                                                            </td>
                                                            <td class="auto-style166">&nbsp;</td>
                                                            <td class="auto-style166" style="text-align: right">&nbsp;</td>
                                                            <td class="auto-style161">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style173">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td background="../Images/TiraAzul.png" class="auto-style164" colspan="6" style="text-align: center">
                                                                <asp:Label ID="lblDescBusqNot0" runat="server" Style="color: #FFFFFF; font-size: small; font-weight: 700;" Text="ALTA / MODIFICACIÓN"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style173">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="grdNoticias" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="36px" Width="100%" Style="text-align: center; font-size: 9pt;"
                                                                    DataKeyNames="pk_Noticia">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <Columns>

                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cboxEliminar" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:BoundField DataField="Noticia" HeaderText="Noticia">
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Fecha_Inicio" DataFormatString="{0:d}" HeaderText="Fecha Inicio">
                                                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Fecha_Fin" DataFormatString="{0:d}" HeaderText="Fecha Fin">
                                                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS">
                                                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
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
                                                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkTodosClientes" Text="LA VERÁN TODOS" runat="server" AutoPostBack="true" OnCheckedChanged="chkTodosClientes_CheckedChanged" Style="font-size: small" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style167">CLIENTES QUE VERÁN LA NOTICIA</td>
                                                            <td colspan="4" class="auto-style168">
                                                                <asp:ListBox ID="chkClientes" runat="server" SelectionMode="Multiple" Height="162px" Width="449px" Font-Names="CENTURY Gothic"></asp:ListBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vgGuardaNoticia" runat="server" ControlToValidate="chkClientes"
                                                                    CssClass="label" ErrorMessage='Seleccionar Cliente(s)' ToolTip='Seleccionar Cliente(s)'
                                                                    Display="None" SetFocusOnError="true">
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender7" TargetControlID="RequiredFieldValidator4">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right" class="auto-style165">FECHA DE INICIO</td>
                                                            <td class="auto-style174">
                                                                <asp:TextBox ID="DteFechaInicio" runat="server" Width="67%" CssClass="auto-style180" Height="25px"></asp:TextBox>
                                                                <img src="../images/ico_calendar.png" id="img3" alt="" />
                                                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="DteFechaInicio"
                                                                    PopupButtonID="img3" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgGuardaNoticia" runat="server" ControlToValidate="DteFechaInicio"
                                                                    CssClass="label" ErrorMessage='El campo "Fecha Inicio" es requerido' ToolTip='El campo "Fecha Inicio" es requerido'
                                                                    Display="None" SetFocusOnError="true">
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator2">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                <asp:CustomValidator ID="CustomValidator2" ValidationGroup="vgGuardaNoticia" runat="server" SetFocusOnError="true" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy"
                                                                    Display="None" ControlToValidate="DteFechaInicio"
                                                                    ClientValidationFunction="ValidaFecha_Cliente">
                                                                </asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender4" TargetControlID="CustomValidator2">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            <td style="text-align: right" class="auto-style165">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkActivo" Text="Activo" runat="server" Style="font-size: small;" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style165" style="text-align: right">FECHA FINAL</td>
                                                            <td class="auto-style174">
                                                                <asp:TextBox ID="DteFechaFin" runat="server" CssClass="auto-style180" Height="25px" Width="67%"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="img4" TargetControlID="DteFechaFin" />
                                                                <img src="../images/ico_calendar.png" id="img4" alt="" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DteFechaFin" CssClass="label" Display="None" ErrorMessage="El campo &quot;Fecha Inicio&quot; es requerido" SetFocusOnError="true" ToolTip="El campo &quot;Fecha Inicio&quot; es requerido" ValidationGroup="vgGuardaNoticia">
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator3">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidaFecha_Cliente" ControlToValidate="DteFechaFin" Display="None" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy" SetFocusOnError="true" ValidationGroup="vgGuardaNoticia">
                                                                </asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="CustomValidator3">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                            </td>
                                                            <td class="auto-style165" style="text-align: right">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkAununcio" runat="server" Style="font-size: small;" Text="Anuncio" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Noticia:</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5" style="text-align: right">
                                                                <asp:TextBox ID="txtNoticia" runat="server" TextMode="MultiLine" Height="121px" Width="100%"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="vgGuardaNoticia" runat="server" ControlToValidate="txtNoticia"
                                                                    CssClass="label" ErrorMessage='El campo "Noticia" es requerido' ToolTip='El campo "Noticia" es requerido'
                                                                    Display="None" SetFocusOnError="true">
                                                                </asp:RequiredFieldValidator>
                                                                <br />
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender8" TargetControlID="RequiredFieldValidator5">
                                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                                <br />
                                                                <asp:Button ID="btnNuevo" runat="server" BorderColor="#003366" CausesValidation="false" Font-Bold="False" Font-Names="Century Gothic" Height="28px" OnClick="btnNuevo_Click" Style="color: #FFFFFF; background-color: #002142" Text="Nuevo" ToolTip="Procesar noticia" Width="139px" />
                                                                <asp:Button ID="btnGuardar" runat="server" BorderColor="#003366" CausesValidation="true" Font-Bold="False" Font-Names="Century Gothic" Height="28px" OnClick="btnGuardar_Click" Style="color: #FFFFFF; background-color: #002142" Text="Guardar" ToolTip="Guardar Noticia" ValidationGroup="vgGuardaNoticia" Width="139px" />
                                                                <br />
                                                                <asp:Label ID="lblMessage" runat="server" Height="16px" Style="color: #006600; font-size: small; font-weight: 700;" Width="100%"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:HiddenField ID="hdnIdNoticia" runat="server" Value="0" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
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
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upmain"
            DisplayAfter="100" DynamicLayout="true">
            <ProgressTemplate>
                <div id="blur">
                </div>
                <div id="progressBackgroundFilter" style="vertical-align: middle; height: 100%; width: 100%">
                    <div class="processMessage" style="position: center !important">
                        <img src="../Images/procesandoimg.gif" style="position: absolute; top: 50%; left: 50%" />
                    </div>


                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />
    </form>

    <%--  <script lang="ja" type="text/javascript" >
        Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(
                    function () {
                        if (document.getElementById) {
                            var progress = document.getElementById('progress');
                            var blur = document.getElementById('blur');
                            //progress.style.width = '300px';
                            //progress.style.height = '300px';
                            blur.style.height = document.documentElement.scrollHeight / 2;
                            progress.style.top = document.documentElement.scrollHeight / 3 - progress.style.height.replace('px', '') / 2 + 'px';
                            progress.style.left = document.body.offsetWidth / 2 - progress.style.width.replace('px', '') / 2 + 'px';
                        }
                    }
               )
</script> --%>
</body>
</html>
