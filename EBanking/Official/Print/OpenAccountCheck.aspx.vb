Imports DataBaseHelper
Public Class OpenAccountCheck
    Inherits System.Web.UI.Page

    Dim newac As NewAccountClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'load data from module
        Try
            lbacname.Text = newac.n_ame ' name
            lbdob.Text = newac.dob ' dob
            lbgender.Text = newac.gender ' gender
            lbmobile.Text = newac.mobile
            lbemail.Text = newac.email
            lbadhar.Text = newac.adhar
            lbpan.Text = newac.pan
            lbaddress.Text = newac.address

            lbproduct.Text = newac.producttype
            lbValue.Text = newac.productvalue
            lbterm.Text = newac.productterm

            lbmop.Text = newac.acoperatemode
            lbGuardian.Text = newac.guardianname
            lbrelation.Text = "" 'newac.relation
            lbname2.Text = newac.jointname

            lbnominireg.Text = newac.nominireg
            lbnomininame.Text = newac.nomininame
            lbnominiaddress.Text = newac.nominiaddress
            lbnominidob.Text = newac.nominiage ' dob
            lbnominirelation.Text = newac.nominirelation

            lbbalance.Text = newac.balance
            lbtrid.Text = newac.trid

            lbacno.Text = newac.accountnumber
            lbcif.Text = newac.cif
            lbdoo.Text = newac.doo
            lbreffno.Text = newac.reffno
            lbprno.Text = newac.pr
            lbstatus.Text = newac.status
        Catch

        End Try

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "Print", "window.print();", True)
    End Sub

End Class