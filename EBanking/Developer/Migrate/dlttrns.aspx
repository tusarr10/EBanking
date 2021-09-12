<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Developer/Developer.Master" CodeBehind="dlttrns.aspx.vb" Inherits="TWEB.dlttrns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <h1>All User From Access DB</h1>
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
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="gridView" EnablePagingGestures="False" CssClass="grid-view" Width="100%" OnCustomCallback="GridView_CustomCallback" KeyFieldName="AcNo" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="52"></dx:GridViewCommandColumn>

                <dx:GridViewDataDateColumn FieldName="AcNo" Name="AcNo" Caption="Account Number" VisibleIndex="1" Width="280"></dx:GridViewDataDateColumn>
                <%--FOR ACON--%>
                <dx:GridViewDataTextColumn FieldName="DLT" ShowInCustomizationForm="True" Name="DLT" Width="250px" Caption="DLT" VisibleIndex="6"></dx:GridViewDataTextColumn>
                <%--dlt--%>

                <dx:GridViewDataTextColumn FieldName="DLT2" ShowInCustomizationForm="True" Name="DLT2" Width="250px" Caption="DLT2" VisibleIndex="7"></dx:GridViewDataTextColumn>
                <%--Gdlt2--%>

                <dx:GridViewDataTextColumn FieldName="Acbal" ShowInCustomizationForm="True" Name="Acbal" Width="200px" Caption="Acbal" VisibleIndex="8"></dx:GridViewDataTextColumn>
                <%--Account Balaance--%>
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

    <div class="card">
        <div class="card-view">
            <asp:UpdatePanel runat="server" ID="UPN1" UpdateMode="Conditional">
                <ContentTemplate>
                    <%--    <asp:Button runat="server" ID="Button1xyz" Text="Submit" OnClick="btn2_Click" />--%>
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit" OnClick="btn2_Click" AutoPostBack="False">
                        <%-- <ClientSideEvents Click="function(s, e) {
                        Callback.PerformCallback();
                        LoadingPanel.Show();
                    }" />--%>
                    </dx:ASPxButton>
                    <asp:Button runat="server" ID="btn1" Text="Submit" OnClick="btn1_Click" Visible="False" />

                    <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="140px" ReadOnly="true" Width="100%"></dx:ASPxMemo>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel"
        Modal="True">
    </dx:ASPxLoadingPanel>
</asp:Content>