Imports System.Data.OleDb
Imports DevExpress.Web

Public Class journaltrns
    Inherits System.Web.UI.Page

    Dim logmsg As String ' = DateAndTime.Now.ToLongTimeString & "  : "
    Private Const UploadDirectory As String = "~/Developer/Data/"
    Dim resultFileUrl As String
    Dim resultFilePath As String

    Dim _acNo As String
    Dim _actype As String
    Dim _date As String
    Dim _name As String
    Dim deposit As String
    Dim withdrow As String
    Dim balance As String
    Dim dlt As String
    Dim remark As String

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
            Return datasetcifdb.Tables("Accesstrnsdetail")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("Accesstrnsdetail").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "transdetail" & "", databaseconnection1))
            dataadapter1.Fill(datasetcifdb, "Accesstrnsdetail")
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
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddatafromserver()
    End Sub

    Private Sub InsertDataIntoSqltransctiondb(ByVal i As Integer)
        Dim x As Integer
        For x = 0 To i - 1
            _acNo = ASPxGridView1.GetSelectedFieldValues("accountNumber")(x).ToString
            If Len(_acNo) > 2 Then
                '  _acNo = Regex.Replace(_acNo, "[^A-Za-z\-/]", "")
                _acNo = _acNo.Replace("ACNO-", "")
                _acNo = _acNo.Trim
            Else
                _acNo = ""
            End If
            _date = ASPxGridView1.GetSelectedFieldValues("d_ate")(x).ToString
            _actype = ASPxGridView1.GetSelectedFieldValues("AccountType")(x).ToString
            balance = ASPxGridView1.GetSelectedFieldValues("balance")(x).ToString
            _name = ASPxGridView1.GetSelectedFieldValues("AccountHolderName")(x).ToString
            deposit = ASPxGridView1.GetSelectedFieldValues("deposit")(x).ToString
            withdrow = ASPxGridView1.GetSelectedFieldValues("withdrow")(x).ToString
            dlt = ASPxGridView1.GetSelectedFieldValues("DLT")(x).ToString
            remark = ASPxGridView1.GetSelectedFieldValues("remark")(x).ToString
            logmsg = logmsg & timeme & " : Getting Data from DB Acno- " & _acNo.ToString() & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            Try
                If Len(_acNo) > 6 Then
                    'cifsearch(_cif)
                    '     dtrnsreportHelper(_acNo)
                    '    If dtrnsreportHelper.IsIdExistdlt(_acNo) = False Then
                    logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                    '       InsertIntoDB(_acNo, _dlt, _dlt1, _AccountBalance)
                Else
                    n += 1

                    logmsg = logmsg & timeme & " : Account Id Already Exist in Database  " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()
                End If
            Catch ex As Exception

            End Try

        Next

    End Sub

    Dim timeme As String = DateAndTime.Now.ToLongTimeString

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

End Class