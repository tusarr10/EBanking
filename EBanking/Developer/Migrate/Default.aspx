<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Developer/Developer.Master" CodeBehind="Default.aspx.vb" Inherits="TWEB._Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--start highlighted block--%>
    <script type="text/javascript">
		function onFileUploadComplete(s, e) {
			if(e.callbackData) {
				var fileData = e.callbackData.split('|');
				var fileName = fileData[0],
					fileUrl = fileData[1],
					fileSize = fileData[2];
				DXUploadedFilesContainer.AddFile(fileName, fileUrl, fileSize);
			}
		}
    </script>
    <%--end highlighted block--%>
    <script src="../../Content/Demo.js"></script>
    <link href="../../Content/Common.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">
    <br />
    <br />
    <div class="uploadContainer">
        <dx:ASPxUploadControl ID="UploadControl" runat="server" ClientInstanceName="UploadControl" Width="100%"
            NullText="Select multiple files..." UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True"
            OnFileUploadComplete="UploadControl_FileUploadComplete">
            <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True" />
            <ValidationSettings MaxFileSize="11194304" AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.pdf ,.accdb">
            </ValidationSettings>
            <ClientSideEvents FilesUploadStart="function(s, e) { DXUploadedFilesContainer.Clear(); }"
                FileUploadComplete="onFileUploadComplete" />
        </dx:ASPxUploadControl>
        <br />
        <br />
        <p class="note">
            <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="Allowed file extensions: .jpg, .jpeg, .gif, .png. ,.pdf ,.accdb" Font-Size="8pt">
            </dx:ASPxLabel>
            <br />
            <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="Maximum file size: 11 MB." Font-Size="8pt">
            </dx:ASPxLabel>
        </p>
    </div>

    <div class="filesContainer">

        <dx:UploadedFilesContainer ID="FileContainer" runat="server" Width="100%" Height="180"
            NameColumnWidth="240" SizeColumnWidth="70" HeaderText="Uploaded files" />
    </div>
    <div class="contentFooter">
        <p class="Note">
            <b>Note</b>: All files uploaded to this demo will be automatically deleted in 5 minutes.
        </p>
    </div>
</asp:Content>