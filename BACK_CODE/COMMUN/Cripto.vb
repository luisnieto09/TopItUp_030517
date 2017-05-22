Imports System.Security.Cryptography
Imports System.Text

Public Class Cripto


    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As New StringBuilder()
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function


    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

    Shared Function regresaHash(ByVal input As String) As String
        Try
            Dim resultado As String = ""
            Using md5hash As MD5 = MD5.Create
                resultado = GetMd5Hash(md5hash, input)
            End Using
            Return resultado
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Shared Function ComparaCadenas(ByVal hash As String,
                                   ByVal cadenaNormal As String) As Boolean

        Try
            Dim _resultado As Boolean = False
            Using md5hash As MD5 = MD5.Create()
                _resultado = VerifyMd5Hash(md5hash, cadenaNormal, hash)
            End Using
            Return _resultado
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
