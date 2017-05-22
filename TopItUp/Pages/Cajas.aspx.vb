Public Class Cajas
    Inherits BasePage



    Private Property soloTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property

    Private Property UsuarioConectado As USERS
        Set(value As USERS)
            Session("USR") = value
        End Set
        Get
            Return Session("USR")
        End Get
    End Property

    Private Property ClienteConectado As CLIENTES
        Set(value As CLIENTES)
            Session("CTE") = value
        End Set
        Get
            Return Session("CTE")
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Me.lblMensaje.Style.Remove("color")
                Me.lblMensaje.Style.Add("color", "red")
                If Convert.ToBoolean(Session("isCajero")) = True Then
                    Response.Redirect("../Pages/TaElectronico.aspx")
                End If

                If UsuarioConectado.FK_ACCESS_GROUP = 1 Then
                    filaBanco.Visible = True
                Else
                    filaBanco.Visible = False
                End If

                If Not soloTelcel Then
                    logoTelcel.Visible = False
                    imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                Else
                    logoTelcel.Visible = True
                    imglogox.ImageUrl = "../Images/recargastelcel.png"
                End If

                lblFechaSaldo.Text = Date.Now.ToShortDateString()
                Select Case UsuarioConectado.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select
                Dim clsGeneric As New clsGenerics()
                Try
                    lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(UsuarioConectado.PK_USER)
                Catch ex As Exception
                    lblSaldoCliente.Text = 0.0
                End Try

                llenaCajeros()
                limpiainicio()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Dim idusuer As Integer = UsuarioConectado.PK_USER
            If String.IsNullOrEmpty(txtNombreCajero.Text) Then
                Throw New Exception("Debe ingresar el nombre del cajero")
            End If
            If String.IsNullOrEmpty(txtUserName.Text) Then
                Throw New Exception("Debe de ingresar al nombre de usuario para el cajero")
            End If
            If String.IsNullOrEmpty(txtPassWord.Text) Then
                Throw New Exception("Debe de ingresar un password")
            End If

            Dim username As String = txtUserName.Text.ToLower.Trim()


            Dim ef As New EDM_TopItUp()

            Dim existe As Integer = ef.USERS.Where(Function(x) x.USERNAME.ToLower.Trim() = username).Count()


            If existe > 0 Then
                Throw New Exception("El nombre de usuario para el cajero ya existe en algun usuario")
            End If

            existe = ef.CAJEROS.Where(Function(x) x.UserName.ToLower.Trim() = username).Count()

            If existe > 0 Then
                Throw New Exception("El nombre de usuario ya existe en otro cajero")
            End If

            Dim Cajero As New CAJEROS()
            Cajero.Fk_Usuario = idusuer
            Cajero.Nombre = txtNombreCajero.Text.Trim()
            Cajero.PassWord = BACK_CODE.Cripto.regresaHash(txtPassWord.Text.Trim())
            Cajero.UserName = txtUserName.Text.Trim()
            ef.CAJEROS.Add(Cajero)
            ef.SaveChanges()


            If cboxLunes.Checked Then
                Dim hclun As New HORARIO_CAJERO()
                hclun.FK_CAJERO = Cajero.PkCajero
                hclun.DIA = 1
                hclun.HORAINICIO = Convert.ToInt32(txtLunesDesde.Text)
                hclun.HORAFINAL = Convert.ToInt32(txtLunesHasta.Text)
                ef.HORARIO_CAJERO.Add(hclun)
            End If

            If cboxMar.Checked Then
                Dim hcmar As New HORARIO_CAJERO()
                hcmar.FK_CAJERO = Cajero.PkCajero
                hcmar.DIA = 2
                hcmar.HORAINICIO = Convert.ToInt32(txtMartesDesde.Text)
                hcmar.HORAFINAL = Convert.ToInt32(txtMartesHasta.Text)
                ef.HORARIO_CAJERO.Add(hcmar)
            End If

            If cboxMier.Checked Then
                Dim hcmier As New HORARIO_CAJERO()
                hcmier.FK_CAJERO = Cajero.PkCajero
                hcmier.DIA = 3
                hcmier.HORAINICIO = Convert.ToInt32(txtMiercolesDesde.Text)
                hcmier.HORAFINAL = Convert.ToInt32(txtMiercolesHasta.Text)
                ef.HORARIO_CAJERO.Add(hcmier)
            End If

            If cboxJue.Checked Then
                Dim hcjue As New HORARIO_CAJERO()
                hcjue.FK_CAJERO = Cajero.PkCajero
                hcjue.DIA = 4
                hcjue.HORAINICIO = Convert.ToInt32(txtJuevesDesde.Text)
                hcjue.HORAFINAL = Convert.ToInt32(txtJuevesHasta.Text)
                ef.HORARIO_CAJERO.Add(hcjue)
            End If

            If cboxVier.Checked Then
                Dim hcvier As New HORARIO_CAJERO()
                hcvier.FK_CAJERO = Cajero.PkCajero
                hcvier.DIA = 5
                hcvier.HORAINICIO = Convert.ToInt32(txtViernesDesde.Text)
                hcvier.HORAFINAL = Convert.ToInt32(txtViernesHasta.Text)
                ef.HORARIO_CAJERO.Add(hcvier)
            End If

            If cboxSab.Checked Then
                Dim hcsab As New HORARIO_CAJERO()
                hcsab.FK_CAJERO = Cajero.PkCajero
                hcsab.DIA = 6
                hcsab.HORAINICIO = Convert.ToInt32(txtSabadoDesde.Text)
                hcsab.HORAFINAL = Convert.ToInt32(txtSabadoHasta.Text)
                ef.HORARIO_CAJERO.Add(hcsab)
            End If

            If cboxDom.Checked Then
                Dim hcdom As New HORARIO_CAJERO()
                hcdom.FK_CAJERO = Cajero.PkCajero
                hcdom.DIA = 7
                hcdom.HORAINICIO = Convert.ToInt32(txtDomingoDesde.Text)
                hcdom.HORAFINAL = Convert.ToInt32(txtDomingoHasta.Text)
                ef.HORARIO_CAJERO.Add(hcdom)
            End If

            ef.SaveChanges()
            llenaCajeros()
            limpiainicio()
            Me.lblMensaje.Style.Remove("color")
            Me.lblMensaje.Style.Add("color", "green")
            lblMensaje.Text = "El cajero fue registrado correctamente"

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub


    Private Sub llenaCajeros()
        Try
            Dim ef As New EDM_TopItUp()
            Me.grvCrear.DataSource = Nothing
            Me.grvCrear.DataBind()
            Dim cajeros = ef.CAJEROS.ToList().Where(Function(x) x.Fk_Usuario = UsuarioConectado.PK_USER)
            If (cajeros.Count > 0) Then
                grvCrear.DataSource = cajeros
                grvCrear.DataBind()
            End If
        Catch ex As Exception
            Me.lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub limpiaEditar()
        txtEditarUserName.Text = ""
        txtpasswordresetear.Text = ""
        lblErrorEditar.Text = ""
        cboxEditDom.Checked = False
        cboxeditlun.Checked = False
        cboxeditmar.Checked = False
        cboxeditmier.Checked = False
        cboxeditjuev.Checked = False
        cboxeditVier.Checked = False
        cboxEditSab.Checked = False
        txtEditLunFrom.Text = ""
        txtEditMarFrom.Text = ""
        txtEditMierFrom.Text = ""
        txtEditJuevFrom.Text = ""
        txtEditVierFrom.Text = ""
        txtEditSabFrom.Text = ""
        txtEditDomFrom.Text = ""
        txtEditLunHasta.Text = ""
        txtEditMarHasta.Text = ""
        txteditMierHasta.Text = ""
        txtEditJuevHasta.Text = ""
        txtEditVierHasta.Text = ""
        txtEditSabHasta.Text = ""
        txtEditDomHasta.Text = ""
    End Sub

    Private Sub limpiainicio()
        txtUserName.Text = ""
        txtPassWord.Text = ""
        txtNombreCajero.Text = ""
        txtLunesDesde.Text = ""
        txtLunesHasta.Text = ""
        txtMartesDesde.Text = ""
        txtMartesHasta.Text = ""
        txtMiercolesDesde.Text = ""
        txtMiercolesHasta.Text = ""
        txtJuevesDesde.Text = ""
        txtJuevesHasta.Text = ""
        txtViernesDesde.Text = ""
        txtViernesHasta.Text = ""
        txtSabadoDesde.Text = ""
        txtSabadoHasta.Text = ""
        txtDomingoDesde.Text = ""
        txtDomingoHasta.Text = ""
    End Sub

    Protected Sub grvCrear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grvCrear.SelectedIndexChanged
        Try


            Dim id As Integer = grvCrear.SelectedDataKey("PkCajero")
            limpiaEditar()
            Me.panEditaCajero.Visible = True
            Me.panCrearCajero.Visible = False
            panCajerosActuales.Visible = False

            Dim ef As New EDM_TopItUp()
            Dim cajero As CAJEROS = ef.CAJEROS.Where(Function(x) x.PkCajero = id).FirstOrDefault()
            Me.txtidCajeroEditar.Text = cajero.PkCajero
            Dim HrsCajero As List(Of HORARIO_CAJERO) = ef.HORARIO_CAJERO.Where(Function(x) x.FK_CAJERO = id).ToList()

            Me.txtEditarUserName.Text = cajero.UserName

            For Each v As HORARIO_CAJERO In HrsCajero
                If v.DIA = 1 Then
                    cboxeditlun.Checked = True
                    txtEditLunFrom.Text = v.HORAINICIO.ToString()
                    txtEditLunHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 2 Then
                    cboxeditmar.Checked = True
                    txtEditMarFrom.Text = v.HORAINICIO.ToString()
                    txtEditMarHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 3 Then
                    cboxeditmier.Checked = True
                    txtEditMierFrom.Text = v.HORAINICIO.ToString()
                    txteditMierHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 4 Then
                    cboxeditjuev.Checked = True
                    txtEditJuevFrom.Text = v.HORAINICIO.ToString()
                    txtEditJuevHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 5 Then
                    cboxeditVier.Checked = True
                    txtEditVierFrom.Text = v.HORAINICIO.ToString()
                    txtEditVierHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 6 Then
                    cboxEditSab.Checked = True
                    txtEditSabFrom.Text = v.HORAINICIO.ToString()
                    txtEditSabHasta.Text = v.HORAFINAL.ToString()
                End If
                If v.DIA = 7 Then
                    cboxEditDom.Checked = True
                    txtEditDomFrom.Text = v.HORAINICIO.ToString()
                    txtEditDomHasta.Text = v.HORAFINAL.ToString()
                End If
            Next

        Catch ex As Exception
            Me.lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub grvCrear_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grvCrear.RowDeleting
        Try
            Dim idcajero As Integer = Convert.ToInt32(grvCrear.DataKeys(e.RowIndex)("PkCajero"))
            Dim ef As New EDM_TopItUp()
            Dim cjro = ef.CAJEROS.Where(Function(x) x.PkCajero = idcajero).FirstOrDefault()
            ef.CAJEROS.Remove(cjro)
            ef.SaveChanges()
            llenaCajeros()
        Catch ex As Exception
            Me.lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancelarEditar_Click(sender As Object, e As EventArgs) Handles btnCancelarEditar.Click
        Try
            limpiaEditar()
            Me.panEditaCajero.Visible = False
            Me.panCrearCajero.Visible = True
            panCajerosActuales.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAceptarEditar_Click(sender As Object, e As EventArgs) Handles btnAceptarEditar.Click
        Try

            lblErrorEditar.Style.Remove("color")
            lblErrorEditar.Style.Add("color", "red")

            Dim id As Integer = Convert.ToInt32(txtidCajeroEditar.Text)
            Dim ef As New EDM_TopItUp()
            Dim Cajero As CAJEROS = ef.CAJEROS.Where(Function(x) x.PkCajero = id).FirstOrDefault()

            If Not Me.txtEditarUserName.Text.ToLower().Trim() = Cajero.UserName.ToLower().Trim() Then ' esta editando el nombre de usuario 
                'se tiene que validar que el nuevo nombre de usuario no exista aun  
                Dim nameuser As String = Me.txtEditarUserName.Text.ToLower().Trim()
                Dim existe As Integer = ef.USERS.Where(Function(x) x.USERNAME.ToLower.Trim() = nameuser).Count()

                If existe > 0 Then ' ya existe un usuario con este nombre de usuario  
                    Me.lblErrorEditar.Text = "El nombre de usuario que quiere asignar ya existe en algun usuario"
                    Exit Sub
                End If

                existe = ef.CAJEROS.Where(Function(x) x.UserName.ToLower.Trim() = nameuser).Count()

                If existe > 0 Then ' ya existe un cajero con este nombre de usuario  
                    Me.lblErrorEditar.Text = "El nombre de usuario que quiere asignar ya existe en algun cajero"
                    Exit Sub
                End If

                Cajero.UserName = Me.txtEditarUserName.Text.Trim()
            End If

            If CheckBox1.Checked Then ' entonces se reemplaza el password por el que pongan  
                Cajero.PassWord = BACK_CODE.Cripto.regresaHash(Me.txtpasswordresetear.Text.Trim())
            End If

            Dim anteriores As List(Of HORARIO_CAJERO) = ef.HORARIO_CAJERO.Where(Function(x) x.FK_CAJERO = Cajero.PkCajero).ToList()
            ef.HORARIO_CAJERO.RemoveRange(anteriores)
            ef.SaveChanges()


            If cboxeditlun.Checked Then
                Dim hclun As New HORARIO_CAJERO()
                hclun.FK_CAJERO = Cajero.PkCajero
                hclun.DIA = 1
                hclun.HORAINICIO = Convert.ToInt32(txtEditLunFrom.Text)
                hclun.HORAFINAL = Convert.ToInt32(txtEditLunHasta.Text)
                ef.HORARIO_CAJERO.Add(hclun)
            End If

            If cboxeditmar.Checked Then
                Dim hcmar As New HORARIO_CAJERO()
                hcmar.FK_CAJERO = Cajero.PkCajero
                hcmar.DIA = 2
                hcmar.HORAINICIO = Convert.ToInt32(txtEditMarFrom.Text)
                hcmar.HORAFINAL = Convert.ToInt32(txtEditMarHasta.Text)
                ef.HORARIO_CAJERO.Add(hcmar)
            End If

            If cboxeditmier.Checked Then
                Dim hcmier As New HORARIO_CAJERO()
                hcmier.FK_CAJERO = Cajero.PkCajero
                hcmier.DIA = 3
                hcmier.HORAINICIO = Convert.ToInt32(txtEditMierFrom.Text)
                hcmier.HORAFINAL = Convert.ToInt32(txteditMierHasta.Text)
                ef.HORARIO_CAJERO.Add(hcmier)
            End If

            If cboxeditjuev.Checked Then
                Dim hcjue As New HORARIO_CAJERO()
                hcjue.FK_CAJERO = Cajero.PkCajero
                hcjue.DIA = 4
                hcjue.HORAINICIO = Convert.ToInt32(txtEditJuevFrom.Text)
                hcjue.HORAFINAL = Convert.ToInt32(txtEditJuevHasta.Text)
                ef.HORARIO_CAJERO.Add(hcjue)
            End If

            If cboxeditVier.Checked Then
                Dim hcvier As New HORARIO_CAJERO()
                hcvier.FK_CAJERO = Cajero.PkCajero
                hcvier.DIA = 5
                hcvier.HORAINICIO = Convert.ToInt32(txtEditVierFrom.Text)
                hcvier.HORAFINAL = Convert.ToInt32(txtEditVierHasta.Text)
                ef.HORARIO_CAJERO.Add(hcvier)
            End If

            If cboxEditSab.Checked Then
                Dim hcsab As New HORARIO_CAJERO()
                hcsab.FK_CAJERO = Cajero.PkCajero
                hcsab.DIA = 6
                hcsab.HORAINICIO = Convert.ToInt32(txtEditSabFrom.Text)
                hcsab.HORAFINAL = Convert.ToInt32(txtEditSabHasta.Text)
                ef.HORARIO_CAJERO.Add(hcsab)
            End If

            If cboxEditDom.Checked Then
                Dim hcdom As New HORARIO_CAJERO()
                hcdom.FK_CAJERO = Cajero.PkCajero
                hcdom.DIA = 7
                hcdom.HORAINICIO = Convert.ToInt32(txtEditDomFrom.Text)
                hcdom.HORAFINAL = Convert.ToInt32(txtEditDomHasta.Text)
                ef.HORARIO_CAJERO.Add(hcdom)
            End If
            ef.SaveChanges()
            Me.panEditaCajero.Visible = False
            Me.panCrearCajero.Visible = True
            panCajerosActuales.Visible = True
            lblMensaje.Style.Remove("color")
            lblMensaje.Style.Add("color", "green")
            Me.lblMensaje.Text = "El Cajero fue editado correctamente"
            llenaCajeros()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grvCrear_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grvCrear.RowEditing
        Try
            grvCrear.EditIndex = -1
            Dim ef As New EDM_TopItUp()
            Dim idCajero As Integer = Convert.ToInt32(Me.grvCrear.DataKeys(e.NewEditIndex)("PkCajero"))
            Dim tc As List(Of TRANSACCIONES_CAJERO) = ef.TRANSACCIONES_CAJERO.Where(Function(x) x.FK_CAJERO = idCajero).ToList()
            Dim query = (From x In tc
                         Join y In ef.TRANSACCIONES.ToList() On x.FK_TRANSACCION Equals y.PK_TRANSACCION
                         Select New TCajeros With {.Fecha = y.FECHA, .Monto = y.MONTO_MTO, .Numero = y.NUMERO_RECARGA}).ToList()

            Me.gvrTransacciones.DataSource = Nothing
            Me.gvrTransacciones.DataBind()
            Me.gvrTransacciones.DataSource = query
            Me.gvrTransacciones.DataBind()

            Me.panCrearCajero.Visible = False
            Me.panCajerosActuales.Visible = False
            Me.panTransacciones.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCerrarTran_Click(sender As Object, e As EventArgs) Handles btnCerrarTran.Click
        Me.panCrearCajero.Visible = True
        Me.panCajerosActuales.Visible = True
        Me.panTransacciones.Visible = False
    End Sub


    Protected Sub btnDetalleTran_Click(sender As Object, e As EventArgs) Handles btnDetalleTran.Click
        Try
            Dim ef As New EDM_TopItUp()
            Dim userid As Integer = UsuarioConectado.PK_USER
            'Dim tc As List(Of TRANSACCIONES_CAJERO) = (From x In ef.TRANSACCIONES_CAJERO.ToList()
            '                                           Join y In ef.CAJEROS On x.FK_CAJERO Equals y.PkCajero
            '                                           Where y.Fk_Usuario = userid
            '                                           Select x).ToList()

            'Dim query = (From x In tc
            '             Join y In ef.TRANSACCIONES.ToList() On x.FK_TRANSACCION Equals y.PK_TRANSACCION
            '             Select New TCajeros With {.Fecha = y.FECHA, .Monto = y.MONTO_MTO, .Numero = y.NUMERO_RECARGA}).ToList()



            Me.gvrTransacciones.DataSource = Nothing
            Dim detalleList As New List(Of TCajeros)
            Dim detalle As TCajeros

            Dim result = ef.tu_sp_obtieneDetalleTransacciones(userid).ToList()

            For Each item As tu_sp_obtieneDetalleTransacciones_Result In result
                detalle = New TCajeros()

                detalle.Fecha = item.FECHA
                detalle.Monto = item.MONTO_MTO
                detalle.Numero = item.NUMERO_RECARGA
                detalleList.Add(detalle)
            Next


            If detalleList.Count > 0 Then
                Me.gvrTransacciones.DataBind()
                Me.gvrTransacciones.DataSource = detalleList
                Me.gvrTransacciones.DataBind()
            End If

            Me.panCrearCajero.Visible = False
            Me.panCajerosActuales.Visible = False
            Me.panTransacciones.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Me.txtpasswordresetear.Enabled = True
        Else
            Me.txtpasswordresetear.Enabled = False
        End If
    End Sub
End Class

Public Class TCajeros
    Public Property Fecha As String
    Public Property Monto As Decimal
    Public Property Numero As String
End Class