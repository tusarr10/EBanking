Imports System.Data.OleDb
Imports DataBaseHelper

Public Class ssajournaltrns
    Inherits System.Web.UI.Page

    Private DataService As New AllJournalService(connectionstringaccount)
    Private JournalData As ssaJournalClass



    Dim logmsg As String
    ' for Calculation
    Dim _totaldata As String
    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer
    Dim timeme As String = DateAndTime.Now.ToLongTimeString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddatafromserver()
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
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
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Please Wait ..." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        InsertDataIntoSqltransctiondb(i)
        _totalSkip = y.ToString
        _totalinsert = z.ToString
        _exist = n.ToString
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "  Already Exist = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If
    End Sub
    Private Sub InsertDataIntoSqltransctiondb(i As Integer)
        'TODO
        'get Data From data Grid View

        '   Check validation 
        Dim x As Integer
        For x = 0 To i - 1
            JournalData = New ssaJournalClass
            JournalData.accountnumber = ASPxGridView1.GetSelectedFieldValues("ACNO")(x).ToString
            If Len(JournalData.accountnumber) > 2 Then
                '  _acNo = Regex.Replace(_acNo, "[^A-Za-z\-/]", "")
                JournalData.accountnumber = JournalData.accountnumber.Replace("ACNO-", "")
                JournalData.accountnumber = JournalData.accountnumber.Trim
            Else
                JournalData.accountnumber = ""
            End If
            JournalData.depositername = ASPxGridView1.GetSelectedFieldValues("Name")(x).ToString
            JournalData.da_te = ASPxGridView1.GetSelectedFieldValues("today")(x).ToString
            JournalData.bbt = ASPxGridView1.GetSelectedFieldValues("BBT")(x).ToString
            JournalData.transctiontype = ASPxGridView1.GetSelectedFieldValues("Transtype")(x).ToString
            If JournalData.da_te = "31 March 2021" Then
                JournalData.transctiontype = "Interest"
            Else
                JournalData.transctiontype = ASPxGridView1.GetSelectedFieldValues("Transtype")(x).ToString
            End If
            JournalData.amount = ASPxGridView1.GetSelectedFieldValues("Amount")(x).ToString
            JournalData.bat = ASPxGridView1.GetSelectedFieldValues("balance")(x).ToString
            JournalData.trid = ASPxGridView1.GetSelectedFieldValues("Notes")(x).ToString
            JournalData.Details = ASPxGridView1.GetSelectedFieldValues("m_onth")(x).ToString
            JournalData.fine = ASPxGridView1.GetSelectedFieldValues("fine")(x).ToString
            JournalData.status = "Approved"
            JournalData.office = OfficeName
            JournalData.u_ser = Getusername
            JournalData.Details = "Transfered"
            logmsg = logmsg & timeme & " : Inserting Data Please Wait.. " & JournalData.trid & " Account Number - " & JournalData.accountnumber & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            If Not DataService.IsTridExistInssaJournal(JournalData.trid) Then
                'TODO if transction Not Available then Insert Data
                Dim ii As Boolean
                ii = DataService.addToSsajournal(JournalData)
                If ii Then
                    z += 1
                    logmsg = logmsg & timeme & " : Data Saved Successfully.. " & JournalData.trid & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                Else
                    logmsg = logmsg & timeme & " : Data Not Saved " & JournalData.trid & " : " & Environment.NewLine
                    y += 1
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                End If
            Else
                'TODO if transction  Available then Check For Error in Trid 
                Dim iii As Boolean
                If Not DataService.IsDataExistInSsa(JournalData) Then
                    'todo if data duplicate not found then do Insert Data
                    iii = DataService.addToSsajournal(JournalData)
                    If iii Then
                        z += 1
                        logmsg = logmsg & timeme & " : Data Saved Successfully.. " & JournalData.accountnumber & Environment.NewLine & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                    Else
                        logmsg = logmsg & timeme & " : Data Not Saved " & JournalData.accountnumber & " : " & Environment.NewLine
                        y += 1
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                    End If
                Else
                    'Todo 
                    'Data Already Exist Just Show Message
                    n += 1
                    logmsg = logmsg & timeme & " : Teansction Id Already Exist in Database  " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                End If
            End If
        Next
    End Sub
    Protected Sub GridView_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)
    End Sub

    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("Accessssatr").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "SSAC" & "", databaseconnection1))
            dataadapter1.Fill(datasetcifdb, "Accessssatr")
            'ShowData(currentrow)
            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try
    End Sub

    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("Accessssatr")
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

End Class