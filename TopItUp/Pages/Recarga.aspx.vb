Imports BACK_CODE
Imports TopItUp.Helpers
Imports BACK_CODE.EnviaCorreo
Imports System.Net

Public Class Recarga
    Inherits System.Web.UI.Page

    Private Property propCantidad As Decimal
        Set(value As Decimal)
            ViewState("CANTIDAD") = value
        End Set
        Get
            Return ViewState("CANTIDAD")
        End Get
    End Property

    Private Property propCompania As Integer
        Set(value As Integer)
            ViewState("COMPANIA") = value
        End Set
        Get
            Return ViewState("COMPANIA")
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lnkBtnTiempoAire_Click(sender As Object, e As EventArgs) Handles lnkBtnTiempoAire.Click
        Response.Redirect("Recarga.aspx")
    End Sub


    Protected Sub btnAplicarRecarga_Click(sender As Object, e As EventArgs) Handles btnAplicarRecarga.Click
        Dim arResult As ArrayList
        Dim vta As New MultiWebServiceMX()

        Try
            Dim _Cantidad = Convert.ToInt32(ViewState("MontoSeleccionado").ToString().Replace(".00", ""))
            arResult = vta.Venta(Me.propCompania, Me.txtNumber.Text, Me.propCantidad) ' AQUI HAY Q PASAR LOS PARAMETROS DE SKU NUMERO Y MONTO... 
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub rb10_CheckedChanged(sender As Object, e As EventArgs) Handles rb10.CheckedChanged
        propCantidad = 10
    End Sub

    Protected Sub rb20_CheckedChanged(sender As Object, e As EventArgs) Handles rb20.CheckedChanged
        propCantidad = 20
    End Sub

    Protected Sub rb50_CheckedChanged(sender As Object, e As EventArgs) Handles rb50.CheckedChanged
        propCantidad = 50
    End Sub

    Protected Sub rb100_CheckedChanged(sender As Object, e As EventArgs) Handles rb100.CheckedChanged
        propCantidad = 100
    End Sub


    Protected Sub rb150_CheckedChanged(sender As Object, e As EventArgs) Handles rb150.CheckedChanged
        propCantidad = 150
    End Sub

    Protected Sub rb200_CheckedChanged(sender As Object, e As EventArgs) Handles rb200.CheckedChanged
        propCantidad = 200
    End Sub

    Protected Sub rb300_CheckedChanged(sender As Object, e As EventArgs) Handles rb300.CheckedChanged
        propCantidad = 300
    End Sub

    Protected Sub rb500_CheckedChanged(sender As Object, e As EventArgs) Handles rb500.CheckedChanged
        propCantidad = 500
    End Sub

    Protected Sub rb750_CheckedChanged(sender As Object, e As EventArgs) Handles rb750.CheckedChanged
        propCantidad = 750
    End Sub

    Protected Sub rb1000_CheckedChanged(sender As Object, e As EventArgs) Handles rb1000.CheckedChanged
        propCantidad = 1000
    End Sub

    Protected Sub rbTelcel_CheckedChanged(sender As Object, e As EventArgs) Handles rbTelcel.CheckedChanged
        Me.propCompania = Me.rbTelcel.ID
    End Sub

    Protected Sub rbMovi_CheckedChanged(sender As Object, e As EventArgs) Handles rbMovi.CheckedChanged
        Me.propCompania = Me.rbMovi.ID
    End Sub

    Protected Sub rbIusa_CheckedChanged(sender As Object, e As EventArgs) Handles rbIusa.CheckedChanged
        Me.propCompania = Me.rbIusa.ID
    End Sub

    Protected Sub rbNextel_CheckedChanged(sender As Object, e As EventArgs) Handles rbNextel.CheckedChanged
        Me.propCompania = Me.rbNextel.ID
    End Sub

End Class