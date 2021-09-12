Imports System.Runtime.CompilerServices

Module DataInformation

    Public ciftable As String = "cifdb"
    Public nominitable As String = "nominiinfo"
    Public liveAccountTable As String = "liveaccount"
    Public accountOperateTable As String = "accountopratemode"
    Public productTypeTable As String = "producttype"
    Public dlttable As String = "dlt"
    Public sbjournaltbl As String = "sbjournal"
    Public journaltbl As String = "journal"
    Public rdjournaltbl As String = "rdjournal"
    Public ssajournaltbl As String = "ssajournal"
    Public tdjournaltbl As String = "tdjournal"
    Public newaccounttable As String = "newacdb"

    'Some Control
    Public WorkingData As String = GetWorKingDate() '""

    Public GetofficeId As String = "12345"
    Public GetuserID As String = "6789"

    Public Getusername As String = "Developer"
    Public OfficeName As String = "Talita"

    'Some Unnacessary Data
    'CONSTANTS
    Public filterdate As String
    Public _name2 As String
    Public _name_OA As String


    Public Function GetWorKingDate() As String
        Return DateAndTime.Now().ToString("yyyy-MM-dd")
    End Function

End Module
Module MyMessageBox

    <Extension()>
    Sub Show(ByVal Page As Page, ByVal Message As String)
        Page.ClientScript.RegisterStartupScript(Page.[GetType](), "MessageBox", "<script language='javascript'>alert('" & Message & "');</script>")
    End Sub

End Module
Module myMsgBox

    <Extension()>
    Sub Show(ByVal page As Page, ByVal url As String)
        Dim message As String = "Your details have been saved successfully."
        Dim script As String = "window.onload = function(){ alert('"
        script &= message
        script &= "');"
        script &= "window.location = '"
        script &= url 'Request.Url.AbsoluteUri
        script &= "'; }"
        page.ClientScript.RegisterStartupScript(page.GetType(), "SuccessMessage", script, True)
    End Sub

End Module