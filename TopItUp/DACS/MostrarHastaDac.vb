Imports System.Data.SqlClient

Public Class MostrarHastaDac

    Public Function func_GetAll() As List(Of clsMostrarHasta)
        Dim dt As New DataTable()
        Dim lista As New List(Of clsMostrarHasta)

        Try
            dt = New BDAccess().GetAllsp("sp_get_cat_mostrar_hasta")

            Dim objHastaS As New clsMostrarHasta
            objHastaS.PK_CAT_MOSTRAR_HASTA = -1
            objHastaS.ROW_NUMBER_IN_QUERY = 0
            objHastaS.NOMBRE_MOSTRAR = "Seleccione opción"
            lista.Add(objHastaS)

            For Each dr In dt.Rows
                Dim objHasta As New clsMostrarHasta

                objHasta.PK_CAT_MOSTRAR_HASTA = dr("PK_CAT_MOSTRAR_HASTA")
                objHasta.NOMBRE_MOSTRAR = dr("NOMBRE_MOSTRAR")
                objHasta.ROW_NUMBER_IN_QUERY = dr("ROW_NUMBER_IN_QUERY")

                lista.Add(objHasta)
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return lista

    End Function


End Class
