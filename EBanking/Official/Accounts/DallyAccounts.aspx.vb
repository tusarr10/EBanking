Imports DevExpress.Web
Imports DataBaseHelper

Public Class DallyAccounts
    Inherits System.Web.UI.Page

    Private Data As dacClass
    Private dataservice As New dacService(connectionstringoperate)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub GetDataFromView()
        Data = New dacClass
        Dim x As String
        'x = datetb.Text '.ToString("dd MMMM yyyy")
        'Dim newDate As Date = DateTime.ParseExact(x, "yyyy-MM-dd",
        '   Globalization.CultureInfo.InvariantCulture)
        Data.D_ate = datetb.Text ' newDate.ToString("dd MMMM yyyy")
        Data.Open_bal = "0" & obtb.Text.Trim
        Data.cashrec = "0" & crdtb.Text.Trim
        Data.Sbdep = "0" & sbdtb.Text.Trim
        Data.rddep = "0" & rddtb.Text.Trim
        Data.ssadep = "0" & ssadtb.Text.Trim
        Data.ssafine = "0" & ssaftb.Text.Trim
        Data.rdfine = "0" & rdftb.Text.Trim
        Data.tddep = "0" & tddtb.Text.Trim
        Data.rplidep = "0" & rplidtb.Text.Trim
        Data.rplifine = "0" & rpliftb.Text.Trim
        Data.rplitax = "0" & rplittb.Text.Trim
        Data.vpp = "0" & vppdtb.Text.Trim
        Data.othcol1 = "0" & ippbdtb.Text.Trim
        Data.othcol2 = "0" & cscdtb.Text.Trim
        Data.totaldep = Data.Open_bal + Data.cashrec + Data.Sbdep + Data.rddep + Data.ssadep + Data.ssafine + Data.rdfine + Data.tddep + Data.rplidep + Data.rplifine + Data.rplitax + Data.vpp + Data.othcol1 + Data.othcol2
        totaldtb.Text = Data.totaldep
        ' Data.totaldep = "0" & totaldtb.Text.Trim

        Data.cashremet = "0" & crwtb.Text.Trim
        Data.sbwith = "0" & sbwtb.Text.Trim
        Data.rdwith = "0" & rdwtb.Text.Trim
        Data.ssawith = "0" & ssawtb.Text.Trim
        Data.tdwith = "0" & tdwtb.Text.Trim
        Data.rpliwith = "0" & rpliwtb.Text.Trim
        Data.MONwith = "0" & monwtb.Text.Trim
        Data.othwith = "0" & ippbwtb.Text.Trim
        Data.totalwith = Data.cashremet + Data.sbwith + Data.rdwith + Data.ssawith + Data.tdwith + Data.rpliwith + Data.MONwith + Data.othwith ' "0" & totalwithtb.Text.Trim
        totalwithtb.Text = Data.totalwith




        Data.Closebal = Data.totaldep - Data.totalwith ' "0" & baltb.Text.Trim
        baltb.Text = Data.Closebal

        Data.stamp1 = "0" & stamptb.Text.Trim
        Data.stamp2 = "0" & stamp2tb.Text.Trim
        Data.curr_ency = Data.Closebal - Data.stamp1 - Data.stamp2 '"0" & cashtb.Text.Trim
        cashtb.Text = Data.curr_ency
        avbtb.Text = Data.Closebal

    End Sub
    Private Sub FillDataInView(data As dacClass)


        '  datetb.Text = data.D_ate

        'Dim newDate As Date = DateTime.ParseExact(data.D_ate, "dd MMMM yyyy",
        '   Globalization.CultureInfo.InvariantCulture)
        '' data.D_ate = newDate.ToString("dd MMMM yyyy")

        datetb.Text = data.D_ate 'newDate.ToString("yyyy-MM-dd")
        obtb.Text = data.Open_bal
        crdtb.Text = data.cashrec
        sbdtb.Text = data.Sbdep
        rddtb.Text = data.rddep
        ssadtb.Text = data.ssadep
        ssaftb.Text = data.ssafine
        rdftb.Text = data.rdfine
        tddtb.Text = data.tddep
        rplidtb.Text = data.rplidep
        rpliftb.Text = data.rplifine
        rplittb.Text = data.rplitax
        vppdtb.Text = data.vpp
        ippbdtb.Text = data.othcol1
        cscdtb.Text = data.othcol2
        totaldtb.Text = data.totaldep

        crwtb.Text = data.cashremet
        sbwtb.Text = data.sbwith
        rdwtb.Text = data.rdwith
        ssawtb.Text = data.ssawith
        tdwtb.Text = data.tdwith
        rpliwtb.Text = data.rpliwith
        monwtb.Text = data.MONwith
        ippbwtb.Text = data.othwith
        totalwithtb.Text = data.totalwith

        cashtb.Text = data.curr_ency
        stamptb.Text = data.stamp1
        stamp2tb.Text = data.stamp2
        baltb.Text = data.Closebal

        avbtb.Text = data.Closebal
    End Sub

    Protected Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click

        If Not avbtb.Text = "00" Then
            obtb.Text = avbtb.Text
            'do clear other text field


        End If


    End Sub

    Protected Sub btncalculate_Click(sender As Object, e As EventArgs) Handles btncalculate.Click
        GetDataFromView()

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        GetDataFromView()
        If Not dataservice.IsDataExist(Data) Then
            Dim x As Boolean
            x = dataservice.InsertData(Data)
            If x Then
                MyMessageBox.Show(Me, "Successfully added data ")
            Else
                MyMessageBox.Show(Me, "failled added data ")
            End If
        Else
            MyMessageBox.Show(Me, "already data available ")
        End If
    End Sub

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        GetDataFromView()
        If dataservice.IsDataExist(Data) Then
            Dim x As Boolean
            x = dataservice.Update(Data)
            If x Then
                MyMessageBox.Show(Me, "Successfully updated data ")
            Else
                MyMessageBox.Show(Me, "failled updated data ")
            End If
        Else
            MyMessageBox.Show(Me, " data not available ")
        End If
    End Sub

    Protected Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        GetDataFromView()
        If dataservice.IsDataExist(Data) Then
            Dim x As Boolean
            x = dataservice.Delete(Data)
            If x Then
                MyMessageBox.Show(Me, "Successfully deleted data ")
            Else
                MyMessageBox.Show(Me, "failled deleted data ")
            End If
        Else
            MyMessageBox.Show(Me, " data not available ")
        End If
    End Sub

    Protected Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        '' go to generate report where we can generate report and print daily account 
        Data = New dacClass
        Try
            Data = dataservice.SearchByDate(datetb.Text)
            FillDataInView(Data)
        Catch ex As Exception
            MyMessageBox.Show(Me, "Data Not Available ")
        End Try





    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        Data = New dacClass
        Try
            Data = dataservice.SearchByDate(datetb.Text)
            FillDataInView(Data)
        Catch ex As Exception
            MyMessageBox.Show(Me, "Data Not Available ")
        End Try

    End Sub
End Class