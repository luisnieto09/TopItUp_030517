<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tras.aspx.vb" Inherits="TopItUp.Tras" %>

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
              width: 18px;
          }
          .auto-style172 {
              width: 18px;
          }
          .auto-style185 {
              text-align: center;
              width: 79px;
          }
          .auto-style191 {
              height: 23px;
          }
          .auto-style192 {
              text-align: center;
              width: 315px;
          }
          .auto-style195 {
              height: 39px;
              width: 315px;
              font-size: small;
              font-weight: bold;
          }
          .auto-style197 {
              width: 18px;
              height: 39px;
          }
          .auto-style198 {
              width: 79px;
              height: 41px;
          }
          .auto-style201 {
              width: 315px;
              height: 19px;
          }
          .auto-style202 {
              width: 18px;
              height: 23px;
          }
          .auto-style203 {
              width: 18px;
              height: 19px;
          }
          .style:text-align=right; {
              font-size: 11pt;
          }
          .style:text-align=right; {
              font-size: 11pt;
          }
          .style:text-align=right; {
              font-size: x-small;
          }
          .style:text-align=right; {
              font-size: small;
          }
          .auto-style204 {
              width: 315px;
              font-size: small;
              font-weight: bold;
          }
          .auto-style205 {
              font-size: small;
          }
          .style:text-align=right; {
              font-size: medium;
          }
          .style:text-align=right; {
              font-size: medium;
          }
          .style:text-align=right; {
              font-size: small;
          }
          .style:text-align=right; {
              text-align: right;
          }
          .style:text-align=right; {
              text-align: right;
          }
          .style:text-align=right; {
              text-align: center;
          }
          .style:text-align=center; {
              text-align: center;
          }
          .style:text-align=center; {
              text-align: center;
          }
          .style:text-align=center; {
              text-align: center;
          }
          .style:text-align=center; {
              text-align: center;
          }
          .auto-style206 {
              width: 315px;
              font-size: small;
              font-weight: bold;
              height: 41px;
          }
          .auto-style207 {
              width: 18px;
              height: 41px;
          }
          #progressBackgroundFilter {
          position:fixed; 
               top:0px; 
            bottom:0px; 
              left:0px;
             right:0px;
          overflow:hidden; 
           padding:0; 
            margin:0; 
  background-color:#000; 
            filter:alpha(opacity=50); 
           opacity:0.5; 
           z-index:1000; 
}
          .auto-style131 {
           font-size:16px;
           color:white;
          }
          </style>
</head>
   
