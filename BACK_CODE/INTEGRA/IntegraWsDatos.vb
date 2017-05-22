Imports System.Configuration
'Imports BACK_CODE.IntegraWs
Imports BACK_CODE.TerriaService
Imports BACK_CODE.StringExtension




Public Class IntegraWsDatos

    Private company As String
    Private user As String
    Private password As String

    Public Sub New()
        company = ConfigurationManager.AppSettings("IntegraCompany").ToString()
        user = ConfigurationManager.AppSettings("IntegraUsr").ToString()
        password = ConfigurationManager.AppSettings("IntegraPwd").ToString()
    End Sub


    Public Function Login() As String
        Try
            Dim sv = New TerriaService.ServiceClient()
            sv.Open()
            Dim respuesta = sv.login(company, user, password)
            sv.Close()
            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Venta(ByVal ticket As String,
                          ByVal storedid As Integer,
                          ByVal accountno As String,
                          ByVal amount As String,
                          ByVal phoneNumber As String,
                          ByVal compania As String) As String
        Try
            Dim PRODUCTID As String = ""
            Dim sv = New serviceClient()
            sv.Open()
            Dim fechahoy = DateTime.Now
            amount = amount.Replace(".00", "").Replace(".0", "")
            Dim prefijo As String = ConfigurationManager.AppSettings("IntegraPrefijo")
            prefijo += fechahoy.Year.ToString() + fechahoy.Month.ToString().PadLeft(2, "0") + fechahoy.Day.ToString().PadLeft(2, "0") + fechahoy.Minute.ToString().PadLeft(2, "0") + fechahoy.Second().ToString().PadLeft(2, "0") + fechahoy.Millisecond.ToString().PadLeft(2, "0")

            PRODUCTID = getsku(compania, amount)

            If (compania = "telcel") Then
                If (amount.Length = 2) Then
                    PRODUCTID = "TAE0" + amount
                End If
                If (amount.Length = 3) Then
                    PRODUCTID = "TAE" + amount
                End If
            End If

            'If (compania = "movistar") Then
            '    If (amount.Length = 2) Then
            '        PRODUCTID = "MOVI0" + amount
            '    End If
            '    If (amount.Length = 3) Then
            '        PRODUCTID = "MOVI" + amount
            '    End If
            'End If

            Dim respuesta = sv.saleRequest(ticket, Convert.ToInt32(storedid), accountno, prefijo, PRODUCTID, phoneNumber, amount)

            If (respuesta.Contains("<error>")) Then
                Return "<error>"
            End If

            Dim trnresponse = respuesta.GetValueFromStringXml("<trnresponse>")

            If Not trnresponse.Trim().Equals("00") Then
                Return False
            End If
            'Dim respuestafinal = sv.saleCheck(ticket, prefijo)
            sv.Close()

            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getsku(ByVal compania As String, ByVal cantidad As String) As String
        Try

            Dim sku As String = ""
            compania = compania.ToUpper().Trim()

            Select Case compania
                Case "MOVISTAR"
                    sku = "MOV"
                Case "IUSACELL"
                    sku = "IUS"
                Case "UNEFON"
                    sku = "UNE"
                Case "NEXTEL"
                    sku = "NEX"
                Case "VIRGIN"
                    sku = "VIR"
            End Select

            sku = sku + If(cantidad.Length > 2, cantidad, "0" + cantidad)

            Return sku

        Catch ex As Exception
            Return ""
        End Try
    End Function


End Class
