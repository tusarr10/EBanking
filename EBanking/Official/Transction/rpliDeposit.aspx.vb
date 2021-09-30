Imports DataBaseHelper

Public Class rpliDeposit
    Inherits System.Web.UI.Page

    Private depositdata As classPliTransction
    Private dataservice As New PliTransctionService(connectionstringRpli)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'get data from view
        getdataFromView()
        If Not dataservice.IstransctioNExist(depositdata.recno) Then
            Dim x As Boolean
            x = dataservice.AddTransctionfile(depositdata)
            If x Then
                MyMessageBox.Show(Me, "Successfully add transction ")
            Else
                MyMessageBox.Show(Me, "failled to add transction ")
            End If
        Else
            MyMessageBox.Show(Me, "Already Trid Exist ")
        End If
        'then post

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
    Private Sub getdataFromView()
        depositdata = New classPliTransction
        depositdata.policyNo = accIdTb.Text.Trim
        depositdata.name = nametb.Text
        depositdata.recno = transctiontb.Text.Trim
        depositdata.dat_e = DateofTransction.Text.Trim
        depositdata.id = depositdata.recno & depositdata.policyNo
        depositdata.month = tillDateTB.Text
        depositdata.type = detailstb.Text
        depositdata.totalrec = "0" & DepositAmounttb.Text.Trim
        depositdata.gst = fun(depositdata.totalrec)
        depositdata.amount = depositdata.totalrec - depositdata.gst
    End Sub

    Protected Sub btnFindAccount_Click(sender As Object, e As EventArgs) Handles btnFindAccount.Click
        Try
            If dataservice.IsPolicyExist(accIdTb.Text.Trim) Then
                depositdata = New classPliTransction
                depositdata = dataservice.FindBuPolicy(accIdTb.Text.Trim)
                nametb.Text = depositdata.name.ToString
                DepositAmounttb.Text = depositdata.totalrec.ToString
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class