Imports System.Data.SqlClient

Module JournalHelper
    Sub JournalSearchByTRID(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(journaltbl).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstring()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & journaltbl & " where trid='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, journaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Sub AllTeansctionFromJournal(datee As String)
        Try
            datasetcifdb.Tables(journaltbl).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstring()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & journaltbl & " where da_te like'%" & datee & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, journaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub
    Function getjournalDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(journaltbl)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function getJournalDate(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("da_te"), String)
        Catch
            Return Nothing
        End Try

    End Function
    Function getJournalAccountType(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("accounttype"), String)
        Catch
            Return Nothing
        End Try

    End Function
    Function getJournalNumber(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("na_me"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalDeposit(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("deposit"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalWithdraw(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("withdraw"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournaldlt(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("dlt"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalTransctionID(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("trid"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalBalance(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("balance"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalStatus(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("status"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalOffice(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("office"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getJournalUser(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(journaltbl).Rows(currentrow)("u_ser"), String)
        Catch
            Return Nothing
        End Try
    End Function

End Module
