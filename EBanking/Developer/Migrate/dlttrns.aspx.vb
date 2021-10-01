Imports System.Data.OleDb
Imports DevExpress.Web
Imports DataBaseHelper

Public Class dlttrns
    Inherits System.Web.UI.Page

    Private dltdata As dltClass
    Private dltService As New dltService(connectionstringaccount)

    Dim logmsg As String ' = DateAndTime.Now.ToLongTimeString & "  : "
    Private Const UploadDirectory As String = "~/Developer/Data/"
    Dim resultFileUrl As String
    Dim resultFilePath As String

    Dim _acNo As String
    Dim _dlt As String
    Dim _dlt1 As String

    ' Dim _nominireg As String
    ' Dim _acctype As String
    '  Dim _GuardianName As String
    Dim _AccountBalance As String

    ' Dim _nomininame As String

    ' for Calculation
    Dim _totaldata As String

    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer

    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("AccessDLT")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("AccessDLT").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "sbbal" & "", databaseconnection1))

            dataadapter1.Fill(datasetcifdb, "AccessDLT")
            'ShowData(currentrow)

            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try

    End Sub

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddatafromserver()
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
            _dlt = ASPxGridView1.GetSelectedFieldValues("DLT")(x).ToString
            Try
                Dim xy As String
                xy = _dlt 'datetb.Text '.ToString("dd MMMM yyyy")
                Dim newDate As Date = DateTime.ParseExact(xy, "dd MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
                _dlt = newDate.ToString("yyyy-MM-dd")
            Catch ex As Exception
                Try
                    Dim xy As String
                    xy = _dlt 'datetb.Text '.ToString("dd MMMM yyyy")
                    Dim newDate As Date = DateTime.ParseExact(xy, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    _dlt = newDate.ToString("yyyy-MM-dd")
                Catch exx As Exception

                End Try
            End Try
            _dlt1 = ASPxGridView1.GetSelectedFieldValues("DLT2")(x).ToString ' For cif
            Try
                Dim xy As String
                xy = _dlt1  'datetb.Text '.ToString("dd MMMM yyyy")
                Dim newDate As Date = DateTime.ParseExact(xy, "dd MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
                _dlt1 = newDate.ToString("yyyy-MM-dd")
            Catch ex As Exception
                Try
                    Dim xy As String
                    xy = _dlt1 'datetb.Text '.ToString("dd MMMM yyyy")
                    Dim newDate As Date = DateTime.ParseExact(xy, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    _dlt1 = newDate.ToString("yyyy-MM-dd")
                Catch exx As Exception

                End Try
            End Try
            _AccountBalance = ASPxGridView1.GetSelectedFieldValues("Acbal")(x).ToString
            logmsg = logmsg & timeme & " : Getting Data from DB Acno- " & _acNo.ToString() & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            Try
                If Len(_acNo) > 6 Then
                    'cifsearch(_cif)
                    ' DLTACCOUNTSEARCH(_acNo)
                    If Not dltService.IsDltExist(_acNo) Then
                        logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                        InsertIntoDB(_acNo, _dlt, _dlt1, _AccountBalance)
                    Else

                        logmsg = logmsg & timeme & " : Account Id Already Exist in Database  " & Environment.NewLine & timeme & "Trying To Update Data For AccountNumber - " & _acNo & " ..." & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                        'Logic For Update Data 
                        UpdatetIntoDB(_acNo, _dlt, _dlt1, _AccountBalance)
                    End If
                Else
                    y += 1
                    logmsg = logmsg & timeme & " : Account ID Does Not Correct For Name - " & _acNo & " ... " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()

                End If
            Catch ex As Exception

            End Try

        Next

    End Sub

    Private Sub UpdatetIntoDB(acNo As String, dlt As String, dlt1 As String, accountBalance As String)
        dltdata = New dltClass
        dltdata.accountnumber = _acNo
        dltdata.accountbalance = _AccountBalance
        dltdata.dlt = _dlt
        dltdata.dlt2 = _dlt1

        Dim i As Boolean
        i = dltService.Updatedlt(dltdata)


        Try
            'Dim cmdstr As String
            'cmdstr = "insert into dlt(accountnumber , accountbalance ,dlt ,dlt2)values('" & _acNo & "','" & _AccountBalance & "','" & _dlt & "','" & _dlt1 & "')"
            'databaseconnection = New SqlConnection(connectionhelper.connectionstringaccount())
            'datacommand = New SqlCommand(cmdstr, databaseconnection)
            'databaseconnection.Open()
            'Dim i
            'i = datacommand.ExecuteNonQuery()
            If i Then
                logmsg = logmsg & timeme & " :  Record successfully Update .." & Environment.NewLine & Environment.NewLine
                n += 1
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            Else
                logmsg = logmsg & timeme & " : Record Not Update " & Environment.NewLine & Environment.NewLine
                y += 1
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertIntoDB(_acNo As String, _dlt As String, _dlt1 As String, _AccountBalance As String)

        dltdata = New dltClass
        dltdata.accountnumber = _acNo
        dltdata.accountbalance = _AccountBalance
        dltdata.dlt = _dlt
        dltdata.dlt2 = _dlt1

        Dim i As Boolean
        i = dltService.AddCustmor(dltdata)


        Try
            'Dim cmdstr As String
            'cmdstr = "insert into dlt(accountnumber , accountbalance ,dlt ,dlt2)values('" & _acNo & "','" & _AccountBalance & "','" & _dlt & "','" & _dlt1 & "')"
            'databaseconnection = New SqlConnection(connectionhelper.connectionstringaccount())
            'datacommand = New SqlCommand(cmdstr, databaseconnection)
            'databaseconnection.Open()
            'Dim i
            'i = datacommand.ExecuteNonQuery()
            If i Then
                logmsg = logmsg & timeme & " :  Record successfully saved .." & Environment.NewLine & Environment.NewLine
                z += 1
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            Else
                logmsg = logmsg & timeme & " : Record Not saved " & Environment.NewLine & Environment.NewLine
                y += 1
                ASPxMemo1.Text = logmsg
                UPN1.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn2_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Try
            i = ASPxGridView1.Selection.Count
            If i < 1 Then
                logmsg = timeme & " : Select At Least 1 Row to Transfer ...."
                ASPxMemo1.Text = logmsg
                UPN1.Update()
                Exit Sub
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
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "  Total Update = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If
    End Sub

End Class