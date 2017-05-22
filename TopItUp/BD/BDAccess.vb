Imports System.Data.SqlClient
Imports System.Configuration

Public Class BDAccess

    Public Function Selecciona(ByVal parametros As List(Of SqlParameter), ByVal spname As String) As DataTable
        Try
            Dim conn As New SqlConnection()

            'conn.ConnectionString = "Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;Integrated Security=True;timeout=500000"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("SQLAzureConnection").ConnectionString

            conn.Open()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandTimeout = 60000
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spname
            For Each p As SqlParameter In parametros
                cmd.Parameters.Add(p)
            Next
            Dim dt As New DataTable()
            Dim theAdapter As New SqlDataAdapter(cmd)
            theAdapter.Fill(dt)
            conn.Close()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllsp(ByVal spname As String) As DataTable
        Try
            Dim conn As New SqlConnection()
            'conn.ConnectionString = "Data Source=mits.centralus.cloudapp.azure.com;Initial catalog=topitup_db;Integrated Security=True;timeout=500000"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("SQLAzureConnection").ConnectionString
            conn.Open()
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandTimeout = 60000
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spname
            Dim dt As New DataTable()
            Dim theAdapter As New SqlDataAdapter(cmd)
            theAdapter.Fill(dt)
            conn.Close()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
