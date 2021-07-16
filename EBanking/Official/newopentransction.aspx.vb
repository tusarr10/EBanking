Imports System.Data.SqlClient
Public Class newopentransction
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub getdataFromDB() '31
        '1
        getAccountData.VertualId = getNewAccountVirtualid(row)
        getAccountData.cif = getNewAccountcif(row)
        getAccountData.accountnumber = getNewAccountacno(row)
        getAccountData.name = getNewAccountName(row)
        getAccountData.producttype1 = getNewAccountproducttype(row)
        getAccountData.productterm = getNewAccountProductTerm(row)
        getAccountData.productvalue = getNewAccountProductValue(row)
        getAccountData.nomini = getNewAccountNominiReg(row)
        getAccountData.nomininame = getNewAccountNominiName(row)
        getAccountData.nominiage = getNewAccountNominiAge(row)
        '11
        getAccountData.nominiaddress = getNewAccountNominiaddress(row)
        getAccountData.nominirelation = getNewAccountNominiRelation(row)
        getAccountData.acoperatemode = getNewAccountMOP(row)
        getAccountData.guardianname = getNewAccountguardianname(row)
        getAccountData.jointname = getNewAccountJointName(row)
        getAccountData.relation = ""
        getAccountData.acstatus = "Pending"
        getAccountData.address = getNewAccountAddress(row)
        getAccountData.mobile = getNewAccountmobile(row)
        getAccountData.email = getNewAccountEmail(row)
        '21
        getAccountData.dob = getNewAccountdob(row)
        getAccountData.gender = getNewAccountgender(row)
        getAccountData.adhar = getNewAccountadhar(row)
        getAccountData.pan = getNewAccountpan(row)
        getAccountData.photo = getNewAccountphoto(row)
        getAccountData.sign = getNewAccountsign(row)
        getAccountData.doo = getNewAccountdoo(row)
        getAccountData.reffno = getNewAccountreffno(row)
        getAccountData.pr = getNewAccountpr(row)
        getAccountData.balance = getNewAccountbalance(row)
        '31
        getAccountData.trid = getNewAccounttrid(row)

    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'getdata Function
        newOpenAccountSearch(reffNumberTb.Text.Trim)
        getdataFromDB()
        'print
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('Print/OpenAccountCheck.aspx','_newtab');", True)
        'then
        Button2.Enabled = True

    End Sub
    Dim cs As String = connectionhelper.connectionstring()
    Private Sub updateDataInOpenAccount()
        'TODO
        'Update transctionJopurnal
        newOpenAccountSearch(reffNumberTb.Text.Trim)
        getdataFromDB()

        Dim bal As String = Nothing
        Dim trid1 As String

        trid1 = tridtb.Text.Trim
        bal = amounttb.Text.Trim

        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("UpdateNewAccount")

        command.Connection = databaseconnection
        command.Transaction = transction



        'Implement Verification
        If bal IsNot Nothing Then
            Try

                command.CommandText = "update newacdb set balance='" & bal & "' , trid='" & trid1 & "' where reffno='" & reffno & "'"
                command.ExecuteNonQuery()

                'update trdtatus from sb journal

                command.CommandText = "insert into journal (da_te,accounttype,accountnumber,na_me,deposit,withdraw,dlt,trid,balance,status,office,u_ser) values ('" & datetb.Text.Trim & "','" & producttype1 & "','" & reffno & "','" & name & "','" & bal & "','" & "00" & "','" & "NewAccount" & "','" & trid1 & "','" & bal & "','" & "Approved" & "','" & OfficeName & "','" & Getusername & "')"
                command.ExecuteNonQuery()

                'update alljournalstatus 



                transction.Commit()
                MyMessageBox.Show(Me, "Data Saved Successfully")
            Catch ex As Exception
                MyMessageBox.Show(Me, "Commit Exception Type: {0}" + ex.Message())
                MyMessageBox.Show(Me, "  Message: {0}" + ex.Message)
                Try
                    transction.Rollback()
                    MyMessageBox.Show(Me, "Data Not Saved Successfully")
                Catch ex2 As Exception
                    MyMessageBox.Show(Me, "Rollback Exception Type: {0}" + ex2.Message())
                    MyMessageBox.Show(Me, "  Message: {0}" + ex2.Message)
                End Try
            End Try

        Else
            MyMessageBox.Show(Me, "Account Balance Not Update Check In All User ...")
        End If





        '*************END***************
        Button3.Enabled = True

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updateDataInOpenAccount()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MyMessageBox.Show(Me, "Successfully Done ")
    End Sub
    Dim row As Integer = 0

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Try
            newOpenAccountSearch(reffNumberTb.Text.Trim)
            fullnametb.Text = getNewAccountName(row)
            datetb.Text = getNewAccountdoo(row)

        Catch ex As Exception

        End Try
    End Sub
    Dim _name1 As String
    Private Sub findDataFromAccountDatabase(ByVal name1 As String)
        Try
            newaccounthelper.NewAccountNameSearch(name1)
            BootstrapGridView1.DataSource = getNewAccountOpenDataTable()
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
End Class