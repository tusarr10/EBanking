Public Class dacService
    Private _repo As Idac
    Public Sub New(ConnectionString As String)
        _repo = New dacRepo(ConnectionString)
    End Sub
    Function GetAll() As List(Of dacClass)
        Return _repo.GetAll()
    End Function
    Function SearchByDate(EnterDate As String) As dacClass
        Return _repo.SearchByDate(EnterDate)
    End Function
    Function SearchByMonth(EnterMonth As String, EnterYear As String) As List(Of dacClass)
        Return _repo.SearchAllByMonth(EnterMonth, EnterYear)
    End Function
    Function InsertData(data As dacClass) As Boolean
        Return _repo.InsertData(data)
    End Function
    Function Update(data As dacClass) As Boolean
        Return _repo.updateData(data)
    End Function
    Function updateStatus(data As dacClass) As Boolean
        Return _repo.updateStatus(data)
    End Function
    Function Delete(data As dacClass) As Boolean
        Return _repo.DeleteData(data)
    End Function
    Function IsDataExist(data As dacClass) As Boolean
        Return _repo.IsDataExist(data)
    End Function
End Class
