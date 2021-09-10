Imports System.Data.SqlClient
Imports Dapper

Public Class newAccountRepo
    Implements newAccountInterface

    Private _db As SqlConnection

    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub

    Public Function getAll() As List(Of NewAccountClass) Implements newAccountInterface.getAll
        Return Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb").ToList
    End Function

    Public Function getByName(EnterName As String) As List(Of NewAccountClass) Implements newAccountInterface.getByName
        Return Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb where n_ame like '%' + @name + '%'", New With {Key .name = EnterName}).ToList
    End Function

    Public Function gteByCif(cif As String) As List(Of NewAccountClass) Implements newAccountInterface.gteByCif
        Return Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb where cif like '%' + @name + '%'", New With {Key .name = cif}).ToList
    End Function

    Public Function getByType(type As String) As List(Of NewAccountClass) Implements newAccountInterface.getByType
        Return Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb where producttype like '%' + @name + '%'", New With {Key .name = type}).ToList
    End Function

    Public Function gteByReffNo(ReffNo As String) As NewAccountClass Implements newAccountInterface.gteByReffNo
        Return Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb where reffno like '%' + @name + '%'", New With {Key .name = ReffNo}).FirstOrDefault
    End Function

    'Public Function AddData(data As NewAccountClass) As Boolean Implements newAccountInterface.AddData
    '    Dim parm As SqlParameter() = {
    '         New SqlParameter("@vrid", data.VirtualId),
    '         New SqlParameter("@cif", data.cif),
    '         New SqlParameter("@accountnumber", data.accountnumber),
    '         New SqlParameter("@name", data.n_ame),
    '         New SqlParameter("@prtype", data.producttype),
    '         New SqlParameter("@prterm", data.productterm),
    '         New SqlParameter("@prvalue", data.productvalue),
    '         New SqlParameter("@nominireg", data.nominireg),
    '         New SqlParameter("@nomininame", data.nomininame),
    '         New SqlParameter("@nominiage", data.nominiage),
    '         New SqlParameter("@nominiaddress", data.nominiaddress),
    '         New SqlParameter("@nominirelation", data.nominirelation),
    '         New SqlParameter("@acopmode", data.acoperatemode),
    '         New SqlParameter("@guardianname", data.guardianname),
    '         New SqlParameter("@jointname", data.jointname),
    '         New SqlParameter("@address", data.address),
    '         New SqlParameter("@mobile", data.mobile),
    '         New SqlParameter("@email", data.email),
    '         New SqlParameter("@dob", data.dob),
    '         New SqlParameter("@gender", data.gender),
    '         New SqlParameter("@adhar", data.adhar),
    '         New SqlParameter("@pan", data.pan),
    '         New SqlParameter("@photo", data.photo),
    '         New SqlParameter("@sign", data.sign),
    '         New SqlParameter("@doo", data.doo),
    '         New SqlParameter("@balance", data.balance),
    '         New SqlParameter("@reffno", data.reffno),
    '         New SqlParameter("@pr", data.pr),
    '         New SqlParameter("@trid", data.trid),
    '         New SqlParameter("@status", data.status)
    '    }
    '    Dim query As String = "INSERT INTO dbo.newacdb (VirtualId, cif, accountnumber, n_ame, producttype, productterm, productvalue, nominireg, nomininame, nominiage, nominiaddress, nominirelation, acoperatemode, guardianname, jointname, address, mobile, email, dob, gender, adhar, pan, photo, sign, doo, balance, reffno, pr, trid, status) VALUES (@vrid, @cif, @accountnumber, @name, @prtype, @prterm, @prvalue, @nominireg, @nomininame, @nominiage, @nominiaddress, @nominirelation, @acopmode, @guardianname, @jointname, @address, @mobile, @email, @dob,@gender, @adhar, @pan, @photo, @sign, @doo, @balance, @reffno, @pr, @trid, @status)"
    '    Dim args = New DynamicParameters()
    '    For Each p As SqlParameter In parm
    '        args.Add(p.ParameterName, p.Value)
    '    Next

    '    Try
    '        If _db.State() Then
    '        Else
    '            _db.Open()
    '        End If
    '        Using transction = _db.BeginTransaction()
    '            Try
    '                _db.Execute(query, args, transction) '1
    '                '2
    '                '.
    '                '.
    '                '.
    '                transction.Commit()
    '            Catch ex As Exception
    '                transction.Rollback()
    '            End Try

    '        End Using
    '        '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function IsReffNoExist(reffno As String) As Boolean Implements newAccountInterface.IsReffNoExist
        Dim x As Integer = Me._db.Query(Of NewAccountClass)("SELECT * FROM newacdb where reffno like '%' + @name + '%'", New With {Key .name = reffno}).Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function UpdateStatus(status As String, reffno As String) As Boolean Implements newAccountInterface.UpdateStatus
        Dim parm As SqlParameter() = {
         New SqlParameter("@reffno", reffno),
         New SqlParameter("@status", status)
        }
        Dim query As String = "" ' "update cifdb set cif=@cif,n_ame=@n_ame,mobile=@mobile,email=@email,pan=@pan,adhar=@adhar,photo=@photo,sign=@sign,address=@address,dob=@dob,gender=@gender,status=@status where cif = @cif"

        '  Dim query As String = " UPDATE Customer SET CompanyName = @CompanyName,Address = @Address, " + " City = @City,State = @State,IntroDate = @IntroDate,CreditLimit = @CreditLimit" + " WHERE CustomerID = @CustomerID"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Execute(query, args)
        Catch generatedExceptionName As Exception
            Return False
        End Try

        Return True
    End Function
End Class