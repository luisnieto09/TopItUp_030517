Imports System.Net

Public Class DesbloqueaUser
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp
    Dim vgPkCliente As Integer = -1
    Dim clsGeneric As New clsGenerics

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

    Private Property vgPropObjUser As USERS
        Set(value As USERS)
            Session("vgPropObjUser") = value
        End Set
        Get
            Return CType(Session("vgPropObjUser"), USERS)
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

        If Not IsPostBack Then

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
            If Convert.ToBoolean(Session("isCajero")) = True Then
                Response.Redirect("../Pages/TaElectronico.aspx")
            End If

            If vgObjUser.FK_ACCESS_GROUP = 1 Then
                filaBanco.Visible = True
            Else
                filaBanco.Visible = False
            End If

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
            Dim clsGeneric As New clsGenerics
            Dim objUser As New USERS

            Try
                objUser = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))
                Session("vpPkUserConnected") = objUser.PK_USER
                vgPropObjUser = objUser
                vgPkCliente = vgObjModelo.CLIENTES_USERS.SqlQuery("SELECT * FROM CLIENTES_USERS WHERE FK_USER=" & objUser.PK_USER)(0).FK_CLIENTE
                propVgObjCliente = New CLIENTES
                propVgObjCliente = vgObjModelo.CLIENTES.Find(vgPkCliente)
                Session("CTE_CONNECTED") = propVgObjCliente.PK_CLIENTE

                Me.lblUsrConnected.Text = objUser.USERNAME
                Me.lblCteConnected.Text = propVgObjCliente.NOMBRE

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
            sub_FillUsersByCte()

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

    Private Sub sub_FillUsersByCte()
        Dim strQuery As String = "select  u.* from clientes c, clientes_users cu, users u where c.fk_cliente_padre = " & propVgObjCliente.PK_CLIENTE & " and cu.fk_cliente = c.pk_cliente and u.pk_user = cu.fk_user and u.status=1 and bloqueado=1"

        'Cuando es super admin obtiene todos los usuarios existentes
        If vgObjUser.FK_ACCESS_GROUP = 1 Then
            strQuery = "select u.* from users u where status in(1,2) and bloqueado=1 "
        End If

        Dim liSelec As New ListItem
        liSelec.Value = -1
        liSelec.Text = "Seleccione"
        Me.ddlUsersCteConnected.Items.Add(liSelec)

        For Each usr As USERS In vgObjModelo.USERS.SqlQuery(strQuery).ToList
            Dim li As New ListItem
            li.Value = usr.PK_USER
            li.Text = usr.AP_PATERNO & " " & usr.AP_MATERNO & " " & usr.NOMBRE
            Me.ddlUsersCteConnected.Items.Add(li)
        Next

    End Sub

    Protected Sub btnDesbloquear_Click(sender As Object, e As EventArgs) Handles btnDesbloquear.Click
        Dim intVlUsrSelect As Integer = Me.ddlUsersCteConnected.SelectedItem.Value

        If intVlUsrSelect <> -1 Then
            Dim objUsr As New USERS
            objUsr = vgObjModelo.USERS.Find(intVlUsrSelect)
            Session("MESSAGE") = "Usuario desbloqueado con éxito.<br>"

            If Me.chkResetPsw.Checked = True Then
                objUsr.PASSWORD = BACK_CODE.Cripto.regresaHash("12345678a")
                objUsr.STATUS = 2  'Para cambiar su psw en primer acceso
                Session("MESSAGE") &= " Favor de notificar su nueva contraseña: <b>12345678a</b>"

                Dim mail As New BACK_CODE.EnviaCorreo()
                Try
                    mail.EnviaCorreo("<HTML><BODY>Usuario Desbloqueado: " & objUsr.USERNAME & "</BODY></HTML>", "Desbloqueo de cuenta del usuario " & objUsr.NOMBRE & " " & objUsr.AP_PATERNO & " " & objUsr.AP_MATERNO, True)
                Catch ex As Mail.SmtpException
                    Me.lblMessage.Text &= " ** " & ex.Message
                End Try

            End If

            objUsr.bloqueado = 0
            vgObjModelo.SaveChanges()
            Response.Redirect("DesbloqueaUser.aspx")
        Else
            'Mensaje
            Me.lblMessage.Text = "Favor de seleccionar algún usuario para desbloquear."
        End If
    End Sub
End Class