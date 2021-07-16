﻿Imports System.Data.SqlClient

Public Class openAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub ProductCb_TextChanged(sender As Object, e As EventArgs) Handles ProductCb.TextChanged
        Try
            If ProductCb.Text = "Saving" Then

            End If
            If ProductCb.Text = "RD" Then
                Actermtb.Text = "5Year"
            Else
                Actermtb.Text = ""
            End If
            If ProductCb.Text = "TD" Or ProductCb.Text = "RD" Then
                AccValuetb.ReadOnly = False
            Else
                AccValuetb.ReadOnly = True

            End If



            If ProductCb.Text = "TD" Then
                Actermtb.ReadOnly = False
            Else
                Actermtb.ReadOnly = True
            End If

            If ProductCb.Text = "SSA" Then
                If Modetb.Text = "Minor" Then


                Else
                    ProductCb.Text = "Choose Product"
                    MyMessageBox.Show(Me, "Operating MOde Must Be Minor")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub nominiregcb_TextChanged1(sender As Object, e As EventArgs)
        Try
            If nominiregcb.Text = "Yes" Then
                NominiNameInfotb.ReadOnly = False
                NominiRelationInfotb.ReadOnly = False
                NominiAgeInfotb.ReadOnly = False
                NominiAddressInfotb.ReadOnly = False

            Else
                NominiNameInfotb.ReadOnly = True
                NominiRelationInfotb.ReadOnly = True
                NominiAgeInfotb.ReadOnly = True
                NominiAddressInfotb.ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Modetb_TextChanged(sender As Object, e As EventArgs)
        Try
            If Modetb.Text = "JointA" Or Modetb.Text = "JointB" Then

                name2tb.ReadOnly = False

            Else

                name2tb.ReadOnly = True
                name2tb.Text = ""
            End If

            If Modetb.Text = "JointA" Or Modetb.Text = "JointB" Or Modetb.Text = "Minor" Then
                Relationtb.ReadOnly = False
            Else
                Relationtb.ReadOnly = True
                Relationtb.Text = ""
            End If

            If Modetb.Text = "JointA" Or Modetb.Text = "JointB" Or Modetb.Text = "Minor" Or Modetb.Text = "Self" Then

            Else

            End If
            If Modetb.Text = "Minor" Then
                GuardianNametb.ReadOnly = False

            Else
                GuardianNametb.ReadOnly = True
                GuardianNametb.Text = ""
                GuardianNametb.Text = ""

            End If
        Catch

        End Try
    End Sub

    Dim _reffNumber, _PrNumber, _OpenDate, _AccountStatus, _Name, _ModeOfOperation, _secondName, _guardianName, _cif, _cifStatus, _Dob, _gender, _MobileNumber, _EmailId, _Pan, _Adhar, _Address, _Relation, _product, _term, _Value, _nominiReg, _NominiName, _NominiRelation, _NominiDOB, _NominiAddress, _Photo, _sign, _fullName, _accountNumber As String

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub OpenPrintPage()
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('Print/OpenAccountCheck.aspx','_newtab');", True)
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VerifyInputData()
        GoForrword()
        Button1.Enabled = True

    End Sub

    Private Sub enableFormView() ' set readonly false
        reffNumberTb.ReadOnly = False
        TextBox1.ReadOnly = False
        accountTb.ReadOnly = False

        ciftb.ReadOnly = False
        NameInfo.ReadOnly = False
        dobtb.ReadOnly = False
        genderlb.Enabled = True
        mobiletb.ReadOnly = False
        emailtb.ReadOnly = False
        pantb.ReadOnly = False
        adhartb.ReadOnly = False
        addresstb.ReadOnly = False

    End Sub
    Private Sub findDataFromAccountDatabase(name As String)
        'get data from liveaccount database 
        'get data from accountOpen Database
        Try
            AddAccountHelper.AccountNameSearch(name)
            BootstrapGridView1.DataSource = getAccountOpenDataTable()
            BootstrapGridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Dim _name1 As String

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click ' for search name 
        _name1 = nametb.Text.Trim
        If _name1 = Nothing Then
            MyMessageBox.Show(Me, "Enter Name ...")
            Exit Sub

        End If

        enableFormView() ' for readonly false
        findDataFromAccountDatabase(_name1)
    End Sub

    Dim IsVerifu As Boolean
    Dim verid As String

    Private Sub GetDataFromView()
        'total in db 28
        _accountNumber = acnotb.Text.Trim
        _reffNumber = reffNumberTb.Text.Trim
        _PrNumber = TextBox1.Text.Trim
        _OpenDate = accountTb.Text.Trim
        _AccountStatus = "Pending"
        _Name = nametb.Text.Trim
        _ModeOfOperation = Modetb.Text.Trim
        _secondName = name2tb.Text.Trim
        _guardianName = GuardianNametb.Text.Trim
        _Photo = ""
        _sign = ""
        _cif = ciftb.Text.Trim
        _fullName = NameInfo.Text.Trim
        _cifStatus = "Pending"
        _Dob = dobtb.Text.Trim
        _gender = genderlb.Text.Trim
        _MobileNumber = mobiletb.Text.Trim
        _EmailId = emailtb.Text.Trim
        _Pan = pantb.Text.Trim
        _Adhar = adhartb.Text.Trim
        _Address = addresstb.Text
        _Relation = Relationtb.Text.Trim
        _product = ProductCb.Text.Trim
        _term = Actermtb.Text.Trim
        _Value = AccValuetb.Text.Trim
        _nominiReg = nominiregcb.Text.Trim
        _NominiName = NominiNameInfotb.Text.Trim
        _NominiRelation = NominiRelationInfotb.Text.Trim
        _NominiDOB = NominiAgeInfotb.Text.Trim
        _NominiAddress = NominiAddressInfotb.Text.Trim
    End Sub
    Private Sub VerifyInputData()
        'Get Data From View
        GetDataFromView()
        'Checking Empty Field
        If _reffNumber = Nothing Then
            Errortb.Text = "Enter Reffence Number... "
            IsVerifu = False
            Exit Sub
        End If
        If _PrNumber = Nothing Then
            Errortb.Text = "Enter PR Number... "
            IsVerifu = False
            Exit Sub
        End If
        If _OpenDate = Nothing Then
            Errortb.Text = "Enter Account OpenDate... "
            IsVerifu = False
            Exit Sub
        End If
        If _Name = Nothing Then
            Errortb.Text = "Enter Name ... "
            IsVerifu = False
            Exit Sub
        End If
        If _ModeOfOperation = "JointA" Or _ModeOfOperation = "JointB" Then
            If _secondName = Nothing Then
                Errortb.Text = "Enter Second Name "
                IsVerifu = False
                Exit Sub
            End If

        End If
        If _ModeOfOperation = "Minor" Then
            If _guardianName = Nothing Then
                Errortb.Text = "Enter Guardian Name "
                IsVerifu = False
                Exit Sub
            End If

        End If
        If _Dob = Nothing Then
            Errortb.Text = "Enter Dob ... "
            IsVerifu = False
            Exit Sub
        End If
        If _gender = Nothing Then
            Errortb.Text = "Enter Gender ... "
            IsVerifu = False
            Exit Sub
        End If
        If _MobileNumber = Nothing Then
            Errortb.Text = "Enter Mobile ... "
            IsVerifu = False
            Exit Sub
        End If
        If _EmailId = Nothing Then
            Errortb.Text = "Enter Email ... "
            IsVerifu = False
            Exit Sub
        End If
        If _Pan = Nothing Then
            Errortb.Text = "Enter Pan ... "
            IsVerifu = False
            Exit Sub
        End If
        If _Adhar = Nothing Then
            Errortb.Text = "Enter Adhar ... "
            IsVerifu = False
            Exit Sub
        End If
        If _cif = Nothing Then
            'Nothing Because No Cif In Account Open Time

        End If

        If ProductCb.Text = "SSA" Then
            'account type "Minor"

            'Error Must be Minor Account
            If Modetb.Text IsNot "Minor" Then
                IsVerifu = False
                MyMessageBox.Show(Me, "Ssa Account Must be Minor ...")
                Exit Sub
            End If

        End If

    End Sub


    Private Sub GoForrword()
        'send all data to a module then open print form
        VertualId = verid
        cif = _cif
        accountnumber = _accountNumber
        name = _Name
        producttype1 = _product
        productterm = _term
        productvalue = _Value
        nomini = _nominiReg
        nomininame = _NominiName
        nominiaddress = _NominiAddress '10
        nominiage = _NominiDOB
        nominirelation = _NominiRelation
        acoperatemode = _ModeOfOperation
        guardianname = _guardianName
        jointname = _secondName
        relation = _Relation
        acstatus = _AccountStatus

        address = _Address
        mobile = _MobileNumber
        email = _EmailId '20
        dob = _Dob
        gender = _gender
        adhar = _Adhar
        pan = _Pan
        photo = _Photo
        sign = _sign
        doo = _OpenDate
        reffno = _reffNumber
        pr = _PrNumber
        balance = "00"
        trid = "NA" '31


        OpenPrintPage()
    End Sub
    'Submit Button
    Private Sub InsertDataTransction()

        verid = DateAndTime.Now.ToString("yyyy-MM-dd-hh-mm") + "_" + GetofficeId + GetuserID

        'insert data into newacdb
        Dim command As String
        command = "INSERT INTO newacdb (VirtualId, cif, accountnumber, n_ame, producttype, productterm, productvalue, nominireg, nomininame, nominiage, nominiaddress, nominirelation, acoperatemode, guardianname, jointname, address, mobile, email, dob, gender, adhar, pan, photo, sign, doo, reffno, pr)
  VALUES ( '" & verid & "','" & _cif & "', '" & _accountNumber & "', '" & _Name & "', '" & _product & "', '" & _term & "', '" & _Value & "', '" & _nominiReg & "', '" & _NominiName & "', '" & _NominiDOB & "', '" & _NominiAddress & "', '" & _NominiRelation & "', '" & _ModeOfOperation & "', '" & _guardianName & "', '" & _secondName & "', '" & _Address & "', '" & _MobileNumber & "', '" & _EmailId & "', '" & _Dob & "', '" & _gender & "', '" & _Adhar & "', '" & _Pan & "', '" & _Photo & "', '" & _sign & "', '" & _OpenDate & "', '" & _reffNumber & "', '" & _PrNumber & "')"
        Try
            Dim cs As String = connectionhelper.connectionstring()
            databaseconnection = New SqlConnection(cs)
            databaseconnection.Open()
            Dim comd As SqlCommand = databaseconnection.CreateCommand()
            Dim transction As SqlTransaction

            transction = databaseconnection.BeginTransaction("OpenAccount")

            comd.Connection = databaseconnection
            comd.Transaction = transction
            Try
                comd.CommandText = command
                comd.ExecuteNonQuery()
                transction.Commit()
                Errortb.Text = "Account Form Post Successfully ..."

                ' GoForrword()

                'now go to transction page
                Button2.Enabled = True

                ' Response.Redirect("#")

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
            ''Error In Database Connection
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'check
        VerifyInputData()
        InsertDataTransction()
    End Sub
End Class