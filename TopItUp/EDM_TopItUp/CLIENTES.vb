'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class CLIENTES
    Public Property PK_CLIENTE As Integer
    Public Property FK_EMPRESA As Integer
    Public Property FK_CAT_RAZON_SOCIAL As Integer
    Public Property NOMBRE As String
    Public Property DIRECCION_COMPLETA As String
    Public Property TELEFONO_CONTACTO As String
    Public Property EMAIL As String
    Public Property RFC As String
    Public Property STATUS As String
    Public Property FK_CLIENTE_PADRE As Nullable(Of Integer)
    Public Property SALDO As Nullable(Of Decimal)

    Public Overridable Property CAT_RAZONES_SOCIALES As CAT_RAZONES_SOCIALES
    Public Overridable Property CAT_RAZONES_SOCIALES1 As CAT_RAZONES_SOCIALES
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
    Public Overridable Property CLIENTES1 As ICollection(Of CLIENTES) = New HashSet(Of CLIENTES)
    Public Overridable Property CLIENTES2 As CLIENTES
    Public Overridable Property CLIENTES11 As ICollection(Of CLIENTES) = New HashSet(Of CLIENTES)
    Public Overridable Property CLIENTES3 As CLIENTES
    Public Overridable Property EMPRESAS As EMPRESAS
    Public Overridable Property EMPRESAS1 As EMPRESAS
    Public Overridable Property LLAVES_TRANS_SODESI_PRONTIPAGOS As ICollection(Of LLAVES_TRANS_SODESI_PRONTIPAGOS) = New HashSet(Of LLAVES_TRANS_SODESI_PRONTIPAGOS)
    Public Overridable Property LLAVES_TRANS_SODESI_PRONTIPAGOS1 As ICollection(Of LLAVES_TRANS_SODESI_PRONTIPAGOS) = New HashSet(Of LLAVES_TRANS_SODESI_PRONTIPAGOS)
    Public Overridable Property NOTICIAS_CLIENTES As ICollection(Of NOTICIAS_CLIENTES) = New HashSet(Of NOTICIAS_CLIENTES)
    Public Overridable Property NOTICIAS_CLIENTES1 As ICollection(Of NOTICIAS_CLIENTES) = New HashSet(Of NOTICIAS_CLIENTES)
    Public Overridable Property TELEFONIAS_CLIENTES As ICollection(Of TELEFONIAS_CLIENTES) = New HashSet(Of TELEFONIAS_CLIENTES)
    Public Overridable Property TELEFONIAS_CLIENTES1 As ICollection(Of TELEFONIAS_CLIENTES) = New HashSet(Of TELEFONIAS_CLIENTES)

End Class
