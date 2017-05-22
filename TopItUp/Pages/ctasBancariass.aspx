<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ctasBancariass.aspx.vb" Inherits="TopItUp.ctasBancariass" %>


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
            height: 342px;
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
            font-size: 17pt;
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

        .auto-style164 {
            text-align: center;
        }

        .auto-style169 {
            width: 814px;
        }

        .auto-style171 {
            text-align: center;
            width: 18px;
        }

        .auto-style172 {
            width: 18px;
        }

        .auto-style173 {
            text-align: center;
            width: 475px;
        }

        .auto-style174 {
            width: 475px;
        }

        .auto-style176 {
        }

        .auto-style177 {
            width: 239px;
            text-align: right;
        }

        .auto-style178 {
            width: 239px;
            text-align: left;
            height: 31px;
        }

        .auto-style179 {
            width: 18px;
            height: 31px;
        }

        .auto-style180 {
            font-size: medium;
            height: 31px;
        }

        .auto-style181 {
            width: 814px;
            height: 31px;
        }

        .auto-style183 {
            font-size: medium;
            text-align: right;
        }

        .auto-style185 {
            font-size: small;
        }

        .auto-style186 {
            width: 18px;
            height: 9px;
        }

        .auto-style187 {
            width: 239px;
            text-align: left;
            height: 9px;
        }

        .auto-style188 {
            font-size: medium;
            height: 9px;
        }

        .auto-style189 {
            width: 814px;
            height: 9px;
        }

        .auto-style191 {
            width: 239px;
            text-align: right;
            height: 24px;
        }

        .auto-style192 {
            font-size: medium;
            text-align: right;
            height: 24px;
        }

        .auto-style193 {
            width: 18px;
            height: 24px;
        }

        .auto-style194 {
            width: 814px;
            height: 24px;
        }

        .auto-style195 {
            width: 18px;
            height: 31px;
            font-size: 17pt;
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>
</head>
<script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Scripts/Validaciones.js"></script>
<body style="margin-top: 0; background-size: cover; background-color:#070711; color:white">
    <form id="form1" runat="server">
        <table id="tblBackground" runat="server" class="auto-style12" border="0" align="center">
            <tr>
                <td class="auto-style87" style="font-family: 'Century Gothic'">
                    <table class="auto-style12">
                        <tr>
                            <td class="auto-style86">
                                <table>
                                    <tr>
                                        <td class="auto-style100">
                                            <asp:Image ID="imglogox" runat="server" ImageUrl="../Images/recargamultimarcas.png" />
                                            <%--<img alt="" src="../Images/logomits.png" />--%><br />
                                            &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                            </asp:ScriptManager>
                                        </td>
                                        <td class="auto-style91">
                                            <div style="float: left;  text-align: left; color: #000000;">
                                                <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                            </div></td><td>
                                                        <ctrlNoticias:NoticiasUser ID="NoticiasUser1" runat="server" EnableTheming="true" EnableViewState="False" />
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
                                                        <asp:Label ID="lblSaldoCliente" runat="server" Style="text-align: right; font-size: 12pt; font-weight: 700;" Font-Names="Century Gothic"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <ctrlMenu:TopBar runat="server" ID="TopBar" />


                                    <tr background="../Images/semitransparente.png">
                                        <td class="auto-style126" colspan="3">
                                            <span class="auto-style125">
                                                <br />
                                            </span>
                                            <span class="auto-style195">
                                                <font face="Century Gothic">&nbsp;CUENTAS BANCARIAS</font></span></td>
                                    </tr>
                                    <tr background="../Images/semitransparente.png">
                                        <td valign="top" class="auto-style110">
                                            <%--<ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
                                            <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                                <tbody>
                                                    <tr>
                                                        <td class="auto-style149">&nbsp;</td>
                                                        <td>
                                                            <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img3"><span class="auto-style131"> </span></td>
                                                        <td><a href="TAElectronico.aspx" runat="server" id="opc1"><span class="auto-style131">Compra de Tiempo Aire</span></a></td>
                                                    </tr>
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
                                        </td>
                                        <td class="auto-style105" colspan="2" valign="top">

                                            <asp:Panel ID="panAdd" runat="server">
                                                CREAR BANCO 
                                            <table>
                                                <tr>
                                                    <td>Descripcion</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNombreBanco" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Nombre</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNombreCorto" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="btnAgregaBanco" runat="server" Text="Agregar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                    </td>
                                                </tr>
                                            </table>
                                                <br />
                                                <br />
                                                BANCOS ACTUALES
                                            <br />
                                                <br />

                                                <asp:GridView DataKeyNames="Id" ID="gvrGridBancos" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                                        <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                                                        <asp:CommandField HeaderText="Habilitar/Deshabilitar" SelectText="Cambiar" ShowSelectButton="True" />
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

                                                <asp:Label ID="lblmensajebanco" runat="server" Text=""></asp:Label>

                                                <br />
                                                <br />
                                                CREAR CUENTA BANCARIA     
                                        <br />
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>Banco</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBanco" runat="server"></asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Numero de cuenta</td>
                                                        <td>
                                                            <asp:TextBox ID="txtNumeroCuenta" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Clabe</td>
                                                        <td>
                                                            <asp:TextBox ID="txtClabe" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Convenio</td>
                                                        <td>
                                                            <asp:TextBox ID="txtConvenio" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Referencia</td>
                                                        <td>
                                                            <asp:TextBox ID="txtReferencia" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <asp:Button ID="btnAceptar" runat="server" Text="Agregar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblMensajeCtaBancaria" runat="server" Text=""></asp:Label>
                                                <br />
                                                <br />
                                                CUENTAS ACTUALES
                                        <br />
                                                <br />
                                                <asp:GridView DataKeyNames="Id" ID="gvrCuentas" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Banco" HeaderText="Banco" />
                                                        <asp:BoundField DataField="NumCuenta" HeaderText="NumCuenta" />
                                                        <asp:BoundField DataField="Clabe" HeaderText="Clabe" />
                                                        <asp:BoundField DataField="Convenio" HeaderText="Convenio" />
                                                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                                                        <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                                                        <asp:CommandField HeaderText="Habilitar/DesHabilitar" SelectText="Cambiar" ShowSelectButton="True" />
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
                                            </asp:Panel>
                                            <br />
                                            <br />
                                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Panel ID="panEdit" Style="display: none" runat="server">
                                                <br />
                                                EDITAR

                                            <table>
                                                <tr>
                                                    <td>Clabe</td>
                                                    <td>
                                                        <asp:TextBox ID="txtClabeEdit" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Convenio</td>
                                                    <td>
                                                        <asp:TextBox ID="txtConvenioEdit" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Referencia</td>
                                                    <td>
                                                        <asp:TextBox ID="txtReferenciaEdit" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="idCancelEdit" runat="server" Text="Cancelar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" /></td>
                                                    <td>
                                                        <asp:Button ID="idAceptarEdit" runat="server" Text="Actualizar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" /></td>
                                                </tr>
                                            </table>
                                                <asp:TextBox ID="txtidEdit" runat="server" Style="display: none"></asp:TextBox>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                </table>

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
        
    </form>
</body>
</html>

