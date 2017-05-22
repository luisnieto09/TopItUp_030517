Imports TopItUp.Helpers
Public Class EdoCta
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp
    Dim vgPkCliente As Integer = -1
    Private Property propVgBlOnlyTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property
    Private Property vgPropFechaIni As Date
        Set(value As Date)
            Session("FECHA_INI") = value
        End Set
        Get
            Return CType(Session("FECHA_INI"), Date)
        End Get
    End Property
    Private Property vgPropFechaFin As Date
        Set(value As Date)
            Session("FECHA_FIN") = value
        End Set
        Get
            Return CType(Session("FECHA_FIN"), Date)
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

    Private Property vgPropIntRowIni As Integer
        Set(value As Integer)
            Session("ROW_INI") = value
        End Set
        Get
            Return Session("ROW_INI")
        End Get
    End Property

    Private Property vgPropIntRowFin As Integer
        Set(value As Integer)
            Session("ROW_FIN") = value
        End Set
        Get
            Return Session("ROW_FIN")
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

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")


            Me.lblFechaSaldo.Text = Date.Now.Date
            Me.lblFechaSaldo.Visible = True

            Me.dteFechaIni.Text = Date.Now.Date
            Me.dteFechaFin.Text = Date.Now.Date

            Me.vgPropFechaIni = CDate(Me.dteFechaIni.Text).Date
            Me.vgPropFechaFin = CDate(Me.dteFechaFin.Text).Date

            Me.vgPropIntRowIni = 0
            Me.vgPropIntRowFin = 0

            sub_fillMostrarHasta()
            sub_FillGrid()

            If Me.propVgBlOnlyTelcel = True Then
                Session("intSoloTelcel") = 1
                imglogox.ImageUrl = "../Images/recargastelcel.png"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenu.jpg);background-size: cover;")
            Else
                Session("intSoloTelcel") = 0
                Me.logoTelcel.Visible = False
                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenuOtras.jpg);background-size: cover;")
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
            Try
                Me.lblUsrConnected.Text = vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"
        End If

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(vgPropObjUserConnected.PK_USER)
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

    Private Sub sub_fillMostrarHasta()
        Dim objDAC As New MostrarHastaDac
        ddlMostarHasta.DataValueField = "ROW_NUMBER_IN_QUERY"
        ddlMostarHasta.DataTextField = "NOMBRE_MOSTRAR"
        ddlMostarHasta.DataSource = objDAC.func_GetAll()
        ddlMostarHasta.DataBind()
    End Sub

    Private Sub sub_FillGrid()
        Me.grdUltimosMvtosTodosLosCtes.Dispose()
        Dim db As New EdoCuentaResult
        Me.grdUltimosMvtosTodosLosCtes.DataSource = db.getEdoCuenta(vgPropIntCveUserConnected, vgPropFechaIni, vgPropFechaFin, Me.vgPropIntRowIni, vgPropIntRowFin)
        Me.grdUltimosMvtosTodosLosCtes.DataBind()
    End Sub

    Protected Sub btnExportarEdoCta_Click(sender As Object, e As EventArgs) Handles btnExportarEdoCta.Click
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")

        Dim rutaArchivo As String
        Dim rutas As Util_URL = Util_URL.getInstance()
        Dim newURL As New Util_ArmaURL()

        If Me.dteFechaIni.Text <> String.Empty Then
            Me.vgPropFechaIni = Convert.ToDateTime(Me.dteFechaIni.Text) 'CDate(Me.dteFechaIni.Text).Date
        Else
            Me.vgPropFechaIni = Date.Now.AddYears(-10).Date
        End If

        Me.lblFechaIni.Text = vgPropFechaIni

        If Me.dteFechaFin.Text <> String.Empty Then
            Me.vgPropFechaFin = Convert.ToDateTime(Me.dteFechaFin.Text) 'CDate(Me.dteFechaFin.Text).Date
        Else
            Me.vgPropFechaFin = Date.Now.AddYears(10).Date
        End If

        Me.lblfechaFin.Text = vgPropFechaFin


        'Dim resultReporte1 = vgObjModelo.sp_GetEdoCtaByPkUser(Me.vgPropIntCveUserConnected, Me.vgPropFechaIni, Me.vgPropFechaFin).ToList()
        Dim resultReporte1 = New EdoCuentaResult().getEdoCuenta(vgPropIntCveUserConnected, vgPropFechaIni, vgPropFechaFin, Me.vgPropIntRowIni, vgPropIntRowFin)
        Dim listasinkeys = (
            From x In resultReporte1
            Select New detalleEdoCuenta With {.ID = x.ID,
                                                        .FECHA = x.FECHA,
                                                        .HORA = x.HORA,
                                                        .MOVIMIENTO = x.MOVIMIENTO,
                                                        .MEDIO_DE_PAGO = x.MEDIO_DE_PAGO,
                                                        .motivo = x.motivo,
                                                        .cargo = x.cargo,
                                                        .abono = x.abono,
                                                        .saldo = x.saldo
                                                         }).ToList()
        rutaArchivo = listasinkeys.ExportaExcel("EstadoDeCuenta")

        newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
        newURL.AddParameter("rutaArchivo", rutaArchivo)
        newURL.AddParameter("nombreArchivo", "EstadoDeCuenta.xlsx")
        Response.Redirect(newURL.GetURL)
    End Sub

    'Protected Sub dteFechaFin_TextChanged(sender As Object, e As EventArgs) Handles dteFechaFin.TextChanged
    '    If Me.dteFechaFin.Text <> String.Empty Then
    '        Me.vgPropFechaFin = CDate(Me.dteFechaFin.Text).Date
    '    Else
    '        Me.vgPropFechaFin = Date.Now.AddYears(10).Date
    '    End If

    '    Me.lblfechaFin.Text = vgPropFechaFin

    '    sub_FillGrid()
    'End Sub

    'Protected Sub dteFechaIni_TextChanged(sender As Object, e As EventArgs) Handles dteFechaIni.TextChanged
    'If Me.dteFechaIni.Text <> String.Empty Then
    '        Me.vgPropFechaIni = CDate(Me.dteFechaIni.Text).Date
    '    Else
    '        Me.vgPropFechaIni = Date.Now.AddYears(-10).Date
    '    End If

    '    Me.lblFechaIni.Text = vgPropFechaIni

    '    sub_FillGrid()
    'End Sub

    Protected Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
        ViewState("SALDO_HEADER") = Nothing
        ViewState("CARGO") = Nothing
        ViewState("ABONO") = Nothing
        If Me.dteFechaIni.Text <> String.Empty Then
            Me.vgPropFechaIni = Convert.ToDateTime(Me.dteFechaIni.Text) 'CDate(Me.dteFechaIni.Text).Date
        Else
            Me.vgPropFechaIni = Date.Now.AddYears(-10).Date
        End If

        Me.lblFechaIni.Text = vgPropFechaIni

        If Me.dteFechaFin.Text <> String.Empty Then
            Me.vgPropFechaFin = Convert.ToDateTime(Me.dteFechaFin.Text) 'CDate(Me.dteFechaFin.Text).Date
        Else
            Me.vgPropFechaFin = Date.Now.AddYears(10).Date
        End If

        Me.lblfechaFin.Text = vgPropFechaFin

        sub_FillGrid()
    End Sub

    Private Sub grdUltimosMvtosTodosLosCtes_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdUltimosMvtosTodosLosCtes.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                If CDec(e.Row.Cells(8).Text) = 0 Then
                    If ViewState("SALDO_HEADER") Is Nothing Then
                        Dim clsGeneric As New clsGenerics
                        Dim prueba As String = FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
                        CType(grdUltimosMvtosTodosLosCtes.Rows(e.Row.RowIndex).FindControl("lblSaldo"), Label).Text = prueba
                        ViewState("SALDO_HEADER") = CDec(prueba) 'Me.lblSaldoGlobal.Text
                        'ViewState("CARGO") = e.Row.Cells(6).Text
                        'ViewState("ABONO") = e.Row.Cells(7).Text
                    Else
                        'Dim saldo As Decimal = CDec(ViewState("SALDO_HEADER")) + CDec(ViewState("ABONO")) - CDec(ViewState("CARGO"))
                        ' ViewState("SALDO_HEADER") = CType(grdUltimosMvtosTodosLosCtes.Rows(e.Row.RowIndex).FindControl("lblSaldo"), Label).Text 'saldo
                        Dim saldo As Decimal = CDec(ViewState("SALDO_HEADER")) + CDec(e.Row.Cells(6).Text) - CDec(e.Row.Cells(7).Text)
                        ViewState("SALDO_HEADER") = saldo
                        CType(grdUltimosMvtosTodosLosCtes.Rows(e.Row.RowIndex).FindControl("lblSaldo"), Label).Text = saldo
                        'ViewState("CARGO") = e.Row.Cells(6).Text
                        'ViewState("ABONO") = e.Row.Cells(7).Text
                    End If
                Else
                    CType(grdUltimosMvtosTodosLosCtes.Rows(e.Row.RowIndex).FindControl("lblSaldo"), Label).Text = e.Row.Cells(8).Text
                End If
            Else ' 
                CType(grdUltimosMvtosTodosLosCtes.Rows(e.Row.RowIndex).FindControl("lblSaldo"), Label).Text = e.Row.Cells(8).Text
            End If
        End If
    End Sub

    Protected Sub btnActualizarEdoCta_Click(sender As Object, e As EventArgs) Handles btnActualizarEdoCta.Click
        'btnMostrar_Click(btnMostrar, New EventArgs)
        Response.Redirect("EdoCta.aspx")
    End Sub

    Protected Sub ddlMostarHasta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMostarHasta.SelectedIndexChanged
        vgPropIntRowIni = 1
        Me.vgPropIntRowFin = ddlMostarHasta.SelectedItem.Value
        ' Me.sub_FillGrid()
    End Sub

End Class

Public Class detalleEdoCuenta
    Public Property ID As Integer
    Public Property FECHA As Date
    Public Property HORA As String
    Public Property MOVIMIENTO As String
    Public Property MEDIO_DE_PAGO As String
    Public Property motivo As String
    Public Property cargo As Decimal
    Public Property abono As Decimal
    Public Property saldo As Decimal

End Class