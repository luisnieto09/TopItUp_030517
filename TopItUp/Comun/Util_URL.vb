Public Class Util_URL
    Private Shared ReadOnly instance As New Lazy(Of Util_URL)(Function() New Util_URL())

        Private Sub New()
        End Sub

    Public Shared Function getInstance() As Util_URL
        Return instance.Value
    End Function

    Public HANDLER_DESCARGA_EXCEL As String = "~/Handler/HandlerDescargaExcel.ashx"
End Class