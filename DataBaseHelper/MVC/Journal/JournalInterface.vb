Public Interface JournalInterface

    ' For All Journal Operation
    Function getAllFromJournal() As List(Of allJournalClass)

    Function getByDateFromJournal(EnterDate As String) As List(Of allJournalClass) 'Search by Date.

    Function getByTridFromJournal(EnterTrid As String) As allJournalClass 'Search By Transction ID.

    Function IsTridExistInJournal(EnterTrid As String) As Boolean ' Check Transction Id Exist Or Not !

    Function AddToJournal(data As allJournalClass) As Boolean

    Function UpdateJournal(data As allJournalClass) As Boolean

    Function DeleteJournal(TransctionId As String) As Boolean

    'For Sb Journal

    Function getAllFromSbJournal() As List(Of sbJournalClass)

    Function getByAcnoFromSbJournal(AccountNumber As String) As List(Of sbJournalClass)

    Function getByTridFormSbJournal(EnterTrid As String) As sbJournalClass

    Function getByDateFromSbJournal(EnterDate As String) As List(Of sbJournalClass)

    Function IsTridExistInSbJournal(trid As String) As Boolean

    Function IsTransctionApproveInSbJournal(trid As String) As Boolean

    Function AddtoSbJournal(data As sbJournalClass) As Boolean

    Function UpdateSbJournal(data As sbJournalClass) As Boolean

    Function DeleteSbjournal(Trid As String) As Boolean

    ' For Rd Journal

    ' For Ssa Journal

    ' For Td Journal

End Interface