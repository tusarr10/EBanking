Imports System.Data
Imports System.Data.SqlClient
Imports Dapper


Public Class RepoVillege
    Implements Ivillege

    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString) 'connectionstringaccount()
    End Sub


    Public Function GetAll() As IList(Of clsvillege) Implements Ivillege.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function FindByOfficeCode(code As String) As IList(Of clsvillege) Implements Ivillege.FindByOfficeCode
        Throw New NotImplementedException()
    End Function

    Public Function FindBy5star(code As String) As IList(Of clsvillege) Implements Ivillege.FindBy5star
        Throw New NotImplementedException()
    End Function

    Public Function FindByssg(code As String) As IList(Of clsvillege) Implements Ivillege.FindByssg
        Throw New NotImplementedException()
    End Function

    Public Function FindByssb(code As String) As IList(Of clsvillege) Implements Ivillege.FindByssb
        Throw New NotImplementedException()
    End Function

    Public Function Addvillege(custmor As clsvillege) As Boolean Implements Ivillege.Addvillege
        Throw New NotImplementedException()
    End Function

    Public Function Updatevillege(custmor As clsvillege) As Boolean Implements Ivillege.Updatevillege
        Throw New NotImplementedException()
    End Function

    Public Function Deletevillege(custmor As clsvillege) As Boolean Implements Ivillege.Deletevillege
        Throw New NotImplementedException()
    End Function
End Class
