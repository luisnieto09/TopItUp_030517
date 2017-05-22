Imports System.Web

Public Class BasePage
    Inherits Page

    Dim vgObjModelo As New EDM_TopItUp

    Protected Overrides Sub OnPreInit(e As EventArgs)
        If Session("USR_CONNECTED") Is Nothing Then
            Session("ERROR") = "SIN PRIVILEGIOS, FAVOR DE INGRESAR SUS DATOS DE ACCESO"
            'Response.Redirect("../hjhshajhjhjh.ASPX")
            Response.Redirect("../" + Constantes.PaginaInicio)
        End If
    End Sub
End Class
