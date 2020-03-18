Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class PersonController
        Inherits ApiController

        Private values As New Dictionary(Of Integer, String) From {
            {1, "Mickaël Wolff"},
            {2, "Linus Torvalds"}
            }

        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"Mickaël Wolff", "Linus Torvalds"}
        End Function

        Public Function GetValue(ByVal id As Integer) As String
            If values.ContainsKey(id) Then
                GetValue = values(id)
            Else
                GetValue = Nothing
            End If
        End Function

        ' POST: api/Person
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Person/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Person/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace