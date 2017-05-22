Imports System.Configuration

Public Class ProcomDtos

    Private _usr As String
    Public Property Usr As String
        Get
            Return _usr
        End Get
        Set(value As String)
            _usr = value
        End Set
    End Property

    Private _password As String
    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Sub New()
        Usr = ConfigurationManager.AppSettings("userprocom").ToString()
        Password = ConfigurationManager.AppSettings("passprocom").ToString()
    End Sub


    Public Function VendeByProcom(ByVal compania As String, ByVal numero As String, ByVal cantidad As String, ByRef foliotransaccion As String) As String
        Try
            Dim sv As New ProcomServiceRef.posPortTypeClient()
            Dim idcompnay As Integer = GetCodeByDescription(compania)
            Dim respuesta = sv.doTransaction(Usr, Password, numero, idcompnay, Convert.ToInt32(cantidad.Replace(".00", "")), "WEB")
            If Not respuesta.codigo = "1" Then
                Throw New Exception(respuesta.descripcionResultado)
            Else
                foliotransaccion = respuesta.folioTaePue + "-" + respuesta.transaccionExterna
            End If
            Return "true-" + foliotransaccion
        Catch ex As Exception
            Return "false-" + ex.Message
        End Try
    End Function

    Public Function GetCodeByDescription(ByVal Company As String) As Integer
        Try
            Company = Company.ToUpper().Trim()
            Select Case Company
                Case "TELCEL" : Return 1
                Case "MOVISTAR" : Return 2
                Case "IUSACELL" : Return 3
                Case "UNEFON" : Return 4
                Case "NEXTEL" : Return 5
                Case "VIRGIN" : Return 6
                Case "MAZTIEMPO" : Return 7
                Case Else : Return 0
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Function






End Class
