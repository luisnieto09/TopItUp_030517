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

Partial Public Class CAT_TELEFONIAS
    Public Property PK_CAT_TELEFONIA As Integer
    Public Property NOMBRE_CORTO As String
    Public Property DESCRIPCION As String
    Public Property STATUS As String
    Public Property statusW As Nullable(Of Boolean)
    Public Property statusWP As Nullable(Of Boolean)

    Public Overridable Property CAT_MONTOS_DISPONIBLES As ICollection(Of CAT_MONTOS_DISPONIBLES) = New HashSet(Of CAT_MONTOS_DISPONIBLES)
    Public Overridable Property CAT_MONTOS_DISPONIBLES1 As ICollection(Of CAT_MONTOS_DISPONIBLES) = New HashSet(Of CAT_MONTOS_DISPONIBLES)
    Public Overridable Property TELEFONIAS_PAISES As ICollection(Of TELEFONIAS_PAISES) = New HashSet(Of TELEFONIAS_PAISES)
    Public Overridable Property TELEFONIAS_CLIENTES As ICollection(Of TELEFONIAS_CLIENTES) = New HashSet(Of TELEFONIAS_CLIENTES)
    Public Overridable Property TELEFONIAS_PAISES1 As ICollection(Of TELEFONIAS_PAISES) = New HashSet(Of TELEFONIAS_PAISES)
    Public Overridable Property TELEFONIAS_CLIENTES1 As ICollection(Of TELEFONIAS_CLIENTES) = New HashSet(Of TELEFONIAS_CLIENTES)
    Public Overridable Property TRANSACCIONES As ICollection(Of TRANSACCIONES) = New HashSet(Of TRANSACCIONES)

End Class
