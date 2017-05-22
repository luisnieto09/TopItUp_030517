Public Class RegistroRapido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
                System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
            End If
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim ef As New EDM_TopItUp()

            Dim correoexiste As Integer = ef.REGISTRO_RAPIDO.Where(Function(x) x.EMAIL.ToLower().Trim() = txtEmail.Text.ToLower().Trim()).Count()

            If correoexiste > 0 Then
                Throw New Exception("El correo electrónico ya había sido registrado con anterioridad")
            End If

            Dim numeroexiste As Integer = ef.REGISTRO_RAPIDO.Where(Function(x) x.TELEFONO_CELULAR.ToLower().Trim() = txtTelefonoCelular.Text.ToLower().Trim()).Count()
            If numeroexiste > 0 Then
                Throw New Exception("El número de teléfono celular ya había sido registrado con anterioridad")
            End If


            Dim _registro As New REGISTRO_RAPIDO()
            _registro.NOMBRE = Trim(Me.txtnombre.Text)
            _registro.EMAIL = Trim(Me.txtEmail.Text)
            _registro.GIRO_NEGOCIO = Trim(Me.txtGiro.Text)
            _registro.DIRECCIO_NEGOCIO = Trim(Me.txtDireccionNegocio.Text)
            _registro.ESTADO = Trim(Me.txtEstado.Text)
            _registro.MUNICIPIO = Trim(Me.txtMunicipio.Text)
            _registro.CP = Trim(Me.txtCP.Text)
            _registro.TELEFONO_CASA = Trim(Me.txtTelefonoCasa.Text)
            _registro.TELEFONO_CELULAR = Trim(Me.txtTelefonoCelular.Text)
            _registro.VENDEPORINTERNET = If(Me.ddlVendeporInternet.SelectedValue = 1, True, False)
            _registro.CLAVEGENERADA = regresaClaveUnica()
            _registro.TIPO_PERSONA = Me.ddlTipoPersona.SelectedValue
            _registro.REQUIEREFACTURA = If(Me.ddlRequiereFactura.SelectedValue = 1, True, False)

            If Me.ddlRequiereFactura.SelectedValue = 1 Then

                _registro.NOMBREFACTURA = Me.txtNombreFactura.Text
                _registro.DIRECCIONFACTURA = Me.txtDireccionFactura.Text
                _registro.RFCFACTURA = Me.txtRFCFactura.Text
                _registro.TELEFONOFACTURA = Me.txtTelefonoFactura.Text

            End If
            _registro.FECHACAMBIO = DateTime.Now
            ef.REGISTRO_RAPIDO.Add(_registro)
            ef.SaveChanges()

            Dim mail As New BACK_CODE.EnviaCorreo()
            Dim strMsg = String.Empty
            strMsg += vbCrLf
            strMsg += vbCrLf
            strMsg += "Hola agradecemos su interés en TopItUp" + vbCrLf
            strMsg += vbCrLf
            strMsg += "le hacemos llegar su clave de activación para TopItUp" + vbCrLf
            strMsg += "solo por activacion usted tendrá un saldo a favor gratis de $20.00" + vbCrLf
            strMsg += "para poder probar la aplicación" + vbCrLf
            strMsg += vbCrLf
            strMsg += "su clave de activacion es: " + _registro.CLAVEGENERADA + vbCrLf
            strMsg += "puede activarla en la siguiente dirección:  https://www.topitup.net/Pages/Activacion" + vbCrLf + vbCrLf
            strMsg += "quedamos a sus ordenes"

            'mail.EnviaCorreoIndividual(strMsg, "clave de activación", 1, _registro.EMAIL)
            Me.lblMensaje.Text = "Su registro ha sido exitoso, su clave de activación  ha sido enviada al teléfono celular proporcionado."

            'MANDO SMS
            Dim strMsgNuevoDepSMS As String = "Bienvenido, comienza a ganar con TopItUp, entra YA!!! www.topitup.net/Pages/Activacion ,CODIGO: " & _registro.CLAVEGENERADA
            Dim strUrlEnvioMensaje As String = "https://www.smsmasivos.com.mx/sms/api.envio.new.php?"
            strMsgNuevoDepSMS = strMsgNuevoDepSMS.Replace(" ", "%20")
            Dim strNumCel As String = _registro.TELEFONO_CELULAR
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
                mail.EnviaCorreo("RESPUESTA SMS AUTOMATIC PROCESS: " & responseData, "RESPUESTA DEL ENVÍO DE SMS - AUTOMATIC PROCESS", False)

                responseReader.Close()
                webRequest.GetResponse().Close()
            Catch ex As Exception
                mail.EnviaCorreo("ERROR AL ENVIAR SMS - AUTOMATIC PROCESS: " & ex.Message, "ERROR EN EL ENVÍO SMS - AUTOMATIC PROCESS", False)
            End Try
        Catch ex As Exception
            Me.lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Function regresaClaveUnica() As String
        Dim fecha As DateTime = DateTime.Now
        Dim claveunica As String = fecha.Month.ToString().PadRight("00") + fecha.Day.ToString().PadRight("00") + fecha.Hour.ToString().PadRight("00") + fecha.Minute.ToString().PadRight("00") + fecha.Second.ToString().PadRight("00") + fecha.Millisecond.ToString().PadRight("00")
        Return claveunica
    End Function

    Protected Sub ddlRequiereFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRequiereFactura.SelectedIndexChanged
        Try
            If Me.ddlRequiereFactura.SelectedValue = 1 Then
                Me.Panel1.Visible = True
            Else
                Me.Panel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class