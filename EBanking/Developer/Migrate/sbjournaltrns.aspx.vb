Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class sbjournaltrns
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GridView_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)

    End Sub
    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("Accesssbtr").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "Savingac" & "", databaseconnection1))
            dataadapter1.Fill(datasetcifdb, "Accesssbtr")
            'ShowData(currentrow)
            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try
    End Sub
    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("Accesssbtr")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Const UploadDirectory As String = "~/Developer/Data/"
    Dim resultFileUrl As String
    Dim resultFilePath As String
    Sub loaddatafromserver()
        Try
            resultFileUrl = UploadDirectory & "Database1.accdb"
            resultFilePath = MapPath(resultFileUrl)
            LoadCiffromdb()
            Dim table As DataTable
            table = getCifAccessDataTable()
            ASPxGridView1.DataSource = table
            ASPxGridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class