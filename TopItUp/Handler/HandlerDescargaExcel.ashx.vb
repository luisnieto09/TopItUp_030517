Imports System.Web
Imports System.Web.Services
Imports System.Security.Cryptography
Imports System.IO

Public Class HandlerDescargaExcel
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim ruta As String = context.Request.Params.[Get]("rutaArchivo")
        Dim NombreArchivo As String = context.Request.Params.[Get]("nombreArchivo")

        Dim toDownload As System.IO.FileInfo = New System.IO.FileInfo(ruta)

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" & NombreArchivo)
        HttpContext.Current.Response.AddHeader("Content-Length", toDownload.Length.ToString())
        HttpContext.Current.Response.ContentType = "application/octet-stream"
        HttpContext.Current.Response.WriteFile(ruta)
        HttpContext.Current.Response.End()
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    
End Class