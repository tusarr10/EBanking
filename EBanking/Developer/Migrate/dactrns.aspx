<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Developer/Developer.Master" CodeBehind="dactrns.aspx.vb" Inherits="TWEB.dactrns" %>
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
                    <h1>All New User From Access DB</h1>
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
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="gridView" EnablePagingGestures="False" CssClass="grid-view" Width="100%" OnCustomCallback="GridView_CustomCallback" KeyFieldName="D_ate" AutoGenerateColumns="False">
            <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowEllipsisInText="true" AllowDragDrop="false" />
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
            <SettingsSearchPanel CustomEditorID="SearchButtonEdit" />
            <Settings VerticalScrollBarMode="Hidden" HorizontalScrollBarMode="Auto" ShowHeaderFilterButton="true" />
            <SettingsPager PageSize="15" EnableAdaptivity="true">
                <PageSizeItemSettings Visible="true"></PageSizeItemSettings>
            </SettingsPager>
            <SettingsExport EnableClientSideExportAPI="true" ExportSelectedRowsOnly="true" />
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="52"></dx:GridViewCommandColumn>

                <dx:GridViewDataTextColumn FieldName="Open_bal" Name="Open_bal" Caption="Open_bal" VisibleIndex="2"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="cashrec" Name="cashrec" Caption="cashrec" VisibleIndex="3"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Sbdep" Name="Sbdep" Caption="Sbdep" VisibleIndex="4"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rddep" Name="rddep" Caption="rddep" VisibleIndex="5"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rdfine" Name="rdfine" Caption="rdfine" VisibleIndex="6"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ssadep" Name="ssadep" Caption="ssadep" VisibleIndex="7"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ssafine" Name="ssafine" Caption="ssafine" VisibleIndex="8"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="tddep" Name="tddep" Caption="tddep" VisibleIndex="9"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rplidep" Name="rplidep" Caption="rplidep" VisibleIndex="10"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rplifine" Name="rplifine" Caption="rplifine" VisibleIndex="11"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rplitax" Name="rplitax" Caption="rplitax" VisibleIndex="12"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vpp" Name="vpp" Caption="vpp" VisibleIndex="13"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="othcol1" Name="othcol1" Caption="othcol1" VisibleIndex="14"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="othcol2" Name="othcol2" Caption="othcol2" VisibleIndex="15"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="totaldep" Name="totaldep" Caption="totaldep" VisibleIndex="16"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="cashremet" Name="cashremet" Caption="cashremet" VisibleIndex="17"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="sbwith" Name="sbwith" Caption="sbwith" VisibleIndex="18"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rdwith" Name="rdwith" VisibleIndex="19"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ssawith" Name="ssawith" VisibleIndex="20"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="rpliwith" Name="rpliwith" VisibleIndex="22"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MONwith" Name="MONwith" VisibleIndex="23"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="othwith" Name="othwith" VisibleIndex="24"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="totalwith" Name="totalwith" VisibleIndex="25"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="curr_ency" Name="curr_ency" VisibleIndex="26"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="stamp1" Name="stamp1" VisibleIndex="27"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="stamp2" Name="stamp2" VisibleIndex="28"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="colsebal" Name="colsebal" VisibleIndex="29"></dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="D_ate" Name="D_ate" Caption="D_ate" VisibleIndex="1">
                    <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>

                <dx:GridViewDataTextColumn FieldName="tdwith" Name="tdwith" VisibleIndex="21"></dx:GridViewDataTextColumn>
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
                    </dx:ASPxButton>
                      <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Update" OnClick="ASPxButton2_Click" AutoPostBack="False">
                    </dx:ASPxButton>
                    <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="140px" ReadOnly="true" Width="100%"></dx:ASPxMemo>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel"
        Modal="True">
    </dx:ASPxLoadingPanel>



</asp:Content>
