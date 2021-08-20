Imports System.Data.SqlClient

Public Class addAccount
    Inherits System.Web.UI.Page
    Dim errorText As String
    Dim userNotAdmin As Boolean = True
    Dim replay As Boolean = False
    Dim replay1 As String = ""
    Dim gendder As String

    Dim photoName As String
    Dim signName As String

    Dim row As Integer = 0
    ''' <summary>
    ''' data from view
    ''' </summary>

    Dim _accountid, _balance, _accountstatus, _cif, _accHolderName, _SecAccHolderName, _NominiReg, _product, _MOP, _GuardianName, _relation, _term, _value, _NominiName, _Nominirelation, _NominiDob, _NominiAddress, _today As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userNotAdmin = False

        If "User" = "Admin" Then
            userNotAdmin = False
        ElseIf "User" = "Clork" Then
            userNotAdmin = True
        End If
    End Sub

    'here  Declar all field from view
    Private Sub GetDataFromView()
        'For Live Account
        _accountid = accIdTb.Text.Trim
        _balance = balanceTb.Text.Trim
        _accountstatus = "Pending"
        _cif = ciftb.Text.Trim
        _product = ProductCb.Text.Trim
        _accHolderName = nametb.Text.Trim
        _SecAccHolderName = name2tb.Text.Trim
        _NominiReg = nominiregcb.Text.Trim
        _MOP = Modetb.Text.Trim
        _GuardianName = Guardiantb.Text.Trim

        'For Mode Of Operation
        _relation = Relationtb.Text.Trim

        'For Product Info
        _term = Actermtb.Text.Trim
        _value = AccValuetb.Text.Trim

        'Nomini Info
        _NominiName = NominiNameInfotb.Text.Trim
        _Nominirelation = NominiRelationInfotb.Text.Trim
        _NominiAddress = NominiAddressInfotb.Text.Trim
        _NominiDob = NominiAgeInfotb.Text.Trim

        'dlt
        _today = DateAndTime.Now().ToString("yyyy-MM-dd")
    End Sub

    Private Sub DoTransctionAddData()
        GetDataFromView()
        Try
            Dim cs As String = connectionhelper.connectionstringaccount()
            databaseconnection = New SqlConnection(cs)
            databaseconnection.Open()
            Dim command As SqlCommand = databaseconnection.CreateCommand()
            Dim transction As SqlTransaction

            transction = databaseconnection.BeginTransaction("AddAccount")

            command.Connection = databaseconnection
            command.Transaction = transction

            Try
                command.CommandText = "  insert into " & liveAccountTable & " (accountnumber ,cif,n_ame,producttype,nominireg,acctype,jointname,guardianname,balance,status )values('" & _accountid & "','" & _cif & "','" & _accHolderName & "','" & _product & "','" & _NominiReg & "','" & _MOP & "','" & _SecAccHolderName & "','" & _GuardianName & "','" & _balance & "','" & _accountstatus & "')" ' Insert inTo Liveaccount
                command.ExecuteNonQuery()
                command.CommandText = "  insert into " & nominitable & " (accountnumber,nominireg,nomininame,nominiage,noiminiaddress,nominirelation )values ('" & _accountid & "','" & _NominiReg & "','" & _NominiName & "','" & _NominiDob & "','" & _NominiAddress & "','" & _Nominirelation & "')" 'insert into nominiinfo
                command.ExecuteNonQuery()

                command.CommandText = "  insert into " & productTypeTable & " (accountnumber , type, term , v_alue )values('" & _accountid & "','" & _product & "','" & _term & "','" & _value & "')" ' Insert inTo product type
                command.ExecuteNonQuery()

                command.CommandText = "insert into " & accountOperateTable & " (accountnumber ,accountoperatemode,guardianname,relation )values('" & _accountid & "','" & _MOP & "','" & _GuardianName & "','" & _relation & "')" 'insert into account type
                command.ExecuteNonQuery()

                command.CommandText = "insert into " & dlttable & "(accountnumber ,accountbalance,dlt,dlt2)values('" & _accountid & "','" & _balance & "','" & _today & "','" & _today & "')"
                command.ExecuteNonQuery()

                'try to commite the transction
                transction.Commit()
                '  MyMessageBox.Show(Me, "Data Saved Successfully")
                Errortb.Text = "Data Saved Successfully"

                Dim x = Request.Url.AbsoluteUri
                myMsgBox.Show(Me, x)

                MyMessageBox.Show(Me, "Data Saved Successfully")
            Catch ex As Exception

                Errortb.Text = "Commit Exception Type: {0}" + ex.Message()

                Errortb.Text = Errortb.Text + " Message: {0}" + ex.Message
                Try
                    transction.Rollback()

                    Errortb.Text = "Data Not Saved Successfully"
                Catch ex2 As Exception

                    Errortb.Text = "Rollback Exception Type: {0}" + ex2.Message()

                    Errortb.Text = Errortb.Text + "  Message: {0}" + ex2.Message
                End Try
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertDataLiveAccountDb(accountId As String)
        Try
            AccountSearch(accountId) 'Get Data By Account Id
        Catch
        End Try
        If IsAccountIdExist(accountId) Then

            Errortb.Text = "Account Already Exit"
            Exit Sub
        Else
            Try
                'insert data to liveaccount , nominiinfo , producttype, accountoperatemode
                DoTransctionAddData()
            Catch ex As Exception
                Errortb.Text = ex.Message
            End Try
        End If
    End Sub

    ''' <summary>
    ''' To add data In data Base
    ''' </summary>
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'check Cif Status
        If CifStatustb.Text.Trim = "Active" Then
            InsertDataLiveAccountDb(accIdTb.Text.Trim)
        Else
            Errortb.Text = "First Verified And Active CIF"
        End If
    End Sub

    Protected Sub Modetb_textChanged(sender As Object, e As EventArgs) Handles Modetb.SelectedIndexChanged
        AcModetb.Text = Modetb.Text
        If Modetb.Text = "JointA" Or Modetb.Text = "JointB" Then
            name2tb.ReadOnly = False
            Relationtb.ReadOnly = False

        ElseIf Modetb.Text = "Minor" Then
            EnablemodeofOpreation()

        End If
    End Sub

    Protected Sub nominiregcb_TextChanged(sender As Object, e As EventArgs) Handles nominiregcb.TextChanged
        NominiRegInfo.Text = nominiregcb.Text
        If nominiregcb.Text = "Yes" Then
            EnableNominiView()
        Else
            NominiNameInfotb.Text = Nothing

        End If
    End Sub

    Protected Sub ProductCb_TextChanged(sender As Object, e As EventArgs) Handles ProductCb.TextChanged
        ActypeInfotb.Text = ProductCb.Text
        If ProductCb.Text = "RD" Then
            EnableProductInfoView()
            Actermtb.Text = "5Years"

        ElseIf ProductCb.Text = "TD" Then
            EnableProductInfoView()
        ElseIf ProductCb.Text = "SSA" Then
            Modetb.Text = "Minor"
        ElseIf ProductCb.Text = "Saving" Then
        Else
            Errortb.Text = "Not Yet Implement"

        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Errortb.Text = "Not Implement Yet"
    End Sub

    Protected Sub Modetb_TextChanged1(sender As Object, e As EventArgs) Handles Modetb.TextChanged
        AcModetb.Text = Modetb.Text
        If Modetb.Text = "JointA" Or Modetb.Text = "JointB" Then
            name2tb.ReadOnly = False
            Relationtb.ReadOnly = False

        ElseIf Modetb.Text = "Minor" Then
            EnablemodeofOpreation()

        End If
    End Sub

    Private Sub fillDataFromCifdb(ByVal AccountId As String) ' Here CIF
        Try
            cifsearch(AccountId)
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
                signphoto.ImageUrl = CifHelper.getcifsign(0)
            End If
            If getcifaddress(0) IsNot Nothing And getcifadhar(0) IsNot Nothing And getcifdob(0) IsNot Nothing And getcifemail(0) IsNot Nothing And getcifgender(0) IsNot Nothing And getcifmobile(0) IsNot Nothing And getcifname(0) IsNot Nothing And getcifpan(0) IsNot Nothing Then
                CifHelper.cifupdate = True
            Else
                CifHelper.cifupdate = False
            End If
            'or we can
            ' status ="Approve"
            'then cifhelper.cifupdated =true
        Catch ex As Exception
            CifHelper.cifupdate = False
        Finally

        End Try

    End Sub

    Private Sub fillDataInView() 'For 1st Devision
        'division 1
        balanceTb.Text = getAccountBalance(row) 'Get Balance Form Database
        AccStatustb.Text = getAccountStatus(row) 'Get Account Status
        'division 2
        ciftb.Text = getAccountCif(row)
        nametb.Text = getAccountName(row)
        name2tb.Text = getAccountJointName(row)
        nominiregcb.Text = getAccountNominiRegistor(row)
        ProductCb.Text = getAccountProductType(row)
        Modetb.Text = getAccountAccType(row)
        Guardiantb.Text = getAccountGuardianName(row)
    End Sub

    Private Sub fillDataFromModeOfOperation(ByVal AccountId As String)
        Try
            AccountOperateMode(AccountId)
        Catch

        End Try
        Try
            AcModetb.Text = getAccountOperateAccOperateMode(row)
            GuardianNametb.Text = getAccountOperateGuardianName(row)
            Relationtb.Text = getAccountOperateRelation(row)
        Catch

        End Try
    End Sub

    Private Sub fillDataFromProductInformation(ByVal AccountId As String)
        Try
            ProductType(AccountId)
        Catch

        End Try
        Try
            ActypeInfotb.Text = getProductTypeType(row)
            Actermtb.Text = getProductTypeTerm(row)
            AccValuetb.Text = getProductTypeValue(row)
        Catch
            Errortb.Text = "producttype"
        End Try
    End Sub

    Private Sub fillDataFromNominiInfo(ByVal AccountId As String)
        Try
            NominiInformation(AccountId)
        Catch

        End Try
        Try
            NominiRegInfo.Text = getNominiInfoReg(row)
            NominiNameInfotb.Text = getNominiInfoNominiName(row)
            NominiRelationInfotb.Text = getNominiInfoRelation(row)
            NominiAddressInfotb.Text = getNominiInfoAddress(row)
            NominiAgeInfotb.Text = getNominiInfoNominiAge(row)
        Catch
            Errortb.Text = "NominiInfo"
        End Try
    End Sub

    Private Sub EnableInput()
        balanceTb.ReadOnly = False

        ciftb.ReadOnly = False
        nametb.ReadOnly = True
        'name2tb.ReadOnly = False

        nominiregcb.Enabled = True
        ProductCb.Enabled = True
        Modetb.Enabled = True
        ProductCb.Enabled = True
        Modetb.Enabled = True
        nominiregcb.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub EnableProductInfoView()
        Actermtb.ReadOnly = False
        AccValuetb.ReadOnly = False
    End Sub

    Private Sub EnableNominiView()
        NominiNameInfotb.ReadOnly = False
        NominiRelationInfotb.ReadOnly = False
        NominiAgeInfotb.ReadOnly = False
        NominiAddressInfotb.ReadOnly = False
    End Sub

    Private Sub EnablemodeofOpreation()

        Relationtb.ReadOnly = False
        Guardiantb.ReadOnly = False
    End Sub

    ''' <summary>
    ''' ERROR CODE EB-AddAccount-GetDataByAccountId-101
    ''' </summary>
    Private Sub GetDataByAccountId(ByVal AccountId As String)

        Try
            AccountSearch(AccountId) 'Get Data By Account Id
        Catch
            EnableInput()
            'Id Not Found OR Account Does Not Exist
        End Try
        If IsAccountIdExist(AccountId) = True Then '
            LinkButton5.Enabled = False 'disable clicking on cif search
            Try
                fillDataInView()

                'Division 3
                'retrive Data From Cif Database
                fillDataFromCifdb(getAccountCif(row).ToString)

                'Division 4
                fillDataFromModeOfOperation(AccountId)

                'Division 5
                fillDataFromProductInformation(AccountId)

                'Division 6
                fillDataFromNominiInfo(AccountId)
            Catch ex As Exception
            End Try
        Else

            ciftb.ReadOnly = False
            LinkButton5.Enabled = True 'enable clicking on cif search and msg id not exist and ready to open
        End If
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Dim _accountIdTb As String
        _accountIdTb = accIdTb.Text.Trim
        GetDataByAccountId(_accountIdTb)
    End Sub

    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
        Dim cifid As String
        Try
            cifid = ciftb.Text.Trim
            fillDataFromCifdb(cifid)
            nametb.Text = NameInfo.Text.Trim
            EnableInput()
        Catch

        End Try
    End Sub

    Private Sub AccountStatusUpdate(ByVal status As String, ByVal accountId As String)
        Try
            AccountSearch(accountId) 'Get Data By Account Id
        Catch
            'Id Not Found OR Account Does Not Exist
        End Try
        If IsAccountIdExist(accountId) Then
            Try
                databaseconnection = New SqlConnection(connectionstringaccount())
                datacommand = New SqlCommand("UPDATE " & liveAccountTable & " set status ='" & status & "' where accountnumber='" & accountId & "'", databaseconnection)
                databaseconnection.Open()
                Dim i = datacommand.ExecuteNonQuery()
                If i > 0 Then
                    replay = True ' Data Update Successfully
                Else
                    replay = False 'Data Not Update

                End If
                databaseconnection.Close()
            Catch ex As Exception
                databaseconnection.Close()
            End Try
        End If
    End Sub

    Protected Sub AccountStatusApproveBtn_Click(sender As Object, e As EventArgs) Handles AccountStatusApproveBtn.Click ' Account Status Active
        If accIdTb.Text IsNot Nothing Then

            If userNotAdmin = False Then
                Dim accountId As String = accIdTb.Text.Trim
                AccountStatusUpdate("Active", accountId)
                If replay Then
                    AccStatustb.Text = "Active"
                End If
            Else
                MyMessageBox.Show(Me, "U R Not Authorize to Do This")
            End If
        Else
            MyMessageBox.Show(Me, "First View Account Details")
        End If

    End Sub

    Protected Sub AccountStatusPendingBtn_Click(sender As Object, e As EventArgs) Handles AccountStatusPendingBtn.Click
        If accIdTb.Text IsNot Nothing Then

            If userNotAdmin = False Then
                Dim accountId As String = accIdTb.Text.Trim
                AccountStatusUpdate("Pending", accountId)
                If replay Then
                    AccStatustb.Text = "Pending"
                End If
            Else
                MyMessageBox.Show(Me, "U R Not Authorize to Do This")
            End If
        Else
            MyMessageBox.Show(Me, "First View Account Details")
        End If

    End Sub

    Protected Sub AccountStatusFreezBtn_Click(sender As Object, e As EventArgs) Handles AccountStatusFreezBtn.Click
        If accIdTb.Text IsNot Nothing Then

            If userNotAdmin = False Then

                Dim accountId As String = accIdTb.Text.Trim
                AccountStatusUpdate("Block", accountId)
                If replay Then
                    AccStatustb.Text = "Block"
                End If
            Else
                MyMessageBox.Show(Me, "U R Not Authorize to Do This")
            End If
        Else
            MyMessageBox.Show(Me, "First View Account Details")
        End If

    End Sub

End Class