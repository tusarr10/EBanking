<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="ssaInterest.aspx.vb" Inherits="TWEB.ssaInterest" %>
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



      <div>
        <div class="card card1  ">
            <div class="card-body ">
                <div class="row">
                    <div class="col-md-4">
                        <label>Enter SSA account Number </label>
                        <div class="input-group  ">
                            <asp:TextBox CssClass="form-control" ID="AcnoTb" runat="server" placeholder="Account Number " ReadOnly="false"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="LinkButton1" runat="server">
                                     <i class="fas fa-check-circle">                                                                        </i>
                            </asp:LinkButton>
                        </div>

                    </div>

                    <div class="col-md-4">
                        <label>Name </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Name " ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label>Account Type  </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control" ID="actypetb" runat="server" placeholder=" " ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="row ">
                    <div class="col-md-2">
                        <label>Account Balance  </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control" ID="baltb" runat="server" placeholder=" " ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <label>Transction Type</label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="trtype" runat="server" placeholder="Account Type" Enabled="true" OnTextChanged ="trtype_TextChanged" AutoPostBack="true">
                                <%--https://www.aspsnippets.com/Articles/Disable-DropDownList-Item-Option-in-ASPNet-using-C-and-VBNet.aspx--%>
                                <%--example--%>
                                <asp:ListItem Text="Choose Product" Value="" />
                                <asp:ListItem Text="Deposit" Value="Deposit" />
                                <asp:ListItem Text="Withdraw" Value="Withdraw" />
                                <asp:ListItem Text="Interest" Value="Interest" />
                                <%--<asp:ListItem Text="TD" Value="TD" />
                                    <asp:ListItem Text="RPLI" Value="RPLI" />
                                    <asp:ListItem Text="NSC" Value="NSC" />
                                    <asp:ListItem Text="PPF" Value="PPF" />--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="amountlb" runat="server" Text="Deposit Amount "></asp:Label>
                        <div class="input-group  ">
                            <asp:TextBox CssClass="form-control" ID="amounttb" runat="server" placeholder=" Enter Transction Amount " ReadOnly="true"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="LinkButton2" runat="server">
                                     <i class="fas fa-check-circle">                                                                        </i>
                            </asp:LinkButton>

                        </div>
                    </div>


                    <div class="col-md-2">
                        <label>Balance  </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control" ID="Availablebalancetb" runat="server" placeholder=" " ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <label>Date  </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control" type="Date" ID="datetb" runat="server" placeholder="" text="" ReadOnly="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <label>Details  </label>
                        <div class="form-group  ">
                            <asp:TextBox CssClass="form-control"  ID="TextBox2" runat="server" placeholder="Transction Details" text="" ReadOnly="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
                <div class="row">
                       <div class="col-4 mx-auto">
                            <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Enabled="true" Text="Add" />
                        </div>
                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Enabled="true" Text="Print" />
                        </div>
                        
                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button2" class="btn btn-lg btn-block btn-outline-success" runat="server" Enabled="true" Text="Next" />
                        </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
