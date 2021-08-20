Public Class PliTransctionService

    Private _repo As IPliTransction

    Public Sub New(ByVal ConnectionString As String)
        _repo = New PliTransctionRepo(ConnectionString)
    End Sub

    Public Function AddTransctionfile(transction As classPliTransction) As Boolean
        Return _repo.AddTransaction(transction)
    End Function

End Class