<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Developer/Developer.Master" CodeBehind="ssajournaltrns.aspx.vb" Inherits="TWEB.ssajournaltrns" %>

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
                    <h1>All ssa transction From Access DB</h1>
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
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="gridView" EnablePagingGestures="False" CssClass="grid-view" Width="100%" OnCustomCallback="GridView_CustomCallback" KeyFieldName="Notes;ACNO;today" AutoGenerateColumns="False">
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
                <dx:GridViewDataTextColumn FieldName="ACNO" Name="ACNO" Caption="ACNO" VisibleIndex="1"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Name" Name="Name" Caption="Name" VisibleIndex="2"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Depositer" Name="Depositer" Caption="Depositer" VisibleIndex="3"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="today" Name="today" Caption="today" VisibleIndex="4"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="BBT" Name="BBT" Caption="bbt" VisibleIndex="5"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Transtype" Name="Transtype" Caption="transtype" VisibleIndex="6"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Amount" Name="Amount" Caption="Amount" VisibleIndex="7"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="fine" Name="fine" Caption="fine" VisibleIndex="8"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="balance" Name="balance" Caption="balance" VisibleIndex="9"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="m_onth" Name="m_onth" Caption="m_onth" VisibleIndex="10"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DLT" Name="DLT" Caption="DLT" VisibleIndex="11"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Notes" Name="Notes" Caption="Notes" VisibleIndex="12"></dx:GridViewDataTextColumn>
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
            Selected count: <span id="selCount" style="font-weight: bold">0(Do Not Select Duplicate Trid)</span>
        </div>
    </div>

    <div class="card">
        <div class="card-view">
            <asp:UpdatePanel runat="server" ID="UPN1" UpdateMode="Conditional">
                <ContentTemplate>
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Submit" OnClick="ASPxButton1_Click" AutoPostBack="False">
                    </dx:ASPxButton>
                    <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="140px" ReadOnly="true" Width="100%"></dx:ASPxMemo>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>