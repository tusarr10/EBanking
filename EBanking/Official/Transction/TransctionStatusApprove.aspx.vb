Imports System.Data.SqlClient
Imports DataBaseHelper

Public Class TransctionStatusApprove
    Inherits System.Web.UI.Page

    ' all Variable Declare
    Dim cs As String = connectionhelper.connectionstringaccount()

    Private dataservice As New AllJournalService(connectionstringaccount)
    Private dltservice As New dltService(connectionstringaccount)
    Private TransctionService As New AllJournalService(connectionstringaccount)
    Dim sbdata As sbJournalClass
    Dim rddata As rdJournalClass
    Dim ssadata As ssaJournalClass
    Dim dltdata As dltClass

    Dim dlt1 As String = Nothing
    Dim dlt2 As String = Nothing
    Dim updatedlt As String
    Dim updatedlt2 As String

    Dim bat As String

    Dim accountNumber As String
    Dim TrId As String
    Dim type As String
    Dim trdate As String
    Dim status As String
    Dim amount As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Request.QueryString("value") IsNot Nothing Then
                accountNumber = Request.QueryString("value").ToString
                TrId = Request.QueryString("value3").ToString
                type = Request.QueryString("value2").ToString
                trdate = Request.QueryString("value4").ToString
                amount = Request.QueryString("value5").ToString
                status = Request.QueryString("status").ToString
                ' btnFindAccountClick()
                fireQuery(type, trdate, accountNumber, TrId, status, amount)
            Else
                MyMessageBox.Show(Me, "Data Tempering : No Parameter Found..")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fireQuery(type As String, trdate As String, accountNumber As String, trId As String, status As String, amount As String)
        If type = "Saving" Then
            sbdata = dataservice.getBydataFromSb(trdate, accountNumber, trId, status)
            getInfosb(sbdata)

        ElseIf type = "RD" Then
            rddata = dataservice.getBydataFromrd(trdate, accountNumber, trId, status)
            getInford(rddata)
        ElseIf type = "SSA" Then
            ssadata = dataservice.getBydataFromssa(trdate, accountNumber, trId, status)
            getInfossa(ssadata)
        Else
            tbacno.Text = "Can`not Find Product Type ..."
            Exit Sub

        End If

    End Sub

    Sub getInfosb(ByVal data As sbJournalClass)

        If data.accountnumber IsNot Nothing Or data.accountnumber IsNot "" Then
            tbacno.Text = data.accountnumber
        Else
            tbacno.Text = "ERROR"

        End If
        If data.trid IsNot Nothing Then
            tbtrid.Text = data.trid
        Else
            tbtrid.Text = "Error"
        End If

        If data.status IsNot Nothing Then
            tbstatus.Text = data.status
        Else
            tbstatus.Text = "ERROR"

        End If
        If data.da_te IsNot Nothing Then
            tbDate.Text = data.da_te
        Else
            tbDate.Text = "Error"
        End If
        If type IsNot Nothing Then
            tbactype.Text = type
        Else
            tbactype.Text = "Error"
        End If

        If data.bbt IsNot Nothing Then
            tbbbt.Text = data.bbt
        Else
            tbbbt.Text = "ERROR"

        End If
        If data.Details IsNot Nothing Then
            detailstb.Text = data.Details
        Else
            detailstb.Text = "ERROR"

        End If
        If data.amount IsNot Nothing Then
            tbAmount.Text = data.amount
        Else
            tbAmount.Text = "Error"
        End If

        If data.bat IsNot Nothing Then
            tbbat.Text = data.bat
            bat = data.bat
        Else
            tbbat.Text = "ERROR"

        End If
        If data.transctiontype IsNot Nothing Then
            tbtrtype.Text = data.transctiontype
        Else
            tbtrtype.Text = "Error"
        End If
        If data.depositername IsNot Nothing Then
            tbname.Text = data.depositername
        Else tbname.Text = "Error"
        End If

    End Sub

    Sub getInford(ByVal data As rdJournalClass)

        If data.accountnumber IsNot Nothing Or data.accountnumber IsNot "" Then
            tbacno.Text = data.accountnumber
        Else
            tbacno.Text = "ERROR"

        End If
        If data.trid IsNot Nothing Then
            tbtrid.Text = data.trid
        Else
            tbtrid.Text = "Error"
        End If

        If data.status IsNot Nothing Then
            tbstatus.Text = data.status
        Else
            tbstatus.Text = "ERROR"

        End If
        If data.da_te IsNot Nothing Then
            tbDate.Text = data.da_te
        Else
            tbDate.Text = "Error"
        End If
        If type IsNot Nothing Then
            tbactype.Text = type
        Else
            tbactype.Text = "Error"
        End If

        If data.bbt IsNot Nothing Then
            tbbbt.Text = data.bbt
        Else
            tbbbt.Text = "ERROR"

        End If
        If data.Details IsNot Nothing Then
            detailstb.Text = data.Details
        Else
            detailstb.Text = "ERROR"

        End If
        If data.amount IsNot Nothing Then
            tbAmount.Text = data.amount
        Else
            tbAmount.Text = "Error"
        End If

        If data.bat IsNot Nothing Then
            tbbat.Text = data.bat
            bat = data.bat
        Else
            tbbat.Text = "ERROR"

        End If
        If data.transctiontype IsNot Nothing Then
            tbtrtype.Text = data.transctiontype
        Else
            tbtrtype.Text = "Error"
        End If
        If data.depositername IsNot Nothing Then
            tbname.Text = data.depositername
        Else tbname.Text = "Error"
        End If

    End Sub

    Sub getInfossa(ByVal data As ssaJournalClass)

        If data.accountnumber IsNot Nothing Or data.accountnumber IsNot "" Then
            tbacno.Text = data.accountnumber
        Else
            tbacno.Text = "ERROR"

        End If
        If data.trid IsNot Nothing Then
            tbtrid.Text = data.trid
        Else
            tbtrid.Text = "Error"
        End If

        If data.status IsNot Nothing Then
            tbstatus.Text = data.status
        Else
            tbstatus.Text = "ERROR"

        End If
        If data.da_te IsNot Nothing Then
            tbDate.Text = data.da_te
        Else
            tbDate.Text = "Error"
        End If
        If type IsNot Nothing Then
            tbactype.Text = type
        Else
            tbactype.Text = "Error"
        End If

        If data.bbt IsNot Nothing Then
            tbbbt.Text = data.bbt
        Else
            tbbbt.Text = "ERROR"

        End If
        If data.Details IsNot Nothing Then
            detailstb.Text = data.Details
        Else
            detailstb.Text = "ERROR"

        End If
        If data.amount IsNot Nothing Then
            tbAmount.Text = data.amount
        Else
            tbAmount.Text = "Error"
        End If

        If data.bat IsNot Nothing Then
            tbbat.Text = data.bat
            bat = data.bat
        Else
            tbbat.Text = "ERROR"

        End If
        If data.transctiontype IsNot Nothing Then
            tbtrtype.Text = data.transctiontype
        Else
            tbtrtype.Text = "Error"
        End If
        If data.depositername IsNot Nothing Then
            tbname.Text = data.depositername
        Else tbname.Text = "Error"
        End If

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub DoSBTransction()
        Dim bal As String = Nothing
        If bat = tbbat.Text.Trim Then
            bal = tbbat.Text.Trim
        Else
            MyMessageBox.Show(Me, "Data Tempering ....!!!")
            Exit Sub
        End If
        If bal IsNot Nothing Then
            Try
                sbdata = New sbJournalClass
                sbdata.accountnumber = accountNumber
                sbdata.bat = bal
                sbdata.status = "Approved"
                sbdata.trid = tbtrid.Text.Trim
                dltdata = New dltClass
                dltdata.accountbalance = bal
                dltdata.accountnumber = accountNumber
                dltdata.dlt = updatedlt
                dltdata.dlt2 = updatedlt2
                If TransctionService.doSBTransction(sbdata, dltdata) Then
                    MyMessageBox.Show(Me, "Data Saved Successfully")
                Else
                    MyMessageBox.Show(Me, "Data Not Saved Successfully")
                End If
            Catch ex As Exception

            End Try
        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If

    End Sub

    Private Sub DoRDTransction()
        Dim bal As String = Nothing
        If bat = tbbat.Text.Trim Then
            bal = tbbat.Text.Trim
        Else
            MyMessageBox.Show(Me, "Data Tempering ....!!!")
            Exit Sub
        End If

        If bal IsNot Nothing Then
            Try
                rddata = New rdJournalClass
                rddata.accountnumber = accountNumber
                rddata.bat = bal
                rddata.status = "Approved"
                rddata.trid = tbtrid.Text.Trim
                dltdata = New dltClass
                dltdata.accountbalance = bal
                dltdata.accountnumber = accountNumber
                dltdata.dlt = updatedlt
                dltdata.dlt2 = updatedlt2
                If TransctionService.dordTransction(rddata, dltdata) Then
                    MyMessageBox.Show(Me, "Data  Saved Successfully")
                Else
                    MyMessageBox.Show(Me, "Data Not Saved Successfully")
                End If
            Catch ex As Exception

            End Try
        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If

    End Sub

    Private Sub DoSSaTransction()
        Dim bal As String = Nothing
        If bat = tbbat.Text.Trim Then
            bal = tbbat.Text.Trim
        Else
            MyMessageBox.Show(Me, "Data Tempering ....!!!")
            Exit Sub
        End If
        If bal IsNot Nothing Then
            Try
                ssadata = New ssaJournalClass
                ssadata.accountnumber = accountNumber
                ssadata.bat = bal
                ssadata.status = "Approved"
                ssadata.trid = tbtrid.Text.Trim
                dltdata = New dltClass
                dltdata.accountbalance = bal
                dltdata.accountnumber = accountNumber
                dltdata.dlt = updatedlt
                dltdata.dlt2 = updatedlt2
                If TransctionService.doSSATransction(ssadata, dltdata) Then
                    MyMessageBox.Show(Me, "Data  Saved Successfully")
                Else
                    MyMessageBox.Show(Me, "Data Not Saved Successfully")

                End If
            Catch ex As Exception

            End Try



        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If

    End Sub

    Private Sub DoTdTransction()

    End Sub

    Private Sub GetDltFirst()
        '  dltInformation(getApproveInfo.GetAccountNumber)
        dltdata = dltservice.GetByAcno(accountNumber)
        dlt1 = dltdata.dlt
        dlt2 = dltdata.dlt2
        updatedlt = trdate
        updatedlt2 = dlt1
    End Sub

    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If status = "Pending" Then

            GetDltFirst()
            If type = "Saving" Then
                DoSBTransction()
            ElseIf type = "RD" Then
                DoRDTransction()
            ElseIf type = "SSA" Then
                DoSSaTransction()
            ElseIf type = "TD" Then
                DoTdTransction()
            End If
        Else
            MyMessageBox.Show(Me, "Already " & status)
        End If
    End Sub

    Private Sub DoRDRejected()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("rejectTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification

        Try
            command.CommandText = "update " & rdjournaltbl & " set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            'update trdtatus from sb journal

            command.CommandText = "update journal set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            transction.Commit()
            MyMessageBox.Show(Me, "Data Saved Successfully")
        Catch ex As Exception
            MyMessageBox.Show(Me, "Commit Exception Type: {0}" + ex.Message())
            MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
            Try
                transction.Rollback()
                MyMessageBox.Show(Me, "Data Not Saved Successfully")
            Catch ex2 As Exception
                MyMessageBox.Show(Me, "Rollback Exception Type: {0}" + ex2.Message())
                MyMessageBox.Show(Me, "  Message: {0}" + ex2.Message)
            End Try
        End Try

    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click

        If status = "Pending" Then

            GetDltFirst()
            Dim trid As String = tbtrid.Text.Trim
            RejectTransction(type, trid)
            'If type = "Saving" Then
            '    DoSBRejected()
            'ElseIf type = "RD" Then
            '    DoRDRejected()
            'ElseIf type = "SSA" Then
            '    DoSSaRejected()
            'ElseIf type = "TD" Then
            '    DoTdTransction()
            'End If
        Else
            MyMessageBox.Show(Me, "Already " & status)
        End If

    End Sub
    Private Sub RejectTransction(ProductType As String, trid As String)
        If TransctionService.rejectTransction(ProductType, trid) Then

            MyMessageBox.Show(Me, "Data Saved Successfully")
        Else
            MyMessageBox.Show(Me, "Data Not Saved ")
        End If
    End Sub

    Private Sub DoSSaRejected()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("rejectTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification

        Try
            command.CommandText = "update " & ssajournaltbl & " set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            'update trdtatus from sb journal

            command.CommandText = "update journal set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            transction.Commit()
            MyMessageBox.Show(Me, "Data Saved Successfully")
        Catch ex As Exception
            MyMessageBox.Show(Me, "Commit Exception Type: {0}" + ex.Message())
            MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
            Try
                transction.Rollback()
                MyMessageBox.Show(Me, "Data Not Saved Successfully")
            Catch ex2 As Exception
                MyMessageBox.Show(Me, "Rollback Exception Type: {0}" + ex2.Message())
                MyMessageBox.Show(Me, "  Message: {0}" + ex2.Message)
            End Try
        End Try

    End Sub

    Private Sub DoSBRejected()
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("rejectTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification

        Try
            command.CommandText = "update sbjournal set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            'update trdtatus from sb journal

            command.CommandText = "update journal set status='Rejected' where trid='" & tbtrid.Text.Trim & "'"
            command.ExecuteNonQuery()

            transction.Commit()
            MyMessageBox.Show(Me, "Data Saved Successfully")
        Catch ex As Exception
            MyMessageBox.Show(Me, "Commit Exception Type: {0}" + ex.Message())
            MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
            Try
                transction.Rollback()
                MyMessageBox.Show(Me, "Data Not Saved Successfully")
            Catch ex2 As Exception
                MyMessageBox.Show(Me, "Rollback Exception Type: {0}" + ex2.Message())
                MyMessageBox.Show(Me, "  Message: {0}" + ex2.Message)
            End Try
        End Try

    End Sub

End Class