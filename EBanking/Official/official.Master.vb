Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Imports DevExpress.Web
Imports TWEB.Model

Public Class official
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdateUserMenuItemsVisible()
    End Sub
    Protected Sub UpdateUserMenuItemsVisible()
        Dim isAuthenticated = AuthHelper.IsAuthenticated()
        RightAreaMenu.Items.FindByName("SignInItem").Visible = Not isAuthenticated
        RightAreaMenu.Items.FindByName("RegisterItem").Visible = Not isAuthenticated
        RightAreaMenu.Items.FindByName("MyAccountItem").Visible = isAuthenticated
        RightAreaMenu.Items.FindByName("SignOutItem").Visible = isAuthenticated
    End Sub

    Protected Sub RightAreaMenu_ItemClick(ByVal source As Object, ByVal e As DevExpress.Web.MenuItemEventArgs)
        If e.Item.Name = "SignOutItem" Then
            AuthHelper.SignOut() ' DXCOMMENT: Your Signing out logic
            Response.Redirect("~/")
        End If
    End Sub
    Protected Sub ApplicationMenu_ItemDataBound(ByVal source As Object, ByVal e As MenuItemEventArgs)
        e.Item.Image.Url = String.Format("../Content/Images/{0}.svg", e.Item.Text)
        e.Item.Image.UrlSelected = String.Format("../Content/Images/{0}-white.svg", e.Item.Text)
    End Sub
End Class