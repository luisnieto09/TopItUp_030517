'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class USER
    Public Property PK_USER As Integer
    Public Property AP_PATERNO As String
    Public Property AP_MATERNO As String
    Public Property NOMBRE As String
    Public Property STATUS As String
    Public Property EMAIL As String
    Public Property USERNAME As String
    Public Property PASSWORD As String
    Public Property FK_ACCESS_GROUP As Nullable(Of Integer)
    Public Property bloqueado As String

    Public Overridable Property ACCESOS As ICollection(Of ACCESO) = New HashSet(Of ACCESO)
    Public Overridable Property ACCESOS1 As ICollection(Of ACCESO) = New HashSet(Of ACCESO)
    Public Overridable Property ACCESS_GROUPS As ACCESS_GROUPS
    Public Overridable Property ACCESS_GROUPS1 As ACCESS_GROUPS
    Public Overridable Property CLIENTES_USERS As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS1 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS2 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS3 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS4 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS5 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS6 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS7 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS8 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS9 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS10 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property CLIENTES_USERS11 As ICollection(Of CLIENTES_USERS) = New HashSet(Of CLIENTES_USERS)
    Public Overridable Property DUDAS_COMENTARIOS As ICollection(Of DUDAS_COMENTARIOS) = New HashSet(Of DUDAS_COMENTARIOS)
    Public Overridable Property DUDAS_COMENTARIOS1 As ICollection(Of DUDAS_COMENTARIOS) = New HashSet(Of DUDAS_COMENTARIOS)
    Public Overridable Property PAGES_USERS As ICollection(Of PAGES_USERS) = New HashSet(Of PAGES_USERS)
    Public Overridable Property PAGES_USERS1 As ICollection(Of PAGES_USERS) = New HashSet(Of PAGES_USERS)
    Public Overridable Property PAGOS As ICollection(Of PAGO) = New HashSet(Of PAGO)
    Public Overridable Property PAGOS1 As ICollection(Of PAGO) = New HashSet(Of PAGO)
    Public Overridable Property SALDOS As ICollection(Of SALDO) = New HashSet(Of SALDO)
    Public Overridable Property SALDOS1 As ICollection(Of SALDO) = New HashSet(Of SALDO)
    Public Overridable Property TRANSACCIONES As ICollection(Of TRANSACCIONE) = New HashSet(Of TRANSACCIONE)
    Public Overridable Property TRANSACCIONES1 As ICollection(Of TRANSACCIONE) = New HashSet(Of TRANSACCIONE)

End Class
