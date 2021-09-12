<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="newopentransction.aspx.vb" Inherits="TWEB.newopentransction" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/GridView.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">

    <h3 class="leftpanel-section section-caption">Type</h3>
    <dx:ASPxTreeView runat="server" ID="TableOfContentsTreeView" ClientInstanceName="tableOfContentsTreeView"
        EnableNodeTextWrapping="true" AllowSelectNode="true" Width="100%" SyncSelectionMode="None" DataSourceID="NodesDataSource" NodeLinkMode="ContentBounds">
        <Styles>
            <Elbow CssClass="tree-view-elbow" />
            <Node CssClass="tree-view-node" HoverStyle-CssClass="hovered" />
        </Styles>
        <ClientSideEvents NodeClick="function (s, e) { HideLeftPanelIfRequired(); }" />
    </dx:ASPxTreeView>

    <asp:XmlDataSource ID="NodesDataSource" runat="server" DataFile="~/App_Data/DefaultLeft.xml" XPath="//Nodes/OperationNode/*" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">

    <div class="card ">
        <div class="card-body ">

            <div class="card ">
                <div class="card-body">
                    <div class="row content ">

                        <div class="col-md-4">
                            <label>Account Holder Name</label>
                            <div class="input-group  ">
                                <asp:TextBox CssClass="form-control" ID="nametb" runat="server" placeholder="Name" ReadOnly="false"></asp:TextBox>
                                <asp:LinkButton class="btn btn-primary" ID="LinkButton1" runat="server">
                                    <i class="fas fa-check-circle"></i>
                                </asp:LinkButton>
                            </div>

                        </div>

                        <div class="col-md-8">


                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnInit ="ASPxGridView1_Init">
  <Columns>

                                    <dx:GridViewDataTextColumn FieldName="n_ame" Name="n_ame" Caption="Name" VisibleIndex="2" Width="36%" MinWidth="280" MaxWidth="450"></dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="pr" Name="pr" Caption="PR" VisibleIndex="4" MinWidth="150" MaxWidth="250" Width="20%"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="reffno" Name="reffno" Caption="Reff. No." VisibleIndex="6" MinWidth="150" MaxWidth="250" Width="20%"></dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn Name="get" Caption="Control" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="BootstrapButton1" runat="server" AutoPostBack="false" Text="View"></dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Name="get" Caption="Option" VisibleIndex="1">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="BootstrapButton2" runat="server" AutoPostBack="false" Text="Get"></dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="producttype" Name="producttype" Caption="Account Type" VisibleIndex="6" MinWidth="150" MaxWidth="250" Width="20%"></dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowEllipsisInText="true" AllowDragDrop="false" />

                                <Settings VerticalScrollBarMode="Hidden" HorizontalScrollBarMode="Auto" ShowHeaderFilterButton="true" />

                                <SettingsPager PageSize="3">
                                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                </SettingsPager>

                                <Styles>
                                    <Cell Wrap="false" />
                                    <PagerBottomPanel CssClass="pager" />
                                    <FocusedRow CssClass="focused" />
                                </Styles>
                            </dx:ASPxGridView>

                        </div>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <label>Refference Number</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="reffNumberTb" runat="server" placeholder="Refference Number" ReadOnly="false"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Name  </label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="fullnametb" runat="server" placeholder="Full Name " ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Date</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="datetb" runat="server" placeholder="" ReadOnly="false" type="date"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <label>Deposit Amount </label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="amounttb" runat="server" placeholder="Account Open Status" Text="00" ReadOnly="false">
                                    </asp:TextBox>
                                    <asp:LinkButton class="btn btn-success mr-1" ID="AccountStatusApproveBtn" runat="server">
                                        <i class="fas fa-check-circle"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label>transction ID </label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="tridtb" runat="server" placeholder="Account Number" ReadOnly="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body">
                    <div class="row">
                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Enabled="true" Text="Add" />
                        </div>
                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Enabled="false" Text="Print" />
                        </div>

                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button2" class="btn btn-lg btn-block btn-outline-success" runat="server" Enabled="false" Text="Next" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body ">
            <div class="form-group  ">
                <asp:TextBox CssClass="form-control" ID="Errortb" runat="server" placeholder="Type" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
