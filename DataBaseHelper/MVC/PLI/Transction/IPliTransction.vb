Public Interface IPliTransction

    Function GetAll() As List(Of classPliTransction)

    Function AddTransaction(transction As classPliTransction) As Boolean

    Function DeleteTransaction(trid As String) As Boolean

    Function FindByProposalNo(proposal As String) As List(Of classPliTransction)
    Function IstransctionExist(trid As String) As Boolean
    Function IsPolicyExist(num As String) As Boolean
    Function FindByPolicyNum(policyNum As String) As classPliTransction


End Interface