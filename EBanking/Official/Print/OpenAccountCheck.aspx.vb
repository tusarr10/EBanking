Public Class OpenAccountCheck
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'load data from module
        Try
            lbacname.Text = name
            lbdob.Text = dob
            lbgender.Text = gender
            lbmobile.Text = mobile
            lbemail.Text = email
            lbadhar.Text = adhar
            lbpan.Text = pan
            lbaddress.Text = address

            lbproduct.Text = producttype1
            lbValue.Text = productvalue
            lbterm.Text = productterm

            lbmop.Text = acoperatemode
            lbGuardian.Text = guardianname
            lbrelation.Text = relation
            lbname2.Text = jointname

            lbnominireg.Text = nomini
            lbnomininame.Text = nomininame
            lbnominiaddress.Text = nominiaddress
            lbnominidob.Text = nominiage ' dob
            lbnominirelation.Text = nominirelation

            lbbalance.Text = balance
            lbtrid.Text = trid

            lbacno.Text = accountnumber
            lbcif.Text = cif
            lbdoo.Text = doo
            lbreffno.Text = reffno
            lbprno.Text = pr
            lbstatus.Text = acstatus
        Catch

        End Try

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "window.print();", True)
    End Sub

End Class