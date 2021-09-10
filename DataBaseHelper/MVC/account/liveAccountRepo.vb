Imports System.Data.SqlClient
Imports Dapper

Public Class liveAccountRepo
    Implements liveAccountInterface

    Private _db As IDbConnection

    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub

    Public Function getAll() As List(Of liveAccountClass) Implements liveAccountInterface.getAll
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount").ToList
    End Function

    Public Function getByName(EnterName As String) As List(Of liveAccountClass) Implements liveAccountInterface.getByName
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where n_ame like '%' + @name + '%'", New With {Key .name = EnterName}).ToList

    End Function

    Public Function getByAccountNumber(AccountNumber As String) As liveAccountClass Implements liveAccountInterface.getByAccountNumber
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where accountnumber = @accountnumber ", New With {Key .accountnumber = AccountNumber}).FirstOrDefault
    End Function

    Public Function getByAccountNumberFromOPMode(AccountNumber As String) As accOperateClass Implements liveAccountInterface.getByAccountNumberFromOPMode
        Return Me._db.Query(Of accOperateClass)("SELECT * FROM accountopratemode WHERE accountnumber=@accountnumber", New With {Key .accountnumber = AccountNumber}).FirstOrDefault
    End Function

    Public Function getByAccountNumberFromNomini(AccountNumber As String) As NominiClass Implements liveAccountInterface.getByAccountNumberFromNomini
        Return Me._db.Query(Of NominiClass)("SELECT * FROM nominiinfo WHERE accountnumber=@accountnumber", New With {Key .accountnumber = AccountNumber}).FirstOrDefault
    End Function

    Public Function getByAccountNumberFromProd(AccountNUmber As String) As productClass Implements liveAccountInterface.getByAccountNumberFromProd
        Return Me._db.Query(Of productClass)("SELECT * FROM producttype WHERE accountnumber=@accountnumber", New With {Key .accountnumber = AccountNUmber}).FirstOrDefault
    End Function

    Public Function gteByCif(cif As String) As List(Of liveAccountClass) Implements liveAccountInterface.gteByCif
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where cif =@cif", New With {Key .cif = cif}).ToList
    End Function

    Public Function getByType(type As String) As List(Of liveAccountClass) Implements liveAccountInterface.getByType
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where producttype =type", New With {Key .type = type}).ToList
    End Function

    Public Function IsAccountNumberExist(AccountNumber As String) As Boolean Implements liveAccountInterface.IsAccountNumberExist
        Dim x As Integer = Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where accountnumber = @accountnumber ", New With {Key .accountnumber = AccountNumber}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function UpdateAccountStatus(AccountNumber As String, Status As String) As Boolean Implements liveAccountInterface.UpdateAccountStatus
        Dim parm As SqlParameter() = {
         New SqlParameter("@accountnumber", AccountNumber),
         New SqlParameter("@status", Status)}
        Dim query As String = "update liveaccount set status=@status where accountnumber=@accountnumber"
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
