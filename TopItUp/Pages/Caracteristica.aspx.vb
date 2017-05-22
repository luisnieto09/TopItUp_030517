Public Class Caracteristica
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Convert.ToBoolean(Session("isCajero")) = True Then
                Response.Redirect("../Pages/TaElectronico.aspx")
            End If


            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-MX")
        End If
    End Sub

End Class