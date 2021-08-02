Public Class pliindexService

    Private _repo As IPliIndex
    Public Sub New()
        _repo = New PliIndexRepo
    End Sub
    Public Function GetAll() As List(Of ClassPliIndex)
        Return _repo.GetAll()
    End Function
End Class
