Imports System.Data.SqlClient
Public Class DetalleClientesDac

    Public Function getEdoCuenta(ByVal pkuser As Integer, ByVal pkcliente As Integer) As List(Of DetalleClientes)
        Try
            Dim parametros As New List(Of SqlParameter)

            Dim p As New SqlParameter()
            p.SqlDbType = SqlDbType.Int
            p.Value = pkuser
            p.ParameterName = "@pk_user"
            parametros.Add(p)

            p = New SqlParameter()
            p.SqlDbType = SqlDbType.Int
            p.Value = pkcliente
            p.ParameterName = "@pk_cliente"
            parametros.Add(p)
           

            Dim dt As New DataTable()
            dt = New BDAccess().Selecciona(parametros, "sp_GetListaClientes")

            Dim lista = New List(Of DetalleClientes)
            For Each r As DataRow In dt.Rows
                Dim res As New DetalleClientes
                res.NOMBRE = If(r("NOMBRE").Equals(DBNull.Value), "", r("NOMBRE"))
                res.SALDO = If(r("SALDO").Equals(DBNull.Value), 0, r("SALDO"))
                res.DIRECCION = If(r("DIRECCION").Equals(DBNull.Value), "", r("DIRECCION"))
                res.USERNAME = If(r("USERNAME").Equals(DBNull.Value), "", r("USERNAME"))
                res.TELEFONO = If(r("TELEFONO").Equals(DBNull.Value), "", r("TELEFONO"))
                res.NIVEL_SUPERIOR = If(r("NIVEL_SUPERIOR").Equals(DBNull.Value), "", r("NIVEL_SUPERIOR"))
                res.RFC = If(r("RFC").Equals(DBNull.Value), "", r("RFC"))
                res.RAZON_SOCIAL = If(r("RAZON_SOCIAL").Equals(DBNull.Value), "", r("RAZON_SOCIAL"))
                res.ACTIVO = If(r("status").Equals(DBNull.Value), "", r("status"))
                res.pk_cliente = If(r("pk_cliente").Equals(DBNull.Value), 0, Convert.ToInt32(r("pk_cliente")))
                res.fkCtePadre = If(r("FK_CLIENTE_PADRE").Equals(DBNull.Value), 0, Convert.ToInt32(r("FK_CLIENTE_PADRE")))
                res.status = If(r("status").Equals(DBNull.Value), 0, Convert.ToInt32(r("status")))
                lista.Add(res)
            Next

            Return lista

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
