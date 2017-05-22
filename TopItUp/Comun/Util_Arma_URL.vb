Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Util_ArmaURL
    Private URLArmada As StringBuilder

    Public Sub New()
        URLArmada = New StringBuilder()
    End Sub

    Private m_baseURL As String

    Public ReadOnly Property GetURL() As String
        Get
            Return URLArmada.ToString()
        End Get
    End Property

    Public Property BaseURL() As String
        Get
            Return m_baseURL
        End Get
        Set(value As String)
            URLArmada.Append(value)
            m_baseURL = value
        End Set
    End Property

    Public Sub AddParameter(nombreParametro As String, valor As String)
        AdiereSeparadorParametros()
        URLArmada.AppendFormat(nombreParametro & Convert.ToString("={0}"), valor)

    End Sub

    Public Sub AddParameter(nombreParametro As String, valor As DateTime)
        AdiereSeparadorParametros()
        URLArmada.AppendFormat(nombreParametro & Convert.ToString("={0}"), valor)
    End Sub

    Public Sub AddParameter(nombreParametro As String, valor As Decimal)
        AdiereSeparadorParametros()
        URLArmada.AppendFormat(nombreParametro & Convert.ToString("={0}"), valor)
    End Sub

    Public Sub AddParameter(nombreParametro As String, valor As Integer)
        AdiereSeparadorParametros()
        URLArmada.AppendFormat(nombreParametro & Convert.ToString("={0}"), valor)
    End Sub

    Public Sub AddParameter(nombreParametro As String, valor As Double)
        AdiereSeparadorParametros()
        URLArmada.AppendFormat(nombreParametro & Convert.ToString("={0}"), valor)
    End Sub

    Private Sub AdiereSeparadorParametros()
        If URLArmada.ToString().Contains("?"c) Then
            URLArmada.Append("&")
        Else
            URLArmada.Append("?")
        End If
    End Sub
End Class
