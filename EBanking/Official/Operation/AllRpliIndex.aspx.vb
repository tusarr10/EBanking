﻿Imports DataBaseHelper
Imports DevExpress.Web

Public Class AllRpliIndex
    Inherits System.Web.UI.Page

    Private pliservice As New pliindexService(connectionstringRpli())

    Private Sub bindrid()
        ASPxGridView1.DataSource = pliservice.GetAll()
        ASPxGridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' getdata()
        '  filldata()
        bindrid() 'dapper
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

        End If
        If e.Parameters = "SendAll" Then

        End If
    End Sub

End Class