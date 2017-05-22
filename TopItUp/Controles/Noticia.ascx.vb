Imports System.Globalization

Public Class Noticia
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblDia.Text = DateTime.Now.ToString("dddd dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX")).ToUpper

        Try
            Dim PK_noticias_cliente = vgObjModelo.CLIENTES_USERS.Where(Function(ere) ere.FK_USER = Me.vgPropObjUserConnected.PK_USER).First()

            Dim noticias_cliente = vgObjModelo.sp_get_Noticias(PK_noticias_cliente.FK_CLIENTE).ToList()

            For Each NOTI In noticias_cliente
                lblNoticia.Text &= NOTI
            Next

        Catch ex As Exception

        End Try
    End Sub

End Class