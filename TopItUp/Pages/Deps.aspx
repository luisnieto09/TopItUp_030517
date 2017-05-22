<%@ Page Language="vb" AutoEventWireup="false" Culture="Auto" UICulture="Auto" CodeBehind="Deps.aspx.vb" Inherits="TopItUp.Deps" %>


<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
     
    </script>

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
    </style>
    <style type="text/css">
        .auto-style2 {
            width: 930px;
            color: #666666;
        }

        .auto-style4 {
            color: white;
            font-size: xx-small;
        }

        .auto-style5 {
            width: 95%;
        }

        .auto-style10 {
            width: 171px;
            font-size: small;
            color: #C0C0C0;
        }

        .auto-style15 {
            text-align: center;
        }

        .RadUpload_rtl {
            text-align: right;
        }

        .auto-style169 {
            font-size: small;
            color: #666666;
            height: 4px;
        }

        .auto-style170 {
            width: 410px;
            color: white;
            font-size: small;
        }

        .auto-style173 {
            text-align: right;
            width: 7px;
        }

        .auto-style177 {
            color: #666666;
            width: 7px;
        }

        .auto-style180 {
            text-align: left;
            color: #333333;
        }

        .auto-style182 {
            height: 23px;
            width: 7px;
            color: #333333;
            font-size: small;
        }

        .auto-style185 {
            text-align: left;
            width: 7px;
            color: #333333;
        }

        .auto-style186 {
            text-align: left;
            width: 410px;
        }

        .auto-style195 {
            height: 2px;
            width: 268px;
            color: white;
            font-size: small;
        }

        .auto-style197 {
            text-align: left;
            width: 268px;
        }

        .auto-style198 {
            font-size: small;
            height: 23px;
            color: #C0C0C0;
        }

        .auto-style199 {
            color: #666666;
            width: 268px;
        }

        .auto-style202 {
            text-align: right;
            width: 410px;
            color: #333333;
        }

        .auto-style203 {
            color: #666666;
            width: 410px;
        }

        .auto-style204 {
            color: #333333;
        }

        .auto-style205 {
            text-align: right;
            width: 7px;
            color: #333333;
        }

        .auto-style206 {
            width: 410px;
            color: white;
            font-size: small;
            height: 2px;
        }

        .auto-style207 {
            text-align: left;
            width: 410px;
            color: white;
            font-size: small;
        }

        .auto-style210 {
            width: 7px;
            font-size: small;
            color: #333333;
            height: 4px;
        }

        .auto-style211 {
            width: 268px;
            font-size: small;
            color: #666666;
            height: 4px;
        }

        .auto-style216 {
            height: 2px;
            width: 7px;
            color: #333333;
            font-size: small;
        }

        .auto-style220 {
            text-align: right;
            width: 7px;
            height: 4px;
        }

        .auto-style221 {
            text-align: left;
            width: 268px;
            height: 4px;
        }

        .auto-style222 {
            text-align: right;
            width: 7px;
            height: 1px;
        }

        .auto-style223 {
            text-align: left;
            width: 268px;
            height: 1px;
        }

        .auto-style224 {
            text-align: right;
            width: 7px;
            height: 7px;
        }

        .auto-style225 {
            text-align: left;
            width: 268px;
            height: 7px;
        }

        .auto-style226 {
            text-align: right;
            width: 7px;
            height: 3px;
        }

        .auto-style227 {
            text-align: left;
            color:white;
            width: 268px;
            height: 3px;
            font-size: small;
        }

        .auto-style229 {
            text-align: left;
            width: 268px;
            color: white;
            font-size: small;
        }

        .auto-style230 {
            text-align: left;
            color:white ;
            width: 268px;
            height: 4px;
            font-size: small;
        }

        .auto-style231 {
            text-align: left;
            width: 268px;
            font-size: small;
            color:white;
        }

        .auto-style232 {
            width: 100%;
        }

        .auto-style236 {
            height: 6px;
            width: 268px;
            color: #333333;
            font-size: small;
        }

        .auto-style237 {
            height: 6px;
        }

        .auto-style238 {
            width: 268px;
            color: white;
            font-size: small;
        }

        .auto-style239 {
            height: 4px;
        }

        .auto-style240 {
            height: 4px;
            width: 268px;
            color: #333333;
            font-size: small;
        }

        .auto-style241 {
            color: white;
        }

        .auto-style242 {
            font-size: 15pt;
            width: 435px;
        }
        .auto-style131 {
           font-size:16px;
           color:white !important;
          }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">
        //<![CDATA[

        function UploadCloud_UploadFailed(sender, args) {
            alert('Intentando carga de archivo.');
            //Add JavaScript handler code here
        }
        //]]>
    </script>
