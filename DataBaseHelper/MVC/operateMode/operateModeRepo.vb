Imports System.Data.SqlClient
Imports Dapper

Public Class operateModeRepo
    Implements IOperateMode

    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub
    Public Function AddOperateModeData(data As ClassOperateMode) As Boolean Implements IOperateMode.AddOperateModeData

    End Function

    Public Function DeleteData(AccountNumber As String) As Boolean Implements IOperateMode.DeleteData

    End Function

    Public Function FindAllByAccountNumber() As IList(Of ClassOperateMode) Implements IOperateMode.FindAllByAccountNumber

    End Function

    Public Function FindByAccountNumber(AccountNumber As String) As ClassOperateMode Implements IOperateMode.FindByAccountNumber

    End Function

    Public Function getAll() As IList(Of ClassOperateMode) Implements IOperateMode.getAll

    End Function

    Public Function UpdateoperateModeDate(data As ClassOperateMode) As Boolean Implements IOperateMode.UpdateoperateModeDate
        Throw New NotImplementedException()
    End Function
End Class
