Public Interface liveAccountInterface
    Function getAll() As List(Of liveAccountClass)
    Function getByName(EnterName As String) As List(Of liveAccountClass)

    'for Retrive Data
    Function getByAccountNumber(AccountNumber As String) As liveAccountClass
    Function getByAccountNumberFromOPMode(AccountNumber As String) As accOperateClass
    Function getByAccountNumberFromNomini(AccountNumber As String) As NominiClass
    Function getByAccountNumberFromProd(AccountNUmber As String) As productClass

    Function gteByCif(cif As String) As List(Of liveAccountClass)
    Function getByType(type As String) As List(Of liveAccountClass)

End Interface
Public Interface liveaccounttransction
    'Insert data

    'Update data

    'update status
End Interface