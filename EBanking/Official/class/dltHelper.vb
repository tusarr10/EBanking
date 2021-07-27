Imports System.Data.SqlClient

Module dltHelper
    Sub dltInformation(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(dlttable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & dlttable & " where accountnumber='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, dlttable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub
    Function getDltAccountId(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(dlttable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getDltAccountBalance(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(dlttable).Rows(currentrow)("accountbalance"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getDltdlt(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(dlttable).Rows(currentrow)("dlt"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getDltdlt2(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(dlttable).Rows(currentrow)("dlt2"), String)
        Catch
            Return Nothing
        End Try
    End Function
End Module
