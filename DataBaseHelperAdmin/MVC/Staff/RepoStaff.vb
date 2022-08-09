Imports System.Data
Imports System.Data.SqlClient

Public Class RepoStaff
    Implements Istaff

    Private _db As IDbConnection
    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub

    Public Function GetAll() As IList(Of ClassStaff) Implements Istaff.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function findByOfficeId(office As String) As List(Of ClassStaff) Implements Istaff.findByOfficeId
        Throw New NotImplementedException()
    End Function

    Public Function IsofficExist(staff As String) As Boolean Implements Istaff.IsofficExist
        Throw New NotImplementedException()
    End Function

    Public Function Addstaff(custmor As ClassStaff) As Boolean Implements Istaff.Addstaff
        Throw New NotImplementedException()
    End Function

    Public Function Updatestaff(custmor As ClassStaff) As Boolean Implements Istaff.Updatestaff
        Throw New NotImplementedException()
    End Function

    Public Function UpdateStatus(status As String, id As String) As Boolean Implements Istaff.UpdateStatus
        Throw New NotImplementedException()
    End Function

    Public Function Deletestaff(staff As String) As Boolean Implements Istaff.Deletestaff
        Throw New NotImplementedException()
    End Function
End Class
