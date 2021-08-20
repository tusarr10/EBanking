Imports System.Data.SqlClient

''' <summary>
''' This Is for Live Account DB
''' </summary>
Module AddAccountHelper

    Sub AccountSearch(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(liveAccountTable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & liveAccountTable & " where accountnumber='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, liveAccountTable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Function IsAccountIdExist(ByVal AccountId As String) As Boolean

        Dim Str, Str1 As String
        Dim i As Integer

        Str = AccountId
        i = 0
        While i <> datasetcifdb.Tables(liveAccountTable).Rows.Count
            Str1 = CType(datasetcifdb.Tables(liveAccountTable).Rows(i)("accountnumber"), String)

            If Str = Str1 Then
                Return True

            End If
            i += 1

        End While
        Return False
    End Function

    Function getAccountId(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try

    End Function

    Function getAccountCif(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("cif"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("n_ame"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountProductType(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("producttype"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountNominiRegistor(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("nominireg"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountAccType(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("acctype"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountJointName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("jointname"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountGuardianName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("guardianname"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountBalance(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("balance"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getAccountStatus(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(liveAccountTable).Rows(currentrow)("status"), String)
        Catch
            Return Nothing
        End Try
    End Function

    ''''''For Open Account

    Sub AccountNameSearch(ByVal Nmae As String)
        Try
            datasetcifdb.Tables(liveAccountTable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & liveAccountTable & " where n_ame like '%" & Nmae & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, liveAccountTable)

        dataadapter = New SqlDataAdapter("SELECT * FROM " & newaccounttable & " where n_ame like '%" & Nmae & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, liveAccountTable)

        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Function getAccountOpenDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(liveAccountTable)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module