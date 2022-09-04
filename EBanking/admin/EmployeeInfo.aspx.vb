Imports AdminDataBaseHelper
Public Class EmployeeInfo
    Inherits System.Web.UI.Page

    ' Declar class 
    Private employeeInformation As ClsEmplInfo
    Private employeeDetails As clsEmpDetails
    Private employeeService As EmpServices
    Private emptrnsf As clsEmpTrnsf


    Private AddEmployeeTransction As New AddEmpServices(connectionstringAdmin)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub searchEID(sender As Object, e As EventArgs) Handles btnSearchEmployee.Click
        Try
            ''Data base connections
        Catch ex As Exception
            '' EX message
        End Try

        Try
            If AddEmployeeTransction.EmployeeExist(tb_employeeId.Text.Trim) Then
                GetDataByEmployeeId(tb_employeeId.Text.Trim)
                ''do fill data
            Else

                EnableInput()
            End If

        Catch ex As Exception
            ''' MSG goes here
            Exit Sub
        End Try

    End Sub
    Private Sub EnableInput()
        tb_employeeName.ReadOnly = False
        tbEmployeeStatus.ReadOnly = False

        tb_userid.ReadOnly = False
        cb_gender.Enabled = True
        tb_fathername.ReadOnly = False
        tb_DOB.ReadOnly = False
        cb_bloodGroup.Enabled = True
        tb_address.ReadOnly = False
        tb_address2.ReadOnly = False
        tb_mobile.ReadOnly = False
        tb_mobile2.ReadOnly = False '.Enabled = True
        tb_aadhaar.ReadOnly = False
        tb_email.ReadOnly = False
        tb_pan.ReadOnly = False
        tb_pran.ReadOnly = False
        tb_remarks.ReadOnly = False

        tb_joindate.ReadOnly = False
        tb_retair.ReadOnly = False
        tb_post.ReadOnly = False
        tb_trca.ReadOnly = False
        tb_originalPost.ReadOnly = False
        tb_currentPlacePost.ReadOnly = False
        tb_currentPost.ReadOnly = False
        tb_PostRemark.ReadOnly = False


        cb_ippb.Enabled = True
        cb_uidai.Enabled = True
        cb_cscid.Enabled = True
        cb_pli.Enabled = True

        btn_add.Enabled = True


    End Sub

    Private Sub cb_cscid_TextChanged(sender As Object, e As EventArgs) Handles cb_cscid.TextChanged
        If cb_cscid.Text = "Yes" Then
            tb_cscid.ReadOnly = False


        ElseIf cb_cscid.Text = "No" Then
            tb_cscid.ReadOnly = True

        End If
    End Sub

    Private Sub cb_ippb_TextChanged(sender As Object, e As EventArgs) Handles cb_ippb.TextChanged
        If cb_ippb.Text = "Yes" Then
            tb_ippb.ReadOnly = False


        ElseIf cb_ippb.Text = "No" Then
            tb_ippb.ReadOnly = True

        End If
    End Sub

    Private Sub cb_pli_TextChanged(sender As Object, e As EventArgs) Handles cb_pli.TextChanged
        If cb_pli.Text = "Yes" Then
            tb_pli.ReadOnly = False


        ElseIf cb_pli.Text = "No" Then
            tb_pli.ReadOnly = True

        End If
    End Sub

    Private Sub cb_uidai_TextChanged(sender As Object, e As EventArgs) Handles cb_uidai.TextChanged
        If cb_uidai.Text = "Yes" Then
            tb_uidai.ReadOnly = False


        ElseIf cb_uidai.Text = "No" Then
            tb_uidai.ReadOnly = True

        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click

        Try
                ' insert data into database
                DoTransctionAddData()
            Catch ex As Exception
                ' error message
            End Try

    End Sub

    Private Sub DoTransctionAddData()
        '' add data to class
        employeeInformation = New ClsEmplInfo
        employeeDetails = New clsEmpDetails
        employeeService = New EmpServices
        emptrnsf = New clsEmpTrnsf
        getDataFromView(employeeInformation, employeeDetails, employeeService, emptrnsf)
        Try
            If AddEmployeeTransction.EmployeeExist(employeeDetails.MemployeeId1) Then
                '' already exist you cannot add
                MyMessageBox.Show(Me, "already exist you can not add")
                Exit Sub
            Else
            End If

            'Logic Here
            If AddEmployeeTransction.AddEmployee(employeeDetails, employeeInformation, employeeService, emptrnsf) Then
                MyMessageBox.Show(Me, "Data Saved Successfully")
            End If
            '  Errortb.Text = "Data Saved Successfully"

            Dim x = Request.Url.AbsoluteUri
            myMsgBox.Show(Me, x)


        Catch ex As Exception
            ' Errortb.Text = "Data Not Saved Successfully"
            MyMessageBox.Show(Me, "Data Not Saved Successfully")
        End Try

    End Sub

    Private Sub getDataFromView(employeeInformation As ClsEmplInfo, employeeDetails As clsEmpDetails, employeeService As EmpServices, emptrnsf As clsEmpTrnsf)
        ' Get Employee Information from View and store in employee info table

        employeeInformation.MUserId1 = tb_userid.Text.Trim
        employeeInformation.MEmployeeId1 = tb_employeeId.Text.Trim
        employeeInformation.MName1 = tb_employeeName.Text
        employeeInformation.MFather1 = tb_fathername.Text.Trim
        employeeInformation.MDOB1 = tb_DOB.Text
        employeeInformation.MGender1 = cb_gender.Text
        employeeInformation.MBlood1 = cb_bloodGroup.Text
        employeeInformation.MAddress1 = tb_address.Text
        employeeInformation.MAddress21 = tb_address2.Text
        employeeInformation.MMobile11 = tb_mobile.Text
        employeeInformation.MMobile2 = tb_mobile2.Text
        employeeInformation.MEmail1 = tb_email.Text
        employeeInformation.Maadhar1 = tb_aadhaar.Text.Trim
        employeeInformation.MPan1 = tb_pan.Text.Trim
        employeeInformation.mpran1 = tb_pran.Text.Trim
        employeeInformation.MIdRemark1 = tb_remarks.Text


#Disable Warning BC42303 ' XML comment cannot appear within a method or a property
        ''' Get Office details data from VIEW and store in class employee details table
