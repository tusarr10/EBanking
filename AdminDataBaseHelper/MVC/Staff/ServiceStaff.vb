Public Class ServiceStaff
    Private _repo As Istaff
    Public Sub New(ByVal Connectiontring As String)
        _repo = New RepoStaff(Connectiontring)
    End Sub
    Public Function GetAll() As List(Of ClassStaff)
        Return _repo.GetAll()
    End Function
    Public Function GetAllByOfficeCode() As List(Of ClassStaff)
        Return _repo.GetAll()
    End Function

End Class
