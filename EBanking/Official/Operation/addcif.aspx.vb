Imports DataBaseHelper

Public Class addcif
    Inherits System.Web.UI.Page

    Private cifservice As New ClassCifService(connectionstringaccount)
    Dim cifclass As ClassCif

    Dim userNotAdmin As Boolean = True
    Dim replay As Boolean = False
    Dim replay1 As String = ""
    Dim gendder As String

    Dim photoName As String
    Dim signName As String

    Friend cifupdate As Boolean = False
    Friend photoPath As String
    Friend signPath As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check User Role and use to edit textbox in this form
        'just for testing
        userNotAdmin = False

        If "User" = "Admin" Then
            userNotAdmin = False
        ElseIf "User" = "Clork" Then
            userNotAdmin = True
        End If

        Try
            If signphoto.ImageUrl = Nothing Then
                signphoto.ImageUrl = "../Resour/Images/generaluser.png"
            End If
            If photophoto.ImageUrl = Nothing Then
                photophoto.ImageUrl = "../Resour/Images/generaluser.png"
            End If
        Catch ex As Exception

        End Try

    End Sub

    ' Complect Migration To Dapper on  02-09-2021
    ''' <summary>
    ''' ERROR CODE EB-CifUpdatefrmm-10
    ''' </summary>
    Private Sub subfilldata()
        Dim cifid As String = ""
        cifid = ciftb.Text.Trim
        Try
            Dim cifAvailable As Boolean = cifservice.IsCifExist(cifid)
            If cifAvailable Then
                Try
                    cifclass = New ClassCif
                    cifclass = cifservice.FindById(cifid)
                    loadData(cifclass)
                    If cifupdate = True Then
                        responselbl.Text = "Everything OK. ID Found."
                        responselbl.ForeColor = Drawing.Color.Green
                    Else
                        responselbl.Text = "Incomplect Profile. ID Found."
                        responselbl.ForeColor = Drawing.Color.Yellow
                        ' clearNocif()
                    End If
                Catch ex As Exception
                    responselbl.Text = "Id Found But Error In Getting Data(Contact DEVELOPER ERROR EB-CifUpdatefrmm-10). ID Found."
                End Try
            Else
                responselbl.Text = "O NO. ID Not Found."
                responselbl.ForeColor = Drawing.Color.Red
                CifHelper.cifupdate = False
                clearNocif()
            End If
        Catch ex As Exception
            responselbl.Text = "error" + ex.Message
        End Try

    End Sub

    Sub upload(ByVal name As String)
        Try

            If FileUpload1.HasFile Then
                Dim extension As String = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
                photoName = name + "Photo" + Format(DateAndTime.Now, "ddMMyyyyhmm") + extension
                photoPath = "~/DATA/Image/" + photoName
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/DATA/Image/") + photoName)
            End If
            If FileUpload2.HasFile Then
                Dim extension1 As String = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName)
                signName = name + "Sign" + Format(DateAndTime.Now, "ddMMyyyyhmm") + extension1
                signPath = "~/DATA/Sign/" + signName
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/DATA/Sign/") + signName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub GetDataFromView()
        cifclass = New ClassCif
        cifclass.cif = ciftb.Text.Trim
        cifclass.n_ame = nametb.Text.Trim
        cifclass.mobile = mobiletb.Text.Trim
        cifclass.email = emailtb.Text.Trim
        cifclass.pan = pantb.Text.Trim
        cifclass.adhar = adhartb.Text.Trim
        cifclass.photo = photoPath
        cifclass.sign = signPath
        cifclass.address = addresstb.Text
        cifclass.dob = dobtb.Text.Trim
        cifclass.gender = genderlb.SelectedItem.Value.ToString.Trim
        cifclass.status = statustb.Text.Trim
    End Sub

    Sub incertCif() '"insert into cifdb(cif) values(" & "'" & cif & "')"

        Try
            If ciftb.Text = Nothing Then
                responselbl.Text = "Enter CIF ID .."
                Exit Sub
            Else
                GetDataFromView()
                upload(ciftb.Text.Trim)
            End If
        Catch
            Exit Sub
        End Try

        Try
            replay = cifservice.AddCif(cifclass)
        Catch ex As Exception
            replay1 = "Error" + ex.Message
        End Try

    End Sub

    Sub UpdateCif() '"insert into cifdb(cif) values(" & "'" & cif & "')"

        Try
            If ciftb.Text = Nothing Then
                responselbl.Text = "Enter CIF ID .."
                Exit Sub
            Else
                GetDataFromView()
                upload(ciftb.Text.Trim)
            End If
        Catch

        End Try
        Try
            replay = cifservice.UpdateCif(cifclass)
        Catch ex As Exception
            replay1 = "Error" + ex.Message
        End Try

    End Sub

    Sub deleteCif(ByVal cifid As String)

        '  Dim commandstring As String
        Try
            replay = cifservice.DeleteCif(cifid)
        Catch ex As Exception
            replay1 = "Error" + ex.Message
            ' databaseconnection.Close()

        End Try
    End Sub

    Sub clearall()
        ciftb.Text = ""
        nametb.Text = ""
        statustb.Text = ""
        dobtb.Text = ""
        genderlb.SelectedIndex = 0
        mobiletb.Text = ""
        emailtb.Text = ""
        pantb.Text = ""
        adhartb.Text = ""
        addresstb.Text = ""
        photophoto.ImageUrl = ""
        signphoto.ImageUrl = ""

    End Sub

    Sub clearNocif()

        nametb.Text = ""
        statustb.Text = ""
        dobtb.Text = ""
        genderlb.SelectedIndex = 0
        mobiletb.Text = ""
        emailtb.Text = ""
        pantb.Text = ""
        adhartb.Text = ""
        addresstb.Text = ""

    End Sub

    'Complect Dapper Migration On 02-09-2021
    Sub loadData(data As ClassCif)
        Try
            If data.cif = Nothing Then
                ' ciftb.readonly = userNotAdmin
            Else
                ciftb.Text = data.cif
                '  ciftb.ReadOnly = userNotAdmin

            End If
            If data.n_ame IsNot Nothing Then
                nametb.Text = data.n_ame
                nametb.ReadOnly = userNotAdmin

            End If
            If data.email IsNot Nothing Then
                emailtb.Text = data.email
                emailtb.ReadOnly = userNotAdmin

            End If
            If data.mobile IsNot Nothing Then
                mobiletb.Text = data.mobile
                mobiletb.ReadOnly = userNotAdmin

            End If
            If data.pan IsNot Nothing Then
                pantb.Text = data.pan
                pantb.ReadOnly = userNotAdmin

            End If
            If data.adhar IsNot Nothing Then
                adhartb.Text = data.adhar
                adhartb.ReadOnly = userNotAdmin

            End If
            If data.dob IsNot Nothing Then
                dobtb.Text = data.dob
                dobtb.ReadOnly = userNotAdmin
            End If
            If data.gender IsNot Nothing Then

                genderlb.SelectedValue = data.gender
                genderlb.Enabled = Not (userNotAdmin)

            End If
            If data.address IsNot Nothing Then
                addresstb.Text = data.address
                addresstb.ReadOnly = userNotAdmin

            End If
            If data.status IsNot Nothing Then
                statustb.Text = data.status
                statustb.ReadOnly = userNotAdmin

            End If
            If data.photo IsNot Nothing Then
                photophoto.ImageUrl = data.photo
                photoPath = photophoto.ImageUrl
                Debug.WriteLine(photophoto.ImageUrl)

            End If
            If data.sign IsNot Nothing Then
                signphoto.ImageUrl = data.sign
                signPath = signphoto.ImageUrl
                Debug.WriteLine(signphoto.ImageUrl)
            End If
            If data.address IsNot Nothing And data.adhar IsNot Nothing And data.dob IsNot Nothing And data.email IsNot Nothing And data.gender IsNot Nothing And data.mobile IsNot Nothing And data.n_ame IsNot Nothing And data.pan IsNot Nothing Then
                cifupdate = True
            Else
                cifupdate = False
            End If
        Catch ex As Exception
            cifupdate = False
        Finally

        End Try
    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click
        subfilldata()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        replay1 = ""
        incertCif()
        If replay = True Then
            subfilldata()
            responselbl.Text = "Record successfully saved : "
            responselbl.ForeColor = Drawing.Color.Green
        ElseIf replay = False Then
            responselbl.Text = "Record Not saved : " + replay1
            responselbl.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        replay1 = ""
        If userNotAdmin = False Then
            UpdateCif()
            If replay = True Then
                subfilldata()
                responselbl.Text = "Record successfully Update : "
                responselbl.ForeColor = Drawing.Color.Green
            ElseIf replay = False Then
                responselbl.Text = "Record Not Update : " + replay1
                responselbl.ForeColor = Drawing.Color.Red
            End If
        Else
            responselbl.Text = "You Can Not Update : You Are Not Admin "
            responselbl.ForeColor = Drawing.Color.Red
            responselbl.BorderColor = Drawing.Color.Green
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        replay1 = ""
        If userNotAdmin = False Then
            deleteCif(ciftb.Text.Trim)
            If replay = True Then
                If cifservice.IsCifExist(ciftb.Text.Trim) = False Then
                    responselbl.Text = "Record successfully Deleted : Successfully "
                    responselbl.ForeColor = Drawing.Color.Green
                    clearall()
                Else
                    responselbl.Text = "Record successfully Deleted : No Confermation Check Again "
                    responselbl.ForeColor = Drawing.Color.YellowGreen
                End If

            ElseIf replay = False Then
                responselbl.Text = "Record Not Deleted : " + replay1
                responselbl.ForeColor = Drawing.Color.Red
            End If
        Else
            responselbl.Text = "You Can Not Delete : You Are Not Admin "
            responselbl.ForeColor = Drawing.Color.Red
            responselbl.BorderColor = Drawing.Color.Green
        End If

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        If userNotAdmin = False Then
            Dim cifId As String = ciftb.Text.Trim
            AccountStatusUpdate("Active", cifId)
            If replay Then
                statustb.Text = "Active"
            End If
        Else
            MyMessageBox.Show(Me, "U R Not Authorize to Do This")
        End If

    End Sub

    Private Sub AccountStatusUpdate(v As String, cifId As String)

        Try
            If cifservice.IsCifExist(cifId) Then
                replay = cifservice.updateStatus(cifId, v)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        If userNotAdmin = False Then
            Dim cifId As String = ciftb.Text.Trim
            AccountStatusUpdate("Pending", cifId)
            If replay Then
                statustb.Text = "Pending"
            End If
        Else
            MyMessageBox.Show(Me, "U R Not Authorize to Do This")
        End If

    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs) Handles LinkButton3.Click
        'check if u r admin or not
        If userNotAdmin = False Then
            Dim cifId As String = ciftb.Text.Trim
            AccountStatusUpdate("Block", cifId)
            If replay Then
                statustb.Text = "Block"
            End If
        Else
            MyMessageBox.Show(Me, "U R Not Authorize to Do This")
        End If

    End Sub

End Class