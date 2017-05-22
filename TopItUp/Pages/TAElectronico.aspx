<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="TAElectronico.aspx.vb" Inherits="TopItUp.TAElectronico" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            z-index: 999;
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
                width: 793px;
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

        .nav-justified {
            width: 20%;
            height: 15px;
        }

        #tblSaldos {
            color: #FFFFFF;
            background-color: #FFFFFF;
            width: 100%;
            height: 60px;
        }

        .auto-style96 {
            text-align: left;
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
            width: 213px;
            text-align: left;
        }

        .auto-style112 {
            width: 345px;
            text-align: left;
        }

        .auto-style122 {
            width: 345px;
            height: 3px;
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

        .auto-style158 {
            width: 208px;
        }

        .auto-style159 {
            height: 24px;
            width: 208px;
        }

        .auto-style160 {
            width: 72px;
        }

        .auto-style163 {
            font-size: 8pt;
            text-align: right;
        }

        .auto-style164 {
            font-size: 15pt;
            height: 79px;
            width: 213px;
        }

        .auto-style165 {
            height: 79px;
            text-align: center;
        }

        .auto-style123 {
            text-align: left;
        }

        .auto-style169 {
            width: 100%;
            height: 14px;
        }

        .auto-style170 {
            width: 269px;
        }

        .auto-style173 {
            height: 26px;
            width: 53px;
        }

        .auto-style174 {
            width: 53px;
        }

        .auto-style175 {
            text-align: left;
        }

        .auto-style176 {
            text-align: left;
        }

        .auto-style177 {
            height: 26px;
            width: 12px;
        }

        .auto-style178 {
            width: 12px;
        }

        .auto-style179 {
            height: 26px;
            width: 2px;
        }

        .auto-style180 {
            width: 2px;
        }

        .auto-style181 {
            height: 26px;
            width: 6px;
        }

        .auto-style182 {
            width: 6px;
        }

        .auto-style183 {
            height: 26px;
            width: 5px;
        }

        .auto-style184 {
            width: 5px;
        }

        .auto-style185 {
            font-size: 15pt;
            height: 79px;
            width: 154px;
        }

        .auto-style188 {
            text-align: left;
            height: 24px;
            width: 154px;
        }

        s .auto-style189 {
        }

        #logoTelcel {
            height: 56px;
            width: 191px;
        }
        .auto-style189 {
            width: 203px;
        }
        .auto-style190 {
            width: 205px;
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>
</head>
<script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Scripts/Validaciones.js?ver=1"></script>

<body runat="server" id="tblBackground" style="background-color:#181834; color:white; ">
    <form width="100%" id="form1" runat="server" style="margin: 0px">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                       </asp:ScriptManager>
        <asp:Panel ID="Panel3" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table runat="server" id="tbl" class="auto-style12" style="margin: 0px" border="0" align="center">
                        <tr style="margin: 0px">
                            <td class="auto-style87" style="margin: 0px">
                                <table class="auto-style12" style="font-family: 'century Gothic'">
                                    <tr>
                                        <td class="auto-style86" style="font-family: 'Century Gothic'">
                                            <table>
                                                <tr>
                                                    <td class="auto-style185">&nbsp;</td>
                                                    <td class="auto-style185">&nbsp;</td>
                                                    <td class="auto-style185">&nbsp;</td>
                                                    <td class="auto-style185">&nbsp;</td>
                                                    <td class="auto-style164">
                                                        <asp:Image ID="imglogox" runat="server" />
                                                       <%-- <img alt="" src="../Images/logomits.png" />--%></td>

                                                    <td class="auto-style164">
                                                        <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" /></td>
                                                         
                                                    <td class="auto-style165">
                                                        <table>
                                                            <tr>
                                                                <td>

                                                                    <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="auto-style165"></td>
                                                </tr>

                                                <%--<tr>
                                                    <td class="auto-style186"></td>
                                                    <td class="auto-style186"></td>
                                                    <td class="auto-style186"></td>
                                                    <td class="auto-style186"></td>
                                                    <td class="auto-style166">&nbsp;
                                      
                                                       
                                       
                                                    </td>
                                                    <td class="auto-style166">&nbsp;</td>
                                                    <td class="auto-style91">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div style="float: left; width: 797px; text-align: left; color: #000000;">
                                                    </div>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                    <td class="auto-style91">&nbsp;</td>
                                                </tr>--%>

                                                <tr width="100%" style="display:none">
                                                    <td colspan="8" style="background-image: none">
                                                        <br />
                                                        <table id="tblSaldos" runat="server" align="center" style="background-image: url('../Images/TiraAzul.png')">
                                                            <tr>
                                                                <td rowspan="2"><strong>Cliente:</strong></td>
                                                                <td rowspan="2" style="text-align: center">
                                                                    <asp:Label ID="lblCteConnected" runat="server" Style="text-align: right; font-size: small; color: #FFFFFF;" Font-Names="Century Gothic"></asp:Label>
                                                                </td>
                                                                <td rowspan="2" style="text-align: left">&nbsp;</td>
                                                                <td rowspan="2" style="text-align: right"><strong>Tipo:</strong></td>
                                                                <td rowspan="2">
                                                                    <asp:Label ID="lblTipoUser" runat="server" Style="text-align: left" Width="100%" Font-Names="Century Gothic" Height="16px"></asp:Label>
                                                                </td>
                                                                <td class="auto-style159">&nbsp;</td>
                                                                <td class="auto-style150"></td>
                                                                <td rowspan="2" class="auto-style160" style="text-align: right">&nbsp;</td>
                                                                <td class="auto-style150"><strong style="text-align: right">Saldo actualizado a:</strong></td>
                                                                <td class="auto-style155">
                                                                    <asp:Label ID="lblFechaSaldo" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                    <%--<div id="dvTime"></div>--%>
                                                                    <asp:Label ID="lblTime" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                </td>
                                                                <td class="auto-style152">&nbsp;</td>
                                                                <td class="auto-style126"><strong>Duración de la sesión:</strong></td>
                                                                <td class="auto-style126">
                                                                    <asp:Label ID="lblDuracionSesion" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style158">

                                                                    <asp:Label ID="lblSaldoGlobal" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Visible="False" Font-Names="Century Gothic">Saldo Global: $ </asp:Label>


                                                                </td>
                                                                <td></td>
                                                                <td><strong>Monto Disponible:</strong></td>
                                                                <td class="auto-style154">
                                                                    <asp:Label ID="lblSaldoCliente" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Font-Names="Century Gothic"></asp:Label>
                                                                </td>
                                                                <td class="auto-style153">&nbsp;</td>
                                                                <td class="auto-style105"><strong>Usuario Conectado:</strong></td>
                                                                <td class="auto-style105">

                                                                    <asp:Label ID="lblUsrConnected" runat="server" Font-Names="Century Gothic" Style="text-align: right; font-size: small; color: #FFFFFF;"></asp:Label>


                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                              <%--  <tr width="100%">
                                                    <td colspan="8">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width:230px"></td>
                                                                <td   style="height:60px; background-image:url('../Images/Tiraazul.png')">
                                                                <asp:Label ID="lblHeadone" style="color:white; font-size:large" runat="server" Text="Label" Font-Bold="True"></asp:Label> <br />   
                                                                <asp:Label ID="lblHeadTwo" style="color:white; font-size:large" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                                <asp:Label ID="lblHEadsaldo" style="color:white; font-size:x-large" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td style="width:250px"></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    
                                                    
                                                </tr>
                                               --%>

                                                <ctrlMenu:TopBar runat="server" id="TopBar" />

                                                <tr>
                                                    <td class="auto-style188">&nbsp;</td>
                                                    <td class="auto-style188">&nbsp;</td>
                                                    <td class="auto-style188">&nbsp;</td>
                                                    <td class="auto-style188">&nbsp;</td>
                                                    <td class="auto-style126" colspan="4">
                                                        <span class="auto-style125">
                                                            <br />
                                                            &nbsp;Recarga de Tiempo Aire</span></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style189">&nbsp;</td>
                                                    <td class="auto-style189">&nbsp;</td>
                                                    <td class="auto-style189">&nbsp;</td>
                                                    <td class="auto-style189">&nbsp;</td>
                                                    <td valign="top" class="auto-style110">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                        <br />
                                                        <%--<ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true"/>--%>

                                                        <table cellspacing="0" runat="server" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img1"><span class="auto-style131"> </span></td>
                                                                    <td><a href="TAElectronico.aspx" runat="server" id="opc1"><span class="auto-style131">Compra de Tiempo Aire</span></a></td>
                                                                </tr>
                                                                <tr id="serviciosrow" runat="server" visible="false">
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img13"><span class="auto-style131"> </span></td>
                                                                    <td><a href="PagoServ.aspx" runat="server" id="A11"><span class="auto-style131">Pago de servicios</span></a></td>
                                                                </tr>
                                                                <tr runat="server" id="filaBanco">
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img14"><span class="auto-style131"> </span></td>
                                                                    <td><a href="ctasBancariass.aspx" runat="server" id="A12"><span class="auto-style131">Bancos</span></a></td>
                                                                </tr>
                                                                <%--<% Response.Write(Session("servcol").ToString())%>--%>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img2"><span class="auto-style131"> </span></td>
                                                                    <td><a href="EdoCta.aspx" runat="server" id="A1"><span class="auto-style131">Estado de Cuenta</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img3"><span class="auto-style131"> </span></td>
                                                                    <td><a href="AtCtes.aspx" runat="server" id="A2"><span class="auto-style131">Atención a Clientes</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img4"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Ctes.aspx" runat="server" id="A3"><span class="auto-style131">Alta Clientes</span></a></td>
                                                                </tr>
                                                                  <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img15"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Ctesconsulta.aspx" runat="server" id="A13"><span class="auto-style131">Lista Clientes</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img5"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Deps.aspx" runat="server" id="A4"><span class="auto-style131">Depósitos</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img6"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Tras.aspx" runat="server" id="A5"><span class="auto-style131">Traspasos</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img7"><span class="auto-style131"> </span></td>
                                                                    <td><a href="reportes.aspx" runat="server" id="A6"><span class="auto-style131">Informes</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img8"><span class="auto-style131"> </span></td>
                                                                    <td><a href="DesbloqueaUser.aspx" runat="server" id="A7"><span class="auto-style131">Desbloquear Usuario</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img9"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Cajas.aspx" runat="server" id="A8"><span class="auto-style131">Cajeros</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img10"><span class="auto-style131"> </span></td>
                                                                    <td><a href="Noticias.aspx" runat="server" id="A9"><span class="auto-style131">Noticias</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img11"><span class="auto-style131"> </span></td>
                                                                    <td><a href="CambiarPsw.aspx" runat="server" id="A10"><span class="auto-style131">Cambiar contraseña</span></a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style149">&nbsp;</td>
                                                                    <td>
                                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img12"><span class="auto-style131"> </span></td>
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
                                                    <td class="auto-style110">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                    <td valign="top" class="auto-style105" colspan="2">

                                                        <br />
                                                        <table id="tblOpcion1">
                                                            <tr>
                                                                <td class="auto-style112">
                                                                    <table style="text-align: left; height: 263px; width: 300px;" align="right">
                                                                        <tr>
                                                                            <td colspan="9"><span class="auto-style163"><strong style="font-size: large;">Ingresa el número celular</strong></span><asp:TextBox ID="txtNumber" CssClass="soloNumeros" Style="text-align: right; font-size: x-large;" runat="server" Width="90%" Height="25px"></asp:TextBox>
                                                                            </td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="9"><span class="auto-style163"><strong  style="font-size: large;">Ingresar nuevamente el número celular<br />
                                                                            </strong></span>
                                                                                <asp:TextBox ID="txtConfirmNumber" CssClass="soloNumeros" Style="text-align: right; font-size: x-large;" runat="server" AutoPostBack="True" Width="90%" Height="25px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style123" colspan="9">
                                                                                <asp:Label ID="lblSelCompany" runat="server" Text="Compañía" Style="font-size:large; font-weight: 700;"></asp:Label>
                                                                                <br />
                                                                                <asp:DropDownList ID="ddlCompania" runat="server" AutoPostBack="True" Height="30px" Width="92%">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style175" colspan="7">
                                                                                <strong style="font-size:large">Compañía&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                                                                                <asp:Label ID="lblCompany" runat="server" Font-Bold="True" Text="TELCEL" Style="text-align: center"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style175">&nbsp;</td>
                                                                            <td class="auto-style175">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style176" colspan="7">
                                                                                <br />
                                                                                <asp:Label ID="lblDescMontoARecargar" runat="server" Text="Monto a recargar" Style="font-weight: 700; font-size:large"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style176">&nbsp;</td>
                                                                            <td class="auto-style176">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style176" rowspan="4">&nbsp;</td>
                                                                            <td class="auto-style179">
                                                                                <asp:Image ID="imgOpc20On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" /><asp:Image ID="imgOpc20Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style181">
                                                                                <asp:ImageButton ID="btn20" runat="server" ImageUrl="../Images/20.png" />
                                                                            </td>
                                                                            <td class="auto-style183">
                                                                                <asp:Image ID="imgOpc150On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc150Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style173">
                                                                                <asp:ImageButton ID="btn150" runat="server" ImageUrl="../Images/150.png" />
                                                                            </td>
                                                                            <td class="auto-style181">
                                                                                <asp:Image ID="img600on" Visible="false" runat="server" ImageUrl="../Images/puntoon.png" />
                                                                                <asp:Image ID="img600off" Visible="false" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style177">
                                                                                <asp:ImageButton ID="btn600" Visible="false" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>
                                                                            <td class="auto-style182">
                                                                                <asp:Image ID="img1000on" Visible="false" runat="server" ImageUrl="../Images/puntoon.png" Style="width: 10px" />
                                                                                <asp:Image ID="img1000off" Visible="false" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style177">
                                                                                <asp:ImageButton ID="btn1000" Visible="false" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style180">
                                                                                <asp:Image ID="imgOpc30On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc30Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style182">
                                                                                <asp:ImageButton ID="btnRec30" runat="server" ImageUrl="../Images/30.png" />
                                                                            </td>
                                                                            <td class="auto-style184">
                                                                                <asp:Image ID="imgOpc200On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc200Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style174">
                                                                                <asp:ImageButton ID="btn200" runat="server" ImageUrl="../Images/200.png" />
                                                                            </td>

                                                                            <td class="auto-style182">
                                                                                <asp:Image ID="img700on" Visible="false" runat="server" ImageUrl="../Images/puntoon.png" />
                                                                                <asp:Image ID="img700off" Visible="false" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style178">
                                                                                <asp:ImageButton ID="btn700" Visible="false" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style180">
                                                                                <asp:Image ID="imgOpc50On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc50Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style182">
                                                                                <asp:ImageButton ID="btnRec50" runat="server" ImageUrl="../Images/50.png" />
                                                                            </td>
                                                                            <td class="auto-style184">
                                                                                <asp:Image ID="imgOpc300On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc300Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style174">
                                                                                <asp:ImageButton ID="btn300" runat="server" ImageUrl="../Images/300.png" />
                                                                            </td>
                                                                            <td class="auto-style182">
                                                                                <asp:Image ID="img800on" Visible="false" runat="server" ImageUrl="../Images/puntoon.png" />
                                                                                <asp:Image ID="img800off" Visible="false" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style178">
                                                                                <asp:ImageButton ID="btn800" Visible="false" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style180">
                                                                                <asp:Image ID="imgOpc100On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc100Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style182">
                                                                                <asp:ImageButton ID="btnRec100" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>
                                                                            <td class="auto-style184">
                                                                                <asp:Image ID="imgOpc500On" runat="server" ImageUrl="../Images/puntoon.png" Visible="False" />
                                                                                <asp:Image ID="imgOpc500Off" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style174">
                                                                                <asp:ImageButton ID="btn500" runat="server" ImageUrl="../Images/500.png" />
                                                                            </td>

                                                                            <td class="auto-style182">
                                                                                <asp:Image ID="Img900on" Visible="false" runat="server" ImageUrl="../Images/puntoon.png" />
                                                                                <asp:Image ID="Img900off" Visible="false" runat="server" ImageUrl="../Images/puntooff.png" />
                                                                            </td>
                                                                            <td class="auto-style178">
                                                                                <asp:ImageButton ID="btn900" Visible="false" runat="server" ImageUrl="../Images/100.png" />
                                                                            </td>

                                                                            <td class="auto-style178">&nbsp;</td>

                                                                            <td class="auto-style178">&nbsp;</td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5">
                                                                                <br />
                                                                                <strong style="font-size:large">Correo Electrónico (OPCIONAL):&nbsp;</strong>
                                                                                <asp:TextBox ID="txtCorreoInfo" runat="server" Width="220px" Height="18px"></asp:TextBox>
                                                                                <asp:Label ID="lblInfoRecarga" runat="server" Style="font-weight: 700; font-size: small; color: #003366; text-align: left;" Width="100%"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style182">&nbsp;</td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                            <td class="auto-style178">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="7" style="text-align: right">
                                                                                <table class="auto-style169">
                                                                                    <tr>
                                                                                        <td class="auto-style170">
                                                                                            <asp:Button ID="btnAplicarRecarga" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142; text-align: center;" Text="Aplicar" ClientIDMode="Static" ToolTip="De click para realizar la recarga" Width="139px" />
                                                                                        </td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td style="text-align: right">&nbsp;</td>
                                                                            <td style="text-align: right">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5" style="text-align: center">
                                                                                <asp:Label ID="lblMessage" Width="100%" runat="server" Style="color: #006600; font-size: small; font-weight: 700; text-align: left;" Height="16px"></asp:Label>
                                                                                <br />
                                                                                <br />
                                                                               
                                                                            </td>

                                                                            <td style="text-align: center" class="auto-style182">&nbsp;</td>

                                                                            <td style="text-align: center" class="auto-style178">&nbsp;</td>

                                                                            <td style="text-align: center" class="auto-style178">&nbsp;</td>

                                                                            <td style="text-align: center" class="auto-style178">&nbsp;</td>

                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" class="auto-style109" rowspan="2">
                                                                    <div style="overflow: hidden; height: 20px">
                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="44px" Width="610px" Style="text-align: center; font-size: 9pt; margin-top: 0px;" DataSourceID="sqlDB">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="COMPANIA" HeaderText="Compañía" SortExpression="COMPANIA">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FOLIO_TRANS" HeaderText="Folio/Trans." ReadOnly="True" SortExpression="FOLIO_TRANS">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Large" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div style="overflow: auto; width: 630px; height: 290px; align: left;">
                                                                        <asp:GridView ShowHeader="False" ID="grdResumenRecargas" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Horizontal" Height="224px" Width="610px" Style="text-align: left; font-size: 9pt;" DataSourceID="sqlDB" PageSize="20" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Font-Size="Large">
                                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO">
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="COMPANIA" HeaderText="Compañía" SortExpression="COMPANIA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FOLIO_TRANS" HeaderText="Folio/Trans." ReadOnly="True" SortExpression="FOLIO_TRANS">
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                                                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Font-Size="Large" />
                                                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                                                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                                                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                                                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                                                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                                                        </asp:GridView>
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
                                                                    </div>
                                                                    <%--       <br />
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
                                                                <br />--%>
                                                                    <asp:SqlDataSource ID="sqlDB" runat="server" ConnectionString="Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;user id=AppTopItUp; password=.TopItUp2017**.!;timeout=500000;MultipleActiveResultSets=True;Application Name=EntityFramework;timeout=5000" ProviderName="System.Data.SqlClient" SelectCommand="sp_get_MvtosTiempoAire" SelectCommandType="StoredProcedure">
                                                                        <SelectParameters>
                                                                            <asp:SessionParameter DefaultValue="-1" Name="vpPkUserConnected" SessionField="USR_CONNECTED" Type="Int32" />
                                                                        </SelectParameters>
                                                                        <SelectParameters>
                                                                            <asp:SessionParameter DefaultValue="1" Name="intSoloTelcel" SessionField="propVgBlOnlyTelcel" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                    <asp:SqlDataSource ID="sqlDBUltimosMovts" runat="server" ConnectionString="Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;user id=AppTopItUp; password=.TopItUp2017**.!;timeout=500000;MultipleActiveResultSets=True;Application Name=EntityFramework;timeout=5000" ProviderName="System.Data.SqlClient" SelectCommand="sp_get_UltimosMvtosTodosLosCtes" SelectCommandType="StoredProcedure">
                                                                        <SelectParameters>
                                                                            <asp:SessionParameter DefaultValue="1" Name="intSoloTelcel" SessionField="propVgBlOnlyTelcel" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style122">
                                                                    <br />
                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" class="auto-style96">
                                                                    <asp:Label ID="lblDesc10Movs" Text="ÚLTIMOS 10 MOVIMIENTOS DE CLIENTES" runat="server" Style="font-weight: 700; font-size: large; color: #003366;" Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div style="overflow: hidden; height: 20px">
                                                                        <asp:GridView ID="grdUltimosMvtosTodosLosCtesHeader" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="36px" Width="784px" Style="text-align: center; font-size: 9pt;" DataSourceID="sqlDBUltimosMovts" Visible="False">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="CLIENTE" HeaderText="Cliente" SortExpression="CLIENTE">
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="USUARIO" HeaderText="Usuario" SortExpression="USUARIO">
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO">
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="COMPANIA" HeaderText="Compañía" SortExpression="COMPANIA">
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
                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                    <%--<div style="overflow: auto; width: 858px; height: 300px; align: left;">--%>
                                                                    <div>
                                                                        <asp:GridView ID="grdUltimosMvtosTodosLosCtes" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlDBUltimosMovts" ForeColor="#333333" GridLines="None" Height="36px" ShowHeader="False" Style="text-align: left; font-size:large;" Width="784px" Visible="False" Font-Size="X-Large">
                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="CLIENTE" HeaderText="CLIENTE" SortExpression="CLIENTE">
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO">
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO">
                                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="MONTO" HeaderText="Monto" SortExpression="MONTO">
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="COMPANIA" HeaderText="Compañía" SortExpression="COMPANIA">
                                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="FOLIO_TRANS" HeaderText="Folio/Trans." ReadOnly="True" SortExpression="FOLIO_TRANS">
                                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Large" />
                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                        </asp:GridView>

                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                </td>
                                                            </tr>
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style189" colspan="8">&nbsp;</td>
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
        </asp:Panel>
       <%-- <table>
            <tr>
                <td>

                    <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />

                </td>
            </tr>
        </table>--%>



        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlDetalleAux" Style="display: none">
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="mpeDatosPlan" runat="server" TargetControlID="pnlDetalleAux"
                    PopupControlID="pnlDetalle" OkControlID="btnYes" BackgroundCssClass="modalBackground" DropShadow="true" />
                <asp:Panel runat="server" ID="pnlDetalle" CssClass="modalPopup" Style="display: none;" Width="796px">
                    <div class="header">
                        Anuncio
                    </div>
                    <div class="body"><span style="color:black !important">
                        <asp:Label ID="lblAnuncio" runat="server"  Text=""></asp:Label>
                        </span>
                    </div>
                    <div class="footer" align="right">
                        <asp:Button ID="btnYes" runat="server" Text="Aceptar" CssClass="yes" />
                        <%--<asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>




        <asp:UpdatePanel ID="UpdatePanel3" runat="server" EnableViewState="true" UpdateMode="Always" RenderMode="Inline">
            <ContentTemplate>
                <asp:Panel runat="server" ID="Panel1" Style="display: none">
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender BehaviorID="dvprocesando" ID="ModalPopupExtender1" runat="server" TargetControlID="Panel1"
                    PopupControlID="Panel2" BackgroundCssClass="modalBackground" EnableViewState="true" DropShadow="true" />
                <asp:Panel runat="server" EnableViewState="true" ViewStateMode="Enabled" ID="Panel2" Style="display: none;">
                    <div>
                        <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label> <img src="../Images/procesandoimg.gif" />  --%>
                        <br />
                        <font color="white">REALIZANDO RECARGA....</font>
                    </div>
                    <div class="footer" align="right">
                        <%-- <asp:Button ID="Btnsi" ClientIDMode="Static" runat="server" Text="Aceptar"  CssClass="yes" />--%>
                        <%--  <asp:Button ID="btnNos" runat="server" Text="Cancelar" CssClass="no" />--%>
                    </div>
                </asp:Panel>
            </ContentTemplate>

        </asp:UpdatePanel>


        <asp:Panel ID="Panel4" Style="display: none" ClientIDMode="Static" CssClass="modalBackground" runat="server">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    Procesando... 
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

    </form>

    <%--  <script lang="ja" type="text/javascript">
        function digiClockHeader() {
            var crTime = new Date();
            var crHrs = crTime.getHours();
            var crMns = crTime.getMinutes();
            var crScs = crTime.getSeconds();
            crMns = (crMns < 10 ? "0" : "") + crMns;
            crScs = (crScs < 10 ? "0" : "") + crScs;
            var timeOfDay = (crHrs < 12) ? "AM" : "PM";
            crHrs = (crHrs > 12) ? crHrs - 12 : crHrs;
            crHrs = (crHrs == 0) ? 12 : crHrs;
            var crTimeString = crHrs + ":" + crMns + ":" + crScs + " " + timeOfDay;

            // $("#dvTime").empty();
            // $("#dvTime").html(crTimeString);
            $("#lblTime").text("");
            $("#lblTime").text(crTimeString);

        }

        $(document).ready(function () {
            setInterval('digiClockHeader()', 1000);

        });
    </script>--%>
    <script lang="ja" type="text/javascript">

        $(function () {

            $(document).on("click", "#btnAplicarRecarga", function () {
                $find("dvprocesando").show();
                // return false; 
            });

        });

    </script>



</body>
</html>
