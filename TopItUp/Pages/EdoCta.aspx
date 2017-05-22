<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EdoCta.aspx.vb" Culture="Auto" UICulture="Auto" Inherits="TopItUp.EdoCta" %>

<%@ Register Src="~/Controles/TopBar.ascx" TagPrefix="ctrlMenu" TagName="TopBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style type="text/css">
          .auto-style12
        {
            width: 85%;
            font-size: 9pt;
        }
        a:link {
          color: black;
          background-color: transparent;
          text-decoration: none;
            }
                      A:link {color:black;} 
    A:visited {color:black;} 
    A:active {color:black;} 
    A:hover {color:black;} 
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
          .auto-style105 {
              text-align: left;
          }
          #tblOpcion1 {
              width: 984px;
              height: 240px;
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
          .auto-style164 {
              text-align: left;
          }
          .auto-style167 {
              font-size: medium;
          }
          .auto-style173 {
              text-align: center;
              width: 475px;
          }
          .auto-style174 {
              width: 475px;
          }
          .auto-style177 {
              width: 809px;
          }
          .auto-style178 {
              width: 100%;
          }
          .auto-style179 {
              width: 95px;
              font-weight: bold;
          }
          .auto-style180 {
              font-size: 15pt;
              width: 435px;
          }
          .auto-style131 {
           font-size:16px;
           color:white;
          }
          </style>
</head>
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Validaciones.js"></script>
   
