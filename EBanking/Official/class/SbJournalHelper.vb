Imports System.Data.SqlClient

Module SbJournalHelper

    Sub AllTeansctionFromSBJournal(datee As String)
        Try
            datasetcifdb.Tables(sbjournaltbl).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & sbjournaltbl & " where da_te like '%" & datee & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, sbjournaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub

    Function getSbJournalDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(sbjournaltbl)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module