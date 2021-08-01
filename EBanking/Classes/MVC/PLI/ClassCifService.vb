Public Class ClassCifService
    Private _repo As ICif
    Public Sub New()
        _repo = New ClassCifRepo()
    End Sub
    Public Function GetAll() As List(Of ClassCif)
        Return _repo.GetAll()
    End Function
    Public Function FindBuId(cif As String) As ClassCif
        Return _repo.FindById(cif)
    End Function
    Public Function AddCif(custmor As ClassCif) As Boolean
        Return _repo.AddCif(custmor)
    End Function
    Public Function UpdateCif(custmor As ClassCif) As Boolean
        Return _repo.UpdateCif(custmor)
    End Function
    Public Function DeleteCif(custmor As String) As Boolean
        Return _repo.DeleteCif(custmor)
    End Function
End Class
