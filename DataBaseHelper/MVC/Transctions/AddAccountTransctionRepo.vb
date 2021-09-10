Imports System.Data.SqlClient
Imports Dapper

Public Class AddAccountTransctionRepo
    Implements liveaccounttransctionInterface

    Private _db As IDbConnection

    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub

    Public Function InsertIntoLiveAccount(dblive As liveAccountClass) As Boolean Implements liveaccounttransctionInterface.InsertIntoLiveAccount
        Throw New NotImplementedException()
    End Function

    Public Function MadeAddAccountTransction(liveaccData As liveAccountClass, nominidata As NominiClass, prtypeData As productClass, opmode As accOperateClass, dltdata As dltClass) As Boolean Implements liveaccounttransctionInterface.MadeAddAccountTransction
        Dim parm As SqlParameter() = {
        New SqlParameter("@accountnumber", liveaccData.accountnumber),
        New SqlParameter("@name", liveaccData.n_ame),
        New SqlParameter("@prtype", liveaccData.producttype),
        New SqlParameter("@cif", liveaccData.cif),
        New SqlParameter("@actype", liveaccData.acctype),
        New SqlParameter("@nominireg", liveaccData.nominireg),
        New SqlParameter("@jointname", liveaccData.jointname),
        New SqlParameter("@guardianname", liveaccData.guardianname),
        New SqlParameter("@balance", liveaccData.balance),
        New SqlParameter("@status", liveaccData.status)
   }
        Dim parm2 As SqlParameter() = {
        New SqlParameter("@account", nominidata.accountnumber),
        New SqlParameter("@nominireg", nominidata.nominireg),
        New SqlParameter("@nomininame", nominidata.nomininame),
        New SqlParameter("@nominiage", nominidata.nominiage),
        New SqlParameter("@nominiaddress", nominidata.nominiaddress),
        New SqlParameter("@nominirelation", nominidata.nominirelation)
        }
        Dim parm3 As SqlParameter() = {
        New SqlParameter("@account", prtypeData.accountnumber),
        New SqlParameter("@type", prtypeData.type),
        New SqlParameter("@term", prtypeData.term),
        New SqlParameter("@val", prtypeData.v_alue)
        }
        Dim parm4 As SqlParameter() = {
        New SqlParameter("@account", opmode.accountnumber),
        New SqlParameter("@accountoperatemode", opmode.accountoperatemode),
        New SqlParameter("@guardianname", opmode.guardianname),
        New SqlParameter("@relation", opmode.relation)
        }
        Dim parm5 As SqlParameter() = {
        New SqlParameter("@account", dltdata.accountnumber),
        New SqlParameter("@acbalance", dltdata.accountbalance),
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
                    Dim query As String = "INSERT INTO liveaccount (accountnumber, cif, n_ame, producttype, nominireg, acctype, jointname, guardianname, balance, status) VALUES (@accountnumber, @cif, @name, @prtype, @nominireg, @actype, @jointname, @guardianname, @balance, @status)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1
                    '2
                    Dim query2 As String = "INSERT INTO nominiinfo (accountnumber, nominireg, nomininame, nominiage, noiminiaddress, nominirelation)VALUES (@account, @nominireg, @nomininame, @nominiage, @nominiaddress, @nominirelation)"
                    Dim args2 = New DynamicParameters()
                    For Each q As SqlParameter In parm2
                        args2.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query2, args2, transction)
                    '3.
                    Dim query3 As String = "INSERT INTO dbo.producttype (accountnumber, type, term, v_alue)VALUES (@account, @type, @term, @val)"
                    Dim args3 = New DynamicParameters()
                    For Each q As SqlParameter In parm3
                        args3.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query3, args3, transction)
                    '4.
                    Dim query4 As String = "INSERT INTO accountopratemode (accountnumber, accountoperatemode, guardianname, relation) VALUES (@account, @accountoperatemode, @guardianname, @relation)"
                    Dim args4 = New DynamicParameters()
                    For Each q As SqlParameter In parm4
                        args4.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query4, args4, transction)
                    '5.
                    Dim query5 As String = "insert into  dlt (accountnumber ,accountbalance,dlt,dlt2)values(@account,@acbalance,@dlt,@dlt2)"
                    Dim args5 = New DynamicParameters()
                    For Each q As SqlParameter In parm5
                        args5.Add(q.ParameterName, q.Value)
                    Next
                    _db.Execute(query5, args5, transction)
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
            '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class