Imports System.Runtime.CompilerServices



Module StringExtension

    <Extension()>
    Public Function GetValueFromStringXml(ByVal origen As String, ByVal tag As String) As String
        Try
            origen = origen.Replace(vbCr, "").Replace(vbLf, "")
            Dim idxStart = origen.IndexOf(tag) + tag.Length
            Dim idxEnd = origen.IndexOf("</" + tag.Replace("<", ""))
            Return origen.Substring(idxStart, (idxEnd - idxStart))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <Extension()>
    Public Function ArrayFromStringXml(ByVal origen As String, ByVal tag As String) As String()
        Try
            origen = origen.Replace(vbCr, "").Replace(vbLf, "")
            Dim tagend = "</" + tag.Replace("<", "")
            Dim idxStart = origen.IndexOf(tag) + tag.Length
            Dim intermedios = tagend + tag
            origen = origen.Replace(intermedios, "+")
            Dim idxEnd = origen.IndexOf(tagend)
            Dim temp = origen.Substring(idxStart, (idxEnd - idxStart))
            Return temp.Split(Convert.ToChar("+"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Module
