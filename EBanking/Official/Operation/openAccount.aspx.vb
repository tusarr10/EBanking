'Imports System.Data.SqlClient
Imports DataBaseHelper
Imports DevExpress.Web

Public Class openAccount
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Link To LiveaccountService.vb
    ''' </summary>
    Private UserData As liveAccountClass

    Private UserDataList As List(Of liveAccountClass)
    Private UserService As New liveAccountService(connectionstringaccount)

    ''' <summary>
    ''' Link to NewAccountInterface.vb
    ''' </summary>
    Private newAccountfiles As NewAccountClass

    Private newService As New newAccountService(connectionstringaccount)
    Private newTransctionService As New newAccountTransctionService(connectionstringaccount)

    ''' <summary>
    ''' For CifService.vb
    ''' </summary>
    Private CifData As ClassCif

    Private CifService As New ClassCifService(connectionstringaccount)


    Friend cifupdate As Boolean = False
    Friend photoPath As String
    Friend signPath As String
    '******************End****************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Not In Use
    Function data(sender As Object, tablename As String) 'For retrive data from Table
        Dim btn As Bootstrap.BootstrapButton = sender
        Dim container As Object = btn.NamingContainer

        Return container.Grid.GetRowValues(container.VisibleIndex, tablename).ToString

    End Function

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

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Dim reff As String = reffNumberTb.Text.Trim
        If newService.IsReffNoExistInNewAccount(reff) Then
            MyMessageBox.Show(Me, "ReffNo already Exist")
        Else

        End If
    End Sub

    Private Sub btnclickcifsearch(cif As String) ' fill cif data from database to view

        Try
            'check cif exist or not
            If CifService.IsCifExist(cif) Then
                CifData = CifService.FindById(cif)
                loadData()
            Else
                cifupdate = False

            End If
        Catch ex As Exception
            ' responselbl.Text = "error" + ex.Message
        Finally
        End Try
    End Sub

    Sub loadData()
        Try
            If CifData.cif = Nothing Then
                ' ciftb.readonly = userNotAdmin
            Else
                ciftb.Text = CifData.cif
                '  ciftb.ReadOnly = userNotAdmin

            End If
            If CifData.n_ame IsNot Nothing Then
                nametb.Text = CifData.n_ame
                '  nametb.ReadOnly = userNotAdmin

            End If
            If CifData.email IsNot Nothing Then
                emailtb.Text = CifData.email
                '   emailtb.ReadOnly = userNotAdmin

            End If
            If CifData.mobile IsNot Nothing Then
                mobiletb.Text = CifData.mobile
                '  mobiletb.ReadOnly = userNotAdmin

            End If
            If CifData.pan IsNot Nothing Then
                pantb.Text = CifData.pan
                '  pantb.ReadOnly = userNotAdmin

            End If
            If CifData.adhar IsNot Nothing Then
                adhartb.Text = CifData.adhar
                '  adhartb.ReadOnly = userNotAdmin

            End If
            If CifData.dob IsNot Nothing Then
                dobtb.Text = CifData.dob
                '  dobtb.ReadOnly = userNotAdmin
            End If
            If CifData.gender IsNot Nothing Then
                'If cifdata.getcifgender = "Male" Then
                '    gendertb.SelectedIndex = 0
                'ElseIf cifdata.getcifgender = "Female" Then
                '    RadioGroup1.SelectedIndex = 1
                'ElseIf cifdata.getcifgender = "Other" Then
                '    RadioGroup1.SelectedIndex = 2
                'End If
                genderlb.SelectedValue = CifData.gender
                '  genderlb.Enabled = Not (userNotAdmin)

            End If
            If CifData.address IsNot Nothing Then
                addresstb.Text = CifData.address
                ' addresstb.ReadOnly = userNotAdmin

            End If
            If CifData.status IsNot Nothing Then
                CifStatustb.Text = CifData.status
                ' statustb.ReadOnly = userNotAdmin

            End If
            If CifData.photo IsNot Nothing Then
                photophoto.ImageUrl = CifData.photo
                photoPath = photophoto.ImageUrl
                Debug.WriteLine(photophoto.ImageUrl)

            End If
            If CifData.sign IsNot Nothing Then
                signphoto.ImageUrl = CifData.sign
                signPath = signphoto.ImageUrl
                Debug.WriteLine(signphoto.ImageUrl)
            End If

            'or we can
            ' status ="Approve"
            'then cifdata.cifupdated =true
        Catch ex As Exception
            cifupdate = False
        Finally

        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
        Try
            Dim btn = sender
            Dim container = btn.NamingContainer
            Dim value As String = container.Grid.GetRowValues(container.VisibleIndex, "cif").ToString
            ciftb.Text = value
            If ciftb.Text IsNot Nothing Then
                btnclickcifsearch(ciftb.Text.Trim)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub ASPxGridView1_Init(sender As Object, e As EventArgs)
        Try
            findDataFromAccountDatabase(name)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Grab Data From Cif Database
    ''' </summary>
    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs) Handles LinkButton5.Click
        ' search cif if exist
        btnclickcifsearch(ciftb.Text.Trim)
    End Sub

    'for Update Balance Of New Account Opened
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    ''' <summary>
    ''' Open Print Page
    ''' </summary>
    Private Sub OpenPrintPage()
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('../Print/OpenAccountCheck.aspx','_newtab');", True)
    End Sub

    ''' <summary>
    ''' Go To Print Page
    ''' </summary>
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VerifyInputData()
        GoForrword()
        Button1.Enabled = True

    End Sub

    ''' <summary>
    ''' Button Control Enable / Disable
    ''' </summary>
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

    Protected Sub GridView_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs)

    End Sub

    ''' <summary>
    ''' Just Bind Data Form Database to Datatable
    ''' </summary>
    Private Sub loadDataTable()
        ' ASPxGridView1.DataSource = UserDataList  'here change to class list
        ASPxGridView1.DataBind()
    End Sub

    ''' <summary>
    ''' Find Data From DataBase
    ''' logic To Get Data From Database
    ''' Check User already Exist Or Not
    ''' </summary>
    ''' <param name="name">Enter Name As String To find user from Database</param>
    Private Sub findDataFromAccountDatabase(name As String)
        'get data from liveaccount database
        'get data from accountOpen Database
        Try
            If name = "" Then
                '   UserDataList = UserService.getByName(_name2)
                ASPxGridView1.DataSource = UserService.getByName(_name_OA)  'here change to class list
                loadDataTable()
            Else
                UserDataList = UserService.getByName(name)
                ASPxGridView1.DataSource = UserService.getByName(name)  'here change to class list
                loadDataTable()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Dim _name1 As String

    ''' <summary>
    ''' Search By Name
    ''' Check Wheather User Already Open Account Or Not
    ''' </summary>
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click ' for search name
        _name1 = nametb.Text.Trim

        If _name1 = Nothing Then
            MyMessageBox.Show(Me, "Enter Name ...")
            Exit Sub
        End If
        _name_OA = _name1
        enableFormView() ' for readonly false
        findDataFromAccountDatabase(_name1)
    End Sub

    Dim IsVerifu As Boolean
    Dim verid As String

    ''' <summary>
    ''' Get Data From View
    ''' </summary>
    Private Sub GetDataFromView()
        'total in db 28
        newAccountfiles = New NewAccountClass
        '  verid = DateAndTime.Now.ToString("yyyy-MM-dd-hh-mm") + "_" + GetofficeId + GetuserID
        ' newAccountfiles.VirtualId = verid
        _accountNumber = acnotb.Text.Trim : newAccountfiles.accountnumber = acnotb.Text.Trim
        _reffNumber = reffNumberTb.Text.Trim : newAccountfiles.reffno = reffNumberTb.Text.Trim
        _PrNumber = TextBox1.Text.Trim : newAccountfiles.pr = TextBox1.Text.Trim
        _OpenDate = accountTb.Text.Trim : newAccountfiles.doo = accountTb.Text.Trim
        _AccountStatus = "Pending" : newAccountfiles.status = "Pending"
        _Name = nametb.Text.Trim : newAccountfiles.n_ame = nametb.Text.Trim
        _ModeOfOperation = Modetb.Text.Trim : newAccountfiles.acoperatemode = Modetb.Text.Trim
        _secondName = name2tb.Text.Trim : newAccountfiles.jointname = name2tb.Text.Trim
        _guardianName = GuardianNametb.Text.Trim : newAccountfiles.guardianname = GuardianNametb.Text.Trim
        _Photo = "" : newAccountfiles.photo = ""
        _sign = "" : newAccountfiles.sign = ""
        _cif = ciftb.Text.Trim : newAccountfiles.cif = ciftb.Text.Trim
        _fullName = NameInfo.Text.Trim : newAccountfiles.n_ame = NameInfo.Text.Trim
        _cifStatus = "Pending" ': newAccountfiles. = "Pending"
        _Dob = dobtb.Text.Trim : newAccountfiles.dob = dobtb.Text.Trim
        _gender = genderlb.Text.Trim : newAccountfiles.gender = genderlb.Text.Trim
        _MobileNumber = mobiletb.Text.Trim : newAccountfiles.mobile = mobiletb.Text.Trim
        _EmailId = emailtb.Text.Trim : newAccountfiles.email = emailtb.Text.Trim
        _Pan = pantb.Text.Trim : newAccountfiles.pan = pantb.Text.Trim
        _Adhar = adhartb.Text.Trim : newAccountfiles.adhar = adhartb.Text.Trim
        _Address = addresstb.Text : newAccountfiles.address = addresstb.Text
        _Relation = Relationtb.Text.Trim  'newAccountfiles.r = Relationtb.Text.Trim
        _product = ProductCb.Text.Trim : newAccountfiles.producttype = ProductCb.Text.Trim
        _term = Actermtb.Text.Trim : newAccountfiles.productterm = Actermtb.Text.Trim
        _Value = AccValuetb.Text.Trim : newAccountfiles.productvalue = AccValuetb.Text.Trim
        _nominiReg = nominiregcb.Text.Trim : newAccountfiles.nominireg = nominiregcb.Text.Trim
        _NominiName = NominiNameInfotb.Text.Trim : newAccountfiles.nomininame = NominiNameInfotb.Text.Trim
        _NominiRelation = NominiRelationInfotb.Text.Trim : newAccountfiles.nominirelation = NominiRelationInfotb.Text.Trim
        _NominiDOB = NominiAgeInfotb.Text.Trim : newAccountfiles.nominiage = NominiAgeInfotb.Text.Trim
        _NominiAddress = NominiAddressInfotb.Text.Trim : newAccountfiles.nominiaddress = NominiAddressInfotb.Text.Trim
    End Sub

    'Verify InPut Data
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

    'Send Data To Next Module For Print Page
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

    ''' <summary>
    ''' Submit Button Click
    ''' </summary>
    ''' <param name="sender">Not Required</param>
    ''' <param name="e">NA</param>
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'check
        VerifyInputData()
        ' InsertDataTransction()
        InsertData()
    End Sub

    Dim result As Boolean

    ''' <summary>
    ''' Logic To Insert Data To Database
    ''' </summary>
    Private Sub InsertData()

        result = newTransctionService.AddData(newAccountfiles)
        If result Then
            Errortb.Text = "Account Form Post Successfully ..."
            Button2.Enabled = True
        Else
            Errortb.Text = "Data Not Saved Successfully"
        End If
    End Sub

End Class