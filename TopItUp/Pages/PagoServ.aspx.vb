Imports BACK_CODE
Imports System.Net
Imports TopItUp.Helpers
Public Class PagoServ
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

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"
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

            If Me.propVgBlOnlyTelcel = True Then
                Session("intSoloTelcel") = 1
                imglogox.ImageUrl = "../Images/recargastelcel.png"
                'tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
                'tblMenu.Attributes.Add("style", "background-image: url(../Images/backmenu.jpg);background-size: cover;")
            Else
                Session("intSoloTelcel") = 0
                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
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
            End Try

            Try

                Dim servicios As List(Of CAT_SERVICIOS) = vgObjModelo.CAT_SERVICIOS.SqlQuery("SELECT S.* FROM CAT_SERVICIOS S, SERVICIOS_CLIENTE_REL R WHERE R.FK_SERVICIO = S.PK_CAT_SERVICIO AND R.FK_CLIENTE =" & Me.vgPropIntCveCteConnected).ToList()
                Dim S As New CAT_SERVICIOS()
                S.PK_CAT_SERVICIO = -1
                S.DESCRIPCION = "Seleccione"
                servicios.Insert(0, S)
                Me.ddlServicio.DataSource = servicios
                Me.ddlServicio.DataValueField = "PK_CAT_SERVICIO"
                Me.ddlServicio.DataTextField = "DESCRIPCION"
                Me.ddlServicio.DataBind()
            Catch ex As Exception

            End Try

            Dim strQueryTelefonias As String = "SELECT T.* FROM CAT_TELEFONIAS T, TELEFONIAS_CLIENTES TC, CLIENTES C WHERE C.PK_CLIENTE = TC.FK_CLIENTE AND T.PK_CAT_TELEFONIA = TC.FK_CAT_TELEFONIA AND TC.COMISION_TEL_CTE > 0.00 AND TC.FK_CLIENTE=" & vgPropObjCteConnected.PK_CLIENTE
            Dim objModelo As New EDM_TopItUp

            If objModelo.CAT_TELEFONIAS.SqlQuery(strQueryTelefonias).Count = 0 Then
                'Sino tiene para recargas telefónicas entonces muestro el mensaje
                'Se muestra una sola vez cada que entras
                Dim cart = vgObjModelo.sp_get_Anuncio(vgPropObjCteConnected.PK_CLIENTE).ToList()
                If Session("MOSTRADO") Is Nothing Then
                    Session("MOSTRADO") = False
                End If

                If Session("MOSTRADO") = False Then
                    If cart.Count > 0 Then
                        For Each NOTI In cart
                            lblAnuncio.Text &= "<Li>" + NOTI + "</Li>"
                            mpeDatosPlan.Show()
                        Next
                        Session("MOSTRADO") = True
                    End If
                End If

            End If

        End If

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

    'Private Sub botonesiniciales()
    '    Me.ImageButton1.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton2.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton3.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton4.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton5.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton6.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton7.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton8.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton9.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton10.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton11.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton12.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton13.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton14.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton15.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton16.ImageUrl = "../Images/puntooff.png"
    '    Me.ImageButton17.ImageUrl = "../Images/puntooff.png"
    'End Sub

    'Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
    '    botonesiniciales()
    '    ImageButton1.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TAG100MXN"
    '    ViewState("DESC_SERVICIO") = "TAG Viaducto Bicentenario :: 100 MXN"
    'End Sub

    'Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
    '    botonesiniciales()
    '    ImageButton2.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TAG200MXN"
    '    ViewState("DESC_SERVICIO") = "TAG Viaducto Bicentenario :: 200 MXN"
    'End Sub

    'Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
    '    botonesiniciales()
    '    ImageButton3.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TAG300MXN"
    '    ViewState("DESC_SERVICIO") = "TAG Viaducto Bicentenario :: 300 MXN"
    'End Sub

    'Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
    '    botonesiniciales()
    '    ImageButton4.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3AXTELMXN"
    '    ViewState("DESC_SERVICIO") = "Axtel"
    'End Sub

    'Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
    '    botonesiniciales()
    '    ImageButton5.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3CABLEMASMXN"
    '    ViewState("DESC_SERVICIO") = "Cablemas"
    'End Sub

    'Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
    '    botonesiniciales()
    '    ImageButton6.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3CREDHIPOTECAMXN"
    '    ViewState("DESC_SERVICIO") = "Crédito Hipotecario"
    'End Sub

    'Protected Sub ImageButton7_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton7.Click
    '    botonesiniciales()
    '    ImageButton7.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3ECOGASMXN"
    '    ViewState("DESC_SERVICIO") = "Eco Gas"
    'End Sub

    'Protected Sub ImageButton8_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton8.Click
    '    botonesiniciales()
    '    ImageButton8.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3GASNATMXN"
    '    ViewState("DESC_SERVICIO") = "Gas Natural"
    'End Sub

    'Protected Sub ImageButton9_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton9.Click
    '    botonesiniciales()
    '    ImageButton9.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3GOBTESORERIAMXN"
    '    ViewState("DESC_SERVICIO") = "Tesorería GDF"
    'End Sub

    'Protected Sub ImageButton10_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton10.Click
    '    botonesiniciales()
    '    ImageButton10.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3LUZCFEMXN"
    '    ViewState("DESC_SERVICIO") = "Luz CFE"
    'End Sub

    'Protected Sub ImageButton11_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton11.Click
    '    botonesiniciales()
    '    ImageButton11.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEFOTELMEXMXN"
    '    ViewState("DESC_SERVICIO") = "Telmex"
    'End Sub

    'Protected Sub ImageButton12_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton12.Click
    '    botonesiniciales()
    '    ImageButton12.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEFTELNORMXN"
    '    ViewState("DESC_SERVICIO") = "Televisión Telnor"
    'End Sub

    'Protected Sub ImageButton13_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton13.Click
    '    botonesiniciales()
    '    ImageButton13.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEMAXCOMMXN"
    '    ViewState("DESC_SERVICIO") = "Televisión Maxcom"
    'End Sub

    'Protected Sub ImageButton14_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton14.Click
    '    botonesiniciales()
    '    ImageButton14.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEMEGACABMXN"
    '    ViewState("DESC_SERVICIO") = "Megacable"
    'End Sub

    'Protected Sub ImageButton15_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton15.Click
    '    botonesiniciales()
    '    ImageButton15.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELESKYMXN"
    '    ViewState("DESC_SERVICIO") = "SKY"
    'End Sub

    'Protected Sub ImageButton16_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton16.Click
    '    botonesiniciales()
    '    ImageButton16.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEDISHMXN"
    '    ViewState("DESC_SERVICIO") = "Dish"
    'End Sub

    'Protected Sub ImageButton17_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton17.Click
    '    botonesiniciales()
    '    ImageButton17.ImageUrl = "../Images/puntoon.png"
    '    ViewState("servicioseleccionado") = "S3TELEVETVMXN"
    '    ViewState("DESC_SERVICIO") = "Ve TV"
    'End Sub

    Protected Sub ddlServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlServicio.SelectedIndexChanged
        Try
            Dim servicios As List(Of CAT_SERVICIOS) = vgObjModelo.CAT_SERVICIOS.ToList()
            Dim sku = servicios.Where(Function(x) x.PK_CAT_SERVICIO.Equals(Convert.ToInt32(Me.ddlServicio.SelectedValue))).FirstOrDefault().NOMBRE_CORTO

            Select Case Me.ddlServicio.SelectedItem.Value
                Case 2, 3, 4 'Viaducto bicentenario
                    imgInfoRefServicioSelec.ImageUrl = ""
                    imgInfoRefServicioSelec.Visible = False
                Case 5 'Axtel
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_axtel.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 6 'Cablemas
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_cablemas.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 7 ' Crédito Hipotecario
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_infonavit.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 8 ' Eco Gas
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_ecogas.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 9 ' Gas Natural
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_gasnatural.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 10 ' Tesorería DF
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_gobdf.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 11 ' CFE
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_cfe.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 12 ' TELMEX
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_telmex.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 13 ' Televisión Telnor
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_telnor.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 14 ' Televisión Maxcom
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_maxcom.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 15 ' Megacable
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_megacable.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 16 ' SKY
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_sky.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 17 ' Dish
                    imgInfoRefServicioSelec.ImageUrl = "../Images/servicios_dish.jpg"
                    imgInfoRefServicioSelec.Visible = True
                Case 18 ' Ve TV
                    imgInfoRefServicioSelec.ImageUrl = ""
                    imgInfoRefServicioSelec.Visible = False
                Case Else
                    imgInfoRefServicioSelec.ImageUrl = ""
                    imgInfoRefServicioSelec.Visible = False
            End Select

            ViewState("servicioseleccionado") = sku
            ViewState("DESC_SERVICIO") = Me.ddlServicio.SelectedItem.Text
            If sku.Equals("S3TAG100MXN") Then
                Me.txtNumber.Enabled = False
                Me.txtNumber.Text = "100"
            ElseIf sku.Equals("S3TAG200MXN") Then
                Me.txtNumber.Enabled = False
                Me.txtNumber.Text = "200"
            ElseIf sku.Equals("S3TAG300MXN") Then
                Me.txtNumber.Enabled = False
                Me.txtNumber.Text = "300"
            Else
                Me.txtNumber.Enabled = True
            End If


        Catch ex As Exception
            imgInfoRefServicioSelec.ImageUrl = ""
            imgInfoRefServicioSelec.Visible = False
        End Try
    End Sub

    Protected Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try
            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "red")
            Dim clsGeneric As New clsGenerics
            Dim llave As New LLAVES_TRANS_SODESI_PRONTIPAGOS 'llave para refcte en prontipagos

            Dim saldoActual = clsGeneric.func_GetSaldoUsr(vgPropObjUserConnected.PK_USER)
            Me.lblMessage.Text = String.Empty

            If Trim(Me.txtNumber.Text) = String.Empty Then
                Me.lblMessage.Text = "Seleccione Importe a Pagar<br><br>"
            End If

            If Trim(Me.txtNumber.Text) = String.Empty Then
                If Me.ddlServicio.SelectedItem.Value <> "-1" Then
                    Me.lblMessage.Text &= "Ingrese la referencia ubicada en su estado de cuenta de " & Me.ddlServicio.SelectedItem.Text & ".<br>"
                Else
                    Me.lblMessage.Text &= "Ingrese la referencia ubicada en su estado de cuenta.<br>"
                End If
            End If

            If saldoActual < Convert.ToDouble(Me.txtNumber.Text) Then
                Me.lblMessage.Text &= "Saldo Insuficiente"
            End If

            If Me.lblMessage.Text <> String.Empty Then
                Exit Sub
            End If

            vgObjModelo = New EDM_TopItUp

            llave.FECHA_REFERENCIAS = Date.Now.Date
            llave.FK_CLIENTE = Me.vgPropIntCveCteConnected
            llave.PROCESADA = 0
            Try
                'Otengo la última clave procesada
                llave.REF_CTE = vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.SqlQuery("SELECT  * from LLAVES_TRANS_SODESI_PRONTIPAGOS where FECHA_REFERENCIAS=convert(date,getdate()) order by REF_CTE desc")(0).REF_CTE + 1
            Catch ex As Exception
                llave.REF_CTE = 25100
            End Try

            vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.Add(llave)
            vgObjModelo.SaveChanges()

            Dim sv = New VENTATELCEL()
            'Dim respuesta = sv.Venta(Convert.ToDouble(Me.txtNumber.Text), Me.txtConfirmNumber.Text, ViewState("servicioseleccionado").ToString(), String.Empty)
            Dim respuesta = sv.Venta(Convert.ToDouble(Me.txtNumber.Text), Me.txtConfirmNumber.Text, ViewState("servicioseleccionado").ToString(), String.Empty)
            Dim correcto As Boolean = False
            Dim CODIGORESPUESTA As String = ""
            Dim ErrorDescripcion As String = ""
            Dim estado As New BACK_CODE.ProntipagosTopUpService.transactionResponseTO

            For i As Integer = 0 To 40 Step 1
                estado = sv.ValidaEstatusTransaccion(respuesta.transactionId, 1)
                'estado = sv.ValidaEstatusTransaccion(respuesta.transactionId, 1)

                CODIGORESPUESTA = String.Empty
                CODIGORESPUESTA = estado.codeTransaction
                If (CODIGORESPUESTA.Equals("00")) Then
                    correcto = True
                    Me.lblMessage.Text = ""
                    Exit For
                End If

                If Not CODIGORESPUESTA.Equals("00") And Not estado.codeDescription.Equals("Procesando Transaccion") Then ' si no regresa procesando "N/A" o exitosa "00" 
                    'entonces regreso algun codigo de error se pone la transaccion  en false y se manda la descripcion del error que regresa el servicio 
                    correcto = False
                    ErrorDescripcion = estado.codeDescription
                    Try
                        If respuesta.codeDescription = String.Empty Then
                            Me.lblMessage.Text = ErrorDescripcion
                        Else
                            Me.lblMessage.Text = ErrorDescripcion
                        End If
                    Catch ex As Exception
                        Me.lblMessage.Text = ErrorDescripcion
                    End Try

                    Exit For ' se sale del ciclo
                End If

                If CODIGORESPUESTA.Equals("N/A") Then
                    System.Threading.Thread.Sleep(1000) ' espera dos segundos para volver a revisar el estado de la transaccion 
                End If
            Next

            If correcto = True Then
                Dim dtResumen As DataTable
                Dim drAdd As DataRow
                'confirmmo que la transacción fue exitosa
                'vgObjModelo = New EDM_TopItUp
                Dim cvellave As LLAVES_TRANS_SODESI_PRONTIPAGOS = vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.Find(llave.PK_LLAVE_TRANS_SODESI_PRONTIPAGOS)
                cvellave.PROCESADA = 1
                vgObjModelo.SaveChanges()

                If Session("dtResumen") Is Nothing Then
                    dtResumen = New DataTable
                    dtResumen.Columns.Add("FECHA", GetType(String))
                    dtResumen.Columns.Add("HORA", GetType(String))
                    dtResumen.Columns.Add("NUMERO", GetType(String))
                    dtResumen.Columns.Add("MONTO", GetType(String))
                    dtResumen.Columns.Add("COMPANIA", GetType(String))
                    dtResumen.Columns.Add("FOLIO_TRANS", GetType(String))
                    Session("dtResumen") = dtResumen
                Else
                    dtResumen = CType(Session("dtResumen"), DataTable)
                End If

                drAdd = dtResumen.NewRow()
                Dim dteFechaMvto As DateTime = Date.Now
                drAdd("FECHA") = DateTime.Now.ToShortDateString()

                'ESTO PUEDE CAUSAR PROBLEMAS SI EL SERVIDOR NO TIENE ESE FORMATO DE FECHA , REGULARMENTE ESTAN EN INGLES 
                'drAdd("FECHA") = CDate(Date.Now).Date.Day & "/" & CDate(Date.Now).Date.Month & "/" & CDate(Date.Now).Date.Year

                drAdd("HORA") = Date.Now.Hour & ":" & Date.Now.Minute
                drAdd("NUMERO") = Trim(Me.txtConfirmNumber.Text)
                drAdd("MONTO") = Convert.ToDouble(Me.txtNumber.Text)
                drAdd("COMPANIA") = Me.ddlServicio.SelectedItem.Text  'ViewState("DESC_SERVICIO")  '"PONER LA DESCRIPCIÓN DEL SERVICIO QUE SE SELECIONÓ" 'lblCompany.Text
                drAdd("FOLIO_TRANS") = estado.folioTransaction & " / " & estado.transactionId
                dtResumen.Rows.Add(drAdd)
                dtResumen.AcceptChanges()

                Dim objUser As New USERS
                objUser = clsGeneric.func_GetUsrConnected(CType(Session("USR_CONNECTED"), Integer))

                'Agregamos la transacción generada por la recarga telefónica
                Dim objTrans As New TRANSACCIONES
                objTrans.FECHA = drAdd("FECHA")
                objTrans.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente

                'Este deberá ser el seleccionado y no deberá ser FIJO
                'objTrans.FK_CAT_SERVICIO =  INDICAR EL SERVICIO QUE SE SOLICITÓ
                objTrans.FK_CAT_TIPO_MVTO = 2 'Pago de Servicios
                objTrans.FK_USER = objUser.PK_USER  ' propVgObjCliente.PK_CLIENTE
                objTrans.FOLIO = estado.folioTransaction
                objTrans.HORA = drAdd("HORA")
                objTrans.MONTO_MTO = Convert.ToDecimal(Me.txtNumber.Text) 'drAdd("MONTO")
                objTrans.NUMERO_RECARGA = Trim(Me.txtConfirmNumber.Text)
                objTrans.TRANSACCION = estado.transactionId
                objTrans.FK_CAT_SERVICIO = Convert.ToInt32(Me.ddlServicio.SelectedValue)

                Dim mail As New BACK_CODE.EnviaCorreo()
                Try
                    vgObjModelo.TRANSACCIONES.Add(objTrans)
                    'Guardamos la transacción
                    vgObjModelo.SaveChanges()
                Catch ex As Exception
                    Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message

                    Try
                        mail.EnviaCorreo(Me.lblMessage.Text, "ERROR EN APLICACIÓN :: PAGO DE SERVICIOS", True)
                    Catch ex1 As Mail.SmtpException
                        Me.lblMessage.Text &= " ** " & ex1.Message
                    End Try
                End Try

                'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
                Dim objSaldo As New SALDOS
                objSaldo.FK_TRANSACCION = objTrans.PK_TRANSACCION
                objSaldo.FECHA_MVTO = dteFechaMvto
                objSaldo.MONTO_MVTO = objTrans.MONTO_MTO
                objSaldo.FK_USER = objUser.PK_USER  'Me.propVgObjCliente.PK_CLIENTE
                'Aquí recupero el saldo del cliente y le resto la recarga
                objSaldo.SALDO = clsGeneric.func_GetSaldoUsr(vgPropObjUserConnected.PK_USER) - objTrans.MONTO_MTO
                lblSaldoCliente.Text = objSaldo.SALDO

                Try
                    vgObjModelo.SALDOS.Add(objSaldo)
                    'Guardamos la transacción
                    vgObjModelo.SaveChanges()
                    Me.lblSaldoCliente.Text = objSaldo.SALDO
                Catch ex As Exception
                    Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
                    Try
                        mail.EnviaCorreo(Me.lblMessage.Text, "ERROR EN APLICACIÓN :: PAGO DE SERVICIOS", True)
                    Catch ex1 As Mail.SmtpException
                        Me.lblMessage.Text &= " ** " & ex1.Message
                    End Try
                End Try


                'AQUI SE VAN A AGREGAR SEIS PESOS AL ADMMAESTRO Y SE DESCONTARAN 6 PESOS AL CLIENTE 

                objSaldo = New SALDOS()
                objSaldo.FK_PAGO = objTrans.PK_TRANSACCION
                objSaldo.FECHA_MVTO = dteFechaMvto
                objSaldo.MONTO_MVTO = Convert.ToDecimal(6)
                objSaldo.FK_USER = objUser.PK_USER
                objSaldo.SALDO = clsGeneric.func_GetSaldoUsr(vgPropObjUserConnected.PK_USER) - objTrans.MONTO_MTO
                lblSaldoCliente.Text = objSaldo.SALDO
                Try
                    vgObjModelo.SALDOS.Add(objSaldo)
                    'Guardamos la transacción
                    vgObjModelo.SaveChanges()
                    Me.lblSaldoCliente.Text = objSaldo.SALDO
                Catch ex As Exception
                    Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
                    Try
                        mail.EnviaCorreo(Me.lblMessage.Text, "ERROR EN APLICACIÓN :: PAGO DE SERVICIOS", True)
                    Catch ex1 As Mail.SmtpException
                        Me.lblMessage.Text &= " ** " & ex1.Message
                    End Try
                End Try

                objSaldo = New SALDOS()
                objSaldo.FK_PAGO = objTrans.PK_TRANSACCION
                objSaldo.FECHA_MVTO = dteFechaMvto
                objSaldo.MONTO_PAGO = Convert.ToDecimal(6)
                objSaldo.FK_USER = 1
                objSaldo.SALDO = clsGeneric.func_GetSaldoUsr(vgPropObjUserConnected.PK_USER) + Convert.ToDecimal(6)
                lblSaldoCliente.Text = objSaldo.SALDO

                Try
                    vgObjModelo.SALDOS.Add(objSaldo)
                    'Guardamos la transacción
                    vgObjModelo.SaveChanges()
                    Me.lblSaldoCliente.Text = objSaldo.SALDO
                Catch ex As Exception
                    Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
                    Try
                        mail.EnviaCorreo(Me.lblMessage.Text, "ERROR EN APLICACIÓN :: PAGO DE SERVICIOS", True)
                    Catch ex1 As Mail.SmtpException
                        Me.lblMessage.Text &= " ** " & ex1.Message
                    End Try
                End Try


                'Me.grdResumenRecargas.DataSource = Session("dtResumen")
                Me.grdResumenRecargas.Dispose()
                Me.grdResumenRecargas.DataBind()

                Me.txtNumber.Text = String.Empty
                txtConfirmNumber.Text = String.Empty
                Me.lblMessage.Text = String.Empty
                Me.lblMessage.Style.Remove("color")
                Me.lblMessage.Style.Add("color", "green")
                Me.lblMessage.Text = "Transacción exitosa con número de Folio " & estado.folioTransaction & " y transacción " & estado.transactionId

                Try
                    mail.EnviaCorreo("PAGO DE SERVICIO " & Me.ddlServicio.SelectedItem.Text & " :: " & Me.lblMessage.Text, "PAGO DE SERVICIOS " & Me.ddlServicio.SelectedItem.Text & " EXITOSO", True)
                    Dim strmsg As String = String.Empty
                    strmsg += "ESTIMADO CLIENTE COMO LO SOLICITO MANDAMOS LOS DATOS DE SU PAGO DE SERVICIO" + vbCr
                    strmsg += "FECHA: " + DateTime.Now.ToShortDateString() + vbCr
                    strmsg += "HORA: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + vbCr
                    strmsg += "SERVICIO: " + ddlServicio.SelectedItem.Text + vbCr
                    strmsg += "CANTIDAD: " + Me.txtConfirmNumber.Text + vbCr
                    mail.EnviaCorreoIndividual(strmsg, "PAGO DE SERVICIO", 3, Me.txtCorreoInforme.Text)

                Catch ex1 As Mail.SmtpException
                    Me.lblMessage.Text &= " ** " & ex1.Message
                End Try
            Else

                Dim strBase As String = "Transacción no disponible, ha sido notificado al administrador del sistema, en breve nos comunicaremos con usted a los registros que nos proporcionó: "
                Try
                    If respuesta.codeDescription = String.Empty Then
                        Me.lblMessage.Text = strBase & ErrorDescripcion
                    Else
                        Me.lblMessage.Text = strBase & respuesta.codeDescription
                    End If
                Catch ex As Exception
                    Me.lblMessage.Text = strBase & ErrorDescripcion
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class


