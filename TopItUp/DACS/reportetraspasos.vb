Imports System.Data.SqlClient

Public Class reportetraspasos



    Public Function GetReporteTraspasos(ByVal fechaini As DateTime,
                                    ByVal fechafin As DateTime,
                                    ByVal usr As Integer) As List(Of traspasosentities)
        Try

            Dim lista As New List(Of traspasosentities)
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
            dt = New BDAccess().Selecciona(parametros, "sp_get_Traspasos_Otros_Cargos")

            If dt.Rows.Count > 0 Then

                For Each r As DataRow In dt.Rows
                    Dim x As New traspasosentities()
                    x.Cliente = r("Cliente").ToString()
                    x.monto = Convert.ToDecimal(r("monto"))
                    x.descripcion = r("descripcion").ToString()
                    x.fecha = Convert.ToDateTime(r("fecha"))
                    x.Afecta = r("Afecta").ToString()
                    x.TipoCargo = r("TipoCargo").ToString()
                    x.ClienteDestino = r("ClienteDestino").ToString()
                    x.Registro = Convert.ToDateTime(r("Registro"))
                    x.fec = r("fec").ToString()
                    lista.Add(x)

                Next

            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
