<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cajas.aspx.vb" Inherits="TopItUp.Cajas" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            font-size: 16px;
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
    </style>
</head>
<script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Scripts/Validaciones.js"></script>
<body style="margin-top: 0; background-size: cover; background-color:#070711; color:white">
    <form id="form1" runat="server" style="font-family: 'Century Gothic'">
        <div>

            <table id="tblBackground" runat="server" class="auto-style12" border="0" align="center">
                <tr>
                    <td class="auto-style87">
                        <table class="auto-style12">
                            <tr>
                                <td class="auto-style100">
                                    <asp:Image ID="imglogox" runat="server" ImageUrl="../Images/recargamultimarcas.png" />
                                    <%--<img alt="" src="../Images/logomits.png" />--%>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                    </asp:ScriptManager>
                                </td>
                                <td class="auto-style91">
                                    <div style="float: left;  text-align: left; color: #000000;">
                                        <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                    </div></td><td>
                                    <table><tr><td><ctrlNoticias:NoticiasUser runat="server" EnableTheming="true" EnableViewState="False"  id="Noticia" /></td></tr></table>
                                    
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
                                        &nbsp;Cajeros / Alta y Baja&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                    &nbsp;</td>
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
                                <td valign="top" class="auto-style105" colspan="2" style="font-family: 'Century Gothic'">
                                    <br />
                                    <br />
                                    <asp:Panel ID="panCrearCajero" runat="server">
                                        ALTA DE CAJERO
                                            <br />
                                        <br />
                                        <table>
                                            <tr>
                                                <td>Nombre</td>
                                                <td>
                                                    <asp:TextBox ID="txtNombreCajero" Width="300" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Nombre Usuario:
                                                                       
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Contraseña</td>
                                                <td>
                                                    <asp:TextBox ID="txtPassWord" TextMode="Password" runat="server"></asp:TextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxLunes" runat="server" />
                                                    Lunes
                                                    
                                                    
                                                </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtLunesDesde" runat="server"></asp:TextBox>
                                                </td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtLunesHasta" runat="server"></asp:TextBox>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxMar" runat="server" />
                                                    Martes </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtMartesDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtMartesHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxMier" runat="server" />Miercoles </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtMiercolesDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtMiercolesHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxJue" runat="server" />Jueves </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtJuevesDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtJuevesHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxVier" runat="server" />Viernes </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtViernesDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtViernesHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxSab" runat="server" />Sabado   </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtSabadoDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtSabadoHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxDom" runat="server" />Domingo </td>
                                                <td>Hr. Inicial<asp:TextBox ID="txtDomingoDesde" runat="server"></asp:TextBox></td>
                                                <td>Hr. Final
                                                    <asp:TextBox ID="txtDomingoHasta" runat="server"></asp:TextBox></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td align="right">
                                                    <asp:Button ID="btnCrear" runat="server" Text="Crear" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" ToolTip="Crear Cajero" Width="139px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                    </asp:Panel>
                                    <br />                                    <br />

                                    <asp:Panel ID="panCajerosActuales" runat="server">
                                        CAJEROS ACTUALES
                                            <br />
                                        <asp:GridView ID="grvCrear" DataKeyNames="PkCajero" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                                            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                                            <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                                            <RowStyle BackColor="#EFF3FB"></RowStyle>

                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                            <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                                            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                                            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                                            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                                            <Columns>

                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                                <asp:CommandField HeaderText="Editar" SelectText="Editar" ShowSelectButton="True" />
                                                <asp:CommandField DeleteText="Eliminar" ControlStyle-CssClass="EliminarCajerosCs" HeaderText="Eliminar" ShowDeleteButton="True">

                                                    <ControlStyle CssClass="EliminarCajerosCs" />
                                                </asp:CommandField>

                                            </Columns>
                                        </asp:GridView>


                                        <br />
                                        <br />

                                        <asp:Button ID="btnDetalleTran" runat="server" Text="Detalle Transacciones" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="200px" />


                                    </asp:Panel>
                                    <br />
                                    <br />

                                    <asp:Panel ID="panEditaCajero" Visible="false" runat="server">
                                        EDITAR CAJERO
                                            <br />
                                        <br />
                                        <table>
                                            <tr>
                                                <td>Nombre de usuario:</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditarUserName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Text="Resetear password" /></td>
                                                <td>
                                                    <asp:TextBox ID="txtpasswordresetear" Enabled="false" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table>
                                            <tr>
                                                <td></td>
                                                <td>Dia</td>
                                                <td>Hr Inicial</td>
                                                <td>HrFinal</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxeditlun" runat="server" />
                                                </td>
                                                <td>Lunes</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditLunFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditLunHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxeditmar" runat="server" />
                                                </td>
                                                <td>Martes</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditMarFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditMarHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxeditmier" runat="server" />
                                                </td>
                                                <td>Miercoles</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditMierFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txteditMierHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxeditjuev" runat="server" />
                                                </td>
                                                <td>Jueves</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditJuevFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditJuevHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxeditVier" runat="server" />
                                                </td>
                                                <td>Viernes</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditVierFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditVierHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxEditSab" runat="server" />
                                                </td>
                                                <td>Sabado</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditSabFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditSabHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cboxEditDom" runat="server" />
                                                </td>
                                                <td>Domingo</td>
                                                <td>
                                                    <asp:TextBox ID="txtEditDomFrom" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtEditDomHasta" runat="server"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="width: 450px; text-align: right">
                                                    <asp:Button ID="btnCancelarEditar" runat="server" Text="Cancelar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                    <asp:Button ID="btnAceptarEditar" runat="server" Text="Aceptar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:TextBox ID="txtidCajeroEditar" Style="display: none" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                    <br />
                                    <asp:Panel ID="panTransacciones" Visible="false" runat="server">
                                        <asp:GridView ID="gvrTransacciones" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Telefono" DataField="Numero" />
                                                <asp:BoundField HeaderText="Monto" DataField="Monto" />
                                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
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
                                        <table>
                                            <tr>
                                                <td style="width: 450px; text-align: right">
                                                    <asp:Button ID="btnCerrarTran" runat="server" Text="Cerrar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Width="139px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblErrorEditar" runat="server" Text=""></asp:Label>
                                    </asp:Panel>

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



        </div>
    </form>
    <script>
        $(function () {
            $(document).on("click", ".EliminarCajerosCs", function () {

                var respuesta = confirm("¿Seguro de eliminar al cajero?");
                if (!respuesta) {
                    return false;
                }

            });
        });
    </script>
</body>
</html>
