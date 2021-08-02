Imports System.Data.SqlClient
Imports Dapper
Imports TWEB

Public Class PliIndexRepo
    Implements IPliIndex

    Private _db As IDbConnection

    Public Sub New()
        _db = New SqlConnection(connectionstringRpli())

    End Sub
    Public Function AddCustmor(custmor As ClassPliIndex) As Boolean Implements IPliIndex.AddCustmor
        Throw New NotImplementedException()
    End Function

    Public Function DeleteCustmor(pno As String) As Boolean Implements IPliIndex.DeleteCustmor
        Throw New NotImplementedException()
    End Function

    Public Function FindById(id As String) As ClassPliIndex Implements IPliIndex.FindById
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of ClassPliIndex) Implements IPliIndex.GetAll
        Return Me._db.Query(Of ClassPliIndex)("SELECT * FROM Pli_Indexing").ToList()
    End Function

    Public Function GetByName() As List(Of ClassPliIndex) Implements IPliIndex.GetByName
        Throw New NotImplementedException()
    End Function

    Public Function UpdateCustmor(custmor As ClassPliIndex) As Boolean Implements IPliIndex.UpdateCustmor
        Throw New NotImplementedException()
    End Function
End Class
