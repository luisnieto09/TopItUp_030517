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

Partial Public Class CAT_SERVICIOS
    Public Property PK_CAT_SERVICIO As Integer
    Public Property NOMBRE_CORTO As String
    Public Property DESCRIPCION As String
    Public Property STATUS As String
    Public Property COBRAR_COMISION As Nullable(Of Integer)

    Public Overridable Property TRANSACCIONES As ICollection(Of TRANSACCIONES) = New HashSet(Of TRANSACCIONES)

End Class
