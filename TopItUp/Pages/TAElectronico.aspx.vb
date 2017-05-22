Imports BACK_CODE
Imports TopItUp.Helpers
Imports BACK_CODE.EnviaCorreo
Imports System.Net
Imports System.Globalization
Imports TopItUp.StringExtension

Public Class TAElectronico
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
    Private Function Recarga_MultiWebService(clsGeneric As clsGenerics) As Boolean
        'prueba
        'Return False

        Dim vta As New MultiWebServiceMX()
        vta = New MultiWebServiceMX()

        Dim blnExitosa As Boolean = False ' se inicia en false por si termina el ciclo de 1 min y siempre regreso "N/A" en caso de ser "00" se pasa a True 
        Dim strReferencia As String = String.Empty
        Dim strSKU As String = String.Empty
        Dim strRefCte As String = String.Empty

        strReferencia = Me.txtConfirmNumber.Text
        Dim arResult As ArrayList

        Try
            Dim _Cantidad = Convert.ToInt32(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            arResult = vta.Venta(Me.ddlCompania.SelectedItem.Text, strReferencia, _Cantidad) ' AQUI HAY Q PASAR LOS PARAMETROS DE SKU NUMERO Y MONTO... 

            'Mayor a 1 correcta, 1 corresponde a recarga consecutiva mismo número y 0 incorrecta.
            blnExitosa = arResult.Count > 1

            If arResult.Count = 1 Then 'Recarga incorrecta por error o por recarga consecutiva mismo número

                blnExitosa = True
                lblMessage.Text = "ERROR: " + arResult.Item(0).ToString()

                Return blnExitosa
            End If

        Catch ex As Exception
            blnExitosa = False
        End Try

        If blnExitosa Then
            Dim dtResumen As DataTable
            Dim drAdd As DataRow

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
            drAdd("HORA") = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
            drAdd("NUMERO") = Trim(Me.txtNumber.Text)
            drAdd("MONTO") = ViewState("MontoSeleccionado")
            drAdd("COMPANIA") = lblCompany.Text
            drAdd("FOLIO_TRANS") = arResult.Item(1).ToString & " / " & arResult.Item(2).ToString
            dtResumen.Rows.Add(drAdd)
            dtResumen.AcceptChanges()

            Dim modelo As New EDM_TopItUp
            Dim objTransTAE As New TRANSACCIONES
            'Agregamos la transacción generada por la recarga telefónica
            objTransTAE.FECHA = drAdd("FECHA")
            objTransTAE.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente

            'Este deberá ser el seleccionado y no deberá ser FIJO
            objTransTAE.FK_CAT_TELEFONIA = Convert.ToInt32(Me.ddlCompania.SelectedValue)
            objTransTAE.FK_CAT_TIPO_MVTO = 1 'Recarga telefónica
            objTransTAE.FK_USER = Me.vgPropObjUserConnected.PK_USER
            objTransTAE.FK_CAT_WS = 1
            objTransTAE.HORA = drAdd("HORA")
            objTransTAE.MONTO_MTO = drAdd("MONTO")
            objTransTAE.NUMERO_RECARGA = drAdd("NUMERO")
            objTransTAE.FOLIO = arResult.Item(1).ToString
            objTransTAE.TRANSACCION = arResult.Item(2).ToString

            Dim mail As New BACK_CODE.EnviaCorreo()
            Try
                modelo.TRANSACCIONES.Add(objTransTAE)
                'Guardamos la transacción
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message

                Try
                    mail.EnviaCorreo("Error Recarga TAE MultiWeb MX: " & Me.lblMessage.Text, "ERROR TAE " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try

            If Convert.ToBoolean(Session("isCajero")) = True Then
                Dim idCajero As Integer = Convert.ToInt32(Session("idCajero"))
                Dim trancajero As New TRANSACCIONES_CAJERO()
                trancajero.FK_CAJERO = idCajero
                trancajero.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
                modelo.TRANSACCIONES_CAJERO.Add(trancajero)
                Try
                    modelo.SaveChanges()
                Catch ex As Exception
                    Me.lblMessage.Text += ex.Message
                End Try
            End If

            '/*******************************************************************************/
            '/************************************ CARGO ************************************/
            '/*******************************************************************************/
            modelo = New EDM_TopItUp
            'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
            Dim objSaldoCargo As New SALDOS
            objSaldoCargo.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
            objSaldoCargo.FECHA_MVTO = dteFechaMvto
            objSaldoCargo.MONTO_MVTO = objTransTAE.MONTO_MTO
            objSaldoCargo.FK_USER = Me.vgPropIntCveUserConnected
            'Aquí recupero el saldo del cliente y le resto la recarga
            objSaldoCargo.SALDO = clsGeneric.func_GetSaldoUsr(Me.vgPropIntCveUserConnected) - objTransTAE.MONTO_MTO
            lblSaldoCliente.Text = objSaldoCargo.SALDO
            TopBar.saldocontrol = objSaldoCargo.SALDO.ToString()

            Try
                modelo.SALDOS.Add(objSaldoCargo)
                'Guardamos la transacción
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
                Try
                    mail.EnviaCorreo("ERROR RECARGA TAE: " & Me.lblMessage.Text, "ERROR RECARGA TAE", True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try

            End Try

            '/*******************************************************************************/
            '/************************************ ABONO ************************************/
            '/*******************************************************************************/
            'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
            Dim objCtePadre As CLIENTES
            Dim objUserPadre As USERS

            objCtePadre = New CLIENTES
            objUserPadre = New USERS

            If Not Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Then ' Si la sucursal tiene cliente padre entonces registra la comisión al padre
                objCtePadre = modelo.CLIENTES.Find(Me.vgPropObjCteConnected.FK_CLIENTE_PADRE)
                objUserPadre = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.PK_CLIENTE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadre, Me.vgPropObjUserConnected)
            End If

            'Si el padre tiene a su vez cliente padre entonces agrego la comisión al nivel 1
            If Not objCtePadre.FK_CLIENTE_PADRE Is Nothing Then ' Si la matriz tiene cliente padre entonces registra la comisión al padre (adm maestro comunmente)
                Dim objUserPadreNivel1 As USERS = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.FK_CLIENTE_PADRE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadreNivel1, objUserPadre)
            End If

            'COMISIÓN DEL USUARIO CONECTADO
            Dim vlDecMontoComisionUsr As Decimal = clsGeneric.func_GetComisionPorTransaccion(Convert.ToInt32(Me.ddlCompania.SelectedValue), objTransTAE.MONTO_MTO, vgPropObjUserConnected)

            '/* LE AGREGO LA COMISIÓN AL CLIENTE CONECTADO */
            modelo = New EDM_TopItUp
            Dim objSaldoAbono As New SALDOS
            objSaldoAbono.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
            objSaldoAbono.FECHA_MVTO = dteFechaMvto
            objSaldoAbono.MONTO_PAGO = vlDecMontoComisionUsr
            objSaldoAbono.FK_USER = Me.vgPropIntCveUserConnected   'Me.propVgObjCliente.PK_CLIENTE
            'Aquí recupero el saldo del cliente y le aumento la comisión
            objSaldoAbono.SALDO = clsGeneric.func_GetSaldoUsr(vgPropIntCveUserConnected) + vlDecMontoComisionUsr
            lblSaldoCliente.Text = objSaldoAbono.SALDO
            TopBar.saldocontrol = lblSaldoCliente.Text

            Try
                modelo.SALDOS.Add(objSaldoAbono)
                'Guardamos la transacción
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su comisión, se ha notificado al administrador del sistema: " & ex.Message
                Try
                    mail.EnviaCorreo("ERROR TAE Multiweb MX :: " & Me.lblMessage.Text, "RECARGA TAE CON ERROR :: " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try

            'Me.grdResumenRecargas.DataSource = Session("dtResumen")
            Me.grdResumenRecargas.Dispose()
            Me.grdResumenRecargas.DataBind()

            Me.txtNumber.Text = String.Empty
            txtConfirmNumber.Text = String.Empty
            Me.lblMessage.Text = String.Empty
            Me.lblInfoRecarga.Text = String.Empty
            Session("MSG1") = "Transacción exitosa con número de Folio " & arResult.Item(1).ToString & " y transacción " & arResult.Item(2).ToString & ""
            Me.lblMessage.Text = Session("MSG1")

            Try
                mail.EnviaCorreo("USUARIO: " & Me.vgPropObjUserConnected.USERNAME & " :: Recarga TAE <b>$" & objTransTAE.MONTO_MTO & "</b> Exitosa MultiWeb MX, TRANS: " & arResult.Item(2).ToString & " NÚMERO: " & objTransTAE.NUMERO_RECARGA, "ÉXITO EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, False)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
        Else
            Try
                Me.lblMessage.Text = "Transacción no disponible [" & Me.lblMessage.Text & "], ha sido notificado al administrador del sistema."
            Catch ex As Exception
                Me.lblMessage.Text = "Transacción no disponible, ha sido notificado al administrador del sistema, en breve el servicio estará disponible."
            End Try

            If blnExitosa Then
                ViewState.Clear()
            End If

            'Response.Redirect("TAElectronico.aspx")

        End If

        Return blnExitosa
    End Function

    Private Sub sub_AddComisionSaldoClientePadre(objTransTAE As TRANSACCIONES, dteFechaMvto As Date, objUserPadre As USERS, objUsrHijo As USERS)
        Dim mail As New BACK_CODE.EnviaCorreo()

        'COMISIÓN DEL PADRE AL QUE PERTENECE EL USUARIO CONECTADO
        Dim modelo As EDM_TopItUp = New EDM_TopItUp
        Dim clsGeneric As New clsGenerics
        Dim vlDecMontoComisionUsrPadre As Decimal
        Dim vlDecMontoComisionUsrHijo As Decimal
        Dim vlDecComPadreFinal As Decimal
        Try
            vlDecMontoComisionUsrPadre = clsGeneric.func_GetPorcenComisionUsrConnected(Convert.ToInt32(Me.ddlCompania.SelectedValue), objUserPadre)
            vlDecMontoComisionUsrHijo = clsGeneric.func_GetPorcenComisionUsrConnected(Convert.ToInt32(Me.ddlCompania.SelectedValue), objUsrHijo)
            vlDecComPadreFinal = vlDecMontoComisionUsrPadre - vlDecMontoComisionUsrHijo  ' obtengo el porcentaje de comisión diferencial que le corresponde al padre
            vlDecComPadreFinal = (vlDecComPadreFinal * objTransTAE.MONTO_MTO) / 100 'monto que le corresponde al padre según la comisión calculada
        Catch ex As Exception
            'vlDecMontoComisionUsrPadre = 0.0
            vlDecComPadreFinal = 0.0
        End Try

        '/* LE AGREGO LA COMISIÓN AL CLIENTE PADRE */
        Dim objSaldoAbonoCtePadre As New SALDOS
        objSaldoAbonoCtePadre.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
        objSaldoAbonoCtePadre.FECHA_MVTO = dteFechaMvto
        objSaldoAbonoCtePadre.MONTO_PAGO = vlDecComPadreFinal 'vlDecMontoComisionUsrPadre
        objSaldoAbonoCtePadre.FK_USER = objUserPadre.PK_USER
        'Aquí recupero el saldo del cliente y le aumento la comisión
        objSaldoAbonoCtePadre.SALDO = clsGeneric.func_GetSaldoUsr(objUserPadre.PK_USER) + vlDecComPadreFinal 'vlDecMontoComisionUsr

        Try
            'mail.EnviaCorreo("SALDO CTE PADRE TRANS " & objSaldoAbonoCtePadre.FK_TRANSACCION & " : " & objSaldoAbonoCtePadre.SALDO, "SALDO CTE PADRE POR RECARGA", True)
        Catch exX As Exception
            'Me.lblMessage.Text = exX.Message
        End Try

        Try
            modelo.SALDOS.Add(objSaldoAbonoCtePadre)
            'Guardamos la comisión del cte. padre al que pertenece el usuario como saldo (ABONO)
            modelo.SaveChanges()
        Catch ex As Exception
            Me.lblMessage.Text = "No es posible realizar la actualización de la comisión del cliente superior " & objUserPadre.PK_USER & ", se ha notificado al administrador del sistema: " & ex.Message
            Try
                mail.EnviaCorreo("ERROR TAE Multiweb MX :: " & Me.lblMessage.Text, "RECARGA TAE CON ERROR :: " & Me.ddlCompania.SelectedItem.Text, True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
        End Try
    End Sub

    Private Function Recarga_Isend(clsGeneric As clsGenerics) As Boolean
        'Return False
        Dim vta As New ServiceIsend()
        Dim blnExitosa As Boolean = False ' se inicia en false por si termina el ciclo de 1 min y siempre regreso "N/A" en caso de ser "00" se pasa a True 

        Dim iservice As New com.isendonline.test.iSendService()
        Dim jsjs2 As New com.isendonline.test.ListOfBillersRequest()
        Dim jsjs3 As New com.isendonline.test.ListOfCountryRequest()

        Dim strReferencia As String = String.Empty
        Dim strSKU As String = String.Empty
        Dim strRefCte As String = String.Empty
        Dim respuesta As New BACK_CODE.ReferenceIsend.PostPaymentResponse

        strReferencia = Me.txtConfirmNumber.Text

        Try
            Dim _Cantidad = Convert.ToInt32(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            respuesta = vta.Venta(_Cantidad, strReferencia, Me.ddlCompania.SelectedItem.Text) ' AQUI HAY Q PASAR LOS PARAMETROS DE SKU NUMERO Y MONTO... 
        Catch ex As Exception
            blnExitosa = False
            If ex.Message.Contains("Monto no disponible isend") Then
                Me.lblMessage.Text = "MONTO NO DISPONIBLE, O COMPAÑIA INCORRECTA NO SE PUEDE REALIZAR RECARGA EL NUMERO INDICADO EN ESTA COMPAÑIA O POR ESTE MONTO"
                Return False
            End If
            Return blnExitosa
        End Try

        If (respuesta Is Nothing Or (respuesta.TransactionID = 0) Or (respuesta.Status = 3) Or (respuesta.Status = 4) Or (respuesta.ErrorCodes.Length > 0)) Then
            blnExitosa = False
        Else
            blnExitosa = True
        End If

        Dim Mail As New BACK_CODE.EnviaCorreo

        If blnExitosa Then
            Dim dtResumen As DataTable
            Dim drAdd As DataRow

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
            drAdd("HORA") = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
            drAdd("NUMERO") = Trim(Me.txtNumber.Text)
            drAdd("MONTO") = ViewState("MontoSeleccionado")
            drAdd("COMPANIA") = lblCompany.Text
            drAdd("FOLIO_TRANS") = respuesta.TransactionID
            dtResumen.Rows.Add(drAdd)
            dtResumen.AcceptChanges()

            'Agregamos la transacción generada por la recarga telefónica
            Dim objTrans As New TRANSACCIONES
            objTrans.FECHA = drAdd("FECHA")
            objTrans.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente

            'Este deberá ser el seleccionado y no deberá ser FIJO
            objTrans.FK_CAT_TELEFONIA = Convert.ToInt32(Me.ddlCompania.SelectedValue)
            objTrans.FK_CAT_TIPO_MVTO = 1 'Recarga telefónica
            objTrans.FK_USER = Me.vgPropObjUserConnected.PK_USER
            objTrans.FOLIO = respuesta.TransactionID
            objTrans.FK_CAT_WS = 2
            objTrans.HORA = drAdd("HORA")
            objTrans.MONTO_MTO = drAdd("MONTO")
            objTrans.NUMERO_RECARGA = drAdd("NUMERO")
            objTrans.TRANSACCION = respuesta.TransactionID

            Try
                vgObjModelo = New EDM_TopItUp()
                vgObjModelo.TRANSACCIONES.Add(objTrans)
                'Guardamos la transacción
                vgObjModelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message & " FOLIO: " & objTrans.TRANSACCION
                Try
                    Mail.EnviaCorreo("ERROR RECARGA iSend: " & Me.lblMessage.Text, "ERROR EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try

            '/*******************************************************************************/
            '/************************************ CARGO ************************************/
            '/*******************************************************************************/

            'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
            Dim objSaldoCargo As New SALDOS
            objSaldoCargo.FK_TRANSACCION = objTrans.PK_TRANSACCION
            objSaldoCargo.FECHA_MVTO = dteFechaMvto
            objSaldoCargo.MONTO_MVTO = objTrans.MONTO_MTO
            objSaldoCargo.FK_USER = vgPropIntCveUserConnected
            'Aquí recupero el saldo del cliente y le resto la recarga
            objSaldoCargo.SALDO = clsGeneric.func_GetSaldoUsr(vgPropIntCveUserConnected) - objTrans.MONTO_MTO
            lblSaldoCliente.Text = objSaldoCargo.SALDO
            TopBar.saldocontrol = lblSaldoCliente.Text

            Try
                vgObjModelo.SALDOS.Add(objSaldoCargo)
                'Guardamos la transacción
                vgObjModelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message

                Try
                    Mail.EnviaCorreo("Error Recarga TAE ISEMD MX: " & Me.lblMessage.Text, "ERROR TAE " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try

            '/*******************************************************************************/
            '/************************************ ABONO ************************************/
            '/*******************************************************************************/

            Dim objCtePadre As CLIENTES
            Dim objUserPadre As USERS

            objCtePadre = New CLIENTES
            objUserPadre = New USERS

            Dim modelo = vgObjModelo
            Dim objTransTAE = objTrans

            If Not Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Then ' Si la sucursal tiene cliente padre entonces registra la comisión al padre
                objCtePadre = modelo.CLIENTES.Find(Me.vgPropObjCteConnected.FK_CLIENTE_PADRE)
                objUserPadre = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.PK_CLIENTE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadre, Me.vgPropObjUserConnected)
            End If

            'Si el padre tiene a su vez cliente padre entonces agrego la comisión al nivel 1
            If Not objCtePadre.FK_CLIENTE_PADRE Is Nothing Then ' Si la matriz tiene cliente padre entonces registra la comisión al padre (adm maestro comunmente)
                Dim objUserPadreNivel1 As USERS = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.FK_CLIENTE_PADRE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadreNivel1, objUserPadre)
            End If

            'COMISIÓN DEL USUARIO CONECTADO
            Dim vlDecMontoComisionUsr As Decimal = clsGeneric.func_GetComisionPorTransaccion(Convert.ToInt32(Me.ddlCompania.SelectedValue), objTransTAE.MONTO_MTO, vgPropObjUserConnected)

            '/* LE AGREGO LA COMISIÓN AL CLIENTE CONECTADO */
            modelo = New EDM_TopItUp
            Dim objSaldoAbono As New SALDOS
            objSaldoAbono.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
            objSaldoAbono.FECHA_MVTO = dteFechaMvto
            objSaldoAbono.MONTO_PAGO = vlDecMontoComisionUsr
            objSaldoAbono.FK_USER = Me.vgPropIntCveUserConnected   'Me.propVgObjCliente.PK_CLIENTE
            'Aquí recupero el saldo del cliente y le aumento la comisión
            objSaldoAbono.SALDO = clsGeneric.func_GetSaldoUsr(vgPropIntCveUserConnected) + vlDecMontoComisionUsr
            lblSaldoCliente.Text = objSaldoAbono.SALDO
            TopBar.saldocontrol = lblSaldoCliente.Text

            Try
                vgObjModelo.SALDOS.Add(objSaldoAbono)
                'Guardamos la transacción
                vgObjModelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su comisión, se ha notificado al administrador del sistema: " & ex.Message & " FOLIO: " & objTrans.TRANSACCION
                Try
                    Mail.EnviaCorreo("ERROR RECARGA iSend: " & Me.lblMessage.Text, "ERROR EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try


            ''LUEGO AQUI SE TIENE QUE GUARDAR LA COMISION AL ADM MAESTRO 
            Me.grdResumenRecargas.Dispose()
            Me.grdResumenRecargas.DataBind()

            Me.txtNumber.Text = String.Empty
            txtConfirmNumber.Text = String.Empty
            Me.lblMessage.Text = String.Empty
            Me.lblInfoRecarga.Text = String.Empty
            Me.lblMessage.Text = "Transacción exitosa con número de Folio " & respuesta.TransactionID & " y transacción " & respuesta.TransactionID
            Try
                Mail.EnviaCorreo("Recarga Exitosa Isend :: " & Me.lblMessage.Text, "RECARGA TAE EXITOSA :: " & Me.ddlCompania.SelectedItem.Text, True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
        Else
            Me.lblMessage.Text = "Transacción no disponible, ha sido notificado al administrador del sistema, en breve nos comunicaremos con usted a los registros que nos proporcionó." '& ErrorDescripcion
            blnExitosa = False
        End If

        Return blnExitosa
    End Function

    Private Function RecargaTeria(clsGenric As clsGenerics) As Boolean
        Try
            Dim PhoneNumer As String = Me.txtConfirmNumber.Text.Trim()
            Dim _Cantidad = Convert.ToInt32(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            Dim compani = Me.ddlCompania.SelectedItem.Text.Trim().ToLower()
            Dim fechacortahoy = DateTime.Now.ToShortDateString()

            Using ef As New EDM_TopItUp()

                Dim fec = DateTime.Now
                Dim anio = fec.Year
                Dim mes = fec.Month
                Dim dia = fec.Day


                Dim datoshoy = ef.NVOINTEGRATICKET.ToList().Where(Function(x) x.ANIO.Equals(anio) And x.MES.Equals(mes) And x.DIA.Equals(dia)).FirstOrDefault()

                Dim integra As New BACK_CODE.IntegraWsDatos()
                If datoshoy Is Nothing Then

                    Dim respuestalogin = integra.Login()
                    If (respuestalogin.Contains("<error>")) Then
                        Return False
                    End If

                    Dim tk = respuestalogin.GetValueFromStringXml("<ticket>")
                    Dim si = respuestalogin.GetValueFromStringXml("<storeId>")
                    Dim accountno = respuestalogin.GetValueFromStringXml("<accountNo>")
                    Dim idcompany = respuestalogin.GetValueFromStringXml("<companyid>")

                    Dim insertaticket As New NVOINTEGRATICKET()
                    insertaticket.ticket = tk
                    insertaticket.idTienda = si

                    insertaticket.idCompania = idcompany

                    insertaticket.noCuenta = accountno
                    insertaticket.ANIO = anio
                    insertaticket.MES = mes
                    insertaticket.DIA = dia
                    ef.NVOINTEGRATICKET.Add(insertaticket)
                    ef.SaveChanges()

                    datoshoy = Nothing
                    datoshoy = insertaticket
                End If

                Dim ticket = datoshoy.ticket
                Dim storedid = Convert.ToInt32(datoshoy.idTienda)
                Dim acountno = datoshoy.noCuenta


                Dim vta = integra.Venta(ticket, storedid, acountno, _Cantidad, PhoneNumer, compani)

                If Not vta.Contains("<error>") Then

                    If Not vta.GetValueFromStringXml("<trnresponse>") = "00" Then
                        Return False
                    End If

                    Dim transaccion As String = vta.GetValueFromStringXml("<externalId>")
                    Dim _folio = vta.GetValueFromStringXml("<trntelcel>")

                    Dim objtransaccion As New TRANSACCIONES()
                    objtransaccion.HORA = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
                    objtransaccion.FECHA = DateTime.Now
                    objtransaccion.FK_CAT_WS = 4
                    objtransaccion.TRANSACCION = transaccion
                    objtransaccion.FK_USER = Me.vgPropObjUserConnected.PK_USER
                    objtransaccion.FOLIO = _folio
                    objtransaccion.FK_CAT_MEDIO_DE_PAGO = 1
                    objtransaccion.FK_CAT_TELEFONIA = Convert.ToInt32(Me.ddlCompania.SelectedValue)
                    objtransaccion.FK_CAT_TIPO_MVTO = 1
                    objtransaccion.MONTO_MTO = Convert.ToDecimal(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
                    objtransaccion.NUMERO_RECARGA = Me.txtConfirmNumber.Text.Trim()
                    ef.TRANSACCIONES.Add(objtransaccion)
                    ef.SaveChanges()

                    Dim objSaldoCargo As New SALDOS
                    objSaldoCargo.FK_TRANSACCION = objtransaccion.PK_TRANSACCION
                    objSaldoCargo.FECHA_MVTO = DateTime.Now
                    objSaldoCargo.MONTO_MVTO = objtransaccion.MONTO_MTO
                    objSaldoCargo.FK_USER = Me.vgPropIntCveUserConnected
                    objSaldoCargo.SALDO = clsGenric.func_GetSaldoUsr(Me.vgPropIntCveUserConnected) - objtransaccion.MONTO_MTO
                    lblSaldoCliente.Text = objSaldoCargo.SALDO
                    TopBar.saldocontrol = lblSaldoCliente.Text
                    ef.SALDOS.Add(objSaldoCargo)
                    ef.SaveChanges()


                    '/*******************************************************************************/
                    '/************************************ ABONO ************************************/
                    '/*******************************************************************************/
                    'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
                    Dim objCtePadre As CLIENTES
                    Dim objUserPadre As USERS

                    objCtePadre = New CLIENTES
                    objUserPadre = New USERS

                    If Not Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Then ' Si la sucursal tiene cliente padre entonces registra la comisión al padre
                        objCtePadre = ef.CLIENTES.Find(Me.vgPropObjCteConnected.FK_CLIENTE_PADRE)
                        objUserPadre = ef.USERS.Find(clsGenric.func_GetUserByCliente(objCtePadre.PK_CLIENTE))
                        sub_AddComisionSaldoClientePadre(objtransaccion, DateTime.Now, objUserPadre, Me.vgPropObjUserConnected)
                    End If

                    'Si el padre tiene a su vez cliente padre entonces agrego la comisión al nivel 1
                    If Not objCtePadre.FK_CLIENTE_PADRE Is Nothing Then ' Si la matriz tiene cliente padre entonces registra la comisión al padre (adm maestro comunmente)
                        Dim objUserPadreNivel1 As USERS = ef.USERS.Find(clsGenric.func_GetUserByCliente(objCtePadre.FK_CLIENTE_PADRE))
                        sub_AddComisionSaldoClientePadre(objtransaccion, DateTime.Now, objUserPadreNivel1, objUserPadre)
                    End If

                    'COMISIÓN DEL USUARIO CONECTADO
                    Dim vlDecMontoComisionUsr As Decimal = clsGenric.func_GetComisionPorTransaccion(Convert.ToInt32(Me.ddlCompania.SelectedValue), objtransaccion.MONTO_MTO, vgPropObjUserConnected)

                    '/* LE AGREGO LA COMISIÓN AL CLIENTE CONECTADO */
                    Dim objSaldoAbono As New SALDOS
                    objSaldoAbono.FK_TRANSACCION = objtransaccion.PK_TRANSACCION
                    objSaldoAbono.FECHA_MVTO = DateTime.Now
                    objSaldoAbono.MONTO_PAGO = vlDecMontoComisionUsr
                    objSaldoAbono.FK_USER = Me.vgPropIntCveUserConnected   'Me.propVgObjCliente.PK_CLIENTE
                    'Aquí recupero el saldo del cliente y le aumento la comisión
                    objSaldoAbono.SALDO = clsGenric.func_GetSaldoUsr(vgPropIntCveUserConnected) + vlDecMontoComisionUsr
                    lblSaldoCliente.Text = objSaldoAbono.SALDO
                    TopBar.saldocontrol = lblSaldoCliente.Text
                    Dim mail As New BACK_CODE.EnviaCorreo

                    Try
                        ef.SALDOS.Add(objSaldoAbono)
                        'Guardamos la transacción
                        ef.SaveChanges()
                    Catch ex As Exception
                        Me.lblMessage.Text = "No es posible realizar la actualización de su comisión, se ha notificado al administrador del sistema: " & ex.Message
                        Try
                            mail.EnviaCorreo("ERROR TAE TERIA:: " & Me.lblMessage.Text, "RECARGA TAE CON ERROR :: " & Me.ddlCompania.SelectedItem.Text, True)
                        Catch exX As Exception
                            Me.lblMessage.Text = exX.Message
                        End Try
                    End Try


                    Me.grdResumenRecargas.Dispose()
                    Me.grdResumenRecargas.DataBind()

                    Me.txtNumber.Text = String.Empty
                    txtConfirmNumber.Text = String.Empty
                    Me.lblMessage.Text = "Transacción exitosa con número de Folio " & transaccion & " y transacción " & transaccion & "" 'String.Empty
                    Me.lblInfoRecarga.Text = String.Empty
                    Session("MSG1") = "Transacción exitosa con número de Folio " & transaccion & " y transacción " & transaccion & ""

                    Try
                        mail.EnviaCorreo("USUARIO: " & Me.vgPropObjUserConnected.USERNAME & " :: Recarga TAE <b>$" & objtransaccion.MONTO_MTO & "</b> Exitosa TERIA, TRANS: " & objtransaccion.TRANSACCION & " NÚMERO: " & objtransaccion.NUMERO_RECARGA, "ÉXITO EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, False)
                    Catch exX As Exception
                        Me.lblMessage.Text = exX.Message
                    End Try

                    ViewState.Clear()
                    Response.Redirect("TAElectronico.aspx")
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function RecargaProcom(clsGenric As clsGenerics) As Boolean
        Try
            Dim PhoneNumer As String = Me.txtConfirmNumber.Text.Trim()
            Dim _Cantidad = Convert.ToInt32(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            Dim compani = Me.ddlCompania.SelectedItem.Text.Trim().ToLower()
            Dim fechacortahoy = DateTime.Now.ToShortDateString()

            Using ef As New EDM_TopItUp()
                Dim foliotransaccion As String
                foliotransaccion = ""
                Dim vta = New ProcomDtos().VendeByProcom(compani, PhoneNumer, _Cantidad, foliotransaccion)
                Dim cadena = vta.Split(Convert.ToChar("-"))
                Dim _vta As Boolean = False
                If cadena(0) = "true" Then
                    _vta = True
                End If
                If _vta = True Then ' entonces hay que guardar comisiones etc etc

                    Dim _folio As String = cadena(1)
                    Dim transaccion As String = cadena(2)

                    Dim objtransaccion As New TRANSACCIONES()
                    objtransaccion.HORA = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
                    objtransaccion.FECHA = DateTime.Now
                    objtransaccion.FK_CAT_WS = 5  'PROCOM 
                    objtransaccion.TRANSACCION = transaccion
                    objtransaccion.FK_USER = Me.vgPropObjUserConnected.PK_USER
                    objtransaccion.FOLIO = _folio
                    objtransaccion.FK_CAT_MEDIO_DE_PAGO = 1
                    objtransaccion.FK_CAT_TELEFONIA = Convert.ToInt32(Me.ddlCompania.SelectedValue)
                    objtransaccion.FK_CAT_TIPO_MVTO = 1
                    objtransaccion.MONTO_MTO = Convert.ToDecimal(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
                    objtransaccion.NUMERO_RECARGA = Me.txtConfirmNumber.Text.Trim()
                    ef.TRANSACCIONES.Add(objtransaccion)
                    ef.SaveChanges()

                    Dim objSaldoCargo As New SALDOS
                    objSaldoCargo.FK_TRANSACCION = objtransaccion.PK_TRANSACCION
                    objSaldoCargo.FECHA_MVTO = DateTime.Now
                    objSaldoCargo.MONTO_MVTO = objtransaccion.MONTO_MTO
                    objSaldoCargo.FK_USER = Me.vgPropIntCveUserConnected
                    objSaldoCargo.SALDO = clsGenric.func_GetSaldoUsr(Me.vgPropIntCveUserConnected) - objtransaccion.MONTO_MTO
                    lblSaldoCliente.Text = objSaldoCargo.SALDO
                    TopBar.saldocontrol = lblSaldoCliente.Text
                    ef.SALDOS.Add(objSaldoCargo)
                    ef.SaveChanges()


                    '/*******************************************************************************/
                    '/************************************ ABONO ************************************/
                    '/*******************************************************************************/
                    'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
                    Dim objCtePadre As CLIENTES
                    Dim objUserPadre As USERS

                    objCtePadre = New CLIENTES
                    objUserPadre = New USERS

                    If Not Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Then ' Si la sucursal tiene cliente padre entonces registra la comisión al padre
                        objCtePadre = ef.CLIENTES.Find(Me.vgPropObjCteConnected.FK_CLIENTE_PADRE)
                        objUserPadre = ef.USERS.Find(clsGenric.func_GetUserByCliente(objCtePadre.PK_CLIENTE))
                        sub_AddComisionSaldoClientePadre(objtransaccion, DateTime.Now, objUserPadre, Me.vgPropObjUserConnected)
                    End If

                    'Si el padre tiene a su vez cliente padre entonces agrego la comisión al nivel 1
                    If Not objCtePadre.FK_CLIENTE_PADRE Is Nothing Then ' Si la matriz tiene cliente padre entonces registra la comisión al padre (adm maestro comunmente)
                        Dim objUserPadreNivel1 As USERS = ef.USERS.Find(clsGenric.func_GetUserByCliente(objCtePadre.FK_CLIENTE_PADRE))
                        sub_AddComisionSaldoClientePadre(objtransaccion, DateTime.Now, objUserPadreNivel1, objUserPadre)
                    End If

                    'COMISIÓN DEL USUARIO CONECTADO
                    Dim vlDecMontoComisionUsr As Decimal = clsGenric.func_GetComisionPorTransaccion(Convert.ToInt32(Me.ddlCompania.SelectedValue), objtransaccion.MONTO_MTO, vgPropObjUserConnected)

                    '/* LE AGREGO LA COMISIÓN AL CLIENTE CONECTADO */

                    Dim objSaldoAbono As New SALDOS
                    objSaldoAbono.FK_TRANSACCION = objtransaccion.PK_TRANSACCION
                    objSaldoAbono.FECHA_MVTO = DateTime.Now
                    objSaldoAbono.MONTO_PAGO = vlDecMontoComisionUsr
                    objSaldoAbono.FK_USER = Me.vgPropIntCveUserConnected   'Me.propVgObjCliente.PK_CLIENTE
                    'Aquí recupero el saldo del cliente y le aumento la comisión
                    objSaldoAbono.SALDO = clsGenric.func_GetSaldoUsr(vgPropIntCveUserConnected) + vlDecMontoComisionUsr
                    lblSaldoCliente.Text = objSaldoAbono.SALDO
                    TopBar.saldocontrol = lblSaldoCliente.Text
                    Dim mail As New BACK_CODE.EnviaCorreo

                    Try
                        ef.SALDOS.Add(objSaldoAbono)
                        'Guardamos la transacción
                        ef.SaveChanges()
                    Catch ex As Exception
                        Me.lblMessage.Text = "No es posible realizar la actualización de su comisión, se ha notificado al administrador del sistema: " & ex.Message
                        Try
                            mail.EnviaCorreo("ERROR TAE PROCOM:: " & Me.lblMessage.Text, "RECARGA TAE CON ERROR :: " & Me.ddlCompania.SelectedItem.Text, True)
                        Catch exX As Exception
                            Me.lblMessage.Text = exX.Message
                        End Try
                    End Try


                    Me.grdResumenRecargas.Dispose()
                    Me.grdResumenRecargas.DataBind()

                    Me.txtNumber.Text = String.Empty
                    txtConfirmNumber.Text = String.Empty
                    Me.lblMessage.Text = "Transacción exitosa con número de Folio " & transaccion & " y transacción " & transaccion & "" 'String.Empty
                    Me.lblInfoRecarga.Text = String.Empty
                    Session("MSG1") = "Transacción exitosa con número de Folio " & transaccion & " y transacción " & transaccion & ""

                    Try
                        mail.EnviaCorreo("USUARIO: " & Me.vgPropObjUserConnected.USERNAME & " :: Recarga TAE <b>$" & objtransaccion.MONTO_MTO & "</b> Exitosa prontipagos, TRANS: " & objtransaccion.TRANSACCION & " NÚMERO: " & objtransaccion.NUMERO_RECARGA, "ÉXITO EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, False)
                    Catch exX As Exception
                        Me.lblMessage.Text = exX.Message
                    End Try

                    ViewState.Clear()
                    Response.Redirect("TAElectronico.aspx")
                    Return True
                Else Return False
                End If

            End Using

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Recarga_Prontipagos(clsGeneric As clsGenerics) As Boolean
        'pruebas 
        'Return False

        Dim vta As New VENTATELCEL()
        'CATÁLOGO DE PRODUCTOS
        Dim strReferencia As String = String.Empty
        Dim strSKU As String = String.Empty
        'Dim strRefCte As Integer = 1
        Dim respuesta As New BACK_CODE.ProntipagosTopUpService.transactionResponseDto
        Dim mail As New BACK_CODE.EnviaCorreo

        Dim llave As New LLAVES_TRANS_SODESI_PRONTIPAGOS 'llave para refcte en prontipagos

        strReferencia = Me.txtConfirmNumber.Text
        Try
            'En esta parte deberá ir cambiando el SKU dependiendo el producto que quieran transaccionar.
            If Not Me.ddlCompania.SelectedValue.Equals("1") Then ' ES COMPAÑIA DIFERENTE A TELCEL 
                'ENTONCES FORMA EL SKU EN BASE A LA COMPAÑIA
                Dim compani = vgObjModelo.CAT_TELEFONIAS.ToList().Where(Function(c) c.PK_CAT_TELEFONIA.Equals(Convert.ToInt32(Me.ddlCompania.SelectedValue))).FirstOrDefault().DESCRIPCION
                strSKU = "S3TAE" & ViewState("MontoSeleccionado").ToString().Replace(".00", "") & compani & "MXN"
            End If

            Dim _Cantidad = Convert.ToDouble(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            vgObjModelo = New EDM_TopItUp

            llave.FECHA_REFERENCIAS = Date.Now.Date
            llave.FK_CLIENTE = Me.vgPropIntCveCteConnected
            llave.PROCESADA = 0
            Try
                'Otengo la última clave procesada
                llave.REF_CTE = vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.SqlQuery("SELECT  * from LLAVES_TRANS_SODESI_PRONTIPAGOS where FECHA_REFERENCIAS=convert(date,getdate()) order by REF_CTE desc")(0).REF_CTE + 1
            Catch ex As Exception
                llave.REF_CTE = Nothing
            End Try




            vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.Add(llave)
            vgObjModelo.SaveChanges()

            respuesta = vta.Venta(_Cantidad, strReferencia, strSKU, "") ' AQUI HAY Q PASAR LOS PARAMETROS DE SKU NUMERO Y MONTO.

            If respuesta.transactionId = Nothing Then
                Me.lblMessage.Text = "Para continuar recargando seleccione la opción COMPRA DE TIEMPO AIRE. " '+ respuesta.codeDescription
                'respuesta.codeDescription
                Return False
            End If
        Catch ex As Exception
            Me.lblMessage.Text = "El sistema no está disponible, ya se ha notificado al administrador del sistema: " & ex.Message
            Try
                mail.EnviaCorreo("Error Recarga TAE Prontipagos :: " & Me.lblMessage.Text, "ERROR RECARGA TAE :: " & Me.ddlCompania.SelectedItem.Text, True)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
        End Try

        Dim EstadoTransaccion = New BACK_CODE.ProntipagosTopUpService.transactionResponseTO
        Dim blnExitosa As Boolean = False ' se inicia en false por si termina el ciclo de 1 min y siempre regreso "N/A" en caso de ser "00" se pasa a True 
        Dim ErrorDescripcion As String = String.Empty

        ' Se revisa el estado de la transaccion 
        Dim CODIGORESPUESTA As String
        For i = 0 To 30 Step 1
            EstadoTransaccion = Nothing

            EstadoTransaccion = vta.ValidaEstatusTransaccion(respuesta.transactionId, 1)
            CODIGORESPUESTA = String.Empty
            CODIGORESPUESTA = EstadoTransaccion.codeTransaction
            Try
                If CODIGORESPUESTA.Equals("00") Then ' Transacción exitosa entonces sale 
                    blnExitosa = True
                    Exit For ' se sale del ciclo 
                End If
            Catch ex As Exception
                blnExitosa = False
                Exit For ' se sale del ciclo
            End Try

            Try
                If Not CODIGORESPUESTA.Equals("N/A") And Not CODIGORESPUESTA.Equals("00") Then ' si no regresa procesando "N/A" o exitosa "00" 
                    'entonces regreso algun codigo de error se pone la transaccion  en false y se manda la descripcion del error que regresa el servicio 
                    blnExitosa = False
                    ErrorDescripcion = EstadoTransaccion.codeDescription
                    Exit For ' se sale del ciclo
                End If
            Catch ex As Exception
                blnExitosa = False
                Exit For ' se sale del ciclo
            End Try

            Try
                If CODIGORESPUESTA.Equals("N/A") Then
                    System.Threading.Thread.Sleep(2000) ' espera dos segundos para volver a revisar el estado de la transaccion 
                End If
            Catch ex As Exception
                blnExitosa = False
                Exit For ' se sale del ciclo
            End Try
        Next i

        If blnExitosa Then
            'confirmmo que la transacción fue exitosa
            vgObjModelo.LLAVES_TRANS_SODESI_PRONTIPAGOS.Find(llave.PK_LLAVE_TRANS_SODESI_PRONTIPAGOS)
            llave.PROCESADA = 1
            vgObjModelo.SaveChanges()

            Dim dtResumen As DataTable
            Dim drAdd As DataRow

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
            drAdd("HORA") = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second
            drAdd("NUMERO") = Trim(Me.txtNumber.Text)
            drAdd("MONTO") = ViewState("MontoSeleccionado")
            drAdd("COMPANIA") = lblCompany.Text
            drAdd("FOLIO_TRANS") = EstadoTransaccion.folioTransaction & " / " & EstadoTransaccion.transactionId
            dtResumen.Rows.Add(drAdd)
            dtResumen.AcceptChanges()

            Dim modelo As New EDM_TopItUp
            Dim objTransTAE As New TRANSACCIONES

            'Agregamos la transacción generada por la recarga telefónica
            objTransTAE.FECHA = drAdd("FECHA")
            objTransTAE.FK_CAT_MEDIO_DE_PAGO = 1 'Saldo del cliente
            'Este deberá ser el seleccionado y no deberá ser FIJO
            objTransTAE.FK_CAT_TELEFONIA = Convert.ToInt32(Me.ddlCompania.SelectedValue)
            objTransTAE.FK_CAT_TIPO_MVTO = 1 'Recarga telefónica
            objTransTAE.FK_USER = Me.vgPropObjUserConnected.PK_USER
            objTransTAE.FOLIO = EstadoTransaccion.folioTransaction
            objTransTAE.FK_CAT_WS = 3
            objTransTAE.HORA = drAdd("HORA")
            objTransTAE.MONTO_MTO = drAdd("MONTO")
            objTransTAE.NUMERO_RECARGA = drAdd("NUMERO")
            objTransTAE.TRANSACCION = EstadoTransaccion.transactionId
            Try
                'Guardamos la transacción
                modelo.TRANSACCIONES.Add(objTransTAE)
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar el guardado de la transacción, se ha notificado al administrador del sistema: " & ex.Message
                Try
                    mail.EnviaCorreo("Error Recarga TAE Prontipagos :: " & Me.lblMessage.Text, "ERROR RECARGA TAE :: " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try

                Return False
            End Try

            '/*******************************************************************************/
            '/************************************ CARGO ************************************/
            '/*******************************************************************************/
            modelo = New EDM_TopItUp
            'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
            Dim objSaldoCargo As New SALDOS
            objSaldoCargo.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
            objSaldoCargo.FECHA_MVTO = dteFechaMvto
            objSaldoCargo.MONTO_MVTO = objTransTAE.MONTO_MTO
            objSaldoCargo.FK_USER = Me.vgPropIntCveUserConnected
            'Aquí recupero el saldo del cliente y le resto la recarga
            objSaldoCargo.SALDO = clsGeneric.func_GetSaldoUsr(Me.vgPropIntCveUserConnected) - objTransTAE.MONTO_MTO
            lblSaldoCliente.Text = objSaldoCargo.SALDO
            TopBar.saldocontrol = lblSaldoCliente.Text


            Try
                modelo.SALDOS.Add(objSaldoCargo)
                'Guardamos la transacción
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su saldo, se ha notificado al administrador del sistema: " & ex.Message
                Try
                    mail.EnviaCorreo("ERROR RECARGA TAE: " & Me.lblMessage.Text, "ERROR RECARGA TAE", True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try

            End Try

            '/*******************************************************************************/
            '/************************************ ABONO ************************************/
            '/*******************************************************************************/
            'Aquí agregaremos el registro en SALDOS descontanto el monto que se ha transaccionado.
            Dim objCtePadre As CLIENTES
            Dim objUserPadre As USERS

            objCtePadre = New CLIENTES
            objUserPadre = New USERS

            If Not Me.vgPropObjCteConnected.FK_CLIENTE_PADRE Is Nothing Then ' Si la sucursal tiene cliente padre entonces registra la comisión al padre
                objCtePadre = modelo.CLIENTES.Find(Me.vgPropObjCteConnected.FK_CLIENTE_PADRE)
                objUserPadre = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.PK_CLIENTE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadre, Me.vgPropObjUserConnected)
            End If

            'Si el padre tiene a su vez cliente padre entonces agrego la comisión al nivel 1
            If Not objCtePadre.FK_CLIENTE_PADRE Is Nothing Then ' Si la matriz tiene cliente padre entonces registra la comisión al padre (adm maestro comunmente)
                Dim objUserPadreNivel1 As USERS = modelo.USERS.Find(clsGeneric.func_GetUserByCliente(objCtePadre.FK_CLIENTE_PADRE))
                sub_AddComisionSaldoClientePadre(objTransTAE, dteFechaMvto, objUserPadreNivel1, objUserPadre)
            End If

            'COMISIÓN DEL USUARIO CONECTADO
            Dim vlDecMontoComisionUsr As Decimal = clsGeneric.func_GetComisionPorTransaccion(Convert.ToInt32(Me.ddlCompania.SelectedValue), objTransTAE.MONTO_MTO, vgPropObjUserConnected)

            '/* LE AGREGO LA COMISIÓN AL CLIENTE CONECTADO */
            modelo = New EDM_TopItUp
            Dim objSaldoAbono As New SALDOS
            objSaldoAbono.FK_TRANSACCION = objTransTAE.PK_TRANSACCION
            objSaldoAbono.FECHA_MVTO = dteFechaMvto
            objSaldoAbono.MONTO_PAGO = vlDecMontoComisionUsr
            objSaldoAbono.FK_USER = Me.vgPropIntCveUserConnected   'Me.propVgObjCliente.PK_CLIENTE
            'Aquí recupero el saldo del cliente y le aumento la comisión
            objSaldoAbono.SALDO = clsGeneric.func_GetSaldoUsr(vgPropIntCveUserConnected) + vlDecMontoComisionUsr
            lblSaldoCliente.Text = objSaldoAbono.SALDO
            TopBar.saldocontrol = lblSaldoCliente.Text

            Try
                modelo.SALDOS.Add(objSaldoAbono)
                'Guardamos la transacción
                modelo.SaveChanges()
            Catch ex As Exception
                Me.lblMessage.Text = "No es posible realizar la actualización de su comisión, se ha notificado al administrador del sistema: " & ex.Message
                Try
                    mail.EnviaCorreo("ERROR TAE PRONTIPAGOS:: " & Me.lblMessage.Text, "RECARGA TAE CON ERROR :: " & Me.ddlCompania.SelectedItem.Text, True)
                Catch exX As Exception
                    Me.lblMessage.Text = exX.Message
                End Try
            End Try

            Me.grdResumenRecargas.Dispose()
            Me.grdResumenRecargas.DataBind()

            Me.txtNumber.Text = String.Empty
            txtConfirmNumber.Text = String.Empty
            Me.lblMessage.Text = "Transacción exitosa con número de Folio " & EstadoTransaccion.folioTransaction & " y transacción " & EstadoTransaccion.transactionId & "" 'String.Empty
            Me.lblInfoRecarga.Text = String.Empty
            Session("MSG1") = "Transacción exitosa con número de Folio " & EstadoTransaccion.folioTransaction & " y transacción " & EstadoTransaccion.transactionId & ""

            Try
                mail.EnviaCorreo("USUARIO: " & Me.vgPropObjUserConnected.USERNAME & " :: Recarga TAE <b>$" & objTransTAE.MONTO_MTO & "</b> Exitosa prontipagos, TRANS: " & EstadoTransaccion.transactionId & " NÚMERO: " & objTransTAE.NUMERO_RECARGA, "ÉXITO EN RECARGA TAE " & Me.ddlCompania.SelectedItem.Text, False)
            Catch exX As Exception
                Me.lblMessage.Text = exX.Message
            End Try
        Else
            Me.lblMessage.Text = "Transacción no disponible, ha sido notificado al administrador del sistema, en breve nos comunicaremos con usted a los registros que nos proporcionó." '& ErrorDescripcion

            ViewState.Clear()
            Response.Redirect("TAElectronico.aspx")

        End If

        Return blnExitosa
    End Function

    Protected Sub btn20_Click(sender As Object, e As ImageClickEventArgs) Handles btn20.Click
        Dim monto = Me.btn20.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_ShowButtonsInactiveCost()
        sub_leyendaMontoRecarga(monto)
        Me.imgOpc20On.Visible = True
        Me.imgOpc20Off.Visible = False

    End Sub

    Protected Sub btnRec30_Click(sender As Object, e As ImageClickEventArgs) Handles btnRec30.Click
        Dim monto = Me.btnRec30.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_ShowButtonsInactiveCost()
        sub_leyendaMontoRecarga(monto)
        Me.imgOpc30On.Visible = True
        Me.imgOpc30Off.Visible = False
    End Sub

    Protected Sub btnRec50_Click(sender As Object, e As ImageClickEventArgs) Handles btnRec50.Click
        Dim monto = Me.btnRec50.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_ShowButtonsInactiveCost()
        Me.imgOpc50On.Visible = True
        Me.imgOpc50Off.Visible = False
        sub_leyendaMontoRecarga(monto)
    End Sub

    Protected Sub btnRec100_Click(sender As Object, e As ImageClickEventArgs) Handles btnRec100.Click
        sub_ShowButtonsInactiveCost()
        Me.imgOpc100On.Visible = True
        Me.imgOpc100Off.Visible = False
        Dim monto = Me.btnRec100.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn150_Click(sender As Object, e As ImageClickEventArgs) Handles btn150.Click
        sub_ShowButtonsInactiveCost()
        Me.imgOpc150On.Visible = True
        Me.imgOpc150Off.Visible = False
        Dim monto = Me.btn150.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn200_Click(sender As Object, e As ImageClickEventArgs) Handles btn200.Click
        sub_ShowButtonsInactiveCost()
        Me.imgOpc200On.Visible = True
        Me.imgOpc200Off.Visible = False
        Dim monto = Me.btn200.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn300_Click(sender As Object, e As ImageClickEventArgs) Handles btn300.Click
        sub_ShowButtonsInactiveCost()
        Me.imgOpc300On.Visible = True
        Me.imgOpc300Off.Visible = False
        Dim monto = Me.btn300.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn500_Click(sender As Object, e As ImageClickEventArgs) Handles btn500.Click
        sub_ShowButtonsInactiveCost()
        Me.imgOpc500On.Visible = True
        Me.imgOpc500Off.Visible = False
        Dim monto = Me.btn500.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Private Sub sub_leyendaMontoRecarga(ByVal strMonto As String)
        ViewState("MontoSeleccionado") = strMonto
        Me.lblInfoRecarga.Text = Me.lblCompany.Text & " recarga de $" & strMonto
    End Sub

    Private Sub TAElectronico_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objpronti As New BACK_CODE.VENTATELCEL

        If Session("isconsulta") = True Then
            Response.Redirect("../Default.aspx")
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

        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"
        Dim clsGeneric As New clsGenerics()

        If Not IsPostBack Then

            System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-MX")
            'CARGA PAGE DESPUÉS DE CADA RECARGA Y MANDO MENSAJE DE LA ÚLTIMA TRANSACCIÓN

            If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                filaBanco.Visible = True
            Else
                filaBanco.Visible = False
            End If



            Dim prueba = DateTime.Now.AddDays(5)

            Dim str = ""
            If Not Session("servcol") Is Nothing Then
                str = Session("servcol").ToString()
            End If


            If Not String.IsNullOrWhiteSpace(str) Then
                serviciosrow.Visible = True
            End If

            If Not Session("MSG1") Is Nothing Then
                Me.lblMessage.Text = Session("MSG1")
                Session("MSG1") = Nothing
                Me.grdResumenRecargas.Dispose()
                Me.grdResumenRecargas.DataBind()
            End If

            Me.lblFechaSaldo.Text = Date.Now.Date
            Me.lblFechaSaldo.Visible = True

            If Me.propVgBlOnlyTelcel = True Then
                Session("intSoloTelcel") = 1
                imglogox.ImageUrl = "../Images/recargastelcel.png"
            Else
                Session("intSoloTelcel") = 0
                Me.logoTelcel.Visible = False
                imglogox.ImageUrl = "../Images/recargamultimarcas.png"
            End If
            tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
            Try
                Me.lblUsrConnected.Text = vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                        lblDesc10Movs.Visible = True
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                        lblDesc10Movs.Visible = False
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                        lblDesc10Movs.Visible = False
                End Select

                Me.ddlCompania.DataValueField = "PK_CAT_TELEFONIA"
                Me.ddlCompania.DataTextField = "NOMBRE_CORTO"

                Dim li As New ListItem
                li.Value = -1
                li.Text = "Seleccione"
                ddlCompania.Items.Add(li)

                Dim strQueryTelefonias As String = String.Empty

                strQueryTelefonias = "SELECT T.* FROM CAT_TELEFONIAS T, TELEFONIAS_CLIENTES TC, CLIENTES C WHERE C.PK_CLIENTE = TC.FK_CLIENTE AND T.PK_CAT_TELEFONIA = TC.FK_CAT_TELEFONIA AND TC.FK_CLIENTE=" & vgPropObjCteConnected.PK_CLIENTE

                If propVgBlOnlyTelcel = True Then
                    strQueryTelefonias &= " AND TC.FK_CAT_TELEFONIA = 1 AND T.PK_CAT_TELEFONIA = 1"
                    Me.lblCompany.Visible = True
                    Me.ddlCompania.Visible = False
                    Me.lblSelCompany.Visible = False
                Else
                    strQueryTelefonias &= " AND TC.FK_CAT_TELEFONIA <> 1 AND  T.PK_CAT_TELEFONIA <> 1"
                End If

                For Each comp As CAT_TELEFONIAS In vgObjModelo.CAT_TELEFONIAS.SqlQuery(strQueryTelefonias)
                    Dim liCompany As New ListItem
                    liCompany.Value = comp.PK_CAT_TELEFONIA
                    liCompany.Text = comp.NOMBRE_CORTO

                    'Caso telcel
                    If propVgBlOnlyTelcel = True Then
                        If liCompany.Value = "1" Then
                            Me.lblCompany.Text = liCompany.Text
                            liCompany.Selected = True
                            ddlCompania.SelectedValue = liCompany.Value
                        Else
                            liCompany.Selected = False
                        End If
                    Else
                        liCompany.Selected = False
                    End If

                    ddlCompania.Items.Add(liCompany)
                Next

                Me.ddlCompania.DataBind()

                Dim companiaSeleccionada = Me.ddlCompania.SelectedItem.Text
                Dim _compani = Me.ddlCompania.SelectedValue

                lblDescMontoARecargar.Visible = False
                sub_ShowButtonsInactiveCost()


                'Si sólo tiene Seleccione entonces no tiene privilegio
                If ddlCompania.Items.Count = 1 Then
                    Me.txtNumber.Enabled = False
                    Me.txtConfirmNumber.Enabled = False
                    Me.btnAplicarRecarga.Enabled = False
                End If

                If propVgBlOnlyTelcel <> True Then

                    Me.lblCompany.Text = String.Empty
                Else
                    iniciaTelcelMontos()
                End If

                'Si el Administrador maestro muestro las últimas 10 recargas de todos los clientes
                If Me.vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                    Me.grdUltimosMvtosTodosLosCtes.Visible = True
                    Me.grdUltimosMvtosTodosLosCtesHeader.Visible = True
                Else
                    'Si NO ES Administrador maestro muestro las últimas 10 recargas de todos SUS clientes
                End If

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
        TopBar.saldocontrol = lblSaldoCliente.Text


        If Not vgPropObjUserConnected Is Nothing Then
            'Es usuario maestro
            If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                Me.lblSaldoGlobal.Visible = True
                Me.lblSaldoGlobal.Text = String.Empty '"Saldo Global: $" & FormatNumber(clsGeneric.func_GetSaldoGlobal(), 2)
            End If
        End If

    End Sub

    Private Sub sub_ShowButtonsInactiveCost()
        Dim _compani = Me.ddlCompania.SelectedValue

        Me.imgOpc20Off.Visible = True
        Me.imgOpc30Off.Visible = True
        Me.imgOpc50Off.Visible = True
        Me.imgOpc100Off.Visible = True
        Me.imgOpc150Off.Visible = True
        Me.imgOpc200Off.Visible = True
        Me.imgOpc300Off.Visible = True
        Me.imgOpc500Off.Visible = True
        Me.img600off.Visible = True
        img700off.Visible = True
        img800off.Visible = True
        Img900off.Visible = True
        img1000off.Visible = True


        Me.imgOpc20On.Visible = False
        Me.imgOpc30On.Visible = False
        Me.imgOpc50On.Visible = False
        Me.imgOpc100On.Visible = False
        Me.imgOpc150On.Visible = False
        Me.imgOpc200On.Visible = False
        Me.imgOpc300On.Visible = False
        Me.imgOpc500On.Visible = False
        Me.img600on.Visible = False
        img700on.Visible = False
        img800on.Visible = False
        Img900on.Visible = False
        img1000on.Visible = False

        Me.btn20.Visible = True
        Me.btnRec30.Visible = True
        Me.btnRec50.Visible = True
        Me.btnRec100.Visible = True
        Me.btn150.Visible = True

        Me.btn200.Visible = True
        Me.btn300.Visible = True
        Me.btn500.Visible = True
        Me.btn600.Visible = True
        Me.btn700.Visible = True
        Me.btn800.Visible = True
        Me.btn900.Visible = True
        Me.btn1000.Visible = True

        sub_ModoSeleccione(_compani)

        Select Case _compani
            Case "-1"
                Me.img600off.Visible = False
                img700off.Visible = False
                img800off.Visible = False
                Img900off.Visible = False
                img1000off.Visible = False
                Me.img600on.Visible = False
                img700on.Visible = False
                img800on.Visible = False
                Img900on.Visible = False
                img1000on.Visible = False
                Me.btn600.Visible = False
                Me.btn700.Visible = False
                Me.btn800.Visible = False
                Me.btn900.Visible = False
                Me.btn1000.Visible = False
            Case "1"
                'Me.img600off.Visible = False
                img700off.Visible = False
                img800off.Visible = False
                Img900off.Visible = False
                img1000off.Visible = False
                'Me.img600on.Visible = False
                img700on.Visible = False
                img800on.Visible = False
                Img900on.Visible = False
                img1000on.Visible = False
                'Me.btn600.Visible = False
                Me.btn700.Visible = False
                Me.btn800.Visible = False
                Me.btn900.Visible = False
                Me.btn1000.Visible = False
            Case "2"
                Img900off.Visible = False
                img1000off.Visible = False

                Img900on.Visible = False
                img1000on.Visible = False

                btn900.Visible = False
                btn1000.Visible = False

            Case "3"
                Img900off.Visible = False
                img1000off.Visible = False
                Img900on.Visible = False
                img1000on.Visible = False

                Me.btn900.Visible = False
                Me.btn1000.Visible = False
            Case "4"
                img800off.Visible = False
                Img900off.Visible = False
                img1000off.Visible = False
                img800on.Visible = False
                Img900on.Visible = False
                img1000on.Visible = False

                Me.btn800.Visible = False
                Me.btn900.Visible = False
                Me.btn1000.Visible = False
            Case "5"
                Me.imgOpc200Off.Visible = False
                Me.imgOpc300Off.Visible = False
                Me.imgOpc500Off.Visible = False
                Me.img600off.Visible = False
                img700off.Visible = False
                img800off.Visible = False
                Img900off.Visible = False
                img1000off.Visible = False

                Me.imgOpc200On.Visible = False
                Me.imgOpc300On.Visible = False
                Me.imgOpc500On.Visible = False
                Me.img600on.Visible = False
                img700on.Visible = False
                img800on.Visible = False
                Img900on.Visible = False
                img1000on.Visible = False

                Me.btn200.Visible = False
                Me.btn300.Visible = False
                Me.btn500.Visible = False
                Me.btn600.Visible = False
                Me.btn700.Visible = False
                Me.btn800.Visible = False
                Me.btn900.Visible = False
                Me.btn1000.Visible = False
            Case "6"



                Me.btn600.Visible = False
                Me.img600off.Visible = False
                Me.img600on.Visible = False

                Me.btn700.Visible = False
                Me.img700off.Visible = False
                Me.img700on.Visible = False

                Me.btn800.Visible = False
                Me.img800off.Visible = False
                Me.img800on.Visible = False

                Me.btn900.Visible = False
                Me.Img900off.Visible = False
                Me.Img900on.Visible = False


                Me.btn1000.Visible = False
                Me.img1000off.Visible = False
                Me.img1000on.Visible = False
            Case "7"
                btn300.Visible = False
                imgOpc300Off.Visible = False
                imgOpc300On.Visible = False

                Me.btn500.Visible = False
                imgOpc500Off.Visible = False
                imgOpc500On.Visible = False

                Me.btn600.Visible = False
                Me.img600off.Visible = False
                Me.img600on.Visible = False

                Me.btn700.Visible = False
                Me.img700off.Visible = False
                Me.img700on.Visible = False

                Me.btn800.Visible = False
                Me.img800off.Visible = False
                Me.img800on.Visible = False

                Me.btn900.Visible = False
                Me.Img900off.Visible = False
                Me.Img900on.Visible = False


                Me.btn1000.Visible = False
                Me.img1000off.Visible = False
                Me.img1000on.Visible = False

            Case "8"
                Me.btn1000.Visible = False
                Me.img1000off.Visible = False
                Me.img1000on.Visible = False
        End Select


    End Sub

    Private Sub iniciaTelcelMontos()
        Me.btn20.ImageUrl = "../Images/10.png"
        Me.btnRec30.ImageUrl = "../Images/20.png"
        Me.btnRec50.ImageUrl = "../Images/30.png"
        Me.btnRec100.ImageUrl = "../Images/50.png"
        Me.btn150.ImageUrl = "../Images/100.png" 'n
        Me.btn200.ImageUrl = "../Images/150.png"
        Me.btn300.ImageUrl = "../Images/200.png" 'n
        Me.btn500.ImageUrl = "../Images/300.png"
        Me.btn600.ImageUrl = "../Images/500.png"
        Me.btn600.Visible = True
        Me.img600off.Visible = True
        Me.img600on.Visible = False
    End Sub

    Private Sub sub_ModoSeleccione(_compani)
        If _compani = "-1" Then
            Me.lblDescMontoARecargar.Visible = False

            Me.imgOpc20Off.Visible = False
            Me.imgOpc30Off.Visible = False
            Me.imgOpc50Off.Visible = False
            Me.imgOpc100Off.Visible = False
            Me.imgOpc150Off.Visible = False
            Me.imgOpc200Off.Visible = False
            Me.imgOpc300Off.Visible = False
            Me.imgOpc500Off.Visible = False
            Me.img600off.Visible = False
            img700off.Visible = False
            img800off.Visible = False
            Img900off.Visible = False
            img1000off.Visible = False

            Me.imgOpc20On.Visible = False
            Me.imgOpc30On.Visible = False
            Me.imgOpc50On.Visible = False
            Me.imgOpc100On.Visible = False
            Me.imgOpc150On.Visible = False
            Me.imgOpc200On.Visible = False
            Me.imgOpc300On.Visible = False
            Me.imgOpc500On.Visible = False
            Me.img600on.Visible = False
            img700on.Visible = False
            img800on.Visible = False
            Img900on.Visible = False
            img1000on.Visible = False

            Me.btn20.Visible = False
            Me.btnRec30.Visible = False
            Me.btnRec50.Visible = False
            Me.btnRec100.Visible = False
            Me.btn150.Visible = False

            Me.btn200.Visible = False
            Me.btn300.Visible = False
            Me.btn500.Visible = False
            Me.btn600.Visible = False
            Me.btn700.Visible = False
            Me.btn800.Visible = False
            Me.btn900.Visible = False
            Me.btn1000.Visible = False
        End If
    End Sub

    Protected Sub ddlCompania_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCompania.SelectedIndexChanged
        Try

            Dim companiaSeleccionada = Me.ddlCompania.SelectedItem.Text
            Dim _compani = Me.ddlCompania.SelectedValue
            sub_ShowButtonsInactiveCost()

            If _compani <> "-1" Then
                Me.lblDescMontoARecargar.Visible = True
            Else
                Me.lblDescMontoARecargar.Visible = False
            End If

            Select Case _compani
                Case "2" ' movi

                    Me.btn20.ImageUrl = "../Images/10.png"
                    Me.btnRec30.ImageUrl = "../Images/20.png"
                    Me.btnRec50.ImageUrl = "../Images/30.png"
                    Me.btnRec100.ImageUrl = "../Images/50.png"
                    Me.btn150.ImageUrl = "../Images/60.png" 'n
                    Me.btn200.ImageUrl = "../Images/100.png"
                    Me.btn300.ImageUrl = "../Images/120.png" 'n
                    Me.btn500.ImageUrl = "../Images/150.png"
                    Me.btn600.ImageUrl = "../Images/200.png"
                    Me.btn700.ImageUrl = "../Images/300.png"
                    Me.btn800.ImageUrl = "../Images/500.png"

                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False


                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False


                Case "3" ' iusa 

                    Me.btn20.ImageUrl = "../Images/20.png"
                    Me.btnRec30.ImageUrl = "../Images/30.png"
                    Me.btnRec50.ImageUrl = "../Images/50.png"
                    Me.btnRec100.ImageUrl = "../Images/55.png"
                    Me.btn150.ImageUrl = "../Images/100.png"
                    Me.btn200.ImageUrl = "../Images/150.png"
                    Me.btn300.ImageUrl = "../Images/200.png"
                    Me.btn500.ImageUrl = "../Images/300.png"
                    Me.btn600.ImageUrl = "../Images/500.png"
                    Me.btn700.ImageUrl = "../Images/750.png"
                    Me.btn800.ImageUrl = "../Images/1000.png"

                    Me.btn300.Visible = True
                    Me.imgOpc300Off.Visible = True
                    Me.imgOpc300On.Visible = False

                    Me.btn500.Visible = True
                    Me.imgOpc500Off.Visible = True
                    Me.imgOpc500On.Visible = False

                    Me.btn600.Visible = True
                    Me.img600off.Visible = True
                    Me.img600on.Visible = False

                    Me.btn700.Visible = True
                    Me.img700off.Visible = True
                    Me.img700on.Visible = False

                    Me.btn800.Visible = True
                    Me.img800off.Visible = True
                    Me.img800on.Visible = False

                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False


                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False



                Case "4" ' unefon

                    Me.btn20.ImageUrl = "../Images/20.png"
                    Me.btnRec30.ImageUrl = "../Images/30.png"
                    Me.btnRec50.ImageUrl = "../Images/50.png"
                    Me.btnRec100.ImageUrl = "../Images/100.png"
                    Me.btn150.ImageUrl = "../Images/150.png"
                    Me.btn200.ImageUrl = "../Images/200.png"
                    Me.btn300.ImageUrl = "../Images/300.png"
                    Me.btn500.ImageUrl = "../Images/500.png"
                    Me.btn600.ImageUrl = "../Images/750.png"
                    Me.btn700.ImageUrl = "../Images/1000.png"


                    Me.btn300.Visible = True
                    Me.imgOpc300Off.Visible = True
                    Me.imgOpc300On.Visible = False

                    Me.btn500.Visible = True
                    Me.imgOpc500Off.Visible = True
                    Me.imgOpc500On.Visible = False

                    Me.btn600.Visible = True
                    Me.img600off.Visible = True
                    Me.img600on.Visible = False

                    Me.btn700.Visible = True
                    Me.img700off.Visible = True
                    Me.img700on.Visible = False

                    Me.btn800.Visible = False
                    Me.img800off.Visible = False
                    Me.img800on.Visible = False

                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False


                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False

                Case "5" ' nextel 


                    Me.btn200.Visible = True
                    Me.btn300.Visible = True
                    Me.btn500.Visible = True
                    Me.btn20.ImageUrl = "../Images/30.png"
                    Me.btnRec30.ImageUrl = "../Images/50.png"
                    Me.btnRec50.ImageUrl = "../Images/100.png"
                    Me.btnRec100.ImageUrl = "../Images/200.png"
                    Me.btn150.ImageUrl = "../Images/500.png"
                    Me.btn200.Visible = False
                    Me.btn300.Visible = False
                    Me.btn500.Visible = False


                    Me.imgOpc200Off.Visible = False
                    Me.imgOpc200On.Visible = False
                    Me.imgOpc300Off.Visible = False
                    Me.imgOpc300On.Visible = False
                    Me.imgOpc500Off.Visible = False
                    Me.imgOpc500On.Visible = False

                    Me.btn600.Visible = False
                    Me.img600off.Visible = False
                    Me.img600on.Visible = False
                    Me.btn700.Visible = False
                    Me.img700off.Visible = False
                    Me.img700on.Visible = False
                    Me.btn800.Visible = False
                    Me.img800off.Visible = False
                    Me.img800on.Visible = False
                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False
                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False

                Case "6" 'virgin 

                    Me.btn20.ImageUrl = "../Images/30.png"
                    Me.btnRec30.ImageUrl = "../Images/40.png"
                    Me.btnRec50.ImageUrl = "../Images/50.png"
                    Me.btnRec100.ImageUrl = "../Images/100.png" 'n
                    Me.btn150.ImageUrl = "../Images/150.png" 'n
                    Me.btn200.ImageUrl = "../Images/200.png"
                    Me.btn300.ImageUrl = "../Images/300.png" 'n
                    Me.btn500.ImageUrl = "../Images/500.png"

                    Me.btn600.Visible = False
                    Me.img600off.Visible = False
                    Me.img600on.Visible = False

                    Me.btn700.Visible = False
                    Me.img700off.Visible = False
                    Me.img700on.Visible = False

                    Me.btn800.Visible = False
                    Me.img800off.Visible = False
                    Me.img800on.Visible = False

                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False


                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False


                Case "7" 'cierto

                    Me.btn20.ImageUrl = "../Images/20.png"
                    Me.btnRec30.ImageUrl = "../Images/30.png"
                    Me.btnRec50.ImageUrl = "../Images/50.png"
                    Me.btnRec100.ImageUrl = "../Images/100.png" 'n
                    Me.btn150.ImageUrl = "../Images/200.png" 'n
                    Me.btn200.ImageUrl = "../Images/500.png"

                    btn300.Visible = False
                    imgOpc300Off.Visible = False
                    imgOpc300On.Visible = False

                    Me.btn500.Visible = False
                    imgOpc500Off.Visible = False
                    imgOpc500On.Visible = False

                    Me.btn600.Visible = False
                    Me.img600off.Visible = False
                    Me.img600on.Visible = False

                    Me.btn700.Visible = False
                    Me.img700off.Visible = False
                    Me.img700on.Visible = False

                    Me.btn800.Visible = False
                    Me.img800off.Visible = False
                    Me.img800on.Visible = False

                    Me.btn900.Visible = False
                    Me.Img900off.Visible = False
                    Me.Img900on.Visible = False

                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False
                Case "8" 'maztiempo 

                    Me.btn20.ImageUrl = "../Images/10.png"
                    Me.btnRec30.ImageUrl = "../Images/20.png"
                    Me.btnRec50.ImageUrl = "../Images/30.png"
                    Me.btnRec100.ImageUrl = "../Images/50.png" 'n
                    Me.btn150.ImageUrl = "../Images/60.png" 'n
                    Me.btn200.ImageUrl = "../Images/100.png"
                    Me.btn300.ImageUrl = "../Images/120.png" 'n
                    Me.btn500.ImageUrl = "../Images/150.png"
                    Me.btn600.ImageUrl = "../Images/200.png"
                    Me.btn700.ImageUrl = "../Images/250.png"
                    Me.btn800.ImageUrl = "../Images/300.png"
                    Me.btn900.ImageUrl = "../Images/500.png"

                    Me.btn1000.Visible = False
                    Me.img1000off.Visible = False
                    Me.img1000on.Visible = False

            End Select


            Me.lblCompany.Text = companiaSeleccionada
            If Not ViewState("MontoSeleccionado") = Nothing Then
                sub_leyendaMontoRecarga(ViewState("MontoSeleccionado"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn600_Click(sender As Object, e As ImageClickEventArgs) Handles btn600.Click
        Dim monto = Me.btn600.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_ShowButtonsInactiveCost()
        Me.img600on.Visible = True
        img600off.Visible = False
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn700_Click(sender As Object, e As ImageClickEventArgs) Handles btn700.Click
        sub_ShowButtonsInactiveCost()
        Me.img700off.Visible = False
        Me.img700on.Visible = True
        Dim monto = Me.btn700.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn800_Click(sender As Object, e As ImageClickEventArgs) Handles btn800.Click
        sub_ShowButtonsInactiveCost()
        Me.img800on.Visible = True
        Me.img800off.Visible = False
        Dim monto = Me.btn800.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn900_Click(sender As Object, e As ImageClickEventArgs) Handles btn900.Click
        sub_ShowButtonsInactiveCost()
        Me.Img900on.Visible = True
        Me.Img900off.Visible = False
        Dim monto = Me.btn900.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btn1000_Click(sender As Object, e As ImageClickEventArgs) Handles btn1000.Click
        sub_ShowButtonsInactiveCost()
        Me.img1000on.Visible = True
        Me.img1000off.Visible = False
        Dim monto = Me.btn1000.ImageUrl.Replace("../Images/", "").Replace("png", "00")
        sub_leyendaMontoRecarga(monto)

    End Sub

    Protected Sub btnAplicarRecarga_Click(sender As Object, e As EventArgs) Handles btnAplicarRecarga.Click
        Try
            lblMessage.Text = String.Empty
            aplica()
            Me.btnAplicarRecarga.Text = "Aplicar"
            Me.btnAplicarRecarga.Enabled = True
            ModalPopupExtender1.Hide()
        Catch ex As Exception
            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "red")
            Me.lblMessage.Text = ex.Message
            ModalPopupExtender1.Hide()
        End Try
    End Sub

    Public Sub aplica()
        Try
            Me.lblMessage.Style.Remove("color")
            Me.lblMessage.Style.Add("color", "red")
            If Me.ddlCompania.SelectedValue.Equals("-1") Then
                Me.lblMessage.Text = "Favor de seleccionar compañía."
                Exit Sub
            End If

            If Not ViewState("MontoSeleccionado") Is Nothing Then
                If (Trim(Me.txtNumber.Text) = String.Empty Or Trim(Me.txtConfirmNumber.Text = String.Empty)) Then
                    If Trim(Me.txtConfirmNumber.Text = String.Empty) And Trim(Me.txtNumber.Text) <> String.Empty Then
                        Me.lblMessage.Text = "Favor de confirmar el número a recargar."
                        Exit Sub
                    Else
                        Me.lblMessage.Text = "Favor de ingresar un número a recargar."
                        Exit Sub
                    End If
                End If

                Dim clsGeneric As New clsGenerics
                If clsGeneric.func_GetSaldoUsr(Me.vgPropObjUserConnected.PK_USER) < Convert.ToDecimal(ViewState("MontoSeleccionado").ToString().Replace(".00", "")) Then
                    Me.lblMessage.Text = "Estimado cliente, su saldo es inferior al monto seleccionado, no es posible realizar la recarga."
                    Exit Sub
                End If

                If (Trim(Me.txtNumber.Text) <> Trim(Me.txtConfirmNumber.Text)) Then
                    Me.lblMessage.Text = "El número no coincide, favor de validar. No es posible realizar la recarga"
                Else
                    If vgPropObjUserConnected.FK_ACCESS_GROUP = 1 Then
                        Me.lblMessage.Text = "El Administrador Maestro no puede realizar transacciones, deberá generar un cliente para esta solicitud."
                    Else
                        Dim recargaExitosa As Boolean = False
                        Dim numero = txtConfirmNumber.Text
                        For Each prelacio As CAT_WS In vgObjModelo.CAT_WS.Where(Function(w) w.STATUS = 1).OrderBy(Function(k) k.ORDEN_PRIORIDAD)

                            Select Case prelacio.NOMBRE_CORTO
                                Case "MultiWebServices"
                                    'recargaExitosa = False
                                    recargaExitosa = Recarga_MultiWebService(clsGeneric)
                                Case "iSend"
                                    'recargaExitosa = False
                                    recargaExitosa = Recarga_Isend(clsGeneric)
                                Case "ProntiPagos"
                                    'recargaExitosa = False
                                    recargaExitosa = Recarga_Prontipagos(clsGeneric)
                                Case "Integra"
                                    recargaExitosa = RecargaTeria(clsGeneric)
                                Case "PROCOM"
                                    recargaExitosa = RecargaTeria(clsGeneric) 'RecargaProcom(clsGeneric)
                            End Select

                            If (recargaExitosa) Then
                                Try
                                    If Not lblMessage.Text.Contains("ERROR") Then
                                        Me.lblMessage.Style.Remove("color")
                                        Me.lblMessage.Style.Add("color", "green")
                                    End If
                                   
                                    If Not String.IsNullOrWhiteSpace(Me.txtCorreoInfo.Text.Trim()) Then
                                        Dim mail As New EnviaCorreo()
                                        Dim strMsg As String = ""
                                        strMsg = "Estimado cliente como lo solicitó, se envían los datos de su transacción realizada" + vbCr
                                        strMsg += "Fecha: " + DateTime.Now + vbCr
                                        strMsg += "Hora: " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + vbCr
                                        strMsg += "Número Telefónico: " + numero + vbCr
                                        strMsg += "Cantidad Recargada: " + ViewState("MontoSeleccionado").ToString() + vbCr
                                        strMsg += If(Session("MSG1") Is Nothing, "", Session("MSG1").ToString())
                                        mail.EnviaCorreoIndividual(strMsg, "Datos Transacción", 3, Me.txtCorreoInfo.Text.Trim().ToLower())
                                    End If
                                    numero = ""
                                Catch ex As Exception
                                    Dim m As New EnviaCorreo()
                                    m.EnviaCorreo(ex.Message, "error enviar correo", True)
                                End Try
                                Exit For

                                Response.Redirect("TAElectronico.aspx")

                            End If
                        Next
                    End If
                End If
            Else
                Me.lblMessage.Text = "Favor de seleccionar un monto a recargar."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class