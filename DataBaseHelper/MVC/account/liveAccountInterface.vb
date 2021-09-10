Public Interface liveAccountInterface

    Function getAll() As List(Of liveAccountClass)

    Function getByName(EnterName As String) As List(Of liveAccountClass)

    'for Retrive Data
    Function getByAccountNumber(AccountNumber As String) As liveAccountClass

    Function IsAccountNumberExist(AccountNumber As String) As Boolean

    Function getByAccountNumberFromOPMode(AccountNumber As String) As accOperateClass

    Function getByAccountNumberFromNomini(AccountNumber As String) As NominiClass

    Function getByAccountNumberFromProd(AccountNUmber As String) As productClass

    Function gteByCif(cif As String) As List(Of liveAccountClass)

    Function getByType(type As String) As List(Of liveAccountClass)

    Function UpdateAccountStatus(AccountNumber As String, Status As String) As Boolean

End Interface

Public Interface liveaccounttransctionInterface

    'Insert data
    Function InsertIntoLiveAccount(dblive As liveAccountClass) As Boolean

    Function MadeAddAccountTransction(liveACData As liveAccountClass, NominiData As NominiClass, Prtype As productClass, opdata As accOperateClass, dltdata As dltClass) As Boolean

    'Update data

    'update status
End Interface