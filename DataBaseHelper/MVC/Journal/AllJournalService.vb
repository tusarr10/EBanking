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

End Class