#Enable Warning BC42303 ' XML comment cannot appear within a method or a property

        employeeDetails.MemployeeId1 = tb_employeeId.Text.Trim
        employeeDetails.Mofficeid1 = tb_originalPost.Text '' to be change in future and replace with Office ID or BO id
        employeeDetails.MDateofJoin1 = tb_joindate.Text
        employeeDetails.MDateofRet1 = tb_retair.Text
        employeeDetails.MDateOfPosting1 = tb_joindate.Text
        employeeDetails.MEmployeeStatus1 = "Service"
        employeeDetails.post1 = tb_currentPost.Text.Trim
        employeeDetails.trcalvl1 = tb_trca.Text.Trim
        employeeDetails.orgPost1 = tb_post.Text
        employeeDetails.CurrentPlace1 = tb_currentPlacePost.Text
        employeeDetails.currentPost1 = tb_currentPost.Text.Trim
        employeeDetails.remarks1 = tb_remarks.Text
        employeeDetails.MIsUidai1 = cb_uidai.Text
        employeeDetails.MIsIPPB1 = cb_ippb.Text
        employeeDetails.MIsPLI1 = cb_pli.Text
        employeeDetails.MIsCSC1 = cb_cscid.Text

        employeeService.memployeeid = tb_employeeId.Text.Trim
        employeeService.muidaiid = tb_uidai.Text.Trim
        employeeService.mpli = tb_pli.Text.Trim
        employeeService.mippbid = tb_ippb.Text.Trim
        employeeService.mcscid = tb_cscid.Text.Trim

        emptrnsf.MEmployeeID1 = tb_employeeId.Text.Trim
        emptrnsf.Mdate1 = tb_currentPlacePost.Text
        emptrnsf.MFrom1 = tb_currentPlacePost.Text
        emptrnsf.MTO1 = ""
        emptrnsf.MRemark1 = "NEW JOIN"
        emptrnsf.mofficecode = tb_currentPlacePost.Text
        emptrnsf.mOfficename = tb_currentPlacePost.Text
        emptrnsf.mname = tb_employeeName.Text
        emptrnsf.mdesignation = tb_currentPost.Text
        emptrnsf.mpost = tb_originalPost.Text
        emptrnsf.mother = "NEW JOIN"
        emptrnsf.mmemo1 = "n/a"


    End Sub

    Private Sub GetDataByEmployeeId(AccountId As String)
        If AddEmployeeTransction.EmployeeExist(AccountId) Then
            'Disable Add Button 
            Try
                'Get data From Employee Details
                employeeDetails = New clsEmpDetails
                employeeDetails = AddEmployeeTransction.GetEmployeeDetailsById(AccountId)


                'Get Data From Employee Informations
                employeeInformation = New ClsEmplInfo
                employeeInformation = AddEmployeeTransction.GetEmployeeInfoById(AccountId)


                ' Get Data From employee Services
                employeeService = New EmpServices
                employeeService = AddEmployeeTransction.GetEmployeeServicesById(AccountId)

                ' emptrnsf = New clsEmpTrnsf
                ' emptrnsf = AddEmployeeTransction.GetEmpTrnsfById(AccountId)

                fillDataInDivisionOne(employeeInformation, employeeDetails, employeeService, AccountId)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub fillDataInDivisionOne(employeeInformation As ClsEmplInfo, employeeDetails As clsEmpDetails, employeeService As EmpServices, AccountId As String)
        'division 1

        tb_userid.Text = employeeInformation.MUserId1
        tb_employeeId.Text = employeeInformation.MEmployeeId1
        tb_employeeName.Text = employeeInformation.MName1
        tb_fathername.Text = employeeInformation.MFather1
        tb_DOB.Text = employeeInformation.MDOB1
        cb_gender.Text = employeeInformation.MGender1
        cb_bloodGroup.Text = employeeInformation.MBlood1
        tb_address.Text = employeeInformation.MAddress1
        tb_address2.Text = employeeInformation.MAddress21
        tb_mobile.Text = employeeInformation.MMobile11
        tb_mobile2.Text = employeeInformation.MMobile2
        tb_email.Text = employeeInformation.MEmail1
        tb_aadhaar.Text = employeeInformation.Maadhar1
        tb_pan.Text = employeeInformation.MPan1
        tb_pran.Text = employeeInformation.mpran1
        tb_remarks.Text = employeeInformation.MIdRemark1


