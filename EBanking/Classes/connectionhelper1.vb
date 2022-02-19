Module connectionhelper1
    Public databaseconnectionstring As String = ""

    'Public bdatareader As SqlDataReader = Nothing

    'Public datatable As DataTable

    'Public databaseconnection As SqlConnection = Nothing

    'Public dataadapter As SqlDataAdapter

    'Public datasetcifdb As New DataSet 'for cifdb
    'Public datasetliveaccount As New DataSet ' for live account

    'Public datacommand As SqlCommand = Nothing

    'Public currentrow As Object

    Public databasesource As String = ConfigurationSettings.AppSettings("dbsource").ToString()

    Public logindatasource As String = ConfigurationSettings.AppSettings("loginsource").ToString

    Public logindatastring As String = "server=tmedia ; database=" & logindatasource & ";user=tusar;password=prahallad89"

End Module