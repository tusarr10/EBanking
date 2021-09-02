Imports System.Data.SqlClient
Imports DataBaseHelper


Public Class TransctionStatusApprove
    Inherits System.Web.UI.Page

    ' all Variable Declare
    Dim cs As String = connectionhelper.connectionstringaccount()

    Private dataservice As New AllJournalService(connectionstringaccount)
    Private dltservice As New dltService(connectionstringaccount)
    Dim sbdataList As sbJournalClass
    Dim rddataList As rdJournalClass
    Dim ssadataList As ssaJournalClass
    Dim dltdatalist As dltClass

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
            sbdataList = dataservice.getBydataFromSb(trdate, accountNumber, trId, status)
            getInfosb(sbdataList)

        ElseIf type = "RD" Then
            rddataList = dataservice.getBydataFromrd(trdate, accountNumber, trId, status)
            getInford(rddataList)
        ElseIf type = "SSA" Then
            ssadataList = dataservice.getBydataFromssa(trdate, accountNumber, trId, status)
            getInfossa(ssadataList)
        Else
            tbacno.Text = "Can`not Find Product Type ..."
            Exit Sub

        End If

    End Sub

    Sub getInfosb(ByVal data As sbJournalClass)

        If data.accountnumber IsNot Nothing Then
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

        If data.accountnumber IsNot Nothing Then
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

        If data.accountnumber IsNot Nothing Then
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
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("UpdateTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification
        If bal IsNot Nothing Then
            Try

                command.CommandText = "update sbjournal set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update trdtatus from sb journal

                command.CommandText = "update journal set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update alljournalstatus

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & accountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & accountNumber & "'"
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
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("UpdateTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification
        If bal IsNot Nothing Then
            Try

                command.CommandText = "update rdjournal set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update trdtatus from sb journal

                command.CommandText = "update journal set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update alljournalstatus

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & accountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & accountNumber & "'"
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
        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("UpdateTransction")

        command.Connection = databaseconnection
        command.Transaction = transction

        'Impliment Verification
        If bal IsNot Nothing Then
            Try

                command.CommandText = "update " & ssajournaltbl & " set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update trdtatus from sb journal

                command.CommandText = "update journal set status='Approved' where trid='" & tbtrid.Text.Trim & "'"
                command.ExecuteNonQuery()

                'update alljournalstatus

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & accountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & accountNumber & "'"
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
        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If

    End Sub

    Private Sub DoTdTransction()

    End Sub

    Private Sub GetDltFirst()
        '  dltInformation(getApproveInfo.GetAccountNumber)
        dltdatalist = dltservice.GetByAcno(accountNumber)
        dlt1 = dltdatalist.dlt
        dlt2 = dltdatalist.dlt2
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
            If type = "Saving" Then
                DoSBRejected()
            ElseIf type = "RD" Then
                DoRDRejected()
            ElseIf type = "SSA" Then
                DoSSaRejected()
            ElseIf type = "TD" Then
                DoTdTransction()
            End If
        Else
            MyMessageBox.Show(Me, "Already " & status)
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