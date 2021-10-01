Imports System.Data.OleDb
Imports DevExpress.Web
Imports DataBaseHelper

Public Class newactrns
    Inherits System.Web.UI.Page

    Private NewAcService As New newAccountService(connectionstringaccount)
    Private newAcClass As NewAccountClass
    Private newAcTrService As New newAccountTransctionService(connectionstringaccount)
    Private journalService As New AllJournalService(connectionstringaccount)
    Private JournalData As allJournalClass
    Dim logmsg As String ' = DateAndTime.Now.ToLongTimeString & "  : "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddatafromserver()
    End Sub

    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("Accessnewac").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "New_ac" & "", databaseconnection1))

            dataadapter1.Fill(datasetcifdb, "Accessnewac")
            'ShowData(currentrow)

            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try

    End Sub
    Function GetTrId(reff As String) As String
        Try
            datasetcifdb.Tables("Accesstrid").Clear()
        Catch
        End Try
        Dim Str1 As String = Nothing
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "CMB" & "", databaseconnection1))

            dataadapter1.Fill(datasetcifdb, "Accesstrid")
            'ShowData(currentrow)

            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try
        Try
            Dim Str As String
            Dim i As Integer

            Str = reff ' searchciftb.Text
            i = 0
            While i <> datasetcifdb.Tables("Accesstrid").Rows.Count
                Str1 = CType(datasetcifdb.Tables("Accesstrid").Rows(i)("ACNO"), String)

                If Str = Str1 Then
                    Return CType(datasetcifdb.Tables("Accesstrid").Rows(i)("Notes"), String)

                End If
                i += 1

            End While


            '  Str1 = CType(datasetcifdb.Tables("Accesstrid").Rows(0)("Notes"), String)
        Catch ex As Exception

        End Try
        Return Str1
    End Function

    Private Const UploadDirectory As String = "~/Developer/Data/"
    Dim resultFileUrl As String
    Dim resultFilePath As String

    Sub loaddatafromserver()
        Try

            resultFileUrl = UploadDirectory & "Database1.accdb"
            resultFilePath = MapPath(resultFileUrl)

            LoadCiffromdb()
            Dim table As DataTable
            table = getCifAccessDataTable()
            ASPxGridView1.DataSource = table
            ASPxGridView1.DataBind()
        Catch ex As Exception
            MyMessageBox.Show(Me, ex.Message)
        End Try
    End Sub

    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("Accessnewac")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Dim _acNo As String
    Dim _name As String
    Dim _cif As String
    Dim _Gname As String
    Dim _date As String
    Dim _address As String
    Dim _dob As String
    Dim _adhar As String
    Dim _pan As String
    Dim _nomini As String '10
    Dim _gender As String
    Dim _actype As String
    Dim _note As String
    Dim _amount As String
    Dim _reff As String
    Dim _mobile As String
    Dim _rcno As String


    ' for Calculation
    Dim _totaldata As String

    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer

    Dim timeme As String = DateAndTime.Now.ToLongTimeString

    'ok
    Private Sub InsertDataIntoSqlnewactrns(ByVal i As Integer)
        Dim x As Integer

        For x = 0 To i - 1
            _acNo = ASPxGridView1.GetSelectedFieldValues("ACNO")(x).ToString
            If Len(_acNo) > 2 Then
                _acNo = _acNo.Replace("ACNO-", "")
                _acNo = _acNo.Trim
            Else
                _acNo = Nothing

            End If
            newAcClass = New NewAccountClass
            newAcClass.accountnumber = _acNo
            _name = ASPxGridView1.GetSelectedFieldValues("N_AME")(x).ToString
            newAcClass.n_ame = _name
            _cif = ASPxGridView1.GetSelectedFieldValues("CIF")(x).ToString
            newAcClass.cif = _cif
            _Gname = ASPxGridView1.GetSelectedFieldValues("FNAME")(x).ToString
            newAcClass.guardianname = _Gname
            _date = ASPxGridView1.GetSelectedFieldValues("D_ATE")(x).ToString
            Try
                Dim xy As String
                xy = _date 'datetb.Text '.ToString("dd MMMM yyyy")
                Dim newDate As Date = DateTime.ParseExact(xy, "dd MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
                _date = newDate.ToString("yyyy-MM-dd")
            Catch ex As Exception
                Try
                    Dim xy As String
                    xy = _date 'datetb.Text '.ToString("dd MMMM yyyy")
                    Dim newDate As Date = DateTime.ParseExact(xy, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    _date = newDate.ToString("yyyy-MM-dd")
                Catch exx As Exception

                End Try
            End Try
            newAcClass.doo = _date
            _address = ASPxGridView1.GetSelectedFieldValues("aDDRESS")(x).ToString
            newAcClass.address = _address
            _dob = ASPxGridView1.GetSelectedFieldValues("dob")(x).ToString
            newAcClass.dob = _dob
            _adhar = ASPxGridView1.GetSelectedFieldValues("aDHAR")(x).ToString
            newAcClass.adhar = _adhar
            _pan = ASPxGridView1.GetSelectedFieldValues("PAN")(x).ToString
            newAcClass.pan = _pan
            _nomini = ASPxGridView1.GetSelectedFieldValues("NOMINI")(x).ToString '10
            newAcClass.nomininame = _nomini
            If Len(_nomini) > 3 Or _nomini = "Y" Or _nomini = "Yes" Then
                newAcClass.nominireg = "Yes"
            Else
                newAcClass.nominireg = "No"
            End If
            _gender = ASPxGridView1.GetSelectedFieldValues("GENDER")(x).ToString
            newAcClass.gender = _gender
            _actype = ASPxGridView1.GetSelectedFieldValues("ACTYPE")(x).ToString
            If _actype = "Requiring Deposit" Then
                _actype = "RD"
            ElseIf _actype = "Time Deposit" Then
                _actype = "TD"
            ElseIf _actype = "SS Account" Then
                _actype = "SSA"
            Else
                _actype = "Saving"
            End If
            newAcClass.producttype = _actype
            _note = ASPxGridView1.GetSelectedFieldValues("NOTES")(x).ToString
            If _note = "m/a" Or _note = "MINOR" Then
                _note = "Minor"
            Else
                _note = "Self"
            End If
            newAcClass.status = "Pending"
            newAcClass.acoperatemode = _note
            _amount = ASPxGridView1.GetSelectedFieldValues("AMOUNT")(x).ToString
            newAcClass.balance = _amount
            _reff = ASPxGridView1.GetSelectedFieldValues("rEFF_NO")(x).ToString
            newAcClass.reffno = _reff
            _mobile = ASPxGridView1.GetSelectedFieldValues("mobile")(x).ToString
            newAcClass.mobile = _mobile
            _rcno = ASPxGridView1.GetSelectedFieldValues("recno")(x).ToString
            newAcClass.pr = _rcno
            logmsg = logmsg & timeme & " : Getting Data from DB Reff No- " & _reff.ToString() & Environment.NewLine
            Try
                newAcClass.trid = GetTrId(_reff)
            Catch ex As Exception
                logmsg = logmsg & timeme & " : Unable to Get Trid Data from DB Reff No- " & _reff.ToString() & Environment.NewLine
            End Try

            ASPxMemo1.Text = logmsg
            UPN1.Update()



            If Len(_reff) > 2 Then
                If Not NewAcService.IsReffNoExistInNewAccount(_reff) Then
                    'Do Insert login
                    logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                    InsertIntoDB(newAcClass)
                Else
                    'do Update Login
                    logmsg = logmsg & timeme & " : Account Id Already Exist in Database  " & Environment.NewLine & timeme & " : Trying to Update Reff Number " & _reff & " Please Wait ..... " & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                    UpdateIntoDB(newAcClass)
                End If
            Else
                y += 1
                logmsg = logmsg & timeme & " : Reff No Does Not Exist For Name - " & _name & " ... " & Environment.NewLine & Environment.NewLine
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            End If
        Next
    End Sub

    Private Sub UpdateIntoDB(newAcClass As NewAccountClass)
        Dim i As Boolean
        i = newAcTrService.UpdateData(newAcClass)
        If i Then
            y += 1
            logmsg = logmsg & timeme & " : Updated account Number and cif and trid for reff No - " & newAcClass.reffno & " ... " & Environment.NewLine & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
        Else
            logmsg = logmsg & timeme & " : Data Not Updated " & newAcClass.reffno & " : " & Environment.NewLine
            y += 1
            ASPxMemo1.Text = logmsg
            UPN1.Update()
        End If

    End Sub

    Private Sub InsertIntoDB(newAcClass As NewAccountClass)
        Dim i As Boolean
        i = newAcTrService.AddData(newAcClass)
        If i Then
            z += 1
            logmsg = logmsg & timeme & " : Data Saved Successfully.. " & newAcClass.reffno & Environment.NewLine & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
        Else
            logmsg = logmsg & timeme & " : Data Not Saved " & newAcClass.reffno & " : " & Environment.NewLine
            y += 1
            ASPxMemo1.Text = logmsg
            UPN1.Update()
        End If
    End Sub

    Protected Sub btn2_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Try
            i = ASPxGridView1.Selection.Count
            If i < 1 Then
                ASPxMemo1.Text = timeme & " : Select At Least 1 Row to Transfer ...."
            End If
            _totaldata = i.ToString
        Catch ex As Exception
            Exit Sub
        End Try
        logmsg = Nothing
        y = 0
        z = 0
        n = 0

        InsertDataIntoSqlnewactrns(i)

        _totalSkip = y.ToString
        _totalinsert = z.ToString
        _exist = n.ToString
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "  Already Exist = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If
    End Sub

    Protected Sub GridView_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs)

        Dim i As Integer
        Try
            i = ASPxGridView1.Selection.Count
        Catch ex As Exception
            Exit Sub
        End Try
        If e.Parameters = "view" Then

        End If
        If e.Parameters = "Send" Then

        End If
        If e.Parameters = "SendAll" Then

        End If
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Try
            i = ASPxGridView1.Selection.Count
            If i < 1 Then
                ASPxMemo1.Text = timeme & " : Select At Least 1 Row to Transfer ...."
            End If
            _totaldata = i.ToString
        Catch ex As Exception
            Exit Sub
        End Try
        logmsg = Nothing
        y = 0
        z = 0
        n = 0

        UpdateDataIntoSqlnewactrns(i)

        _totalSkip = y.ToString
        _totalinsert = z.ToString
        _exist = n.ToString
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "  Already Exist = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If

    End Sub

    Private Sub UpdateDataIntoSqlnewactrns(i As Integer)
        Dim x As Integer
        For x = 0 To i - 1
            _acNo = ASPxGridView1.GetSelectedFieldValues("ACNO")(x).ToString
            If Len(_acNo) > 2 Then
                _acNo = _acNo.Replace("ACNO-", "")
                _acNo = _acNo.Trim
            Else
                _acNo = Nothing

            End If
            newAcClass = New NewAccountClass
            JournalData = New allJournalClass
            newAcClass.accountnumber = _acNo
            _name = ASPxGridView1.GetSelectedFieldValues("N_AME")(x).ToString
            newAcClass.n_ame = _name
            JournalData.na_me = _name
            _cif = ASPxGridView1.GetSelectedFieldValues("CIF")(x).ToString
            newAcClass.cif = _cif
            _Gname = ASPxGridView1.GetSelectedFieldValues("FNAME")(x).ToString
            newAcClass.guardianname = _Gname
            _date = ASPxGridView1.GetSelectedFieldValues("D_ATE")(x).ToString
            newAcClass.doo = _date
            JournalData.da_te = _date
            _address = ASPxGridView1.GetSelectedFieldValues("aDDRESS")(x).ToString
            newAcClass.address = _address
            _dob = ASPxGridView1.GetSelectedFieldValues("dob")(x).ToString
            newAcClass.dob = _dob
            _adhar = ASPxGridView1.GetSelectedFieldValues("aDHAR")(x).ToString
            newAcClass.adhar = _adhar
            _pan = ASPxGridView1.GetSelectedFieldValues("PAN")(x).ToString
            newAcClass.pan = _pan
            _nomini = ASPxGridView1.GetSelectedFieldValues("NOMINI")(x).ToString '10
            newAcClass.nomininame = _nomini
            If Len(_nomini) > 3 Or _nomini = "Y" Or _nomini = "Yes" Then
                newAcClass.nominireg = "Yes"
            Else
                newAcClass.nominireg = "No"
            End If
            _gender = ASPxGridView1.GetSelectedFieldValues("GENDER")(x).ToString
            newAcClass.gender = _gender
            _actype = ASPxGridView1.GetSelectedFieldValues("ACTYPE")(x).ToString
            If _actype = "Requiring Deposit" Then
                _actype = "RD"
            ElseIf _actype = "Time Deposit" Then
                _actype = "TD"
            ElseIf _actype = "SS Account" Then
                _actype = "SSA"
            Else
                _actype = "Saving"
            End If
            newAcClass.producttype = _actype
            JournalData.accounttype = _actype
            _note = ASPxGridView1.GetSelectedFieldValues("NOTES")(x).ToString
            If _note = "m/a" Or _note = "MINOR" Then
                _note = "Minor"
            Else
                _note = "Self"
            End If
            newAcClass.status = "Pending"
            newAcClass.acoperatemode = _note
            _amount = ASPxGridView1.GetSelectedFieldValues("AMOUNT")(x).ToString
            newAcClass.balance = _amount
            JournalData.deposit = _amount
            JournalData.balance = _amount
            JournalData.withdraw = "00"
            JournalData.dlt = "New Account"
            JournalData.status = "Approved"
            JournalData.office = OfficeName
            JournalData.u_ser = Getusername
            _reff = ASPxGridView1.GetSelectedFieldValues("rEFF_NO")(x).ToString
            newAcClass.reffno = _reff
            JournalData.accountnumber = _reff
            _mobile = ASPxGridView1.GetSelectedFieldValues("mobile")(x).ToString
            newAcClass.mobile = _mobile
            _rcno = ASPxGridView1.GetSelectedFieldValues("recno")(x).ToString
            newAcClass.pr = _rcno
            logmsg = logmsg & timeme & " : Getting Data from DB Reff No- " & _reff.ToString() & Environment.NewLine
            Try
                newAcClass.trid = GetTrId(_reff)
                JournalData.trid = newAcClass.trid
            Catch ex As Exception
                logmsg = logmsg & timeme & " : Unable to Get Trid Data from DB Reff No- " & _reff.ToString() & Environment.NewLine
            End Try

            ASPxMemo1.Text = logmsg
            UPN1.Update()
            'Logic to Update transctionin Journal Database
            'check is trid exist
            If Not journalService.IsTridExistInJournal(newAcClass.trid) Then
                Dim ii As Boolean
                ii = journalService.addToJournal(JournalData)
                If ii Then
                    z += 1
                    logmsg = logmsg & timeme & " : Data Saved Successfully.. " & newAcClass.reffno & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                Else
                    logmsg = logmsg & timeme & " : Data Not Saved " & newAcClass.reffno & " : " & Environment.NewLine
                    y += 1
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                End If
            Else
                y += 1
                logmsg = logmsg & timeme & " : Trid No Does Not Exist For Name - " & _name & " ... " & Environment.NewLine & Environment.NewLine
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            End If

        Next

    End Sub
End Class