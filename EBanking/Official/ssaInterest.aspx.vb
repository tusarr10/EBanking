Public Class ssaInterest
    Inherits System.Web.UI.Page
    Protected Sub trtype_TextChanged(sender As Object, e As EventArgs)
        If trtype.Text = "Deposit" Then
            amounttb.ReadOnly = False
            amountlb.Text = "Deposit Amount "
        ElseIf trtype.Text = "Withdraw" Then
            amounttb.ReadOnly = True
            amounttb.Text = "00"
            MyMessageBox.Show(Me, "SSA Withdraw Not Available ")
        ElseIf trtype.Text = "Interest" Then
            amounttb.ReadOnly = False
            amountlb.Text = "Interset Amount "
        Else
            amounttb.ReadOnly = True
            amounttb.Text = "00"
            MyMessageBox.Show(Me, "Choose Transction Type .. ")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class