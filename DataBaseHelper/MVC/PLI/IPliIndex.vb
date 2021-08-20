Public Interface IPliIndex

    Function GetAll() As List(Of ClassPliIndex) ' table

    Function GetByName(name As String) As List(Of ClassPliIndex) 'filter table

    Function FindById(id As String) As ClassPliIndex 'get individual data

    Function AddCustmor(custmor As ClassPliIndex) As Boolean

    Function UpdateCustmor(custmor As ClassPliIndex) As Boolean

    Function DeleteCustmor(pno As String) As Boolean

    Function IsProposalExist(Proposal As String) As Boolean

    Function FindByIdNo(id As String) As ClassPliIndex

End Interface