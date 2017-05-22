
Public Class ctasBancariass
    Inherits BasePage

    Private Property soloTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property

    Private Property UserConectado As USERS
        Set(value As USERS)
            Session("USR") = value
        End Set
        Get
            Return Session("USR")
        End Get
    End Property

    Private Property CteConectado As CLIENTES
        Set(value As CLIENTES)
            Session("CTE") = value
        End Set
        Get
            Return Session("CTE")
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not UserConectado.FK_ACCESS_GROUP = 1 Then
                Response.Redirect("../Pages/Taelectronico.aspx")
            End If

            If Not Page.IsPostBack Then

                If soloTelcel Then
                    logoTelcel.Visible = True
                    imglogox.ImageUrl = "../Images/recargastelcel.png"
                Else
                    logoTelcel.Visible = False
                    imglogox.ImageUrl = "../Images/recargamultimarcas.png"
                End If
                If UserConectado.FK_ACCESS_GROUP = 1 Then
                    filaBanco.Visible = True
                Else
                    filaBanco.Visible = False

                End If

                lblFechaSaldo.Text = Date.Now.ToShortDateString()
                Select Case UserConectado.FK_ACCESS_GROUP
                    Case 1
                        Me.lblTipoUser.Text = "ADMINISTRADOR MAESTRO"
                    Case 2
                        Me.lblTipoUser.Text = "DISTRIBUIDOR AUTORIZADO"
                    Case 3
                        Me.lblTipoUser.Text = "CAJERO"
                End Select
                Dim clsGeneric As New clsGenerics()
                Try
                    lblSaldoCliente.Text = clsGeneric.func_GetSaldoUsr(UserConectado.PK_USER)
                Catch ex As Exception
                    lblSaldoCliente.Text = 0.0
                End Try

                llenaComboBancos()
                llenaGridBancos()
                llenaGridCtasBancarias()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnAgregaBanco_Click(sender As Object, e As EventArgs) Handles btnAgregaBanco.Click
        Try
            Me.lblmensajebanco.Text = ""
            If String.IsNullOrWhiteSpace(txtNombreCorto.Text.Trim()) Then
                Throw New Exception("Favor de indicar el nombre del banco")
            End If
            Dim ef As New EDM_TopItUp()
            Dim banco As New CAT_BANCOS()
            banco.DESCRIPCION = txtNombreBanco.Text
            banco.NOMBRE_CORTO = txtNombreCorto.Text
            banco.STATUS = "1"
            banco.NOMBRE_EJECUTIVO = ""
            banco.NOMBRE_SUCURSAL = ""
            banco.SUCURSAL = ""
            ef.CAT_BANCOS.Add(banco)
            ef.SaveChanges()
            llenaComboBancos()
            llenaGridBancos()
            llenaGridCtasBancarias()
            Me.lblmensajebanco.Text = "El banco se guardo de forma exitosa"
        Catch ex As Exception
            Me.lblmensajebanco.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Me.lblMensajeCtaBancaria.Text = ""
            Dim ef As New EDM_TopItUp()
            Dim cta As New CTAS_BANCARIAS_EMPRESAS()
            If String.IsNullOrWhiteSpace(txtNumeroCuenta.Text.Trim()) Then
                Throw New Exception("Es necesario indicar el numero de cuenta")
            End If
            If ddlBanco.SelectedValue = 0 Then
                Throw New Exception("Ex necesario seleccionar un banco para la cuenta bancaria")
            End If

            cta.FK_EMPRESA = 1
            cta.FK_CAT_BANCO = ddlBanco.SelectedValue
            cta.CONVENIO = txtConvenio.Text
            cta.NUMERO_CTA = txtNumeroCuenta.Text
            cta.REFERENCIA = txtReferencia.Text
            cta.STATUS = "1"
            cta.CLABE = txtClabe.Text
            ef.CTAS_BANCARIAS_EMPRESAS.Add(cta)
            ef.SaveChanges()
            Me.lblMensajeCtaBancaria.Text = "La cuenta bancaria se guardo exitosamente"
            llenaGridCtasBancarias()
        Catch ex As Exception
            Me.lblMensajeCtaBancaria.Text = ex.Message
        End Try
    End Sub

    Protected Sub gvrCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvrCuentas.SelectedIndexChanged
        Try
            Dim id As Integer = Convert.ToInt32(gvrCuentas.SelectedDataKey("Id"))
            Dim ef As New EDM_TopItUp()
            Dim cta = ef.CTAS_BANCARIAS_EMPRESAS.Where(Function(x) x.PK_CTA_BANCARIA_EMPRESA = id).FirstOrDefault()
            If cta.STATUS = "1" Then
                cta.STATUS = "0"
            Else
                cta.STATUS = "1"
            End If
            ef.SaveChanges()
            llenaGridCtasBancarias()
        Catch ex As Exception
            Me.lblMensajeCtaBancaria.Text = ex.Message
        End Try
    End Sub

    Protected Sub gvrGridBancos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvrGridBancos.SelectedIndexChanged
        Try
            Dim ef As New EDM_TopItUp()
            Dim id As Integer = Convert.ToInt32(gvrGridBancos.SelectedDataKey("Id"))
            Dim banco = ef.CAT_BANCOS.Where(Function(x) x.PK_CAT_BANCO = id).FirstOrDefault()
            If banco.STATUS = "1" Then
                banco.STATUS = "0"
            Else
                banco.STATUS = "1"
            End If
            ef.SaveChanges()
            llenaGridBancos()
            llenaComboBancos()
        Catch ex As Exception
            Me.lblmensajebanco.Text = ex.Message
        End Try
    End Sub

    Private Sub llenaGridBancos()
        Try
            Dim ef As New EDM_TopItUp()
            Dim bancoas = ef.CAT_BANCOS()
            Me.gvrGridBancos.DataSource = Nothing
            Me.gvrGridBancos.DataBind()
            Dim query = From x In bancoas
                        Select New With {Key .Id = x.PK_CAT_BANCO,
                                          Key .Nombre = x.NOMBRE_CORTO,
                                          Key .Descripcion = x.DESCRIPCION,
                                          Key .Habilitado = If(x.STATUS = "1", "Si", "No")}

            Me.gvrGridBancos.DataSource = query.ToList()
            Me.gvrGridBancos.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub llenaGridCtasBancarias()
        Try
            Dim ef As New EDM_TopItUp()
            Dim ctabancarias = ef.CTAS_BANCARIAS_EMPRESAS()
            Dim bancos = ef.CAT_BANCOS()
            Dim query = From x In ctabancarias
                        Join y In bancos On x.FK_CAT_BANCO Equals y.PK_CAT_BANCO
                        Select New With {Key .Id = x.PK_CTA_BANCARIA_EMPRESA,
                                          Key .Banco = y.NOMBRE_CORTO,
                                          Key .NumCuenta = x.NUMERO_CTA,
                                          Key .Clabe = x.CLABE,
                                          Key .Convenio = x.CONVENIO,
                                          Key .Referencia = x.REFERENCIA,
                                          Key .Habilitado = If(x.STATUS = "1", "Si", "No")}

            Me.gvrCuentas.DataSource = Nothing
            Me.gvrCuentas.DataBind()
            Me.gvrCuentas.DataSource = query.ToList()
            Me.gvrCuentas.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub llenaComboBancos()
        Try
            Dim ef As New EDM_TopItUp()
            Dim bancos = ef.CAT_BANCOS().Where(Function(x) x.STATUS = "1").ToList()
            Me.ddlBanco.DataSource = Nothing
            Me.ddlBanco.DataBind()
            Me.ddlBanco.DataSource = bancos
            Me.ddlBanco.DataTextField = "NOMBRE_CORTO"
            Me.ddlBanco.DataValueField = "PK_CAT_BANCO"
            Me.ddlBanco.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class