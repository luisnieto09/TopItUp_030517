Public Class TaeFast
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Shared Function GetCompanies() As List(Of CAT_TELEFONIAS)
        Try
            Dim user = HttpContext.Current.Session("USR_CONNECTED")
            Dim ef As New EDM_TopItUp()
            Dim telefonias = ef.CAT_TELEFONIAS().ToList()
            Return telefonias
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod>
    Shared Function GetAmountsByCompany(ByVal idCompany) As List(Of CAT_MONTOS_DISPONIBLES)
        Try
            Dim montdist As New List(Of CAT_MONTOS_DISPONIBLES)
            Dim disponiblebyCompani = montdist.Where(Function(x) x.FK_CAT_TELEFONIA.Equals(idCompany)).ToList()
            Return disponiblebyCompani
        Catch ex As Exception
            Throw ex
        End Try
    End Function









End Class