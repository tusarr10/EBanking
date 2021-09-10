Imports DataBaseHelper
''' <summary>
''' Dapper Migration Complect
''' </summary>
Public Class ssaDeposit
    Inherits System.Web.UI.Page

    Dim currentBalnce As Double
    Dim TransctionAmount As Double
    Dim NewBalance As Double
    Dim fine As Double = 0
    Dim totalDeposit As Double = 0

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
    Private ssadata As ssaJournalClass
    Private jdata As allJournalClass

    Private cifService As New ClassCifService(connectionstringaccount)
    Private allJournalService As New AllJournalService(connectionstringaccount)
    Private AccountService As New liveAccountService(connectionstringaccount)
    Private dltservice As New dltService(connectionstringaccount)
    Private Sub btnFindAccountClick()
        Dim accountnumber As String
        accountnumber = accIdTb.Text.Trim
        GetDataOfAccount(accountnumber)
    End Sub

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

    Protected Sub btnFindAccount_Click(sender As Object, e As EventArgs) Handles btnFindAccount.Click
        btnFindAccountClick()
    End Sub

    Protected Sub Calculatebtn_Click(sender As Object, e As EventArgs) Handles Calculatebtn.Click
        DoCalculate()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            DoCalculate()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Error In Doing Calculate ..")
            Exit Sub

        End Try
        Try
            GetDataFromView()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Error I Get Data From View ")
            Exit Sub
        End Try
        If Len(transctiontb.Text) > 2 Then
            DoTransction()
        Else
            MyMessageBox.Show(Me, "Enter valid Transction ID")
        End If

    End Sub

    Private Sub FillDataInView(liveAccountData As liveAccountClass) 'get and put data from liveaccount
        balanceTb.Text = liveAccountData.balance
        currentBalnce = liveAccountData.balance
        AccStatustb.Text = liveAccountData.status
        Acctypetb.Text = liveAccountData.acctype
        ciftb.Text = liveAccountData.cif
        nametb.Text = liveAccountData.n_ame
        Gnametb.Text = liveAccountData.guardianname ' getAccountGuardianName(0)

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

    Private Sub GetDataOfAccount(ByVal accountnumber As String)
        If AccountService.IsAccountNumberExist(accountnumber) Then
            liveAccountData = New liveAccountClass
            liveAccountData = AccountService.getByAcNo(accountnumber)
            If liveAccountData.producttype = "SSA" Then
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

    End Sub 'Get Account Information Then Insert data in view

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
            fine = "0" + DepositFine.Text.Trim
        Catch
            MyMessageBox.Show(Me, "Enter Number Only In INR ")
            Exit Sub
        End Try
        If TransctionAmount <= 0 Then
            MyMessageBox.Show(Me, "Enter Valid Amount ")
            Exit Sub
        End If

        Try
            NewBalance = currentBalnce + TransctionAmount
            newbalancetb.Text = NewBalance
            totalDeposit = TransctionAmount + fine
        Catch
            MyMessageBox.Show(Me, "Unable to Calculate")
        End Try

    End Sub

    Private Sub GetDataFromView()
        'data validation pending...

        dlt = dlttb.Text
        ssadata = New ssaJournalClass
        jdata = New allJournalClass

        accountNumber = accIdTb.Text.Trim
        ssadata.accountnumber = accIdTb.Text.Trim
        jdata.accountnumber = accIdTb.Text.Trim

        bbt = balanceTb.Text.Trim
        ssadata.bbt = balanceTb.Text.Trim

        da_te = DateofTransction.Text
        ssadata.da_te = DateofTransction.Text
        jdata.da_te = DateofTransction.Text

        depositername = nametb.Text.Trim
        ssadata.depositername = nametb.Text.Trim
        jdata.na_me = nametb.Text.Trim

        amount = "0" + DepositAmounttb.Text.Trim
        ssadata.amount = "0" + DepositAmounttb.Text.Trim
        jdata.deposit = totalDeposit
        jdata.withdraw = "0"

        fine = "0" + DepositFine.Text.Trim
        ssadata.fine = "0" + DepositFine.Text.Trim

        'add total deposit in alltransction
        bat = newbalancetb.Text.Trim
        jdata.balance = newbalancetb.Text.Trim
        ssadata.bat = newbalancetb.Text.Trim

        Trid = transctiontb.Text.Trim
        ssadata.trid = transctiontb.Text.Trim
        jdata.trid = transctiontb.Text.Trim

        details = detailstb.Text.Trim
        ssadata.Details = detailstb.Text.Trim


        'from hardcode
        transctiontype = "Deposit"
        ssadata.transctiontype = "Deposit"
        status = "Pending"
        ssadata.status = "Pending"
        jdata.status = "Pending"

        office = OfficeName ' to be change in login system
        ssadata.office = OfficeName
        jdata.office = OfficeName

        userName = Getusername ' to be change in Login system
        ssadata.u_ser = Getusername
        jdata.u_ser = Getusername

        'for journal
        accounttype = "SSA"
        jdata.accounttype = "SSA"
        dlt = dlttb.Text
        jdata.dlt = dlttb.Text

    End Sub

    Private Sub DoTransction()
        ' GetDataFromView()
        Try
            If allJournalService.AddtransctionSSA(ssadata, jdata) Then

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

        '    transction = databaseconnection.BeginTransaction("AddSSATransctions")

        '    command.Connection = databaseconnection
        '    command.Transaction = transction
        '    Try
        '        command.CommandText = "insert into " & ssajournaltbl & " (accountnumber ,depositername,da_te,bbt,transctiontype,amount,bat,trid,status,office,u_ser,fine ,details )values('" & accountNumber & "','" & depositername & "','" & da_te & "','" & bbt & "','" & transctiontype & "','" & amount & "','" & bat & "','" & Trid & "','" & status & "','" & office & "','" & userName & "','" & fine & "','" & details & "')"
        '        command.ExecuteNonQuery()

        '        command.CommandText = "insert into journal (da_te,accounttype ,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser ) values('" & da_te & "','" & accounttype & "','" & accountNumber & "','" & depositername & "','" & TransctionAmount & "','" & "00" & "','" & dlt & "','" & Trid & "','" & bat & "','" & status & "','" & office & "','" & userName & "')"
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

End Class