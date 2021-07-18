Imports DevExpress.Web

Public Class Operation
    Inherits System.Web.UI.Page


    Private Sub loadDataFromServer()
        Try
            LoadAllDataFromServer()
            Dim tables As DataTable
            tables = getLiveaccountDataTable()
            ASPxGridView1.DataSource = tables
            ASPxGridView1.DataBind()
        Catch

        End Try
    End Sub
    Function data(sender As Object, tablename As String)
        Dim btn = sender
        Dim container As Object = btn.NamingContainer

        Return container.Grid.GetRowValues(container.VisibleIndex, tablename).ToString

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadDataFromServer()
    End Sub

    Protected Sub lblexamIsPaid_Click(sender As Object, e As EventArgs)
        Dim btn = sender
        Dim container As Object = btn.NamingContainer
        Try

            MyMessageBox.Show(Me, data(sender, "accountnumber"))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub link1_Click(sender As Object, e As EventArgs)

        Try

            MyMessageBox.Show(Me, data(sender, "balance"))
        Catch ex As Exception

        End Try

    End Sub
    Sub redirect(url As String, accountnumber As String)
        Dim TARGET_URL As String = url
        If Page.IsCallback Then
            DevExpress.Web.ASPxWebControl.RedirectOnCallback(TARGET_URL + "?value=" + accountnumber)
        Else
            Response.Redirect(TARGET_URL + "?value=" + accountnumber)
        End If
    End Sub

    Dim acno As String
    Dim actype As String
    Dim producttype As String
    Private Sub GoToDeposit(sender As Object)

        If producttype = "Saving" Then
            redirect("sbDeposit.aspx", acno)
        ElseIf producttype = "RD" Then
            redirect("rdDeposit.aspx", acno)
        ElseIf producttype = "SSA" Then
            redirect("ssaDeposit.aspx", acno)
        Else
            MyMessageBox.Show(Me, "Do Manually")

        End If
    End Sub
    Private Sub GoToWithdraw(sender As Object)
        If producttype = "Saving" Then
            redirect("sbWithdraw.aspx", acno)
        ElseIf producttype = "RD" Then
            MyMessageBox.Show(Me, "Do Manually")
        ElseIf producttype = "SSA" Then
            MyMessageBox.Show(Me, "Do Manually")
        Else
            MyMessageBox.Show(Me, "Do Manually")

        End If
    End Sub
    Protected Sub GridView_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs)
        Try
            '  acno = data(sender, "accountnumber")
            acno = ASPxGridView1.GetSelectedFieldValues("accountnumber")(0).ToString

            actype = ASPxGridView1.GetSelectedFieldValues("acctype")(0).ToString
            producttype = ASPxGridView1.GetSelectedFieldValues("producttype")(0).ToString

        Catch ex As Exception
            Exit Sub
        End Try
        If e.Parameters = "view" Then

            GoToView(acno)
        End If
        If e.Parameters = "deposit" Then

            GoToDeposit(acno)
        End If
        If e.Parameters = "withdraw" Then

            GoToWithdraw(acno)
        End If

    End Sub

    Private Sub GoToView(sender As Object)

    End Sub
End Class