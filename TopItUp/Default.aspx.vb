Imports System.Net
Imports System.Security.Cryptography
Imports BACK_CODE

Public Class _Default
    Inherits System.Web.UI.Page

    Dim vgModelo As New EDM_TopItUp
    Dim vgBlnVieneDeCerrar As Boolean = False

    Private Property propVgBlOnlyTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property

    Private Property vgPropIntIntentosFallidos As Integer
        Set(value As Integer)
            Session("vgPropIntIntentosFallidos") = value
        End Set
        Get
            Return Session("vgPropIntIntentosFallidos")
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
        If Not Session("ERROR") Is Nothing Then
            Me.lblMessage.Text = Session("ERROR")
            Session("ERROR") = Nothing
        End If

        If Not IsPostBack Then
            Session("servcol") = ""
            Session("MOSTRADO") = False
            If vgPropObjUserConnected Is Nothing And vgPropObjCteConnected Is Nothing Then
                vgPropObjUserConnected = New USERS
                vgPropObjCteConnected = New CLIENTES

                vgPropObjUserConnected.PK_USER = -1
                vgPropObjCteConnected.PK_CLIENTE = -1
                vgPropIntCveUserConnected = vgPropObjUserConnected.PK_USER
                vgPropIntCveCteConnected = vgPropObjCteConnected.PK_CLIENTE
            End If

            vgPropIntIntentosFallidos = 0


            propVgBlOnlyTelcel = False


            propVgBlOnlyTelcel = True

            'Verifico si es el primer acceso o viene de un CERRAR SESIÓN
            Try
                If vgPropObjCteConnected.PK_CLIENTE <> -1 Then
                    vgBlnVieneDeCerrar = True
                    'Viene de un cerrar sesión entonces actualizo la fecha Final del acceso
                    Dim objAcceso As New ACCESOS

                    objAcceso = vgModelo.ACCESOS.Find(Session("PK_ACCESO"))
                    'Sesión correcta
                    If objAcceso.DATETIME_FIN Is Nothing Then
                        objAcceso.DATETIME_FIN = Date.Now
                        objAcceso.DURACION_SESSION_MINUTOS = "" 'Poner la diferencia en minutos
                        vgModelo.SaveChanges()
                        Session.Abandon()
                        Me.lblMessage.Style.Remove("color")
                        Me.lblMessage.Style.Add("color", "green")
                        Me.lblMessage.Text = "Sesión cerrada con éxito."
                    Else
                        'se salió la última vez SIN DARLE SALIR
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Sub btnEntrar_Click(sender As Object, e As ImageClickEventArgs) Handles btnEntrar.Click
        Session("isCajero") = False
        Me.propVgBlOnlyTelcel = True
        Me.lblMessage.Style.Remove("color")
        Me.lblMessage.Style.Add("color", "red")
        Me.lblMessage.Text = "<ol>"
        Dim blnCorrecto As Boolean = True

        If Me.ddlDuracionSesion.SelectedItem.Value <> "-1" Then
            Select Case Me.ddlDuracionSesion.SelectedItem.Value
                Case "1H"
                    Session.Timeout = 60
                Case "2H"
                    Session.Timeout = 120
                Case "4H"
                    Session.Timeout = 240
                Case "8H"
                    Session.Timeout = 480
                Case Else
                    Session.Timeout = Me.ddlDuracionSesion.SelectedItem.Value
            End Select

            Session("TIMEOUT") = Session.Timeout
        Else
            Me.lblMessage.Text &= "<li>Seleccione duración de conexión en el sistema.</li>"
            blnCorrecto = False
        End If

        If Me.txtUser.Text = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingrese Usuario.</li>"
            blnCorrecto = False
        End If

        If Me.txtPassword.Text = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingrese Contraseña.</li>"
            blnCorrecto = False
        End If

        Dim objModel As New EDM_TopItUp

        'seccion de cajeros 
        Dim iscajero As Integer = objModel.CAJEROS.Where(Function(x) x.UserName.ToLower.Trim() = txtUser.Text.ToLower.Trim()).Count()

        If iscajero > 0 Then

            Dim cajero As CAJEROS = objModel.CAJEROS.Where(Function(x) x.UserName.ToLower.Trim = txtUser.Text.Trim.ToLower()).FirstOrDefault()
            ' primero valida el password del cajero  

            Dim passOk As Boolean = BACK_CODE.Cripto.ComparaCadenas(cajero.PassWord, Me.txtPassword.Text.Trim())

            If Not passOk Then
                Me.lblMessage.Text = "Password de cajero incorrecto"
                Exit Sub
            End If

            Session("isCajero") = True
            Session("idCajero") = cajero.PkCajero

            Dim dia As Integer = DateTime.Now.DayOfWeek

            Select Case dia
                Case 0
                    dia = 7
            End Select

            Dim hora As Integer = DateTime.Now.Hour
            Dim puede As Integer = objModel.HORARIO_CAJERO.Where(Function(x) x.FK_CAJERO = cajero.PkCajero And x.DIA = dia And (hora >= x.HORAINICIO And hora <= x.HORAFINAL)).Count()

            If puede > 0 Then
                Session("servcol") = ""

                vgPropObjUserConnected = objModel.USERS.Where(Function(x) x.PK_USER = cajero.Fk_Usuario).FirstOrDefault()
                Dim cteuser As CLIENTES_USERS = objModel.CLIENTES_USERS.Where(Function(x) x.FK_USER = cajero.Fk_Usuario).FirstOrDefault()
                vgPropObjCteConnected = objModel.CLIENTES.Where(Function(x) x.PK_CLIENTE = cteuser.FK_CLIENTE).FirstOrDefault()
                vgPropIntCveUserConnected = cajero.Fk_Usuario
                vgPropIntCveCteConnected = vgPropObjCteConnected.PK_CLIENTE

                Response.Redirect("Pages/TAElectronico.aspx")
                Exit Sub

            Else
                Me.lblMessage.Text = "El cajero no se encuentra en su horario permitido para accesar"
                Exit Sub
            End If

        End If
        'termina seccion de cajeros 

        Session("isconsulta") = False
        Session("servcol") = ""
        vgPropObjUserConnected = objModel.USERS.SqlQuery("select * from users where iswcfuser = 1 and usrconsulta ='" + Me.txtUser.Text + "'").FirstOrDefault()

        If Not vgPropObjUserConnected Is Nothing Then ' existe el usuario de wcf 

            If BACK_CODE.Cripto.ComparaCadenas(vgPropObjUserConnected.pwdconsulta, Me.txtPassword.Text) Then
                Session("isconsulta") = True

                vgPropIntCveUserConnected = vgPropObjUserConnected.PK_USER
                vgPropIntCveCteConnected = objModel.CLIENTES_USERS.Where(Function(x) x.FK_USER = vgPropIntCveUserConnected).FirstOrDefault().FK_CLIENTE
                vgPropObjCteConnected = objModel.CLIENTES.Find(vgPropIntCveCteConnected)

                Response.Redirect("Pages/Reportes.aspx")
            Else
                Me.lblMessage.Text = "Datos incorrectos"
                blnCorrecto = False
                Exit Sub
            End If
        End If





        Try
            vgPropObjUserConnected = objModel.USERS.SqlQuery("SELECT * FROM USERS WHERE USERNAME='" & Me.txtUser.Text & "' and iswcfuser is null").First()
            Me.vgPropIntCveUserConnected = vgPropObjUserConnected.PK_USER
            If vgPropObjUserConnected.bloqueado = 1 Then
                Me.lblMessage.Text &= "<li>Usuario bloqueado, Favor de contactar al administrador.</li>"
                blnCorrecto = False
            ElseIf vgPropObjUserConnected.STATUS = 2 Then
                Me.lblMessage.Text += "DATOS INCORRECTOS"
                blnCorrecto = False
            Else
                If Trim(Me.txtUser.Text) = vgPropObjUserConnected.USERNAME And BACK_CODE.Cripto.ComparaCadenas(vgPropObjUserConnected.PASSWORD, Me.txtPassword.Text.Trim()) And vgPropObjUserConnected.STATUS = 1 Then
                    'Usuario correcto, valido que tenga cliente asignado.
                    Dim objModelo As New EDM_TopItUp
                    Dim cveCte As Integer = -1
                    Try
                        Me.vgPropIntCveCteConnected = objModelo.CLIENTES_USERS.SqlQuery("SELECT * FROM CLIENTES_USERS WHERE FK_USER=" & vgPropObjUserConnected.PK_USER)(0).FK_CLIENTE
                        Me.vgPropObjCteConnected = objModelo.CLIENTES.Find(vgPropIntCveCteConnected)

                        Dim tieneservicios = objModel.SERVICIOS_CLIENTE_REL.Where(Function(x) x.FK_CLIENTE = vgPropIntCveCteConnected)
                        If Not tieneservicios Is Nothing Then
                            If tieneservicios.Count() > 0 Then
                                Session("servcol") = "<tr><td class=""auto-style149"">&nbsp;</td><td><img class=""auto-style131"" src=""../Images/puntoOff.png"" runat=""server"" id=""Img1""><span class=""auto-style131""> </span></td></tr>"
                            Else
                                Session("servcol") = ""
                            End If
                        Else
                            Session("servcol") = ""
                        End If
                    Catch ex As Exception
                        blnCorrecto = False
                        Me.lblMessage.Text &= "<li>No tiene cliente asignado, favor de contactar al administrador.</li>"
                    End Try
                    'Datos correctos
                ElseIf vgPropObjUserConnected.STATUS = 0 Then
                    Me.lblMessage.Text &= "<li>Inactivo, Favor de contactar al administrador.</li>"
                    blnCorrecto = False
                    Exit Sub
                ElseIf vgPropObjUserConnected.STATUS = 2 Then
                    'Valido si es primer acceso del usuario
                    'EN CASO AFIRMATIVO MUESTRO LA OPCIÓN PARA GENERAR NUEVA CONSEÑA
                    If Me.txtxConfirmPsw.Visible = False Then
                        Me.lblConfirmPsw.Visible = True
                        Me.txtxConfirmPsw.Visible = True
                        Me.lblPsw.Text = "Nueva Contraseña"
                        Me.lblMessage.Text = "Estimado Cliente, por motivos de seguridad deberá cambiar su contraseña."
                        blnCorrecto = False
                        Exit Sub
                    End If

                    If Me.txtxConfirmPsw.Visible = True Then
                        If (Me.txtxConfirmPsw.Text = Me.txtPassword.Text) Then
                        Else
                            Me.lblMessage.Text = "Estimado Cliente, su nueva contraseña no coincide, favor de verificar."
                            blnCorrecto = False
                            Exit Sub
                        End If

                        If ((Me.txtxConfirmPsw.Text = Me.txtPassword.Text) And (BACK_CODE.Cripto.regresaHash(Me.txtxConfirmPsw.Text.Trim()) = Me.vgPropObjUserConnected.PASSWORD)) Then
                            Me.lblMessage.Text = "Estimado Cliente, su nueva contraseña no debe ser igual a la que tiene actualmente asignada."
                            blnCorrecto = False
                            Exit Sub
                        End If
                    End If
                Else
                    vgPropIntIntentosFallidos += 1
                    Me.lblMessage.Text &= "<li>Datos incorrectos.</li>"
                    Dim mail As New BACK_CODE.EnviaCorreo
                    If vgPropIntIntentosFallidos >= 5 Then
                        Dim usrBloqueo As USERS = vgModelo.USERS.Find(vgPropObjUserConnected.PK_USER)
                        usrBloqueo.bloqueado = 1
                        ''''vgModelo.SaveChanges()
                        Me.lblMessage.Text &= "<li>Usuario bloqueado por exceso de intentos incorrectos, Favor de contactar al administrador.</li>"
                        Try
                            mail.EnviaCorreo("Usuario bloqueado por Exceso de Intentos :: " & usrBloqueo.USERNAME, "BLOQUEO POR EXCESO DE INTENTOS :: " & usrBloqueo.NOMBRE & " " & usrBloqueo.AP_PATERNO & " " & usrBloqueo.AP_MATERNO, True)
                        Catch exX As Exception
                            Me.lblMessage.Text = exX.Message
                        End Try
                    End If

                    blnCorrecto = False
                End If

            End If
        Catch ex As Exception
            Me.lblMessage.Text &= "<li>Datos incorrectos</li>"
            blnCorrecto = False
        End Try

        Me.lblMessage.Text &= "</ol>"

        If blnCorrecto = True Then
            Dim objAcceso As New ACCESOS

            If Me.txtxConfirmPsw.Visible = True Then
                vgPropObjUserConnected = objModel.USERS.Find(vgPropObjUserConnected.PK_USER)
                vgPropObjUserConnected.PASSWORD = BACK_CODE.Cripto.regresaHash(Me.txtxConfirmPsw.Text.Trim())
                vgPropObjUserConnected.STATUS = 1
            End If

            'Find IP Address Behind Proxy Or Client Machine In ASP.NET  
            Dim IPAdd As String = String.Empty

            IPAdd = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

            If String.IsNullOrEmpty(IPAdd) Then
                IPAdd = Request.ServerVariables("REMOTE_ADDR")
                objAcceso.IP = IPAdd
            End If
            objAcceso.NAVEGADOR = Request.ServerVariables("HTTP_USER_AGENT")
            objAcceso.FK_USER = vgPropObjUserConnected.PK_USER
            objAcceso.DATETIME_INI = Date.Now
            objAcceso.DURACION_SESSION_MINUTOS = "-1"
            vgModelo.ACCESOS.Add(objAcceso)
            Session("PK_ACCESO") = objAcceso.PK_ACCESO

            If CheckBoxTelcel.Checked = True Then
                propVgBlOnlyTelcel = True
            End If
            If CheckBoxOtras.Checked = True Then
                propVgBlOnlyTelcel = False
            End If
            Response.Redirect("Pages/TAElectronico.aspx")


        End If
    End Sub

    Protected Sub CheckBoxTelcel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTelcel.CheckedChanged
        CheckBoxOtras.Checked = False
    End Sub

    Protected Sub CheckBoxOtra_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOtras.CheckedChanged
        CheckBoxTelcel.Checked = False
    End Sub
End Class