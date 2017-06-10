'Imports Telerik.Web.UI
Imports TopItUp.Helpers
Imports System.Net.Mail
Imports System.Configuration
Imports System.Globalization

Public Class Deps
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp
    Dim vgPkCliente As Integer = -1
    'Se debe poner de acuerdo al tipo de acceso (Nuevo, edición, Consulta o VoBo)
    Dim vgBlnNewEditMode As Boolean

    Property propDtPagosEnviadosCte As DataTable
        Set(value As DataTable)
            Session("propDtPagosEnviadosCte") = value
        End Set
        Get
            Return CType(Session("propDtPagosEnviadosCte"), DataTable)
        End Get
    End Property

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

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        Dim clsGeneric As New clsGenerics

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

            Dim arKeys(0) As String
            arKeys(0) = "PK_PAGO"
            grdPagosEnviados.DataKeyNames = arKeys

            If Me.propVgBlOnlyTelcel = True Then
                imglogox.ImageUrl = "../Images/recargastelcel.png"
                'opc10.HRef = "../Default.aspx"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
            Else
                'opc10.HRef = "../Otras.aspx"
                Me.logoTelcel.Visible = False
                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                ' tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white !important")
            Try

                Me.lblUsrConnected.Text = Me.vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = vgPropObjCteConnected.NOMBRE
                Me.txtNombreCliente.Text = vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                        Me.btnModoAddDeps.Visible = True
                        Me.btnModoVoBoDeps.Visible = True
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                        Me.btnModoAddDeps.Visible = False
                        Me.btnModoVoBoDeps.Visible = False
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                        Me.btnModoAddDeps.Visible = False
                        Me.btnModoVoBoDeps.Visible = False
                End Select

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"
        End If

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        If Not IsPostBack Then
            If Me.vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                vgBlnNewEditMode = False
            Else
                vgBlnNewEditMode = True
            End If

            If Not Session("vgBlnNewEditMode") Is Nothing Then
                vgBlnNewEditMode = CType(Session("vgBlnNewEditMode"), Boolean)
                sub_FillCtes()
                Me.txtNombreCliente.Visible = False
                Me.ddlCtes.Visible = True
            Else
                Me.ddlCtes.Visible = False
            End If

            'vgBlnNewEditMode = CType(Session("MODE_EDIT_DEPOSITO"), Boolean)

            Dim dtPagosEnviadosCte As New DataTable
            dtPagosEnviadosCte.Columns.Add("Archivo", GetType(String))
            dtPagosEnviadosCte.Columns.Add("Fecha_carga", GetType(Date))
            dtPagosEnviadosCte.Columns.Add("Estatus_carga", GetType(String))
            dtPagosEnviadosCte.Columns.Add("Estado", GetType(String))
            dtPagosEnviadosCte.Columns.Add("BANCO", GetType(String))
            dtPagosEnviadosCte.Columns.Add("CUENTA", GetType(String))
            dtPagosEnviadosCte.Columns.Add("SALDO_ACTUAL", GetType(String))
            dtPagosEnviadosCte.Columns.Add("MONTO_PAGO", GetType(String))
            dtPagosEnviadosCte.Columns.Add("NUEVO_SALDO", GetType(String))
            dtPagosEnviadosCte.Columns.Add("USUARIO", GetType(String))
            dtPagosEnviadosCte.Columns.Add("CLIENTE", GetType(String))

            propDtPagosEnviadosCte = dtPagosEnviadosCte

            subCargaBancos()
            Sub_HabilitaModo()

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
                Me.lblSaldoGlobal.Text = String.Empty '"Saldo Global: $" & FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
            End If
        End If

    End Sub

    Private Sub sub_FillCtes()

        Dim liSeleccione As New ListItem
        liSeleccione.Text = "Seleccione"
        liSeleccione.Value = -1
        Me.ddlCtes.Items.Add(liSeleccione)
        Dim g As New clsGenerics

        'For Each cte As CLIENTES In vgObjModelo.CLIENTES.ToList()
        '    Dim li As New ListItem
        '    Try
        '        li.Text = cte.NOMBRE '& " [ " & g.func_GetUsrConnected(g.func_GetUserByCliente(cte.PK_CLIENTE)).USERNAME & " ]"
        '    Catch ex As Exception
        '        li.Text = cte.NOMBRE
        '    End Try
        '    li.Value = cte.PK_CLIENTE
        '    Me.ddlCtes.Items.Add(li)
        'Next

        For Each cte As CLIENTES In vgObjModelo.CLIENTES.SqlQuery("SELECT * FROM CLIENTES WHERE STATUS = 1 ORDER BY NOMBRE ASC").ToList()

            'Fill a clientes a depositar
            Dim li As New ListItem

            Try
                li.Text = cte.NOMBRE '& " => " & g.func_GetUsrConnected(g.func_GetUserByCliente(cte.PK_CLIENTE)).USERNAME
            Catch ex As Exception
                li.Text = cte.NOMBRE
            End Try

            li.Value = cte.PK_CLIENTE
            Me.ddlCtes.Items.Add(li)
        Next

        ddlCtes.DataBind()
    End Sub

    Private Sub Sub_HabilitaModo()
        If vgBlnNewEditMode = True Then
            Me.txtMontoPago.Visible = True
            Me.ddlBancos.Visible = True
            Me.ddlCuentas.Visible = True
            Me.uploadAsync.Visible = True
            Me.txtHoraMinSegDep.Visible = True
            Me.lblInfoFiles.Visible = True
            Me.DteFechaDeposito.Visible = True
            Me.btnEnviar.Visible = True
            Me.btnAutorizar.Visible = False
            Me.btnRechazarDep.Visible = False
            Me.txtMotivoRechazo.Visible = False
            Me.lblMotivoRechazo.Visible = False
            Me.lblHorarioDep.Visible = False
        Else
            'Consulta y VoBo
            Me.lblMontoPagado.Visible = True
            Me.lblBanco.Visible = True
            Me.lblCuenta.Visible = True
            Me.btnEnviar.Visible = False
            Me.btnAutorizar.Visible = False
            Me.btnRechazarDep.Visible = False
            Me.lblSucursal.Visible = True
            Me.lblNombreSuc.Visible = True
            Me.lblNumAutorizacion.Visible = True
            Me.divTablaDetalle.Visible = False
            Me.grdPagosEnviados.Columns(12).Visible = True 'Muestro el botón para editar el registro
            Me.lblMotivoRechazo.Visible = True
            Me.lblNombreCte.Visible = True
            Me.txtMotivoRechazo.Visible = False
            Me.txtNumSucursal.Visible = False
            Me.txtNumAutorizacion.Visible = False
            Me.ddlBancos.Enabled = False
            Me.ddlCuentas.Enabled = False
            Me.txtMontoPago.Enabled = False
            Me.txtNombreCliente.Enabled = False
            Me.txtNombreSucursal.Enabled = False
            Me.txtNumAutorizacion.Enabled = False
            Me.txtNumSucursal.Enabled = False
            Me.lblFechaDep.Visible = True

            Me.txtHoraMinSegDep.Visible = False
            Me.DteFechaDeposito.Visible = False
            Me.lblHorarioDep.Visible = True
            Me.lblFechaDep.Visible = True
            Me.lblCteConnected.Visible = True
            Me.lblNombreSuc.Visible = True
            Me.txtNombreCliente.Visible = False
            Me.txtNombreSucursal.Visible = False
            'Dim objpago As New PAGOS()
            'objPago = vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(Me.grdPagosEnviados.SelectedIndex).Value)
        End If

    End Sub

    Private Sub subCargaBancos()
        Dim item0 As New ListItem

        item0.Text = "Seleccione"
        item0.Value = -1

        Me.ddlBancos.Items.Add(item0)

        For Each banco As CAT_BANCOS In vgObjModelo.CAT_BANCOS.ToList.Where(Function(x) x.STATUS = "1").ToList()
            Dim itemBanco As New ListItem
            itemBanco.Value = banco.PK_CAT_BANCO
            itemBanco.Text = banco.NOMBRE_CORTO
            Me.ddlBancos.Items.Add(itemBanco)
        Next

    End Sub

    Private Sub SubMuestraArchivo(strUrlImage As String, intTipoDoc As Integer)
        Dim myLbl As New Label
        Dim strTipoDoc As String

        Select Case intTipoDoc
            Case 1 'WORD
                strTipoDoc = "word.jpg"
            Case 2 ' PDF
                strTipoDoc = "pdf.jpg"
            Case 3 ' IMAGEN
                strTipoDoc = "image.jpg"
            Case Else
                strTipoDoc = "image.jpg"
        End Select

        myLbl.Text = "<a href='" & strUrlImage & "' TARGET='_blank'><img src='/Images/" & strTipoDoc & "' width='32' height='32'></a> "

        Me.pnlFiles.Controls.Add(myLbl)
    End Sub

    Private Function funcBlnValida() As Boolean
        Dim blnValido As Boolean = True

        Me.lblMessage.Text = "Para enviar a solicitud será necesario: <ol>"

        If Trim(Me.txtMontoPago.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar monto del pago a reportar.</li>"
            blnValido = False
        End If

        If Me.ddlBancos.SelectedItem.Value = "-1" Then
            Me.lblMessage.Text &= "<li>Seleccionar Banco.</li>"
            blnValido = False
        End If

        If ddlCtes.Visible = True Then
            If Me.ddlCtes.SelectedValue = -1 Then
                Me.lblMessage.Text &= "<li>Cliente que realiza el depósito.</li>"
                blnValido = False
            End If
        End If

        Try
            If Me.ddlCuentas.SelectedItem.Value = "-1" Then
                Me.lblMessage.Text &= "<li>Seleccionar Cuenta Bancaria.</li>"
                blnValido = False
            End If
        Catch ex As Exception
            Me.lblMessage.Text &= "<li>Seleccionar Cuenta Bancaria.</li>"
            blnValido = False
        End Try

        If Trim(Me.txtNumSucursal.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Número de Sucursal.</li>"
            blnValido = False
        End If

        If Trim(Me.txtNombreSucursal.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Nombre de la Sucursal.</li>"
            blnValido = False
        End If

        If Trim(Me.txtNumAutorizacion.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Número de autorización / No. de depósito.</li>"
            blnValido = False
        End If

        If Trim(Me.DteFechaDeposito.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha del Depósito.</li>"
            blnValido = False
        End If

        If Trim(Me.txtHoraMinSegDep.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Horario de pago HH:MM:SS.</li>"
            blnValido = False
        End If

        If Me.uploadAsync.PostedFiles.Count = 0 Then
            Me.lblMessage.Text &= "<li>Seleccionar archivos para cargar.</li>"
            blnValido = False
        End If

        Me.lblMessage.Text &= "</ol>"

        Return blnValido
    End Function

    Private Sub ddlBancos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBancos.SelectedIndexChanged
        Dim cta As New ListItem
        Dim ctaSeleccione As New ListItem

        ddlCuentas.Items.Clear()

        ctaSeleccione.Value = -1
        ctaSeleccione.Text = "Seleccione"
        ddlCuentas.Items.Add(ctaSeleccione)

        For Each ctaEmpresa As CTAS_BANCARIAS_EMPRESAS In vgObjModelo.CTAS_BANCARIAS_EMPRESAS.SqlQuery("SELECT * FROM CTAS_BANCARIAS_EMPRESAS WHERE FK_CAT_BANCO=" & ddlBancos.SelectedItem.Value)
            Dim liCuenta As New ListItem
            If ctaEmpresa.STATUS = 1 Then
                liCuenta.Value = ctaEmpresa.PK_CTA_BANCARIA_EMPRESA
                liCuenta.Text = ctaEmpresa.NUMERO_CTA
                ddlCuentas.Items.Add(liCuenta)
            End If
        Next

        If ddlBancos.SelectedItem.Value = -1 Then
            Me.lblMessage.Text = "Favor de seleccionar banco."
        End If

    End Sub

    'Selecciono el depósito para poder revisarlo y Autorizar o Rechazar
    Private Sub grdPagosEnviados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdPagosEnviados.RowCommand
        'If e.CommandName = "Editar" Then
        '    sub_FillControls(grdPagosEnviados.DataKeys(0).Value)
        '    sub_DeshabilitaControles()
        'End If
    End Sub

    Private Sub sub_FillControls(ByVal objPago As PAGOS)
        Dim objCuenta As New CTAS_BANCARIAS_EMPRESAS
        Dim objUser As New USERS

        objCuenta = vgObjModelo.CTAS_BANCARIAS_EMPRESAS.Find(objPago.FK_CTA_BANCARIA_EMPRESA_DEPOSITO)
        vgObjModelo = New EDM_TopItUp
        objUser = vgObjModelo.USERS.Find(objPago.FK_USER)

        Me.lblBanco.Text = vgObjModelo.CAT_BANCOS.Find(objCuenta.FK_CAT_BANCO).NOMBRE_CORTO
        Me.lblCuenta.Text = objCuenta.NUMERO_CTA
        Me.lblSucursal.Text = objPago.SUC_NUMERO
        Me.lblNombreSuc.Text = objPago.SUC_NOMBRE
        Me.lblMontoPagado.Text = objPago.MONTO_PAGO
        Me.lblFechaDep.Text = objPago.FECHA_PAGO_CLIENTE
        Me.txtNombreCliente.Text = objUser.AP_MATERNO & " " & objUser.AP_MATERNO & " " & objUser.NOMBRE
        Me.lblNumAutorizacion.Text = objPago.NUM_AUT_DEP
        Me.lblMotivoRechazo.Text = objPago.MOTIVO_RECHAZO
        Me.lblHorarioDep.Text = objPago.HORA_MIN_PAGO
        Me.lblNombreCte.Text = objUser.AP_MATERNO & " " & objUser.AP_MATERNO & " " & objUser.NOMBRE
        'Carga archivos
        Dim objPagosFiles As New PAGOS_FILES_UPLOADED

        For Each fileUploaded As PAGOS_FILES_UPLOADED In Me.vgObjModelo.PAGOS_FILES_UPLOADED.SqlQuery("SELECT * FROM PAGOS_FILES_UPLOADED WHERE FK_PAGO=" & objPago.PK_PAGO).ToList()
            Dim objFile As FILES = vgObjModelo.FILES.Find(fileUploaded.FK_FILE)

            Dim link As New HyperLink()
            Dim tRow As New TableRow
            Dim tCell = New TableCell()
            link.Style.Add("color", "white")
            link.NavigateUrl = "..\FilesUploaded\" & objFile.NOMBRE_SAVED
            link.Text = objFile.NOMBRE_REAL
            link.Target = "_blank"
            tblDocs.Rows.Add(tRow)
            tCell.Controls.Add(link)
            tRow.Cells.Add(tCell)
        Next

    End Sub

    'MUESTRO U OCULTO LA OPCIÓN DE EDITAR SEGÚN EL ESTADO DE LA SOLICITUD
    Private Sub grdPagosEnviados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdPagosEnviados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Sólo para el caso de ENVIADA muestro la opción de EDITAR

            Try





                Dim fkstatus As String = e.Row.Cells(11).Text

                If fkstatus = "Autorizado" Then
                    e.Row.BackColor = Drawing.Color.LawnGreen
                End If
                If fkstatus = "Rechazado" Then
                    e.Row.BackColor = Drawing.Color.Crimson
                    e.Row.ForeColor = Drawing.Color.White
                End If



                'AUTORIZADO
                'If vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(e.Row.RowIndex).FK_CAT_STATUS_PAGO = 2 Then
                '    e.Row.BackColor = Drawing.Color.Green
                'End If

                ''RECHAZADO
                'If vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(e.Row.AccessKey()).Value).FK_CAT_STATUS_PAGO = 3 Then
                '    e.Row.BackColor = Drawing.Color.Red
                'End If
            Catch ex As Exception

            End Try

        Else
            '        'No es posible editarse el registro porque ya se autorizó o rechazó con anterioridad
        End If


        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    'Sólo para el caso de ENVIADA muestro la opción de EDITAR
        '    If vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(e.Row.AccessKey()).Value).FK_CAT_STATUS_PAGO = 1 Then
        '        e.Row.FindControl("").Visible = False
        '    Else
        '        'No es posible editarse el registro porque ya se autorizó o rechazó con anterioridad
        '    End If
        'End If
    End Sub

    Protected Sub grdPagosEnviados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPagosEnviados.SelectedIndexChanged
        If Me.grdPagosEnviados.SelectedIndex <> -1 Then
            Dim objPago As PAGOS = vgObjModelo.PAGOS.Find(Me.grdPagosEnviados.DataKeys(Me.grdPagosEnviados.SelectedIndex).Value)
            sub_ShowDetail(objPago)
        End If
    End Sub

    Private Sub sub_ShowDetail(ByVal vpIntPkPago As PAGOS)
        Me.divTablaDetalle.Visible = True
        Me.btnAutorizar.Visible = True
        Me.btnRechazarDep.Visible = True
        Me.sub_FillControls(vpIntPkPago)
        Me.grdPagosEnviados.Visible = False
    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("Deps.aspx")
    End Sub

    Protected Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Try

            System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")

            'Si hay un registro seleccionado 
            If Me.grdPagosEnviados.SelectedIndex <> -1 Then
                Dim objPago As New PAGOS
                objPago = vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(Me.grdPagosEnviados.SelectedIndex).Value)

                'Verifico que el estado de la solicitud sea PENDIENTE, en caso contrario notifico
                If objPago.FK_CAT_STATUS_PAGO = 1 Then
                    'Autoriza el pago
                    objPago.FK_CAT_STATUS_PAGO = 2
                    objPago.FECHA_APLICACION = Date.Now
                    vgObjModelo.SaveChanges()

                    Dim objClsGeneric As New clsGenerics

                    'AGRAGO EL SALDO PARA HACER LAS PRUEBAS PERO EN REALIDAD DEBE IR EN LA PARTE DE AUTORIZAR EL SALDO
                    Dim objSaldo As New SALDOS
                    objSaldo.FK_PAGO = objPago.PK_PAGO
                    objSaldo.FECHA_MVTO = objPago.FECHA_APLICACION
                    objSaldo.FK_USER = objPago.FK_USER
                    objSaldo.MONTO_PAGO = objPago.MONTO_PAGO
                    objSaldo.SALDO = objClsGeneric.func_GetSaldoUsr(objPago.FK_USER) + objPago.MONTO_PAGO
                    vgObjModelo.SALDOS.Add(objSaldo)
                    vgObjModelo.SaveChanges()

                    Try
                        Me.grdPagosEnviados.Dispose()
                        Me.grdPagosEnviados.DataBind()
                    Catch ex As Exception
                    End Try

                    Me.lblMessage.Text = "Movimiento correcto, el saldo ha sido aumentado correctamente."
                    Dim mail As New BACK_CODE.EnviaCorreo
                    Try
                        mail.EnviaCorreo("Ha sido AUTORIZADO un depósito por " & Me.vgPropObjUserConnected.USERNAME & ". <br><br>Datos aplicados: <br>Banco: <b>" & Me.lblBanco.Text & "</b><br>Cuenta: <b>" & Me.lblCuenta.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>Fecha depósito " & objPago.FECHA_PAGO_CLIENTE & "<br>FECHA DE APLICACIÓN<b>" & objPago.FECHA_APLICACION & "</b>", "Favor de validar depósito AUTORIZADO", False)
                        If Me.vgPropObjUserConnected.EMAIL <> String.Empty Then
                            mail.EnviaCorreoIndividual("Estimado " & Me.vgPropObjUserConnected.NOMBRE & " " & Me.vgPropObjUserConnected.AP_PATERNO & ", hemos autorizado su depósito realizado en <b>" & Me.lblBanco.Text & "</b> , cuenta <b>" & Me.lblCuenta.Text & "</b> por la cantidad de <b>" & objPago.MONTO_PAGO & "</b> con fecha depósito " & objPago.FECHA_PAGO_CLIENTE, "Depósito autorizado [ " & Me.lblBanco.Text & " ]", 2, Me.vgPropObjUserConnected.EMAIL)
                        End If

                        mail.EnviaCorreoIndividual("Ha sido AUTORIZADO un depósito por " & Me.vgPropObjUserConnected.USERNAME & ". <br><br>Datos aplicados: <br>Banco: <b>" & Me.lblBanco.Text & "</b><br>Cuenta: <b>" & Me.lblCuenta.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>Fecha depósito " & objPago.FECHA_PAGO_CLIENTE & "<br>FECHA DE APLICACIÓN<b>" & objPago.FECHA_APLICACION & "</b>", "Favor de validar depósito AUTORIZADO", 2, "atencion.clientes@topitup.net")

                    Catch exX As Exception
                        Me.lblMessage.Text = "ERR: " & exX.Message
                    End Try
                Else
                    'Sino es PENDIENTE notifico
                    Me.lblMessage.Text = "Estimado usuario, la solicitud seleccionada ya fue revisada con anterioridad."
                End If
            Else
                Me.lblMessage.Visible = True
                Me.lblMessage.Text = "Para poder autorizar un registro primero deberá seleccionarlo."
            End If
        Catch ex As Exception
            Me.lblMessage.Visible = True
            Me.lblMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If funcBlnValida() = True Then
            If Me.uploadAsync.HasFile = True Then
                Dim strFileName As String
                Dim vlIntTotalCargados As Integer = 0
                Dim strRutaFile As String
                Dim strRutaServer As String
                'Dim strTipoImgToShow As Integer

                'Guardo la solicitud
                Dim objPago As New PAGOS
                'objPago.FECHA_APLICACION = ""
                Try
                    objPago.FECHA_PAGO_CLIENTE = CDate(Me.DteFechaDeposito.Text)
                Catch ex As Exception
                    objPago.FECHA_PAGO_CLIENTE = Me.DteFechaDeposito.Text
                End Try
                objPago.FK_CTA_BANCARIA_EMPRESA_DEPOSITO = Me.ddlCuentas.SelectedItem.Value
                objPago.FK_MEDIO_DE_PAGO = 1 'SALDO DEL CLIENTE - Transferencia
                objPago.MONTO_PAGO = Me.txtMontoPago.Text
                'objPago.NOMBRE_REAL_COMPROBANTE = objPago.NOMBRE_COMPROBANTE
                objPago.NUM_AUT_DEP = Me.txtNumAutorizacion.Text
                objPago.SUC_NOMBRE = Me.txtNombreSucursal.Text
                objPago.SUC_NUMERO = Me.txtNumSucursal.Text
                objPago.HORA_MIN_PAGO = Me.txtHoraMinSegDep.Text
                Dim objClsGeneric As New clsGenerics

                If Me.btnModoAddDeps.Visible = True Then
                    Dim model As New EDM_TopItUp
                    Dim idc As Integer = CInt(Me.ddlCtes.SelectedValue())
                    Dim userid As Integer = model.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = idc).FirstOrDefault().FK_USER
                    Dim usrBase As USERS = model.USERS.Find(userid)
                    objPago.SALDO_ANTES = objClsGeneric.func_GetSaldoUsr(usrBase.PK_USER)
                    objPago.SALDO_DESPUES = objPago.SALDO_ANTES + objPago.MONTO_PAGO
                    objPago.FK_USER = usrBase.PK_USER
                Else
                    objPago.SALDO_ANTES = objClsGeneric.func_GetSaldoUsr(Me.vgPropObjUserConnected.PK_USER)
                    objPago.SALDO_DESPUES = objPago.SALDO_ANTES + objPago.MONTO_PAGO
                    objPago.FK_USER = Me.vgPropIntCveUserConnected
                End If


                Dim existenumaut As Integer = vgObjModelo.PAGOS.Where(Function(x) x.NUM_AUT_DEP.ToLower().Trim() = txtNumAutorizacion.Text.ToLower().Trim()).Count()

                If existenumaut > 0 Then
                    Me.lblMessage.Text = "El numero de autorización ya existe"
                    Exit Sub
                End If

                objPago.FK_CAT_STATUS_PAGO = 1

                vgObjModelo.PAGOS.Add(objPago)
                vgObjModelo.SaveChanges()
                Dim mail As New BACK_CODE.EnviaCorreo()





                For Each fileUp As HttpPostedFile In Me.uploadAsync.PostedFiles

                    Dim words As String() = fileUp.FileName.Split(New Char() {"\"c})
                    Dim nombreArchivo As String = words(words.Length - 1)


                    strRutaFile = fileUp.FileName

                    Dim rutaserver As String = Server.MapPath(ConfigurationManager.AppSettings("RutaReciboDePago").ToString())

                    strRutaServer = rutaserver & nombreArchivo

                    Dim array = fileUp.FileName.Split(Convert.ToChar("."))
                    Dim largo As Integer = array.Length
                    Dim ext As String = array(largo - 1)

                    If Not (ext = "PNG" Or ext = "png" Or ext = "jpg" Or ext = "JPG" Or ext = "pdf" Or ext = "PDF") Then
                        lblMessage.Text = "Formato de archivo incorrecto"
                        mail.EnviaCorreo("ALERTA, SE INTENTÓ SUBIR UN ARCHIVO INVÁLIDO CON EXTENSIÓN " & ext & " DEL USER id: " & objPago.FK_USER, "MENSAJE DE SEGURIDAD IMPORTANTE !!!!", True)
                        Exit Sub
                    End If

                    fileUp.SaveAs(strRutaServer)

                    Dim link As New HyperLink()
                    Dim tRow As New TableRow
                    Dim tCell = New TableCell()

                    link.NavigateUrl = strRutaServer
                    link.Text = fileUp.FileName
                    link.Target = "_blank"
                    tblDocs.Rows.Add(tRow)
                    tCell.Controls.Add(link)
                    tRow.Cells.Add(tCell)

                    Dim file As New FILES
                    file.NOMBRE_REAL = fileUp.FileName
                    file.NOMBRE_SAVED = fileUp.FileName
                    file.STATUS = 1
                    vgObjModelo.FILES.Add(file)
                    vgObjModelo.SaveChanges()

                    Dim objFileRelation As New PAGOS_FILES_UPLOADED
                    objFileRelation.FK_FILE = file.PK_FILE
                    objFileRelation.FK_PAGO = objPago.PK_PAGO
                    vgObjModelo.PAGOS_FILES_UPLOADED.Add(objFileRelation)
                    vgObjModelo.SaveChanges()

                    'Select Case fileUp.GetExtension()
                    '    Case ".doc", ".docx"
                    '        strTipoImgToShow = 1
                    '    Case ".pdf"
                    '        strTipoImgToShow = 2
                    '    Case ".jpg", ".gif", ".png"
                    '        strTipoImgToShow = 3
                    '    Case Else
                    '        strTipoImgToShow = 3
                    'End Select

                    'SubMuestraArchivo("FilesUploaded/" & fileUp.FileName, strTipoImgToShow)
                    Me.lblMessage.Text = "Archivo guardado con éxito."

                    vlIntTotalCargados += 1
                    strFileName = fileUp.FileName
                Next

                Dim drNew As DataRow = propDtPagosEnviadosCte.NewRow

                If vlIntTotalCargados = 1 Then
                    drNew("Archivo") = strFileName
                Else
                    drNew("Archivo") = vlIntTotalCargados
                End If

                'drNew("BANCO") = Me.ddlBancos.SelectedItem.Text
                'drNew("CUENTA") = Me.ddlCuentas.SelectedItem.Text
                'drNew("CLIENTE") = "NOMBRE CTE"
                'drNew("USUARIO") = "USUARIO SOLICITUD"
                'drNew("Fecha_carga") = Date.Now
                'drNew("Estatus_carga") = "Cargado"
                'drNew("Estado") = "Enviado"
                'drNew("SALDO_ACTUAL") = 0 'Saldo actual en línea
                'drNew("MONTO_PAGO") = Me.txtMontoPago.Text
                'drNew("NUEVO_SALDO") = 0 + Me.txtMontoPago.Text 'Saldo actual en línea + Me.txtMontoPago.Text 

                'propDtPagosEnviadosCte.Rows.Add(drNew)
                'propDtPagosEnviadosCte.AcceptChanges()

                objPago.NOMBRE_COMPROBANTE = drNew("Archivo")
                vgObjModelo.SaveChanges()

                'MANDO SMS
                'Dim strMsgNuevoDepSMS As String = "PAGO RECIBIDO<br>CUENTA ACCESO:<b> " & Me.vgPropObjUserConnected.USERNAME & "</b><br>Banco: <b>" & Me.ddlBancos.SelectedItem.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>FECHA DEP: <b>" & objPago.FECHA_PAGO_CLIENTE & "</b>"
                Dim strMsgNuevoDepSMS As String = "PAGO RECIBIDO, CUENTA ACCESO: " & Me.vgPropObjUserConnected.USERNAME & ", Cantidad: " & objPago.MONTO_PAGO & ", FECHA DEP: " & objPago.FECHA_PAGO_CLIENTE
                Dim strUrlEnvioMensaje As String = "https://www.smsmasivos.com.mx/sms/api.envio.new.php?"
                strMsgNuevoDepSMS = strMsgNuevoDepSMS.Replace(" ", "%20")
                Dim strNumCel As String = "5544485631"
                Dim strApiKey As String = "94f7dd4b9a9546814fe11b93cc876704aafd6378"
                Dim strCodPais As String = "52"
                Dim strPostString As String = "apikey=" + strApiKey + "&mensaje=" + strMsgNuevoDepSMS + "&numcelular=" + strNumCel + "&numregion=" + strCodPais + ""
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(strPostString)
                Const contentType = "application/x-www-form-urlencoded"
                System.Net.ServicePointManager.Expect100Continue = False

                Dim cookies As Net.CookieContainer = New Net.CookieContainer()

                Try
                    Dim webRequest As Net.HttpWebRequest = Net.HttpWebRequest.Create(strUrlEnvioMensaje)
                    ' WebRequest.Create(urlenviomensaje) as HttpWebRequest
                    webRequest.Method = "POST"
                    webRequest.ContentType = contentType
                    webRequest.CookieContainer = cookies
                    webRequest.ContentLength = byteArray.Length
                    Dim requestWriter As IO.StreamWriter = New IO.StreamWriter(webRequest.GetRequestStream())
                    requestWriter.Write(strPostString)
                    requestWriter.Close()

                    Dim responseReader As IO.StreamReader = New IO.StreamReader(webRequest.GetResponse().GetResponseStream())
                    Dim responseData As String = responseReader.ReadToEnd()
                    mail.EnviaCorreo("RESPUESTA SMS sin HTML: " & responseData, "RESPUESTA DEL ENVÍO DE SMS", False)

                    responseReader.Close()
                    webRequest.GetResponse().Close()
                Catch ex As Exception
                    mail.EnviaCorreo("ERROR AL ENVIAR SMS: " & ex.Message, "ERROR EN EL ENVÍO SMS", False)
                End Try

                'CREO LA TRANSACCION

                'Dim objTrans As New TRANSACCIONES
                'objTrans.FECHA = objPago.FECHA_APLICACION
                'objTrans.FK_CAT_MEDIO_DE_PAGO = 1

                'Me.grdPagosEnviados.DataSource = propDtPagosEnviadosCte
                'Me.grdPagosEnviados.DataBind()

                Me.lblMessage.Text = "Estimado Cliente, su depósito ha sido reportado exitosamente."
                Me.grdPagosEnviados.Dispose()
                Me.grdPagosEnviados.DataBind()

                Try
                    Dim strMsgNuevoDep As String = "Se informa que se ha registrado un depósito enviado por " & Me.vgPropObjUserConnected.USERNAME & " y lo reporta con Banco <b>" & Me.ddlBancos.SelectedItem.Text & "</b> , cuenta <b>" & Me.ddlCuentas.SelectedItem.Text & "</b> por la cantidad de <b>" & objPago.MONTO_PAGO & "</b> con fecha depósito " & objPago.FECHA_PAGO_CLIENTE
                    mail.EnviaCorreo(strMsgNuevoDep, "Favor de validar depósito recibido en " & Me.ddlBancos.SelectedItem.Text, False)

                    If Me.vgPropObjUserConnected.EMAIL <> String.Empty Then
                        mail.EnviaCorreoIndividual("Estimado " & Me.vgPropObjUserConnected.NOMBRE & " " & Me.vgPropObjUserConnected.AP_PATERNO & ", hemos recibido la información de su depósito realizado en <b>" & Me.ddlBancos.SelectedItem.Text & "</b> , cuenta <b>" & Me.ddlCuentas.SelectedItem.Text & "</b> por la cantidad de <b>" & objPago.MONTO_PAGO & "</b> con fecha depósito " & objPago.FECHA_PAGO_CLIENTE, "Depósito recibido para validar [ " & Me.ddlBancos.SelectedItem.Text & " ]", 2, Me.vgPropObjUserConnected.EMAIL)
                    End If

                    If vlIntTotalCargados >= 1 Then
                        Dim objmail As New MailMessage
                        Dim HTMLConImagenes As AlternateView
                        Dim msg As String = "Se informa que se ha registrado un depósito enviado por " & Me.vgPropObjUserConnected.USERNAME & " y lo reporta con Banco <b>" & Me.ddlBancos.SelectedItem.Text & "</b> , cuenta <b>" & Me.ddlCuentas.SelectedItem.Text & "</b> por la cantidad de <b>" & objPago.MONTO_PAGO & "</b> con fecha depósito " & objPago.FECHA_PAGO_CLIENTE

                        HTMLConImagenes = AlternateView.CreateAlternateViewFromString(msg, Nothing, "text/html")

                        Dim model As New EDM_TopItUp

                        For Each f As PAGOS_FILES_UPLOADED In model.PAGOS_FILES_UPLOADED.SqlQuery("SELECT * FROM PAGOS_FILES_UPLOADED WHERE FK_PAGO=" & objPago.PK_PAGO).ToList()
                            Dim FILE As New FILES()
                            FILE = model.FILES.Find(f.FK_FILE)

                            Dim words As String() = FILE.NOMBRE_REAL.Split(New Char() {"\"c})
                            Dim nombreArchivo As String = words(words.Length - 1)
                            Dim rutaserver As String = Server.MapPath(ConfigurationManager.AppSettings("RutaReciboDePago").ToString())

                            strRutaServer = rutaserver & nombreArchivo

                            'Dim imagen As New LinkedResource("C:\inetpub\wwwroot\TopItUp\TopItUp\FilesUploaded\" & FILE.NOMBRE_REAL)
                            Dim imagen As New LinkedResource(strRutaServer)
                            imagen.ContentId = FILE.PK_FILE
                            HTMLConImagenes.LinkedResources.Add(imagen)
                            objmail.AlternateViews.Add(HTMLConImagenes)
                        Next

                        mail.EnviaCorreoIndividual(msg, "Favor de validar depósito recibido en " & Me.ddlBancos.SelectedItem.Text, 2, "depositos@topitup.net", True, objmail)
                    Else
                        mail.EnviaCorreoIndividual("Se informa que se ha registrado un depósito enviado por " & Me.vgPropObjUserConnected.USERNAME & " y lo reporta con Banco <b>" & Me.ddlBancos.SelectedItem.Text & "</b> , cuenta <b>" & Me.ddlCuentas.SelectedItem.Text & "</b> por la cantidad de <b>" & objPago.MONTO_PAGO & "</b> con fecha depósito " & objPago.FECHA_PAGO_CLIENTE, "Favor de validar depósito recibido en " & Me.ddlBancos.SelectedItem.Text, 2, "depositos@topitup.net")
                    End If

                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            Else
                Me.lblMessage.Text = "Favor de adjuntar su comprobante de pago."
                Try
                    If propDtPagosEnviadosCte.Rows.Count > 0 Then
                        Me.grdPagosEnviados.DataSource = propDtPagosEnviadosCte
                        Me.grdPagosEnviados.DataBind()
                    End If
                Catch ex As Exception
                End Try
            End If
        Else

        End If
    End Sub

    Protected Sub btnRechazarDep_Click(sender As Object, e As EventArgs) Handles btnRechazarDep.Click
        'Si hay un registro seleccionado 
        If Me.grdPagosEnviados.SelectedIndex <> -1 Then
            Me.txtMotivoRechazo.Visible = True
            Me.lblMotivoRechazo.Visible = True
            Dim objPago As New PAGOS

            If Trim(Me.txtMotivoRechazo.Text) = String.Empty Then
                Me.lblMessage.Text = "Favor de ingresar el motivo de rechazo."
                Exit Sub
            End If

            objPago = vgObjModelo.PAGOS.Find(grdPagosEnviados.DataKeys(Me.grdPagosEnviados.SelectedIndex).Value)

            'Verifico que el estado de la solicitud sea PENDIENTE, en caso contrario notifico
            If objPago.FK_CAT_STATUS_PAGO = 1 Then
                'Rechaza el pago
                objPago.FK_CAT_STATUS_PAGO = 3
                objPago.MOTIVO_RECHAZO = Me.txtMotivoRechazo.Text
                objPago.FECHA_APLICACION = Date.Now
                vgObjModelo.SaveChanges()
                Me.grdPagosEnviados.Dispose()
                Me.grdPagosEnviados.DataBind()
                Me.lblMessage.Text = "<font color=red>Depósito rechazado correctamente, se notificará al usuario.</font>"

                Dim MAIL As New BACK_CODE.EnviaCorreo
                Try
                    MAIL.EnviaCorreo("Ha sido <font color=red>RECHAZADO</font> un depósito por " & Me.vgPropObjUserConnected.USERNAME & ". <br><br>Datos del RECHAZO: <br>Banco: <b>" & Me.ddlBancos.SelectedItem.Text & "</b><br>Cuenta: <b>" & Me.ddlCuentas.SelectedItem.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>Fecha depósito " & objPago.FECHA_PAGO_CLIENTE & "<br>FECHA DE APLICACIÓN<b>" & objPago.FECHA_APLICACION & "</b><BR>MOTIVO DE RECHAZO:" & objPago.MOTIVO_RECHAZO & "</b>", "Depósito RECHAZADO [ <font color=red>" & objPago.MOTIVO_RECHAZO & "</font> ]", False)
                Catch exX As Exception
                    'Me.lblMessage.Text = exX.Message
                End Try
                Try
                    MAIL.EnviaCorreoIndividual("Ha sido <font color=red>RECHAZADO</font> un depósito por " & Me.vgPropObjUserConnected.USERNAME & ". <br><br>Datos del RECHAZO: <br>Banco: <b>" & Me.ddlBancos.SelectedItem.Text & "</b><br>Cuenta: <b>" & Me.ddlCuentas.SelectedItem.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>Fecha depósito " & objPago.FECHA_PAGO_CLIENTE & "<br>FECHA DE APLICACIÓN<b>" & objPago.FECHA_APLICACION & "</b><BR>MOTIVO DE RECHAZO:" & objPago.MOTIVO_RECHAZO & "</b>", "Depósito RECHAZADO [ <font color=red>" & objPago.MOTIVO_RECHAZO & "</font> ]", 2, "depositos@topitup.net")
                Catch ex As Exception
                End Try

                Dim usrDeposito As New USERS
                Dim modelo As New EDM_TopItUp

                Try
                    MAIL.EnviaCorreoIndividual("Ha sido <font color=red>RECHAZADO</font> un depósito por " & Me.vgPropObjUserConnected.USERNAME & ". <br><br>Datos del RECHAZO: <br>Banco: <b>" & Me.ddlBancos.SelectedItem.Text & "</b><br>Cuenta: <b>" & Me.ddlCuentas.SelectedItem.Text & "</b><br>Cantidad: <b>" & objPago.MONTO_PAGO & "</b><br>Fecha depósito " & objPago.FECHA_PAGO_CLIENTE & "<br>FECHA DE APLICACIÓN<b>" & objPago.FECHA_APLICACION & "</b><BR>MOTIVO DE RECHAZO:" & objPago.MOTIVO_RECHAZO & "</b>", "Depósito RECHAZADO [ <font color=red>" & objPago.MOTIVO_RECHAZO & "</font> ]", 2, modelo.USERS.Find(objPago.FK_USER).EMAIL)
                Catch ex As Exception
                End Try

            Else
                'Sino es PENDIENTE notifico
                Me.lblMessage.Text = "Estimado usuario, la solicitud seleccionada ya fue revisada con anterioridad."
            End If
        Else
            Me.lblMessage.Visible = True
            Me.lblMessage.Text = "Para poder rechazar un registro primero deberá seleccionarlo."
        End If
    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim rutaArchivo As String
        Dim rutas As Util_URL = Util_URL.getInstance()
        Dim newURL As New Util_ArmaURL()
        Dim resultReporte1 = vgObjModelo.sp_GetDepositos(Me.vgPropIntCveUserConnected).ToList()
        rutaArchivo = resultReporte1.ExportaExcel("Depositos")

        newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
        newURL.AddParameter("rutaArchivo", rutaArchivo)
        newURL.AddParameter("nombreArchivo", "Depositos.xlsx")
        Response.Redirect(newURL.GetURL)
    End Sub

    Protected Sub btnModoAddDeps_Click(sender As Object, e As EventArgs) Handles btnModoAddDeps.Click
        Session("vgBlnNewEditMode") = True
        Response.Redirect("Deps.aspx")
    End Sub

    Protected Sub btnModoVoBoDeps_Click(sender As Object, e As EventArgs) Handles btnModoVoBoDeps.Click
        Session("vgBlnNewEditMode") = False
        Response.Redirect("Deps.aspx")
    End Sub

End Class