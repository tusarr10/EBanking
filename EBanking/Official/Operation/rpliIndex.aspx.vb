Imports System.Data.SqlClient
Imports DataBaseHelper

Public Class rpliIndex
    Inherits System.Web.UI.Page

    Dim result As Boolean = False
    Dim log As String
    Private Custmorfiles As ClassPliIndex
    Private CustmorService As New pliindexService(connectionstringRpli())
    Dim listOfCustmor As List(Of ClassPliIndex)

    Private TranstionFiles As classPliTransction
    Private plitransctionservice As New PliTransctionService(connectionstringRpli())

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
        Custmorfiles = New ClassPliIndex
        TranstionFiles = New classPliTransction

        TranstionFiles.policyNo = ""
        TranstionFiles.month = "Initial"
        TranstionFiles.type = "Index"
        TranstionFiles.gst = totalgst
        TranstionFiles.amount = premtb.Text.Trim - totalgst

        idrp = DateAndTime.Now.ToString() & boidtb.Text
        Custmorfiles.id = DateAndTime.Now.ToString("yyMdHHmmss") & boidtb.Text
        TranstionFiles.id = DateAndTime.Now.ToString("yyMdHHmmss") & boidtb.Text

        agentidrp = agentidtb.Text.Trim
        Custmorfiles.agentId = agentidtb.Text.Trim

        boidrp = boidtb.Text.Trim
        Custmorfiles.boid = boidtb.Text.Trim

        recdaterp = rcdatetb.Text.Trim
        Custmorfiles.RecDate = rcdatetb.Text.Trim

        agentsarp = agentsa.Text.Trim
        Custmorfiles.agentSA = agentsa.Text.Trim

        agentpremrp = agentpremtb.Text.Trim
        Custmorfiles.agentPremium = agentpremtb.Text.Trim

        agentmobilerp = agentmobile.Text.Trim
        Custmorfiles.AgentMobile = agentmobile.Text.Trim

        custanamerp = custnametb.Text.Trim
        Custmorfiles.CustName = custnametb.Text.Trim
        TranstionFiles.name = custnametb.Text.Trim

        custdobrp = custdobtb.Text.Trim
        Custmorfiles.custmordob = custdobtb.Text.Trim

        custmobilerp = custmobiletb.Text.Trim
        Custmorfiles.custmobile = custmobiletb.Text.Trim

        custnotesrp = custnotestb.Text.Trim
        Custmorfiles.custmornotes = custnotestb.Text.Trim

        proposaldaterp = proposaldatetb.Text.Trim
        Custmorfiles.proposaldate = proposaldatetb.Text.Trim
        TranstionFiles.dat_e = proposaldatetb.Text.Trim

        proposaltyperp = producttype.Text.Trim
        Custmorfiles.proposaltype = producttype.Text.Trim

        productcatrp = DropDownList1.Text.Trim
        Custmorfiles.productcat = DropDownList1.Text.Trim

        prefqrp = DropDownList3.Text.Trim
        Custmorfiles.prefrq = DropDownList3.Text.Trim

        matagerp = matagetb.Text.Trim
        Custmorfiles.matage = matagetb.Text.Trim

        proposalnorp = propnotb.Text.Trim
        Custmorfiles.proposalno = propnotb.Text.Trim
        TranstionFiles.proposalno = propnotb.Text.Trim

        recnorp = recnotb.Text.Trim
        Custmorfiles.recno = recnotb.Text.Trim
        TranstionFiles.recno = recnotb.Text.Trim

        sarp = satb.Text.Trim
        Custmorfiles.sa = satb.Text.Trim

        premrp = premtb.Text.Trim
        Custmorfiles.premium = premtb.Text.Trim
        TranstionFiles.totalrec = premtb.Text.Trim

        indexborp = "Talita"
        Custmorfiles.indexbo = "Talita"

        usidrp = "Tusar"
        Custmorfiles.userid = "Tusar"
    End Sub 'insert data to pli transction class
    Sub insertDataaInView()
        agentidtb.Text = Custmorfiles.agentId
        boidtb.Text = Custmorfiles.boid
        rcdatetb.Text = Custmorfiles.RecDate
        agentsa.Text = Custmorfiles.agentSA
        agentpremtb.Text = Custmorfiles.agentPremium
        custnametb.Text = Custmorfiles.CustName
        custdobtb.Text = Custmorfiles.custmordob
        custmobiletb.Text = Custmorfiles.custmobile
        custnotestb.Text = Custmorfiles.custmornotes
        custaddresstb.Text = Custmorfiles.custaddress
        proposaldatetb.Text = Custmorfiles.proposaldate
        producttype.Text = Custmorfiles.proposaltype
        DropDownList1.Text = Custmorfiles.productcat
        DropDownList3.Text = Custmorfiles.prefrq
        matagetb.Text = Custmorfiles.matage
        propnotb.Text = Custmorfiles.proposalno
        recnotb.Text = Custmorfiles.recno
        satb.Text = Custmorfiles.sa
        premtb.Text = Custmorfiles.premium
        officeidtb.Text = Custmorfiles.indexbo
        usernametb.Text = Custmorfiles.userid 'total 21

    End Sub
    Private Function verifyData() As Boolean
        'Data Verification 
        Return True 'it (false) now its true  for testing 
    End Function
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click 'insert data to new account
        log = ""
        getdatafromview()
        If verifyData() = True Then
            If CustmorService.IsProposalExist(Custmorfiles.proposalno) = False Then
                result = CustmorService.AddCustmor(Custmorfiles)
                If result Then
                    log = log & "Successfully Added A New Recored " & Environment.NewLine
                    logtb.Text = log
                    ASPxButton2.Enabled = True
                Else
                    log = log & "Failed Adding Recored " & Environment.NewLine
                    logtb.Text = log
                End If
            Else
                log = log & "Proposal Number already EXIST ..With Proposal Number " & Custmorfiles.proposalno & " ." & Environment.NewLine
                logtb.Text = log
            End If
        Else
            log = log & " ErrorData Verification " & Environment.NewLine
            logtb.Text = log
        End If
    End Sub


    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) 'insert transction data to db
        getFunctionData()
        log = ""
        getdatafromview()
        If verifyData() = True Then
            result = plitransctionservice.AddTransctionfile(TranstionFiles)
            If result Then
                log = log & " Record successfully saved for Proposal No -  " & proposalnorp & Environment.NewLine

                logtb.Text = log
                ASPxButton3.Enabled = True
            Else
                log = log & " Record Not saved for Proposal No -  " & proposalnorp & Environment.NewLine
                logtb.Text = log
            End If
        Else
            log = log & " ErrorData Verification " & Environment.NewLine
            logtb.Text = log
        End If
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
        totalgst = fun(premtb.Text.Trim)
    End Sub


    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs)
        Response.Redirect(Request.Url.AbsoluteUri)
        'myMsgBox.Show(Me, "~/Official/Operation/rpliIndex.aspx")
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) 'Search Proposal Number
        Dim pno As String = psearchtb.Text.Trim
        If CustmorService.IsProposalExist(pno) Then
            Custmorfiles = CustmorService.FindByid(pno)
            'Dim x = Custmorfiles.agentId
            insertDataaInView()
        Else
            'my message = Proposal Number Not Found 
        End If

    End Sub
End Class