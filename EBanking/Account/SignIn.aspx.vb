Imports DevExpress.Web
Imports TWEB.Model

Partial Public Class SignInModule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub SignInButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        FormLayout.FindItemOrGroupByName("GeneralError").Visible = False
        If ASPxEdit.ValidateEditorsInContainer(Me) Then
            ' DXCOMMENT: You Authentication logic
            If (Not AuthHelper.SignIn(UserNameTextBox.Text, PasswordButtonEdit.Text)) Then
                GeneralErrorDiv.InnerText = "Invalid login attempt."
                FormLayout.FindItemOrGroupByName("GeneralError").Visible = True
            Else
                Response.Redirect("~/Official/Default.aspx") ' to main page
            End If
        End If
    End Sub

End Class