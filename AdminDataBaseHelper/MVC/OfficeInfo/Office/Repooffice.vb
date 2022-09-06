Imports System.Data
Imports System.Data.SqlClient
Imports Dapper


Public Class Repooffice
    Implements Ioffice

    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub

    Public Function GetAll() As IList(Of clsoffice) Implements Ioffice.GetAll
        Return Me._db.Query(Of clsoffice)("SELECT * FROM OfficeDetails").ToList()
    End Function

    Public Function FindByOfficeCode(OfficeCode As String) As clsoffice Implements Ioffice.FindByOfficeCode
        Return Me._db.Query(Of clsoffice)("SELECT * FROM OfficeDetails WHERE officeId =@officecode", New With {Key .officecode = OfficeCode}).FirstOrDefault
    End Function

    'Public Function IsOfficecodeExist(officecode As String) As Boolean Implements Ioffice.IsOfficecodeExist
    '    Throw New NotImplementedException()
    'End Function

    Public Function IsOfficecodeExist(officeCode As String) As Boolean Implements Ioffice.IsOfficecodeExist
        Dim x = Me._db.Query(Of clsoffice)("SELECT * FROM OfficeDetails WHERE officeId =@officecode", New With {Key .officecode = officeCode}).ToList().Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
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

    Public Function FindBySubdivision(SD As String) As List(Of clsoffice) Implements Ioffice.FindBySubdivision
        Throw New NotImplementedException()
    End Function
End Class
