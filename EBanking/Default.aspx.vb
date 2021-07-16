Imports Microsoft.VisualBasic
Imports System
Imports System.IO

Partial Public Class [Default]
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        TextContent.InnerHtml = File.ReadAllText(Server.MapPath("~/App_Data/Overview.html"))

        TableOfContentsTreeView.DataBind()
        TableOfContentsTreeView.ExpandAll()
    End Sub
End Class