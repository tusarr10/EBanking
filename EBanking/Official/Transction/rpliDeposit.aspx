<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="rpliDeposit.aspx.vb" Inherits="TWEB.rpliDeposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
    <h3 class="leftpanel-section section-caption">Transction Type</h3>
    <dx:ASPxTreeView runat="server" ID="TableOfContentsTreeView" ClientInstanceName="tableOfContentsTreeView"
        EnableNodeTextWrapping="true" AllowSelectNode="true" Width="100%" SyncSelectionMode="None" DataSourceID="NodesDataSource" NodeLinkMode="ContentBounds">
        <Styles>
            <Elbow CssClass="tree-view-elbow" />
            <Node CssClass="tree-view-node" HoverStyle-CssClass="hovered" />
        </Styles>
        <ClientSideEvents NodeClick="function (s, e) { HideLeftPanelIfRequired(); }" />
    </dx:ASPxTreeView>

    <asp:XmlDataSource ID="NodesDataSource" runat="server" DataFile="~/App_Data/DefaultLeft.xml" XPath="//Nodes/TransctionNode/*" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">

    <div class="card">

        <div class="card-body">
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <label>Deposit RPLI Account</label>

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <label>Account ID</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="accIdTb" runat="server" placeholder="Account ID"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="btnFindAccount" runat="server">
                                <i class="fas fa-check-circle">
                                </i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                 <div class="col-md-4">
                    <label>Name  </label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="nametb" runat="server" placeholder="Enter Your Name " ReadOnly="FALSE"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>


        <div class="row">
            <div class="col">
                <hr>
            </div>
        </div>

        <div class="card-body ">
            <div class="row">
                <div class="col-md-3">
                    <label>Deposit Amount</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="DepositAmounttb" runat="server" placeholder="Enter Ammount In INR. "></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="Calculatebtn" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
               
                <div class="col-md-3">
                    <label>Transction Id</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="transctiontb" runat="server" placeholder="Enter Your Transction ID. " ReadOnly="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Date</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="DateofTransction" runat="server" placeholder="Date" type="Date" ReadOnly="false"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Till Date</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="tillDateTB" runat="server" placeholder="Date" type="Date" ReadOnly="false"></asp:TextBox>
                    </div>
                </div>
               
               
                <div class="col-md-3">
                    <label>Details</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="detailstb" runat="server" placeholder=" Details" ReadOnly="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <hr>
        </div>
    </div>

    <div class="card">
        <div class="card-body ">
            <div class="row">
                <div class="col-4 mx-auto">
                    <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Post" />
                </div>
                <div class="col-4 mx-auto">
                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Text="Cancel" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
