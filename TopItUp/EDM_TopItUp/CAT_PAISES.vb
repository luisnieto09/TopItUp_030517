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

Partial Public Class CAT_PAISES
    Public Property PK_CAT_PAIS As Integer
    Public Property NOMBRE_CORTO As String
    Public Property DESCRIPCION As String
    Public Property STATUS As String

    Public Overridable Property TELEFONIAS_PAISES As ICollection(Of TELEFONIAS_PAISES) = New HashSet(Of TELEFONIAS_PAISES)
    Public Overridable Property TELEFONIAS_PAISES1 As ICollection(Of TELEFONIAS_PAISES) = New HashSet(Of TELEFONIAS_PAISES)

End Class
