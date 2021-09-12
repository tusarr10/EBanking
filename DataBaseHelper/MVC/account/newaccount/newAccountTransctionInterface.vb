Public Interface newAccountTransctionInterface

    Function AddData(data As NewAccountClass) As Boolean

    Function NewAccountTransction(data As NewAccountClass, data1 As allJournalClass) As Boolean
    Function NewAccountUpdate(data As NewAccountClass) As Boolean

End Interface