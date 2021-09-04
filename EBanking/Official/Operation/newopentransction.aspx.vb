Imports DataBaseHelper

Public Class newopentransction
    Inherits System.Web.UI.Page

    Private DataFile As NewAccountClass
    Private newService As New newAccountService(connectionstringaccount)
    Private newtransctionService As New newAccountTransctionService(connectionstringaccount)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Private Sub getdataFromDB(data As NewAccountClass) '31
    '    '1
    '    getAccountData.VertualId = data.VirtualId 'getNewAccountVirtualid(row)
    '    getAccountData.cif = data.cif 'getNewAccountcif(row)
    '    getAccountData.accountnumber = data.accountnumber ' getNewAccountacno(row)
    '    getAccountData.name = data.n_ame 'getNewAccountName(row)
    '    getAccountData.producttype1 = data.producttype ' getNewAccountproducttype(row)
    '    getAccountData.productterm = data.productterm ' getNewAccountProductTerm(row)
    '    getAccountData.productvalue = data.productvalue ' getNewAccountProductValue(row)
    '    getAccountData.nomini = data.nominireg ' getNewAccountNominiReg(row)
    '    getAccountData.nomininame = data.nomininame ' getNewAccountNominiName(row)
    '    getAccountData.nominiage = data.nominiage ' getNewAccountNominiAge(row)
    '    '11
    '    getAccountData.nominiaddress = data.nominiaddress ' getNewAccountNominiaddress(row)
    '    getAccountData.nominirelation = data.nominirelation ' getNewAccountNominiRelation(row)
    '    getAccountData.acoperatemode = data.acoperatemode ' getNewAccountMOP(row)
    '    getAccountData.guardianname = data.guardianname ' getNewAccountguardianname(row)
    '    getAccountData.jointname = data.jointname ' getNewAccountJointName(row)
    '    getAccountData.relation = ""
    '    getAccountData.acstatus = data.status ' getAccountStatus(row)
    '    getAccountData.address = data.address ' getNewAccountAddress(row)
    '    getAccountData.mobile = data.mobile ' getNewAccountmobile(row)
    '    getAccountData.email = data.email ' getNewAccountEmail(row)
    '    '21
    '    getAccountData.dob = data.dob ' getNewAccountdob(row)
    '    getAccountData.gender = data.gender ' getNewAccountgender(row)
    '    getAccountData.adhar = data.adhar ' getNewAccountadhar(row)
    '    getAccountData.pan = data.pan ' getNewAccountpan(row)
    '    getAccountData.photo = data.photo ' getNewAccountphoto(row)
    '    getAccountData.sign = data.sign ' getNewAccountsign(row)
    '    getAccountData.doo = data.doo ' getNewAccountdoo(row)
    '    getAccountData.reffno = data.reffno ' getNewAccountreffno(row)
    '    getAccountData.pr = data.pr 'getNewAccountpr(row)
    '    getAccountData.balance = data.balance ' getNewAccountbalance(row)
    '    '31
    '    getAccountData.trid = data.trid ' getNewAccounttrid(row)

    'End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'getdata Function
        newOpenAccountSearch(reffNumberTb.Text.Trim)
        ' getdataFromDB()
        'print
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('../Print/OpenAccountCheck.aspx','_newtab');", True)
        'then
        Button2.Enabled = True

    End Sub

    Dim cs As String = connectionhelper.connectionstringaccount()

    ''' <summary>
    ''' Logic For Insert/Update Data In Database
    ''' </summary>
    Private Sub updateDataInOpenAccount()
        'TODO
        'Update transctionJournal
        DataFile = New NewAccountClass
        DataFile = newService.getByReffNo(reffNumberTb.Text.Trim)
        Dim datafile2 = New allJournalClass

        'For update data in New Account Class
        DataFile.trid = tridtb.Text.Trim
        DataFile.balance = amounttb.Text.Trim

        'For insert data in all Journal
        datafile2.da_te = datetb.Text.Trim
        datafile2.accounttype = DataFile.producttype
        datafile2.accountnumber = DataFile.accountnumber
        datafile2.na_me = DataFile.n_ame
        datafile2.deposit = amounttb.Text.Trim
        datafile2.withdraw = "00"
        datafile2.dlt = "New Account"
        datafile2.trid = DataFile.trid
        datafile2.balance = DataFile.balance
        datafile2.status = "Approved"
        datafile2.office = OfficeName
        datafile2.u_ser = Getusername

        Dim matchingtext As String = DataFile.status
        If Not matchingtext = "Pending" Then
            MyMessageBox.Show(Me, "Already Payment Done And Status = " & matchingtext)
            Button3.Enabled = True
            Exit Sub
        End If
        'Implement Verification
        If datafile2.deposit IsNot Nothing Then
            'TODO
            'Update Balance , status ,trid where reffno =xx
            'insert data in to journal ..

            Dim Result As Boolean
            Result = newtransctionService.AddTransction(DataFile, datafile2)

            If Result Then
                MyMessageBox.Show(Me, "Data Saved Successfully")
            Else
                MyMessageBox.Show(Me, "Data Not Saved Successfully")
            End If
        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If

        '*************END***************
        Button3.Enabled = True

    End Sub

    ''' <summary>
    ''' Button Click For Update Balance And Transction Report
    ''' </summary>
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updateDataInOpenAccount()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MyMessageBox.Show(Me, "Successfully Done ")
    End Sub

    Dim row As Integer = 0

    ''' <summary>
    ''' get Data from DataBase By Its ReffNo
    ''' </summary>
    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Try
            DataFile = New NewAccountClass
            DataFile = newService.getByReffNo(reffNumberTb.Text.Trim)
            ' newOpenAccountSearch(reffNumberTb.Text.Trim)
            fullnametb.Text = DataFile.n_ame ' getNewAccountName(row)
            datetb.Text = DataFile.doo ' getNewAccountdoo(row)
        Catch ex As Exception

        End Try
    End Sub

    Dim _name1 As String

    Private Sub findDataFromAccountDatabase(ByVal name1 As String)
        Try
            ' newaccounthelper.NewAccountNameSearch(name1)

            BootstrapGridView1.DataSource = newService.getByName(name1) 'getNewAccountOpenDataTable()
            BootstrapGridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Try
            ' for search name
            _name1 = nametb.Text.Trim
            If _name1 = Nothing Then
                MyMessageBox.Show(Me, "Enter Name ...")
                Exit Sub

            End If

            findDataFromAccountDatabase(_name1)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ASPxGridView1_Init(sender As Object, e As EventArgs)
        Try
            ' for search name
            _name1 = nametb.Text.Trim
            If _name1 = Nothing Then

                Exit Sub

            End If

            findDataFromAccountDatabase(_name1)
        Catch ex As Exception

        End Try
    End Sub

End Class