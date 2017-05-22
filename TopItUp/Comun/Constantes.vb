Imports System.Configuration.Configuration
Public Class Constantes

    Public Shared PaginaInicio As String = ConfigurationManager.AppSettings("PaginaInicio").ToString()

End Class
