Imports AdminDataBaseHelper

Public Class AddBO
    Inherits System.Web.UI.Page

    Private BoCLass As clsoffice

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GetDataFromInterface(boclass155 As clsoffice)
        '  boclass155 = New clsoffice
        boclass155.MCircle1 = cb_Circle.Text.Trim

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BoCLass = New clsoffice
        GetDataFromInterface(BoCLass)
    End Sub

End Class