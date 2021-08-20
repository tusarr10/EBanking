Imports System.Data.SqlClient

''' <summary>
''' Date : 25.06.2021
''' Name : TUSAR RANJAN PRADHAN
''' For Table nominiinfo
''' </summary>
Module NominiInfoHelper

    Sub NominiInformation(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(nominitable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & nominitable & " where accountnumber='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, nominitable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub

    Function getNominiInfoId(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getNominiInfoReg(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("nominireg"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getNominiInfoNominiName(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("nomininame"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getNominiInfoNominiAge(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("nominiage"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getNominiInfoAddress(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("noiminiaddress"), String)
        Catch
            Return Nothing
        End Try
    End Function

    Function getNominiInfoRelation(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(nominitable).Rows(currentrow)("nominirelation"), String)
        Catch
            Return Nothing
        End Try
    End Function

End Module