Imports System.Data.SqlClient
Imports Dapper

Public Class newAccountTransctionRepo
    Implements newAccountTransctionInterface

    Private _db As SqlConnection

    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub

    Private Function AddData(data As NewAccountClass) As Boolean Implements newAccountTransctionInterface.AddData
        Dim parm As SqlParameter() = {
           New SqlParameter("@vrid", data.VirtualId),
           New SqlParameter("@cif", data.cif),
           New SqlParameter("@accountnumber", data.accountnumber),
           New SqlParameter("@name", data.n_ame),
           New SqlParameter("@prtype", data.producttype),
           New SqlParameter("@prterm", data.productterm),
           New SqlParameter("@prvalue", data.productvalue),
           New SqlParameter("@nominireg", data.nominireg),
           New SqlParameter("@nomininame", data.nomininame),
           New SqlParameter("@nominiage", data.nominiage),
           New SqlParameter("@nominiaddress", data.nominiaddress),
           New SqlParameter("@nominirelation", data.nominirelation),
           New SqlParameter("@acopmode", data.acoperatemode),
           New SqlParameter("@guardianname", data.guardianname),
           New SqlParameter("@jointname", data.jointname),
           New SqlParameter("@address", data.address),
           New SqlParameter("@mobile", data.mobile),
           New SqlParameter("@email", data.email),
           New SqlParameter("@dob", data.dob),
           New SqlParameter("@gender", data.gender),
           New SqlParameter("@adhar", data.adhar),
           New SqlParameter("@pan", data.pan),
           New SqlParameter("@photo", data.photo),
           New SqlParameter("@sign", data.sign),
           New SqlParameter("@doo", data.doo),
           New SqlParameter("@balance", data.balance),
           New SqlParameter("@reffno", data.reffno),
           New SqlParameter("@pr", data.pr),
           New SqlParameter("@trid", data.trid),
           New SqlParameter("@status", data.status)
      }
        Dim query As String = "INSERT INTO dbo.newacdb (VirtualId, cif, accountnumber, n_ame, producttype, productterm, productvalue, nominireg, nomininame, nominiage, nominiaddress, nominirelation, acoperatemode, guardianname, jointname, address, mobile, email, dob, gender, adhar, pan, photo, sign, doo, balance, reffno, pr, trid, status) VALUES (@vrid, @cif, @accountnumber, @name, @prtype, @prterm, @prvalue, @nominireg, @nomininame, @nominiage, @nominiaddress, @nominirelation, @acopmode, @guardianname, @jointname, @address, @mobile, @email, @dob,@gender, @adhar, @pan, @photo, @sign, @doo, @balance, @reffno, @pr, @trid, @status)"
        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    _db.Execute(query, args, transction) '1
                    '2
                    '.
                    '.
                    '.
                    transction.Commit()
                Catch ex As Exception
                    transction.Rollback()
                End Try

            End Using
            '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function NewAccountTransction(data As NewAccountClass, data1 As allJournalClass) As Boolean Implements newAccountTransctionInterface.NewAccountTransction
        Dim parm As SqlParameter() = {
          New SqlParameter("@vrid", data.VirtualId),
          New SqlParameter("@cif", data.cif),
          New SqlParameter("@accountnumber", data.accountnumber),
          New SqlParameter("@name", data.n_ame),
          New SqlParameter("@prtype", data.producttype),
          New SqlParameter("@prterm", data.productterm),
          New SqlParameter("@prvalue", data.productvalue),
          New SqlParameter("@nominireg", data.nominireg),
          New SqlParameter("@nomininame", data.nomininame),
          New SqlParameter("@nominiage", data.nominiage),
          New SqlParameter("@nominiaddress", data.nominiaddress),
          New SqlParameter("@nominirelation", data.nominirelation),
          New SqlParameter("@acopmode", data.acoperatemode),
          New SqlParameter("@guardianname", data.guardianname),
          New SqlParameter("@jointname", data.jointname),
          New SqlParameter("@address", data.address),
          New SqlParameter("@mobile", data.mobile),
          New SqlParameter("@email", data.email),
          New SqlParameter("@dob", data.dob),
          New SqlParameter("@gender", data.gender),
          New SqlParameter("@adhar", data.adhar),
          New SqlParameter("@pan", data.pan),
          New SqlParameter("@photo", data.photo),
          New SqlParameter("@sign", data.sign),
          New SqlParameter("@doo", data.doo),
          New SqlParameter("@balance", data.balance),
          New SqlParameter("@reffno", data.reffno),
          New SqlParameter("@pr", data.pr),
          New SqlParameter("@trid", data.trid),
          New SqlParameter("@status", data.status)
     }
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@date", data1.da_te),
        New SqlParameter("@accounttype", data1.accounttype),
        New SqlParameter("@accountnumber", data.accountnumber),
        New SqlParameter("@name", data1.na_me),
        New SqlParameter("@deposit", data1.deposit),
        New SqlParameter("@withdraw", data1.withdraw),
        New SqlParameter("@dlt", data1.dlt),
        New SqlParameter("@trid", data1.trid),
        New SqlParameter("@balance", data1.balance),
        New SqlParameter("@status", data1.status),
        New SqlParameter("@office", data1.office),
        New SqlParameter("@user", data1.u_ser)
        }

        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "update newacdb set balance=@balance,status=@status , trid=@trid  where reffno=@reffno"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "insert into journal (da_te,accounttype,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser) values (@date,@accounttype,@accountnumber,@name,@deposit,@withdraw,@dlt,@trid,@balance,@status,@office,@user)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using
            '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class