Public Class newAccountService
    Private _repo As newAccountInterface

    Public Sub New(connection As String)
        _repo = New newAccountRepo(connection)
    End Sub

    Function IsReffNoExistInNewAccount(reffno As String) As Boolean
        Return _repo.IsReffNoExist(reffno)
    End Function

    'Function AddData(data As NewAccountClass) As Boolean
    '    Return _repo.AddData(data)
    'End Function
    Function getByName(Name As String) As List(Of NewAccountClass)
        Return _repo.getByName(Name)
    End Function

    Function getByReffNo(Reffno As String) As NewAccountClass
        Return _repo.gteByReffNo(Reffno)
    End Function

End Class