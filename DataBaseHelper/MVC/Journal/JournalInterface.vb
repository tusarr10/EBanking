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

    Function UpdateSbJournal(data As String, trid As String) As Boolean

    Function DeleteSbjournal(Trid As String) As Boolean

    ' For Rd Journal
    Function getAllfromRdJournal() As List(Of rdJournalClass)

    Function getByAcnoFromRdJournal(AccountNumber As String) As List(Of rdJournalClass)

    Function getByTridFromRdJournal(EnterTransctionId As String) As rdJournalClass

    Function getByDateFromRdJournal(EnterDate As String) As List(Of rdJournalClass)

    Function IsTridExistInRdJournal(Trid As String) As Boolean

    Function IsTransctionApproveInRdJournal(Trid As String) As Boolean

    Function AddtordJournal(Data As rdJournalClass) As Boolean

    Function UpdateRdJournal(Data As String, trid As String) As Boolean

    Function DeleteFromRdJournal(Trid As String) As Boolean

    ' For Ssa Journal

    Function getAllFromSsaJournal() As List(Of ssaJournalClass)

    Function getByAcnoFromSsaJournal(AccountNumber As String) As List(Of ssaJournalClass)

    Function getByTridFromSsaJournal(EnterTrid As String) As ssaJournalClass

    Function getByDateFromSsaJournal(EnterDate As String) As List(Of ssaJournalClass)

    Function IsTridExistInSsaJournal(Trid As String) As Boolean

    Function IsTransctionApproveInSsaJournal(Trid As String) As Boolean

    Function AddtoSsaJournal(Data As ssaJournalClass) As Boolean

    Function UpdateToSsaJournal(Data As String, trid As String) As Boolean

    Function DeleteFromSsaJournal(Trid As ssaJournalClass) As Boolean

    ' For Td Journal
    Function getAllFromTdJournal() As List(Of tdJournalClass)

    Function getByAcnoFromTdJournal(AccountNumber As String) As List(Of tdJournalClass)

    Function getByTridFromTdJournal(EnterTrid As String) As tdJournalClass

    Function getByDateFromTdJournal(EnterDate As String) As List(Of tdJournalClass)

    Function IsTridExistInTdJournal(Trid As String) As Boolean

    Function IsTransctionApproveInTdJournal(Trid As String) As Boolean

    Function AddtoTdJournal(Data As tdJournalClass) As Boolean

    Function UpdateToTdJournal(Data As tdJournalClass) As Boolean

    Function DeleteFromTdJournal(Trid As tdJournalClass) As Boolean

End Interface