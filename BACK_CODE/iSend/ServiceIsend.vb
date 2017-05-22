Imports System.Configuration

Public Class ServiceIsend
    Private AgentID As Integer
    Private AgentPassword As String
    Private CodigoLadaMexico As String

    Public Sub New()
        AgentID = ConfigurationManager.AppSettings("AgentID")
        AgentPassword = ConfigurationManager.AppSettings("AgentPassword")
        CodigoLadaMexico = ConfigurationManager.AppSettings("CodigoLadaMexico")
    End Sub

    Public Function Venta(ByVal cantidad As Integer,
                                  ByVal reference As String,
                                  ByVal Compania As String, Optional ByVal ExternalTransactionID As String = "",
                                  Optional ByVal Lada As String = "", Optional ByVal BillerId As Integer = 0) 'As ReferenceIsend.PostPaymentResponse 'Comment by BDA 2017-02-12

        'Dim referencia As New ReferenceIsend.iSendServiceSoapClient()
        'Dim billers As New ReferenceIsend.ListOfBillersRequest()
        'Dim iservice As New com.isendonline.test.iSendService()
        'Dim ListOfBillers As New com.isendonline.test.ListOfBillersRequest()
        'Dim paymentRequest As New com.isendonline.test.PostSimplePaymentRequest()
        'Dim getInfoAgnets As New com.isendonline.test.GetAgentInfoRequest()
        'Dim getOperatorRequest As New com.isendonline.test.GetOperatorsRequest()
        'Dim biller As New com.isendonline.test.BillerData()
        Try



            Dim iservice As New ReferenceIsend.iSendServiceSoapClient()
            Dim ListOfBillers As New ReferenceIsend.ListOfBillersRequest()
            Dim paymentRequest As New ReferenceIsend.PostSimplePaymentRequest()
            Dim getInfoAgnets As New ReferenceIsend.GetAgentInfoRequest()
            Dim getOperatorRequest As New ReferenceIsend.GetOperatorsRequest()
            Dim biller As New ReferenceIsend.BillerData()

            If Lada = "" Then
                Lada = CodigoLadaMexico
            End If

            getOperatorRequest.AgentID = AgentID
            getOperatorRequest.AgentPassword = AgentPassword
            getOperatorRequest.Phone = Lada + reference
            getOperatorRequest.ShowCarrierName = True

            Dim getOperatorResponse = iservice.GetOperators(getOperatorRequest)


            'Dim res = GetOperatorByPhone(Lada + reference)

            Dim partenombre As String = String.Format("{0} MXP", cantidad.ToString().Replace(".00", ""))

            biller = getOperatorResponse.BillerList.Where(Function(x) x.Name.Contains(partenombre)).Where(Function(x) x.CarrierName.ToLower().Trim() = Compania.ToLower().Trim()).FirstOrDefault()

            If (biller Is Nothing) Then
                Throw New Exception("Monto no disponible isend")
            End If

            cantidad = biller.MaxAmount  'cantidad * biller.BillerServiceList.FirstOrDefault().ExchangeRate



            'If BillerId = 0 Then
            '    cantidad = cantidad * getOperatorResponse.BillerList(0).BillerServiceList(0).ExchangeRate
            '    biller = getOperatorResponse.BillerList.Where(Function(r) r.MaxAmount = cantidad).FirstOrDefault()
            'Else
            '    biller = getOperatorResponse.BillerList.Where(Function(r) r.BillerID = BillerId).FirstOrDefault()
            '    cantidad = biller.MaxAmount
            'End If

            getInfoAgnets.AgentID = AgentID
            getInfoAgnets.AgentPassword = AgentPassword

            Dim getInfoResponse = iservice.GetAgentInfo(getInfoAgnets)
            Dim _fecha As DateTime = DateTime.Now

            paymentRequest.AgentID = AgentID
            paymentRequest.AgentPassword = AgentPassword
            paymentRequest.ExternalTransactionID = _fecha.Year.ToString() + _fecha.Month.ToString() + _fecha.Day.ToString() + _fecha.Hour.ToString() + _fecha.Second.ToString() + _fecha.Millisecond.ToString()
            paymentRequest.ValidateOnly = False
            paymentRequest.Amount = cantidad
            paymentRequest.Account = getOperatorRequest.Phone
            paymentRequest.BillerID = biller.BillerID
            paymentRequest.PaymentServiceTypeID = biller.BillerServiceList(0).PaymentServiceTypeID
            paymentRequest.EntryTimeStamp = DateTime.Now

            Dim paymentResponse = iservice.PostSimplePayment(paymentRequest)

            Return paymentResponse
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCountries() As com.isendonline.test.ListOfCountryResponse
        Try
            Dim iservice As New com.isendonline.test.iSendService()
            Dim ListOfCountry As New com.isendonline.test.ListOfCountryRequest()
            ListOfCountry.AgentID = AgentID
            ListOfCountry.AgentPassword = AgentPassword
            Dim countries = iservice.GetCountries(ListOfCountry)
            Return countries
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getBillersByCountry(ByVal idCountry As Integer) As com.isendonline.test.ListOfBillersResponse
        Try
            Dim ListOfBillers As New com.isendonline.test.ListOfBillersRequest()
            ListOfBillers.AgentID = AgentID
            ListOfBillers.AgentPassword = AgentPassword
            ListOfBillers.CountryID = idCountry
            Dim iservice As New com.isendonline.test.iSendService()
            Dim billers = iservice.GetBillers(ListOfBillers)
            Return billers
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getBillersByCountryAndCarrierName(ByVal idCountry As Integer, ByVal CarrierName As String) As List(Of com.isendonline.test.BillerData)
        Try
            Dim ListOfBillers As New com.isendonline.test.ListOfBillersRequest()
            ListOfBillers.AgentID = AgentID
            ListOfBillers.AgentPassword = AgentPassword
            ListOfBillers.CountryID = idCountry
            Dim iservice As New com.isendonline.test.iSendService()
            Dim billers = iservice.GetBillers(ListOfBillers).BillerList.Where(Function(t) t.Name.Contains(CarrierName)).ToList()
            Return billers
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCarrierDistinctByCountry(ByVal idCountry As Integer) As List(Of String)
        Try
            Dim billers = getBillersByCountry(idCountry)

            Dim listCarrier As List(Of String) = billers.BillerList.
           Select(Function(c) c.Name.Split("-").ToList()(0).Trim().ToString()).Distinct().ToList()

            Return listCarrier
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetOperatorByPhone(ByRef PhoneNumber As String) As com.isendonline.test.ListOfBillersResponse
        Try
            Dim ListOfBillers As New com.isendonline.test.ListOfBillersRequest()
            Dim getoperatorreq As New com.isendonline.test.GetOperatorsRequest
            getoperatorreq.AgentID = AgentID
            getoperatorreq.AgentPassword = AgentPassword
            getoperatorreq.Phone = PhoneNumber
            getoperatorreq.ShowCarrierName = True
            Dim iservice As New com.isendonline.test.iSendService()
            Dim respuesta = iservice.GetOperators(getoperatorreq)
            Return respuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
