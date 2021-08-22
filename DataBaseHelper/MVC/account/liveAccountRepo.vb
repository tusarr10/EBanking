Imports Dapper
Imports System.Data.SqlClient

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
        Throw New NotImplementedException()
    End Function

    Public Function getByAccountNumberFromNomini(AccountNumber As String) As NominiClass Implements liveAccountInterface.getByAccountNumberFromNomini
        Throw New NotImplementedException()
    End Function

    Public Function getByAccountNumberFromProd(AccountNUmber As String) As productClass Implements liveAccountInterface.getByAccountNumberFromProd
        Throw New NotImplementedException()
    End Function

    Public Function gteByCif(cif As String) As List(Of liveAccountClass) Implements liveAccountInterface.gteByCif
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where cif =@cif", New With {Key .cif = cif}).ToList
    End Function

    Public Function getByType(type As String) As List(Of liveAccountClass) Implements liveAccountInterface.getByType
        Return Me._db.Query(Of liveAccountClass)("SELECT * FROM liveaccount where producttype =type", New With {Key .type = type}).ToList
    End Function
End Class
