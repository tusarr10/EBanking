Imports System.Data.SqlClient

Public Class sbInterest
    Inherits System.Web.UI.Page

    Protected Sub trtype_TextChanged(sender As Object, e As EventArgs)
        If trtype.Text = "Deposit" Then
            amounttb.ReadOnly = False
            amountlb.Text = "Deposit Amount "
        ElseIf trtype.Text = "Withdraw" Then
            amounttb.ReadOnly = False
            amountlb.Text = "Withdraw Amount "
        ElseIf trtype.Text = "Interest" Then
            amounttb.ReadOnly = False
            amountlb.Text = "Interset Amount "
        Else
            amounttb.ReadOnly = True
            amounttb.Text = "00"
            MyMessageBox.Show(Me, "Choose Transction Type .. ")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If datetb.Text = Nothing Then
            datetb.Text = DateAndTime.Now().ToString("yyyy-MM-dd")
        End If
        Try
            If Request.QueryString("value") IsNot Nothing Then
                AcnoTb.Text = Request.QueryString("value").ToString
                btnFindAccountClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindAccountClick()
        Dim accountnumber As String
        accountnumber = AcnoTb.Text.Trim
        GetDataOfAccount(accountnumber)
    End Sub

    Private Sub FillDataInView()
        baltb.Text = getAccountBalance(0)
        TextBox1.Text = getAccountName(0)
        actypetb.Text = getAccountProductType(0)

    End Sub

    Private Sub GetDataOfAccount(ByVal accountnumber As String)
        Try
            AccountSearch(accountnumber)
        Catch
            MyMessageBox.Show(Me, "Unable to find account")
            Exit Sub

        End Try
        If IsAccountIdExist(accountnumber) Then

            If getAccountProductType(0) = "Saving" Then
                If getAccountStatus(0) = "Active" Then
                    FillDataInView()
                    AcnoTb.ReadOnly = True
                Else
                    MyMessageBox.Show(Me, "This Is a Inactive Account ..")
                End If
            Else
                MyMessageBox.Show(Me, "This is not a Saving Account .This Is a " & getAccountProductType(0) & " Account")
            End If
        Else
            MyMessageBox.Show(Me, "Account Does not Exist ..")

        End If

    End Sub 'Get Account Information Then

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        'fo rsearch account number
        btnFindAccountClick()
        'after successful search

    End Sub

    'for verify
    Dim _actype As String

    Dim _accountNumber As String
    Dim _date As String
    Dim _name As String
    Dim _transctiontype As String
    Dim _bbt As String
    Dim _amount As String
    Dim _fine As String
    Dim _bat As String
    Dim _trid As String
    Dim _status As String
    Dim _office As String
    Dim _user As String
    Dim _details As String 'Total 13

    Private Sub GetDataFromView()
        _accountNumber = AcnoTb.Text.Trim 'given
        _name = TextBox1.Text.Trim 'get
        _actype = actypetb.Text 'get
        _date = datetb.Text 'given
        _transctiontype = trtype.Text 'given
        _bbt = baltb.Text.Trim 'get
        _amount = amounttb.Text.Trim 'given
        _fine = "00"
        _bat = Availablebalancetb.Text.Trim 'calculated
        _trid = "NA"
        _status = "Approved"
        _office = "CBS"
        _user = Getusername 'hardcode
        _details = TextBox2.Text 'given
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="fn">As Available Balance</param>
    ''' <param name="sn"> As Transctions Amount</param>
    ''' <param name="op"> As Function Ex. (DEP , WIT ,INT )</param>
    ''' <returns></returns>
    Function DoCalculation(fn As Double, sn As Double, op As String) As String
        If op = "DEP" Then
            Dim x As Double = fn + sn
            Return x
        ElseIf op = "WIT" Then
            Dim x As Double = fn - sn
            Return x
        ElseIf op = "INT" Then
            Dim x As Double = fn + sn
            Return x
        Else
            Return "00"
        End If
    End Function

    Private Sub DoCalculate()
        GetDataFromView()
        If _transctiontype = "Deposit" Then
            Availablebalancetb.Text = DoCalculation(_bbt, _amount, "DEP")
        ElseIf _transctiontype = "Withdraw" Then
            Availablebalancetb.Text = DoCalculation(_bbt, _amount, "WIT")
            ' MyMessageBox.Show(Me, "You Can Not ..")
        ElseIf _transctiontype = "Interest" Then
            Availablebalancetb.Text = DoCalculation(_bbt, _amount, "INT")
        Else
            MyMessageBox.Show(Me, "You can not ..")
            Exit Sub

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'for post button
        DoCalculate()
        DoTransction()
    End Sub

    Dim cs As String = connectionhelper.connectionstringaccount()

    Private Sub DoTransction()
        Dim sbjournalcmd As String = "INSERT INTO sbjournal (accountnumber, depositername, da_te, bbt, transctiontype, amount, bat, trid, status, office, u_ser, Details)
  VALUES ('" & _accountNumber & "', '" & _name & "', '" & _date & "', '" & _bbt & "', '" & _transctiontype & "', '" & _amount & "', '" & _bat & "', '" & _trid & "', '" & _status & "', '" & _office & "', '" & _user & "', '" & _details & "')"
        Dim liveaccountcom As String = "update liveaccount set balance='" & _bat & "' where accountnumber='" & _accountNumber & "'"

        databaseconnection = New SqlConnection(cs)
        databaseconnection.Open()
        Dim command As SqlCommand = databaseconnection.CreateCommand()
        Dim transction As SqlTransaction
        transction = databaseconnection.BeginTransaction("InsertTransction")

        command.Connection = databaseconnection
        command.Transaction = transction
        Try

            command.CommandText = sbjournalcmd
            command.ExecuteNonQuery()
            command.CommandText = liveaccountcom
            command.ExecuteNonQuery()

            transction.Commit()

            MyMessageBox.Show(Me, "Successfully Post Transction")
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

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'for Print Button
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'for next button
        MyMessageBox.Show(Me, "Success ...")
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        DoCalculate()
    End Sub

End Class