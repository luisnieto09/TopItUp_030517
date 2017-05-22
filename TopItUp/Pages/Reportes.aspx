<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Reportes.aspx.vb" Inherits="TopItUp.Reportes" Culture="auto" UICulture="auto" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/Validaciones.js"></script>
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

        .auto-style112 {
            width: 387px;
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
            font-size: small;
        }

        .auto-style162 {
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
        <table runat="server" id="tblBackground" class="auto-style12" border="0" align="center" style="font-family: 'Century Gothic'">
            <tr>
                <td class="auto-style87">
                    <table class="auto-style12" style="font-family: 'century Gothic'">
                        <tr>
                            <td class="auto-style86">
                                <table>
                                    <tr>
                                        <td class="auto-style100">
                                            <asp:Image ID="imglogox" runat="server" />
                                           <%-- <img alt="" src="../Images/logomits.png" />--%><br />
                                            &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" EnablePartialRendering="true">
                                            </asp:ScriptManager>

                                        </td>
                                        <td class="auto-style91">
                                            <div style="float: left;  text-align: left; color: #000000;">
                                                <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                            </div>
                                           
                                        </td>
                                         <td>
                                                     <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />
                                         </td>
                                        <td>
                                            <br />
                                        </td>
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
                                        <td class="auto-style126" colspan="3">
                                            <span class="auto-style125">
                                                <br />
                                                &nbsp;Reportes</span></td>
                                    </tr>
                                    <tr background="../images/semitransparente.png">
                                        <td valign="top" class="auto-style110">
                                            <%--     <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
                                            <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                                <tbody>
                                                    <tr runat="server" id="ocultaruno">
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
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img15"><span class="auto-style131"> </span></td>
                                                        <td><a href="ctasBancariass.aspx" runat="server" id="A11"><span class="auto-style131">Bancos</span></a></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img4"><span class="auto-style131"> </span></td>
                                                        <td><a href="EdoCta.aspx" runat="server" id="A1"><span class="auto-style131">Estado de Cuenta</span></a></td>
                                                    </tr>
                                                    <tr id="ocultartres" runat="server" >
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img2"><span class="auto-style131"> </span></td>
                                                        <td><a href="AtCtes.aspx" runat="server" id="A2"><span class="auto-style131">Atención a Clientes</span></a></td>
                                                    </tr>
                                                    <tr id="ocultarcuatro" runat="server" >
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img6"><span class="auto-style131"> </span></td>
                                                        <td><a href="Ctes.aspx" runat="server" id="A3"><span class="auto-style131">Alta Clientes</span></a></td>
                                                    </tr>
                                                      <tr id="ocultarcinco" runat="server" >
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img16"><span class="auto-style131"> </span></td>
                                                        <td><a href="Ctesconsulta.aspx" runat="server" id="A12"><span class="auto-style131">Lista Clientes</span></a></td>
                                                    </tr>
                                                    <tr runat="server" id="ocultarseis">
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img7"><span class="auto-style131"> </span></td>
                                                        <td><a href="Deps.aspx" runat="server" id="A4"><span class="auto-style131">Depósitos</span></a></td>
                                                    </tr>
                                                    <tr runat="server" id="ocultarsiete">
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
                                                    <tr runat="server" id="ocultarocho">
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img10"><span class="auto-style131"> </span></td>
                                                        <td><a href="DesbloqueaUser.aspx" runat="server" id="A7"><span class="auto-style131">Desbloquear Usuario</span></a></td>
                                                    </tr>
                                                    <tr runat="server" id="ocultarnueve">
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img11"><span class="auto-style131"> </span></td>
                                                        <td><a href="Cajas.aspx" runat="server" id="A8"><span class="auto-style131">Cajeros</span></a></td>
                                                    </tr>
                                                    <tr runat="server" id="ocultardiez">
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
                                        </td>
                                        <td colspan="3">
                                            <table id="tblOpcion" style="background-position: right; background-repeat: no-repeat">
                                                <tr>
                                                    <td background="../Images/TiraAzul.png" colspan="2" style="text-align: center">
                                                        <asp:Label runat="server" ID="lblDescBusqNot" Text="INFORMES" Style="color: #FFFFFF; font-size: medium; font-weight: 700;"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style112" colspan="2">
                                                        <table style="text-align: left; height: 61px; width: 683px;" align="right">
                                                            <tr>
                                                                <td class="auto-style162">
                                                                    <label runat="server" id="lblReporte">REPORTE</label><b> </b>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:DropDownList ID="Reporte" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Reporte_SelectedIndexChanged1" CssClass="auto-style162">
                                                                        <asp:ListItem Text="Seleccione" Value="0" />
                                                                        <asp:ListItem Text="Infome de Ventas por compañia" Value="1" />
                                                                        <asp:ListItem Text="Informe de Ventas por cliente" Value="2" />
                                                                        <asp:ListItem Text="Informe de Ventas por Hora" Value="3" />
                                                                        <asp:ListItem Text="Informe de Depositos Recibidos" Value="4" />
                                                                        <asp:ListItem Text="Informe de Traspasos de Otros Cargos" Value="5" />
                                                                        <asp:ListItem Text="Informe de Comisiones" Value="6" />
                                                                    </asp:DropDownList>
                                                                    <b>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Reporte" Display="None" ErrorMessage="Seleccionar un reporte" Operator="NotEqual" SetFocusOnError="true" ValueToCompare="0"></asp:CompareValidator>
                                                                    </b>
                                                                    <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender3" TargetControlID="CompareValidator1">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style161">FECHA DE INICIO</td>
                                                                <td>
                                                                    <asp:TextBox ID="DteFechaInicio" runat="server"></asp:TextBox>
                                                                    <strong>
                                                                        <img src="../images/ico_calendar.png" id="img5" alt="" />
                                                                    </strong>
                                                                    <ajaxToolkit:CalendarExtender runat="server" ID="dtxFecha_Inicio" TargetControlID="DteFechaInicio"
                                                                        PopupButtonID="img5" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                    <strong>
                                                                        <asp:RequiredFieldValidator ID="rfvtFecha_Inicio" runat="server" ControlToValidate="DteFechaInicio" CssClass="label" Display="None" ErrorMessage="El campo &quot;Fecha Inicio&quot; es requerido" SetFocusOnError="true" ToolTip="El campo &quot;Fecha Inicio&quot; es requerido">
                                                                        </asp:RequiredFieldValidator>
                                                                    </strong>
                                                                    <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="vceFecha_Inicio" TargetControlID="rfvtFecha_Inicio">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                    <strong>
                                                                        <asp:CustomValidator ID="cvFecha_Inici" runat="server" ClientValidationFunction="ValidaFecha_Cliente" ControlToValidate="DteFechaInicio" Display="None" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </strong>
                                                                    <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="vceFecha_InicioV" TargetControlID="cvFecha_Inici">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td><strong></strong></td>
                                                                <td>&nbsp;<ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="DteFechaFin"
                                                                    PopupButtonID="img1" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                    <strong>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DteFechaFin" CssClass="label" Display="None" ErrorMessage="El campo &quot;Fecha Fin&quot; es requerido" SetFocusOnError="true" ToolTip="El campo &quot;Fecha Fin&quot; es requerido">*
                                                                        </asp:RequiredFieldValidator>
                                                                    </strong>
                                                                    <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style161">FECHA FINAL</td>
                                                                <td>
                                                                    <asp:TextBox ID="DteFechaFin" runat="server"></asp:TextBox>
                                                                    <strong>
                                                                        <img src="../images/ico_calendar.png" id="img1" alt="" />
                                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidaFecha_Cliente2" ControlToValidate="DteFechaFin" Display="None" ErrorMessage="El formato de fecha es incorrecto ej. dd/MM/yyyy" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </strong>
                                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="CustomValidator1">
                                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td class="auto-style161">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblCliente" runat="server" Text="CLIENTE" Visible="False"></asp:Label>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:DropDownList ID="ddlClientes" runat="server" AppendDataBoundItems="true" Visible="false" Width="251px">
                                                                        <asp:ListItem Text="Todos los clientes" Value="0" />
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblBanco" runat="server" Text="BANCO" Visible="False"></asp:Label>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:DropDownList ID="ddlBanco" runat="server" AppendDataBoundItems="true" Visible="false" Width="251px">
                                                                        <asp:ListItem Text="Todos los Bancos" Value="0" />
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnBuscar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="MOSTRAR REPORTE" ToolTip="Genera el reporte seleccionado" Width="139px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblMessage" Width="100%" runat="server" Style="color: #006600; font-size: medium; font-weight: 700;" Height="16px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style109">
                                                        <div style="overflow: auto; width: 800px; height: 250px; align: left;">
                                                            <asp:Button ID="btnDescargarExcel" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="EXPORTAR REPORTE" ToolTip="Exportar a Excel el reporte mostrado" Width="139px" />
                                                            <br />
                                                            <br />
                                                            <asp:Label ID="lbltotalcomisiones" Visible="false" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#009900"></asp:Label>
                                                            <br />
                                                            <asp:GridView ID="grdReportes" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" Height="208px" Width="100%">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#2461BF" />
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#EFF3FB" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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

    </form>
</body>
</html>
