Imports DevExpress.Web
Imports DataBaseHelper

Public Class AllrpliTranstion
    Inherits System.Web.UI.Page

    Dim dataclass As List(Of classPliTransction)
    Dim dataserver As New PliTransctionService(connectionstringRpli)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddataFromServer()
    End Sub

    Private Sub loaddataFromServer()
        Try
            ASPxGridView1.DataSource = dataserver.getAll()
            ASPxGridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridView_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs)

        Dim i As Integer
        Try
            i = ASPxGridView1.Selection.Count
        Catch ex As Exception
            Exit Sub
        End Try
        If e.Parameters = "view" Then

        End If
        If e.Parameters = "Send" Then

        End If
        If e.Parameters = "SendAll" Then

        End If
    End Sub



End Class