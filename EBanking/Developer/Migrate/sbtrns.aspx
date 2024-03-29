﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Developer/Developer.Master" CodeBehind="sbtrns.aspx.vb" Inherits="TWEB.sbtrns" %>

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
                <dx:GridViewDataColumn FieldName="CustmorName" Name="CustmorName" Caption="Name" Width="250" VisibleIndex="2">
                    <Settings FilterMode="DisplayText"></Settings>
                </dx:GridViewDataColumn>
                <%--ForNAme--%>
                <dx:GridViewDataDateColumn FieldName="AcNo" Name="AcNo" Caption="Account Number" VisibleIndex="1" Width="180"></dx:GridViewDataDateColumn>
                <%--FOR ACON--%>

                <dx:GridViewDataComboBoxColumn FieldName="AcType" ShowInCustomizationForm="True" Name="AcType" Width="150px" Caption="AcType" VisibleIndex="4">
                </dx:GridViewDataComboBoxColumn>
                <%--FOR Producttype--%>

                <dx:GridViewDataComboBoxColumn FieldName="NominiName" ShowInCustomizationForm="True" Name="NominiName" Width="100px" Caption="NominiName" VisibleIndex="5">
                </dx:GridViewDataComboBoxColumn>
                <%--FOR NOMINI--%>

                <dx:GridViewDataTextColumn FieldName="Email" ShowInCustomizationForm="True" Name="Email" Width="150px" Caption="CIF Id" VisibleIndex="3"></dx:GridViewDataTextColumn>
                <%--For cif--%>

                <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" Name="Notes" Width="200px" Caption="Notes" VisibleIndex="6"></dx:GridViewDataTextColumn>
                <%--AccountType--%>

                <dx:GridViewDataTextColumn FieldName="FatherName" ShowInCustomizationForm="True" Name="FatherName" Width="200px" Caption="guardin name" VisibleIndex="7"></dx:GridViewDataTextColumn>
                <%--Guardian Name--%>

                <dx:GridViewDataTextColumn FieldName="AcBal" ShowInCustomizationForm="True" Name="AcBal" Width="100px" Caption="AcBal" VisibleIndex="8"></dx:GridViewDataTextColumn>
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