Imports System.Data.SqlClient

Module allaccountgrid

    Sub LoadAllDataFromServer()
        Try
            datasetcifdb.Tables(liveAccountTable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        dataadapter = New SqlDataAdapter("SELECT * FROM " & liveAccountTable & "", databaseconnection)

        dataadapter.Fill(datasetcifdb, liveAccountTable)
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub
    Function getLiveaccountDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(liveAccountTable)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
