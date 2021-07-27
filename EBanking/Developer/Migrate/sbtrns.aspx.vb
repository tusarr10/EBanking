Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports DevExpress.Web

Public Class sbtrns
    Inherits System.Web.UI.Page

    Dim logmsg As String ' = DateAndTime.Now.ToLongTimeString & "  : "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddatafromserver()

        If Page.IsPostBack Then
            '     Notes.Text = logmsg

        End If

    End Sub

    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("AccessCif").Clear()

        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "Custmor" & "", databaseconnection1))

            dataadapter1.Fill(datasetcifdb, "AccessCif")
            'ShowData(currentrow)

            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try


    End Sub
    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("AccessCif")
        Catch ex As Exception
            Return Nothing
        End Try
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

        End Try
    End Sub
    Dim _acNo As String
    Dim _name As String
    Dim _cif As String
    Dim _Producttype As String
    Dim _nominireg As String
    Dim _acctype As String
    Dim _GuardianName As String
    Dim _AccountBalance As String
    Dim _nomininame As String

    ' for Calculation 
    Dim _totaldata As String
    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer

    Private Sub InsertIntoDB(ByVal acNo As String, ByVal cif As String, ByVal name As String, ByVal producttype As String, ByVal nominireg As String, ByVal acctype As String, ByVal guardianName As String, ByVal accountBalance As String, ByVal nomininame As String)
        Dim cmdstr As String
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
                command.CommandText = "insert into " & liveAccountTable & "(accountnumber,cif,n_ame,producttype,nominireg,acctype,guardianname,balance,status)values('" & acNo & "','" & cif & "','" & name & "','" & producttype & "','" & nominireg & "','" & acctype & "','" & guardianName & "','" & accountBalance & "','Pending')"
                command.ExecuteNonQuery()


                command.CommandText = "  insert into " & nominitable & " (accountnumber,nominireg,nomininame )values ('" & acNo & "','" & nominireg & "','" & nomininame & "')" 'insert into nominiinfo
                command.ExecuteNonQuery()

                command.CommandText = "  insert into " & productTypeTable & " (accountnumber , type )values('" & acNo & "','" & producttype & "')" ' Insert inTo product type
                command.ExecuteNonQuery()

                command.CommandText = "insert into " & accountOperateTable & " (accountnumber ,accountoperatemode,guardianname )values('" & acNo & "','" & acctype & "','" & guardianName & "')" 'insert into account type
                command.ExecuteNonQuery()
                'try to commite the transction
                transction.Commit()
                '  MyMessageBox.Show(Me, "Data Saved Successfully")
                z += 1

                logmsg = logmsg & timeme & " : Data Saved Successfully.. " & acNo & Environment.NewLine & Environment.NewLine
                ASPxMemo1.Text = logmsg
                UPN1.Update()


            Catch ex As Exception

                logmsg = logmsg & timeme & " : Commit Exception Type: {0}" + ex.Message() & " Message: {0}" & Environment.NewLine
                ASPxMemo1.Text = logmsg
                UPN1.Update()
                Try
                    transction.Rollback()
                    logmsg = logmsg & timeme & " : Data Not Saved " & acNo & " : " & Environment.NewLine
                    y += 1
                    ASPxMemo1.Text = logmsg
                UPN1.Update()
                Catch ex2 As Exception
                    logmsg = logmsg & timeme & " : Rollback Exception Type: {0}" + ex2.Message() & " Message: {0}" & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                End Try

            End Try
        Catch ex As Exception

        End Try
        Try
            databaseconnection.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub InsertDataIntoSqlCIFDB(ByVal i As Integer)
        Dim x As Integer


        For x = 0 To i - 1
            _acNo = ASPxGridView1.GetSelectedFieldValues("AcNo")(x).ToString
            If Len(_acNo) > 2 Then
                '  _acNo = Regex.Replace(_acNo, "[^A-Za-z\-/]", "")
                _acNo = _acNo.Replace("ACNO-", "")
                _acNo = _acNo.Trim
            Else
                _acNo = ""
            End If
            _name = ASPxGridView1.GetSelectedFieldValues("CustmorName")(x).ToString
            _cif = ASPxGridView1.GetSelectedFieldValues("Email")(x).ToString ' For cif
            If Len(_cif) > 2 Then
                _cif = _cif
            Else
                _cif = Nothing
            End If
            _Producttype = ASPxGridView1.GetSelectedFieldValues("AcType")(x).ToString 'for account type
            If _Producttype = "Saving Account" Then
                _Producttype = "Saving"
            ElseIf _Producttype = "Requiring Deposit" Then
                _Producttype = "RD"
            ElseIf _Producttype = "SS Account" Then
                _Producttype = "SSA"
            ElseIf _Producttype = "Time Deposit" Then
                _Producttype = "TD"
            Else
                _Producttype = _Producttype
            End If

            _nominireg = ASPxGridView1.GetSelectedFieldValues("NominiName")(x).ToString
            If Len(_nominireg) > 4 Then
                _nomininame = _nominireg
                _nominireg = "Yes"
            ElseIf Len(_nominireg) < 4 Then
                If _nominireg = "Y" Or _nominireg = "y" Then
                    _nominireg = "Yes"
                    _nomininame = Nothing
                Else
                    _nominireg = "No"
                    _nomininame = Nothing
                End If
            Else
                _nominireg = "No"
                _nomininame = Nothing
            End If
            _acctype = ASPxGridView1.GetSelectedFieldValues("Notes")(x).ToString
            If _acctype = "MINOR" Or _acctype = "M/A" Or _acctype = "m/a" Then
                _acctype = "Minor"
            ElseIf _acctype = "JOINT B" Or _acctype = "JB" Then
                _acctype = "JointB"
            Else
                _acctype = "Self"
            End If
            _GuardianName = ASPxGridView1.GetSelectedFieldValues("FatherName")(x).ToString

            _AccountBalance = ASPxGridView1.GetSelectedFieldValues("AcBal")(x).ToString

            logmsg = logmsg & timeme & " : Getting Data from DB Acno- " & _acNo.ToString() & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            Try
                If Len(_acNo) > 6 Then
                    'cifsearch(_cif)
                    AccountSearch(_acNo)
                    If AddAccountHelper.IsAccountIdExist(_acNo) = False Then
                        logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                        InsertIntoDB(_acNo, _cif, _name, _Producttype, _nominireg, _acctype, _GuardianName, _AccountBalance, _nomininame)
                    Else
                        n += 1

                        logmsg = logmsg & timeme & " : Account Id Already Exist in Database  " & Environment.NewLine & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                    End If
                Else
                    y += 1
                    logmsg = logmsg & timeme & " : Account ID Does Not Correct For Name - " & _name & " ... " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()

                End If
            Catch ex As Exception

            End Try

        Next

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
    Protected Sub btn1_Click(sender As Object, e As EventArgs)
        logmsg = Nothing

    End Sub
    Dim timeme As String = DateAndTime.Now.ToLongTimeString

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

        InsertDataIntoSqlCIFDB(i)

        _totalSkip = y.ToString
        _totalinsert = z.ToString
        _exist = n.ToString
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "  Already Exist = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If
    End Sub
End Class