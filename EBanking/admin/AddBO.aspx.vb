Imports AdminDataBaseHelper

Public Class AddBO
    Inherits System.Web.UI.Page

    Private BoCLass As clsoffice
    Private BoLocation As ClsLocation
    Private allStaffs As ClassStaff
    Private listOfVillege As clsvillege

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' Getting Data From Interface and it contains All Information of Office Location 
    ''' </summary>
    ''' <param name="boclass">Enter Data Of BoClass as Office Object </param>
    Private Sub GetDataFromInterface(boclass As clsoffice)
        '  boclass155 = New clsoffice
        boclass.MCircle1 = cb_Circle.Text.Trim
        boclass.MBo1 = tb_employeeName.Text.Trim        'Office Name as BO
        boclass.MofficeId1 = tb_employeeName.Text.Trim 'office nmae as Office Id 
        boclass.MBoType1 = tb_officeStatus.Text
        boclass.staffNo = tb_numberOfStaff.Text
        boclass.MEstDate = tb_dateOfEstablishment.Text
        boclass.MCircle1 = cb_Circle.Text
        boclass.MRO1 = cb_Region.Text
        boclass.MDO1 = tb_Division.Text
        boclass.MSDO1 = tb_subDiv.Text
        boclass.MHO1 = tb_headPost.Text
        boclass.MSO1 = tb_Accountoffice.Text
        boclass.MFacilityId1 = tb_OfficeCode.Text
        boclass.MProfitCenterId1 = tb_OfficeCode2.Text
    End Sub
    Private Sub GetDataFromDatabase(boclass As clsoffice)
        cb_Circle.Text = boclass.MCircle1
        tb_employeeName.Text = boclass.MBo1
        ' tb_employeeName.Text = boclass.MofficeId1
        tb_officeStatus.Text = boclass.MBoType1
        boclass.staffNo = tb_numberOfStaff.Text
        boclass.MEstDate = tb_dateOfEstablishment.Text
        boclass.MCircle1 = cb_Circle.Text
        cb_Region.Text = boclass.MRO1
        tb_Division.Text = boclass.MDO1
        tb_subDiv.Text = boclass.MSDO1
        tb_headPost.Text = boclass.MHO1
        tb_Accountoffice.Text = boclass.MSO1
        tb_OfficeCode.Text = boclass.MFacilityId1
        tb_OfficeCode2.Text = boclass.MProfitCenterId1

    End Sub
    ''' <summary>
    ''' It Contains Office Location And Geo Information 
    ''' </summary>
    ''' <param name="data">It contains Locationn Informations</param>
    Public Sub GetDataFromOfficeLocation(data As ClsLocation)
        data.Districts = tb_Districts.Text
        data.SubDiv = tb_SubDivP.Text
        data.Block = tb_Bolck.Text
        data.Panchyat = tb_panchyat.Text
        data.NoVillege = tb_NoOfVillege.Text
        data.ApproxPopulation = tb_approxPeople.Text
        data.Loong = tb_loong.Text
        data.latt = tb_lat.Text
        data.OfficeId = tb_employeeName.Text.Trim

    End Sub
    Public Sub getDataFromOfficeLocationDataBase(data As ClsLocation)
        tb_Districts.Text = data.Districts
        tb_SubDivP.Text = data.SubDiv
        data.Block = tb_Bolck.Text
        data.Panchyat = tb_panchyat.Text
        data.NoVillege = tb_NoOfVillege.Text
        data.ApproxPopulation = tb_approxPeople.Text
        data.Loong = tb_loong.Text
        data.latt = tb_lat.Text
        data.OfficeId = tb_employeeName.Text.Trim
    End Sub

    ''' <summary>
    ''' Insert BoId and Office Code as primary key
    ''' </summary>
    ''' <param name="data">Data as Class Of Available Staff </param>
    Public Sub GetEmployeeDetails(data As ClassStaff)
        data.MBoname = tb_employeeName.Text.Trim
        data.MofficeId = tb_employeeName.Text.Trim
    End Sub

    ''' <summary>
    ''' Data as Villege Class
    ''' </summary>
    ''' <param name="data">only office code </param>
    Public Sub getAvailableVillegeDetails(data As clsvillege)
        data.mofficecode = tb_employeeName.Text.Trim
    End Sub

    ''' <summary>
    ''' Getting Data From Interface And Insert Into Data Base
    ''' </summary>
    Public Sub AddDataIntoDatabae()
        BoCLass = New clsoffice
        BoLocation = New ClsLocation
        allStaffs = New ClassStaff
        listOfVillege = New clsvillege

        GetDataFromInterface(BoCLass)
        GetDataFromOfficeLocation(BoLocation)
        GetEmployeeDetails(allStaffs)
        getAvailableVillegeDetails(listOfVillege)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddDataIntoDatabae()
    End Sub


    ''' <summary>
    ''' Fill employee Deatils Division In AddBo Aspx
    ''' </summary>
    Private Sub availableEmployeeDetails()
        'Retrive Data from (empDetails Table )
    End Sub
    ''' <summary>
    ''' Fill Data In Available Servi details
    ''' Check availablety Details In Data Base
    ''' </summary>
    Private Sub availableServiceDetails()
        'If Employees has All Function  Then Choose Yes 
        ' REFFER to availableEmployeeDetails()

    End Sub
    Private Sub OfficeAccountDetails()
        'Get Data From 
    End Sub






End Class
