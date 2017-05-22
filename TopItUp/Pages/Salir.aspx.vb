Public Class Salir
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim istelcel As Boolean = Convert.ToBoolean(Session("propVgBlOnlyTelcel"))
            Session.Clear()
            Session.RemoveAll()
            If istelcel Then
                Response.Redirect("../Default.aspx")
            Else
                Response.Redirect("../Otras.aspx")
            End If

        End If
    End Sub

End Class