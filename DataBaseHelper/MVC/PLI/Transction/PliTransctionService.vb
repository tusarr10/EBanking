Public Class PliTransctionService

    Private _repo As IPliTransction

    Public Sub New(ByVal ConnectionString As String)
        _repo = New PliTransctionRepo(ConnectionString)
    End Sub

    Public Function AddTransctionfile(transction As classPliTransction) As Boolean
        Return _repo.AddTransaction(transction)
    End Function
    Public Function IsPolicyExist(policy As String) As Boolean
        Return _repo.IsPolicyExist(policy)
    End Function
    Public Function IstransctioNExist(trid As String) As Boolean
        Return _repo.IstransctionExist(trid)
    End Function
    Public Function FindBuPolicy(policyNum As String) As classPliTransction
        Return _repo.FindByPolicyNum(policyNum)
    End Function
    Public Function getAll() As List(Of classPliTransction)
        Return _repo.GetAll()
    End Function
End Class