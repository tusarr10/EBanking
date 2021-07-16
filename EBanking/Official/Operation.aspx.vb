Public Class Operation
    Inherits System.Web.UI.Page

    Private Sub loadDataFromServer()
        Try
            LoadAllDataFromServer()
            Dim tables As DataTable
            tables = getLiveaccountDataTable()
            BGridView1.DataSource = tables
            BGridView1.DataBind()
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

End Class