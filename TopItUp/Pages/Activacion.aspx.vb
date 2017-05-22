Imports System.Globalization

Public Class Activacion
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-MX")

            If Convert.ToBoolean(Session("isCajero")) = True Then
                Response.Redirect("../Pages/TaElectronico.aspx")
            End If
        End If
        

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If String.IsNullOrWhiteSpace(Me.txtEmail.Text.Trim) Then
                Throw New Exception("Favor de indicar correo")
            End If
            If String.IsNullOrWhiteSpace(Me.txtClave.Text.Trim) Then
                Throw New Exception("Favor de indicar clave")
            End If

            Dim ef As New EDM_TopItUp()


            Dim registro = ef.REGISTRO_RAPIDO.Where(Function(x) x.EMAIL.Trim.ToLower = Me.txtEmail.Text.Trim.ToLower).FirstOrDefault()
            If Not registro Is Nothing Then

                If registro.CLAVEGENERADA.Trim.ToLower = Me.txtClave.Text.Trim.ToLower Then ' correcto entonces genera usuario y cliente 

                    If registro.YASEACTIVO Then
                        Throw New Exception("El usuario " + registro.EMAIL + " ha sido activado anteriormente.")
                    End If

                    Using tran As System.Data.Entity.DbContextTransaction = ef.Database.BeginTransaction()
                        Try

                            Dim cte As New CLIENTES
                            cte.NOMBRE = registro.NOMBRE
                            cte.FK_EMPRESA = 1
                            cte.FK_CAT_RAZON_SOCIAL = Convert.ToInt32(registro.TIPO_PERSONA)
                            cte.DIRECCION_COMPLETA = registro.DIRECCIO_NEGOCIO
                            cte.TELEFONO_CONTACTO = registro.TELEFONO_CASA
                            cte.EMAIL = registro.EMAIL
                            cte.RFC = ""
                            cte.FK_CLIENTE_PADRE = 1
                            cte.STATUS = 1
                            cte.SALDO = Convert.ToDecimal(20)
                            ef.CLIENTES.Add(cte)

                            Dim user As New USERS
                            user.NOMBRE = registro.NOMBRE
                            user.AP_MATERNO = ""
                            user.AP_PATERNO = ""
                            user.STATUS = 1
                            user.EMAIL = registro.EMAIL
                            user.USERNAME = registro.EMAIL
                            user.PASSWORD = "e10adc3949ba59abbe56e057f20f883e"
                            user.FK_ACCESS_GROUP = 2
                            ef.USERS.Add(user)

                            Dim cteuser As New CLIENTES_USERS
                            cteuser.FK_CLIENTE = cte.PK_CLIENTE
                            cteuser.FK_USER = user.PK_USER
                            ef.CLIENTES_USERS.Add(cteuser)


                            For i As Integer = 1 To 5 Step 1
                                Dim com As New TELEFONIAS_CLIENTES
                                com.FK_CLIENTE = cte.PK_CLIENTE
                                com.FK_CAT_TELEFONIA = i
                                If i = 2 Then
                                    com.COMISION_TEL_CTE = Convert.ToDecimal(5)
                                Else
                                    com.COMISION_TEL_CTE = Convert.ToDecimal(6)
                                End If
                                ef.TELEFONIAS_CLIENTES.Add(com)
                            Next

                            registro.YASEACTIVO = True

                            Dim fecha = DateTime.Now
                            Dim t As New TRANSACCIONES

                            Dim admmaestro = ef.USERS.Where(Function(x) x.PK_USER = 1).FirstOrDefault() ' ADMINISTRADOR MAESTRO 

                            t.FK_USER = admmaestro.PK_USER
                            t.FK_CAT_TIPO_MVTO = 3
                            t.FK_CAT_MEDIO_DE_PAGO = 1
                            t.FECHA = fecha
                            t.HORA = fecha.Hour.ToString() & ":" & fecha.Minute.ToString()
                            t.MONTO_MTO = Convert.ToDecimal(20)
                            t.MOTIVO_TRASPASO = "SE TRASPASA PARA SALDO INICIAL CLIENTE EN REGISTRO RAPIDO " & user.USERNAME '& " SE TOMA SALDO DE  " & admmaestro.USERNAME
                            ef.TRANSACCIONES.Add(t)

                            Dim idsaldomayoradmmaestro As Integer = ef.SALDOS.Where(Function(x) x.FK_USER = admmaestro.PK_USER).Max(Function(x) x.PK_SALDO)
                            Dim saldoadmmaestro As Integer = ef.SALDOS.Where(Function(x) x.PK_SALDO = idsaldomayoradmmaestro).FirstOrDefault().SALDO

                            Dim s = New SALDOS()
                            s.FK_USER = admmaestro.PK_USER
                            s.FK_TRANSACCION = t.PK_TRANSACCION
                            s.MONTO_MVTO = Convert.ToDecimal(20)
                            s.MONTO_PAGO = 0
                            s.SALDO = saldoadmmaestro - Convert.ToDecimal(20)
                            s.FECHA_MVTO = fecha
                            ef.SALDOS.Add(s)

                            Dim sc = New SALDOS()
                            sc.FK_USER = user.PK_USER
                            sc.FK_TRANSACCION = t.PK_TRANSACCION
                            sc.MONTO_MVTO = 0
                            sc.MONTO_PAGO = Convert.ToDecimal(20)
                            sc.SALDO = Convert.ToDecimal(20)
                            sc.FECHA_MVTO = fecha
                            ef.SALDOS.Add(sc)

                            ef.SaveChanges()

                            Me.lblmessage.Text = "Usuario creado correctamente nombre de usuario: " + user.EMAIL + " password: 123456"
                            tran.Commit()

                            Try
                                Dim Mail As New BACK_CODE.EnviaCorreo()
                                Mail.EnviaCorreoIndividual("Te damos la bienvenida " + registro.NOMBRE, "Bienvenido a TOPITUP!!", 1, registro.EMAIL, False, Nothing, True)
                            Catch ex As Exception
                                Me.lblmessage.Text += " ERROR AL ENVIAR EL CORREO"
                            End Try

                        Catch ex As Exception
                            tran.Rollback()
                        End Try
                    End Using
                Else
                    'Throw New Exception("La clave proporcionada no coincide con la que se envió a su correo, favor de validar.")
                    Throw New Exception("Los datos no coinciden con lo que se envió a su correo, favor de validar.")
                End If
            Else
                Throw New Exception("El correo no coincide con ninguno registrado")
            End If

        Catch ex As Exception
            Me.lblmessage.Text = ex.Message
        End Try



    End Sub
End Class