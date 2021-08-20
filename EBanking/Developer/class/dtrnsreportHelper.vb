Imports System.Data.SqlClient

Module dtrnsreportHelper

    Sub searchDTR(ByVal trid As String, ByVal da_te As String)
        Try
            datasetcifdb.Tables(journaltbl).Clear()
        Catch
        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & journaltbl & " where trid like '%" & trid & "%' and da_te like '%" & da_te & "%'", databaseconnection)

        dataadapter.Fill(datasetcifdb, journaltbl)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Sub GetDtr()

    End Sub

    Function IsDtrExist(ByVal mating_string As String, ByVal matching_date As String) As Boolean
        Try
            Dim i As Integer
            Dim str1, str2 As String
            While i <> datasetcifdb.Tables(journaltbl).Rows.Count
                str1 = CType(datasetcifdb.Tables(journaltbl).Rows(i)("trid"), String)
                str2 = CType(datasetcifdb.Tables(journaltbl).Rows(i)("da_te"), String)
                If mating_string = str1 And matching_date = str2 Then
                    Return True
                End If
                i += 1
            End While
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function getjournalDataTable() As DataTable
        Try
            Return datasetcifdb.Tables(journaltbl)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module