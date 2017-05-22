Imports TopItUp.Helpers
Imports System.Globalization
Imports BACK_CODE
Imports System.Net

Public Class Reportes
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp

    Private Property propVgBlOnlyTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property

    Private Property vgPropObjUserConnected As USERS
        Set(value As USERS)
            Session("USR") = value
        End Set
        Get
            Return Session("USR")
        End Get
    End Property

    Private Property vgPropObjCteConnected As CLIENTES
        Set(value As CLIENTES)
            Session("CTE") = value
        End Set
        Get
            Return Session("CTE")
        End Get
    End Property

    Private Property vgPropIntCveUserConnected As Integer
        Set(value As Integer)
            Session("USR_CONNECTED") = value
        End Set
        Get
            Return Session("USR_CONNECTED")
        End Get
    End Property

    Private Property vgPropIntCveCteConnected As Integer
        Set(value As Integer)
            Session("CTE_CONNECTED") = value
        End Set
        Get
            Return Session("CTE_CONNECTED")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("isconsulta") = True Then
            ocultarcinco.Visible = False
            ocultarcuatro.Visible = False
            ocultardiez.Visible = False
            ocultarnueve.Visible = False
            ocultarocho.Visible = False
            ocultarseis.Visible = False
            ocultartres.Visible = False
            ocultaruno.Visible = False
            filaBanco.Visible = False
            ocultarsiete.Visible = False
        End If


        If Session("USR_CONNECTED") Is Nothing Then
            Session("ERROR") = "SIN CONEXIÓN, FAVOR DE INGRESAR SUS DATOS DE ACCESO"




            Try
                If propVgBlOnlyTelcel = True Then
                    Response.Redirect("../Default.aspx")
                Else
                    Response.Redirect("../Otras.aspx")
                End If
            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try


        End If

        Dim clsGeneric As New clsGenerics()



        If Not IsPostBack Then
            If Convert.ToBoolean(Session("isCajero")) = True Then
                Response.Redirect("../Pages/TaElectronico.aspx")
            End If

            If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                filaBanco.Visible = True
            Else
                filaBanco.Visible = False
            End If
            System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-MX")
            Dim test = DateTime.Now.AddDays(5)

            'Dim nfi = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat
            'nfi.CurrencyDecimalSeparator = "."
            'nfi.CurrencyGroupSeparator = ","


            Me.lblFechaSaldo.Text = Date.Now.Date
            Me.lblFechaSaldo.Visible = True

            If Me.propVgBlOnlyTelcel = True Then
                Session("intSoloTelcel") = 1
                imglogox.ImageUrl = "../Images/recargastelcel.png"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
            Else
                Session("intSoloTelcel") = 0
                Me.logoTelcel.Visible = False
                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
            Try
                Me.lblUsrConnected.Text = vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = Me.vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                        LLenaClientes()
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                        LLenaClientes()
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

                LLenaBancos()
            Catch ex As Exception

            End Try
        End If

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(Me.vgPropObjUserConnected.PK_USER)
        Catch ex As Exception
            lblSaldoCliente.Text = 0.0
        End Try
        lblSaldoCliente.Text = FormatNumber(lblSaldoCliente.Text, 2)

        If Not vgPropObjUserConnected Is Nothing Then
            'Es usuario maestro
            If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                Me.lblSaldoGlobal.Visible = True
                Me.lblSaldoGlobal.Text = String.Empty ' "Saldo Global: $" & FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
            End If
        End If

    End Sub

    Protected Sub Reporte_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Protected Sub grdReportes_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdReportes.RowDataBound
        Dim strinf As String = "sdfsdfsds"
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")



        Me.lblMessage.Style.Remove("color")
        Me.lblMessage.Style.Add("color", "red")
        Me.lbltotalcomisiones.Text = ""
        Me.lbltotalcomisiones.Visible = False
        Me.lblMessage.Text = ""
        If Me.Reporte.SelectedValue.Equals("0") Then
            Me.lblMessage.Text = "Favor de seleccionar el reporte."
            Exit Sub
        End If

        If Trim(Me.DteFechaInicio.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Inicio.</li>"
            Exit Sub
        End If

        If Trim(Me.DteFechaFin.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Fin.</li>"
            Exit Sub
        End If

        Dim Fecha1 As DateTime
        Dim Fecha2 As DateTime

        Fecha1 = Convert.ToDateTime(Me.DteFechaInicio.Text)
        Fecha2 = Convert.ToDateTime(Me.DteFechaFin.Text)


        Select Case Me.Reporte.SelectedValue
            Case "1"
                Me.lbltotalcomisiones.Text = ""
                Me.lbltotalcomisiones.Visible = True
                Dim resultReporte1 = vgObjModelo.sp_get_Ventas_compañia(DteFechaInicio.Text, Me.DteFechaFin.Text, Me.vgPropIntCveUserConnected).ToList()

                If resultReporte1.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    ' Dim comision = resultReporte1.Sum(Function(x) x.Total).ToString("C2")
                    'Me.lbltotalcomisiones.Text = "total monto " + comision
                    grdReportes.DataSource = resultReporte1
                    grdReportes.DataBind()
                End If
            Case "2"
                Me.lbltotalcomisiones.Text = ""
                Me.lbltotalcomisiones.Visible = True
                Dim clienteSelecionado As Integer

                If ddlClientes.Visible Then
                    clienteSelecionado = Convert.ToInt32(ddlClientes.SelectedValue)
                Else
                    clienteSelecionado = 0
                End If




                Dim resultReporte2 = vgObjModelo.sp_get_Ventas_clientes(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected, clienteSelecionado).ToList()

                If resultReporte2.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    Dim comision = resultReporte2.Sum(Function(x) x.monto).ToString("C2")
                    Me.lbltotalcomisiones.Text = "total monto " + comision
                    grdReportes.DataSource = resultReporte2
                    grdReportes.DataBind()
                End If

            Case "3"
                Me.lbltotalcomisiones.Text = ""
                Me.lbltotalcomisiones.Visible = False
                Dim resultReporte3 = New ReporteHorasDac().GetReporteHoras(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected)  '  vgObjModelo.sp_get_Ventas_Hora(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected).ToList()
                If resultReporte3.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    'Dim comision = resultReporte3.Sum(Function(x) x.).ToString("C2")
                    'Me.lbltotalcomisiones.Text = "total monto " + comision
                    grdReportes.DataSource = resultReporte3
                    grdReportes.DataBind()
                End If
            Case "4"
                Me.lbltotalcomisiones.Text = ""
                Me.lbltotalcomisiones.Visible = True
                Dim resultReporte4 = vgObjModelo.sp_get_Depositos_Recibidos(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected, Convert.ToInt32(ddlBanco.SelectedValue)).ToList()

                If resultReporte4.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    Dim comision = resultReporte4.Sum(Function(x) x.monto).ToString("C2")
                    Me.lbltotalcomisiones.Text = "total monto " + comision
                    grdReportes.DataSource = resultReporte4
                    grdReportes.DataBind()
                End If
            Case "5"
                Me.lbltotalcomisiones.Text = ""
                Me.lbltotalcomisiones.Visible = True
                Dim resultReporte5 = New reportetraspasos().GetReporteTraspasos(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected).ToList()

                If resultReporte5.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    Dim comision = resultReporte5.Sum(Function(x) x.monto).ToString("C2")
                    Me.lbltotalcomisiones.Text = "total monto " + comision
                    grdReportes.DataSource = resultReporte5
                    grdReportes.DataBind()
                End If
            Case "6"
                Dim prueba = DateTime.Now.AddDays(5)

                Dim resultadoreporte6 = New ComisionesDac().GetComisiones(vgPropIntCveUserConnected, Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text))
                If resultadoreporte6.Count() = 0 Then
                    Dim mensaje As String = "alert('No se encontraron resultados');"

                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
                Else
                    Me.lbltotalcomisiones.Visible = True
                    Dim comtotal As String = resultadoreporte6.Sum(Function(x) x.Comision).ToString("C2")
                    Me.lbltotalcomisiones.Text = "total de comisiones: " + comtotal
                    grdReportes.DataSource = resultadoreporte6
                    grdReportes.DataBind()
                End If
        End Select
    End Sub

    Protected Sub btnDescargarExcel_Click(sender As Object, e As EventArgs) Handles btnDescargarExcel.Click

        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")

        Me.lblMessage.Style.Remove("color")
        Me.lblMessage.Style.Add("color", "red")
        Me.lblMessage.Text = ""
        If Me.Reporte.SelectedValue.Equals("0") Then
            Me.lblMessage.Text = "Favor de seleccionar el reporte."
            Exit Sub
        End If

        If Trim(Me.DteFechaInicio.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha del Depósito.</li>"
            Exit Sub
        End If

        If Trim(Me.DteFechaFin.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha del Depósito.</li>"
            Exit Sub
        End If

        Dim rutaArchivo As String
        Dim rutas As Util_URL = Util_URL.getInstance()
        Dim newURL As New Util_ArmaURL()



        Select Case Me.Reporte.SelectedValue
            Case "1"
                Dim resultReporte1 = vgObjModelo.sp_get_Ventas_compañia(DteFechaInicio.Text, Me.DteFechaFin.Text, Me.vgPropIntCveUserConnected).ToList()
                rutaArchivo = resultReporte1.ExportaExcel("VentasPorCompania")

                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "VentasPorCompania.xlsx")
                Response.Redirect(newURL.GetURL)

            Case "2"
                Dim clienteSelecionado As Integer

                If ddlClientes.Visible Then
                    clienteSelecionado = Convert.ToInt32(ddlClientes.SelectedValue)
                Else
                    clienteSelecionado = 0
                End If

                Dim resultReporte2 = vgObjModelo.sp_get_Ventas_clientes(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected, clienteSelecionado).ToList()

                rutaArchivo = resultReporte2.ExportaExcel("VentasPorClientes")

                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "VentasPorClientes.xlsx")
                Response.Redirect(newURL.GetURL)
            Case "3"
                Dim resultReporte2 = New ReporteHorasDac().GetReporteHoras(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected) 'vgObjModelo.sp_get_Ventas_Hora(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected).ToList()

                rutaArchivo = resultReporte2.ExportaExcel("VentasPorHora")

                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "VentasPorHora.xlsx")
                Response.Redirect(newURL.GetURL)
            Case "4"
                Dim resultReporte2 = vgObjModelo.sp_get_Depositos_Recibidos(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected, Convert.ToInt32(ddlBanco.SelectedValue)).ToList()

                rutaArchivo = resultReporte2.ExportaExcel("DepositosRecibidos")

                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "DepositosRecibidos.xlsx")
                Response.Redirect(newURL.GetURL)
            Case "5"
                Dim resultReporte2 = New reportetraspasos().GetReporteTraspasos(Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text), Me.vgPropIntCveUserConnected).ToList()

                rutaArchivo = resultReporte2.ExportaExcel("TraspasosOtrosCargos")

                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "TraspasosOtrosCargos.xlsx")
                Response.Redirect(newURL.GetURL)

            Case "6"
                Dim resultadoreporte6 = New ComisionesDac().GetComisiones(vgPropIntCveUserConnected, Convert.ToDateTime(DteFechaInicio.Text), Convert.ToDateTime(Me.DteFechaFin.Text))
                rutaArchivo = resultadoreporte6.ExportaExcel("Comisiones")
                newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
                newURL.AddParameter("rutaArchivo", rutaArchivo)
                newURL.AddParameter("nombreArchivo", "Comisiones.xlsx")
                Response.Redirect(newURL.GetURL)
        End Select
    End Sub

    Private Sub LLenaClientes()
        Dim clientes_ = vgObjModelo.CLIENTES.Where(Function(r) r.STATUS = "1").ToList().OrderBy(Function(x) x.NOMBRE).ToList()
        If Not vgPropIntCveUserConnected = 1 Then
            Dim idcte As Nullable(Of Integer)
            idcte = vgPropIntCveCteConnected
            Dim existen = clientes_.Where(Function(x) If(x.FK_CLIENTE_PADRE Is Nothing, 0, x.FK_CLIENTE_PADRE) = idcte).Count()
            If existen > 0 Then
                clientes_ = clientes_.Where(Function(x) If(x.FK_CLIENTE_PADRE Is Nothing, 0, x.FK_CLIENTE_PADRE) = idcte).ToList()
                ddlClientes.DataSource = clientes_
                ddlClientes.DataTextField = "NOMBRE"
                ddlClientes.DataValueField = "PK_CLIENTE"
                ddlClientes.DataBind()
            End If
        Else
            ddlClientes.DataSource = clientes_
            ddlClientes.DataTextField = "NOMBRE"
            ddlClientes.DataValueField = "PK_CLIENTE"
            ddlClientes.DataBind()
        End If

    End Sub

    Private Sub LLenaBancos()
        Dim clientes_ = vgObjModelo.CAT_BANCOS.ToList()
        Dim seleccione As New CAT_BANCOS()
        seleccione.PK_CAT_BANCO = 0
        seleccione.NOMBRE_CORTO = "Seleccione"
        clientes_.Insert(0, seleccione)
        ddlBanco.Items.Clear()
        ddlBanco.DataSource = clientes_
        ddlBanco.DataTextField = "NOMBRE_CORTO"
        ddlBanco.DataValueField = "PK_CAT_BANCO"
        ddlBanco.DataBind()
    End Sub

    Protected Sub Reporte_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles Reporte.SelectedIndexChanged
        If Reporte.SelectedValue = "2" Then
            Me.lblCliente.Visible = True
            Me.ddlClientes.Visible = True

        Else
            Me.lblCliente.Visible = False
            Me.ddlClientes.Visible = False
        End If

        If Reporte.SelectedValue = "4" Then
            Me.lblBanco.Visible = True
            Me.ddlBanco.Visible = True

        Else
            Me.lblBanco.Visible = False
            Me.ddlBanco.Visible = False
        End If
    End Sub
End Class