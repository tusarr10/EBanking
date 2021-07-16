Imports System.Data.SqlClient

Module AccountOperateModeHelper
    Sub AccountOperateMode(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(accountOperateTable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstring()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & accountOperateTable & " where accountnumber='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, accountOperateTable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub
    Function getAccountOperateNumber(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(accountOperateTable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getAccountOperateAccOperateMode(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(accountOperateTable).Rows(currentrow)("accountoperatemode"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getAccountOperateGuardianName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(accountOperateTable).Rows(currentrow)("guardianname"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getAccountOperateRelation(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(accountOperateTable).Rows(currentrow)("relation"), String)
        Catch
            Return Nothing
        End Try
    End Function
End Module
