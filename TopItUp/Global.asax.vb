Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    'Private Property propVgBlOnlyTelcel As Boolean
    '    Set(value As Boolean)
    '        Session("propVgBlOnlyTelcel") = value
    '    End Set
    '    Get
    '        Return CType(Session("propVgBlOnlyTelcel"), Boolean)
    '    End Get
    'End Property


    '    If Session("USR_CONNECTED") Is Nothing Then
    '    Session("ERROR") = "SIN CONEXIÓN, FAVOR DE INGRESAR SUS DATOS DE ACCESO"
    '    Try
    '        If propVgBlOnlyTelcel = True Then
    '            Response.Redirect("../Default.aspx")
    '        Else
    '            Response.Redirect("../Otras.aspx")
    '        End If
    '    Catch ex As Exception
    '        Response.Redirect("../Default.aspx")
    '    End Try
    'End If

    Sub Application_Start(sender As Object, e As EventArgs)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends    
    End Sub

    Private Sub Global_asax_EndRequest(sender As Object, e As EventArgs) Handles Me.EndRequest
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class