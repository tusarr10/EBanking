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

    Function getByDataFromSbJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As sbJournalClass

    Function IsTridExistInSbJournal(trid As String) As Boolean

    Function IsTransctionApproveInSbJournal(trid As String) As Boolean

    Function AddtoSbJournal(data As sbJournalClass) As Boolean

    Function UpdateSbJournal(data As String, trid As String) As Boolean

    Function DeleteSbjournal(Trid As String) As Boolean

    Function AddTransctionsb(sbData As sbJournalClass, journalData As allJournalClass) As Boolean
    Function DoSBTransction(sbData As sbJournalClass, dltdata As dltClass) As Boolean 'Grab Status trid bat accountnumber from sb class and dlt info from dlt class 
    Function rejecttransction(TableName As String, Trid As String) As Boolean
    Function AddIntersestSB(sbdata As sbJournalClass, liveac As liveAccountClass) As Boolean

    ' For Rd Journal
    Function getAllfromRdJournal() As List(Of rdJournalClass)

    Function getByAcnoFromRdJournal(AccountNumber As String) As List(Of rdJournalClass)

    Function getByTridFromRdJournal(EnterTransctionId As String) As rdJournalClass

    Function getByDataFromRdJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As rdJournalClass

    Function getByDateFromRdJournal(EnterDate As String) As List(Of rdJournalClass)

    Function IsTridExistInRdJournal(Trid As String) As Boolean

    Function IsTransctionApproveInRdJournal(Trid As String) As Boolean

    Function AddtordJournal(Data As rdJournalClass) As Boolean

    Function UpdateRdJournal(Data As String, trid As String) As Boolean

    Function DeleteFromRdJournal(Trid As String) As Boolean
    Function AddTransctionRd(rdData As rdJournalClass, journalData As allJournalClass) As Boolean
    Function DoRDTransction(rdData As rdJournalClass, dltdata As dltClass) As Boolean 'Grab Status trid bat accountnumber from sb class and dlt info from dlt class 

    ' For Ssa Journal

    Function getAllFromSsaJournal() As List(Of ssaJournalClass)

    Function getByAcnoFromSsaJournal(AccountNumber As String) As List(Of ssaJournalClass)

    Function getByTridFromSsaJournal(EnterTrid As String) As ssaJournalClass

    Function getByDateFromSsaJournal(EnterDate As String) As List(Of ssaJournalClass)

    Function getByDataFromSsabJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As ssaJournalClass

    Function IsTridExistInSsaJournal(Trid As String) As Boolean

    Function IsTransctionApproveInSsaJournal(Trid As String) As Boolean

    Function AddtoSsaJournal(Data As ssaJournalClass) As Boolean

    Function UpdateToSsaJournal(Data As String, trid As String) As Boolean

    Function DeleteFromSsaJournal(Trid As ssaJournalClass) As Boolean
    Function AddTransctionssa(ssaData As ssaJournalClass, journalData As allJournalClass) As Boolean
    Function DoSSATransction(ssaData As ssaJournalClass, dltdata As dltClass) As Boolean 'Grab Status trid bat accountnumber from ssa class and dlt info from dlt class 
    Function addInterestSSA(ssadata As ssaJournalClass, live As liveAccountClass) As Boolean

    ' For Td Journal
    Function getAllFromTdJournal() As List(Of tdJournalClass)

    Function getByAcnoFromTdJournal(AccountNumber As String) As List(Of tdJournalClass)

    Function getByTridFromTdJournal(EnterTrid As String) As tdJournalClass

    Function getByDataFromtdJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As tdJournalClass

    Function getByDateFromTdJournal(EnterDate As String) As List(Of tdJournalClass)

    Function IsTridExistInTdJournal(Trid As String) As Boolean

    Function IsTransctionApproveInTdJournal(Trid As String) As Boolean

    Function AddtoTdJournal(Data As tdJournalClass) As Boolean

    Function UpdateToTdJournal(Data As tdJournalClass) As Boolean

    Function DeleteFromTdJournal(Trid As tdJournalClass) As Boolean
    Function AddTransctiontd(tdData As tdJournalClass, journalData As allJournalClass) As Boolean
    Function DoTDTransction(tdData As tdJournalClass, dltdata As dltClass) As Boolean 'Grab Status trid bat accountnumber from sb class and dlt info from dlt class 



    ' Generlly for developer Mode
    Function checkDataAvailableSSA(data As ssaJournalClass)
    Function checkDataAvailableSb(data As sbJournalClass)
    Function checkDataAvailablerd(data As rdJournalClass)
End Interface
