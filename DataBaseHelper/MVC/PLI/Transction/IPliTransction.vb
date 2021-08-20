Public Interface IPliTransction

    Function GetAll() As List(Of classPliTransction)

    Function AddTransaction(transction As classPliTransction) As Boolean

    Function DeleteTransaction(trid As String) As Boolean

    Function FindByProposalNo(proposal As String) As List(Of classPliTransction)

End Interface