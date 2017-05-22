Imports System.Data.SqlClient

Public Class ReporteHorasDac


    Public Function GetReporteHoras(ByVal fechaini As DateTime,
                                    ByVal fechafin As DateTime,
                                    ByVal usr As Integer) As List(Of ReporteHorasDetail)
        Try
            Dim lista As New List(Of ReporteHorasDetail)
            Dim parametros As New List(Of SqlParameter)

            Dim p As New SqlParameter()
            p.SqlDbType = SqlDbType.Int
            p.Value = usr
            p.ParameterName = "@PK_USER"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechaini
            p.ParameterName = "@FechaInicio"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechafin
            p.ParameterName = "@FechaFin"
            parametros.Add(p)

            Dim dt As New DataTable()
            dt = New BDAccess().Selecciona(parametros, "sp_get_Ventas_Hora")

            Dim rh As ReporteHorasDetail
            For Each r As DataRow In dt.Rows
                rh = New ReporteHorasDetail()
                rh.fecha = r("fecha")
                rh.C00_00_a_7_59 = r("7")
                rh.C8_00 = r("8")
                rh.C9_00 = r("9")
                rh.C10_00 = r("10")
                rh.C11_00 = r("11")
                rh.C12_00 = r("12")
                rh.C13_00 = r("13")
                rh.C14_00 = r("14")
                rh.C15_00 = r("15")
                rh.C16_00 = r("16")
                rh.C17_00 = r("17")
                rh.C18_00 = r("18")
                rh.C19_00 = r("19")
                rh.C20_00 = r("20")
                rh.C21_00 = r("21")
                rh.C22_00 = r("22")
                rh.C23_00 = r("23")
                lista.Add(rh)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
