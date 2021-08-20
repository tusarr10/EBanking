Imports System.Data.SqlClient
Imports Dapper

Public Class PliIndexRepo
    Implements IPliIndex

    Private _db As IDbConnection

    Public Sub New(ByVal connectionString As String)
        _db = New SqlConnection(connectionString)

    End Sub

    Public Function AddCustmor(custmor As ClassPliIndex) As Boolean Implements IPliIndex.AddCustmor
        Dim parm As SqlParameter() = {
        New SqlParameter("@id", custmor.id),
        New SqlParameter("@agentid", custmor.agentId),
        New SqlParameter("@boid", custmor.boid),
        New SqlParameter("@recdate", custmor.RecDate),
        New SqlParameter("@agentsa", custmor.agentSA),
        New SqlParameter("@agentprem", custmor.agentPremium),
        New SqlParameter("@agentmobile", custmor.AgentMobile),
        New SqlParameter("@custname", custmor.CustName),
        New SqlParameter("@custdob", custmor.custmordob),
        New SqlParameter("@custmobile", custmor.custmobile),
        New SqlParameter("@custnotes", custmor.custmornotes),
        New SqlParameter("@custaddress", custmor.custaddress),
        New SqlParameter("@proposaldate", custmor.proposaldate),
        New SqlParameter("@proposaltype", custmor.proposaltype),
        New SqlParameter("@proposalcat", custmor.productcat),
        New SqlParameter("@prefrq", custmor.prefrq),
        New SqlParameter("@matage", custmor.matage),
        New SqlParameter("@proposalno", custmor.proposalno),
        New SqlParameter("@recno", custmor.recno),
        New SqlParameter("@sa", custmor.sa),
        New SqlParameter("@premium", custmor.premium),
        New SqlParameter("@indexbo", custmor.indexbo),
        New SqlParameter("@userid", custmor.userid)
                } '23 parm
        Dim query As String = "INSERT INTO dbo.Pli_Indexing (id, agentId, boid, RecDate, agentSA, agentPremium, AgentMobile, CustName, custmordob, custmobile, custmornotes, custaddress, proposaldate, proposaltype, productcat, prefrq, matage, proposalno, recno, sa, premium, indexbo, userid)
  VALUES (@id, @agentid, @boid, @recdate, @agentsa, @agentprem, @agentmobile, @custname, @custdob, @custmobile, @custnotes, @custaddress, @proposaldate, @proposaltype, @proposalcat, @prefrq, @matage, @proposalno, @recno, @sa, @premium, @indexbo, @userid)"

        Dim args As DynamicParameters = New DynamicParameters
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next
        Try
            Me._db.Query(Of ClassPliIndex)(query, args).SingleOrDefault()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function DeleteCustmor(pno As String) As Boolean Implements IPliIndex.DeleteCustmor
        Dim deletedCustomer As Integer = Me._db.Execute("DELETE FROM Pli_Indexing WHERE proposalno = @Id", New With {
       Key .Id = pno
   })
        Return deletedCustomer > 0
    End Function

    Public Function FindById(id As String) As ClassPliIndex Implements IPliIndex.FindById
        Return Me._db.Query(Of ClassPliIndex)("select * from Pli_Indexing where proposalno=@pno", New With {Key .pno = id}).FirstOrDefault

    End Function

    Public Function FindByIdNo(id As String) As ClassPliIndex Implements IPliIndex.FindByIdNo
        Return Me._db.Query(Of ClassPliIndex)("select * from Pli_Indexing where id=@pno", New With {Key .pno = id}).FirstOrDefault

    End Function

    Public Function IsProposalExist(Proposal As String) As Boolean Implements IPliIndex.IsProposalExist
        Dim x = Me._db.Query(Of ClassPliIndex)("select * from Pli_Indexing where proposalno='" & Proposal & "'").ToList().Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetAll() As List(Of ClassPliIndex) Implements IPliIndex.GetAll
        Return Me._db.Query(Of ClassPliIndex)("SELECT * FROM Pli_Indexing").ToList()
    End Function

    Public Function GetByName(Name As String) As List(Of ClassPliIndex) Implements IPliIndex.GetByName
        Return Me._db.Query(Of ClassPliIndex)("select * from Pli_Indexing where CustName like '%" & Name & "%'").ToList()
    End Function

    Public Function UpdateCustmor(custmor As ClassPliIndex) As Boolean Implements IPliIndex.UpdateCustmor
        Dim parm As SqlParameter() = {
       New SqlParameter("@id", custmor.id),
       New SqlParameter("@agentid", custmor.agentId),
       New SqlParameter("@boid", custmor.boid),
       New SqlParameter("@recdate", custmor.RecDate),
       New SqlParameter("@agentsa", custmor.agentSA),
       New SqlParameter("@agentprem", custmor.agentPremium),
       New SqlParameter("@agentmobile", custmor.AgentMobile),
       New SqlParameter("@custname", custmor.CustName),
       New SqlParameter("@custdob", custmor.custmordob),
       New SqlParameter("@custmobile", custmor.custmobile),
       New SqlParameter("@custnotes", custmor.custmornotes),
       New SqlParameter("@custaddress", custmor.custaddress),
       New SqlParameter("@proposaldate", custmor.proposaldate),
       New SqlParameter("@proposaltype", custmor.proposaltype),
       New SqlParameter("@proposalcat", custmor.productcat),
       New SqlParameter("@prefrq", custmor.prefrq),
       New SqlParameter("@matage", custmor.matage),
       New SqlParameter("@proposalno", custmor.proposalno),
       New SqlParameter("@recno", custmor.recno),
       New SqlParameter("@sa", custmor.sa),
       New SqlParameter("@premium", custmor.premium),
       New SqlParameter("@indexbo", custmor.indexbo),
       New SqlParameter("@userid", custmor.userid)
               } '23 parm
        '  Dim query As String = "INSERT INTO dbo.Pli_Indexing (id, agentId, boid, RecDate, agentSA, agentPremium, AgentMobile, CustName, custmordob, custmobile, custmornotes, custaddress, proposaldate, proposaltype, productcat, prefrq, matage, proposalno, recno, sa, premium, indexbo, userid)
        '        VALUES (@id, @agentid, @boid, @recdate, @agentsa, @agentprem, @agentmobile, @custname, @custdob, @custmobile, @custnotes, @custaddress, @proposaldate, @proposaltype, @proposalcat, @prefrq, @matage, @proposalno, @recno, @sa, @premium, @indexbo, @userid)"
        Dim query As String = "UPDATE dbo.Pli_Indexing SET agentId = @agentid,boid = @boid,RecDate = @recdate,agentSA = @agentsa,agentPremium = @agentprem,AgentMobile = @agentmobile,CustName = @custname,custmordob = @custdob,custmobile = @custmobile,custmornotes = @custnotes,custaddress = @custaddress,proposaldate = @proposaldate,proposaltype = @proposaltype,productcat = @proposalcat,prefrq = @prefrq,matage = @matage,proposalno =  @proposalno,recno = @recno,sa = @sa,premium = @premium,indexbo = @indexbo,userid = @userid WHERE id=@id"

        Dim args As DynamicParameters = New DynamicParameters
        For Each p As SqlParameter In parm
            args.Add(p.ParameterName, p.Value)
        Next
        Try
            Me._db.Query(Of ClassPliIndex)(query, args).SingleOrDefault()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class