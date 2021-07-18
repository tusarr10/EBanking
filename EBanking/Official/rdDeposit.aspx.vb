﻿Imports System.Data.SqlClient
Public Class rdDeposit
    Inherits System.Web.UI.Page


    Dim currentBalnce As Double = 00

    Dim TransctionAmount As Double = 00
    Dim fine As Double = 00
    Dim NewBalance As Double = 00
    Dim totalDeposit As Double = 00

    Dim accountNumber As String
    Dim depositername As String
    Dim tillDate As String
    Dim da_te As String
    Dim bbt As String
    Dim transctiontype As String
    Dim amount As String


    Dim bat As String
    Dim Trid As String
    Dim status As String
    Dim office As String
    Dim userName As String
    Dim details As String

    Dim accounttype As String
    Dim dlt As String

    Private Sub btnFindAccountClick()
        Dim accountnumber As String
        accountnumber = accIdTb.Text.Trim
        GetDataOfAccount(accountnumber)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetworkingDate = DateAndTime.Now().ToString("yyyy-MM-dd")
            DateofTransction.Text = GetworkingDate
        Catch

        End Try
        Try
            If Request.QueryString("value") IsNot Nothing Then
                accIdTb.Text = Request.QueryString("value").ToString
                btnFindAccountClick()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub FillDataInView() 'get and put data from liveaccount
        balanceTb.Text = getAccountBalance(0)
        currentBalnce = getAccountBalance(0)
        AccStatustb.Text = getAccountStatus(0)
        Acctypetb.Text = getAccountAccType(0)
        ciftb.Text = getAccountCif(0)
        nametb.Text = getAccountName(0)
        nametb2.Text = getAccountJointName(0)

    End Sub
    Private Sub FIllDataInCif(accountnumber As String)
        Try
            cifsearch(accountnumber)
        Catch

        End Try
        Try
            If CifHelper.getcif(0) = Nothing Then
                ' ciftb.readonly = userNotAdmin
            Else
                CifInfo.Text = getcif(0)
                '  ciftb.ReadOnly = userNotAdmin

            End If
            If getcifname(0) IsNot Nothing Then
                NameInfo.Text = getcifname(0)
            End If
            If getcifemail(0) IsNot Nothing Then
                emailtb.Text = getcifemail(0)
            End If
            If getcifmobile(0) IsNot Nothing Then
                mobiletb.Text = getcifmobile(0)
            End If
            If CifHelper.getcifpan(0) IsNot Nothing Then
                pantb.Text = CifHelper.getcifpan(0)
            End If
            If CifHelper.getcifadhar(0) IsNot Nothing Then
                adhartb.Text = CifHelper.getcifadhar(0)
            End If
            If getcifdob(0) IsNot Nothing Then
                dobtb.Text = getcifdob(0)
            End If
            If CifHelper.getcifgender(0) IsNot Nothing Then
                genderlb.SelectedValue = CifHelper.getcifgender(0)

            End If
            If CifHelper.getcifaddress(0) IsNot Nothing Then
                addresstb.Text = CifHelper.getcifaddress(0)
            End If
            If getcifStatus(0) IsNot Nothing Then
                CifStatustb.Text = getcifStatus(0)

            End If
            If CifHelper.getcifphoto(0) IsNot Nothing Then
                photophoto.ImageUrl = CifHelper.getcifphoto(0)
            End If
            If CifHelper.getcifsign(0) IsNot Nothing Then
                photosign.ImageUrl = CifHelper.getcifsign(0)
            End If

        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Cif Information")
        Finally

        End Try
    End Sub
    Private Sub FilldataInDLT(accountnumber As String)
        Dim dlt, dlt2 As String
        Try
            dltInformation(accountnumber)

        Catch
            MyMessageBox.Show(Me, "NO DATA FOUND IN DLT TABLE")
            Exit Sub

        End Try
        Try
            dlt = getDltdlt(0).ToString()
            dlt2 = getDltdlt2(0).ToString()
            dlttb.Text = dlt
            dlttb2.Text = dlt2
        Catch
            MyMessageBox.Show(Me, "Unable to convert dlt to date")
        End Try

    End Sub
    Private Sub GetDataOfAccount(ByVal accountnumber As String)
        Try
            AccountSearch(accountnumber)
        Catch
            MyMessageBox.Show(Me, "Unable to find account")
            Exit Sub

        End Try
        If IsAccountIdExist(accountnumber) Then
            If getAccountProductType(0) = "RD" Then
                If getAccountStatus(0) = "Active" Then
                    FillDataInView()
                    FIllDataInCif(getAccountCif(0))
                    FilldataInDLT(accountnumber)
                Else
                    MyMessageBox.Show(Me, "This Is a Inactive Account ..")
                End If
            Else
                MyMessageBox.Show(Me, "This Is Not A RD Account This is a " & getAccountProductType(0) & " Account ..")
            End If

        Else
            MyMessageBox.Show(Me, "Account Number Does Not Exist ..")
        End If

    End Sub
    Protected Sub btnFindAccount_Click(sender As Object, e As EventArgs) Handles btnFindAccount.Click
        btnFindAccountClick()

    End Sub

    Private Sub DoCalculate()
        ''TODO Calculate
        currentBalnce = getAccountBalance(0)
        Try
            TransctionAmount = "0" + DepositAmounttb.Text.Trim
            fine = "0" + DepositFine.Text.Trim

        Catch
            MyMessageBox.Show(Me, "Enter Number Only In INR ")
            Exit Sub
        End Try
        Try
            NewBalance = currentBalnce + TransctionAmount
            totalDeposit = TransctionAmount + fine
            newbalancetb.Text = NewBalance
        Catch
            MyMessageBox.Show(Me, "Unable to Calculate")
        End Try

    End Sub
    Protected Sub Calculatebtn_Click(sender As Object, e As EventArgs) Handles Calculatebtn.Click
        DoCalculate()

    End Sub

    Private Sub GetDataFromView()
        'data validation pending...

        accountNumber = accIdTb.Text.Trim
        bbt = balanceTb.Text.Trim
        da_te = DateofTransction.Text
        depositername = nametb.Text.Trim
        amount = "0" + DepositAmounttb.Text.Trim
        fine = "0" + DepositFine.Text.Trim
        'add total deposit in alltransction
        bat = newbalancetb.Text.Trim
        Trid = transctiontb.Text.Trim
        tillDate = tillDateTB.Text.Trim
        details = detailstb.Text.Trim

        'from hardcode
        transctiontype = "Deposit"
        status = "Pending"
        office = OfficeName ' to be change in login system
        userName = Getusername ' to be change in Login system

        'for journal
        accounttype = "RD"
        dlt = dlttb.Text

    End Sub
    Private Sub DoTransction()
        Try
            'Search TRID If exist

        Catch ex As Exception

        End Try
        Try
            GetDataFromView()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Error I Get Data From View ")
            Exit Sub
        End Try
        Try
            DoCalculate()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Error In Doing Calculate ..")
            Exit Sub

        End Try
        Try
            Dim cs As String = connectionhelper.connectionstring()
            databaseconnection = New SqlConnection(cs)
            databaseconnection.Open()
            Dim command As SqlCommand = databaseconnection.CreateCommand()
            Dim transction As SqlTransaction

            transction = databaseconnection.BeginTransaction("AddRdTransctions")

            command.Connection = databaseconnection
            command.Transaction = transction
            Try
                command.CommandText = "insert into " & rdjournaltbl & " (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,fine,mo_nth )values('" & accountNumber & "','" & depositername & "','" & da_te & "','" & bbt & "','" & transctiontype & "','" & amount & "','" & bat & "','" & Trid & "','" & status & "','" & office & "','" & userName & "','" & fine & "','" & tillDate & "')"
                command.ExecuteNonQuery()

                command.CommandText = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values('" & da_te & "','" & accounttype & "','" & accountNumber & "','" & depositername & "','" & totalDeposit & "','" & "00" & "','" & dlt & "','" & Trid & "','" & bat & "','" & status & "','" & office & "','" & userName & "')"
                command.ExecuteNonQuery()

                transction.Commit()
                Dim x = Request.Url.AbsoluteUri
                myMsgBox.Show(Me, x)
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




        Catch ex As Exception
            MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DoTransction()
    End Sub


End Class