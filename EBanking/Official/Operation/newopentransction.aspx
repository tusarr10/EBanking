<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="newopentransction.aspx.vb" Inherits="TWEB.newopentransction" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/GridView.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">

    <h3 class="leftpanel-section section-caption">Type</h3>
    <dx:aspxtreeview runat="server" id="TableOfContentsTreeView" clientinstancename="tableOfContentsTreeView"
        enablenodetextwrapping="true" allowselectnode="true" width="100%" syncselectionmode="None" datasourceid="NodesDataSource" nodelinkmode="ContentBounds">
        <styles>
            <elbow cssclass="tree-view-elbow" />
            <node cssclass="tree-view-node" hoverstyle-cssclass="hovered" />
        </styles>
        <clientsideevents nodeclick="function (s, e) { HideLeftPanelIfRequired(); }" />
    </dx:aspxtreeview>

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
                    <div class="row">

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
                            <%--          <dx:BootstrapGridView ID="gsgfdf" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <dx:BootstrapGridViewTextColumn FieldName="n_ame" Name="n_ame" Caption="Name" VisibleIndex="2" Width="36%" MinWidth="280" MaxWidth="450"></dx:BootstrapGridViewTextColumn>
                                    <%--  <dx:BootstrapGridViewTextColumn FieldName="address" Name="Address" Caption="Address" VisibleIndex="3" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn FieldName="pr" Name="pr" Caption="PR" VisibleIndex="4" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn FieldName="reffno" Name="reffno" Caption="Reff. No." VisibleIndex="6" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>

                                    <dx:BootstrapGridViewButtonEditColumn Name="get" Caption="Control" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="BootstrapButton1" runat="server" AutoPostBack="false" Text="View"></dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapGridViewButtonEditColumn>
                                    <dx:BootstrapGridViewButtonEditColumn Name="get" Caption="Option" VisibleIndex="1">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="BootstrapButton2" runat="server" AutoPostBack="false" Text="Get"></dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapGridViewButtonEditColumn>
                                    <dx:BootstrapGridViewTextColumn FieldName="producttype" Name="producttype" Caption="Account Type" VisibleIndex="6" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>
                                </Columns>
                                <Settings HorizontalScrollBarMode="Auto" />
                                <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="100" />
                            </dx:BootstrapGridView>--%>

                            <dx:aspxgridview id="BootstrapGridView1" oninit="ASPxGridView1_Init" cssclass="grid-view" width="100%" keyfieldname="reffno" runat="server" autogeneratecolumns="False">

                                <columns>

                                    <dx:gridviewdatatextcolumn fieldname="n_ame" name="n_ame" caption="Name" visibleindex="2" width="36%" minwidth="280" maxwidth="450"></dx:gridviewdatatextcolumn>
                                    <%--  <dx:BootstrapGridViewTextColumn FieldName="address" Name="Address" Caption="Address" VisibleIndex="3" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>--%>
                                    <dx:gridviewdatatextcolumn fieldname="pr" name="pr" caption="PR" visibleindex="4" minwidth="150" maxwidth="250" width="20%"></dx:gridviewdatatextcolumn>
                                    <dx:gridviewdatatextcolumn fieldname="reffno" name="reffno" caption="Reff. No." visibleindex="6" minwidth="150" maxwidth="250" width="20%"></dx:gridviewdatatextcolumn>

                                    <dx:gridviewdatatextcolumn name="get" caption="Control" visibleindex="0">
                                        <dataitemtemplate>
                                            <dx:bootstrapbutton id="BootstrapButton1" runat="server" autopostback="false" text="View"></dx:bootstrapbutton>
                                        </dataitemtemplate>
                                    </dx:gridviewdatatextcolumn>
                                    <dx:gridviewdatatextcolumn name="get" caption="Option" visibleindex="1">
                                        <dataitemtemplate>
                                            <dx:bootstrapbutton id="BootstrapButton2" runat="server" autopostback="false" text="Get"></dx:bootstrapbutton>
                                        </dataitemtemplate>
                                    </dx:gridviewdatatextcolumn>
                                    <dx:gridviewdatatextcolumn fieldname="producttype" name="producttype" caption="Account Type" visibleindex="6" minwidth="150" maxwidth="250" width="20%"></dx:gridviewdatatextcolumn>
                                </columns>
                                <settingsbehavior allowfocusedrow="true" allowselectbyrowclick="true" allowellipsisintext="true" allowdragdrop="false" />

                                <settings verticalscrollbarmode="Hidden" horizontalscrollbarmode="Auto" showheaderfilterbutton="true" />

                                <settingspager pagesize="3">
                                    <pagesizeitemsettings visible="true" showallitem="true" />
                                </settingspager>

                                <styles>
                                    <cell wrap="false" />
                                    <pagerbottompanel cssclass="pager" />
                                    <focusedrow cssclass="focused" />
                                </styles>
                            </dx:aspxgridview>
                        </div>
                    </div>

                    <%--    <div class="row">

                      <div class="col-md-4">
                            <label>Guardian Name</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="Guardiantb" runat="server" placeholder="Guardian Name" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>

                    <div class="row">
                        <div class="col">
                            <hr />
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