<body style="margin-top:0; background-color:#666666;"><form id="form1" runat="server"><table id="tblBackground" runat="server" class="auto-style12" border="0" align="center" style="font-family: 'Century Gothic'">
                                    <tr>
                                        <td class="auto-style87">                                            
 <table class="auto-style12">
                    <tr>
                        <td class="auto-style86" style="font-family: 'CENTURY Gothic'">
                            <table>
                                <tr >
                                    <td class="auto-style180">
                                        <asp:Image ID="imglogox" runat="server" />
                                        <%--<img alt="" src="../Images/logomits.png" />--%><br />
                                        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" EnablePartialRendering="true" >
                                        </asp:ScriptManager>
                                    </td>
                                    <td class="auto-style91">
                                        <div style="float: left;  text-align: left; color: #000000;">
                                        <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" /></div>
                                        <td>
                                                <ctrlNoticias:NoticiasUser ID="NoticiasUser1" runat="server" EnableTheming="true" EnableViewState="False" />
                                        </td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>                                
                                <tr width="100%" style="display:none">
                                    <td colspan="3" width="100%" background="../Images/TiraAzul.png">
                                        <table id="tblSaldos" background="../Images/TiraAzul.png" runat="server" align="center">
                                            <tr>
                                                                                              <td rowspan="3"><strong>Cliente:</strong></td>
                                                <td rowspan="3" style="text-align: center">
                                                    <asp:Label ID="lblCteConnected" runat="server" style="text-align: right; font-size: small; color: #FFFFFF; " Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td rowspan="3" style="text-align: left">
                                                    &nbsp;</td>
                                                <td rowspan="3" style="text-align: right"><strong>Tipo:</strong></td>
                                                <td rowspan="3">
                                                    &nbsp;</td>
                                                <td class="auto-style158">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td rowspan="3" class="auto-style160" style="text-align: right"><strong style="text-align: right">Saldo actualizado a:</strong></td>
                                                <td>&nbsp;</td>
                                                <td class="auto-style155">
                                                    <asp:Label ID="lblFechaSaldo" runat="server" style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td class="auto-style152">&nbsp;</td>
                                                <td class="auto-style157"><strong>Usuario Conectado:</strong></td>
                                                <td class="auto-style126">
                                                    <asp:Label ID="lblUsrConnected" runat="server" style="text-align: right; font-size: small; color: #FFFFFF; " Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td style="text-align: right">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style158">
                                                    <asp:Label ID="lblTipoUser" runat="server" style="text-align: left" Width="100%" Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td></td>
                                                <td></td>
                                                <td class="auto-style154">
                                                    <asp:Label ID="lblTime" runat="server" style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td class="auto-style153">&nbsp;</td>
                                                <td class="auto-style156"><strong>Duración de la sesión:</strong></td>
                                                <td class="auto-style105">
                                                    <asp:Label ID="lblDuracionSesion" runat="server" style="text-align: right" Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                                <td style="text-align: right">&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style158">
                                                    <asp:Label ID="lblSaldoGlobal" runat="server" style="text-align: right; font-size: 12pt; font-weight: 700;" Visible="False" Font-Names="Century Gothic">Saldo Global: $ </asp:Label>
                                                                                              </td>
                                                <td></td>
                                                <td></td>
                                                <td class="auto-style154">&nbsp;</td>
                                                <td class="auto-style153">&nbsp;</td>
                                                <td class="auto-style156"><strong>Monto Disponible:</strong></td>
                                                <td class="auto-style105">
                                                    <asp:Label ID="lblSaldoCliente" runat="server" style="text-align: right; font-size: 12pt; font-weight: 700;" Font-Names="Century Gothic"></asp:Label>
                                                                                              </td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                
                                <ctrlMenu:TopBar runat="server" ID="TopBar" />

                                <tr background="../Images/semitransparente.png">
                                    <td  class="auto-style126" colspan="3" >
                                        <span class="auto-style125">
                                        <br />
                                        &nbsp;Estado de Cuenta</span></td>
                                </tr>
                                <tr background="../Images/semitransparente.png">
                                    <%--<td class="auto-style110">--%>
                                    <td valign="top">
                                        <%--<ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
                                        <table cellspacing="0" cellpadding="0" border="0" class="auto-style10" id="tblMenu">
                                            <tbody>
                                                <tr id="ocultaruno" runat="server">
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
                                                <tr id="ocultartres" runat="server">
                                                    <td class="auto-style149">&nbsp;</td>
                                                    <td>
                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img5"><span class="auto-style131"> </span></td>
                                                    <td><a href="AtCtes.aspx" runat="server" id="A2"><span class="auto-style131">Atención a Clientes</span></a></td>
                                                </tr>
                                                <tr runat="server" id="ocultarcuatro">
                                                    <td class="auto-style149">&nbsp;</td>
                                                    <td>
                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img6"><span class="auto-style131"> </span></td>
                                                    <td><a href="Ctes.aspx" runat="server" id="A3"><span class="auto-style131">Alta Clientes</span></a></td>
                                                </tr>
                                                 <tr id="ocultarcinco" runat="server">
                                                    <td class="auto-style149">&nbsp;</td>
                                                    <td>
                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img16"><span class="auto-style131"> </span></td>
                                                    <td><a href="Ctesconsulta.aspx" runat="server" id="A12"><span class="auto-style131">Lista Clientes</span></a></td>
                                                </tr>
                                                <tr id="ocultarseis" runat="server">
                                                    <td class="auto-style149">&nbsp;</td>
                                                    <td>
                                                        <img class="auto-style131" src="../Images/puntoOff.png" runat="server" id="Img7"><span class="auto-style131"> </span></td>
                                                    <td><a href="Deps.aspx" runat="server" id="A4"><span class="auto-style131">Depósitos</span></a></td>
                                                </tr>
                                                <tr id="ocultarsiete" runat="server">
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
                                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                    </td>
                                    <td class="auto-style105" colspan="2" >
                                                    
                                        <table id="tblOpcion1">
                                                        <td">
                                                        <tr>
                                                            <td class="auto-style177">
&nbsp;&nbsp;&nbsp;
                                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="auto-style178">
                                                                    <tr>
                                                                        <td class="auto-style179">&nbsp;</td>
                                                                        <td class="auto-style158">
                                                                Fecha Consulta del Reporte:
                                                                <asp:Label ID="lblToday" runat="server" style="font-weight: 700" Width="50%"></asp:Label>
                                                                        </td>
                                                                        <td>Saldo del
                                                                <asp:Label ID="lblFechaIni" runat="server"></asp:Label>
