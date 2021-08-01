﻿Imports DevExpress.Web

Public Class transction
    Inherits System.Web.UI.Page



    Dim filterdate As String = GetworkingDate
    Private Sub allDataFromSbTransctiondb(dat As String)
        Try
            AllTeansctionFromSBJournal(dat)
            Dim tables As DataTable
            tables = getSbJournalDataTable()
            sbjournalGridView.DataSource = tables
            sbjournalGridView.DataBind()

        Catch

        End Try
    End Sub
    Private Sub allDatafromJournalDB(dat As String)
        Try
            AllTeansctionFromJournal(dat)
            Dim tables As DataTable
            tables = JournalHelper.getjournalDataTable()
            journalgridview.DataSource = tables
            journalGridView.DataBind()
        Catch

        End Try
    End Sub

    Private Sub allDatafromRDTransctionDB(dat As String)
        Try
            RdJournalHelper.AllTeansctionFromRDJournal(dat)
            Dim tables As DataTable
            tables = getRDJournalDataTable()
            RdJournalGridView.DataSource = tables
            RdJournalGridView.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub alldatafromSSAJournalDB(dat As String)
        Try
            SSAJournalHelper.AllTeansctionFromSSAJournal(dat)
            Dim tables As DataTable
            tables = getSSAJournalDataTable()
            ssaJournalGridView.DataSource = tables
            ssaJournalGridView.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDataFromServer(filterdate As String)
        allDataFromSbTransctiondb(filterdate)
        allDatafromJournalDB(filterdate)
        allDatafromRDTransctionDB(filterdate)
        alldatafromSSAJournalDB(filterdate)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (IsPostBack = False) Then
            'Load Data From Server
            GetworkingDate = datetb.Text
            LoadDataFromServer(GetworkingDate)
        Else

        End If
    End Sub
    Protected Sub btnAction_Init(sender As Object, e As EventArgs)
        Dim btn = sender
        Dim container = btn.NamingContainer
        Dim value As String = container.Grid.GetRowValues(container.VisibleIndex, "accountnumber").ToString
        getApproveInfo.GetAccountNumber = value

        Dim value2 As String = container.Grid.GetRowValues(container.VisibleIndex, "trid").ToString
        getApproveInfo.GetTrId = value2

        Dim value3 As String = container.Grid.GetRowValues(container.visibleIndex, "accounttype").ToString

        Try
            Response.Redirect("TransctionStatusApprove.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Private Function data(sender As Object, tablename As String)
        Dim btn As Bootstrap.BootstrapButton = sender
        Dim container As Object = btn.NamingContainer

        Return container.Grid.GetRowValues(container.VisibleIndex, tablename).ToString

    End Function
    Protected Sub btnAction_Click(sender As Object, e As EventArgs) 'for sb
        Dim btn As Bootstrap.BootstrapButton = sender
        Dim container As Object = btn.NamingContainer
        Try
            Dim value As String = container.Grid.GetRowValues(container.VisibleIndex, "accountnumber").ToString
            getApproveInfo.GetAccountNumber = value
            Dim value2 As String = container.Grid.GetRowValues(container.VisibleIndex, "trid").ToString
            getApproveInfo.GetTrId = value2
            getApproveInfo.GetAcType = "Saving"
            getApproveInfo.GetName = container.Grid.GetRowValues(container.VisibleIndex, "depositername").ToString
            getApproveInfo.GetAmount = data(sender, "amount")
            getApproveInfo.GetBAT = data(sender, "bat")
            getApproveInfo.GetDate = data(sender, "da_te")
            getApproveInfo.GetBBT = data(sender, "bbt")
            getApproveInfo.GetStatus = data(sender, "status")
            getApproveInfo.GetDetailsTransction = data(sender, "Details")
            getApproveInfo.GetTransctionsType = data(sender, "transctiontype")
        Catch ex As Exception
            MyMessageBox.Show(Me, "OPPS Inform Developer .")
            Exit Sub

        Finally
            Try
                Response.Redirect("TransctionStatusApprove.aspx")
            Catch ex As Exception

            End Try
        End Try



    End Sub
    Protected Sub btnAction_Click2(sender As Object, e As EventArgs) 'For all transction

    End Sub
    Protected Sub btnAction_Click1(sender As Object, e As EventArgs) 'For RD
        Dim btn As Bootstrap.BootstrapButton = sender
        Dim container As Object = btn.NamingContainer
        Try
            Dim value As String = container.Grid.GetRowValues(container.VisibleIndex, "accountnumber").ToString
            getApproveInfo.GetAccountNumber = value
            Dim value2 As String = container.Grid.GetRowValues(container.VisibleIndex, "trid").ToString
            getApproveInfo.GetTrId = value2
            getApproveInfo.GetAcType = "RD"
            getApproveInfo.GetName = container.Grid.GetRowValues(container.VisibleIndex, "depositername").ToString
            Dim x As Double = data(sender, "amount")
            Dim y As Double = data(sender, "fine")

            getApproveInfo.GetAmount = x + y 'data(sender, "amount")

            getApproveInfo.GetBAT = data(sender, "bat")
            getApproveInfo.GetDate = data(sender, "da_te")
            getApproveInfo.GetBBT = data(sender, "bbt")
            getApproveInfo.GetStatus = data(sender, "status")
            getApproveInfo.GetDetailsTransction = data(sender, "Details")
            getApproveInfo.GetTransctionsType = data(sender, "transctiontype")
        Catch ex As Exception
            MyMessageBox.Show(Me, "OPPS Inform Developer .")
            Exit Sub

        Finally
            Try
                Response.Redirect("TransctionStatusApprove.aspx")
            Catch ex As Exception

            End Try
        End Try


    End Sub

    Protected Sub btnAction_Click3(sender As Object, e As EventArgs)
        Dim btn As Bootstrap.BootstrapButton = sender
        Dim container As Object = btn.NamingContainer
        Try
            Dim value As String = container.Grid.GetRowValues(container.VisibleIndex, "accountnumber").ToString
            getApproveInfo.GetAccountNumber = value
            Dim value2 As String = container.Grid.GetRowValues(container.VisibleIndex, "trid").ToString
            getApproveInfo.GetTrId = value2
            getApproveInfo.GetAcType = "SSA"
            getApproveInfo.GetName = container.Grid.GetRowValues(container.VisibleIndex, "depositername").ToString
            Dim x As Double = data(sender, "amount")
            Dim y As Double = data(sender, "fine")

            getApproveInfo.GetAmount = x + y 'data(sender, "amount")

            getApproveInfo.GetBAT = data(sender, "bat")
            getApproveInfo.GetDate = data(sender, "da_te")
            getApproveInfo.GetBBT = data(sender, "bbt")
            getApproveInfo.GetStatus = data(sender, "status")
            getApproveInfo.GetDetailsTransction = data(sender, "Details")
            getApproveInfo.GetTransctionsType = data(sender, "transctiontype")
        Catch ex As Exception
            MyMessageBox.Show(Me, "OPPS Inform Developer .")
            Exit Sub

        Finally
            Try
                Response.Redirect("TransctionStatusApprove.aspx")
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Protected Sub journalgridview_Init(sender As Object, e As EventArgs)
        allDatafromJournalDB(filterdate)
    End Sub

    Protected Sub sbjournalGridView_Init(sender As Object, e As EventArgs)
        allDataFromSbTransctiondb(filterdate)
    End Sub

    Protected Sub ASPxGridView1_Init(sender As Object, e As EventArgs)
        allDatafromRDTransctionDB(filterdate)
    End Sub

    Protected Sub ASPxGridView1_Init1(sender As Object, e As EventArgs)
        alldatafromSSAJournalDB(filterdate)

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Try
            filterdate = datetb.Text.ToString
            LoadDataFromServer(filterdate)
        Catch
            MyMessageBox.Show(Me, "Enter Valid Date In  {yyyy-MM-dd} formate ")
        End Try

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        Try
            ' filterdate = datetb.Text.ToString
            LoadDataFromServer("")
        Catch
            MyMessageBox.Show(Me, "Enter Valid Date In  {yyyy-MM-dd} formate ")
        End Try
    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        Try
            filterdate = datetb.Text.ToString
            LoadDataFromServer(GetworkingDate)
        Catch
            MyMessageBox.Show(Me, "Enter Valid Date In  {yyyy-MM-dd} formate ")
        End Try
    End Sub
End Class