Imports Dapper
Imports System.Data.SqlClient

Public Interface newAccountInterface
    Function getAll() As List(Of NewAccountClass)
    Function getByName(EnterName As String) As List(Of NewAccountClass)
    Function gteByCif(cif As String) As List(Of NewAccountClass)
    Function getByType(type As String) As List(Of NewAccountClass)
    Function gteByReffNo(ReffNo As String) As NewAccountClass

    'add data by transction ok
    Function AddData(data As NewAccountClass) As Boolean

End Interface

Public Class newAccountRepo
    Implements newAccountInterface

    Private _db As IDbConnection

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

    Public Function AddData(data As NewAccountClass) As Boolean Implements newAccountInterface.AddData
        Throw New NotImplementedException()
    End Function
End Class
Public Class newAccountService

End Class