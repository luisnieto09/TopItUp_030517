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

Partial Public Class CAT_MONTOS_DISPONIBLES
    Public Property PK_CAT_MONTO_DISPONIBLE As Integer
    Public Property FK_CAT_TELEFONIA As Integer
    Public Property MONTO As Decimal
    Public Property FK_CAT_MONEDA As Integer
    Public Property STATUS As String

    Public Overridable Property CAT_MONEDAS As CAT_MONEDAS
    Public Overridable Property CAT_MONEDAS1 As CAT_MONEDAS
    Public Overridable Property CAT_TELEFONIAS As CAT_TELEFONIAS
    Public Overridable Property CAT_TELEFONIAS1 As CAT_TELEFONIAS

End Class
