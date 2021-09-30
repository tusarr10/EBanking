Imports System.Data.OleDb
Imports DevExpress.Web
Imports DataBaseHelper

Public Class CifTrns
    Inherits System.Web.UI.Page
    Private CifService As New ClassCifService(connectionstringaccount)
    Private CifData As ClassCif

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

    Dim _name As String
    Dim _cif As String
    Dim _mobile As String
    Dim _pan As String
    Dim _adhar As String
    Dim _address As String
    Dim _dob As String
    Dim _gender As String

    Dim _totaldata As String
    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer

    Private Sub InsertDataIntoSqlCIFDB(ByVal i As Integer)
        Dim x As Integer

        For x = 0 To i - 1
            _name = ASPxGridView1.GetSelectedFieldValues("CustmorName")(x).ToString
            _cif = ASPxGridView1.GetSelectedFieldValues("Email")(x).ToString
            _mobile = ASPxGridView1.GetSelectedFieldValues("MobileNo")(x).ToString
            _pan = ASPxGridView1.GetSelectedFieldValues("PAN")(x).ToString
            _adhar = ASPxGridView1.GetSelectedFieldValues("Adhar")(x).ToString
            _address = ASPxGridView1.GetSelectedFieldValues("Address")(x).ToString
            _dob = ASPxGridView1.GetSelectedFieldValues("DOB")(x).ToString
            Try
                Dim xy As String
                xy = _dob 'datetb.Text '.ToString("dd MMMM yyyy")
                Dim newDate As Date = DateTime.ParseExact(xy, "dd MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
                _dob = newDate.ToString("yyyy-MM-dd")
            Catch ex As Exception
                Try
                    Dim xy As String
                    xy = _dob 'datetb.Text '.ToString("dd MMMM yyyy")
                    Dim newDate As Date = DateTime.ParseExact(xy, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    _dob = newDate.ToString("yyyy-MM-dd")
                Catch exx As Exception

                End Try
            End Try
            _gender = ASPxGridView1.GetSelectedFieldValues("Gender")(x).ToString
            logmsg = logmsg & timeme & " : Getting Data from DB CIF- " & _cif.ToString() & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            Try
                If Len(_cif) > 2 Then
                    'cifsearch(_cif)
                    ' If IsIdExist(_cif) = False Then
                    If Not CifService.IsCifExist(_cif) Then
                        logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                        InsertIntoDB(_name, _cif, _mobile, _pan, _adhar, _address, _dob, _gender)
                    Else
                        n += 1

                        logmsg = logmsg & timeme & " : Cif Id Already Exist in Database  " & Environment.NewLine & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                    End If
                Else
                    y += 1
                    logmsg = logmsg & timeme & " : Cif Does Not Exist For Name - " & _name & " ... " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()

                End If
            Catch ex As Exception

            End Try

        Next

    End Sub

    Private Sub InsertIntoDB(_name As String, _cif As String, _mobile As String, _pan As String, _adhar As String, _address As String, _dob As String, _gender As String)
        CifData = New ClassCif
        CifData.n_ame = _name
        CifData.cif = _cif
        CifData.mobile = _mobile
        CifData.pan = _pan
        CifData.adhar = _adhar
        CifData.address = _address
        CifData.dob = _dob
        CifData.gender = _gender
        CifData.status = "Pending"


        Try
            Dim i As Boolean
            i = CifService.AddCif(CifData)
            'Dim cmdstr As String
            'cmdstr = "insert into cifdb(cif,n_ame,mobile,pan,adhar,address,dob,gender,status)values('" & _cif & "','" & _name & "','" & _mobile & "','" & _pan & "','" & _adhar & "','" & _address & "','" & _dob & "','" & _gender & "','Pending')"
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
            ''  timer1.Enabled = True
            'logmsg = Nothing
            'InsertDataIntoSqlCIFDB()
            'timer1.Enabled = False

        End If
        If e.Parameters = "SendAll" Then
            ' InsertDataIntoSqlCIFDB(i)
        End If
    End Sub

    Protected Sub btn1_Click(sender As Object, e As EventArgs)
        ' logmsg = Nothing
        'InsertDataIntoSqlCIFDB()
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
        logmsg = logmsg & Environment.NewLine & Environment.NewLine & timeme & " :  Total Data Select = " & _totaldata & " Total Insert =  " & _totalinsert & " Total Skip = " & _totalSkip & "Total Exist = " & _exist & " ." & Environment.NewLine
        ASPxMemo1.Text = logmsg
        UPN1.Update()
        If IsCallback Then

        End If
    End Sub

End Class