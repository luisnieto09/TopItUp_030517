Public Class TopBar
    Inherits System.Web.UI.UserControl
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

    Public Property saldocontrol As String
        Set(value As String)
            lblHEadsaldo.Text = value
        End Set
        Get
            Return lblHEadsaldo.Text
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim clsGeneric As New clsGenerics()
            Dim tipouser = Convert.ToInt32(vgPropObjUserConnected.FK_ACCESS_GROUP)
            Dim strtipouser As String = ""
            If tipouser = 1 Then
                strtipouser = "Administrador Maestro"
            ElseIf tipouser = 2 Then
                strtipouser = "Distribuidor Autorizado"
            Else
                strtipouser = "N/A"
            End If

            Dim _saldo = clsGeneric.func_GetSaldoUsr(Me.vgPropObjUserConnected.PK_USER)
            Dim strsaldo = FormatNumber(_saldo, 2)

            lblHeadone.Text = String.Format("Cliente:{0} Tipo:{1} ", vgPropObjUserConnected.NOMBRE, strtipouser)
            lblHeadTwo.Text = String.Format("Saldo Actualizado a {0}: $", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())
            lblHEadsaldo.Text = strsaldo

        Catch ex As Exception

        End Try
    End Sub

End Class