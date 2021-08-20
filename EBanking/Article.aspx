<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="Article.aspx.vb" Inherits="TWEB.Article" Title="Article" %>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
    <div class="text-content" runat="server" id="TextContent"></div>
</asp:Content>

<asp:Content ContentPlaceHolderID="LeftPanelContent" runat="server">
    <h3 class="section-caption contents-caption">Contents</h3>

    <dx:aspxtreeview runat="server" id="TableOfContentsTreeView" clientinstancename="tableOfContentsTreeView"
        enablenodetextwrapping="true" allowselectnode="true" width="100%" syncselectionmode="None" datasourceid="NodesDataSource" nodelinkmode="ContentBounds">
        <styles>
            <elbow cssclass="tree-view-elbow" />
            <node cssclass="tree-view-node" hoverstyle-cssclass="hovered" />
        </styles>
        <clientsideevents nodeclick="function (s, e) { HideLeftPanelIfRequired(); }" />
    </dx:aspxtreeview>

    <asp:XmlDataSource ID="NodesDataSource" runat="server" DataFile="~/App_Data/ArticleContents.xml" XPath="//Nodes/*" />
</asp:Content>