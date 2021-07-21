<%@ Control Language="vb" %>
<script runat="server">

    Public Property Width() As Unit
    Public Property Height() As Unit
    Public Property NameColumnWidth() As Unit
    Public Property SizeColumnWidth() As Unit
    Public Property ThumbColumnWidth() As Unit
    Public Property HeaderText() As String
    Public Property UseExtendedPopup() As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        FilesRoundPanel.Width = Width
        FilesRoundPanel.Height = Height
        FilesRoundPanel.HeaderText = HeaderText
    End Sub
    Protected Function GetOptionsString() As String
        Return "'" & GetStyleAttributeValue(NameColumnWidth) & "', '" & GetStyleAttributeValue(SizeColumnWidth) & "', '" & GetStyleAttributeValue(ThumbColumnWidth) & "', " & UseExtendedPopup.ToString().ToLower()
    End Function
    Protected Function GetStyleAttributeValue(ByVal width As Unit) As String
        Return If((Not width.IsEmpty), String.Format("width: {0}; max-width: {0}", width.ToString()), String.Empty)
    End Function
</script>
<script type="text/javascript">
    DXUploadedFilesContainer.ApplySettings(<%=GetOptionsString()%>);
</script>
<dx:ASPxRoundPanel ID="FilesRoundPanel" ClientInstanceName="FilesRoundPanel" runat="server" CssClass="uploadFilesContainerPanel">
    <PanelCollection>
        <dx:PanelContent runat="server">
            <table id="uploadedFilesContainer" class="uploadedFilesContainer">
                <tbody></tbody>
            </table>
        </dx:PanelContent>
    </PanelCollection>
</dx:ASPxRoundPanel>
