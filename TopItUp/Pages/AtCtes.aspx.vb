Imports System.Net
Public Class AtCtes
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp
    Dim vgPkCliente As Integer = -1

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
      

        Dim clsGeneric As New clsGenerics
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
            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "red")
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
            'If Me.propVgBlOnlyTelcel = True Then
            '    opc10.HRef = "../Default.aspx"
            '    tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
            'Else
            '    opc10.HRef = "../Otras.aspx"
            '    tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
            'End If

            If Me.propVgBlOnlyTelcel = True Then
                Session("intSoloTelcel") = 1
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                '#070711
                imglogox.ImageUrl = "../Images/recargastelcel.png"
                tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
                ' tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenu.jpg);background-size: cover;")
            Else
                Session("intSoloTelcel") = 0
                Me.logoTelcel.Visible = False

                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
                ' tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenuOtras.jpg);background-size: cover;")
            End If

            Dim objUser As New USERS

            Try
                objUser = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))
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

                Me.txtCte.Text = propVgObjCliente.NOMBRE
                Me.txtMailCte.Text = propVgObjCliente.EMAIL

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"
        End If

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(Me.vgPropObjUserConnected.PK_USER)
        Catch ex As Exception
            lblSaldoCliente.Text = 0.0
        End Try

        lblSaldoCliente.Text = FormatNumber(lblSaldoCliente.Text, 2)
        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        If Not vgPropObjUserConnected Is Nothing Then
            'Es usuario maestro
            If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                Me.lblSaldoGlobal.Visible = True
                Me.lblSaldoGlobal.Text = String.Empty '"Saldo Global: $" & FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
            End If
        End If

    End Sub
    Private Function func_validaCliente() As Boolean
        Dim blnCorrecto As Boolean = True
        Me.lblMessage.Text = "Favor de ingresar y validar:<ol>"

        If Trim(Me.txtCte.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Cliente.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtMailCte.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Correo electrónico.</li>"
            blnCorrecto = False
        End If

        If Trim(Me.txtComentarios.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Comentarios.</li>"
            blnCorrecto = False
        End If

        Me.lblMessage.Text &= "</ol>"

        Return blnCorrecto
    End Function

    Protected Sub btnSaveComentarios_Click1(sender As Object, e As EventArgs) Handles btnSaveComentarios.Click
        If Me.func_validaCliente() = True Then
            Dim comments As New DUDAS_COMENTARIOS
            Dim objUSER As New USERS
            Dim clsGeneric As New clsGenerics
            objUSER = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))
            comments.FK_USER = objUSER.PK_USER
            comments.NOMBRE_CORTO = "COM: " & Date.Now.Date
            comments.DESCRIPCION = Me.txtComentarios.Text
            comments.STATUS = 1

            vgObjModelo.DUDAS_COMENTARIOS.Add(comments)
            vgObjModelo.SaveChanges()
            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "green")
            Me.lblMessage.Text = "Muchas gracias por sus comentarios, son muy importantes para nosotros, nos comunicaremos con usted en el transcurso del día."
            Dim mail As New BACK_CODE.EnviaCorreo()
            Try
                mail.EnviaCorreo("<HTML><BODY>" & comments.NOMBRE_CORTO & " <br>Descripción: " & comments.DESCRIPCION & "</BODY></HTML>", "Comentarios Recibidos de USR:" & objUSER.USERNAME & " - MAIL REPORTADO: " & Me.txtMailCte.Text & " USUARIO: " & objUSER.NOMBRE & " " & objUSER.AP_PATERNO & " " & objUSER.AP_MATERNO, False)
            Catch ex As Mail.SmtpException
                Me.lblMessage.Text &= " ** " & ex.Message
            End Try

            Try
                mail.EnviaCorreoIndividual("<HTML><BODY>" & comments.NOMBRE_CORTO & " <br>Descripción: " & comments.DESCRIPCION & "</BODY></HTML>", "Comentarios Recibidos de USR:" & objUSER.USERNAME & " - MAIL REPORTADO: " & Me.txtMailCte.Text & " USUARIO: " & objUSER.NOMBRE & " " & objUSER.AP_PATERNO & " " & objUSER.AP_MATERNO, 1, "atencion.clientes@topitup.net")
            Catch ex As Mail.SmtpException
            End Try

        End If
    End Sub

End Class