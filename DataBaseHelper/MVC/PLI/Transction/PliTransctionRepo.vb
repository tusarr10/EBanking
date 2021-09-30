Imports System.Data.SqlClient
Imports Dapper

Public Class PliTransctionRepo
    Implements IPliTransction

    Private _db As IDbConnection

    Public Sub New(ByVal connectionString As String)
        _db = New SqlConnection(connectionString)
    End Sub

    Public Function AddTransaction(transction As classPliTransction) As Boolean Implements IPliTransction.AddTransaction
        Dim parm As SqlParameter() = {
        New SqlParameter("@id", transction.id),
        New SqlParameter("@policyno", transction.policyNo),
        New SqlParameter("@proposalno", transction.proposalno),
        New SqlParameter("@amount", transction.amount),
        New SqlParameter("@month", transction.month),
        New SqlParameter("@date", transction.dat_e),
        New SqlParameter("@name", transction.name),
        New SqlParameter("@recno", transction.recno),
        New SqlParameter("@gst", transction.gst),
        New SqlParameter("@totalrec", transction.totalrec),
        New SqlParameter("@type", transction.type)
        }
        Dim query As String = "INSERT INTO pli_transction (id, policyNo, proposalno, amount, month, dat_e, name, recno, gst, totalrec, type) VALUES (@id, @policyno, @proposalno,@amount , @month, @date, @name, @recno, @gst, @totalrec, @type)"

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

    Public Function DeleteTransaction(trid As String) As Boolean Implements IPliTransction.DeleteTransaction
        Throw New NotImplementedException()
    End Function

    Public Function FindByProposalNo(proposal As String) As List(Of classPliTransction) Implements IPliTransction.FindByProposalNo
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As List(Of classPliTransction) Implements IPliTransction.GetAll
        Return Me._db.Query(Of classPliTransction)("select * from pli_transction")
    End Function

    Public Function IstransctionExist(trid As String) As Boolean Implements IPliTransction.IstransctionExist
        Dim x = Me._db.Query(Of classPliTransction)("select * from pli_transction where recno='" & trid & "'").ToList().Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsPolicyExist(num As String) As Boolean Implements IPliTransction.IsPolicyExist
        Dim x = Me._db.Query(Of classPliTransction)("select * from pli_transction where policyNo='" & num & "'").ToList().Count
        If x > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FindByPolicyNum(policyNum As String) As classPliTransction Implements IPliTransction.FindByPolicyNum
        Return Me._db.Query(Of classPliTransction)("select * from pli_transction where policyNo=@pno", New With {Key .pno = policyNum}).FirstOrDefault
    End Function
End Class