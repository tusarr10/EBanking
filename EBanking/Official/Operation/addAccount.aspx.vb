Imports System.Data.SqlClient
Imports DataBaseHelper

Public Class addAccount
    Inherits System.Web.UI.Page

    Private liveAccountService As New liveAccountService(connectionstringaccount)
    Private liveAccountData As liveAccountClass
    Private nominiData As NominiClass
    Private productData As productClass
    Private opData As accOperateClass

    Private Cifservice As New ClassCifService(connectionstringaccount)
    Private cifData As ClassCif

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

    ''' <summary>
    ''' Grab Data from view and store at respective class by reffer from here
    ''' and then send this data to liveaccountInterface/transction Interface  to make transction
    ''' </summary>
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

        If liveAccountService.IsAccountNumberExist(accountId) Then

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

    ''' <summary>
    ''' Dapper Migration
    ''' </summary>
    ''' <param name="Data"></param>
    Private Sub fillDataFromCifdb(ByVal data As ClassCif) ' Here CIF

        Try
            If data.cif = Nothing Then
            Else
                'ciftb.Text = data.cif
                CifInfo.Text = data.cif
            End If
            If data.n_ame IsNot Nothing Then
                NameInfo.Text = data.n_ame

            End If
            If data.email IsNot Nothing Then
                emailtb.Text = data.email

            End If
            If data.mobile IsNot Nothing Then
                mobiletb.Text = data.mobile

            End If
            If data.pan IsNot Nothing Then
                pantb.Text = data.pan

            End If
            If data.adhar IsNot Nothing Then
                adhartb.Text = data.adhar

            End If
            If data.dob IsNot Nothing Then
                dobtb.Text = data.dob

            End If
            If data.gender IsNot Nothing Then

                genderlb.SelectedValue = data.gender

            End If
            If data.address IsNot Nothing Then
                addresstb.Text = data.address

            End If
            If data.status IsNot Nothing Then
                CifStatustb.Text = data.status

            End If
            If data.photo IsNot Nothing Then
                photophoto.ImageUrl = data.photo

            End If
            If data.sign IsNot Nothing Then
                signphoto.ImageUrl = data.sign

            End If
            If data.address IsNot Nothing And data.adhar IsNot Nothing And data.dob IsNot Nothing And data.email IsNot Nothing And data.gender IsNot Nothing And data.mobile IsNot Nothing And data.n_ame IsNot Nothing And data.pan IsNot Nothing Then
                cifupdate = True
            Else
                cifupdate = False
            End If
        Catch ex As Exception
            cifupdate = False
        Finally

        End Try

    End Sub

    ''' <summary>
    ''' Complect Dapper
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub fillDataInView(data As liveAccountClass) 'For 1st Devision
        'division 1

        balanceTb.Text = data.balance ' getAccountBalance(row) 'Get Balance Form Database
        AccStatustb.Text = data.status ' getAccountStatus(row) 'Get Account Status
        'division 2
        ciftb.Text = data.cif ' getAccountCif(row)
        nametb.Text = data.n_ame ' getAccountName(row)
        name2tb.Text = data.jointname ' getAccountJointName(row)
        nominiregcb.Text = data.nominireg ' getAccountNominiRegistor(row)
        ProductCb.Text = data.producttype ' getAccountProductType(row)
        Modetb.Text = data.acctype ' getAccountAccType(row)
        Guardiantb.Text = data.guardianname ' getAccountGuardianName(row)
    End Sub

    ''' <summary>
    ''' Dapper Migration
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub fillDataFromModeOfOperation(ByVal data As accOperateClass)

        Try
            AcModetb.Text = data.accountoperatemode ' getAccountOperateAccOperateMode(row)
            GuardianNametb.Text = data.guardianname ' getAccountOperateGuardianName(row)
            Relationtb.Text = data.relation 'getAccountOperateRelation(row)
        Catch
            Errortb.Text = "Opps Error In Getting data From Mode Of Operation ..."
        End Try
    End Sub

    ''' <summary>
    ''' Dapper Migration DONE
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub fillDataFromProductInformation(ByVal data As productClass)

        Try
            ActypeInfotb.Text = data.type 'getProductTypeType(row)
            Actermtb.Text = data.term ' getProductTypeTerm(row)
            AccValuetb.Text = data.v_alue ' getProductTypeValue(row)
        Catch
            Errortb.Text = "producttype"
        End Try
    End Sub

    ''' <summary>
    ''' Dapper Migration
    ''' </summary>
    ''' <param name="data"></param>
    Private Sub fillDataFromNominiInfo(ByVal data As NominiClass)

        Try
            NominiRegInfo.Text = data.nominireg ' getNominiInfoReg(row)
            NominiNameInfotb.Text = data.nomininame ' getNominiInfoNominiName(row)
            NominiRelationInfotb.Text = data.nominirelation ' getNominiInfoRelation(row)
            NominiAddressInfotb.Text = data.nominiaddress ' getNominiInfoAddress(row)
            NominiAgeInfotb.Text = data.nominiage ' getNominiInfoNominiAge(row)
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
        '  If IsAccountIdExist(AccountId) = True Then '
        If liveAccountService.IsAccountNumberExist(AccountId) Then '
            LinkButton5.Enabled = False 'disable clicking on cif search
            Try
                'Fire To Get ClassData From Live acccount Data
                liveAccountData = New liveAccountClass
                liveAccountData = liveAccountService.getByAcNo(AccountId)
                fillDataInView(liveAccountData)

                'Division 3
                'retrive Data From Cif Database
                cifData = New ClassCif
                cifData = Cifservice.FindById(liveAccountData.cif.ToString)
                fillDataFromCifdb(cifData)

                'Division 4
                opData = New accOperateClass
                opData = liveAccountService.getByAcNoFromOpMode(AccountId)
                fillDataFromModeOfOperation(opData)

                'Division 5
                productData = New productClass
                productData = liveAccountService.getByAccountNumberFromAcType(AccountId)
                fillDataFromProductInformation(productData)

                'Division 6
                nominiData = New NominiClass
                nominiData = liveAccountService.getByAcnoFromNomini(AccountId)
                fillDataFromNominiInfo(nominiData)
            Catch ex As Exception
            End Try
        Else
            EnableInput()
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
            cifData = New ClassCif
            cifData = Cifservice.FindById(cifid)
            fillDataFromCifdb(cifData)
            nametb.Text = NameInfo.Text.Trim
            EnableInput()
        Catch

        End Try
    End Sub

    Protected Sub AccountStatusApproveBtn_Click(sender As Object, e As EventArgs) Handles AccountStatusApproveBtn.Click ' Account Status Active
        If accIdTb.Text IsNot Nothing Then

            If userNotAdmin = False Then
                Dim accountId As String = accIdTb.Text.Trim

                If liveAccountService.UpdateAccountStatus(accountId, "Active") Then
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
                '  AccountStatusUpdate("Pending", accountId)
                If liveAccountService.UpdateAccountStatus(accountId, "Pending") Then
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
                '  AccountStatusUpdate("Block", accountId)
                If liveAccountService.UpdateAccountStatus(accountId, "Block") Then
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