Imports System.IO
Imports DevExpress.Web

Public Class _Default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Const UploadDirectory As String = "~/Developer/Data/"
    Protected Sub UploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
        Dim resultExtension As String = Path.GetExtension(e.UploadedFile.FileName)
        Dim resultFileName As String = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension)
        Dim name As String = e.UploadedFile.FileName
        Dim resultFileUrl As String = UploadDirectory & name
        Dim resultFilePath As String = MapPath(resultFileUrl)
        e.UploadedFile.SaveAs(resultFilePath)

        RemoveFileWithDelay(resultFileName, resultFilePath, 5)


        Dim url As String = ResolveClientUrl(resultFileUrl)
        Dim sizeInKilobytes As Long = e.UploadedFile.ContentLength / 1024
        Dim sizeText As String = sizeInKilobytes.ToString() & " KB"
        e.CallbackData = name & "|" & url & "|" & sizeText
    End Sub
    Public Shared Sub RemoveFileWithDelay(ByVal key As String, ByVal fullPath As String, ByVal delay As Integer)
        RemoveFileWithDelayInternal(key, fullPath, delay, AddressOf FileSystemRemoveAction)

    End Sub
    Private Shared Sub FileSystemRemoveAction(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        Dim fileFullPath As String = value.ToString()
        If File.Exists(fileFullPath) Then
            File.Delete(fileFullPath)
        End If
    End Sub
    Private Const RemoveTaskKeyPrefix As String = "DXRemoveTask_"
    Private Shared Sub RemoveFileWithDelayInternal(ByVal fileKey As String, ByVal fileData As Object, ByVal delay As Integer, ByVal removeAction As CacheItemRemovedCallback)
        Dim key As String = RemoveTaskKeyPrefix & fileKey
        If HttpRuntime.Cache(key) Is Nothing Then
            Dim absoluteExpiration As Date = Date.UtcNow.Add(New TimeSpan(0, delay, 0))
            HttpRuntime.Cache.Insert(key, fileData, Nothing, absoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, removeAction)
        End If
    End Sub
End Class