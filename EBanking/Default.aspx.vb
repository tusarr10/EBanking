Imports System.IO

Partial Public Class [Default]
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Response.Redirect("~/official/")
        Catch ex As Exception

        End Try
        TextContent.InnerHtml = File.ReadAllText(Server.MapPath("~/App_Data/Overview.html"))

        TableOfContentsTreeView.DataBind()
        TableOfContentsTreeView.ExpandAll()
    End Sub

End Class