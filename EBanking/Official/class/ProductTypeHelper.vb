Imports System.Data.SqlClient

Module ProductTypeHelper
    Sub ProductType(ByVal AccountId As String)
        Try
            datasetcifdb.Tables(productTypeTable).Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM " & productTypeTable & " where accountnumber='" & AccountId & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, productTypeTable)
        'ShowData(currentrow)

        databaseconnection.Close()

    End Sub
    Function getProductTypeNumber(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(productTypeTable).Rows(currentrow)("accountnumber"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getProductTypeType(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(productTypeTable).Rows(currentrow)("type"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getProductTypeTerm(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(productTypeTable).Rows(currentrow)("term"), String)
        Catch
            Return Nothing
        End Try
    End Function
    Function getProductTypeValue(ByVal currentrow) As String
        Try
            Return CType(datasetcifdb.Tables(productTypeTable).Rows(currentrow)("v_alue"), String)
        Catch
            Return Nothing
        End Try
    End Function
End Module
