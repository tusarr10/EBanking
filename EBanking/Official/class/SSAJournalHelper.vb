Imports System.Data.SqlClient

Module SSAJournalHelper

    Sub AllTeansctionFromSSAJournal(datee As String)
        Try
            datasetcifdb.Tables(ssajournaltbl).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & ssajournaltbl & " where da_te like '%" & datee & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, ssajournaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub

    Function getSSAJournalDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(ssajournaltbl)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module