Imports System.Data.SqlClient

Public Class addcif
    Inherits System.Web.UI.Page

    Dim userNotAdmin As Boolean = True
    Dim replay As Boolean = False
    Dim replay1 As String = ""
    Dim gendder As String

    Dim photoName As String
    Dim signName As String

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
    ''' <summary>
    ''' ERROR CODE EB-CifUpdatefrmm-10
    ''' </summary>
    Private Sub subfilldata()
        Dim cifid As String = ""
        cifid = ciftb.Text.Trim

        Try
            CifHelper.cifsearch(cifid)
            If IsIdExist(cifid) = True Then
                Try
                    ' do fill in box
                    loadData()
                    If CifHelper.cifupdate = True Then
                        responselbl.Text = "Everything OK. ID Found."
                        responselbl.ForeColor = Drawing.Color.Green

                    Else
                        responselbl.Text = "Incomplect Profile. ID Found."
                        responselbl.ForeColor = Drawing.Color.Yellow
                        clearNocif()
                    End If
                Catch

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
        Finally
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
    Sub incertCif() '"insert into cifdb(cif) values(" & "'" & cif & "')"
        Dim commandstring As String

        Try
            If ciftb.Text = Nothing Then
                responselbl.Text = "Enter CIF ID .."
                Exit Sub
            Else
                upload(ciftb.Text.Trim)
            End If

        Catch

        End Try
        Try
            commandstring = "insert into cifdb(cif,n_ame,mobile,email,pan,adhar,photo,sign,address,dob,gender,status)values('" & ciftb.Text.Trim & "','" & nametb.Text.Trim & "','" & mobiletb.Text.Trim & "','" & emailtb.Text.Trim & "','" & pantb.Text.Trim & "','" & adhartb.Text.Trim & "','" & photoPath & "','" & signPath & "','" & addresstb.Text.Trim & "','" & dobtb.Text.Trim & "','" & genderlb.SelectedItem.Value.ToString.Trim & "','" & statustb.Text.Trim & "')"
            databaseconnection = New SqlConnection(connectionhelper.connectionstringaccount())
            datacommand = New SqlCommand(commandstring, databaseconnection)
            databaseconnection.Open()
            Dim i
            i = datacommand.ExecuteNonQuery()
            If i > 0 Then
                replay = True ' "Record successfully saved "

            Else
                replay = False '"Record Not saved "
            End If
            databaseconnection.Close()
        Catch ex As Exception
            replay1 = "Error" + ex.Message
            databaseconnection.Close()

        End Try
    End Sub

    Sub UpdateCif() '"insert into cifdb(cif) values(" & "'" & cif & "')"
        Dim commandstring As String
        Try
            If ciftb.Text = Nothing Then
                responselbl.Text = "Enter CIF ID .."
                Exit Sub
            Else
                upload(ciftb.Text.Trim)
            End If

        Catch

        End Try
        Try
            ',[cif]      ,[n_ame]      ,[mobile]      ,[email]      ,[pan]      ,[adhar]      ,[photo]      ,[sign]      ,[address]      ,[dob] ,gender]      ,[status]
            commandstring = "Update cifdb set n_ame='" & nametb.Text.Trim & "',mobile= '" & mobiletb.Text.Trim & "',email='" & emailtb.Text.Trim & "',pan='" & pantb.Text.Trim & "',adhar='" & adhartb.Text.Trim & "',photo='" & photoPath & "',sign='" & signPath & "',address='" & addresstb.Text.Trim & "',dob='" & dobtb.Text.Trim & "',gender='" & genderlb.SelectedItem.Value.ToString.Trim & "',status='" & statustb.Text.Trim & "'  where cif='" & ciftb.Text.Trim & "'"
            databaseconnection = New SqlConnection(connectionhelper.connectionstringaccount())
            datacommand = New SqlCommand(commandstring, databaseconnection)
            databaseconnection.Open()
            Dim i
            i = datacommand.ExecuteNonQuery()
            If i > 0 Then
                replay = True ' "Record successfully saved "

            Else
                replay = False '"Record Not saved "
            End If
            databaseconnection.Close()
        Catch ex As Exception
            replay1 = "Error" + ex.Message
            databaseconnection.Close()

        End Try
    End Sub
    Sub deleteCif(ByVal cifid As String)

        Dim commandstring As String
        Try
            commandstring = "delete cifdb where cif='" & cifid & "'"
            databaseconnection = New SqlConnection(connectionhelper.connectionstringaccount())
            datacommand = New SqlCommand(commandstring, databaseconnection)
            databaseconnection.Open()
            Dim i
            i = datacommand.ExecuteNonQuery()
            If i > 0 Then
                replay = True ' "Record successfully saved "

            Else
                replay = False '"Record Not saved "
            End If
            databaseconnection.Close()
        Catch ex As Exception
            replay1 = "Error" + ex.Message
            databaseconnection.Close()

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
    Sub loadData()
        Try
            If CifHelper.getcif(0) = Nothing Then
                ' ciftb.readonly = userNotAdmin
            Else
                ciftb.Text = CifHelper.getcif(0)
                '  ciftb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifname(0) IsNot Nothing Then
                nametb.Text = CifHelper.getcifname(0)
                nametb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifemail(0) IsNot Nothing Then
                emailtb.Text = CifHelper.getcifemail(0)
                emailtb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifmobile(0) IsNot Nothing Then
                mobiletb.Text = CifHelper.getcifmobile(0)
                mobiletb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifpan(0) IsNot Nothing Then
                pantb.Text = CifHelper.getcifpan(0)
                pantb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifadhar(0) IsNot Nothing Then
                adhartb.Text = CifHelper.getcifadhar(0)
                adhartb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifdob(0) IsNot Nothing Then
                dobtb.Text = CifHelper.getcifdob(0)
                dobtb.ReadOnly = userNotAdmin
            End If
            If CifHelper.getcifgender(0) IsNot Nothing Then
                'If CifHelper.getcifgender(0) = "Male" Then
                '    gendertb.SelectedIndex = 0
                'ElseIf CifHelper.getcifgender(0) = "Female" Then
                '    RadioGroup1.SelectedIndex = 1
                'ElseIf CifHelper.getcifgender(0) = "Other" Then
                '    RadioGroup1.SelectedIndex = 2
                'End If
                genderlb.SelectedValue = CifHelper.getcifgender(0)
                genderlb.Enabled = Not (userNotAdmin)

            End If
            If CifHelper.getcifaddress(0) IsNot Nothing Then
                addresstb.Text = CifHelper.getcifaddress(0)
                addresstb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifStatus(0) IsNot Nothing Then
                statustb.Text = CifHelper.getcifStatus(0)
                statustb.ReadOnly = userNotAdmin

            End If
            If CifHelper.getcifphoto(0) IsNot Nothing Then
                photophoto.ImageUrl = CifHelper.getcifphoto(0)
                photoPath = photophoto.ImageUrl
                Debug.WriteLine(photophoto.ImageUrl)

            End If
            If CifHelper.getcifsign(0) IsNot Nothing Then
                signphoto.ImageUrl = CifHelper.getcifsign(0)
                signPath = signphoto.ImageUrl
                Debug.WriteLine(signphoto.ImageUrl)
            End If
            If getcifaddress(0) IsNot Nothing And getcifadhar(0) IsNot Nothing And getcifdob(0) IsNot Nothing And getcifemail(0) IsNot Nothing And getcifgender(0) IsNot Nothing And getcifmobile(0) IsNot Nothing And getcifname(0) IsNot Nothing And getcifpan(0) IsNot Nothing Then
                CifHelper.cifupdate = True
            Else
                CifHelper.cifupdate = False
            End If
            'or we can 
            ' status ="Approve"
            'then cifhelper.cifupdated =true

        Catch ex As Exception
            CifHelper.cifupdate = False
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
            ''Must Implectment Dialog 
            deleteCif(ciftb.Text.Trim)
            CifHelper.cifsearch(ciftb.Text.Trim)
            If replay = True Then
                If IsIdExist(ciftb.Text.Trim) = False Then
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
            cifsearch(cifId) 'Get Data By Account Id 
        Catch
            'Id Not Found OR Account Does Not Exist
        End Try
        If IsIdExist(cifId) Then
            Try
                databaseconnection = New SqlConnection(connectionstringaccount())
                datacommand = New SqlCommand("UPDATE " & ciftable & " set status ='" & v & "' where cif='" & cifId & "'", databaseconnection)
                databaseconnection.Open()
                Dim i = datacommand.ExecuteNonQuery()
                If i > 0 Then
                    replay = True ' Data Update Successfully
                Else
                    replay = False 'Data Not Update 

                End If
                databaseconnection.Close()
            Catch ex As Exception
                databaseconnection.Close()
            End Try
        End If
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