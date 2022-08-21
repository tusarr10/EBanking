Imports System.Data
Imports System.Data.SqlClient

Public Class Repooffice
    Implements Ioffice

    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub

    Public Function GetAll() As IList(Of clsoffice) Implements Ioffice.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function FindByOfficeCode(OfficeCode As String) As clsoffice Implements Ioffice.FindByOfficeCode
        Throw New NotImplementedException()
    End Function

    Public Function IsOfficecodeExist() As Boolean Implements Ioffice.IsOfficecodeExist
        Throw New NotImplementedException()
    End Function

    Public Function AddOffice(officeData As clsoffice) As Boolean Implements Ioffice.AddOffice
        Throw New NotImplementedException()
    End Function

    Public Function UpdateOffice(office As clsoffice) As Boolean Implements Ioffice.UpdateOffice
        Throw New NotImplementedException()
    End Function

    Public Function DeleteOffice(officeCode As String) As Boolean Implements Ioffice.DeleteOffice
        Throw New NotImplementedException()
    End Function
End Class
