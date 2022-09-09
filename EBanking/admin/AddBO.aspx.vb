Imports AdminDataBaseHelper

Public Class AddBO
    Inherits System.Web.UI.Page

    Private BoCLass As clsoffice

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GetDataFromInterface(boclass As clsoffice)
        '  boclass155 = New clsoffice
        boclass.MCircle1 = cb_Circle.Text.Trim
        boclass.MBo1 = tb_employeeName.Text
        boclass.MofficeId1 = tb_employeeName.Text ' Office nmae as Office Id 
        boclass.MBoType1 = tb_officeStatus.Text
        boclass.staffNo = tb_numberOfStaff.Text



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BoCLass = New clsoffice
        GetDataFromInterface(BoCLass)
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