</head>


<body style="margin-top: 0; background-color:#666666">
    <form id="form1" runat="server">
        <script type="text/javascript">
            //Put your JavaScript code here.
        </script>
        <table runat="server" id="tblBackground" class="auto-style12" border="0" align="center" style="font-family: 'Century Gothic'">
            <tr>
                <td class="auto-style87">
                    <table class="auto-style12">
                        <tr>
                            <td class="auto-style86" style="font-family: 'Century Gothic'">
                                <table>
                                    <tr>
                                        <td class="auto-style242" style="font-family: 'Century Gothic'">
                                         <%--   <img alt="" src="../Images/logomits.png" />--%>
                                            <asp:Image ID="imglogox" runat="server" />
                                            <br />
                                            &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" EnablePartialRendering="true">
                                            </asp:ScriptManager>
                                        </td>
                                        <td class="auto-style91">
                                            <div style="float: left;  text-align: left; color: #000000;">
                                                <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                            </div></td>

                                                  <td>
                                                      <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr width="100%" style="display:none">
                                        <td colspan="3" width="100%" background="../Images/TiraAzul.png" style="font-family: 'Century Gothic'">
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
                                                    <td class="auto-style154"></td>
                                                    <td class="auto-style153"></td>
                                                    <td class="auto-style156"><strong>Monto Disponible:</strong></td>
                                                    <td class="auto-style105">
                                                        <asp:Label ID="lblSaldoCliente" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Font-Names="Century Gothic"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <ctrlMenu:TopBar runat="server" ID="TopBar" />

                                    <tr background="../Images/semitransparente.png">
                                        <td class="auto-style126" colspan="3" style="font-family: 'Century Gothic'">
                                            <span class="auto-style125">
                                                <br />
                                                &nbsp;Reportar Depósitos</span></td>
                                    </tr>
                                    <tr background="../Images/semitransparente.png">
                                        <td class="auto-style110" style="font-family: 'Century Gothic'">&nbsp;</td>
                                        <td class="auto-style105" colspan="2">

                                            <asp:Button ID="btnModoAddDeps" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="Modo NUEVO Depósito" ToolTip="Crear Depósitos" Width="178px" Visible="False" />
                                            &nbsp;

                                               <asp:Button ID="btnModoVoBoDeps" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="Modo VoBo" ToolTip="VoBo de los Depósitos" Width="178px" Visible="False" />


                                        </td>
                                    </tr>
                                    <tr background="../Images/semitransparente.png">
                                        <td valign="top" class="auto-style110" style="font-family: 'Century Gothic'">
                                            <%--  <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true"/>--%>
                                            <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                                <tbody>
                                                    <tr>
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img1"><span class="auto-style131"> </span></td>
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
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img2"><span class="auto-style131"> </span></td>
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
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img15"><span class="auto-style131"> </span></td>
                                                        <td><a href="Ctesconsulta.aspx" runat="server" id="A12"><span class="auto-style131">Lista Clientes</span></a></td>
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
                                            <br />
                                        </td>
                                        <td class="auto-style105" colspan="2">

                                            <div id="divTablaDetalle" runat="server" class="auto-style2">
                                                <table class="auto-style5" border="0">
                                                    <tr>
                                                        <td class="auto-style185">&nbsp;</td>
                                                        <td class="auto-style229">BANCO</td>
                                                        <td class="auto-style207">MONTO DEL PAGO QUE REALIZÓ</td>
                                                        <td rowspan="16" class="auto-style15">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style210"></td>
                                                        <td class="auto-style211">
                                                            <asp:Label ID="lblBanco" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label>
                                                            <asp:DropDownList ID="ddlBancos" runat="server" AutoPostBack="True" CssClass="auto-style180" Visible="False" Width="85%" Height="25px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="auto-style169" colspan="2">
                                                            <asp:Label ID="lblMontoPagado" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label><br />
                                                            <asp:TextBox ID="txtMontoPago" runat="server" Visible="False" Width="85%" CssClass="auto-style180 soloNumeros" Height="25px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style216"></td>
                                                        <td class="auto-style195">NÚMERO DE CUENTA A LA QUE DEPOSITÓ</td>
                                                        <td class="auto-style206">FECHA DEL DEPÓSITO</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style237"></td>
                                                        <td class="auto-style236">
                                                            <asp:Label ID="lblCuenta" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label>
                                                            <asp:DropDownList ID="ddlCuentas" runat="server" AutoPostBack="True" CssClass="auto-style180" Visible="False" Width="85%" Height="25px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="auto-style237">
                                                            <asp:Label ID="lblFechaDep" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label>
                                                            <asp:TextBox ID="DteFechaDeposito" runat="server"></asp:TextBox>
                                                            <img src="../images/ico_calendar.png" id="img3" alt="" />
                                                            <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="DteFechaDeposito"
                                                                PopupButtonID="img3" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td class="auto-style238">SU NOMBRE DE CLIENTE</td>
                                                        <td class="auto-style241">HORARIO EN QUE EFECTUÓ SU DEPÓSITO<br />
                                                            ( FORMATO 24hrs:&nbsp; <em><strong>HH:MM:SS</strong></em> )</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style239"></td>
                                                        <td class="auto-style240">
                                                            <asp:Label ID="lblNombreCte" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label>
                                                            <asp:TextBox ID="txtNombreCliente" runat="server" Width="85%" CssClass="auto-style180" Enabled="False" Height="25px"></asp:TextBox>
                                                            <asp:DropDownList ID="ddlCtes" runat="server" AutoPostBack="True" Height="25px" Width="100%" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="auto-style239">
                                                            <asp:TextBox ID="txtHoraMinSegDep" runat="server" Width="30%" CssClass="auto-style180" Enabled="True" Height="25px" MaxLength="8"></asp:TextBox>
                                                            <asp:Label ID="lblHorarioDep" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style220"></td>
                                                        <td class="auto-style230">NÚMERO DE SUCURSAL</td>
                                                        <td class="auto-style170" rowspan="6"></span>
                    <asp:Panel ID="pnlFiles" runat="server"  CssClass="auto-style180" Height="121px">
                       <span style="color:white"> DOCUMENTOS CARGARDOS</span>
                        <span class="auto-style4"><br />
                            <br />
                        </span>
                        <asp:Table ID="tblDocs" runat="server" Width="100%">
                        </asp:Table>
                    </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style222"></td>
                                                        <td class="auto-style223">
                                                            <asp:TextBox ID="txtNumSucursal" runat="server" Width="30%" CssClass="auto-style180 soloNumeros" Enabled="True" Height="25px"></asp:TextBox>
                                                            <asp:Label ID="lblSucursal" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label><br />
                                                        </td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style226"></td>
                                                        <td class="auto-style227">NOMBRE DE LA SUCURSAL</td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style224"></td>
                                                        <td class="auto-style225">
                                                            <asp:TextBox ID="txtNombreSucursal" runat="server" Width="85%" CssClass="auto-style180" Enabled="True" Height="25px"></asp:TextBox>
                                                            <asp:Label ID="lblNombreSuc" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label><br />
                                                        </td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style173"></td>
                                                        <td class="auto-style231"># DE AUTORIZACIÓN O DEPÓSITO</td>
                                                    </tr>
                                                    <tr class="auto-style204">
                                                        <td class="auto-style220"></td>
                                                        <td class="auto-style221">
                                                            <asp:TextBox ID="txtNumAutorizacion" runat="server" Width="85%" CssClass="auto-style180 soloNumeros" Enabled="True" Height="25px"></asp:TextBox>
                                                            <asp:Label ID="lblNumAutorizacion" runat="server" Visible="False" Style="font-weight: 700; color: #666666;"></asp:Label><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style182">&nbsp;</td>
                                                        <td class="auto-style198" colspan="2">
                                                            <asp:Label ID="lblInfoFiles" runat="server" CssClass="auto-style4" Visible="False" Font-Size="Small">COMPROBANTE ASOCIADO</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style205">&nbsp;</td>
                                                        <td class="auto-style197">
                                                            <asp:FileUpload ID="uploadAsync" runat="server" AllowMultiple="True" Visible="False" Width="400px" Height="25px" CssClass="auto-style204" />
                                                        </td>
                                                        <td class="auto-style202">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style173">&nbsp;</td>
                                                        <td class="auto-style197">
                                                            <br />
                                                            <asp:Label ID="lblMotivoRechazo" runat="server" Text="Motivo de rechazo:" Visible="False"></asp:Label>
                                                            <br />
                                                            <asp:TextBox ID="txtMotivoRechazo" runat="server" Visible="False" Width="144%" CssClass="auto-style180" Height="109px" TextMode="MultiLine" Wrap="False"></asp:TextBox>
                                                            <br />
                                                            <table class="auto-style232">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnRegresar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="REGRESAR" ToolTip="Regresar a Lista de los Depósitos" Width="143px" /></td>
                                                                    <td>
                                                                        <asp:Button ID="btnAutorizar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="AUTORIZAR DEPÓSITO" ToolTip="Autorizar Depósito" Width="157px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnEnviar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="ENVIAR DEPÓSITO" ToolTip="Confirmar el envío de su depósito" Width="143px" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnRechazarDep" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="RECHAZAR" ToolTip="Rechaza el depósito seleccionado" Width="143px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                        </td>
                                                        <td class="auto-style186">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style177">&nbsp;</td>
                                                        <td class="auto-style199">
                                                            <asp:Label ID="lblMessage" Width="100%" runat="server" Style="color: #006600; font-size: medium; font-weight: 700;" Height="16px"></asp:Label>
                                                        </td>
                                                        <td class="auto-style203">&nbsp;</td>
                                                    </tr>
                                                </table>
                                                <asp:SqlDataSource ID="DS_GetDeps" runat="server" ConnectionString="Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;user id=AppTopItUp; password=.TopItUp2017**.!;timeout=500000;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="sp_GetDepositos" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:SessionParameter DefaultValue="-1" Name="pk_user" SessionField="USR_CONNECTED" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>

                                                <asp:Button ID="btnExportar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="EXPORTAR" ToolTip="Exportar Depósitos" Width="143px" />
                                                <br />

                                            </div>

                                            <br />
                                            <asp:GridView
                                                ID="grdPagosEnviados"
                                                runat="server"
                                                AutoGenerateColumns="False"
                                                DataKeyNames="PK_PAGO,ESTATUS_CARGA"
                                                CellPadding="4"
                                                ForeColor="#333333"
                                                GridLines="None"
                                                DataSourceID="DS_GetDeps">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Cliente" DataField="CLIENTE" SortExpression="CLIENTE"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Usuario" DataField="USER_SOL" ReadOnly="True" SortExpression="USER_SOL"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Saldo Al Reportar" DataFormatString="{0:N}" DataField="SALDO_ACTUAL" SortExpression="SALDO_ACTUAL"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Banco" DataField="BANCO" SortExpression="BANCO"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Cuenta" DataField="CUENTA" SortExpression="CUENTA"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Número de autorización" DataField="SUCURSAL" SortExpression="SUCURSAL"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Nombre" DataField="NOMBRE_SUC" SortExpression="NOMBRE_SUC"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Monto de Pago" DataFormatString="{0:N}" DataField="PAGO_REPORTADO" SortExpression="PAGO_REPORTADO"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Saldo Al Autorizar" DataFormatString="{0:N}" DataField="SALDO_AL_AUTORIZAR" SortExpression="SALDO_AL_AUTORIZAR"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Archivos" DataField="ARCHIVOS" ReadOnly="True" SortExpression="ARCHIVOS"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Fecha de Pago" DataFormatString="{0:d}" DataField="FECHA_PAGO" SortExpression="FECHA_PAGO"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Estatus de Carga" DataField="ESTATUS_CARGA" SortExpression="ESTATUS_CARGA"></asp:BoundField>
                                                    <asp:ButtonField Visible="false" ButtonType="Button" CommandName="Select" HeaderText="Mostrar" ShowHeader="True" Text="&gt;&gt;" />
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
        <script src="../Scripts/jquery-1.10.2.min.js"></script>
        <script src="../Scripts/Validaciones.js"></script>
        
    </form>
</body>
</html>

