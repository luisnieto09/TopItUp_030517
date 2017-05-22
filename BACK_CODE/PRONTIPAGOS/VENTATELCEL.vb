'Imports BACK_CODE.ProntipagosClientService
'Imports BACK_CODE.ProntipagosService
Imports BACK_CODE.ProntipagosTopUpService



Public Class VENTATELCEL

    Dim Sv As New ProntipagosTopUpServiceEndPointClient()

    Public Sub New()
        Sv.ClientCredentials.UserName.UserName = "habernet@mobile.com"
        Sv.ClientCredentials.UserName.Password = "54710"
    End Sub

        


    ''' <summary>
    ''' recargaTelcel
    ''' </summary>
    ''' <param name="cantidad">CANTIDAD A PAGAR TIPO DOUBLE</param>
    ''' <param name="reference">NUMERO TELEFONICO O IDENTIFACODOR RECIBO DE SERVICIO TIPO STRING</param>
    ''' <param name="sku">SI ES NULL SE ASUME QUE ES VENTA TAE , SI NO ES VENTA DE SERVICIO TIPO STRING </param>
    ''' <param name="referenciaCliente">ID DE CLIENTE SI --> NULL ENTONCES ID = 1, nota: regresa null si el servicio no respondio </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Venta(ByVal cantidad As Double,
                                  ByVal reference As String,
                                  ByVal sku As String,
                                  ByVal referenciaCliente As String) As transactionResponseDto
        Try
            Dim respuesta = Sv.sellServiceAsync(cantidad, reference, sku, referenciaCliente)



            Dim catalogo As responseCatalogProductTO
            catalogo = Sv.obtainCatalogProducts()


            Dim ok As Boolean
            ok = False

            For x As Int16 = 0 To 5 Step 1
                If respuesta.IsCompleted Then
                    ok = True
                    Exit For
                Else
                    System.Threading.Thread.Sleep(1000) ' esoera un segundo para ver si ya termino de ejecutarse la llamada 
                End If
            Next
            If Not ok Then
                respuesta.Dispose()
                Return Nothing
            End If
            Dim resultado As sellServiceResponse = respuesta.Result
            Return resultado.return
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' ValidaEstatusTransaccion
    ''' </summary>
    ''' <param name="transactionId">CODIGO DE TRANSACCION PARA VERIFICAR SU ESTATUS</param>
    ''' <param name="referenciaCliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidaEstatusTransaccion(ByVal transactionId As String,
                                             ByVal referenciaCliente As Integer) As transactionResponseTO
        Try
            'Sv.Open()
            Dim respuesta = Sv.checkStatusService(transactionId, referenciaCliente)
            'Sv.Close()
            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' regresa balance  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Balance() As responseBalanceTO
        Try
            'Sv.Open()
            Dim respuesta = Sv.balanceService()
            'Sv.Close()
            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' regresa Catalogo de productos 
    ''' </summary>
    ''' <returns>responseCatalogProductTO</returns>
    ''' <remarks></remarks>
    Public Function ObtieneProductos() As responseCatalogProductTO
        Try

            'Sv.Open()
            Dim respuesta = Sv.obtainCatalogProducts()
            'Sv.Close()
            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
