Imports System.Data.SqlClient
Imports DevExpress.Web

Public Class AllRpliIndex
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getdata()
        filldata()

    End Sub
    Sub getdata()
        Try
            datasetcifdb.Tables("rpliallindex").Clear()
        Catch ex As Exception

        End Try
        Try
            Dim cs As String = connectionhelper.connectionstringRpli()
            databaseconnection = New SqlConnection(cs)
            databaseconnection.Open()
            currentrow = 0
            dataadapter = New SqlDataAdapter("SELECT * FROM Pli_Indexing", databaseconnection)

            dataadapter.Fill(datasetcifdb, "rpliallindex")
            'ShowData(currentrow)

            databaseconnection.Close()
        Catch ex As Exception

        Finally

        End Try
    End Sub
    Sub filldata()
        ASPxGridView1.DataSource = datasetcifdb.Tables("rpliallindex")
        ASPxGridView1.DataBind()
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