&nbsp;al
                                                                <asp:Label ID="lblfechaFin" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style179">FECHA INICIAL</td>
                                                                        <td class="auto-style158">
                                                                <asp:TextBox ID="dteFechaIni" runat="server"></asp:TextBox>
                                                                 <ajaxToolkit:CalendarExtender runat="server" ID="dtxFecha_Inicio" TargetControlID="dteFechaIni"
                                                                                PopupButtonID="img1" Format="dd/MM/yyyy" ></ajaxToolkit:CalendarExtender>
                                                                <img src="../images/ico_calendar.png" id="img1" alt="" /></td>
                                                                        <td>FECHA FINAL<asp:TextBox ID="dteFechaFin" runat="server" ></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="dteFechaFin"
                                                                                PopupButtonID="img2" Format="dd/MM/yyyy" ></ajaxToolkit:CalendarExtender>
                                                                 <img src="../images/ico_calendar.png" id="img2" alt="" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style179">REGISTROS A MOSTRAR</td>
                                                                        <td class="auto-style158">
                                                                <asp:DropDownList ID="ddlMostarHasta" runat="server" Height="16px" Width="220px">
                                                                </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                <asp:Button ID="btnMostrar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" style="color: #FFFFFF; background-color: #002142; text-align: left;" Text="MOSTRAR" ToolTip="Mostrar Estado de Cuenta" Width="139px" />
                                                                            <asp:Button ID="btnExportarEdoCta" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" style="color: #FFFFFF; background-color: #002142" Text="EXPORTAR" ToolTip="Exportar Estado de Cuenta" Width="139px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style179">
                                                                            <asp:Button ID="btnActualizarEdoCta" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" style="color: #FFFFFF; background-color: #002142" Text="ACTUALIZAR" ToolTip="Exportar Cliente" Width="139px" />
                                                                        </td>
                                                                        <td class="auto-style158">
                                                                            &nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    </table>
                                                                 <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                 <asp:GridView ID="grdUltimosMvtosTodosLosCtes" 
                                                                     runat="server" AutoGenerateColumns="false" 
                                                                     CellPadding="4" ForeColor="#333333" 
                                                                     GridLines="None" 
                                                                     Height="36px" 
                                                                     ShowHeader="true" 
                                                                     style="text-align: left; 
                                                                     font-size: 9pt;" Width="1100px" ViewStateMode="Enabled" AllowPaging="FALSE">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" > 
                                                            <HeaderStyle Width="5%" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField  Visible="false" DataField="pk_transaccion" HeaderText="TRANSACCION" SortExpression="pk_transaccion" ReadOnly="True"> 
                                                            <HeaderStyle Height="5%" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FECHA" DataFormatString = "{0:dd/MM/yyyy}" HeaderText="FECHA" SortExpression="FECHA" ReadOnly="True"> 
                                                            <HeaderStyle Width="5%" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="HORA" HeaderText="HORA" SortExpression="HORA" ReadOnly="True"> 
                                                            <HeaderStyle Width="5%" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MOVIMIENTO" HeaderText="CONCEPTO" SortExpression="MOVIMIENTO" ReadOnly="True"> 
                                                            <HeaderStyle Width="60%" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="MEDIO_DE_PAGO" HeaderText="MEDIO DE PAGO" SortExpression="MEDIO_DE_PAGO" ReadOnly="True"> 
                                                            <HeaderStyle Width="10%" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ABONO"  DataFormatString="{0:N2}" HeaderText="ABONO" SortExpression="ABONO" ReadOnly="True">
                                                            <HeaderStyle Width="5%" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CARGO"  DataFormatString="{0:N2}"  HeaderText="CARGO" SortExpression="CARGO" ReadOnly="True">
                                                            <HeaderStyle Width="5%" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SALDO" Visible="false"  DataFormatString="{0:N2}" HeaderText="SALDO" ReadOnly="True" SortExpression="SALDO" >
                                                            <HeaderStyle Width="5%" HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SALDO" HeaderStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSaldo" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="5%" />
                                                            </asp:TemplateField>
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
                                                                     &nbsp;<asp:SqlDataSource ID="SQL_EdoCta" runat="server" ConnectionString="Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;user id=AppTopItUp; password=.TopItUp2017**.!;timeout=500000;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="sp_GetEdoCtaByPkUser" SelectCommandType="StoredProcedure">
                                                                         <SelectParameters>
                                                                             <asp:SessionParameter DefaultValue="-1" Name="PK_USER" SessionField="USR_CONNECTED" Type="Int32" />
                                                                             <asp:SessionParameter Name="FECHA_INI" SessionField="FECHA_INI" Type="DateTime" />
                                                                             <asp:SessionParameter Name="FECHA_FIN" SessionField="FECHA_FIN" Type="DateTime" />
                                                                             <asp:SessionParameter Name="ROW_INI" SessionField="ROW_INI" Type="Int32" />
                                                                             <asp:SessionParameter Name="ROW_FIN" SessionField="ROW_FIN" Type="Int32" />
                                                                         </SelectParameters>
                                                                     </asp:SqlDataSource>
                                                                 <br />
                                                            </td>
                                                            <td class="auto-style167">
                                                                &nbsp;</td>
                                                            <td class="auto-style174">
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td">
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

