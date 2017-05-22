Imports System.Data.Entity

Public Class Noticias1
    Inherits BasePage

    Private AgentID As Integer
    Private AgentPassword As String


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
            Me.DteFechaInicio.Text = Date.Now.Date
            Me.DteFechaFin.Text = Date.Now.Date

            Try
                Dim notis As New List(Of Get_Noticias_Usuario_Result)
                grdNoticias.DataSource = notis
                grdNoticias.DataBind()
                If vgPropIntCveUserConnected = 1 Then
                    LLenaClientes()
                Else
                    Me.lblMessage.Style.Remove("color")
                    Me.lblMessage.Style.Add("color", "red")
                    Me.lblMessage.Text = "Estimado cliente, la opción no está disponible para su tipo de acceso, lamentamos los inconvenientes."
                    Me.btnBuscar.Visible = False
                    Me.btnGuardar.Visible = False
                    Me.btnNuevo.Visible = False
                    Me.txtFechaFin.Visible = False
                    Me.DteFechaInicio.Visible = False
                    Me.chkActivo.Visible = False
                    Me.chkClientes.Visible = False
                    Me.chkTodosClientes.Visible = False
                    txtNoticia.Visible = False
                    grdNoticias.Visible = False
                    chkActivo.Visible = False
                End If

                If Me.propVgBlOnlyTelcel = True Then
                    Session("intSoloTelcel") = 1
                    imglogox.ImageUrl = "../Images/recargastelcel.png"
                    'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                    'tblBackground.Attributes.Add("style", "background-image: url(../Images/background.jpg);background-size: cover;")
                Else
                    Session("intSoloTelcel") = 0
                    Me.logoTelcel.Visible = False
                    imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                    'tblBackground.Attributes.Add("style", "background-color: #DFE3E6;background-size: cover;")
                    'tblBackground.Attributes.Add("style", "background-image: url(../Images/backgroundOtras.jpg);background-size: cover;")
                End If
                tblBackground.Attributes.Add("style", "background-color: #070711;background-size: cover; color:white")
                Me.lblUsrConnected.Text = vgPropObjUserConnected.USERNAME
                Me.lblCteConnected.Text = Me.vgPropObjCteConnected.NOMBRE

                Select Case vgPropObjUserConnected.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select

            Catch ex As Exception
                Me.lblMessage.Text = ex.Message
            End Try
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

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)
        If Trim(Me.txtFechaIni.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Inicio.</li>"
            Exit Sub
        End If

        If Trim(Me.txtFechaFin.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Fin.</li>"
            Exit Sub
        End If

        LLenaNoticias()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Trim(DteFechaInicio.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Inicio.</li>"
            Exit Sub
        End If

        If Trim(DteFechaFin.Text) = String.Empty Then
            Me.lblMessage.Text &= "<li>Ingresar Fecha Fin.</li>"
            Exit Sub
        End If

        If Trim(DteFechaFin.Text) = String.Empty Then
            lblMessage.Text &= "<li>Ingresar la Descripción.</li>"
            Exit Sub
        End If

        If chkTodosClientes.Checked = False And chkClientes.GetSelectedIndices().Length = 0 Then
            lblMessage.Text &= "<li>Seleccionar Cliente(s)</li>"
            Exit Sub
        End If

        Dim Noticia As New NOTICIAS()

        Noticia.FECHA_INI = DteFechaInicio.Text
        Noticia.FECHA_VIGENCIA = DteFechaFin.Text
        Noticia.Descripcion = txtNoticia.Text
        Noticia.STATUS = chkActivo.Checked
        Noticia.PK_NOTICIA = Convert.ToUInt32(hdnIdNoticia.Value)
        Noticia.Anuncio = chkAununcio.Checked

        Dim noticiasPK As New List(Of Integer)

        If (hdnIdNoticia.Value = "0") Then

            vgObjModelo.NOTICIAS.Add(Noticia)
            vgObjModelo.SaveChanges()

            If (chkTodosClientes.Checked) Then
                For Each elementoSeleccionado In vgObjModelo.CLIENTES.Where(Function(r) r.STATUS = "1").ToList()
                    Dim client As New NOTICIAS_CLIENTES()
                    client.FK_CLIENTE = elementoSeleccionado.PK_CLIENTE
                    client.FK_NOTICIA = Convert.ToInt32(Noticia.PK_NOTICIA)

                    vgObjModelo.NOTICIAS_CLIENTES.Add(client)
                    vgObjModelo.SaveChanges()
                Next
            Else
                For Each elementoSeleccionado In chkClientes.GetSelectedIndices()
                    Dim client As New NOTICIAS_CLIENTES()
                    client.FK_CLIENTE = Convert.ToInt32(chkClientes.Items(elementoSeleccionado).Value)
                    client.FK_NOTICIA = Convert.ToInt32(Noticia.PK_NOTICIA)

                    vgObjModelo.NOTICIAS_CLIENTES.Add(client)
                    vgObjModelo.SaveChanges()
                Next
            End If

            Dim mensaje As String = "alert('Registro insertado con éxito');"

            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
        Else
            Noticia.PK_NOTICIA = Convert.ToUInt32(hdnIdNoticia.Value)

            vgObjModelo.Entry(Noticia).State = System.Data.Entity.EntityState.Modified
            vgObjModelo.SaveChanges()

            Dim clientesActuales = vgObjModelo.NOTICIAS_CLIENTES.Where(Function(er) er.FK_NOTICIA = Noticia.PK_NOTICIA).ToList()

            For Each elementoSeleccionado In chkClientes.GetSelectedIndices()
                noticiasPK.Add(Convert.ToInt32(chkClientes.Items(elementoSeleccionado).Value))
            Next

            For Each clienteActual In clientesActuales
                vgObjModelo.NOTICIAS_CLIENTES.Remove(clienteActual)
                vgObjModelo.SaveChanges()
            Next

            For Each clienteSelecionado In noticiasPK
                Dim client As New NOTICIAS_CLIENTES()
                client.FK_CLIENTE = clienteSelecionado
                client.FK_NOTICIA = Convert.ToInt32(Noticia.PK_NOTICIA)

                vgObjModelo.NOTICIAS_CLIENTES.Add(client)
                vgObjModelo.SaveChanges()
            Next

            Dim mensaje As String = "alert('Registro actualizado con éxito');"

            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnALerta", mensaje, True)
        End If

        LLenaNoticias()
        LimpiaPantalla()

    End Sub

    Protected Sub grdNoticias_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdNoticias.RowDataBound
        Try
            Select Case e.Row.RowType
                Case DataControlRowType.DataRow
                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackClientHyperlink(grdNoticias, "Select$" & e.Row.RowIndex))
                    e.Row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.textDecoration='underline';"
                    e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';"
            End Select
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub grdNoticias_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdNoticias.RowCommand
        chkClientes.ClearSelection()
        hdnIdNoticia.Value = grdNoticias.DataKeys(Convert.ToInt32(e.CommandArgument)).Value
        Dim pk_Noticia As Integer = Convert.ToInt32(hdnIdNoticia.Value)

        Try
            Dim noticia = vgObjModelo.NOTICIAS.Where(Function(r) r.PK_NOTICIA = pk_Noticia).FirstOrDefault()

            If noticia Is Nothing Then
                lblMessage.Text = "No existe la noticia!!!"
            Else
                DteFechaInicio.Text = noticia.FECHA_INI.Date 'noticia.FECHA_INI.ToString("yyyy-MM-dd")
                DteFechaFin.Text = noticia.FECHA_VIGENCIA.Date  'noticia.FECHA_VIGENCIA.ToString("yyyy-MM-dd")
                txtNoticia.Text = noticia.Descripcion
                chkActivo.Checked = noticia.STATUS

                If noticia.Anuncio.HasValue Then
                    chkAununcio.Checked = noticia.Anuncio.Value
                Else
                    chkAununcio.Checked = False
                End If

                For Each elementoi In vgObjModelo.NOTICIAS_CLIENTES.Where(Function(FD) FD.FK_NOTICIA = pk_Noticia)
                    Dim opcion = chkClientes.Items.FindByValue(elementoi.FK_CLIENTE)
                    opcion.Selected = True
                Next

                btnGuardar.Text = "Modificar"
            End If
        Catch ex As Exception
            Me.lblMessage.Text &= ex.Message
        End Try
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Try
            hdnIdNoticia.Value = "0"
            btnGuardar.Text = "Guardar"

            LimpiaPantalla()

        Catch ex As Exception
            Me.lblMessage.Text &= ex.Message
        End Try
    End Sub

    Private Sub LimpiaPantalla()
        DteFechaInicio.Text = String.Empty
        DteFechaFin.Text = String.Empty
        txtNoticia.Text = String.Empty
        chkActivo.Checked = False
        chkClientes.ClearSelection()
        chkTodosClientes.Checked = False
        chkAununcio.Checked = False
        chkClientes.Attributes.Remove("disabled")
        lblMessage.Text = ""
    End Sub

    Private Sub LLenaNoticias()
        Try
            If Trim(txtFechaIni.Text) <> String.Empty And Trim(txtFechaFin.Text) <> String.Empty Then
                Dim resuktadoBusqueda = vgObjModelo.Get_Noticias_Usuario _
                (Me.vgPropObjCteConnected.PK_CLIENTE, Convert.ToDateTime(Me.txtFechaIni.Text), Convert.ToDateTime(Me.txtFechaFin.Text)).ToList()

                grdNoticias.DataSource = resuktadoBusqueda
                grdNoticias.DataBind()
            End If
        Catch ex As Exception
            Me.lblMessage.Text &= ex.Message
        End Try
    End Sub

    Private Sub LLenaClientes()
        ' Dim clientes_ = vgObjModelo.CLIENTES.Where(Function(r) r.STATUS = "1").ToList()
        Dim clientes_ = vgObjModelo.CLIENTES.Where(Function(r) r.STATUS = "1").ToList()
        Dim query = (From x In vgObjModelo.CLIENTES.Where(Function(r) r.STATUS = "1") Select x).OrderBy(Function(x) x.NOMBRE).ToList()
        'Dim cteseleccione = New CLIENTES()
        'cteseleccione.PK_CLIENTE = 0
        'cteseleccione.NOMBRE = "Seleccione Cliente(s)"
        'query.Insert(0, cteseleccione)

        chkClientes.DataSource = query
        chkClientes.DataTextField = "NOMBRE"
        chkClientes.DataValueField = "PK_CLIENTE"
        chkClientes.DataBind()
    End Sub

    Protected Sub chkTodosClientes_CheckedChanged(sender As Object, e As EventArgs)
        If (chkTodosClientes.Checked) Then
            chkClientes.ClearSelection()
            chkClientes.Attributes.Add("disabled", "disabled")
            RequiredFieldValidator4.Enabled = False
            ValidatorCalloutExtender7.Enabled = False
        Else
            chkClientes.ClearSelection()
            chkClientes.Attributes.Remove("disabled")
            RequiredFieldValidator4.Enabled = True
            ValidatorCalloutExtender7.Enabled = True
        End If
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim ef As New EDM_TopItUp()
            Dim indexrow As Integer = 0
            For Each row As GridViewRow In grdNoticias.Rows
                Dim cbox As CheckBox = DirectCast((row.FindControl("cboxEliminar")), CheckBox)
                If cbox.Checked Then
                    Dim idnoticia As Integer = Convert.ToInt32(grdNoticias.DataKeys(indexrow)("pk_Noticia"))
                    Dim noticia = ef.NOTICIAS().Where(Function(x) x.PK_NOTICIA = idnoticia).FirstOrDefault()
                    Dim notclientes = ef.NOTICIAS_CLIENTES.Where(Function(x) x.FK_NOTICIA = noticia.PK_NOTICIA).ToList()
                    ef.NOTICIAS_CLIENTES.RemoveRange(notclientes)
                    ef.NOTICIAS.Remove(noticia)
                    ef.SaveChanges()
                End If
                indexrow = indexrow + 1
            Next
            LLenaNoticias()
        Catch ex As Exception

        End Try
    End Sub
End Class