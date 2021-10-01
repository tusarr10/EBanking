Imports DataBaseHelper
Imports DevExpress.Web
Imports System.Data.OleDb

Public Class dactrns
    Inherits System.Web.UI.Page

    Private Const UploadDirectory As String = "~/Developer/Data/"
    Dim resultFileUrl As String
    Dim resultFilePath As String


    Private DataService As New dacService(connectionstringoperate)
    Private data As dacClass

    Dim logmsg As String
    Dim _totaldata As String
    Dim _totalinsert As String
    Dim _totalSkip As String
    Dim _exist As String
    Dim y As Integer
    Dim z As Integer
    Dim n As Integer

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        loaddatafromserver()

        If Page.IsPostBack Then
            '     Notes.Text = logmsg

        End If

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
    Private Sub LoadCiffromdb()
        Try
            datasetcifdb.Tables("dacdb").Clear()
        Catch
        End Try
        Try
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & resultFilePath & ";Jet OLEDB:Database Password=" & "" & ";"
            Dim databaseconnection1 As OleDbConnection = New OleDbConnection(cs)
            databaseconnection1.Open()
            Dim dataadapter1 As OleDbDataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM " & "dacdb" & "", databaseconnection1))
            dataadapter1.Fill(datasetcifdb, "dacdb")
            'ShowData(currentrow)

            databaseconnection1.Close()
        Catch ex As Exception
            MyMessageBox.Show(Me, "Unable to load Database Mak sure Your Data Base Upload to ....." + ex.Message)
        End Try

    End Sub
    Function getCifAccessDataTable() As DataTable
        Try
            Return datasetcifdb.Tables("dacdb")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''Event
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

    Private Sub InsertDataIntoSqlCIFDB(i As Integer)
        Dim xi As Integer
        For x = 0 To i - 1
            data = New dacClass

            data.D_ate = ASPxGridView1.GetSelectedFieldValues("D_ate")(x).ToString
            Try
                Dim xy As String
                xy = data.D_ate 'datetb.Text '.ToString("dd MMMM yyyy")
                Dim newDate As Date = DateTime.ParseExact(xy, "dd MMMM yyyy", Globalization.CultureInfo.InvariantCulture)
                data.D_ate = newDate.ToString("yyyy-MM-dd")
            Catch ex As Exception
                Try
                    Dim xy As String
                    xy = data.D_ate 'datetb.Text '.ToString("dd MMMM yyyy")
                    Dim newDate As Date = DateTime.ParseExact(xy, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
                    data.D_ate = newDate.ToString("yyyy-MM-dd")
                Catch exx As Exception

                End Try
            End Try
            data.Open_bal = ASPxGridView1.GetSelectedFieldValues("Open_bal")(x).ToString
            data.cashrec = ASPxGridView1.GetSelectedFieldValues("cashrec")(x).ToString
            data.Sbdep = ASPxGridView1.GetSelectedFieldValues("Sbdep")(x).ToString
            data.rddep = ASPxGridView1.GetSelectedFieldValues("rddep")(x).ToString
            data.rdfine = ASPxGridView1.GetSelectedFieldValues("rdfine")(x).ToString
            data.ssadep = ASPxGridView1.GetSelectedFieldValues("ssadep")(x).ToString
            data.ssafine = ASPxGridView1.GetSelectedFieldValues("ssafine")(x).ToString
            data.tddep = ASPxGridView1.GetSelectedFieldValues("tddep")(x).ToString
            data.rplidep = ASPxGridView1.GetSelectedFieldValues("rplidep")(x).ToString
            data.rplifine = ASPxGridView1.GetSelectedFieldValues("rplifine")(x).ToString
            data.rplitax = ASPxGridView1.GetSelectedFieldValues("rplitax")(x).ToString
            data.vpp = ASPxGridView1.GetSelectedFieldValues("vpp")(x).ToString
            data.othcol1 = ASPxGridView1.GetSelectedFieldValues("othcol1")(x).ToString
            data.othcol2 = ASPxGridView1.GetSelectedFieldValues("othcol2")(x).ToString
            data.totaldep = ASPxGridView1.GetSelectedFieldValues("totaldep")(x).ToString

            data.cashremet = ASPxGridView1.GetSelectedFieldValues("cashremet")(x).ToString
            data.sbwith = ASPxGridView1.GetSelectedFieldValues("sbwith")(x).ToString
            data.rdwith = ASPxGridView1.GetSelectedFieldValues("rdwith")(x).ToString
            data.ssawith = ASPxGridView1.GetSelectedFieldValues("ssawith")(x).ToString
            data.tdwith = ASPxGridView1.GetSelectedFieldValues("tdwith")(x).ToString
            data.rpliwith = ASPxGridView1.GetSelectedFieldValues("rpliwith")(x).ToString
            data.MONwith = ASPxGridView1.GetSelectedFieldValues("MONwith")(x).ToString
            data.othwith = ASPxGridView1.GetSelectedFieldValues("othwith")(x).ToString
            data.totalwith = ASPxGridView1.GetSelectedFieldValues("totalwith")(x).ToString
            data.curr_ency = ASPxGridView1.GetSelectedFieldValues("curr_ency")(x).ToString
            data.stamp1 = ASPxGridView1.GetSelectedFieldValues("stamp1")(x).ToString
            data.stamp2 = ASPxGridView1.GetSelectedFieldValues("stamp2")(x).ToString
            data.Closebal = ASPxGridView1.GetSelectedFieldValues("colsebal")(x).ToString
            data.office = OfficeName
            data.u_ser = Getusername
            data.status = "Verified"
            data.ti_me = ""
            logmsg = logmsg & timeme & " : Getting Data from DB CIF- " & data.D_ate.ToString() & Environment.NewLine
            ASPxMemo1.Text = logmsg
            UPN1.Update()
            Try
                If Len(data.D_ate) > 2 Then
                    'cifsearch(_cif)
                    ' If IsIdExist(_cif) = False Then
                    If Not DataService.IsDataExist(data) Then
                        logmsg = logmsg & timeme & " : Inserting Data Please wait... " & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                        Dim ii As Boolean = DataService.InsertData(data)
                        If ii Then
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

                    Else
                        n += 1

                        logmsg = logmsg & timeme & " : Cif Id Already Exist in Database  " & Environment.NewLine & Environment.NewLine
                        ASPxMemo1.Text = logmsg
                        UPN1.Update()
                    End If
                Else
                    y += 1
                    logmsg = logmsg & timeme & " : Data Does Not Exist For Name - " & data.D_ate & " ... " & Environment.NewLine & Environment.NewLine
                    ASPxMemo1.Text = logmsg
                    UPN1.Update()

                End If
            Catch ex As Exception

            End Try

        Next
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs)

    End Sub
End Class