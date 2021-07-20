Imports System.Data.SqlClient
Public Class TransctionStatusApprove
    Inherits System.Web.UI.Page

    ' all Variable Declare
    Dim cs As String = connectionhelper.connectionstring()
    Dim dlt1 As String = Nothing
    Dim dlt2 As String = Nothing
    Dim updatedlt As String
    Dim updatedlt2 As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            getInfo()

        Catch ex As Exception
            MyMessageBox.Show(Me, ex.Message)
        End Try
    End Sub
    Sub getInfo()
        If getApproveInfo.GetAccountNumber IsNot Nothing Then
            tbacno.Text = getApproveInfo.GetAccountNumber

        Else
            tbacno.Text = "ERROR"

        End If
        If getApproveInfo.GetTrId IsNot Nothing Then
            tbtrid.Text = getApproveInfo.GetTrId
        Else
            tbtrid.Text = "Error"
        End If

        If getApproveInfo.GetStatus IsNot Nothing Then
            tbstatus.Text = getApproveInfo.GetStatus

        Else
            tbstatus.Text = "ERROR"

        End If
        If getApproveInfo.GetDate IsNot Nothing Then
            tbDate.Text = getApproveInfo.GetDate
        Else
            tbDate.Text = "Error"
        End If
        If getApproveInfo.GetAcType IsNot Nothing Then
            tbactype.Text = GetAcType
        Else tbactype.Text = "Error"
        End If

        If getApproveInfo.GetBBT IsNot Nothing Then
            tbbbt.Text = getApproveInfo.GetBBT

        Else
            tbbbt.Text = "ERROR"

        End If
        If getApproveInfo.GetDetailsTransction IsNot Nothing Then
            detailstb.Text = getApproveInfo.GetDetailsTransction

        Else
            detailstb.Text = "ERROR"

        End If
        If getApproveInfo.GetAmount IsNot Nothing Then
            tbAmount.Text = getApproveInfo.GetAmount
        Else
            tbAmount.Text = "Error"
        End If

        If getApproveInfo.GetBAT IsNot Nothing Then
            tbbat.Text = getApproveInfo.GetBAT

        Else
            tbbat.Text = "ERROR"

        End If
        If getApproveInfo.GetTransctionsType IsNot Nothing Then
            tbtrtype.Text = getApproveInfo.GetTransctionsType
        Else
            tbtrtype.Text = "Error"
        End If
        If getApproveInfo.GetName IsNot Nothing Then
            tbname.Text = GetName
        Else tbname.Text = "Error"
        End If


    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub DoSBTransction()
        Dim bal As String = Nothing
        If GetBAT = tbbat.Text.Trim Then
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

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
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
        If GetBAT = tbbat.Text.Trim Then
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

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
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
        If GetBAT = tbbat.Text.Trim Then
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

                command.CommandText = "update liveaccount set balance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
                command.ExecuteNonQuery()

                command.CommandText = "update dlt set dlt='" & updatedlt & "',dlt2='" & updatedlt2 & "', accountbalance='" & bal & "' where accountnumber='" & getApproveInfo.GetAccountNumber & "'"
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
        dltInformation(getApproveInfo.GetAccountNumber)
        dlt1 = getDltdlt(0)
        dlt2 = getDltdlt2(0)
        updatedlt = getApproveInfo.GetDate
        updatedlt2 = dlt1
    End Sub
    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If getApproveInfo.GetStatus = "Pending" Then

            GetDltFirst()
            If GetAcType = "Saving" Then
                DoSBTransction()
            ElseIf GetAcType = "RD" Then
                DoRDTransction()
            ElseIf GetAcType = "SSA" Then
                DoSSaTransction()
            ElseIf GetAcType = "TD" Then
                DoTdTransction()
            End If

        Else
            MyMessageBox.Show(Me, "Already " & getApproveInfo.GetStatus)
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

        If getApproveInfo.GetStatus = "Pending" Then

            GetDltFirst()
            If GetAcType = "Saving" Then
                DoSBRejected()
            ElseIf GetAcType = "RD" Then
                DoRDRejected()
            ElseIf GetAcType = "SSA" Then
                DoSSaRejected()
            ElseIf GetAcType = "TD" Then
                DoTdTransction()
            End If

        Else
            MyMessageBox.Show(Me, "Already " & getApproveInfo.GetStatus)
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