Imports System.Data.SqlClient

Module RdJournalHelper

    Sub AllTeansctionFromRDJournal(datee As String)
        Try
            datasetcifdb.Tables(rdjournaltbl).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & rdjournaltbl & " where da_te like '%" & datee & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, rdjournaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub

    Function getRDJournalDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(rdjournaltbl)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module