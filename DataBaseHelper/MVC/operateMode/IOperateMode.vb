Public Interface IOperateMode

    Function getAll() As IList(Of ClassOperateMode)

    Function FindByAccountNumber(AccountNumber As String) As ClassOperateMode

    Function FindAllByAccountNumber() As IList(Of ClassOperateMode)

    Function AddOperateModeData(data As ClassOperateMode) As Boolean

    Function DeleteData(AccountNumber As String) As Boolean

    Function UpdateoperateModeDate(data As ClassOperateMode) As Boolean

End Interface