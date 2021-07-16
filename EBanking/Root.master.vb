Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.HtmlControls

Imports DevExpress.Web
Imports TWEB.Model

Partial Public Class Root
    Inherits MasterPage
    Private privateEnableBackButton As Boolean
    Public Property EnableBackButton() As Boolean
        Get
            Return privateEnableBackButton
        End Get
        Set(ByVal value As Boolean)
            privateEnableBackButton = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If (Not String.IsNullOrEmpty(Page.Header.Title)) Then
            Page.Header.Title &= " - "
        End If
        Page.Header.Title = Page.Header.Title & "ASP.NET WebForms/MVC Responsive Web Application Template | DevExpress"

        Page.Header.DataBind()

        UpdateUserMenuItemsVisible()
        HideUnusedContent()
        UpdateUserInfo()
    End Sub

    Protected Sub HideUnusedContent()
        LeftAreaMenu.Items(1).Visible = EnableBackButton

        Dim hasLeftPanelContent As Boolean = HasContent(LeftPanelContent)
        LeftAreaMenu.Items.FindByName("ToggleLeftPanel").Visible = hasLeftPanelContent
        LeftPanel.Visible = hasLeftPanelContent

        Dim hasRightPanelContent As Boolean = HasContent(RightPanelContent)
        RightAreaMenu.Items.FindByName("ToggleRightPanel").Visible = hasRightPanelContent
        RightPanel.Visible = hasRightPanelContent

        Dim hasPageToolbar As Boolean = HasContent(PageToolbar)
        PageToolbarPanel.Visible = hasPageToolbar
    End Sub

    Protected Function HasContent(ByVal ContentPlaceHolder As Control) As Boolean
        If ContentPlaceHolder Is Nothing Then
            Return False
        End If

        Dim childControls As ControlCollection = ContentPlaceHolder.Controls
        If childControls.Count = 0 Then
            Return False
        End If

        Return True
    End Function

    ' SignIn/Register

    Protected Sub UpdateUserMenuItemsVisible()
        Dim isAuthenticated = AuthHelper.IsAuthenticated()
        RightAreaMenu.Items.FindByName("SignInItem").Visible = Not isAuthenticated
        RightAreaMenu.Items.FindByName("RegisterItem").Visible = Not isAuthenticated
        RightAreaMenu.Items.FindByName("MyAccountItem").Visible = isAuthenticated
        RightAreaMenu.Items.FindByName("SignOutItem").Visible = isAuthenticated
    End Sub

    Protected Sub UpdateUserInfo()
        If AuthHelper.IsAuthenticated() Then
            Dim user = AuthHelper.GetLoggedInUserInfo()
            Dim myAccountItem = RightAreaMenu.Items.FindByName("MyAccountItem")
            Dim userName = CType(myAccountItem.FindControl("UserNameLabel"), ASPxLabel)
            Dim email = CType(myAccountItem.FindControl("EmailLabel"), ASPxLabel)
            Dim accountImage = CType(RightAreaMenu.Items(0).FindControl("AccountImage"), HtmlGenericControl)
            userName.Text = String.Format("{0} ({1} {2})", user.UserName, user.FirstName, user.LastName)
            email.Text = user.Email
            accountImage.Attributes("class") = "account-image"

            If String.IsNullOrEmpty(user.AvatarUrl) Then
                accountImage.InnerHtml = String.Format("{0}{1}", user.FirstName(0), user.LastName(0)).ToUpper()
            Else
                Dim avatarUrl = CType(myAccountItem.FindControl("AvatarUrl"), HtmlImage)
                avatarUrl.Attributes("src") = ResolveUrl(user.AvatarUrl)
                accountImage.Style("background-image") = ResolveUrl(user.AvatarUrl)
            End If
        End If
    End Sub

    Protected Sub RightAreaMenu_ItemClick(ByVal source As Object, ByVal e As DevExpress.Web.MenuItemEventArgs)
        If e.Item.Name = "SignOutItem" Then
            AuthHelper.SignOut() ' DXCOMMENT: Your Signing out logic
            Response.Redirect("~/")
        End If
    End Sub

    Protected Sub ApplicationMenu_ItemDataBound(ByVal source As Object, ByVal e As MenuItemEventArgs)
        e.Item.Image.Url = String.Format("Content/Images/{0}.svg", e.Item.Text)
        e.Item.Image.UrlSelected = String.Format("Content/Images/{0}-white.svg", e.Item.Text)
    End Sub
End Class