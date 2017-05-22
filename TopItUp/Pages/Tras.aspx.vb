Imports System.Globalization

Public Class Tras
    Inherits BasePage

    Dim vgObjModelo As New EDM_TopItUp

    Private Property propSaldoCteOrigen As Decimal
        Set(value As Decimal)
            Session("CTE_SALDO_ORIGEN") = value
        End Set
        Get
            Return Session("CTE_SALDO_ORIGEN")
        End Get
    End Property
    Private Property propSaldoCteDestino As Decimal
        Set(value As Decimal)
            Session("CTE_SALDO_DESTINO") = value
        End Set
        Get
            Return Session("CTE_SALDO_DESTINO")
        End Get
    End Property
    Private Property vgSaldoUserConnected As Decimal
        Set(value As Decimal)
            Session("USR_SALDO") = value
        End Set
        Get
            Return Session("USR_SALDO")
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
                'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenuOtras.jpg);background-size: cover;")
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
            Try
                Me.lblUsrConnected.Text = vgPropObjUserConnected.USERNAME

                'Pongo el cliente al que pertenece el usuario o en su caso el CLIENTE del usuario que no tiene dependencia
                Me.lblCteConnected.Text = Me.vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

                sub_FillControls()

                If Not IsPostBack Then
                    'Si es Administrador maestro no tiene límite
                    If Me.vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then

                    Else
                        If Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Or CDec(Me.lblSaldoCteOrigen.Text) <= 0.0 Then
                            'Si el cliente actual no tiene hijos entonces no podrá traspasar
                            Me.lblMessage.Text = "Estimado Cliente, para realizar traspasos es necesario tener al menos un cliente de nivel inferior y usted tener saldo disponible."
                            sub_DeshabilitaPantalla()
                        End If
                    End If
                End If

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"
        End If

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

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

    Private Function func_RegistraTraspaso() As Boolean
        Dim blnExitoso As Boolean = False
        Dim dteFechaMvto As DateTime = Date.Now
        Dim clsGeneric As New clsGenerics

        'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
        Dim objSaldoDeposito As New SALDOS
        Dim usrDestino As Integer = clsGeneric.func_GetUserByCliente(Me.ddlClienteDeposito.SelectedItem.Value)

        'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
        Dim objSaldoRetiro As New SALDOS
        Dim usrOrigen As Integer = clsGeneric.func_GetUserByCliente(Me.ddlClienteRetiro.SelectedItem.Value)

        '/*******************************************************************/
        '/*******************************************************************/
        '/*********************** TRANSACCION ORIGEN ************************/
        '/*******************************************************************/
        '/*******************************************************************/
        'Guardo la transacción 
        'Agregamos la transacción generada por el traspaso
        Dim objTrans As New TRANSACCIONES
        objTrans.FECHA = Date.Now.Date
        objTrans.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente
        objTrans.FK_CAT_TIPO_MVTO = 3 'Traspaso entre cuentas
        objTrans.FK_USER = usrOrigen
        objTrans.HORA = Date.Now.Hour & ":" & Date.Now.Minute
        objTrans.MONTO_MTO = CDec(Me.txtMontoTraspaso.Text)
        objTrans.TRANSACCION = String.Empty
        objTrans.MOTIVO_TRASPASO = Trim(Me.txtMotivoTraspaso.Text)

        Dim mail As New BACK_CODE.EnviaCorreo()
        Try
            vgObjModelo.TRANSACCIONES.Add(objTrans)
            'Guardamos la transacción
            vgObjModelo.SaveChanges()
        Catch ex As Exception
            Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message
            Try
                mail.EnviaCorreo("Error Traspasos :: " & Me.lblMessage.Text, "ERROR TRASPASOS", True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
            blnExitoso = False
        End Try

        '/*******************************************************************/
        '/*******************************************************************/
        '/*********************** SALDO ORIGEN ******************************/
        '/*******************************************************************/
        '/*******************************************************************/
        objSaldoRetiro.FK_TRANSACCION = objTrans.PK_TRANSACCION
        objSaldoRetiro.FECHA_MVTO = dteFechaMvto
        objSaldoRetiro.MONTO_MVTO = CDec(Me.txtMontoTraspaso.Text)
        objSaldoRetiro.FK_USER = usrOrigen 'USUARIO DEL CLIENTE AL QUE SE LE DEPOSITA EL EFECTIVO
        'Aquí recupero el saldo del cliente y le resto el traspaso
        objSaldoRetiro.SALDO = clsGeneric.func_GetSaldoUsr(usrOrigen) - CDec(Me.txtMontoTraspaso.Text)

        '/*******************************************************************/
        '/*******************************************************************/
        '/*********************** TRANSACCION DESTINO ***********************/
        '/*******************************************************************/
        '/*******************************************************************/
        'Agregamos la transacción generada por el traspaso
        Dim objTrans2 As New TRANSACCIONES
        objTrans2.FECHA = Date.Now.Date
        objTrans2.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente
        objTrans2.FK_CAT_TIPO_MVTO = 3 'Traspaso entre cuentas
        objTrans2.FK_USER = usrDestino
        objTrans2.HORA = Date.Now.Hour & ":" & Date.Now.Minute
        objTrans2.MONTO_MTO = CDec(Me.txtMontoTraspaso.Text)
        objTrans2.TRANSACCION = String.Empty

        Try
            vgObjModelo.TRANSACCIONES.Add(objTrans2)
            'Guardamos la transacción
            vgObjModelo.SaveChanges()
        Catch ex As Exception
            Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message
            Try
                mail.EnviaCorreo("Error Traspasos :: " & Me.lblMessage.Text, "ERROR TRASPASOS", True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
            blnExitoso = False
        End Try

        '/*******************************************************************/
        '/*******************************************************************/
        '/*********************** SALDO DESTINO *****************************/
        '/*******************************************************************/
        '/*******************************************************************/
        objSaldoDeposito.FK_TRANSACCION = objTrans.PK_TRANSACCION
        objSaldoDeposito.FECHA_MVTO = dteFechaMvto
        objSaldoDeposito.MONTO_PAGO = CDec(Me.txtMontoTraspaso.Text)
        objSaldoDeposito.FK_USER = usrDestino 'USUARIO DEL CLIENTE AL QUE SE LE DEPOSITA EL EFECTIVO
        'Aquí recupero el saldo del cliente y le aumento el traspaso
        objSaldoDeposito.SALDO = clsGeneric.func_GetSaldoUsr(usrDestino) + CDec(Me.txtMontoTraspaso.Text)

        Try
            vgObjModelo.SALDOS.Add(objSaldoRetiro) 'cargo
            vgObjModelo.SALDOS.Add(objSaldoDeposito) 'abono
            'Guardamos la transacción
            vgObjModelo.SaveChanges()
            blnExitoso = True

        Catch ex As Exception
            Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
            Try
                mail.EnviaCorreo("Error Traspasos :: " & Me.lblMessage.Text, "ERROR TRASPASOS", True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
            blnExitoso = False
        End Try

        Return blnExitoso
    End Function
    Private Function func_ValidaForm() As Boolean
        Dim blnValido As Boolean = True
        Me.lblMessage.Text = "<ol>Estimado Cliente, Favor de validar:<\ol><br>"

        If Me.vgPropObjUserConnected.FK_ACCESS_GROUP <> 1 Then
            If CDec(Me.txtMontoTraspaso.Text) > Me.propSaldoCteOrigen Then
                Me.lblMessage.Text &= "<ul>El monto del traspaso no puede ser mayor al saldo del Cliente Retiro.<\ul>"
                blnValido = False
            End If
        End If

        If Me.ddlClienteRetiro.SelectedItem.Value = -1 Then
            Me.lblMessage.Text &= "<ul>Es necesario seleccionar el clientee para efecturar el Retiro.<\ul>"
            blnValido = False
        End If

        If Me.ddlClienteDeposito.SelectedItem.Value = -1 Then
            Me.lblMessage.Text &= "<ul>Es necesario seleccioar el cliente para efecturar el Depósito.<\ul>"
            blnValido = False
        End If

        If Me.vgPropObjUserConnected.FK_ACCESS_GROUP <> 1 Then
            If CDec(Me.lblSaldoCteOrigen.Text) = 0.0 Then
                Me.lblMessage.Text &= "<ul>El Cliente Retiro debe tener saldo para poder traspasar.<\ul>"
                blnValido = False
            End If
        End If

        Return blnValido
    End Function

    Private Sub sub_FillControls()

        'Lleno saldo del usuario
        'ESTA VARIABLE DEBERÁ PONERSE EN GLOBAL.ASAX o MASTERPAGE
        Try
            vgSaldoUserConnected = vgObjModelo.SALDOS.SqlQuery("SELECT * FROM SALDOS WHERE PK_SALDO = (SELECT MAX(PK_SALDO) FROM SALDOS WHERE FK_USER=" & Me.vgPropIntCveUserConnected & ")").ToList()(0).SALDO()
        Catch ex As Exception
            vgSaldoUserConnected = 0.0
        End Try

        Me.lblSaldoCteOrigen.Text = "0.00" 'vgSaldoUserConnected

        Dim liClienteSelec As New ListItem
        liClienteSelec.Text = "Selecccione"
        liClienteSelec.Value = -1
        Me.ddlClienteDeposito.Items.Add(liClienteSelec)
        Me.ddlClienteRetiro.Items.Add(liClienteSelec)
        Dim g As New clsGenerics
        For Each cte As CLIENTES In vgObjModelo.CLIENTES.SqlQuery("SELECT * FROM CLIENTES WHERE STATUS = 1 ORDER BY NOMBRE ASC").ToList()

            'Fill a clientes a depositar
            Dim liCteOrigen As New ListItem

            Try
                liCteOrigen.Text = cte.NOMBRE '& " => " & g.func_GetUsrConnected(g.func_GetUserByCliente(cte.PK_CLIENTE)).USERNAME
            Catch ex As Exception
                liCteOrigen.Text = cte.NOMBRE
            End Try

            liCteOrigen.Value = cte.PK_CLIENTE
            Me.ddlClienteDeposito.Items.Add(liCteOrigen)

            'Fill a clientes  para retirar
            Dim liCteDestino As New ListItem
            Try
                liCteDestino.Text = cte.NOMBRE '& " => " & g.func_GetUsrConnected(g.func_GetUserByCliente(cte.PK_CLIENTE)).USERNAME
            Catch ex As Exception
                liCteDestino.Text = cte.NOMBRE
            End Try

            liCteDestino.Value = cte.PK_CLIENTE
            Me.ddlClienteRetiro.Items.Add(liCteDestino)
        Next
    End Sub

    Private Sub sub_DeshabilitaPantalla()
        Me.txtMontoTraspaso.Enabled = False
        Me.ddlClienteDeposito.Enabled = False
        Me.ddlClienteRetiro.Enabled = False
        Me.btnTraspasar.Enabled = False
    End Sub

    Protected Sub ddlClienteRetiro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClienteRetiro.SelectedIndexChanged
        If Me.ddlClienteRetiro.SelectedItem.Value <> "-1" Then
            Dim objGeneric As New clsGenerics
            Me.propSaldoCteOrigen = objGeneric.func_GetSaldoUsr(objGeneric.func_GetUserByCliente(Me.ddlClienteRetiro.SelectedItem.Value))
            Me.lblSaldoCteOrigen.Text = propSaldoCteOrigen
        Else
            Me.propSaldoCteOrigen = CDec(0.0)
        End If
    End Sub

    Protected Sub ddlClienteDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClienteDeposito.SelectedIndexChanged
        If Me.ddlClienteDeposito.SelectedItem.Value <> "-1" Then
            Dim objGeneric As New clsGenerics
            Me.propSaldoCteDestino = objGeneric.func_GetSaldoUsr(objGeneric.func_GetUserByCliente(Me.ddlClienteDeposito.SelectedItem.Value))
        Else
            Me.propSaldoCteDestino = CDec(0.0)
        End If
    End Sub

    Protected Sub btnTraspasar_Click(sender As Object, e As EventArgs) Handles btnTraspasar.Click
        If func_ValidaForm() = True Then
            Me.propSaldoCteOrigen -= Me.txtMontoTraspaso.Text 'CARGO
            Me.propSaldoCteDestino += Me.txtMontoTraspaso.Text 'ABONO

            'GUARDO EL REGISTRO DEL SALDO DE CADA UNO DE LOS CLIENTES
            If func_RegistraTraspaso() = True Then
                Me.lblMessage.Text = "<html><body><ol>El traspaso por la cantidad de <b>" & Me.txtMontoTraspaso.Text & "<\b> ha sido exitoso, los nuevos saldos disponibles son:<\ol><br>"
                Me.lblMessage.Text &= "<ul>Cliente Retiro ( " & Me.ddlClienteRetiro.SelectedItem.Text & " ) : " & propSaldoCteOrigen & "<\ul>."
                Me.lblMessage.Text &= "<ul>Cliente Depósito ( " & Me.ddlClienteDeposito.SelectedItem.Text & " ) : " & propSaldoCteDestino & ".<\ul></body></html>"
                Dim mail As New BACK_CODE.EnviaCorreo
                Me.txtMontoTraspaso.Text = ""
                txtMotivoTraspaso.Text = ""
                lblSaldoCteOrigen.Text = ""
                lblSaldoCliente.Text = ""

                ddlClienteRetiro.SelectedIndex = 0
                ddlClienteDeposito.SelectedIndex = 0
                Try
                    mail.EnviaCorreo("TRASPASO EXITOSO :: " & Me.lblMessage.Text, "TRASPASO EXITOS", False)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            Else
                Me.lblMessage.Text = "No esposible realizar el traspaso, favor de contactar al administrador."
            End If
        End If
    End Sub
End Class