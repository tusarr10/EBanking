Imports System.Data.SqlClient
Imports Dapper

Public Class dacRepo
    Implements Idac
    Private _db As IDbConnection

    Public Sub New(ByVal ConnectionString As String)
        _db = New SqlConnection(ConnectionString) 'connectionstringaccount()
    End Sub
    Public Function SearchByDate(EnterDate As String) As dacClass Implements Idac.SearchByDate
        Return _db.Query(Of dacClass)("select * from dacdb where D_ate=@date", New With {Key .date = EnterDate}).FirstOrDefault
    End Function

    Public Function SearchAllByMonth(EnterMonth As String, EnterYear As String) As List(Of dacClass) Implements Idac.SearchAllByMonth
        Return _db.Query(Of dacClass)("select * from dacdb where D_ate like '%" & EnterYear & " " & EnterMonth & "%'").ToList
    End Function

    Public Function GetAll() As List(Of dacClass) Implements Idac.GetAll
        Return _db.Query(Of dacClass)("select * from dacdb").ToList
    End Function

    Public Function InsertData(data As dacClass) As Boolean Implements Idac.InsertData
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", data.D_ate),
        New SqlParameter("@obal", data.Open_bal),
         New SqlParameter("@cashrec", data.cashrec),
        New SqlParameter("@sbdep", data.Sbdep),
         New SqlParameter("@rddep", data.rddep),
        New SqlParameter("@rdfine", data.rdfine),
         New SqlParameter("@ssadep", data.ssadep),
        New SqlParameter("@ssafine", data.ssafine),
         New SqlParameter("@tddep", data.tddep),
        New SqlParameter("@rplidep", data.rplidep),
         New SqlParameter("@rplifine", data.rplifine),
        New SqlParameter("@rplitax", data.rplitax),
         New SqlParameter("@vpp", data.vpp),
        New SqlParameter("@othcol1", data.othcol1),
         New SqlParameter("@othcol2", data.othcol2),
        New SqlParameter("@totaldep", data.totaldep),
         New SqlParameter("@cashremet", data.cashremet),
        New SqlParameter("@sbwith", data.sbwith),
         New SqlParameter("@rdwith", data.rdwith),
        New SqlParameter("@ssawith", data.ssawith),
        New SqlParameter("@tdwith", data.tdwith),
         New SqlParameter("@rpliwith", data.rpliwith),
        New SqlParameter("@monwith", data.MONwith),
         New SqlParameter("@othwith", data.othwith),
        New SqlParameter("@totalwith", data.totalwith),
          New SqlParameter("@currency", data.curr_ency),
        New SqlParameter("@stamp1", data.stamp1),
         New SqlParameter("@stamp2", data.stamp2),
        New SqlParameter("@closebal", data.Closebal),
         New SqlParameter("@office", data.office),
        New SqlParameter("@user", data.u_ser),
        New SqlParameter("@time", data.ti_me),
        New SqlParameter("@status", data.status)
        }
        Dim query As String = "INSERT INTO dbo.dacdb (D_ate, Open_bal, cashrec, Sbdep, rddep, rdfine, ssadep, ssafine, tddep, rplidep, rplifine, rplitax, vpp, othcol1, othcol2, totaldep, cashremet, sbwith, rdwith, ssawith,tdwith, rpliwith, MONwith, othwith, totalwith, curr_ency, stamp1, stamp2, closebal, office, u_ser, ti_me, status) VALUES (@date, @obal, @cashrec , @sbdep, @rddep, @rdfine, @ssadep, @ssafine, @tddep, @rplidep, @rplifine, @rplitax, @vpp, @othcol1, @othcol2, @totaldep, @cashremet, @sbwith, @rdwith, @ssawith,@tdwith, @rpliwith, @monwith, @othwith, @totalwith, @currency, @stamp1, @stamp2, @closebal, @office, @user, @time, @status)"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of ClassCif)(query, args).SingleOrDefault()
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    Public Function updateData(data As dacClass) As Boolean Implements Idac.updateData
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", data.D_ate),
        New SqlParameter("@obal", data.Open_bal),
         New SqlParameter("@cashrec", data.cashrec),
        New SqlParameter("@sbdep", data.Sbdep),
         New SqlParameter("@rddep", data.rddep),
        New SqlParameter("@rdfine", data.rdfine),
         New SqlParameter("@ssadep", data.ssadep),
        New SqlParameter("@ssafine", data.ssafine),
         New SqlParameter("@tddep", data.tddep),
        New SqlParameter("@rplidep", data.rplidep),
         New SqlParameter("@rplifine", data.rplifine),
        New SqlParameter("@rplitax", data.rplitax),
         New SqlParameter("@vpp", data.vpp),
        New SqlParameter("@othcol1", data.othcol1),
         New SqlParameter("@othcol2", data.othcol2),
        New SqlParameter("@totaldep", data.totaldep),
         New SqlParameter("@cashremet", data.cashremet),
        New SqlParameter("@sbwith", data.sbwith),
         New SqlParameter("@rdwith", data.rdwith),
        New SqlParameter("@ssawith", data.ssawith),
        New SqlParameter("@tdwith", data.tdwith),
         New SqlParameter("@rpliwith", data.rpliwith),
        New SqlParameter("@monwith", data.MONwith),
         New SqlParameter("@othwith", data.othwith),
        New SqlParameter("@totalwith", data.totalwith),
          New SqlParameter("@currency", data.curr_ency),
        New SqlParameter("@stamp1", data.stamp1),
         New SqlParameter("@stamp2", data.stamp2),
        New SqlParameter("@closebal", data.Closebal),
         New SqlParameter("@office", data.office),
        New SqlParameter("@user", data.u_ser),
        New SqlParameter("@time", data.ti_me),
        New SqlParameter("@status", data.status)
        }
        Dim query As String = "update dacdb set Open_bal=@obal, cashrec=@cashrec , Sbdep=@sbdep, rddep=@rddep, rdfine= @rdfine, ssadep=@ssadep,ssafine= @ssafine, tddep=@tddep, rplidep=  @rplidep, rplifine=@rplifine, rplitax=@rplitax,vpp=@vpp,  othcol1=@othcol1, othcol2=@othcol2,  totaldep=@totaldep,  cashremet= @cashremet, sbwith= @sbwith, rdwith=@rdwith,  ssawith= @ssawith,tdwith=@tdwith,  rpliwith=@rpliwith,  MONwith=@monwith, othwith=@othwith,  totalwith=@totalwith, curr_ency=@currency,  stamp1=@stamp1,  stamp2=@stamp2,  closebal=@closebal, office=@office, u_ser=@user,  ti_me=@time,  status=@status where  D_ate=@date"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of ClassCif)(query, args).SingleOrDefault()
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function


    Public Function updateStatus(Data As dacClass) As Boolean Implements Idac.updateStatus
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", Data.D_ate),
        New SqlParameter("@status", Data.status)
        }
        Dim query As String = "update dacdb set status=@status where D_ate=@date "

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of ClassCif)(query, args).SingleOrDefault()
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    Public Function DeleteData(data As dacClass) As Boolean Implements Idac.DeleteData
        Dim parm As SqlParameter() = {
        New SqlParameter("@date", data.D_ate),
        New SqlParameter("@status", data.status)
        }
        Dim query As String = "delete dacdb where D_ate=@date "

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of ClassCif)(query, args).SingleOrDefault()
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    Public Function IsDataExist(data As dacClass) As Boolean Implements Idac.IsDataExist
        Dim x As Integer = _db.Query(Of dacClass)("select * from dacdb where D_ate=@date", New With {Key .date = data.D_ate}).ToList.Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
