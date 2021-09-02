
Public Class newAccountTransctionService
    Private _repo1 As newAccountTransctionInterface
    Public Sub New(connection As String)
        _repo1 = New newAccountTransctionRepo(connection)
    End Sub
    Function AddData(data As NewAccountClass) As Boolean
        Return _repo1.AddData(data)
    End Function
    Function AddTransction(data As NewAccountClass, data1 As allJournalClass) As Boolean
        Return _repo1.NewAccountTransction(data, data1)
    End Function
End Class