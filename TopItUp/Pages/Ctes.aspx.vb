Imports System.Net
Imports BACK_CODE
Imports TopItUp.Helpers

Public Class Ctes
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
            Me.tblOpcion1.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
            Me.lblFechaSaldo.Text = Date.Now.Date
            Me.lblFechaSaldo.Visible = True

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

                ' tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenuOtras.jpg);background-size: cover;")
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
            Try
                Me.lblUsrConnected.Text = Me.vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

                sub_FillCtes()
                'Si es super admin muestro el combo en lugar de la caja del cliente
                If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then

                    Me.ddlCtes.Visible = True
                    Me.txtNombreCteNivelSuperior.Visible = False
                End If

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"
        End If

        If Not IsPostBack Then
            llenaServicios()
            Dim objModel As New EDM_TopItUp
            Me.txtNombreCteNivelSuperior.Text = Me.vgPropObjCteConnected.NOMBRE
            For Each razon As CAT_RAZONES_SOCIALES In vgObjModelo.CAT_RAZONES_SOCIALES.ToList()
                Dim li As New ListItem(razon.NOMBRE_CORTO, razon.PK_CAT_RAZON_SOCIAL)
                Me.ddlCatRazonSocial.Items.Add(li)
            Next
        End If

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        If Not IsPostBack Then
            Sub_FillComisionesCte()
        End If

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(Me.vgPropIntCveUserConnected)
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

    Private Sub Sub_FillComisionesCte()
        'Carga las comisiones que tiene actualmente el cliente
        Dim vlIntPkCte As Integer = Me.vgPropObjCteConnected.PK_CLIENTE

        If Me.ddlCtes.Visible = True Then
            vlIntPkCte = Me.ddlCtes.SelectedValue
        End If

        For Each telCte As TELEFONIAS_CLIENTES In vgObjModelo.TELEFONIAS_CLIENTES.SqlQuery("SELECT * FROM TELEFONIAS_CLIENTES WHERE FK_CLIENTE=" & vlIntPkCte)

            If telCte.FK_CAT_TELEFONIA = 1 Then
                Me.lblComMaxTelcel.Text = telCte.COMISION_TEL_CTE
                Me.txtComTelcel.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 2 Then
                Me.lblComMaxMovi.Text = telCte.COMISION_TEL_CTE
                Me.txtComMovi.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 3 Then
                Me.lblComMaxIusa.Text = telCte.COMISION_TEL_CTE
                Me.txtComIusa.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 4 Then
                Me.lblComMaxUnefon.Text = telCte.COMISION_TEL_CTE
                Me.txtComUnefon.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 5 Then
                Me.lblComMaxNextel.Text = telCte.COMISION_TEL_CTE
                Me.txtComNextel.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 6 Then
                Me.lblcomvirgin.Text = telCte.COMISION_TEL_CTE
                Me.txtcomvirgin.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 7 Then
                Me.lblcomcierto.Text = telCte.COMISION_TEL_CTE
                Me.txtcomcierto.Text = telCte.COMISION_TEL_CTE
            End If

            If telCte.FK_CAT_TELEFONIA = 8 Then
                Me.lblcommaztiempo.Text = telCte.COMISION_TEL_CTE
                Me.txtcommaztiempo.Text = telCte.COMISION_TEL_CTE
            End If

        Next

        If Me.lblComMaxTelcel.Text = String.Empty Then
            Me.lblComMaxTelcel.Text = "0.00"
        End If

        If Me.lblComMaxMovi.Text = String.Empty Then
            Me.lblComMaxMovi.Text = "0.00"
        End If

        If Me.lblComMaxIusa.Text = String.Empty Then
            Me.lblComMaxIusa.Text = "0.00"
        End If

        If Me.lblComMaxUnefon.Text = String.Empty Then
            Me.lblComMaxUnefon.Text = "0.00"
        End If

        If Me.lblComMaxNextel.Text = String.Empty Then
            Me.lblComMaxNextel.Text = "0.00"
        End If

        If String.IsNullOrWhiteSpace(lblcomvirgin.Text) Then
            Me.lblcomvirgin.Text = "0.00"
        End If

        If String.IsNullOrWhiteSpace(lblcomcierto.Text) Then
            Me.lblcomcierto.Text = "0.00"
        End If

        If String.IsNullOrWhiteSpace(lblcommaztiempo.Text) Then
            Me.lblcommaztiempo.Text = "0.00"
        End If

    End Sub

    Private Sub sub_FillCtes()

        Dim liSeleccione As New ListItem
        liSeleccione.Text = "Seleccione"
        liSeleccione.Value = -1
        Me.ddlCtes.Items.Add(liSeleccione)
        Dim g As New clsGenerics

        Dim ctes = vgObjModelo.CLIENTES.Where(Function(x) x.STATUS = 1).ToList().OrderBy(Function(x) x.NOMBRE).ToList()

        'If Not vgPropIntCveUserConnected = 1 Then
        '    ctes = ctes.Where(Function(x) x.FK_CLIENTE_PADRE = vgPropIntCveCteConnected).ToList()
        'End If

        For Each cte As CLIENTES In ctes
            Dim li As New ListItem
            Try
                li.Text = cte.NOMBRE '& " [ " & g.func_GetUsrConnected(g.func_GetUserByCliente(cte.PK_CLIENTE)).USERNAME & " ]"
            Catch ex As Exception
                li.Text = cte.NOMBRE
            End Try
            li.Value = cte.PK_CLIENTE
            Me.ddlCtes.Items.Add(li)
        Next

        ddlCtes.DataBind()
        If Not vgPropIntCveCteConnected = 1 Then
            ddlCtes.SelectedValue = vgPropIntCveCteConnected
        End If
    End Sub

    Protected Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        'Me.txtRFC.Text = txtRFC.Text.ToUpper
    End Sub

    Private Function func_validaCliente() As Boolean
        Dim blnCorrecto As Boolean = True
        Me.lblMessage.Text = "Favor de ingresar y validar:<ol>"

        If Trim(Me.txtNombre.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Cliente.</li>"
            blnCorrecto = False
        End If

        If ddlCtes.Visible = True Then
            If Me.ddlCtes.SelectedValue = -1 Then
                Me.lblMessage.Text &= "<li>Nivel Superior.</li>"
                blnCorrecto = False
            End If
        End If

        If Trim(Me.txtDireccionCompeta.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Dirección completa.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtUserAsignado.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Usuario de acceso asignado.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtRFC.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>RFC.</li>"
            blnCorrecto = False
        End If

        'If Me.chkTelcel.Checked = False And Me.chkMovi.Checked = False And Me.chkIusa.Checked = False And Me.chkNextel.Checked = False And Me.chkUnefon.Checked = False Then
        '    Me.lblMessage.Text &= "<li>Al menos una compañía para el nuevo cliente.</li>"
        '    blnCorrecto = False
        'End If

        '/***************** VALIDA TELCEL *****************/
        If Me.chkTelcel.Checked = True And (Trim(txtComTelcel.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Telcel.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkTelcel.Checked = True And (Trim(txtComTelcel.Text) <> String.Empty And CDec(txtComTelcel.Text) > CDec(Me.lblComMaxTelcel.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Telcel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkTelcel.Checked = True And Trim(txtComTelcel.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Telcel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA MOVISTAR *****************/
        If Me.chkMovi.Checked = True And (Trim(txtComMovi.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Movistar.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkMovi.Checked = True And (Trim(txtComMovi.Text) <> String.Empty And CDec(txtComMovi.Text) > CDec(Me.lblComMaxMovi.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Movistar no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkMovi.Checked = True And Trim(txtComMovi.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Movistar no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Unefon *****************/
        If Me.chkUnefon.Checked = True And (Trim(txtComUnefon.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Unefon.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkUnefon.Checked = True And (Trim(txtComUnefon.Text) <> String.Empty And CDec(txtComUnefon.Text) > CDec(Me.lblComMaxUnefon.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Unefon no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkUnefon.Checked = True And Trim(txtComUnefon.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Unefon no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Iusacell *****************/
        If Me.chkIusa.Checked = True And (Trim(txtComIusa.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Iusacell.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkIusa.Checked = True And (Trim(txtComIusa.Text) <> String.Empty And CDec(txtComIusa.Text) > CDec(Me.lblComMaxIusa.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Iusacell no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkIusa.Checked = True And Trim(txtComIusa.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Iusacell no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Nextel *****************/

        If Me.chkNextel.Checked = True And (Trim(txtComNextel.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Nextel.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkNextel.Checked = True And (Trim(txtComNextel.Text) <> String.Empty And CDec(txtComNextel.Text) > CDec(Me.lblComMaxNextel.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Nextel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkNextel.Checked = True And Trim(txtComNextel.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Nextel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        If Trim(Me.txtTelefonoContacto.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Teléfono de contacto.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtPsw.Text) = String.Empty Or Trim(Me.txtPswConfirm.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Contraseña y favor de confirmarla.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtPsw.Text) <> String.Empty And Trim(Me.txtPswConfirm.Text) <> String.Empty Then
            If Trim(Me.txtPsw.Text) <> Trim(Me.txtPswConfirm.Text) Then
                Me.lblMessage.Text &= "<li>Contraseña no coincide.</li>"
                blnCorrecto = False
            End If
        End If

        If Trim(Me.txtTelefonoContacto.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Teléfono de contacto.</li>"
            blnCorrecto = False
        End If

        Dim objGeneric = New clsGenerics
        If objGeneric.func_ExisteUserName(Trim(Me.txtUserAsignado.Text)) = True Then
            Me.lblMessage.Text &= "<li>El usuario capturado no se puede utilizar, favor de cambiarlo.</li>"
            blnCorrecto = False
        End If

        Me.lblMessage.Text &= "</ol>"

        If blnCorrecto Then
            lblMessage.Text = ""
        End If

        Return blnCorrecto
    End Function
    Private Sub sub_LimpiaCampos()
        Me.txtNombre.Text = String.Empty
        Me.txtDireccionCompeta.Text = String.Empty
        Me.txtUserAsignado.Text = String.Empty
        Me.txtRFC.Text = String.Empty
        Me.txtTelefonoContacto.Text = String.Empty
        Me.txtPsw.Text = String.Empty
        Me.txtPswConfirm.Text = String.Empty
    End Sub
    Protected Sub chkTelcel_CheckedChanged(sender As Object, e As EventArgs) Handles chkTelcel.CheckedChanged
        Me.txtComTelcel.Enabled = chkTelcel.Checked
        Me.txtComTelcel.Text = Me.lblComMaxTelcel.Text
    End Sub
    Protected Sub chkMovi_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovi.CheckedChanged
        Me.txtComMovi.Enabled = chkMovi.Checked
        Me.txtComMovi.Text = Me.lblComMaxMovi.Text
    End Sub
    Protected Sub chkIusa_CheckedChanged(sender As Object, e As EventArgs) Handles chkIusa.CheckedChanged
        Me.txtComIusa.Enabled = chkIusa.Checked
        Me.txtComIusa.Text = Me.lblComMaxIusa.Text
    End Sub
    Protected Sub chkNextel_CheckedChanged(sender As Object, e As EventArgs) Handles chkNextel.CheckedChanged
        Me.txtComNextel.Enabled = chkNextel.Checked
        Me.txtComNextel.Text = Me.lblComMaxNextel.Text
    End Sub
    Protected Sub chkUnefon_CheckedChanged(sender As Object, e As EventArgs) Handles chkUnefon.CheckedChanged
        Me.txtComUnefon.Enabled = chkUnefon.Checked
        Me.txtComUnefon.Text = Me.lblComMaxUnefon.Text
    End Sub

    Protected Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        Me.chkTelcel.Checked = chkAll.Checked
        Me.chkMovi.Checked = chkAll.Checked
        Me.chkIusa.Checked = chkAll.Checked
        Me.chkNextel.Checked = chkAll.Checked
        Me.chkUnefon.Checked = chkAll.Checked
        Me.cboxvirgin.Checked = chkAll.Checked
        Me.cboxcierto.Checked = chkAll.Checked
        Me.cboxmaztiempo.Checked = chkAll.Checked

        Me.txtComTelcel.Enabled = chkTelcel.Checked
        Me.txtComMovi.Enabled = chkMovi.Checked
        Me.txtComIusa.Enabled = chkIusa.Checked
        Me.txtComNextel.Enabled = chkNextel.Checked
        Me.txtComUnefon.Enabled = chkUnefon.Checked
        Me.txtcomvirgin.Enabled = cboxvirgin.Checked
        Me.txtcomcierto.Enabled = cboxcierto.Checked
        Me.txtcommaztiempo.Enabled = cboxmaztiempo.Checked

    End Sub

    Protected Sub ddlCtes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCtes.SelectedIndexChanged
        'Cargas las comisiones del cliente seleccionado
        If Me.ddlCtes.SelectedItem.Value = "-1" Then
            Me.lblComMaxTelcel.Text = "0.00"
            Me.lblComMaxMovi.Text = "0.00"
            Me.lblComMaxIusa.Text = "0.00"
            Me.lblComMaxUnefon.Text = "0.00"
            Me.lblComMaxNextel.Text = "0.00"
        Else
            Sub_FillComisionesCte()
        End If
    End Sub

    Protected Sub btnActivarCte_Click(sender As Object, e As EventArgs) Handles btnActivarCte.Click
        Try

            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "red")
        Dim blnCorrecto As Boolean = True
        Me.lblMessage.Text = "Favor de ingresar y validar:<ol>"

        If Trim(Me.txtNombre.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Cliente.</li>"
            blnCorrecto = False
        End If

        If ddlCtes.Visible = True Then
            If Me.ddlCtes.SelectedValue = -1 Then
                Me.lblMessage.Text &= "<li>Nivel Superior.</li>"
                blnCorrecto = False
            End If
        End If

        If Trim(Me.txtDireccionCompeta.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Dirección completa.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtUserAsignado.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Usuario de acceso asignado.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtRFC.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>RFC.</li>"
            blnCorrecto = False
        End If

        'If Me.chkTelcel.Checked = False And Me.chkMovi.Checked = False And Me.chkIusa.Checked = False And Me.chkNextel.Checked = False And Me.chkUnefon.Checked = False Then
        '    Me.lblMessage.Text &= "<li>Al menos una compañía para el nuevo cliente.</li>"
        '    blnCorrecto = False
        'End If

        '/***************** VALIDA TELCEL *****************/
        If Me.chkTelcel.Checked = True And (Trim(txtComTelcel.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Telcel.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkTelcel.Checked = True And (Trim(txtComTelcel.Text) <> String.Empty And CDec(txtComTelcel.Text) > CDec(Me.lblComMaxTelcel.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Telcel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkTelcel.Checked = True And Trim(txtComTelcel.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Telcel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA MOVISTAR *****************/
        If Me.chkMovi.Checked = True And (Trim(txtComMovi.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Movistar.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkMovi.Checked = True And (Trim(txtComMovi.Text) <> String.Empty And CDec(txtComMovi.Text) > CDec(Me.lblComMaxMovi.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Movistar no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkMovi.Checked = True And Trim(txtComMovi.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Movistar no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Unefon *****************/
        If Me.chkUnefon.Checked = True And (Trim(txtComUnefon.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Unefon.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkUnefon.Checked = True And (Trim(txtComUnefon.Text) <> String.Empty And CDec(txtComUnefon.Text) > CDec(Me.lblComMaxUnefon.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Unefon no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkUnefon.Checked = True And Trim(txtComUnefon.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Unefon no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Iusacell *****************/
        If Me.chkIusa.Checked = True And (Trim(txtComIusa.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Iusacell.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkIusa.Checked = True And (Trim(txtComIusa.Text) <> String.Empty And CDec(txtComIusa.Text) > CDec(Me.lblComMaxIusa.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Iusacell no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkIusa.Checked = True And Trim(txtComIusa.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Iusacell no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        '/***************** VALIDA Nextel *****************/

        If Me.chkNextel.Checked = True And (Trim(txtComNextel.Text) = String.Empty) Then
            Me.lblMessage.Text &= "<li>Comisión de Nextel.</li>"
            blnCorrecto = False
        End If

        Try
            If Me.chkNextel.Checked = True And (Trim(txtComNextel.Text) <> String.Empty And CDec(txtComNextel.Text) > CDec(Me.lblComMaxNextel.Text)) Then
                Me.lblMessage.Text &= "<li>La comisión de Nextel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        Catch ex As Exception
            If Me.chkNextel.Checked = True And Trim(txtComNextel.Text) <> String.Empty Then
                Me.lblMessage.Text &= "<li>La comisión de Nextel no puede ser mayor a la comisión que usted tiene.</li>"
                blnCorrecto = False
            End If
        End Try

        If Trim(Me.txtTelefonoContacto.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Teléfono de contacto.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtPsw.Text) = String.Empty Or Trim(Me.txtPswConfirm.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Contraseña y favor de confirmarla.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtPsw.Text) <> String.Empty And Trim(Me.txtPswConfirm.Text) <> String.Empty Then
            If Trim(Me.txtPsw.Text) <> Trim(Me.txtPswConfirm.Text) Then
                Me.lblMessage.Text &= "<li>Contraseña no coincide.</li>"
                blnCorrecto = False
            End If
        End If

        If Trim(Me.txtTelefonoContacto.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Teléfono de contacto.</li>"
            blnCorrecto = False
        End If

        Dim objGeneric = New clsGenerics
        If objGeneric.func_ExisteUserName(Trim(Me.txtUserAsignado.Text)) = True Then
            Me.lblMessage.Text &= "<li>El usuario capturado no se puede utilizar, favor de cambiarlo.</li>"
            blnCorrecto = False
        End If

        Me.lblMessage.Text &= "</ol>"

        If blnCorrecto Then
            lblMessage.Text = ""
        End If


            If objGeneric.func_ExisteUserNameEliminado(Trim(Me.txtUserAsignado.Text)) = True Then
                Dim usuario = vgObjModelo.USERS.Where(Function(x) x.USERNAME = Trim(txtUserAsignado.Text)).FirstOrDefault()
                usuario.STATUS = 1
                usuario.PASSWORD = BACK_CODE.Cripto.regresaHash("123456")
                Dim cteuser = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_USER = usuario.PK_USER).FirstOrDefault().FK_CLIENTE
                Dim cte = vgObjModelo.CLIENTES.Find(cteuser)
                cte.STATUS = 1
                vgObjModelo.SaveChanges()
                blnCorrecto = False
                Me.lblMessage.Style.Remove("color")
                Me.lblMessage.Style.Add("color", "green")
                lblMessage.Text = "El cliente fue habilitado nuevamente ya que existia anteriormente el nombre de usuario password nuevo: 123456"
            End If

        If blnCorrecto Then
            Try
                Dim objCte As New CLIENTES
                Dim objUsr As New USERS
                Dim objCteUsr As New CLIENTES_USERS
                Dim objTelCte As New TELEFONIAS_CLIENTES
                Dim obtServUsers As New SERVICIOS_CLIENTE_REL

                    Dim clientepadre As Integer = Convert.ToInt32(Me.ddlCtes.SelectedValue)
                    'Dim clientepadre As Integer = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_USER = userseleccionado).FirstOrDefault().FK_CLIENTE()

                'Creo CLIENTE
                objCte.NOMBRE = Trim(Me.txtNombre.Text)
                objCte.DIRECCION_COMPLETA = Me.txtDireccionCompeta.Text
                objCte.RFC = Me.txtRFC.Text
                objCte.TELEFONO_CONTACTO = Me.txtTelefonoContacto.Text
                'Es super Admin
                If Me.ddlCtes.Visible = True Then
                        objCte.FK_CLIENTE_PADRE = clientepadre
                Else
                    objCte.FK_CLIENTE_PADRE = CType(Session("CTE_CONNECTED"), Integer)
                End If

                objCte.FK_EMPRESA = 1 'Distribuidores
                objCte.FK_CAT_RAZON_SOCIAL = Me.ddlCatRazonSocial.SelectedItem.Value
                objCte.STATUS = 1
                vgObjModelo.CLIENTES.Add(objCte)
                Try
                    vgObjModelo.SaveChanges()
                Catch ex As Exception
                    Dim correo As New BACK_CODE.EnviaCorreo
                    Me.lblMessage.Text = "Error al crear cliente <b>" & objCte.NOMBRE & "</b> [ " & Me.txtUserAsignado.Text & " ] " & ex.Message

                    Try
                        correo.EnviaCorreo(Me.lblMessage.Text, "Error al intentar crear cliente", True)
                    Catch exm As Exception
                        Me.lblMessage.Text = "Error al mandar correo: " & exm.Message
                    End Try
                    Exit Sub
                End Try

                'Creo USER
                objUsr.AP_PATERNO = " "
                objUsr.AP_MATERNO = ""
                objUsr.NOMBRE = Me.txtNombre.Text
                objUsr.STATUS = 1  'Para que cambie su contraseña en su primer acceso
                objUsr.EMAIL = Me.txtCorreoElec.Text
                objUsr.USERNAME = Trim(Me.txtUserAsignado.Text)
                objUsr.PASSWORD = BACK_CODE.Cripto.regresaHash(Me.txtPsw.Text.Trim()) 'Me.txtPsw.Text
                objUsr.FK_ACCESS_GROUP = 2 'Distribuidor
                vgObjModelo = New EDM_TopItUp
                vgObjModelo.USERS.Add(objUsr)
                Try
                    vgObjModelo.SaveChanges()
                Catch ex As Exception
                    Dim correo As New BACK_CODE.EnviaCorreo
                    Me.lblMessage.Text = "Error al crear usuario <b>" & objCte.NOMBRE & "</b> [ " & objUsr.USERNAME & " ] " & ex.Message

                    Try
                        correo.EnviaCorreo(Me.lblMessage.Text, "Error al intentar crear usuario", True)
                    Catch exm As Exception
                        Me.lblMessage.Text = "Error al mandar correo: " & exm.Message
                    End Try
                    Exit Sub
                End Try

                'Asocio CLIENTE al USER
                objCteUsr.FK_CLIENTE = objCte.PK_CLIENTE
                objCteUsr.FK_USER = objUsr.PK_USER
                vgObjModelo.CLIENTES_USERS.Add(objCteUsr)
                Try
                    vgObjModelo.SaveChanges()
                Catch ex As Exception
                    Dim correo As New BACK_CODE.EnviaCorreo
                    Me.lblMessage.Text = "Error al crear relación cliente - usuario <b>" & objCte.NOMBRE & "</b> [ " & objUsr.USERNAME & " ] " & ex.Message

                    Try
                        correo.EnviaCorreo(Me.lblMessage.Text, "Error al intentar crear relación cliente - usuario", True)
                    Catch exm As Exception
                        Me.lblMessage.Text = "Error al mandar correo: " & exm.Message
                    End Try
                    Exit Sub
                End Try

                'Registro las comisiones por telefonía que tendrá el cliente

                'TELCEL
                objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                objTelCte.FK_CAT_TELEFONIA = 1
                Try
                    If Me.txtComTelcel.Enabled = True Then
                        objTelCte.COMISION_TEL_CTE = CDec(Me.txtComTelcel.Text)
                    Else
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End If
                Catch ex As Exception
                    objTelCte.COMISION_TEL_CTE = CDec(0)
                End Try
                vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                vgObjModelo.SaveChanges()

                'MOVISTAR
                objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                objTelCte.FK_CAT_TELEFONIA = 2
                Try
                    If Me.txtComMovi.Enabled = True Then
                        objTelCte.COMISION_TEL_CTE = CDec(Me.txtComMovi.Text)
                    Else
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End If
                Catch ex As Exception
                    objTelCte.COMISION_TEL_CTE = CDec(0)
                End Try

                vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                vgObjModelo.SaveChanges()

                'IUSACELL
                objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                objTelCte.FK_CAT_TELEFONIA = 3
                Try
                    If Me.txtComIusa.Enabled = True Then
                        objTelCte.COMISION_TEL_CTE = CDec(Me.txtComIusa.Text)
                    Else
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End If
                Catch ex As Exception
                    objTelCte.COMISION_TEL_CTE = CDec(0)
                End Try
                vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                vgObjModelo.SaveChanges()

                'UNEFON
                objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                objTelCte.FK_CAT_TELEFONIA = 4
                Try
                    If Me.txtComUnefon.Enabled = True Then
                        objTelCte.COMISION_TEL_CTE = CDec(Me.txtComUnefon.Text)
                    Else
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End If
                Catch ex As Exception
                    objTelCte.COMISION_TEL_CTE = CDec(0)
                End Try
                vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                vgObjModelo.SaveChanges()

                'NEXTEL
                objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                objTelCte.FK_CAT_TELEFONIA = 5
                Try
                    If Me.txtComNextel.Enabled = True Then
                        objTelCte.COMISION_TEL_CTE = CDec(Me.txtComNextel.Text)
                    Else
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End If
                Catch ex As Exception
                    objTelCte.COMISION_TEL_CTE = CDec(0)
                End Try
                vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                    vgObjModelo.SaveChanges()


                    'VIRGIN 
                    objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                    objTelCte.FK_CAT_TELEFONIA = 6
                    Try
                        If Me.txtComNextel.Enabled = True Then
                            objTelCte.COMISION_TEL_CTE = CDec(Me.txtcomvirgin.Text)
                        Else
                            objTelCte.COMISION_TEL_CTE = CDec(0)
                        End If
                    Catch ex As Exception
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End Try
                    vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                    vgObjModelo.SaveChanges()

                    'CIERTO 
                    objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                    objTelCte.FK_CAT_TELEFONIA = 7
                    Try
                        If Me.txtComNextel.Enabled = True Then
                            objTelCte.COMISION_TEL_CTE = CDec(Me.txtcomcierto.Text)
                        Else
                            objTelCte.COMISION_TEL_CTE = CDec(0)
                        End If
                    Catch ex As Exception
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End Try
                    vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                    vgObjModelo.SaveChanges()

                    'CIERTO 
                    objTelCte.FK_CLIENTE = objCte.PK_CLIENTE
                    objTelCte.FK_CAT_TELEFONIA = 8
                    Try
                        If Me.txtComNextel.Enabled = True Then
                            objTelCte.COMISION_TEL_CTE = CDec(Me.txtcommaztiempo.Text)
                        Else
                            objTelCte.COMISION_TEL_CTE = CDec(0)
                        End If
                    Catch ex As Exception
                        objTelCte.COMISION_TEL_CTE = CDec(0)
                    End Try
                    vgObjModelo.TELEFONIAS_CLIENTES.Add(objTelCte)
                    vgObjModelo.SaveChanges()


                Dim passtemp As String = Me.txtPsw.Text.Trim()
                sub_LimpiaCampos()
                Dim strCtePadre As String
                Try
                    strCtePadre = vgObjModelo.CLIENTES.Find(objCte.FK_CLIENTE_PADRE).NOMBRE
                Catch ex As Exception
                    strCtePadre = ""
                End Try


                ' servicios clientes 

                'If Me.CheckBox2.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 1
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                'If Me.CheckBox3.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 2
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                'If Me.CheckBox4.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 3
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                'If Me.CheckBox5.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 4
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                'If Me.CheckBox6.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 5
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                'If Me.CheckBox7.Checked Then

                '    obtServUsers = New SERVICIOS_CLIENTE_REL()
                '    obtServUsers.COMISION = 0
                '    obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                '    obtServUsers.FK_CLIENTE = 6
                '    vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                '    vgObjModelo.SaveChanges()

                'End If

                    For Each row As GridViewRow In GridView1.Rows

                        If DirectCast(row.FindControl("cboxservicio"), CheckBox).Checked Then
                            Dim idservicio As Integer = DirectCast(GridView1.DataKeys(row.RowIndex)("PK_CAT_SERVICIO"), Integer)
                            obtServUsers = New SERVICIOS_CLIENTE_REL()
                            obtServUsers.COMISION = 0
                            obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                            obtServUsers.FK_SERVICIO = idservicio
                            vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                            vgObjModelo.SaveChanges()
                        End If
                    Next

                    'For Each c As Control In Me.Panel1.Controls
                    '        Try
                    '            If TypeOf c Is CheckBox Then
                    '                If Not c.ID.ToString() = "cboxCheckAll" Then
                    '                    Dim n As CheckBox = DirectCast(c, CheckBox)
                    '                    Dim id As String = c.ID.ToString().Replace("CheckBox", "")
                    '                    If Not id.Equals("1") Then
                    '                        If n.Checked Then
                    '                            obtServUsers = New SERVICIOS_CLIENTE_REL()
                    '                            obtServUsers.COMISION = 0
                    '                            obtServUsers.FK_CLIENTE = objCte.PK_CLIENTE
                    '                            obtServUsers.FK_SERVICIO = Convert.ToInt32(id) ' + 1
                    '                            vgObjModelo.SERVICIOS_CLIENTE_REL.Add(obtServUsers)
                    '                            vgObjModelo.SaveChanges()
                    '                        End If
                    '                    End If
                    '                End If
                    '            End If
                    '        Catch ex As Exception

                    '        End Try
                    'Next
                    Me.lblMessage.Style.Remove("color")
                    Me.lblMessage.Style.Add("color", "green")
                Me.lblMessage.Text = "<html><body>Información guardada exitosamente, el nuevo cliente podra entrar con la cuenta asignada <b>" & objUsr.USERNAME & "</b> y contraseña " & "<b>" & passtemp & "</b><br><b>AVISO</b>: Se recomienda informarle que puede cambiar cambiar su contraseña en la opción de menú en su primer acceso.</body></html>"

                Dim strClientePadre As String = String.Empty
                If Me.ddlCtes.Visible = True Then
                    strClientePadre = ", Cliente superior: <b>" & Me.ddlCtes.SelectedItem.Text & "</b>"
                End If

                Dim mail As New BACK_CODE.EnviaCorreo()
                Try
                    mail.EnviaCorreo(Me.lblMessage.Text & strClientePadre, "Nuevo Cliente :: " & objCte.NOMBRE, False)
                    If Not String.IsNullOrEmpty(Trim(Me.txtCorreoElec.Text)) Then
                        mail.EnviaCorreoIndividual("<html><body>Estimado usuario, se proporcionan sus datos de acceso. <br><br>USUARIO: " & objUsr.USERNAME & " <BR>CONTRASEÑA: <b>" & passtemp & "</b> <br><b>AVISO</b>: Por motivos de seguridad se recomienda que cambie su contraseña en su primer acceso en la opción del menú.</body></html>", "Nuevo Cliente :: " & objCte.NOMBRE, 3, Me.txtCorreoElec.Text)
                    End If

                    mail.EnviaCorreo(Me.lblMessage.Text & strClientePadre, "Nuevo Cliente :: " & objCte.NOMBRE, "atencion.clientes@topitup.net")

                Catch ex As Mail.SmtpException
                    Me.lblMessage.Text &= " ** " & ex.Message
                End Try
            Catch exGlobal As Exception
                Try
                    vgObjModelo.SaveChanges()
                Catch exTrans As Exception
                    Dim correo As New BACK_CODE.EnviaCorreo
                    Me.lblMessage.Text = "Error en alguna parte de crear cliente <b>" & Me.txtNombre.Text & "</b> [ " & Me.txtUserAsignado.Text & " ] " & exTrans.Message

                    Try
                        correo.EnviaCorreo(Me.lblMessage.Text, "Error al intentar crear relación cliente - usuario", True)
                    Catch exm As Exception
                        Me.lblMessage.Text = "Error al mandar correo: " & exm.Message
                    End Try
                    Exit Sub
                End Try
            End Try
            End If
        Catch ex As Exception
            Dim mail As New EnviaCorreo()
            mail.EnviaCorreo(ex.Message, "ERROR AL CREAR CLIENTE USUARIO CONECTADO: " + vgPropObjUserConnected.PK_USER.ToString(), True)
        End Try
    End Sub

    Protected Sub btnViewGridUsersByCliente_Click(sender As Object, e As EventArgs) Handles btnViewGridUsersByCliente.Click
        Response.Redirect("CtesConsulta.aspx")
    End Sub

    Protected Sub btnViewGridUsersByCliente0_Click(sender As Object, e As EventArgs) Handles btnViewGridUsersByCliente0.Click
        Me.tblOpcion1.Visible = True
    End Sub

    Protected Sub txtCorreoElec_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub cboxCheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles cboxCheckAll.CheckedChanged
    '    Try
    '        Dim estado As Boolean = cboxCheckAll.Checked

    '        CheckBox2.Checked = estado
    '        CheckBox3.Checked = estado
    '        CheckBox4.Checked = estado
    '        CheckBox5.Checked = estado
    '        CheckBox6.Checked = estado
    '        CheckBox7.Checked = estado
    '        CheckBox8.Checked = estado
    '        CheckBox9.Checked = estado
    '        CheckBox10.Checked = estado
    '        CheckBox11.Checked = estado
    '        CheckBox12.Checked = estado
    '        CheckBox13.Checked = estado
    '        CheckBox14.Checked = estado
    '        CheckBox15.Checked = estado
    '        CheckBox16.Checked = estado
    '        CheckBox16.Checked = estado
    '        CheckBox17.Checked = estado
    '        CheckBox18.Checked = estado


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub llenaServicios()
        Try
            Using ef As New TopItUp.EDM_TopItUp()
                Dim datos = ef.CAT_SERVICIOS.ToList()
                GridView1.DataSource = datos
                GridView1.DataBind()
            End Using
        Catch ex As Exception

        End Try
    End Sub

   
End Class