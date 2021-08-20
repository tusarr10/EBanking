Public Class OperateModeService
    Private _repo As IOperateMode

    Public Sub New(ByVal connectionString As String)
        _repo = New operateModeRepo(connectionString)
    End Sub

    Public Function GetAll() As List(Of ClassOperateMode)
        Return Me._repo.getAll()
    End Function

    Public Function FindByAccountNumber(AccountNumber As String) As ClassOperateMode
        Return Me._repo.FindByAccountNumber(AccountNumber)

    End Function

    Public Function FindAllByAccountNumber() As List(Of ClassOperateMode)
        Return Me._repo.FindAllByAccountNumber()
    End Function

End Class