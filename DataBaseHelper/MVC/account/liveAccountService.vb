Public Class liveAccountService
    Private _repo As liveAccountInterface
    Public Sub New(connection As String)
        _repo = New liveAccountRepo(connection)

    End Sub
    Public Function GetAll() As List(Of liveAccountClass)
        Return _repo.getAll()
    End Function
    Public Function getByName(EnterName As String)
        Return _repo.getByName(EnterName)
    End Function
End Class
