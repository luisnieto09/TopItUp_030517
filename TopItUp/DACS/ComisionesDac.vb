Imports System.Data.SqlClient

Public Class ComisionesDac


    Public Function GetComisiones(ByVal user As Integer, _
                                  ByVal fechain As Date, _
                                  ByVal fechafin As Date) As List(Of ComisionesGrid)
        Try
            Dim parametros As New List(Of SqlParameter)

            Dim p As New SqlParameter()
            p.SqlDbType = SqlDbType.Int
            p.Value = user
            p.ParameterName = "@VUSER"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechain
            p.ParameterName = "@VFECHAINICIO"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechafin
            p.ParameterName = "@VFECHAFIN"
            parametros.Add(p)

            Dim dt As New DataTable()
            dt = New BDAccess().Selecciona(parametros, "COMISIONES_SP")

            Dim resultado As New List(Of ComisionesGrid)

            For Each r As DataRow In dt.Rows

                Dim item As New ComisionesGrid()
                item.Cliente = r("Cliente").ToString()
                item.Comision = Convert.ToDecimal(r("Comision"))
                item.Compania = r("Compania").ToString()
                item.fecha = Convert.ToDateTime(r("fecha"))
                item.NumTelefonico = r("NumTelefonico").ToString()
                resultado.Add(item)

            Next

            Return resultado

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
