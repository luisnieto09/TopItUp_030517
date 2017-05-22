Imports System.Data.SqlClient
Public Class EdoCuentaResult

    Public Function getEdoCuenta(ByVal userid As Integer, ByVal fechaini As Date, ByVal fechafin As Date, rowini As Integer, rowfin As Integer) As List(Of sp_GetEdoCtaByPkUser_Result)
        Try
            Dim parametros As New List(Of SqlParameter)

            Dim p As New SqlParameter()
            p.SqlDbType = SqlDbType.Int
            p.Value = userid
            p.ParameterName = "@PK_USER"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechaini
            p.ParameterName = "@FECHA_INI"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Date
            p.Value = fechafin
            p.ParameterName = "@FECHA_FIN"
            parametros.Add(p)

            'p = New SqlParameter()
            'p.SqlDbType = SqlDbType.Int
            'p.Value = rowini
            'p.ParameterName = "@ROW_INI"
            'parametros.Add(p)


            'p = New SqlParameter()
            'p.SqlDbType = SqlDbType.Int
            'p.Value = rowfin
            'p.ParameterName = "@ROW_FIN"
            'parametros.Add(p)


            Dim dt As New DataTable()
            dt = New BDAccess().Selecciona(parametros, "sp_GetEdoCtaByPkUser")

            Dim lista = New List(Of sp_GetEdoCtaByPkUser_Result)
            For Each r As DataRow In dt.Rows
                Dim res As New sp_GetEdoCtaByPkUser_Result
                res.abono = r("abono")
                res.saldo = r("SALDO")
                res.cargo = r("cargo")
                res.motivo = r("motivo")
                res.MEDIO_DE_PAGO = r("MEDIO_DE_PAGO")
                res.MOVIMIENTO = r("MOVIMIENTO")
                res.HORA = r("HORA")
                res.FECHA = r("FECHA")
                res.pk_transaccion = r("PK_TRANSACCION")
                'res.pksaldo = r("PK_SALDO")
                res.ID = r("id")
                lista.Add(res)
            Next

            Return lista

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
