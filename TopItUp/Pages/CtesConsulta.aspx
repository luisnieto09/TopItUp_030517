<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CtesConsulta.aspx.vb" Inherits="TopItUp.CtesConsulta" %>


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

        .auto-style171 {
            text-align: center;
        }

        .ModalPopUp {
            background-color: #848484;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .auto-style175 {
            width: 186px;
        }

        .auto-style176 {
            width: 111px;
        }
        .auto-style131 {
           font-size:16px;
           color:white;
          }
    </style>
</head>
<script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../Scripts/Validaciones.js"></script>
<body style="margin-top: 0; background-color:#070711;">
    <form id="form1" runat="server" style="font-family: 'Century Gothic'">
        <table id="tblBackground" runat="server" class="auto-style12" border="0" align="center">
            <tr>
                <td class="auto-style87">
                    <table class="auto-style12">
                        <tr>
                            <td class="auto-style86">
                                <table>
                                    <tr>
                                        <td class="auto-style100">
                                            <%--<img alt="" src="../Images/logomits.png" />--%>
                                            <asp:Image ID="imglogox" runat="server" />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                                            </asp:ScriptManager>
                                        </td>
                                        <td class="auto-style91">
                                            <div style="float: left;  text-align: left; color: #000000;">
                                                <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                            </div></td><td>
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
                                                        <asp:Label ID="lblTime" runat="server" Style="text-align: right" Font-Names="Century Gothic"></asp:Label>
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
                                                &nbsp;Clientes / Consulta&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="btnActualizarListaCtes" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="ACTUALIZAR" ToolTip="Exportar Cliente" Width="139px" />
                                                &nbsp;<asp:Button ID="btnExportar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="EXPORTAR" ToolTip="Exportar Cliente" Width="139px" />
                                                &nbsp;<asp:Button ID="btnRegregar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" Text="REGRESAR" ToolTip="Regresar a Clientes :: Alta" Width="139px" />
                                            </span></td>
                                    </tr>
                                    <tr background="../Images/semitransparente.png">
                                        <td valign="top" class="auto-style110">
                                            <%--  <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
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
                                            <%--          <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />--%>
                                        </td>
                                        <td class="auto-style105" colspan="2">
                                            <%--                  
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>--%>

                                            <asp:Panel ID="PanGrid" runat="server">
                                                <table id="tblOpcion1">
                                                    <td>
                                                        <tr>
                                                            <td class="auto-style171">Cliente
                                                                <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
                                                                Usuario
                                                                <asp:DropDownList ID="ddlUSuario" runat="server"></asp:DropDownList>
                                                                Nivel superior
                                                                <asp:DropDownList ID="ddlDependeDE" runat="server"></asp:DropDownList>
                                                                <asp:Button ID="btnAceptar" runat="server" Text="Filtrar" />
                                                                <br />
                                                                <%--     OnRowEditing="grdClientesHeader_RowEditing"
                                                                    DataSourceID="SQL_Ctes" 
                                                                --%>
                                                                <asp:GridView ID="grdClientesHeader"
                                                                    OnRowDeleting="grdClientesHeader_RowDeleting"
                                                                    OnSelectedIndexChanged="grdClientesHeader_SelectedIndexChanged"
                                                                    runat="server" AutoGenerateColumns="False"
                                                                    CellPadding="4"
                                                                    ForeColor="#333333" GridLines="None"
                                                                    DataKeyNames="pk_cliente"
                                                                    Height="36px" Style="text-align: left; font-size: 9pt;" Width="1000px" AllowSorting="True">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ReadOnly="True" SortExpression="NOMBRE" />
                                                                        <asp:BoundField DataField="SALDO" Visible="true" HeaderText="Saldo" ReadOnly="True" SortExpression="SALDO" />
                                                                        <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" ReadOnly="True" SortExpression="DIRECCION" />
                                                                        <asp:BoundField DataField="USERNAME" HeaderText="UserName" ReadOnly="True" SortExpression="USERNAME" />
                                                                        <asp:BoundField DataField="RFC" HeaderText="RFC" ReadOnly="True" SortExpression="RFC" />
                                                                        <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" ReadOnly="True" SortExpression="TELEFONO" />
                                                                        <asp:BoundField DataField="NIVEL_SUPERIOR" HeaderText="Nivel Superior" ReadOnly="True" SortExpression="NIVEL_SUPERIOR" />
                                                                        <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razón Social" ReadOnly="True" SortExpression="RAZON_SOCIAL" />
                                                                        <asp:BoundField DataField="status" HeaderText="Activo" ReadOnly="True" SortExpression="status" />

                                                                        <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                                                                        <%--<asp:CommandField HeaderText="Modificar" ShowEditButton="True"  />--%>
                                                                        <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Editar" />

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
                                                                <%--                <asp:SqlDataSource ID="SQL_Ctes" runat="server" ConnectionString="Data Source=vm2wjq7huo.database.windows.net;Initial catalog=topitup_dev;User ID=JCASTANEDA;Password=.cvjfc097**;MultipleActiveResultSets=True;Application Name=EntityFramework"
                                                                         ProviderName="System.Data.SqlClient" 
                                                                         SelectCommand="sp_GetListaClientes" 
                                                                         SelectCommandType="StoredProcedure"
                                                                         DeleteCommand="sp_GetListaClientes"
                                                                         DeleteCommandType="StoredProcedure">
                                                                        <SelectParameters>
                                                                            <asp:SessionParameter DefaultValue="-1" Name="PK_USER" SessionField="USR_CONNECTED" Type="Int32" />
                                                                            <asp:SessionParameter DefaultValue="-1" Name="PK_CLIENTE" SessionField="CTE_CONNECTED" Type="Int32" />
                                                                        </SelectParameters>
                                                                        <DeleteParameters>
                                                                            <asp:SessionParameter DefaultValue="-1" Name="PK_USER" SessionField="USR_CONNECTED" Type="Int32" />
                                                                            <asp:SessionParameter DefaultValue="-1" Name="PK_CLIENTE" SessionField="CTE_CONNECTED" Type="Int32" />
                                                                        </DeleteParameters>
                                                                    </asp:SqlDataSource>--%>

                                                                <%--                                                                    <br />
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
                                                                    <br />--%>
                                                            </td>
                                                        </tr>
                                                </table>
                                                <div>
                                                    <asp:Label ID="lblmainerror" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="Red" Style="color: #009933"></asp:Label>

                                                </div>
                                            </asp:Panel>

                                            <asp:Panel ID="PaneEditar" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td valign="top">
                                                            <table>
                                                                <%--<tr bgcolor="#2E64FE"  align="center"><td colspan="4">--%>
                                                                <tr align="center" style="color: white; font-weight: bold; background-color: rgb(93, 123, 157);">
                                                                    <td colspan="5">EDITAR CLIENTE</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>NOMBRE DE USUARIO</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUserNameEditar" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="auto-style176">&nbsp;</td>
                                                                    <td>RAZÓN SOCIAL</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlRazonSocialEditar" AutoPostBack="true" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>NOMBRE</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNombreEditar" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="auto-style176">&nbsp;</td>
                                                                    <td>RFC</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRFCEditar" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>DIRECCIÓN</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDireccionEditar" runat="server"></asp:TextBox></td>
                                                                    <td class="auto-style176">&nbsp;</td>
                                                                    <td>TELÉFONO</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTelefonoEditar" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>CORREO ELECTRÓNICO</td>
                                                                    <td>

                                                                        <asp:TextBox ID="txteMailetar" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="auto-style176">&nbsp;</td>
                                                                    <td>CTE PADRE</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlctepadreeditar" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>NUEVA CONTRASEÑA<br />
                                                                        <br />
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="txPswEtar" runat="server" TextMode="Password" ></asp:TextBox>
                                                                        &nbsp;<br />
                                                                        <strong>NOTA:</strong> CAMPO VACÍO<br />
                                                                        TAMBIÉN MANTIENE LA<br />
                                                                        CONTRASEÑA ACTUAL</td>
                                                                    <td class="auto-style176">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table>
                                                                <tr>
                                                                    <td>

                                                                        
                                                                        <asp:GridView ID="GvTelefoniasEditar"
                                                                            AutoGenerateColumns="false"
                                                                            DataKeyNames="PK_CAT_TELEFONIA"
                                                                            runat="server"
                                                                            CellPadding="4"
                                                                            ForeColor="#333333"
                                                                            GridLines="None">
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
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="cboxTelefoniaEditar" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="NOMBRE_CORTO" HeaderText="Telefonia" />
                                                                                <asp:TemplateField HeaderText="Comision">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox runat="server" Width="30px" ID="txtComisionEditar"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                    <td>
                                                                        <div style="overflow-x:scroll; height:600px ">
                                                                        <asp:GridView ID="GvServiciosEditar"
                                                                            AutoGenerateColumns="False"
                                                                            DataKeyNames="PK_CAT_SERVICIO"
                                                                            runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="cboxServicioEdita" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Servicio" DataField="DESCRIPCION" />
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

                                                <asp:TextBox ID="txtIdCliente" runat="server" Style="display: none"></asp:TextBox>
                                                <br />
                                                <br />
                                                <div>
                                                    <asp:Label ID="lblError" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="Red" Style="color: #009933"></asp:Label>
                                                </div>
                                                <div style="float: right">
                                                    <asp:Button ID="btnSaldoCero" runat="server" Text="Saldo a Cero" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" />
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <div style="float: right">
                                                    <asp:Button ID="btnAceptarEditar" runat="server" Text="Aceptar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" />
                                                    <asp:Button ID="btnCancelarEditar" runat="server" Text="Cancelar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" />
                                                </div>
                                                <br />
                                                <br />
                                                <br />


                                                <br />


                                            </asp:Panel>
                                            <%--<tr bgcolor="#2E64FE"  align="center"><td colspan="4">--%>  
                                        


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



        <%--<tr bgcolor="#2E64FE"  align="center"><td colspan="4">--%><%--<tr bgcolor="#2E64FE"  align="center"><td colspan="4">--%>


        <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
        <asp:Panel Width="300" ID="Panel2" runat="server" BackColor="White" BorderStyle="Ridge" Style="display: none">
            <table style="width: 297px">
                <tr align="center" style="color: white; width: 100%; font-weight: bold; background-color: rgb(93, 123, 157);">
                    <td class="auto-style175">ELIMINAR</td>
                </tr>
                <tr>
                    <td><span style="height: 20px"></span></td>
                </tr>
                <tr>
                    <td class="auto-style175">¿Está seguro que desea eliminar al cliente seleccionado?
                    </td>
                </tr>
                <tr>
                    <td><span style="height: 20px"></span></td>
                </tr>
                <tr>
                    <td align="right" class="auto-style175">&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnEliminarNo" runat="server" Text="Cancelar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" />
                        <asp:Button ID="btnEliminarSi" runat="server" Text="Aceptar" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" Style="color: #FFFFFF; background-color: #002142" />
                    </td>
                </tr>
            </table>
            <br />

        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender
            ID="ModalAceptarCancelar"
            runat="server"
            TargetControlID="Button2"
            PopupControlID="Panel2"
            BackgroundCssClass="ModalPopUp">
        </ajaxToolkit:ModalPopupExtender>

    </form>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/Validaciones.js"></script>

</body>
</html>