#Disable Warning BC42303 ' XML comment cannot appear within a method or a property
        ''' Get Office details data from VIEW and store in class employee details table
#Enable Warning BC42303 ' XML comment cannot appear within a method or a property

        ' tb_employeeId.Text = employeeDetails.MemployeeId1
        tb_originalPost.Text = employeeDetails.Mofficeid1  '' to be change in future and replace with Office ID or BO id
        tb_joindate.Text = employeeDetails.MDateofJoin1
        tb_retair.Text = employeeDetails.MDateofRet1
        tb_joindate.Text = employeeDetails.MDateOfPosting1
        '   employeeDetails.MEmployeeStatus1 = "Service"
        tb_currentPost.Text = employeeDetails.post1
        tb_trca.Text = employeeDetails.trcalvl1
        tb_post.Text = employeeDetails.orgPost1
        tb_currentPlacePost.Text = employeeDetails.CurrentPlace1
        tb_currentPost.Text = employeeDetails.currentPost1
        tb_PostRemark.Text = employeeDetails.remarks1
        cb_uidai.Text = employeeDetails.MIsUidai1
        cb_ippb.Text = employeeDetails.MIsIPPB1
        cb_pli.Text = employeeDetails.MIsPLI1
        cb_cscid.Text = employeeDetails.MIsCSC1

        tb_employeeId.Text = employeeService.memployeeid
        tb_uidai.Text = employeeService.muidaiid
        tb_pli.Text = employeeService.mpli
        tb_ippb.Text = employeeService.mippbid
        tb_cscid.Text = employeeService.mcscid


        Try
            emptrnsfGridView.DataSource = AddEmployeeTransction.GetEmpTrnsfById(AccountId)
            emptrnsfGridView.DataBind()

        Catch ex As Exception

        End Try

    End Sub
End Class