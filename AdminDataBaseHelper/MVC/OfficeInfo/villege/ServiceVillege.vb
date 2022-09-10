Public Class ServiceVillege
    Private _repo As Ivillege

    ' this reffer to logic form
    Public Sub New(ByVal ConnectionString As String)
        _repo = New RepoVillege(ConnectionString)
    End Sub

    Public Function GetAll() As List(Of RepoVillege)
        Return _repo.GetAll()
    End Function
    Public Function GetVillege(ByVal officecode As String) As List(Of RepoVillege)
        Return _repo.FindByOfficeCode(officecode)
    End Function
    Public Function GetVillege5star(ByVal officecode As String) As List(Of RepoVillege)
        Return _repo.FindBy5star(officecode)
    End Function
    Public Function GetVillegessb(ByVal officecode As String) As List(Of RepoVillege)
        Return _repo.FindByssb(officecode)
    End Function
    Public Function GetVillegessg(ByVal officecode As String) As List(Of RepoVillege)
        Return _repo.FindByssg(officecode)
    End Function
    Public Function AddVillege(ByVal clasvillege As clsvillege) As Boolean
        Return _repo.Addvillege(clasvillege)
    End Function
    Public Function updateVillege(ByVal officecode As clsvillege) As Boolean
        Return _repo.Updatevillege(officecode)
    End Function
    Public Function GetVillegessg(ByVal officecode As clsvillege) As Boolean
        Return _repo.Deletevillege(officecode)
    End Function
End Class
