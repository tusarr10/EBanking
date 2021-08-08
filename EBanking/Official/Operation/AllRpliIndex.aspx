<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="AllRpliIndex.aspx.vb" Inherits="TWEB.AllRpliIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/GridView.css") %>' />
    <script type="text/javascript" src='<%# ResolveUrl("~/Content/GridView1.js") %>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">

    <dx:ASPxMenu runat="server" ID="PageToolbar" ClientInstanceName="pageToolbar"
        ItemAutoWidth="false" ApplyItemStyleToTemplates="true" ItemWrap="false"
        AllowSelectItem="false" SeparatorWidth="0"
        Width="100%" CssClass="page-toolbar">

        <ClientSideEvents ItemClick="onPageToolbarItemClick" />
        <SettingsAdaptivity Enabled="true" EnableAutoHideRootItems="false"
            EnableCollapseRootItemsToIcons="true" CollapseRootItemsToIconsAtWindowInnerWidth="600" />
        <ItemStyle CssClass="item" VerticalAlign="Middle" />
        <ItemImage Width="16px" Height="16px" />
        <Items>
            <dx:MenuItem Enabled="false">
                <Template>
                    <h1>All RPLI Index Report</h1>

                </Template>
            </dx:MenuItem>
            <dx:MenuItem Name="Send" Text="Send" Alignment="Right" AdaptivePriority="2" Visible="false">
                <Image Url="~/Content/Images/add.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="SendAll" Text="SendAll" Alignment="Right" AdaptivePriority="2" Visible="false">
                <Image Url="~/Content/Images/edit.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="View" Text="View" Alignment="Right" AdaptivePriority="2">
                <Image Url="~/Content/Images/delete.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="Export" Text="Export" Alignment="Right" AdaptivePriority="2">
                <Image Url="~/Content/Images/export.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="ToggleFilterPanel" Text="" GroupName="Filter" Alignment="Right" AdaptivePriority="1">
                <Image Url="~/Content/Images/search.svg" UrlChecked="~/Content/Images/search-selected.svg" />
            </dx:MenuItem>
        </Items>
    </dx:ASPxMenu>
    <dx:ASPxPanel runat="server" ID="FilterPanel" ClientInstanceName="filterPanel"
        Collapsible="true" CssClass="filter-panel">
        <SettingsCollapsing ExpandEffect="Slide" AnimationType="Slide" ExpandButton-Visible="false" />
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxButtonEdit runat="server" ID="SearchButtonEdit" ClientInstanceName="searchButtonEdit" ClearButton-DisplayMode="Always" Caption="Search" Width="100%" />
            </dx:PanelContent>
        </PanelCollection>
        <ClientSideEvents Expanded="onFilterPanelExpanded" Collapsed="adjustPageControls" />
    </dx:ASPxPanel>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card ">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="gridView" EnablePagingGestures="False" CssClass="grid-view" Width="100%" OnCustomCallback="GridView_CustomCallback" KeyFieldName="proposalno" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0" Width="52"></dx:GridViewCommandColumn>

            </Columns>

            <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowEllipsisInText="true" AllowDragDrop="false" />
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
            <SettingsSearchPanel CustomEditorID="SearchButtonEdit" />
            <Settings VerticalScrollBarMode="Hidden" HorizontalScrollBarMode="Auto" ShowHeaderFilterButton="true" />
            <SettingsPager PageSize="15" EnableAdaptivity="true">
                <PageSizeItemSettings Visible="true"></PageSizeItemSettings>
            </SettingsPager>
            <SettingsExport EnableClientSideExportAPI="true" ExportSelectedRowsOnly="true" />
            <Columns>
                <dx:GridViewDataTextColumn VisibleIndex="1" Caption="id" FieldName="id" Name="id"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="agentId" FieldName="agentId" Name="agentId"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="3" Caption="boid" FieldName="boid" Name="boid"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="4" Caption="RecDate" FieldName="RecDate" Name="RecDate"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="5" Caption="agentSA" FieldName="agentSA" Name="agentSA"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="6" Caption="agentPremium" FieldName="agentPremium" Name="agentPremium"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="7" Caption="AgentMobile" FieldName="AgentMobile" Name="AgentMobile"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="8" Caption="CustName" FieldName="CustName" Name="CustName"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="9" Caption="custmordob" FieldName="custmordob" Name="custmordob"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="10" Caption="custmobile" FieldName="custmobile" Name="custmobile"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="11" Caption="custmornotes" FieldName="custmornotes" Name="custmornotes"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="12" Caption="custaddress" FieldName="custaddress" Name="custaddress"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="14" Caption="proposaldate" FieldName="proposaldate" Name="proposaldate"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="15" Caption="proposaltype" FieldName="proposaltype" Name="proposaltype"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="16" Caption="productcat" FieldName="productcat" Name="productcat"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="17" Caption="prefrq" FieldName="prefrq" Name="prefrq"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="18" Caption="matage" FieldName="matage" Name="matage"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="19" Caption="proposalno" FieldName="proposalno" Name="proposalno"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="20" Caption="recno" FieldName="recno" Name="recno"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="21" Caption="sa" FieldName="sa" Name="sa"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="22" Caption="premium" FieldName="premium" Name="premium"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="23" Caption="indexbo" FieldName="indexbo" Name="indexbo"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="24" Caption="userid" FieldName="userid" Name="userid"></dx:GridViewDataTextColumn>
            </Columns>

            <SettingsPopup>
                <EditForm>
                    <SettingsAdaptivity MaxWidth="800" Mode="Always" VerticalAlign="WindowCenter" />
                </EditForm>
            </SettingsPopup>
            <Styles>
                <Cell Wrap="false" />
                <PagerBottomPanel CssClass="pager" />
                <FocusedRow CssClass="focused" />
            </Styles>
            <ClientSideEvents Init="onGridViewInit" SelectionChanged="onGridViewSelectionChanged" />
        </dx:ASPxGridView>

        <div class="TopPadding">
            Selected count: <span id="selCount" style="font-weight: bold">0</span>
        </div>


    </div>


</asp:Content>
