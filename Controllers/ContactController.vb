Imports System.Net
Imports System.Net.Http
Imports System.Net.HttpStatusCode
Imports System.Web
Imports System.Web.Http
Imports RestApiApp.Models

Namespace Controllers
    Public Class ContactController
        Inherits ApiController

        Public ReadOnly ContactList As Dictionary(Of Integer, Person)

        Public Sub New()
            ContactList = New Dictionary(Of Integer, Person) From
            {{1, New Contact With {.Name = "Mickaël Wolff"}}, {2, New Contact With {.Name = "Linus Torvalds"}}}
        End Sub

        Public Function GetValues() As IEnumerable(Of String)
            GetValues = System.Linq.Enumerable.Select(ContactList, Function(c) c.Value().Name)
        End Function

        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Dim response As HttpResponseMessage
            Dim payload As String

            If ContactList.ContainsKey(id) Then
                payload = ContactList(key:=id).Name
                response = Request.CreateResponse(
                    statusCode:=HttpStatusCode.OK,
                    value:=payload)
            Else
                response = Request.CreateResponse(statusCode:=HttpStatusCode.NotFound)
            End If

            Return response
        End Function

        ' POST: /Contact
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: /Contact/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: /Contact/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace