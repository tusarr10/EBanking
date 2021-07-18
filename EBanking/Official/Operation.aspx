<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="Operation.aspx.vb" Inherits="TWEB.Operation" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/GridView.css") %>' />
    <script type="text/javascript" src='<%# ResolveUrl("~/Content/GridView.js") %>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
    <h3 class="leftpanel-section section-caption">Operation Type</h3>
    <dx:ASPxTreeView runat="server" ID="TableOfContentsTreeView" ClientInstanceName="tableOfContentsTreeView"
        EnableNodeTextWrapping="true" AllowSelectNode="true" Width="100%" SyncSelectionMode="None" DataSourceID="NodesDataSource" NodeLinkMode="ContentBounds">
        <Styles>
            <Elbow CssClass="tree-view-elbow" />
            <Node CssClass="tree-view-node" HoverStyle-CssClass="hovered" />
        </Styles>
        <ClientSideEvents NodeClick="function (s, e) { HideLeftPanelIfRequired(); }" />
    </dx:ASPxTreeView>

    <asp:XmlDataSource ID="NodesDataSource" runat="server" DataFile="~/App_Data/DefaultLeft.xml" XPath="//Nodes/ReportNode/*" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="PageToolbar">

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
                    <h1>Grid View</h1>
                </Template>
            </dx:MenuItem>
            <dx:MenuItem Name="Deposit" Text="Deposit" Alignment="Right" AdaptivePriority="2">
                <Image Url="../Content/Images/add.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="Withdraw" Text="Withdraw" Alignment="Right" AdaptivePriority="2">
                <Image Url="../Content/Images/edit.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="View" Text="View" Alignment="Right" AdaptivePriority="2">
                <Image Url="../Content/Images/delete.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="Export" Text="Export" Alignment="Right" AdaptivePriority="2">
                <Image Url="../Content/Images/export.svg" />
            </dx:MenuItem>
            <dx:MenuItem Name="ToggleFilterPanel" Text="" GroupName="Filter" Alignment="Right" AdaptivePriority="1">
                <Image Url="../Content/Images/search.svg" UrlChecked="../Content/Images/search-selected.svg" />
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
    <div class="card ">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="gridView" EnablePagingGestures="False" CssClass="grid-view" Width="100%" OnCustomCallback="GridView_CustomCallback" KeyFieldName="accountnumber" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0" Width="52"></dx:GridViewCommandColumn>
                <dx:GridViewDataColumn FieldName="n_ame" Name="n_ame" Caption="Name" Width="250" VisibleIndex="2">
                    <Settings FilterMode="DisplayText"></Settings>
                </dx:GridViewDataColumn>
                <dx:GridViewDataComboBoxColumn FieldName="producttype" Name="producttype" Width="150" Caption="Product Type" VisibleIndex="3">
                    <PropertiesComboBox>
                        <Columns>
                            <dx:ListBoxColumn FieldName="Saving" Name="Saving" Caption="Saving Bank"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="RD" Name="RD" Caption="RD"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="SSA" Name="SSA" Caption="SSA"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="TD" Name="TD" Caption="TD"></dx:ListBoxColumn>
                        </Columns>
                    </PropertiesComboBox>

                    <Settings FilterMode="DisplayText"></Settings>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataDateColumn FieldName="accountnumber" Name="accountnumber" Caption="Account Number" VisibleIndex="1" Width="180"></dx:GridViewDataDateColumn>

                <dx:GridViewDataComboBoxColumn FieldName="acctype" Name="acctype" Caption="Account Type" Width="100" VisibleIndex="5">
                    <PropertiesComboBox>
                        <Columns>
                            <dx:ListBoxColumn FieldName="Self" Name="Self" Caption="Self"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="Minor" Name="Minor" Caption="Minor"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="JointA" Name="JointA" Caption="Joint A"></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="JointB" Name="JointB" Caption="Joint B"></dx:ListBoxColumn>
                        </Columns>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="cif" Width="150" Name="cif" Caption="CIF Id" VisibleIndex="2"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="jointname" Name="jointname" Caption="Joint Holder Name" VisibleIndex="6" Width="200"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="guardianname" Name="guardianname" Caption="Guardian Nmae" VisibleIndex="7" Width="200"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="balance" Name="balance" Caption="Balance " Width="100" VisibleIndex="8"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="status" Name="status" Caption="Status" Width="100" VisibleIndex="9"></dx:GridViewDataTextColumn>
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
    </div>

</asp:Content>
