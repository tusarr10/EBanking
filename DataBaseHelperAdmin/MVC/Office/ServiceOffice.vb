Public Class ServiceOffice
    Private _repo As Ioffice
    Public Sub New(ByVal ConnectionString As String)
        _repo = New Repooffice(ConnectionString)
    End Sub
    Public Function GetAll() As List(Of clsoffice)
        Return _repo.GetAll()
    End Function
    Public Function FindByOfficeCode(Officecode As String) As clsoffice
        Return _repo.FindByOfficeCode(Officecode)
    End Function
    Public Function AddOffice(office As clsoffice) As Boolean
        Return _repo.AddOffice(office)
    End Function
    Public Function UpdateOffice(office As clsoffice) As Boolean
        Return _repo.UpdateOffice(office)
    End Function
    Public Function DeleteOffice(office As String) As Boolean
        Return _repo.DeleteOffice(office)
    End Function
End Class
