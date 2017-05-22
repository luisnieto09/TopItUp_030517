Imports BACK_CODE
Imports TopItUp.Helpers
Public Class CtesConsulta
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

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")

            Dim res = New DetalleClientesDac().getEdoCuenta(Me.vgPropIntCveUserConnected, Me.vgPropIntCveCteConnected)
            Me.grdClientesHeader.DataSource = res
            Me.grdClientesHeader.DataBind()

            Dim clientes = vgObjModelo.CLIENTES.ToList()
            Dim query = (From x In clientes
                        Join y In res On x.PK_CLIENTE Equals y.pk_cliente
                        Select x).OrderBy(Function(x) x.NOMBRE).ToList()
            Dim cteseleccione = New CLIENTES()
            cteseleccione.PK_CLIENTE = 0
            cteseleccione.NOMBRE = "Seleccione"
            query.Insert(0, cteseleccione)

            Dim usuario = vgObjModelo.USERS.ToList()
            Dim usrs = (From x In usuario
                         Join m In vgObjModelo.CLIENTES_USERS On x.PK_USER Equals m.FK_USER
                         Join y In res On m.FK_CLIENTE Equals y.pk_cliente
                        Select x).OrderBy(Function(x) x.USERNAME).ToList()

            Dim u1 = New USERS()
            u1.PK_USER = 0
            u1.USERNAME = "Seleccione"
            usrs.Insert(0, u1)

            Dim usuarioMayor = vgObjModelo.USERS.ToList()
            Dim mayor = (From x In usuarioMayor
                     Join m In vgObjModelo.CLIENTES_USERS On m.FK_USER Equals x.PK_USER
                     Join y In res On y.fkCtePadre Equals m.FK_CLIENTE
                     Select x).Distinct().ToList().OrderBy(Function(x) x.NOMBRE).ToList()

            Dim u2 = New USERS()
            u2.PK_USER = 0
            u2.USERNAME = "Seleccione"
            mayor.Insert(0, u2)

            Me.ddlCliente.DataSource = query
            Me.ddlCliente.DataValueField = "PK_CLIENTE"
            Me.ddlCliente.DataTextField = "NOMBRE"
            Me.ddlCliente.DataBind()

            Me.ddlUSuario.DataSource = usrs
            Me.ddlUSuario.DataValueField = "PK_USER"
            Me.ddlUSuario.DataTextField = "USERNAME"
            Me.ddlUSuario.DataBind()

            Me.ddlDependeDE.DataSource = mayor
            Me.ddlDependeDE.DataValueField = "PK_USER"
            Me.ddlDependeDE.DataTextField = "USERNAME"
            Me.ddlDependeDE.DataBind()


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
                Me.lblUsrConnected.Text = Me.vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                        Me.ddlctepadreeditar.Enabled = True
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                        Me.ddlctepadreeditar.Enabled = False
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

            Catch ex As Exception
                Response.Redirect("../Default.aspx")
            End Try

            Me.lblDuracionSesion.Text = Session("TIMEOUT") & " Minutos"

            Dim razones = vgObjModelo.CAT_RAZONES_SOCIALES.ToList()
            Dim r As New CAT_RAZONES_SOCIALES()
            r.PK_CAT_RAZON_SOCIAL = -1
            r.NOMBRE_CORTO = "Seleccione"
            razones.Insert(0, r)

            Me.ddlRazonSocialEditar.DataSource = razones
            Me.ddlRazonSocialEditar.DataValueField = "PK_CAT_RAZON_SOCIAL"
            Me.ddlRazonSocialEditar.DataTextField = "NOMBRE_CORTO"
            Me.ddlRazonSocialEditar.DataBind()

            Dim _clientes = vgObjModelo.CLIENTES.Where(Function(x) x.STATUS = 1).OrderBy(Function(x) x.NOMBRE).ToList()


            If Not vgPropIntCveCteConnected = 1 Then
                Dim idcliente As Nullable(Of Integer) = vgPropIntCveCteConnected
                _clientes = _clientes.Where(Function(x) If(x.FK_CLIENTE_PADRE Is Nothing, 0, x.FK_CLIENTE_PADRE) = vgPropIntCveCteConnected Or x.PK_CLIENTE = vgPropIntCveCteConnected).ToList()
            End If


            Dim c As New CLIENTES()
            c.PK_CLIENTE = -1
            c.NOMBRE = ("Seleccione")
            _clientes.Insert(0, c)

            'Dim usuarios = vgObjModelo.USERS.Where(Function(x) x.STATUS = 1).ToList()
            'Dim u As New USERS()
            'u.PK_USER = -1
            'u.USERNAME = "Seleccione"
            'usuarios.Insert(0, u)


            Me.ddlctepadreeditar.DataSource = _clientes
            Me.ddlctepadreeditar.DataValueField = "PK_CLIENTE"
            Me.ddlctepadreeditar.DataTextField = "NOMBRE"
            Me.ddlctepadreeditar.DataBind()


        End If
        Me.lblDuracionSesion.Text = Session.Timeout & " Minutos"

        Try
            lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(Me.vgPropIntCveCteConnected)
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


        'modalEditar.Show()
    End Sub



    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim rutaArchivo As String
        Dim rutas As Util_URL = Util_URL.getInstance()
        Dim newURL As New Util_ArmaURL()
        'Dim resultReporte1 = vgObjModelo.sp_GetListaClientes(Me.vgPropIntCveUserConnected, Me.vgPropIntCveCteConnected).ToList()
        Dim resultReporte1 = New DetalleClientesDac().getEdoCuenta(Me.vgPropIntCveUserConnected, Me.vgPropIntCveCteConnected)

        Dim cliente = Convert.ToInt32(Me.ddlCliente.SelectedValue)
        Dim user = Convert.ToInt32(ddlUSuario.SelectedValue)
        Dim padre = Convert.ToInt32(ddlDependeDE.SelectedValue)
        If Not cliente = 0 Then
            resultReporte1 = resultReporte1.Where(Function(x) x.pk_cliente = cliente).ToList()
        End If
        If Not user = 0 Then
            Dim fkcliente As Integer = 0
            fkcliente = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_USER = user).FirstOrDefault().FK_CLIENTE()
            resultReporte1 = resultReporte1.Where(Function(x) x.pk_cliente = fkcliente).ToList()
        End If
        If Not padre = 0 Then
            resultReporte1 = resultReporte1.Where(Function(x) x.fkCtePadre = padre).ToList()
        End If

        'Dim x As New sp_GetListaClientes_Result()

        rutaArchivo = resultReporte1.ExportaExcel("Clientes")

        newURL.BaseURL = rutas.HANDLER_DESCARGA_EXCEL
        newURL.AddParameter("rutaArchivo", rutaArchivo)
        newURL.AddParameter("nombreArchivo", "Clientes.xlsx")
        Response.Redirect(newURL.GetURL)
    End Sub

    Protected Sub btnRegregar_Click(sender As Object, e As EventArgs) Handles btnRegregar.Click
        Response.Redirect("Ctes.aspx")
    End Sub

    'Protected Sub grdClientesHeader_RowEditing(sender As Object, e As GridViewEditEventArgs)
    '    Try
    '        Dim id As Integer = DirectCast(grdClientesHeader.DataKeys(e.NewEditIndex).Value, Integer)
    '        Dim _cliente = vgObjModelo.CLIENTES.Find(id)

    '        Me.txtNombreEditar.Text = ""
    '        Me.txtRFCEditar.Text = ""
    '        Me.txtDireccionEditar.Text = ""
    '        Me.txtTelefonoEditar.Text = ""
    '        Me.txteMaileditar.Text = ""


    '        Me.txtNombreEditar.Text = _cliente.NOMBRE
    '        Me.txtRFCEditar.Text = _cliente.RFC
    '        Me.txtDireccionEditar.Text = _cliente.DIRECCION_COMPLETA
    '        Me.txtTelefonoEditar.Text = ""
    '        Me.txteMaileditar.Text = _cliente.EMAIL
    '        modalEditar.Show()


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub grdClientesHeader_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id = DirectCast(grdClientesHeader.DataKeys(e.RowIndex)("pk_cliente"), Integer)
            Me.txtIdCliente.Text = id
            ModalAceptarCancelar.Show()

            'Dim cliente = vgObjModelo.CLIENTES.Find(id)
            'Dim telefonias = vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = id).ToList()
            'For Each t As TELEFONIAS_CLIENTES In telefonias
            '    vgObjModelo.TELEFONIAS_CLIENTES.Remove(t)
            '    vgObjModelo.SaveChanges()
            'Next
            'Dim users = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = id).ToList()
            'For Each u As CLIENTES_USERS In users
            '    vgObjModelo.CLIENTES_USERS.Remove(u)
            '    vgObjModelo.SaveChanges()
            'Next
            'vgObjModelo.CLIENTES.Remove(cliente)
            'vgObjModelo.SaveChanges()
            'Me.grdClientesHeader.Dispose()
            'Me.grdClientesHeader.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptarEditar_Click(sender As Object, e As EventArgs) Handles btnAceptarEditar.Click
        Try

            Me.lblError.Text = String.Empty

            If Me.ddlRazonSocialEditar.SelectedValue.Equals("-1") Then
                Me.lblError.Text = "Seleccione una razón social"
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.txtUserNameEditar.Text) Then
                Me.lblError.Text = "Seleccione un nombre de usuario"
                Exit Sub
            End If

            If Me.ddlctepadreeditar.SelectedValue.Equals("-1") Then
                Me.lblError.Text = "Seleccione un cliente padre"
                Exit Sub
            End If



            Dim _diccionario As New Dictionary(Of Integer, Decimal)
            Dim idcliente As Integer = Convert.ToInt32(Me.txtIdCliente.Text)
            Dim cliente As CLIENTES = vgObjModelo.CLIENTES.Find(idcliente)
            Dim fkuser As Integer = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = idcliente).FirstOrDefault().FK_USER
            Dim usuario As USERS = vgObjModelo.USERS.Find(fkuser)

            If Not usuario.USERNAME = Trim(Me.txtUserNameEditar.Text) Then

                Dim objGeneric = New clsGenerics
                If objGeneric.func_ExisteUserName(Trim(Me.txtUserNameEditar.Text)) = True Then
                    Me.lblError.Text = "El usuario capturado ya existe, favor de cambiarlo."
                    Exit Sub
                End If
                If objGeneric.func_ExisteUserNameEliminado(Trim(Me.txtUserNameEditar.Text)) = True Then
                    Me.lblError.Text = "No se puede asignar ese nombre de usuario ya que existe en un cliente inactivo"
                    Exit Sub
                End If

            End If



            Dim currentclientepadre As Integer = Convert.ToInt32(Me.ddlctepadreeditar.SelectedValue)
            Dim ctepadre As Integer = currentclientepadre 'vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_USER = currentclientepadre).FirstOrDefault().FK_CLIENTE



            Dim todocorrecto As Boolean = True
            For Each gr As GridViewRow In GvTelefoniasEditar.Rows
                If CType(gr.FindControl("cboxTelefoniaEditar"), CheckBox).Checked Then
                    Dim telefonia As Integer = DirectCast(GvTelefoniasEditar.DataKeys(gr.RowIndex)("PK_CAT_TELEFONIA"), Integer)
                    Dim comision As Decimal = Convert.ToDecimal(CType(gr.FindControl("txtComisionEditar"), TextBox).Text)
                    Dim comisionpadre As Decimal = vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = ctepadre).Where(Function(x) x.FK_CAT_TELEFONIA = telefonia).FirstOrDefault().COMISION_TEL_CTE()
                    If comision > comisionpadre Then
                        todocorrecto = False
                    End If
                    _diccionario.Add(telefonia, comision)
                End If
            Next

            If todocorrecto Then

                'borra las anteriores 
                For Each tc As TELEFONIAS_CLIENTES In vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = idcliente).ToList()
                    vgObjModelo.TELEFONIAS_CLIENTES.Remove(tc)
                    vgObjModelo.SaveChanges()
                Next

                For Each Pair In _diccionario ' agrega las nuevas telefonias al cliente 
                    Dim _tc As New TELEFONIAS_CLIENTES()
                    _tc.FK_CLIENTE = idcliente
                    _tc.FK_CAT_TELEFONIA = Pair.Key
                    _tc.COMISION_TEL_CTE = Pair.Value
                    vgObjModelo.TELEFONIAS_CLIENTES.Add(_tc)
                    vgObjModelo.SaveChanges()
                Next

                'elimina servicios anteriores 
                For Each sc As SERVICIOS_CLIENTE_REL In vgObjModelo.SERVICIOS_CLIENTE_REL.Where(Function(x) x.FK_CLIENTE = idcliente).ToList()
                    vgObjModelo.SERVICIOS_CLIENTE_REL.Remove(sc)
                    vgObjModelo.SaveChanges()
                Next

                'guarda los nuevos servicios 
                For Each r As GridViewRow In GvServiciosEditar.Rows
                    Dim lservicios As New List(Of Integer)()

                    If CType(r.FindControl("cboxServicioEdita"), CheckBox).Checked Then
                        Dim idservicio As Integer = DirectCast(GvServiciosEditar.DataKeys(r.RowIndex)("PK_CAT_SERVICIO"), Integer)
                        Dim sc As New SERVICIOS_CLIENTE_REL()
                        sc.FK_CLIENTE = idcliente
                        sc.FK_SERVICIO = idservicio
                        sc.COMISION = 0
                        vgObjModelo.SERVICIOS_CLIENTE_REL.Add(sc)
                        vgObjModelo.SaveChanges()
                    End If

                Next

            Else
                Me.lblError.Text = "Las comisiones no pueden ser mayores a las del cliente padre"
                Exit Sub
            End If


            cliente.NOMBRE = Me.txtNombreEditar.Text
            cliente.EMAIL = Me.txteMailetar.Text
            cliente.RFC = Me.txtRFCEditar.Text
            cliente.TELEFONO_CONTACTO = Me.txtTelefonoEditar.Text
            cliente.DIRECCION_COMPLETA = Me.txtDireccionEditar.Text
            cliente.FK_CAT_RAZON_SOCIAL = Me.ddlRazonSocialEditar.SelectedValue
            cliente.FK_CLIENTE_PADRE = ctepadre
            vgObjModelo.SaveChanges()
            usuario.USERNAME = Me.txtUserNameEditar.Text
            usuario.NOMBRE = txtNombreEditar.Text
            vgObjModelo.SaveChanges()

            'Quiere asignarle una contraseña
            If Not (Trim(Me.txPswEtar.Text) = String.Empty) Then
                Try


                    Dim objUser As USERS
                    Dim objModel As New EDM_TopItUp
                    Dim clsGeneric As New clsGenerics
                    Dim pkUsr As Integer = clsGeneric.func_GetUserByCliente(cliente.PK_CLIENTE)
                    objUser = objModel.USERS.Find(pkUsr)
                    objUser.PASSWORD = BACK_CODE.Cripto.regresaHash(Me.txPswEtar.Text.Trim()) 'Me.txtPsw.Text
                    objModel.SaveChanges()
                Catch ex As Exception

                End Try

            End If

            Me.grdClientesHeader.Dispose()
            Me.grdClientesHeader.DataBind()
            Me.PanGrid.Visible = True
            Me.PaneEditar.Visible = False
            Response.Redirect("CtesConsulta.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelarEditar_Click(sender As Object, e As EventArgs) Handles btnCancelarEditar.Click
        Me.PanGrid.Visible = True
        Me.PaneEditar.Visible = False
    End Sub

    Protected Sub grdClientesHeader_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Me.lblError.Text = String.Empty
            Dim id As Integer = DirectCast(Me.grdClientesHeader.SelectedDataKey("pk_cliente"), Integer)
            Dim _cliente = vgObjModelo.CLIENTES.Find(id)
            Dim iduserselected As Integer = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = id).FirstOrDefault().FK_USER
            Dim _user = vgObjModelo.USERS.Find(iduserselected)
            Me.txtIdCliente.Text = id.ToString()
            Dim strQuery As String = String.Format("SELECT a.* from CAT_TELEFONIAS a , TELEFONIAS_CLIENTES b where a.PK_CAT_TELEFONIA = b.FK_CAT_TELEFONIA  and b.FK_CLIENTE = {0}", _cliente.FK_CLIENTE_PADRE)
            Dim telefonias = vgObjModelo.CAT_TELEFONIAS.SqlQuery(strQuery)
            'Dim telefonias = vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = _cliente.FK_CLIENTE_PADRE)

            'Dim telefonias = vgObjModelo.CAT_TELEFONIAS.ToList()
            Me.GvTelefoniasEditar.DataSource = telefonias.ToList()
            Me.GvTelefoniasEditar.DataBind()

            Dim query As String = String.Format("SELECT a.* from CAT_SERVICIOS a , servicios_cliente_rel b where a.PK_CAT_SERVICIO = b.fk_servicio and b.fk_cliente = {0}", _cliente.FK_CLIENTE_PADRE)
            Dim idupadre As Integer = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = _cliente.FK_CLIENTE_PADRE).FirstOrDefault().FK_USER
            Dim userpadre As USERS = vgObjModelo.USERS.Find(idupadre)

            Dim servicis As New List(Of CAT_SERVICIOS)()

            If userpadre.FK_ACCESS_GROUP = 1 Then ' entonces se muestran todos los servicios 
                servicis = vgObjModelo.CAT_SERVICIOS.ToList()
            Else ' si no solo se muestran los servicios de su padre 
                servicis = vgObjModelo.CAT_SERVICIOS.SqlQuery(query).ToList()
            End If

            Me.GvServiciosEditar.DataSource = servicis
            Me.GvServiciosEditar.DataBind()


            Me.txtNombreEditar.Text = ""
            Me.txtRFCEditar.Text = ""
            Me.txtDireccionEditar.Text = ""
            Me.txtTelefonoEditar.Text = ""
            Me.txteMailetar.Text = ""
            Me.txtUserNameEditar.Text = ""
            Me.txPswEtar.Text = ""
            Me.ddlRazonSocialEditar.SelectedIndex = 0
            Me.ddlctepadreeditar.SelectedIndex = 0
            'Me.txtIdCliente.Text = ""

            'Dim userpadre

            Me.txtNombreEditar.Text = _cliente.NOMBRE
            Me.txtRFCEditar.Text = _cliente.RFC
            Me.txtDireccionEditar.Text = _cliente.DIRECCION_COMPLETA
            Me.txtTelefonoEditar.Text = _cliente.TELEFONO_CONTACTO
            Me.txteMailetar.Text = _cliente.EMAIL
            Me.txtUserNameEditar.Text = _user.USERNAME
            Me.txPswEtar.Text = String.Empty
            Me.ddlRazonSocialEditar.SelectedValue = _cliente.FK_CAT_RAZON_SOCIAL
            Me.ddlctepadreeditar.SelectedValue = _cliente.FK_CLIENTE_PADRE
            'modalEditar.Show()
            Me.PanGrid.Visible = False
            Me.PaneEditar.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnEliminarSi_Click(sender As Object, e As EventArgs) Handles btnEliminarSi.Click
        Try

            If Me.vgPropIntCveCteConnected = 1 Then
                Dim idcliente As Integer = Convert.ToInt32(Me.txtIdCliente.Text)

                Dim cliente = vgObjModelo.CLIENTES.Find(idcliente)
                Dim user_cte = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = idcliente).FirstOrDefault()
                Dim user = vgObjModelo.USERS.Where(Function(x) x.PK_USER = user_cte.FK_USER).FirstOrDefault()
                cliente.NOMBRE = cliente.NOMBRE '+ "_Eliminado"
                user.USERNAME = user.USERNAME '+ "_Eliminado"
                cliente.STATUS = 2
                user.STATUS = 2
                vgObjModelo.SaveChanges()



                'Try
                '    Dim telefonias = vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = idcliente).ToList()
                '    For Each t As TELEFONIAS_CLIENTES In telefonias
                '        vgObjModelo.TELEFONIAS_CLIENTES.Remove(t)
                '        vgObjModelo.SaveChanges()
                '    Next
                '    Dim users = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = idcliente).ToList()
                '    For Each u As CLIENTES_USERS In users
                '        vgObjModelo.CLIENTES_USERS.Remove(u)
                '        vgObjModelo.SaveChanges()
                '        Try
                '            Dim model As New EDM_TopItUp
                '            model.USERS.Find(u.FK_USER).USERNAME = model.USERS.Find(u.FK_USER).USERNAME & " - DELETE"
                '            model.SaveChanges()
                '        Catch ex As Exception
                '        End Try
                '    Next
                '    vgObjModelo.CLIENTES.Remove(cliente)
                '    vgObjModelo.SaveChanges()
                'Catch ex As Exception

                'End Try

                Me.grdClientesHeader.Dispose()
                Me.grdClientesHeader.DataBind()
                lblmainerror.Text = "El cliente ha sido eliminado con éxito"
                ModalAceptarCancelar.Hide()
            Else
                lblmainerror.Text = "Sin privilegios, por favor solicite el borrado del registro al administrador del sistema."
                ModalAceptarCancelar.Hide()
            End If
            'If Not clientepadre.FK_ACCESS_GROUP = 1 Then
            '    lblmainerror.Text = "No es posible eliminar ya que el cliente padre no es Administrador Maestro"
            '    ModalAceptarCancelar.Hide()
            'Else
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnEliminarNo_Click(sender As Object, e As EventArgs) Handles btnEliminarNo.Click
        ModalAceptarCancelar.Hide()
    End Sub

    Protected Sub GvTelefoniasEditar_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvTelefoniasEditar.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim idCliente = Convert.ToInt32(Me.txtIdCliente.Text)
                Dim dr = DirectCast(e.Row.DataItem, CAT_TELEFONIAS)
                Dim idTelefonia As Integer = dr.PK_CAT_TELEFONIA
                Dim telefonias = vgObjModelo.TELEFONIAS_CLIENTES.Where(Function(x) x.FK_CLIENTE = idCliente)
                Dim c As Nullable(Of Integer)
                'Dim comision As String
                If telefonias.Count() > 0 Then
                    c = telefonias.Where(Function(x) x.FK_CAT_TELEFONIA = idTelefonia).Count()
                End If
                If c > 0 Then
                    Dim res As TELEFONIAS_CLIENTES = telefonias.Where(Function(x) x.FK_CAT_TELEFONIA = idTelefonia).FirstOrDefault()
                    CType(e.Row.FindControl("cboxTelefoniaEditar"), CheckBox).Checked = True
                    CType(e.Row.FindControl("txtComisionEditar"), TextBox).Text = res.COMISION_TEL_CTE.ToString()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GvServiciosEditar_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvServiciosEditar.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim idCliente = Convert.ToInt32(Me.txtIdCliente.Text)
                Dim source = DirectCast(e.Row.DataItem, CAT_SERVICIOS)
                Dim idServic = source.PK_CAT_SERVICIO
                Dim esta As Integer = 0
                esta = vgObjModelo.SERVICIOS_CLIENTE_REL.Where(Function(x) x.FK_CLIENTE = idCliente).Where(Function(x) x.FK_SERVICIO = idServic).Count()
                If esta > 0 Then
                    CType(e.Row.FindControl("cboxServicioEdita"), CheckBox).Checked = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnActualizarListaCtes_Click(sender As Object, e As EventArgs) Handles btnActualizarListaCtes.Click
        Response.Redirect("CtesConsulta.aspx")
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim res = New DetalleClientesDac().getEdoCuenta(Me.vgPropIntCveUserConnected, Me.vgPropIntCveCteConnected)
            Dim cliente = Convert.ToInt32(Me.ddlCliente.SelectedValue)
            Dim user = Convert.ToInt32(ddlUSuario.SelectedValue)
            Dim padre = Convert.ToInt32(ddlDependeDE.SelectedValue)
            If Not cliente = 0 Then
                res = res.Where(Function(x) x.pk_cliente = cliente).ToList()
            End If
            If Not user = 0 Then
                Dim fkcliente As Integer = 0
                fkcliente = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_USER = user).FirstOrDefault().FK_CLIENTE()
                res = res.Where(Function(x) x.pk_cliente = fkcliente).ToList()
            End If
            If Not padre = 0 Then
                res = res.Where(Function(x) x.fkCtePadre = padre).ToList()
            End If

            grdClientesHeader.DataSource = res
            grdClientesHeader.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSaldoCero_Click(sender As Object, e As EventArgs) Handles btnSaldoCero.Click
        Try
            Me.lblError.Text = String.Empty
            Dim idcliente As Integer = Convert.ToInt32(Me.txtIdCliente.Text)
            Dim cliente As CLIENTES = vgObjModelo.CLIENTES.Find(idcliente)
            Dim idusuario As Integer = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = idcliente).FirstOrDefault().FK_USER
            Dim user As USERS = vgObjModelo.USERS.Find(idusuario)
            Dim usuarioconectado = vgObjModelo.CLIENTES_USERS.Where(Function(x) x.FK_CLIENTE = vgPropIntCveUserConnected).FirstOrDefault().FK_USER
            Dim cteconectado As USERS = vgObjModelo.USERS.Find(usuarioconectado)
            Dim _saldoCliente = vgObjModelo.SALDOS.Where(Function(x) x.FK_USER = idusuario).Max(Function(x) x.PK_SALDO)
            Dim saldocliente = vgObjModelo.SALDOS.Where(Function(x) x.PK_SALDO = _saldoCliente).FirstOrDefault().SALDO

            Dim _saldouserconectado = vgObjModelo.SALDOS.Where(Function(x) x.FK_USER = usuarioconectado).Max(Function(x) x.PK_SALDO)
            Dim saldouserconectado = vgObjModelo.SALDOS.Where(Function(x) x.PK_SALDO = _saldouserconectado).FirstOrDefault().SALDO

            Dim saldofinalconectado = saldocliente + saldouserconectado

            Dim fecha = DateTime.Now
            Dim t = New TRANSACCIONES()
            t.FK_USER = usuarioconectado
            t.FK_CAT_TIPO_MVTO = 3
            t.FK_CAT_MEDIO_DE_PAGO = 1
            t.FECHA = fecha
            t.HORA = fecha.Hour.ToString() & ":" & fecha.Minute.ToString()
            t.MONTO_MTO = saldocliente
            t.MOTIVO_TRASPASO = "SE REALIZA SALDO A CERO, SE TRASPASA DEL CLIENTE " & user.USERNAME & " AL CLIENTE " & cteconectado.USERNAME
            vgObjModelo.TRANSACCIONES.Add(t)
            vgObjModelo.SaveChanges()

            Dim s = New SALDOS()
            s.FK_USER = idusuario
            s.FK_TRANSACCION = t.PK_TRANSACCION
            s.MONTO_MVTO = saldocliente
            s.MONTO_PAGO = 0
            s.SALDO = 0
            s.FECHA_MVTO = fecha
            vgObjModelo.SALDOS.Add(s)
            vgObjModelo.SaveChanges()

            Dim sc = New SALDOS()
            sc.FK_USER = usuarioconectado
            sc.FK_TRANSACCION = t.PK_TRANSACCION
            sc.MONTO_MVTO = 0
            sc.MONTO_PAGO = saldocliente
            sc.SALDO = saldofinalconectado
            sc.FECHA_MVTO = fecha
            vgObjModelo.SALDOS.Add(sc)
            vgObjModelo.SaveChanges()

            Me.grdClientesHeader.Dispose()
            Me.grdClientesHeader.DataBind()
            Me.PanGrid.Visible = True
            Me.PaneEditar.Visible = False
            Response.Redirect("CtesConsulta.aspx")
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
End Class