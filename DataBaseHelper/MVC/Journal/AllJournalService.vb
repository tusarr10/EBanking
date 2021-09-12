Public Class AllJournalService
    Private _repo As JournalInterface

    Sub New(connection As String)
        _repo = New AllJournalRepo(connection)
    End Sub

    Public Function GetAll() As List(Of allJournalClass)
        Return _repo.getAllFromJournal()
    End Function

    Public Function GetAllFromSb() As List(Of sbJournalClass)
        Return _repo.getAllFromSbJournal()
    End Function

    Public Function GetAllfromRd() As List(Of rdJournalClass)
        Return _repo.getAllfromRdJournal()
    End Function

    Public Function getAllFromSSA() As List(Of ssaJournalClass)
        Return _repo.getAllFromSsaJournal()
    End Function

    Public Function getByDateFromJournal(Datee As String) As List(Of allJournalClass)
        Return _repo.getByDateFromJournal(Datee)
    End Function

    Public Function getByDateFromSb(datee As String) As List(Of sbJournalClass)
        Return _repo.getByDateFromSbJournal(datee)
    End Function

    Public Function getByDateFromRd(datee As String) As List(Of rdJournalClass)
        Return _repo.getByDateFromRdJournal(datee)
    End Function

    Public Function getByDateFromSsa(datee As String) As List(Of ssaJournalClass)
        Return _repo.getByDateFromSsaJournal(datee)
    End Function

    Public Function getBydataFromSb(enterdate As String, accountNumber As String, Trid As String, status As String) As sbJournalClass
        Return _repo.getByDataFromSbJournal(enterdate, accountNumber, Trid, status)
    End Function

    Public Function getBydataFromssa(enterdate As String, accountNumber As String, Trid As String, status As String) As ssaJournalClass
        Return _repo.getByDataFromSsabJournal(enterdate, accountNumber, Trid, status)
    End Function

    Public Function getBydataFromrd(enterdate As String, accountNumber As String, Trid As String, status As String) As rdJournalClass
        Return _repo.getByDataFromRdJournal(enterdate, accountNumber, Trid, status)
    End Function

    Public Function getBydataFromtd(enterdate As String, accountNumber As String, Trid As String, status As String) As tdJournalClass
        Return _repo.getByDataFromtdJournal(enterdate, accountNumber, Trid, status)
    End Function
    Public Function AddtransctionSb(sbData As sbJournalClass, journalData As allJournalClass) As Boolean
        Return _repo.AddTransctionsb(sbData, journalData)
    End Function
    Public Function AddtransctionSSA(ssaData As ssaJournalClass, journalData As allJournalClass) As Boolean
        Return _repo.AddTransctionssa(ssaData, journalData)
    End Function
    Public Function AddtransctionRD(rdData As rdJournalClass, journalData As allJournalClass) As Boolean
        Return _repo.AddTransctionRd(rdData, journalData)
    End Function
    Public Function AddtransctionTD(tdData As tdJournalClass, journalData As allJournalClass) As Boolean
        Return _repo.AddTransctiontd(tdData, journalData)
    End Function
    Public Function addInteresrSB(sbdata As sbJournalClass, liveac As liveAccountClass) As Boolean
        Return _repo.AddIntersestSB(sbdata, liveac)
    End Function
    Public Function addInteresrSsa(ssadata As ssaJournalClass, liveac As liveAccountClass) As Boolean
        Return _repo.addInterestSSA(ssadata, liveac)
    End Function
    Public Function doSBTransction(sbData As sbJournalClass, dltdata As dltClass) As Boolean
        Return _repo.DoSBTransction(sbData, dltdata)
    End Function
    Public Function dordTransction(rdData As rdJournalClass, dltdata As dltClass) As Boolean
        Return _repo.DoRDTransction(rdData, dltdata)
    End Function
    Public Function doSSATransction(ssaData As ssaJournalClass, dltdata As dltClass) As Boolean
        Return _repo.DoSSATransction(ssaData, dltdata)
    End Function
    Public Function rejectTransction(ProductType As String, trid As String) As Boolean
        Return _repo.rejecttransction(ProductType, trid)
    End Function
    Public Function IsTridExistInJournal(trid As String) As Boolean
        Return _repo.IsTridExistInJournal(trid)
    End Function
    Public Function IsTridExistInsbJournal(trid As String) As Boolean
        Return _repo.IsTridExistInSbJournal(trid)
    End Function
    Public Function IsTridExistInrdJournal(trid As String) As Boolean
        Return _repo.IsTridExistInRdJournal(trid)
    End Function
    Public Function IsTridExistInssaJournal(trid As String) As Boolean
        Return _repo.IsTridExistInSsaJournal(trid)
    End Function
    Public Function addToJournal(data As allJournalClass) As Boolean
        Return _repo.AddToJournal(data)
    End Function
    Public Function addToSbjournal(data As sbJournalClass) As Boolean
        Return _repo.AddtoSbJournal(data)
    End Function
    Public Function addTordjournal(data As rdJournalClass) As Boolean
        Return _repo.AddtordJournal(data)
    End Function
    Public Function addToSsajournal(data As ssaJournalClass) As Boolean
        Return _repo.AddtoSsaJournal(data)
    End Function
    'for Developer Module
    Public Function IsDataExistInSB(data As sbJournalClass) As Boolean
        Return _repo.checkDataAvailableSb(data)
    End Function
    Public Function IsDataExistInrd(data As rdJournalClass) As Boolean
        Return _repo.checkDataAvailablerd(data)
    End Function
    Public Function IsDataExistInSsa(data As ssaJournalClass) As Boolean
        Return _repo.checkDataAvailableSSA(data)
    End Function
End Class