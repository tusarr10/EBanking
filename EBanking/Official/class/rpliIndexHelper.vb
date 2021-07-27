Imports System.Data.SqlClient

Module rpliIndexHelper



    Public Property idrp As String
    Public Property agentidrp As String
    Public Property boidrp As String
    Public Property recdaterp As String
    Public Property agentsarp As String
    Public Property agentpremrp As String
    Public Property agentmobilerp As String '7

    Public Property custanamerp As String
    Public Property custdobrp As String
    Public Property custmobilerp As String
    Public Property custnotesrp As String
    Public Property custaddressrp As String '12

    Public Property proposaldaterp As String
    Public Property proposaltyperp As String
    Public Property productcatrp As String
    Public Property prefqrp As String
    Public Property matagerp As String '17

    Public Property proposalnorp As String
    Public Property recnorp As String
    Public Property sarp As String
    Public Property premrp As String
    Public Property indexborp As String
    Public Property usidrp As String '23

    Sub clearall() 'clear all variable
        idrp = Nothing
        agentidrp = Nothing
        boidrp = Nothing
        recdaterp = Nothing
        agentsarp = Nothing
        agentpremrp = Nothing
        agentmobilerp = Nothing

        custanamerp = Nothing
        custdobrp = Nothing
        custmobilerp = Nothing
        custnotesrp = Nothing
        custaddressrp = Nothing

        proposaldaterp = Nothing
        proposaltyperp = Nothing
        productcatrp = Nothing
        prefqrp = Nothing
        matagerp = Nothing

        proposalnorp = Nothing
        recnorp = Nothing
        sarp = Nothing
        premrp = Nothing
        'indexbo = Nothing
        'usid = Nothing
    End Sub
    Sub searchpliindex(ByVal pno As String)
        Try
            datasetcifdb.Tables("rpliindex").Clear()
        Catch

        End Try
        Dim cs As String = connectionhelper.connectionstringaccount()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        currentrow = 0
        dataadapter = New SqlDataAdapter("SELECT * FROM Pli_Indexing where proposalno='" & pno & "'", databaseconnection)

        dataadapter.Fill(datasetcifdb, "rpliindex")
        'ShowData(currentrow)

        databaseconnection.Close()
    End Sub
    Function IsProposalExist() As Boolean

        Return False
    End Function
End Module
