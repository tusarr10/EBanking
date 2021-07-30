Imports System.Data.SqlClient

Public Class rpliIndex
    Inherits System.Web.UI.Page

    Dim log As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Try
                'log implement
                usidrp = "Tusar"
                indexborp = "Talita"
                officeidtb.Text = indexborp
                usernametb.Text = usidrp
                rcdatetb.Text = DateAndTime.Now.ToString("yyyy-MM-dd")
                proposaldatetb.Text = DateAndTime.Now.ToString("yyyy-MM-dd")
            Catch ex As Exception

            End Try
        Else

        End If

    End Sub

    Protected Sub trtype_TextChanged(sender As Object, e As EventArgs)
        If producttype.Text = "PLI" Then

        ElseIf producttype.Text = "RPLI" Then

        Else

            MyMessageBox.Show(Me, "Choose Product Type .. ")
        End If
    End Sub
    Protected Sub trtype_TextChanged1(sender As Object, e As EventArgs)
        If DropDownList1.Text = "Choose Product" Then
            MyMessageBox.Show(Me, "Choose Product Type .. ")
        Else

        End If
        If DropDownList3.Text = "Choose Frequency" Then
            MyMessageBox.Show(Me, "Choose Frequency Type .. ")
        End If
    End Sub

    Sub getdatafromview()
        idrp = DateAndTime.Now.ToString() & boidtb.Text
        agentidrp = agentidtb.Text.Trim
        boidrp = boidtb.Text.Trim
        recdaterp = rcdatetb.Text.Trim
        agentsarp = agentsa.Text.Trim
        agentpremrp = agentpremtb.Text.Trim
        agentmobilerp = agentmobile.Text.Trim

        custanamerp = custnametb.Text.Trim
        custdobrp = custdobtb.Text.Trim
        custmobilerp = custmobiletb.Text.Trim
        custnotesrp = custnotestb.Text.Trim
        custaddressrp = custaddresstb.Text.Trim

        proposaldaterp = proposaldatetb.Text.Trim
        proposaltyperp = producttype.Text.Trim
        productcatrp = DropDownList1.Text.Trim
        prefqrp = DropDownList3.Text.Trim
        matagerp = matagetb.Text.Trim

        proposalnorp = propnotb.Text.Trim
        recnorp = recnotb.Text.Trim
        sarp = satb.Text.Trim
        premrp = premtb.Text.Trim

        indexborp = "Talita"
        usidrp = "Tusar"

    End Sub

    Private Function verifyData() As Boolean
        'Data Verification 
        Return True 'it (false) now its true  for testing 
    End Function
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)
        log = ""
        getdatafromview()
        If verifyData() = True Then
            insertdataIntoDb()
        Else
            log = log & " ErrorData Verification " & Environment.NewLine
            logtb.Text = log
        End If
    End Sub

    Private Sub insertintotransction()
        Dim commandstring As String
        Try
            commandstring = "INSERT INTO dbo.pli_transction (id, policyNo, proposalno, amount, month, dat_e, name, recno, gst, totalrec, type)
  VALUES ('" & idrp & "', '" & "" & "', '" & proposalnorp & "', '" & premrp & "', '" & "Initial" & "', '" & proposaldaterp & "', '" & custanamerp & "', '" & recnorp & "', '" & totalgst & "', '" & premrp & "', '" & "Index" & "')"
            databaseconnection = New SqlConnection(connectionhelper.connectionstringRpli())
            datacommand = New SqlCommand(commandstring, databaseconnection)
            databaseconnection.Open()
            Dim i
            i = datacommand.ExecuteNonQuery()
            If i > 0 Then
                log = log & " Record successfully saved for Proposal No -  " & proposalnorp & Environment.NewLine

                logtb.Text = log
                ASPxButton3.Enabled = True

            Else
                log = log & " Record Not saved for Proposal No -  " & proposalnorp & Environment.NewLine
                logtb.Text = log
            End If
            databaseconnection.Close()
        Catch ex As Exception
            log = log & " Error" + ex.Message & Environment.NewLine
            logtb.Text = log
            databaseconnection.Close()

        End Try
    End Sub
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs)
        getFunctionData()
        insertintotransction()
    End Sub


    Dim cgst As String
    Dim sgst As String
    Dim totalgst As String
    Dim totalvalue As Integer
    Dim gstrate As Double = 4.5

    Function fun(ByVal totalvalue As Double) As String
        Return (totalvalue) - (totalvalue * 100 / (100 + gstrate))
    End Function
    Function centreGst(ByVal x As String) As String
        Return fun(x) / 2
    End Function
    Function Stategst(ByVal x As String) As String
        Return fun(x) / 2
    End Function
    Sub getFunctionData()
        totalgst = fun(premrp)
    End Sub
    Private Sub insertdataIntoDb()
        Dim commandstring As String
        Try
            commandstring = "INSERT INTO dbo.Pli_Indexing (id, agentId, boid, RecDate, agentSA, agentPremium, AgentMobile, CustName, custmordob, custmobile, custmornotes, custaddress, proposaldate, proposaltype, productcat, prefrq, matage, proposalno, recno, sa, premium, indexbo, userid)
  VALUES ('" & idrp & "', '" & agentidrp & "', '" & boidrp & "', '" & recdaterp & "', '" & agentsarp & "', '" & agentpremrp & "', '" & agentmobilerp & "', '" & custanamerp & "', '" & custdobrp & "', '" & custmobilerp & "', '" & custnotesrp & "', '" & custaddressrp & "', '" & proposaldaterp & "', '" & proposaltyperp & "', '" & productcatrp & "', '" & prefqrp & "', '" & matagerp & "', '" & proposalnorp & "', '" & recnorp & "', '" & sarp & "', '" & premrp & "', '" & indexborp & "', '" & usidrp & "')"
            databaseconnection = New SqlConnection(connectionhelper.connectionstringRpli())
            datacommand = New SqlCommand(commandstring, databaseconnection)
            databaseconnection.Open()
            Dim i
            i = datacommand.ExecuteNonQuery()
            If i > 0 Then
                log = log & " Record successfully saved for Proposal No -  " & proposalnorp & Environment.NewLine
                logtb.Text = log
                ASPxButton2.Enabled = True
            Else
                log = log & " Record Not saved for Proposal No -  " & proposalnorp & Environment.NewLine
                logtb.Text = log
            End If
            databaseconnection.Close()
        Catch ex As Exception
            log = log & " Error" + ex.Message & Environment.NewLine
            logtb.Text = log
            databaseconnection.Close()
        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs)
        Response.Redirect(Request.Url.AbsoluteUri)
        'myMsgBox.Show(Me, "~/Official/Operation/rpliIndex.aspx")
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs)
        Dim pno As String = psearchtb.Text.Trim
        rpliIndexHelper.searchpliindex(pno)
    End Sub
End Class