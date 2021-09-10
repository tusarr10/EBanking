Imports DataBaseHelper

''' <summary>
''' Dapper Migration Complect
''' </summary>
Public Class sbDeposit
    Inherits System.Web.UI.Page

    Dim currentBalnce As Double
    Dim TransctionAmount As Double
    Dim NewBalance As Double

    Dim accountNumber As String
    Dim depositername As String
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

    Private cifData As ClassCif
    Private liveAccountData As liveAccountClass
    Private dltData As dltClass
    Private sbdata As sbJournalClass
    Private jdata As allJournalClass

    Private cifService As New ClassCifService(connectionstringaccount)
    Private allJournalService As New AllJournalService(connectionstringaccount)
    Private AccountService As New liveAccountService(connectionstringaccount)
    Private dltservice As New dltService(connectionstringaccount)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            WorkingData = DateAndTime.Now().ToString("yyyy-MM-dd")
            DateofTransction.Text = WorkingData
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

    Private Sub FillDataInView(liveAccountData As liveAccountClass) 'get and put data from liveaccount
        balanceTb.Text = liveAccountData.balance
        currentBalnce = liveAccountData.balance
        AccStatustb.Text = liveAccountData.status
        Acctypetb.Text = liveAccountData.acctype
        ciftb.Text = liveAccountData.cif
        nametb.Text = liveAccountData.n_ame
        nametb2.Text = liveAccountData.jointname

    End Sub

    Private Sub FIllDataInCif(cifData As ClassCif)
        Try
            If cifData.cif = Nothing Then
                ' ciftb.readonly = userNotAdmin
            Else
                CifInfo.Text = cifData.cif
                '  ciftb.ReadOnly = userNotAdmin

            End If
            If cifData.n_ame IsNot Nothing Then
                NameInfo.Text = cifData.n_ame
            End If
            If cifData.email IsNot Nothing Then
                emailtb.Text = cifData.email
            End If
            If cifData.mobile IsNot Nothing Then
                mobiletb.Text = cifData.mobile
            End If
            If cifData.pan IsNot Nothing Then
                pantb.Text = cifData.pan
            End If
            If cifData.adhar IsNot Nothing Then
                adhartb.Text = cifData.adhar
            End If
            If cifData.dob IsNot Nothing Then
                dobtb.Text = cifData.dob
            End If
            If cifData.gender IsNot Nothing Then
                genderlb.SelectedValue = cifData.gender

            End If
            If cifData.address IsNot Nothing Then
                addresstb.Text = cifData.address
            End If
            If cifData.status IsNot Nothing Then
                CifStatustb.Text = cifData.status

            End If
            If cifData.photo IsNot Nothing Then
                photophoto.ImageUrl = cifData.photo
            End If
            If cifData.sign IsNot Nothing Then
                photosign.ImageUrl = cifData.sign
            End If
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Cif Information")
        Finally

        End Try
    End Sub

    Private Sub FilldataInDLT(dltData As dltClass)
        Try
            dlttb.Text = dltData.dlt
            dlttb2.Text = dltData.dlt2
        Catch
            MyMessageBox.Show(Me, "Unable to convert dlt to date")
        End Try

    End Sub

    Private Sub GetDataOfAccount(ByVal accountnumber As String, cif As String)

        If AccountService.IsAccountNumberExist(accountnumber) Then
            liveAccountData = New liveAccountClass
            liveAccountData = AccountService.getByAcNo(accountnumber)
            If liveAccountData.producttype = "Saving" Then
                If liveAccountData.status = "Active" Then
                    FillDataInView(liveAccountData)

                    cifData = New ClassCif
                    cifData = cifService.FindById(liveAccountData.cif)
                    FIllDataInCif(cifData)

                    dltData = New dltClass
                    dltData = dltservice.GetByAcno(liveAccountData.accountnumber)
                    FilldataInDLT(dltData)

                Else
                    MyMessageBox.Show(Me, "This Is a Inactive Account ..")
                End If
            Else
                MyMessageBox.Show(Me, "This is not a Saving Account .This Is a " & getAccountProductType(0) & " Account")
            End If
        Else
            MyMessageBox.Show(Me, "Account Does not Exist ..")

        End If

    End Sub

    Private Sub btnFindAccountClick()
        Dim accountnumber As String
        accountnumber = accIdTb.Text.Trim
        GetDataOfAccount(accountnumber, "")
    End Sub

    Protected Sub btnFindAccount_Click(sender As Object, e As EventArgs) Handles btnFindAccount.Click
        btnFindAccountClick()
    End Sub

    Private Sub DoCalculate()
        ''TODO Calculate
        liveAccountData = AccountService.getByAcNo(accIdTb.Text.Trim)
        currentBalnce = Double.Parse(liveAccountData.balance)  'getAccountBalance(0)
        If currentBalnce = balanceTb.Text Then

        Else
            MyMessageBox.Show(Me, "Data Tempering" & currentBalnce & "=" & balanceTb.Text)
            Exit Sub
        End If
        Try
            TransctionAmount = "0" + DepositAmounttb.Text.Trim
        Catch
            MyMessageBox.Show(Me, "Enter Number Only In INR ")
            Exit Sub
        End Try

        If TransctionAmount <= 0 Then
            MyMessageBox.Show(Me, "Enter Number > 0 ")
            Exit Sub
        Else

        End If

        Try
            NewBalance = currentBalnce + TransctionAmount
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
        sbdata = New sbJournalClass
        jdata = New allJournalClass

        accountNumber = accIdTb.Text.Trim
        sbdata.accountnumber = accIdTb.Text.Trim
        jdata.accountnumber = accIdTb.Text.Trim

        bbt = balanceTb.Text.Trim
        sbdata.bbt = balanceTb.Text.Trim

        da_te = DateofTransction.Text
        sbdata.da_te = DateofTransction.Text
        jdata.da_te = DateofTransction.Text

        depositername = nametb.Text.Trim
        sbdata.depositername = nametb.Text.Trim
        jdata.na_me = nametb.Text.Trim

        amount = "0" + DepositAmounttb.Text.Trim
        sbdata.amount = "0" + DepositAmounttb.Text.Trim
        jdata.deposit = "0" + DepositAmounttb.Text.Trim
        jdata.withdraw = "0"

        bat = newbalancetb.Text.Trim
        sbdata.bat = newbalancetb.Text.Trim
        jdata.balance = newbalancetb.Text.Trim

        Trid = transctiontb.Text.Trim
        sbdata.trid = transctiontb.Text.Trim
        jdata.trid = transctiontb.Text.Trim

        details = detailstb.Text.Trim
        sbdata.Details = detailstb.Text.Trim

        'from hardcode
        transctiontype = "Deposit"
        sbdata.transctiontype = "Deposit"
        status = "Pending"
        sbdata.status = "Pending"
        jdata.status = "Pending"

        office = OfficeName ' to be change in login system
        sbdata.office = OfficeName
        jdata.office = OfficeName

        userName = Getusername ' to be change in Login system
        sbdata.u_ser = Getusername
        jdata.u_ser = Getusername

        'for journal
        accounttype = "Saving"
        jdata.accounttype = "Saving"
        dlt = dlttb.Text
        jdata.dlt = dlttb.Text

    End Sub

    Private Sub DoTransction()

        Try
            If allJournalService.AddtransctionSb(sbdata, jdata) Then
                Dim x = Request.Url.AbsoluteUri
                myMsgBox.Show(Me, x)
            Else

                MyMessageBox.Show(Me, "Data Not Saved Successfully")
            End If
        Catch ex As Exception

        End Try


        'Try
        '    Dim cs As String = connectionhelper.connectionstringaccount()
        '    databaseconnection = New SqlConnection(cs)
        '    databaseconnection.Open()
        '    Dim command As SqlCommand = databaseconnection.CreateCommand()
        '    Dim transction As SqlTransaction

        '    transction = databaseconnection.BeginTransaction("AddSbTransction")

        '    command.Connection = databaseconnection
        '    command.Transaction = transction
        '    Try
        '        command.CommandText = "insert into " & sbjournaltbl & " (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser ,details)values('" & accountNumber & "','" & depositername & "','" & da_te & "','" & bbt & "','" & transctiontype & "','" & amount & "','" & bat & "','" & Trid & "','" & status & "','" & office & "','" & userName & "','" & details & "')"
        '        command.ExecuteNonQuery()

        '        command.CommandText = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values('" & da_te & "','" & accounttype & "','" & accountNumber & "','" & depositername & "','" & amount & "','" & "00" & "','" & dlt & "','" & Trid & "','" & bat & "','" & status & "','" & office & "','" & userName & "')"
        '        command.ExecuteNonQuery()

        '        transction.Commit()
        '        Dim x = Request.Url.AbsoluteUri
        '        myMsgBox.Show(Me, x)
        '    Catch ex As Exception
        '        MyMessageBox.Show(Me, "Commit Exception Type: {0}" + ex.Message())
        '        MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
        '        Try
        '            transction.Rollback()

        '            MyMessageBox.Show(Me, "Data Not Saved Successfully")
        '        Catch ex2 As Exception
        '            MyMessageBox.Show(Me, "Rollback Exception Type: {0}" + ex2.Message())
        '            MyMessageBox.Show(Me, "  Message: {0}" + ex2.Message)
        '        End Try
        '    End Try
        'Catch ex As Exception
        '    MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
        'End Try
    End Sub

    Dim Isverification As Boolean = False

    Private Sub btnpost_click()
        GetDataFromView()

        If Len(transctiontb.Text.ToString) > 2 Then
            If "x" = "x" Then 'transction duplicate and status must reject
                DoTransction()
            End If
        Else
            MyMessageBox.Show(Me, "Enter Valid Transction ID")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        btnpost_click()
    End Sub

End Class