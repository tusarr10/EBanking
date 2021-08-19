Imports Dapper
Imports System.Data.SqlClient
Imports System.Configuration

Module connectionhelper
    Public databaseconnection As SqlConnection = Nothing
    Public datasetcifdb As New DataSet
    Public currentrow As Object
    Public dataadapter As SqlDataAdapter
    Public databasesource As String = ConfigurationSettings.AppSettings("dbsource").ToString()
    Public datacommand As SqlCommand = Nothing
    Function connectionString(ByVal databasename As String, ByVal databasepassword As String) As String
        databaseconnectionstring = "server=tmedia ; database=" & databasename & ";user=tusar;password=tusarranjan"
        Return databaseconnectionstring
    End Function
    Function connectionString(ByVal databasename As String) As String
        databaseconnectionstring = "server=tmedia ; database=" & databasename & ";user=tusar;password=tusarranjan"
        Return databaseconnectionstring
    End Function

    Dim databasesourceaccount As String = ConfigurationSettings.AppSettings("dbsource").ToString()
    Dim databasesourcerpli As String = ConfigurationSettings.AppSettings("plidbsrc").ToString()
    Function connectionstringaccount() As String
        databaseconnectionstring = "server=tmedia ; database=" & databasesourceaccount.ToString & ";user=tusar;password=tusarranjan"
        Return databaseconnectionstring
    End Function
    Function connectionstringRpli() As String
        databaseconnectionstring = "server=tmedia ; database=" & databasesourcerpli.ToString & ";user=tusar;password=tusarranjan"
        Return databaseconnectionstring
    End Function
End Module
