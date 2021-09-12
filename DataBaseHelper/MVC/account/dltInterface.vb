Imports System.Data.SqlClient
Imports Dapper

Public Interface dltInterface

    Function getAll() As List(Of dltClass)

    Function getByAcc(acno As String) As dltClass
    Function IsAccountNumberExist(acno As String) As Boolean

    Function addDlt(data As dltClass) As Boolean

    Function UpdatDlt(data As dltClass) As Boolean

End Interface

Public Class dltRepo
    Implements dltInterface
    Private _db As IDbConnection

    Public Sub New(connection As String)
        _db = New SqlConnection(connection)
    End Sub

    Public Function getAll() As List(Of dltClass) Implements dltInterface.getAll
        Return Me._db.Query(Of dltClass)("SELECT * FROM dlt").ToList
    End Function

    Public Function getByAcc(acno As String) As dltClass Implements dltInterface.getByAcc
        Return Me._db.Query(Of dltClass)("SELECT * FROM dlt WHERE accountnumber = @accountnumber ", New With {Key .accountnumber = acno}).FirstOrDefault
    End Function

    Public Function addDlt(data As dltClass) As Boolean Implements dltInterface.addDlt
        Dim parm As SqlParameter() = {
        New SqlParameter("@balance", data.accountbalance),
        New SqlParameter("@acno", data.accountnumber),
        New SqlParameter("@dlt", data.dlt),
        New SqlParameter("@dlt2", data.dlt2)
                }
        Dim query As String = "INSERT INTO dlt (accountnumber, accountbalance, dlt, dlt2) VALUES (@acno, @balance, @dlt, @dlt2)"

        Dim args As DynamicParameters = New DynamicParameters
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next
        Try
            Me._db.Query(Of ClassPliIndex)(query, args).SingleOrDefault()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function UpdatDlt(data As dltClass) As Boolean Implements dltInterface.UpdatDlt
        Dim parm As SqlParameter() = {
        New SqlParameter("@balance", data.accountbalance),
        New SqlParameter("@acno", data.accountnumber),
        New SqlParameter("@dlt", data.dlt),
        New SqlParameter("@dlt2", data.dlt2)
                }
        Dim query As String = "UPDATE dlt SET accountbalance = @balance,dlt = @dlt,dlt2 = @dlt2 where accountnumber = @acno "

        Dim args As DynamicParameters = New DynamicParameters
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next
        Try
            Me._db.Query(Of ClassPliIndex)(query, args).SingleOrDefault()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function IsAccountNumberExist(acno As String) As Boolean Implements dltInterface.IsAccountNumberExist
        Dim x As Integer = Me._db.Query(Of dltClass)("SELECT * FROM dlt WHERE accountnumber = @accountnumber ", New With {Key .accountnumber = acno}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

Public Class dltService
    Private _repo As dltInterface

    Public Sub New(ByVal connectionString As String)
        _repo = New dltRepo(connectionString)
    End Sub

    Public Function GetAll() As List(Of dltClass)
        Return _repo.getAll()
    End Function

    Public Function GetByAcno(acno As String) As dltClass
        Return _repo.getByAcc(acno)
    End Function

    Public Function AddCustmor(data As dltClass) As Boolean
        Return _repo.addDlt(data)
    End Function

    Public Function Updatedlt(data As dltClass) As Boolean
        Return _repo.UpdatDlt(data)
    End Function
    Public Function IsDltExist(acno As String) As Boolean
        Return _repo.IsAccountNumberExist(acno)
    End Function
End Class