Public Class PliTransctionService

    Private _repo As IPliTransction

    Public Sub New()
        _repo = New PliTransctionRepo()
    End Sub
    Public Function AddTransctionfile(transction As classPliTransction) As Boolean
        Return _repo.AddTransaction(transction)
    End Function
End Class
