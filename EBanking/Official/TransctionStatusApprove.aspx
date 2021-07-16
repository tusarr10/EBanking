<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="TransctionStatusApprove.aspx.vb" Inherits="TWEB.TransctionStatusApprove" %>

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



    <div class="card align-content-center">
        <div class="card-body mx-auto   ">
            <div class="card-group mx-auto  ">
                <label>
                    Transction ID :
                </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbtrid" runat="server" placeholder="Your TrID" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group mx-auto  ">
                <label>
                    Date :
                </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbDate" runat="server" placeholder="date" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Account Number : </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbacno" runat="server" placeholder="Your Account Number" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Transction Type : </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbtrtype" runat="server" placeholder="Transction Type" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="card-group ">
                <label>Name : </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbname" runat="server" placeholder="Your Name" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Account Type : </label>

                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbactype" runat="server" placeholder="Account Type" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Balance Before Transction : </label>

                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbbbt" runat="server" placeholder="Previous Balance" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Deposit Amount : </label>

                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbAmount" runat="server" placeholder="Amount" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Balance After Transction : </label>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbbat" runat="server" placeholder="Balance After Transction" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Status : </label>
                <%--<asp:TextBox ID="lblStatus" runat="server" Text="Transction Status"></asp:TextBox>--%>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="tbstatus" runat="server" placeholder="Transction Status" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="card-group ">
                <label>Details : </label>
                <%--<asp:TextBox ID="lblStatus" runat="server" Text="Transction Status"></asp:TextBox>--%>
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="detailstb" runat="server" placeholder="Transction Details" ReadOnly="true"></asp:TextBox>
                </div>
            </div>


        </div>
        <div class="card ">
            <div class="card-body">
                <div class="row">
                    <div class="col-2 mx-auto">
                        <asp:Button ID="btnCancel" class="btn btn-lg btn-block btn-success" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
                    </div>
                    <div class="col-2 mx-auto">
                        <asp:Button ID="btnApprove" class="btn btn-lg btn-block btn-info" runat="server" Text="Approve" />
                    </div>
                    <div class="col-2 mx-auto">
                        <asp:Button ID="btnReject" class="btn btn-lg btn-block btn-danger" runat="server" Text="Reject" />
                    </div>
                </div>
            </div>
        </div>


    </div>

</asp:Content>
