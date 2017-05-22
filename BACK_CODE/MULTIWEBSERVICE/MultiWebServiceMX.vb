Imports System.Xml
Imports System.Configuration
Public Class MultiWebServiceMX
    Private UserMultiwebService As String
    Private PasswordMultiWebService As String
    Private ClaveSeguridadMultiWebService As String

    Public Sub New()
        UserMultiwebService = ConfigurationManager.AppSettings("UserMultiwebService")
        PasswordMultiWebService = ConfigurationManager.AppSettings("PasswordMultiWebService")
        ClaveSeguridadMultiWebService = ConfigurationManager.AppSettings("ClaveSeguridadMultiWebService")
    End Sub
    Public Function Venta(ByRef compania As String, ByVal numero As String, ByVal monto As String) As ArrayList
        Dim arResult As New ArrayList()
        'Dim iservice = New net.Recargas_Electronicas.MX.Recargas_ElectronicasSoapClient()
        'Dim resultado = iservice.TAE("dfsdfsdf", PasswordMultiWebService, "iusacell", "5510496310", "50", "")

        Dim iservice= New net.itmultiwebservice.www.Recargas_Electronicas()

        Dim resultado
        resultado = Nothing

        'Dim saldo = iservice.TAESALDO(UserMultiwebService, PasswordMultiWebService)
        resultado = iservice.TAE(UserMultiwebService, PasswordMultiWebService, compania.ToLower(), numero, monto, "")
        'saldo = iservice.TAESALDO(UserMultiwebService, PasswordMultiWebService)

        iservice.Dispose()
        iservice.Abort()
        Dim strMsg As String = String.Empty

        If (resultado.Contains("<error>")) Then
            'No se pudo procesar la transaccón y al final regresará el arreglo vacío
            strMsg = resultado.ToString.Replace("<error>", "").Replace("</error>", "") & ". Mensaje con fecha: " & Date.Now

            If strMsg.Contains("R2") Then
                strMsg = "Para recargar el mismo número [ " & numero & " ] debe esperar al menos 2 minutos. Mensaje con fecha: " & Date.Now
                arResult.Insert(0, strMsg) 'MENSAJE POR RECARGA CONSECUTIVA
                ''''mensaje multiweb cuando tiene errores por falta de saldo, operación u otro.
                'Else
                '    arResult.Insert(0, strMsg) 'MENSAJE POR RECARGA CONSECUTIVA
            Else
                'strMsg = resultado.ToString & ". Mensaje con fecha: " & Date.Now

                Dim mail As New BACK_CODE.EnviaCorreo()
                Try
                    arResult.Insert(0, strMsg) 'MENSAJE POR ERROR EN MULTIWEB
                    mail.EnviaCorreo("Error Recarga TAE MultiWeb MX: " & strMsg, "ERROR MultiWebServices MX ", True)
                Catch exX As Exception
                End Try

            End If
        Else
            'Verifico Folio y Transacción
            Dim xmlDoc As New XmlDocument()
            Dim root As XmlElement
            Dim node As XmlNode
            xmlDoc.LoadXml(resultado)

            node = xmlDoc.FirstChild
            root = xmlDoc.DocumentElement

            arResult.Insert(0, root.ChildNodes(5).InnerText)

            If arResult.Item(0).ToString = "-1" Then
                'TRANSACCIÓN EXITOSA Y DEJA CONTINUAR
                arResult.Insert(1, root.ChildNodes(6).InnerText) 'FOLIO
                arResult.Insert(2, root.ChildNodes(7).InnerText) 'TRANSACCIÓN
            Else
                arResult.Clear()
            End If

            Dim resultado2 = iservice.TAESALDO(UserMultiwebService, PasswordMultiWebService)
            Dim mail As New BACK_CODE.EnviaCorreo()
            Try
                'arResult.Insert(0, strMsg) 'MENSAJE POR ERROR EN MULTIWEB
                mail.EnviaCorreo("Saldo multiwebservices: " & resultado2, "saldo multiweb", True)
            Catch exX As Exception
            End Try
        End If

        Return arResult
    End Function

End Class
