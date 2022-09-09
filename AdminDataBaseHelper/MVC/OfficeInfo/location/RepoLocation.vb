Imports System.Data.SqlClient
Imports Dapper

Public Class RepoLocation
    Implements ILocation
    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString)
    End Sub

    Public Function AddData(Data As ClsLocation) As Boolean Implements ILocation.AddData
        Dim parm As SqlParameter() = {
        New SqlParameter("@OfficeId", Data.OfficeId),
        New SqlParameter("@Districts", Data.Districts),
        New SqlParameter("@SubDiv", Data.SubDiv),
        New SqlParameter("@Block", Data.Block),
        New SqlParameter("@Panchyat", Data.Panchyat),
        New SqlParameter("@NoVillege", Data.NoVillege),
        New SqlParameter("@ApproxPopulation", Data.ApproxPopulation),
        New SqlParameter("@Loong", Data.Loong),
        New SqlParameter("@Latt", Data.latt)
   }


        Try
            If _db.State() Then
            Else
                _db.Open()
            End If
            Using transction = _db.BeginTransaction()
                Try
                    Dim query As String = "INSERT INTO OfficeLocation (OfficeId, Districts,SubDiv,Block,Panchyat,Novillege,ApproxPopulation,Loong,Latt) VALUES (@OfficeId, @Districts, @SubDiv, @Block, @Panchyat, @NoVillege, @ApproxPopulation, @Loong, @Latt)"
                    Dim args = New DynamicParameters()
                    For Each p As SqlParameter In parm
                        args.Add(p.ParameterName, p.Value)
                    Next
                    _db.Execute(query, args, transction) '1

                    '6.
                    '.
                    '.

                    transction.Commit()
                    Return True
                Catch ex As Exception
                    transction.Rollback()
                    Return False
                End Try

            End Using
            '  Me._db.Query(Of allJournalClass)(query, args).SingleOrDefault
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllData() As List(Of ClsLocation) Implements ILocation.GetAllData
        Return Me._db.Query(Of ClsLocation)("SELECT * FROM OfficeLocation").ToList()
    End Function

    Public Function GetDataById(OfficeId As String) As ClsLocation Implements ILocation.GetDataById
        Return Me._db.Query(Of ClsLocation)("SELECT * FROM OfficeLocation where OfficeId=@officeCode", New With {Key .officeCode = OfficeId}).FirstOrDefault

    End Function

    Public Function updateData(data As ClsLocation) As Boolean Implements ILocation.updateData
        Throw New NotImplementedException()
    End Function

    Public Function deleteData(OfficeId As String) As Boolean Implements ILocation.deleteData
        Throw New NotImplementedException()
    End Function

    Public Function IsDataExist(OfficeId As String) As Boolean Implements ILocation.IsDataExist
        Dim x = Me._db.Query(Of clsoffice)("SELECT * FROM OfficeDetails WHERE officeId =@officecode", New With {Key .officecode = OfficeId}).ToList().Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
