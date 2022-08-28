Imports System.Data.SqlClient

Module connectionhelper
    Public databaseconnection As SqlConnection = Nothing
    Public datasetcifdb As New DataSet
    Public currentrow As Object
    Public dataadapter As SqlDataAdapter
    Public databasesource As String = ConfigurationSettings.AppSettings("dbsource").ToString()
    Public datacommand As SqlCommand = Nothing

    Function connectionString(ByVal databasename As String, ByVal databasepassword As String) As String
        databaseconnectionstring = "server=tmedia ; database=" & databasename & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function

    Function connectionString(ByVal databasename As String) As String
        databaseconnectionstring = "server=tmedia ; database=" & databasename & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function


    Dim databasesourceaccount As String = ConfigurationSettings.AppSettings("dbsource").ToString()
    Dim databasesourceoperate As String = ConfigurationSettings.AppSettings("dboperate").ToString()
    Dim databasesourcerpli As String = ConfigurationSettings.AppSettings("plidbsrc").ToString()
    Dim databasesourceAdmin As String = ConfigurationSettings.AppSettings("admindbsrc").ToString()

    Function connectionstringaccount() As String
        databaseconnectionstring = "server=TMEDIA ; database=" & databasesourceaccount.ToString & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function
    Function connectionstringoperate() As String
        databaseconnectionstring = "server=TMEDIA ; database=" & databasesourceoperate.ToString & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function
    Function connectionstringRpli() As String
        databaseconnectionstring = "server=TMEDIA ; database=" & databasesourcerpli.ToString & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function
    Function connectionstringAdmin() As String
        databaseconnectionstring = "server=TMEDIA ; database=" & databasesourceAdmin.ToString & ";user=tusar;password=prahallad89"
        Return databaseconnectionstring
    End Function
End Module