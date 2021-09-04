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

    Public Function getByAcNo(EnterAccountNumber As String) As liveAccountClass
        Return _repo.getByAccountNumber(EnterAccountNumber)
    End Function
    Public Function getByAcnoFromNomini(accountNUmber As String) As NominiClass
        Return _repo.getByAccountNumberFromNomini(accountNUmber)
    End Function
    Public Function getByAccountNumberFromAcType(accountNumber As String) As productClass
        Return _repo.getByAccountNumberFromProd(accountNumber)
    End Function
    Public Function getByAcNoFromOpMode(accountNumber As String) As accOperateClass
        Return _repo.getByAccountNumberFromOPMode(accountNumber)
    End Function

    Public Function IsAccountNumberExist(AccountNumber As String) As Boolean
        Return Me._repo.IsAccountNumberExist(AccountNumber)
    End Function
    Public Function UpdateAccountStatus(AccountNUmber As String, status As String) As Boolean
        Return _repo.UpdateAccountStatus(AccountNUmber, status)
    End Function

End Class