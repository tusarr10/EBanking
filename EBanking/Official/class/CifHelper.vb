Imports System.Data.SqlClient

Module CifHelper
    Friend cifupdate As Boolean = False
    Friend photoPath As String
    Friend signPath As String
    Sub cifsearch(ByVal cif As String)
        Try
            datasetcifdb.Tables("cifdb").Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM cifdb where cif='" & cif & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, "cifdb")
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Function IsIdExist(ByVal matchingcif As String) As Boolean

        Dim Str, Str1 As String
        Dim i As Integer

        Str = matchingcif ' searchciftb.Text
        i = 0
        While i <> datasetcifdb.Tables("cifdb").Rows.Count
            Str1 = CType(datasetcifdb.Tables("cifdb").Rows(i)("cif"), String)

            If Str = Str1 Then
                Return True

            End If
            i += 1

        End While
        Return False
    End Function
    Function getcif(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("cif"), String)


        Catch
            Return Nothing


        End Try
    End Function
    Function getcifname(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("n_ame"), String)

        Catch
            Return Nothing


        End Try

    End Function
    Function getcifmobile(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("mobile"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifemail(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("email"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifpan(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("pan"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifadhar(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("adhar"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifphoto(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("photo"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getcifsign(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("sign"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifaddress(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("address"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifdob(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("dob"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifgender(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("gender"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getcifStatus(ByVal currentrow) As String
        Try : Return CType(datasetcifdb.Tables("cifdb").Rows(currentrow)("status"), String)
        Catch
            Return Nothing
        End Try
    End Function

End Module
