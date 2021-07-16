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
    Dim databasesource1 As String = ConfigurationSettings.AppSettings("dbsource").ToString()
    Function connectionstring() As String
        databaseconnectionstring = "server=tmedia ; database=" & databasesource1.ToString & ";user=tusar;password=tusarranjan"
        Return databaseconnectionstring
    End Function
End Module
