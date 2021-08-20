Public Class pliindexService

    Private _repo As IPliIndex

    Public Sub New(ByVal connectionString As String)
        _repo = New PliIndexRepo(connectionString)
    End Sub

    Public Function GetAll() As List(Of ClassPliIndex)
        Return _repo.GetAll()
    End Function

    Public Function AddCustmor(custmor As ClassPliIndex) As Boolean
        Return _repo.AddCustmor(custmor)
    End Function

    Public Function UpdateCustmor(custmor As ClassPliIndex) As Boolean
        Return _repo.UpdateCustmor(custmor)
    End Function

    Public Function GetByName(name As String) As List(Of ClassPliIndex)
        Return _repo.GetByName(name)
    End Function

    Public Function FindById(id As String) As ClassPliIndex
        Return _repo.FindById(id)
    End Function

    Public Function FindByIdNo(id As String) As ClassPliIndex
        Return _repo.FindByIdNo(id)
    End Function

    Public Function DeleteByPNO(pno As String) As Boolean
        Return _repo.DeleteCustmor(pno)
    End Function

    Public Function IsProposalExist(pno As String) As Boolean
        Return _repo.IsProposalExist(pno)
    End Function

End Class