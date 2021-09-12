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

    Public Function getByDataFromSbJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As sbJournalClass Implements JournalInterface.getByDataFromSbJournal
        Return Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE trid=@Trid AND status=@status AND accountnumber=@acno AND da_te=@dte", New With {Key .Trid = Trid, Key .status = status, Key .acno = accountNumber, Key .dte = enterdate}).FirstOrDefault

    End Function

    Public Function getByDataFromRdJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As rdJournalClass Implements JournalInterface.getByDataFromRdJournal
        Return Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid AND status=@status AND accountnumber=@acno AND da_te=@dte", New With {Key .Trid = Trid, Key .status = status, Key .acno = accountNumber, Key .dte = enterdate}).FirstOrDefault
    End Function

    Public Function getByDataFromSsabJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As ssaJournalClass Implements JournalInterface.getByDataFromSsabJournal
        Return Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE trid=@Trid AND status=@status AND accountnumber=@acno AND da_te=@dte", New With {Key .Trid = Trid, Key .status = status, Key .acno = accountNumber, Key .dte = enterdate}).FirstOrDefault
    End Function

    Public Function getByDataFromtdJournal(enterdate As String, accountNumber As String, Trid As String, status As String) As tdJournalClass Implements JournalInterface.getByDataFromtdJournal
        Return Me._db.Query(Of tdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid AND status=@status AND accountnumber=@acno AND da_te=@dte", New With {Key .Trid = Trid, Key .status = status, Key .acno = accountNumber, Key .dte = enterdate}).FirstOrDefault
    End Function

    Public Function AddTransctionsb(sbData As sbJournalClass, journalData As allJournalClass) As Boolean Implements JournalInterface.AddTransctionsb
        'accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details)
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", sbData.accountnumber),
        New SqlParameter("@name", sbData.depositername),
        New SqlParameter("@trtype", sbData.transctiontype),
        New SqlParameter("@date", sbData.da_te),
        New SqlParameter("@bbt", sbData.bbt),
        New SqlParameter("@amount", sbData.amount),
        New SqlParameter("@bat", sbData.bat),
        New SqlParameter("@trid", sbData.trid),
        New SqlParameter("@status", sbData.status),
        New SqlParameter("@office", sbData.office),
        New SqlParameter("@user", sbData.u_ser),
        New SqlParameter("@details", sbData.Details)
   }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@date", journalData.da_te),
        New SqlParameter("@actype", journalData.accounttype),
        New SqlParameter("@acno", journalData.accountnumber),
        New SqlParameter("@name", journalData.na_me),
        New SqlParameter("@deposit", journalData.deposit),
        New SqlParameter("@withdraw", journalData.withdraw),
        New SqlParameter("@dlt", journalData.dlt),
        New SqlParameter("@trid", journalData.trid),
        New SqlParameter("@balance", journalData.balance),
        New SqlParameter("@status", journalData.status),
        New SqlParameter("@office", journalData.office),
        New SqlParameter("@user", journalData.u_ser)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "insert into sbjournal (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details)values(@accountnumber,@name,@date,@bbt,@trtype,@amount,@bat,@trid,@status,@office,@user,@details)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values(@date,@actype,@acno,@name ,@deposit,@withdraw,@dlt,@trid,@balance,@status,@office,@user)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddTransctionRd(rdData As rdJournalClass, journalData As allJournalClass) As Boolean Implements JournalInterface.AddTransctionRd
        '(accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,fine,mo_nth 
        Dim parm As SqlParameter() = {
    New SqlParameter("@accountnumber", rdData.accountnumber),
    New SqlParameter("@name", rdData.depositername),
    New SqlParameter("@trtype", rdData.transctiontype),
    New SqlParameter("@date", rdData.da_te),
    New SqlParameter("@bbt", rdData.bbt),
    New SqlParameter("@amount", rdData.amount),
    New SqlParameter("@bat", rdData.bat),
    New SqlParameter("@trid", rdData.trid),
    New SqlParameter("@status", rdData.status),
    New SqlParameter("@office", rdData.office),
    New SqlParameter("@user", rdData.u_ser),
    New SqlParameter("@details", rdData.Details),
    New SqlParameter("@fine", rdData.fine),
    New SqlParameter("@month", rdData.mo_nth)
    }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@date", journalData.da_te),
        New SqlParameter("@actype", journalData.accounttype),
        New SqlParameter("@acno", journalData.accountnumber),
        New SqlParameter("@name", journalData.na_me),
        New SqlParameter("@deposit", journalData.deposit),
        New SqlParameter("@withdraw", journalData.withdraw),
        New SqlParameter("@dlt", journalData.dlt),
        New SqlParameter("@trid", journalData.trid),
        New SqlParameter("@balance", journalData.balance),
        New SqlParameter("@status", journalData.status),
        New SqlParameter("@office", journalData.office),
        New SqlParameter("@user", journalData.u_ser)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try

                    Dim query As String = "insert into rdjournal (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details,mo_nth,fine)values(@accountnumber,@name,@date,@bbt,@trtype,@amount,@bat,@trid,@status,@office,@user,@details,@month,@fine)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values(@date,@actype,@acno,@name ,@deposit,@withdraw,@dlt,@trid,@balance,@status,@office,@user)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddTransctionssa(ssaData As ssaJournalClass, journalData As allJournalClass) As Boolean Implements JournalInterface.AddTransctionssa
        '(accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,fine,mo_nth 
        Dim parm As SqlParameter() = {
    New SqlParameter("@accountnumber", ssaData.accountnumber),
    New SqlParameter("@name", ssaData.depositername),
    New SqlParameter("@trtype", ssaData.transctiontype),
    New SqlParameter("@date", ssaData.da_te),
    New SqlParameter("@bbt", ssaData.bbt),
    New SqlParameter("@amount", ssaData.amount),
    New SqlParameter("@bat", ssaData.bat),
    New SqlParameter("@trid", ssaData.trid),
    New SqlParameter("@status", ssaData.status),
    New SqlParameter("@office", ssaData.office),
    New SqlParameter("@user", ssaData.u_ser),
    New SqlParameter("@details", ssaData.Details),
    New SqlParameter("@fine", ssaData.fine)
    }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@date", journalData.da_te),
        New SqlParameter("@actype", journalData.accounttype),
        New SqlParameter("@acno", journalData.accountnumber),
        New SqlParameter("@name", journalData.na_me),
        New SqlParameter("@deposit", journalData.deposit),
        New SqlParameter("@withdraw", journalData.withdraw),
        New SqlParameter("@dlt", journalData.dlt),
        New SqlParameter("@trid", journalData.trid),
        New SqlParameter("@balance", journalData.balance),
        New SqlParameter("@status", journalData.status),
        New SqlParameter("@office", journalData.office),
        New SqlParameter("@user", journalData.u_ser)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try

                    Dim query As String = "insert into ssajournal (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details,fine)values(@accountnumber,@name,@date,@bbt,@trtype,@amount,@bat,@trid,@status,@office,@user,@details,@fine)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values(@date,@actype,@acno,@name ,@deposit,@withdraw,@dlt,@trid,@balance,@status,@office,@user)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AddTransctiontd(tdData As tdJournalClass, journalData As allJournalClass) As Boolean Implements JournalInterface.AddTransctiontd
        Return False
    End Function

    Public Function AddIntersestSB(sbdata As sbJournalClass, liveac As liveAccountClass) As Boolean Implements JournalInterface.AddIntersestSB
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", sbdata.accountnumber),
        New SqlParameter("@name", sbdata.depositername),
        New SqlParameter("@trtype", sbdata.transctiontype),
        New SqlParameter("@date", sbdata.da_te),
        New SqlParameter("@bbt", sbdata.bbt),
        New SqlParameter("@amount", sbdata.amount),
        New SqlParameter("@bat", sbdata.bat),
        New SqlParameter("@trid", sbdata.trid),
        New SqlParameter("@status", sbdata.status),
        New SqlParameter("@office", sbdata.office),
        New SqlParameter("@user", sbdata.u_ser),
        New SqlParameter("@details", sbdata.Details)
   }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@balance", liveac.balance),
        New SqlParameter("@acno", liveac.accountnumber)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try

                    Dim query As String = "insert into sbjournal (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details)values(@accountnumber,@name,@date,@bbt,@trtype,@amount,@bat,@trid,@status,@office,@user,@details)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "update liveaccount set balance=@balance where accountnumber=@acno"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function addInterestSSA(ssadata As ssaJournalClass, live As liveAccountClass) As Boolean Implements JournalInterface.addInterestSSA
        Dim parm As SqlParameter() = {
    New SqlParameter("@accountnumber", ssadata.accountnumber),
    New SqlParameter("@name", ssadata.depositername),
    New SqlParameter("@trtype", ssadata.transctiontype),
    New SqlParameter("@date", ssadata.da_te),
    New SqlParameter("@bbt", ssadata.bbt),
    New SqlParameter("@amount", ssadata.amount),
    New SqlParameter("@bat", ssadata.bat),
    New SqlParameter("@trid", ssadata.trid),
    New SqlParameter("@status", ssadata.status),
    New SqlParameter("@office", ssadata.office),
    New SqlParameter("@user", ssadata.u_ser),
    New SqlParameter("@details", ssadata.Details),
    New SqlParameter("@fine", ssadata.fine)
    }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@balance", live.balance),
        New SqlParameter("@acno", live.accountnumber)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try

                    Dim query As String = "insert into ssajournal (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details,fine)values(@accountnumber,@name,@date,@bbt,@trtype,@amount,@bat,@trid,@status,@office,@user,@details,@fine)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "update liveaccount set balance=@balance where accountnumber=@acno"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DoSBTransction(sbData As sbJournalClass, dltdata As dltClass) As Boolean Implements JournalInterface.DoSBTransction
        Dim parm As SqlParameter() = {
       New SqlParameter("@trid", sbData.trid),
       New SqlParameter("@status", sbData.status)
         }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@balance", sbData.bat),
        New SqlParameter("@acno", sbData.accountnumber)
        }
        Dim parm3 As SqlParameter() = {
        New SqlParameter("@balance", dltdata.accountbalance),
        New SqlParameter("@acno", dltdata.accountnumber),
        New SqlParameter("@dlt", dltdata.dlt),
        New SqlParameter("@dlt2", dltdata.dlt2)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "update sbjournal set status=@status where trid=@trid"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "update liveaccount set balance=@balance where accountnumber=@acno"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)
                    '3.
                    Dim query3 As String = "update journal set status=@status where trid=@trid"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)
                    '4.
                    Dim query4 As String = "update dlt set dlt=@dlt,dlt2=@dlt2, accountbalance=@balance where accountnumber=@acno"
                    Dim args4 = New DynamicParameters()
                    For Each q As SqlParameter In parm3
                        args4.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query4, args4, transction)
                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DoRDTransction(rdData As rdJournalClass, dltdata As dltClass) As Boolean Implements JournalInterface.DoRDTransction
        Dim parm As SqlParameter() = {
    New SqlParameter("@trid", rdData.trid),
    New SqlParameter("@status", rdData.status)
      }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@balance", rdData.bat),
        New SqlParameter("@acno", rdData.accountnumber)
        }
        Dim parm3 As SqlParameter() = {
        New SqlParameter("@balance", dltdata.accountbalance),
        New SqlParameter("@acno", dltdata.accountnumber),
        New SqlParameter("@dlt", dltdata.dlt),
        New SqlParameter("@dlt2", dltdata.dlt2)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "update rdjournal set status=@status where trid=@trid"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "update liveaccount set balance=@balance where accountnumber=@acno"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)
                    '3.
                    Dim query3 As String = "update journal set status=@status where trid=@trid"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)
                    '4.
                    Dim query4 As String = "update dlt set dlt=@dlt,dlt2=@dlt2, accountbalance=@balance where accountnumber=@acno"
                    Dim args4 = New DynamicParameters()
                    For Each q As SqlParameter In parm3
                        args4.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query4, args4, transction)
                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DoSSATransction(ssaData As ssaJournalClass, dltdata As dltClass) As Boolean Implements JournalInterface.DoSSATransction
        Dim parm As SqlParameter() = {
    New SqlParameter("@trid", ssaData.trid),
    New SqlParameter("@status", ssaData.status)
      }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@balance", ssaData.bat),
        New SqlParameter("@acno", ssaData.accountnumber)
        }
        Dim parm3 As SqlParameter() = {
        New SqlParameter("@balance", dltdata.accountbalance),
        New SqlParameter("@acno", dltdata.accountnumber),
        New SqlParameter("@dlt", dltdata.dlt),
        New SqlParameter("@dlt2", dltdata.dlt2)
        }
        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "update ssajournal set status=@status where trid=@trid"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "update liveaccount set balance=@balance where accountnumber=@acno"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)
                    '3.
                    Dim query3 As String = "update journal set status=@status where trid=@trid"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)
                    '4.
                    Dim query4 As String = "update dlt set dlt=@dlt,dlt2=@dlt2, accountbalance=@balance where accountnumber=@acno"
                    Dim args4 = New DynamicParameters()
                    For Each q As SqlParameter In parm3
                        args4.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query4, args4, transction)
                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DoTDTransction(tdData As tdJournalClass, dltdata As dltClass) As Boolean Implements JournalInterface.DoTDTransction
        Throw New NotImplementedException()
    End Function

    Public Function rejecttransction(TableName As String, Trid As String) As Boolean Implements JournalInterface.rejecttransction
        Dim _tablename As String
        If TableName = "Saving" Then
            _tablename = "sbjournal"
        ElseIf TableName = "RD" Then
            _tablename = "rdjournal"
        ElseIf TableName = "SSA" Then
            _tablename = "ssajournal"
        ElseIf TableName = "TD" Then
            _tablename = "tdjournal"
        Else
            _tablename = TableName
        End If
        Dim parm As SqlParameter() = {
    New SqlParameter("@trid", Trid),
    New SqlParameter("@status", "Rejected"),
    New SqlParameter("@NTrid", "R-" & Trid)
      }

        'da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser 

        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "update " & _tablename & " set status=@status,trid=@NTrid where trid=@trid"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '3.
                    Dim query3 As String = "update journal set status=@status,trid=@NTrid where trid=@trid"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function checkDataAvailable(data As ssaJournalClass) As Object Implements JournalInterface.checkDataAvailableSSA
        Dim x As Integer = Me._db.Query(Of ssaJournalClass)("SELECT * FROM ssajournal WHERE trid=@Trid AND da_te=@date and accountnumber=@acno", New With {Key .Trid = data.trid, Key .date = data.da_te, Key .acno = data.accountnumber}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function checkDataAvailableSb(data As sbJournalClass) As Object Implements JournalInterface.checkDataAvailableSb
        Dim x As Integer = Me._db.Query(Of sbJournalClass)("SELECT * FROM sbjournal WHERE trid=@Trid AND da_te=@date and accountnumber=@acno", New With {Key .Trid = data.trid, Key .date = data.da_te, Key .acno = data.accountnumber}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function checkDataAvailablerd(data As rdJournalClass) As Object Implements JournalInterface.checkDataAvailablerd
        Dim x As Integer = Me._db.Query(Of rdJournalClass)("SELECT * FROM rdjournal WHERE trid=@Trid AND da_te=@date and accountnumber=@acno", New With {Key .Trid = data.trid, Key .date = data.da_te, Key .acno = data.accountnumber}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class