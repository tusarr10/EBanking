Imports System.Data.SqlClient
Imports Dapper

Public Class AllJournalRepo
    Implements JournalInterface

    Private _db As IDbConnection

    Public Sub New(ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub

    Public Function getAllFromJournal() As List(Of allJournalClass) Implements JournalInterface.getAllFromJournal
        Return Me._db.Query(Of allJournalClass)("SELECT * FROM journal").ToList
    End Function

    Public Function getByDateFromJournal(EnterDate As String) As List(Of allJournalClass) Implements JournalInterface.getByDateFromJournal
        Return Me._db.Query(Of allJournalClass)("SELECT * FROM journal WHERE da_te =@EnterDate", New With {Key .EnterDate = EnterDate}).ToList
    End Function

    Public Function getByTridFromJournal(EnterTrid As String) As allJournalClass Implements JournalInterface.getByTridFromJournal
        Return Me._db.Query(Of allJournalClass)("SELECT * FROM journal WHERE trid=@Trid", New With {Key .Trid = EnterTrid}).FirstOrDefault
    End Function

    Public Function IsTridExistInJournal(EnterTrid As String) As Boolean Implements JournalInterface.IsTridExistInJournal
        Dim x As Integer = Me._db.Query(Of allJournalClass)("SELECT * FROM journal WHERE trid=@Trid", New With {Key .Trid = EnterTrid}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AddToJournal(data As allJournalClass) As Boolean Implements JournalInterface.AddToJournal
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", data.da_te),
        New SqlParameter("@accounttype", data.accounttype),
        New SqlParameter("@accountnumber", data.accountnumber),
        New SqlParameter("@name", data.na_me),
        New SqlParameter("@deposit", data.deposit),
        New SqlParameter("@withdraw", data.withdraw),
        New SqlParameter("@dlt", data.dlt),
        New SqlParameter("@trid", data.trid),
        New SqlParameter("@balance", data.balance),
        New SqlParameter("@status", data.status),
        New SqlParameter("@office", data.office),
        New SqlParameter("@user", data.u_ser)
        }
        Dim query As String = "INSERT INTO dbo.journal (da_te, accounttype, accountnumber, na_me, deposit, withdraw, dlt, trid, balance, status, office, u_ser) VALUES (@date, @accounttype, @accountnumber, @name, @deposit, @withdraw, @dlt, @trid, @balance, @status, @office, @user)"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateJournal(data As allJournalClass) As Boolean Implements JournalInterface.UpdateJournal
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", data.da_te),
        New SqlParameter("@accounttype", data.accounttype),
        New SqlParameter("@accountnumber", data.accountnumber),
        New SqlParameter("@name", data.na_me),
        New SqlParameter("@deposit", data.deposit),
        New SqlParameter("@withdraw", data.withdraw),
        New SqlParameter("@dlt", data.dlt),
        New SqlParameter("@trid", data.trid),
        New SqlParameter("@balance", data.balance),
        New SqlParameter("@status", data.status),
        New SqlParameter("@office", data.office),
        New SqlParameter("@user", data.u_ser)
        }
        Dim query As String = "UPDATE journal SET da_te = @date,accounttype = @accounttype,accountnumber = @accountnumber ,na_me = @name,deposit = @deposit,withdraw = @withdraw,dlt = @dlt,trid = @trid,balance = @balance,status = @status,office = @office,u_ser = @user"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteJournal(TransctionId As String) As Boolean Implements JournalInterface.DeleteJournal
        Throw New NotImplementedException()
    End Function

    Public Function getAllFromSbJournal() As List(Of sbJournalClass) Implements JournalInterface.getAllFromSbJournal
        Return Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal").ToList
    End Function

    Public Function getByAcnoFromSbJournal(AccountNumber As String) As List(Of sbJournalClass) Implements JournalInterface.getByAcnoFromSbJournal
        Return Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE accountnumber=@acno", New With {Key .acno = AccountNumber}).ToList
    End Function

    Public Function getByTridFormSbJournal(EnterTrid As String) As sbJournalClass Implements JournalInterface.getByTridFormSbJournal
        Return Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE trid=@Trid", New With {Key .Trid = EnterTrid}).FirstOrDefault
    End Function

    Public Function getByDateFromSbJournal(EnterDate As String) As List(Of sbJournalClass) Implements JournalInterface.getByDateFromSbJournal
        Return Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE da_te =@EnterDate", New With {Key .EnterDate = EnterDate}).ToList
    End Function

    Public Function IsTridExistInSbJournal(trid As String) As Boolean Implements JournalInterface.IsTridExistInSbJournal
        Dim x As Integer = Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE trid=@Trid", New With {Key .Trid = trid}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsTransctionApproveInSbJournal(trid As String) As Boolean Implements JournalInterface.IsTransctionApproveInSbJournal
        Dim x As Integer = Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE trid=@Trid AND status=@status", New With {Key .Trid = trid, Key .status = "Approved"}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function AddtoSbJournal(data As sbJournalClass) As Boolean Implements JournalInterface.AddtoSbJournal
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", data.accountnumber),
        New SqlParameter("@depositername", data.depositername),
        New SqlParameter("@date", data.da_te),
        New SqlParameter("@bbt", data.bbt),
        New SqlParameter("@transctiontype", data.transctiontype),
        New SqlParameter("@amount", data.amount),
        New SqlParameter("@bat", data.bat),
        New SqlParameter("@trid", data.trid),
        New SqlParameter("@details", data.Details),
        New SqlParameter("@status", data.status),
        New SqlParameter("@office", data.office),
        New SqlParameter("@user", data.u_ser)
        }
        Dim query As String = "INSERT INTO dbo.sbjournal (accountnumber, depositername, da_te, bbt, transctiontype, amount, bat, trid, status, office, u_ser, Details) VALUES (@accountnumber, @depositername, @date, @bbt, @transctiontype, @amount, @bat, @trid, @status, @office, @user, @details)"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateSbJournal(data As String, trid As String) As Boolean Implements JournalInterface.UpdateSbJournal 'only for transction status
        Dim parm As SqlParameter() = {
        New SqlParameter("@status", data),
        New SqlParameter("@trid", trid)
        }
        Dim query As String = "update sbjournal set status=@status where trid=@trid"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteSbjournal(Trid As String) As Boolean Implements JournalInterface.DeleteSbjournal
        Throw New NotImplementedException()
    End Function

    Public Function getAllfromRdJournal() As List(Of rdJournalClass) Implements JournalInterface.getAllfromRdJournal
        Return Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal").ToList
    End Function

    Public Function getByAcnoFromRdJournal(AccountNumber As String) As List(Of rdJournalClass) Implements JournalInterface.getByAcnoFromRdJournal
        Return Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE accountnumber=@acno", New With {Key .acno = AccountNumber}).ToList
    End Function

    Public Function getByTridFromRdJournal(EnterTransctionId As String) As rdJournalClass Implements JournalInterface.getByTridFromRdJournal
        Return Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid", New With {Key .Trid = EnterTransctionId}).FirstOrDefault
    End Function

    Public Function getByDateFromRdJournal(EnterDate As String) As List(Of rdJournalClass) Implements JournalInterface.getByDateFromRdJournal
        Return Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal  WHERE da_te =@EnterDate", New With {Key .EnterDate = EnterDate}).ToList
    End Function

    Public Function IsTridExistInRdJournal(Trid As String) As Boolean Implements JournalInterface.IsTridExistInRdJournal
        Dim x As Integer = Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid", New With {Key .Trid = Trid}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsTransctionApproveInRdJournal(Trid As String) As Boolean Implements JournalInterface.IsTransctionApproveInRdJournal
        Dim x As Integer = Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid AND status=@status", New With {Key .Trid = Trid, Key .status = "Approved"}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AddtordJournal(Data As rdJournalClass) As Boolean Implements JournalInterface.AddtordJournal
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", Data.accountnumber),
        New SqlParameter("@depositername", Data.depositername),
        New SqlParameter("@date", Data.da_te),
        New SqlParameter("@bbt", Data.bbt),
        New SqlParameter("@transctiontype", Data.transctiontype),
        New SqlParameter("@amount", Data.amount),
        New SqlParameter("@bat", Data.bat),
        New SqlParameter("@trid", Data.trid),
        New SqlParameter("@details", Data.Details),
        New SqlParameter("@status", Data.status),
        New SqlParameter("@office", Data.office),
        New SqlParameter("@fine", Data.fine),
        New SqlParameter("@month", Data.mo_nth),
        New SqlParameter("@user", Data.u_ser)
        }
        Dim query As String = "INSERT INTO rdjournal(accountnumber, da_te, depositername, bbt, transctiontype, amount, fine, bat, mo_nth, trid, status, office, u_ser, Details) VALUES (@accountnumber, @date, @depositername, @bbt, @transctiontype, @amount,@fine, @bat,@month, @trid, @status, @office, @user, @details)"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateRdJournal(Data As String, trid As String) As Boolean Implements JournalInterface.UpdateRdJournal
        Dim parm As SqlParameter() = {
 New SqlParameter("@status", Data),
 New SqlParameter("@trid", trid)
 }
        Dim query As String = "update rdjournal set status=@status where trid=@trid"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteFromRdJournal(Trid As String) As Boolean Implements JournalInterface.DeleteFromRdJournal
        Throw New NotImplementedException()
    End Function

    Public Function getAllFromSsaJournal() As List(Of ssaJournalClass) Implements JournalInterface.getAllFromSsaJournal
        Return Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal").ToList
    End Function

    Public Function getByAcnoFromSsaJournal(AccountNumber As String) As List(Of ssaJournalClass) Implements JournalInterface.getByAcnoFromSsaJournal
        Return Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE accountnumber=@acno", New With {Key .acno = AccountNumber}).ToList
    End Function

    Public Function getByTridFromSsaJournal(EnterTrid As String) As ssaJournalClass Implements JournalInterface.getByTridFromSsaJournal
        Return Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE trid=@Trid", New With {Key .Trid = EnterTrid}).FirstOrDefault
    End Function

    Public Function getByDateFromSsaJournal(EnterDate As String) As List(Of ssaJournalClass) Implements JournalInterface.getByDateFromSsaJournal
        Return Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal  WHERE da_te =@EnterDate", New With {Key .EnterDate = EnterDate}).ToList
    End Function

    Public Function IsTridExistInSsaJournal(Trid As String) As Boolean Implements JournalInterface.IsTridExistInSsaJournal
        Dim x As Integer = Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE trid=@Trid", New With {Key .Trid = Trid}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsTransctionApproveInSsaJournal(Trid As String) As Boolean Implements JournalInterface.IsTransctionApproveInSsaJournal
        Dim x As Integer = Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE trid=@Trid AND status=@status", New With {Key .Trid = Trid, Key .status = "Approved"}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AddtoSsaJournal(Data As ssaJournalClass) As Boolean Implements JournalInterface.AddtoSsaJournal
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", Data.accountnumber),
        New SqlParameter("@depositername", Data.depositername),
        New SqlParameter("@date", Data.da_te),
        New SqlParameter("@bbt", Data.bbt),
        New SqlParameter("@transctiontype", Data.transctiontype),
        New SqlParameter("@amount", Data.amount),
        New SqlParameter("@bat", Data.bat),
        New SqlParameter("@trid", Data.trid),
        New SqlParameter("@details", Data.Details),
        New SqlParameter("@status", Data.status),
        New SqlParameter("@office", Data.office),
        New SqlParameter("@fine", Data.fine),
        New SqlParameter("@user", Data.u_ser)
        }
        Dim query As String = "INSERT INTO ssajournal (accountnumber, da_te, depositername, transctiontype, bbt, amount, fine, bat, trid, status, office, u_ser, Details) VALUES (@accountnumber, @date, @depositername, @transctiontype, @bbt, @amount,@fine, @bat, @trid, @status, @office, @user, @details)"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateToSsaJournal(Data As String, trid As String) As Boolean Implements JournalInterface.UpdateToSsaJournal
        Dim parm As SqlParameter() = {
 New SqlParameter("@status", Data),
 New SqlParameter("@trid", trid)
 }
        Dim query As String = "update ssajournal set status=@status where trid=@trid"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DeleteFromSsaJournal(Trid As ssaJournalClass) As Boolean Implements JournalInterface.DeleteFromSsaJournal
        Throw New NotImplementedException()
    End Function

    Public Function getAllFromTdJournal() As List(Of tdJournalClass) Implements JournalInterface.getAllFromTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function getByAcnoFromTdJournal(AccountNumber As String) As List(Of tdJournalClass) Implements JournalInterface.getByAcnoFromTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function getByTridFromTdJournal(EnterTrid As String) As tdJournalClass Implements JournalInterface.getByTridFromTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function getByDateFromTdJournal(EnterDate As String) As List(Of tdJournalClass) Implements JournalInterface.getByDateFromTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function IsTridExistInTdJournal(Trid As String) As Boolean Implements JournalInterface.IsTridExistInTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function IsTransctionApproveInTdJournal(Trid As String) As Boolean Implements JournalInterface.IsTransctionApproveInTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function AddtoTdJournal(Data As tdJournalClass) As Boolean Implements JournalInterface.AddtoTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function UpdateToTdJournal(Data As tdJournalClass) As Boolean Implements JournalInterface.UpdateToTdJournal
        Throw New NotImplementedException()
    End Function

    Public Function DeleteFromTdJournal(Trid As tdJournalClass) As Boolean Implements JournalInterface.DeleteFromTdJournal
        Throw New NotImplementedException()
    End Function

End Class