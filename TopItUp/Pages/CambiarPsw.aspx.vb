Imports System.Net

Public Class CambiarPsw
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp
    Dim vgPkCliente As Integer = -1
    Dim clsGeneric As New clsGenerics

    Private Property vgPropObjUser As USERS
        Set(value As USERS)
            Session("USR") = value
        End Set
        Get
            Return CType(Session("USR"), USERS)
        End Get
    End Property

    Private Property vgObjUser As USERS
        Get
            Return Session("USR")
        End Get
        Set(value As USERS)
            Session("USR") = value
        End Set
    End Property

    Private Property propVgObjCliente As CLIENTES
        Set(value As CLIENTES)
            Session("propVgObjCliente") = value
        End Set
        Get
            Return CType(Session("propVgObjCliente"), CLIENTES)
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

    Private Property vgPropIntIntentosFallaDesbloquear As Integer
        Set(value As Integer)
            Session("vgPropIntIntentosFallaDesbloquear") = value
        End Set
        Get
            Return Session("vgPropIntIntentosFallaDesbloquear")
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

        If Not IsPostBack Then
            lblMessage.Style.Remove("color")
            lblMessage.Style.Add("color", "green")

            If vgObjUser.FK_ACCESS_GROUP = 1 Then
                filaBanco.Visible = True
            Else
                filaBanco.Visible = False
            End If

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
            Me.lblFechaSaldo.Text = Date.Now.Date
            Me.lblFechaSaldo.Visible = True

            vgPropIntIntentosFallaDesbloquear = 0
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
            Dim clsGeneric As New clsGenerics
            Dim objUser As New USERS

            Try
                objUser = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))
                vgObjUser = objUser
                Session("vpPkUserConnected") = objUser.PK_USER
                vgPropObjUser = objUser
                vgPkCliente = vgObjModelo.CLIENTES_USERS.SqlQuery("SELECT * FROM CLIENTES_USERS WHERE FK_USER=" & objUser.PK_USER)(0).FK_CLIENTE
                propVgObjCliente = New CLIENTES
                propVgObjCliente = vgObjModelo.CLIENTES.Find(vgPkCliente)
                Session("CTE_CONNECTED") = propVgObjCliente.PK_CLIENTE

                Me.lblUsrConnected.Text = objUser.USERNAME
                Me.lblCteConnected.Text = propVgObjCliente.NOMBRE
                Me.txtContraActual.Text = ""

                Select Case objUser.FK_ACCESS_GROUP
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
            vgObjUser = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))

            If Not Session("MESSAGE") Is Nothing Then
                Me.lblMessage.Text = Session("MESSAGE")
                Session("MESSAGE") = String.Empty
            End If
        End If

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(Me.vgPropObjUser.PK_USER)
        Catch ex As Exception
            lblSaldoCliente.Text = 0.0
        End Try
        lblSaldoCliente.Text = FormatNumber(lblSaldoCliente.Text, 2)

        If Not vgPropObjUser Is Nothing Then
            'Es usuario maestro
            If vgPropObjUser.FK_ACCESS_GROUP = 1 Then
                Me.lblSaldoGlobal.Visible = True
                Me.lblSaldoGlobal.Text = String.Empty ' "Saldo Global: $" & FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
            End If
        End If
    End Sub

    Private Function func_ContraActualCoincide() As Boolean
        Dim blnCoincide As Boolean = False

        If Session("isconsulta") = True Then
            If BACK_CODE.Cripto.ComparaCadenas(vgObjUser.pwdconsulta, Me.txtContraActual.Text.Trim()) Then
                blnCoincide = True
            Else
                blnCoincide = False
            End If
            Return blnCoincide
        End If

        If BACK_CODE.Cripto.ComparaCadenas(vgObjUser.PASSWORD, Me.txtContraActual.Text.Trim()) Then
            blnCoincide = True
        End If
        Return blnCoincide

    End Function

    Protected Sub btnCambiarContra_Click(sender As Object, e As EventArgs) Handles btnCambiarContra.Click
        'funcionalidad para cajeros 

        If Convert.ToBoolean(Session("isCajero")) Then
            Dim idCajero As Integer = Convert.ToInt32(Session("idCajero"))
            Dim cajero As CAJEROS = vgObjModelo.CAJEROS.Find(idCajero)

            If String.IsNullOrEmpty(txtContraActual.Text.Trim()) Then
                Me.lblMessage.Text = "Favor de indicar la contraseña actual"
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtNuevaContra.Text.Trim()) Then
                Me.lblMessage.Text = "Favor de indicar la nueva contraseña"
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtNuevaContraConfirm.Text.Trim()) Then
                Me.lblMessage.Text = "Favor de confirmar la nueva contraseña"
                Exit Sub
            End If

            If Not txtNuevaContra.Text = txtNuevaContraConfirm.Text Then
                Me.lblMessage.Text = "La nueva contraseña y su confirmacion no coinciden"
                Exit Sub
            End If

            If Not BACK_CODE.Cripto.ComparaCadenas(cajero.PassWord, txtContraActual.Text.Trim()) Then
                Me.lblMessage.Text = "La contraseña actual no es correcta"
                Exit Sub
            End If

            cajero.PassWord = BACK_CODE.Cripto.regresaHash(txtNuevaContra.Text.Trim())



            vgObjModelo.SaveChanges()
            Me.lblMessage.Text = "La Contraseña se actualizo correctamente"
            Me.txtContraActual.Text = ""
            Me.txtNuevaContra.Text = ""
            Me.txtNuevaContraConfirm.Text = ""
            Exit Sub

        End If ' end cajeros



        If func_ContraActualCoincide() = True Then
            If Trim(Me.txtNuevaContra.Text) = String.Empty Or Trim(Me.txtNuevaContraConfirm.Text) = String.Empty Then
                Me.lblMessage.Text = "Favor de ingresar la nueva contraseña."
                Exit Sub
            Else
                Dim usr As New USERS
                usr = vgObjModelo.USERS.Find(vgObjUser.PK_USER)

                If Trim(Me.txtNuevaContra.Text) = Trim(Me.txtNuevaContraConfirm.Text) Then

                    If Session("isconsulta") = True Then
                        usr.pwdconsulta = BACK_CODE.Cripto.regresaHash(txtNuevaContra.Text.Trim())
                    Else
                        usr.PASSWORD = BACK_CODE.Cripto.regresaHash(Me.txtNuevaContra.Text.Trim())
                    End If

                    'usr.PASSWORD = BACK_CODE.Cripto.regresaHash(Me.txtNuevaContra.Text.Trim())
                    vgObjModelo.SaveChanges()
                    lblMessage.Style.Remove("color")
                    lblMessage.Style.Add("color", "green")
                    Session("MESSAGE") = "Su contraseña ha sido cambiada con éxito."

                    Dim mail As New BACK_CODE.EnviaCorreo()
                    Try
                        mail.EnviaCorreo("<HTML><BODY>Cambio de contraseña exitoso: " & usr.USERNAME & "</BODY></HTML>", "Cambio de Contraseña del usuario " & usr.NOMBRE & " " & usr.AP_PATERNO & " " & usr.AP_MATERNO, True)
                    Catch ex As Mail.SmtpException
                        Me.lblMessage.Text &= " ** " & ex.Message
                    End Try

                    Response.Redirect("CambiarPsw.aspx")

                Else

                    vgPropIntIntentosFallaDesbloquear += 1

                    Me.lblMessage.Text = "La contraseña no coincide, favor de validar."

                    If vgPropIntIntentosFallaDesbloquear = 3 Then
                        usr.bloqueado = 1
                        vgObjModelo.SaveChanges()
                        Me.lblMessage.Text &= "<li>Usuario bloqueado por exceso de intentos incorrectos, Favor de contactar al administrador.</li>"
                    End If

                    Exit Sub
                End If
            End If
        Else
            vgPropIntIntentosFallaDesbloquear += 1
            Me.lblMessage.Text = "Contraseña actual incorrecta."

        End If
    End Sub

End Class