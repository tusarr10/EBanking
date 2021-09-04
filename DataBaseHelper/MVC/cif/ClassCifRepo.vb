Imports System.Data.SqlClient
Imports Dapper

Public Class ClassCifRepo
    Implements ICif

    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString) 'connectionstringaccount()
    End Sub

    Public Function AddCif(custmor As ClassCif) As Boolean Implements ICif.AddCif
        Dim parm As SqlParameter() = {
            New SqlParameter("@cif", custmor.cif),
            New SqlParameter("@n_ame", custmor.n_ame),
            New SqlParameter("@mobile", custmor.mobile),
            New SqlParameter("@email", custmor.email),
            New SqlParameter("@pan", custmor.pan),
            New SqlParameter("@adhar", custmor.adhar),
            New SqlParameter("@photo", custmor.photo),
            New SqlParameter("@sign", custmor.sign),
            New SqlParameter("@address", custmor.address),
            New SqlParameter("@dob", custmor.dob),
            New SqlParameter("@gender", custmor.gender),
            New SqlParameter("@status", custmor.status)}
        Dim query As String = "insert into cifdb(cif,n_ame,mobile,email,pan,adhar,photo,sign,address,dob,gender,status)values(@cif,@n_ame,@mobile,@email,@pan,@adhar,@photo,@sign,@address,@dob,@gender,@status)"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of ClassCif)(query, args).SingleOrDefault()
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try

    End Function

    Public Function DeleteCif(cif As String) As Boolean Implements ICif.DeleteCif
        Dim deleteciff As Integer = Me._db.Execute("DELETE FROM cifDB WHERE cif=@cif", New With {Key .cif = cif})
        Return deleteciff > 0
    End Function

    Public Function FindById(cif As String) As ClassCif Implements ICif.FindById
        Return Me._db.Query(Of ClassCif)("select * from cifdb where cif=@cif", New With {Key .cif = cif}).FirstOrDefault()
    End Function

    Public Function IsCifExist(cif As String) As Boolean Implements ICif.IsCifExist
        Dim x = Me._db.Query(Of ClassCif)("Select * from cifdb where cif=@cif", New With {Key .cif = cif}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetAll() As IList(Of ClassCif) Implements ICif.GetAll
        Return Me._db.Query(Of ClassCif)("SELECT * From cifdb").ToList()
    End Function

    Public Function UpdateCif(custmor As ClassCif) As Boolean Implements ICif.UpdateCif
        Dim parm As SqlParameter() = {
            New SqlParameter("@cif", custmor.cif),
            New SqlParameter("@n_ame", custmor.n_ame),
            New SqlParameter("@mobile", custmor.mobile),
            New SqlParameter("@email", custmor.email),
            New SqlParameter("@pan", custmor.pan),
            New SqlParameter("@adhar", custmor.adhar),
            New SqlParameter("@photo", custmor.photo),
            New SqlParameter("@sign", custmor.sign),
            New SqlParameter("@address", custmor.address),
            New SqlParameter("@dob", custmor.dob),
            New SqlParameter("@gender", custmor.gender),
            New SqlParameter("@status", custmor.status)}
        Dim query As String = "update cifdb set cif=@cif,n_ame=@n_ame,mobile=@mobile,email=@email,pan=@pan,adhar=@adhar,photo=@photo,sign=@sign,address=@address,dob=@dob,gender=@gender,status=@status where cif = @cif"

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

    Public Function UpdateStatus(status As String, id As String) As Boolean Implements ICif.UpdateStatus
        Dim parm As SqlParameter() = {
            New SqlParameter("@cif", id),
            New SqlParameter("@status", status)
            }
        Dim query As String = "update cifdb set status=@status where cif = @cif"

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