<body style="margin-top:0; style=background-color:#666666;">
    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
           </asp:ScriptManager>
        <asp:UpdatePanel ID="upmain" runat="server">
            <ContentTemplate>
                <table id="tblBackground" runat="server" class="auto-style12" border="0" align="center">
                                    <tr>
                                        <td class="auto-style87" style="font-family: 'Century Gothic'">                                            
 <table class="auto-style12">
                    <tr>
                        <td class="auto-style86">
                            <table>
                                <tr >
                                    <td class="auto-style100">
                                        <asp:Image ID="imglogox" runat="server" />
                                        <%--<img alt="" src="../Images/logomits.png" />--%>
                                     
                                    </td>
                                    <td class="auto-style91">
                                        &nbsp;</td>
                                    <td>
                                        <img runat="server" id="logoTelcel" alt="" src="../Images/logoTelcel.png" />
                                    
                                                <ctrlNoticias:NoticiasUser ID="NoticiasUser" runat="server" EnableTheming="true" EnableViewState="False" />
                                    </td>
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
                                        &nbsp;Traspasos entre Clientes</span></td>
                                </tr>
                                <tr background="../Images/semitransparente.png">
                                    <td class="auto-style110">
                                       <%-- <ctrlMenu:MenuUser ID="mdPaquete" runat="server" EnableTheming="true" />--%>
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
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td class="auto-style105" colspan="2" >
                                            
                                  
                                                <table id="tblOpcion1">
                                                        <td">
                                                        <tr>
                                                            <td class="auto-style204">
                                                                &nbsp;</td>
                                                            <td>
                                                                <span class="auto-style205">CLIENTE RETIRO [ CARGO ]</span><br />
                                                                <asp:DropDownList ID="ddlClienteRetiro" runat="server" AutoPostBack="True" Width="300px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="auto-style172">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style204">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td class="auto-style172">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style204">
                                                                &nbsp;</td>
                                                            <td>
                                                                <span class="auto-style205">CLIENTE DEPÓSITO [ ABONO ]</span><asp:DropDownList ID="ddlClienteDeposito" runat="server" AutoPostBack="True" Width="300px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="auto-style172">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style195">
                                                                &nbsp;</td>
                                                            <td>
                                                                <span class="auto-style205">MONTO MÁXIMO DISPONIBLE A TRASPASAR</span><asp:Label ID="lblSaldoCteOrigen" runat="server" Width="300px" Font-Size="Small"   BorderColor="#00CC00" Font-Bold="False" BorderStyle="Double" style="text-align: center; font-weight: 700"></asp:Label>
                                                            </td>
                                                            <td class="auto-style197">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style204">
                                                                </td>
                                                            <td>
                                                            </td>
                                                            <td class="auto-style172">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left" class="auto-style206">
                                                                </td>
                                                            <td style="text-align: left" class="auto-style198">
                                                                <span class="auto-style205">MONTO<strong><br />
                                                                </strong></span><asp:TextBox ID="txtMontoTraspaso" runat="server" CssClass="soloNumeros noenter" Width="300px"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left" class="auto-style207">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left" class="auto-style204">
                                                                &nbsp;</td>
                                                            <td style="text-align: left">
                                                                <span class="auto-style205">MOTIVO DEL TRASPASO</span><br />
                                                                <asp:TextBox ID="txtMotivoTraspaso" runat="server" Width="300px" Height="106px" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left" class="auto-style172">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left" class="auto-style191" colspan="2">
                                                                <asp:Label ID="lblMessage" Width="100%" runat="server" style="color: #006600; font-size: small; font-weight: 700; text-align: center;" Height="16px" ></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" class="auto-style202">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style201">
                                                                </td>
                                                            <td style="text-align: right">
                                                                <asp:Button ID="btnTraspasar" runat="server" BorderColor="#003366" Font-Bold="False" Font-Names="Century Gothic" Height="28px" style="color: #FFFFFF; background-color: #002142" Text="TRASPASAR" ToolTip="Realizar Traspaso en este momento" Width="139px" />
                                                            </td>
                                                            <td style="text-align: left" class="auto-style203">
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style192">
                                                                &nbsp;</td>
                                                            <td class="auto-style185">
                                                                &nbsp;</td>
                                                            <td class="auto-style171">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td">
                                                            </td>
                                                        </tr>
                                                    </table>
                                          

                                            
                                        

                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
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
     

        <div style="float: left; width: 797px; text-align: left; color: #000000;">
                                
                                        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upmain"
        DisplayAfter="100" DynamicLayout="true">
        <ProgressTemplate>
            <div id="blur">
                 </div>
            <div id="progressBackgroundFilter"  style="vertical-align:middle; height:100%; width:100%">
                <div class="processMessage" style="position:center !important"  >
                    <img src="../Images/procesandoimg.gif" style="position:absolute; top:50%; left:50%" />
                </div>
                
                 
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress> 

          <script src="../Scripts/jquery-1.10.2.min.js"></script>
          <script src="../Scripts/Validaciones.js"></script>
    </form>
    <script>
        $(function () {
            $(document).on("keypress", ".noenter", function (e) {
                if (e.keyCode == 13)
                {
                    return false; 
                }
            });

        });
    </script>
    </body>
    
</html>

