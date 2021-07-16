<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="Operation.aspx.vb" Inherits="TWEB.Operation" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
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

<asp:XmlDataSource ID="NodesDataSource" runat="server" DataFile="~/App_Data/DefaultLeft.xml" XPath="//Nodes/OperationNode/*" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">


<div class="card ">
        <div class="card-body ">
            <div class="row ">
                <div class="col-md-3">
                    <label>Search By Account Number </label>
                    <div class="input-group  ">
                        <asp:TextBox CssClass="form-control" ID="ciftb" runat="server" placeholder="Eneter Account Number " ReadOnly="false"></asp:TextBox>
                        <asp:LinkButton class="btn btn-primary" ID="LinkButton5" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Search By CIF</label>
                    <div class="input-group  ">
                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter CIF ID" ReadOnly="false"></asp:TextBox>
                        <asp:LinkButton class="btn btn-primary" ID="LinkButton1" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Search By Name</label>
                    <div class="input-group ">
                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter Name " ReadOnly="false"></asp:TextBox>
                        <asp:LinkButton class="btn btn-primary" ID="LinkButton2" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>
        <div class="card-body">
            <div class="row ">
                <div class="col-md-3">
                    <label>Filter By Type </label>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" ID="nominiregcb" runat="server" placeholder="Nomini" Enabled="true" AutoPostBack="true">
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            <asp:ListItem Text="Saving" Value="Saving" />
                            <asp:ListItem Text="RD" Value="RD" />
                            <asp:ListItem Text="SSA" Value="SSA"></asp:ListItem>
                            <asp:ListItem Text="TD" Value="TD"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Filter By Status </label>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" placeholder="Nomini" Enabled="true" AutoPostBack="true">
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            <asp:ListItem Text="Approved" Value="Approved" />
                            <asp:ListItem Text="Rejected" Value="Rejected" />
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>


                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-4 mx-auto ">
                    <label></label>
                    <div class="form-group">
                        <asp:Button ID="Button3" class="btn-outline-success" runat="server" Enabled="true" Text="Filter" /></div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col">
                <hr />
            </div>
        </div>

        <%--<div class="card-body">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered border-primary  table-hover table-responsive ">

                <Columns>
                    <asp:BoundField DataField="accountnumber" HeaderText="Account Number" SortExpression="accountnumber"></asp:BoundField>
                    <asp:BoundField DataField="cif" HeaderText="CIF" SortExpression="cif"></asp:BoundField>
                    <asp:BoundField DataField="n_ame" HeaderText="Name" SortExpression="n_ame"></asp:BoundField>
                    <asp:BoundField DataField="producttype" HeaderText="Product Type" SortExpression="producttype"></asp:BoundField>
                    <asp:BoundField DataField="nominireg" HeaderText="nomini reg" SortExpression="nominireg"></asp:BoundField>
                    <asp:BoundField DataField="acctype" HeaderText="Account Type" SortExpression="acctype"></asp:BoundField>
                    <asp:BoundField DataField="jointname" HeaderText="jointname" SortExpression="jointname"></asp:BoundField>
                    <asp:BoundField DataField="guardianname" HeaderText="Guardian Name" SortExpression="guardianname"></asp:BoundField>
                    <asp:BoundField DataField="balance" HeaderText="Balance" SortExpression="balance"></asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status"></asp:BoundField>

                    <asp:TemplateField HeaderText="Account Number" sortExpression="accountnumber">
                        <ItemTemplate>
                         <asp:Button ID="try" OnClick="lblexamIsPaid_Click" runat="server" Text='<%# Eval("accountnumber") %>'></asp:Button>
                            <dx:BootstrapButton ID="lblexamIsPaid" OnClick="lblexamIsPaid_Click" runat="server" AutoPostBack="false" Text='<%# Eval("accountnumber") %>'></dx:BootstrapButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
      
        <div class="card-body ">
            <dx:BootstrapGridView ID="BGridView1" runat="server"  AutoGenerateColumns="False">
                <Settings ShowFilterRow="True" ShowFooter="True"></Settings>
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0"></dx:BootstrapGridViewCommandColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="n_ame" Name="n_ame" Caption="Name" VisibleIndex="3">
                        <Settings FilterMode="DisplayText"></Settings>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="producttype" Name="producttype" Caption="Product Type" VisibleIndex="4">
                        <Settings FilterMode="DisplayText"></Settings>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="nominireg" Name="nominireg" Caption="Nomini Register" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="acctype" Name="acctype" Caption="Account Type" VisibleIndex="6">
                        <Settings FilterMode="DisplayText"></Settings>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="jointname" Name="jointname" Caption="Joint Account Holder Name" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="guardianname" Name="guardianname" Caption="Guardian Name" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="status" Name="status" Caption="Status" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn Name="accountnumber" Caption="Account Number" FieldName="accountnumber" VisibleIndex="1">
                        <DataItemTemplate>
                            <dx:BootstrapButton ID="lblexamIsPaid" OnClick="lblexamIsPaid_Click" runat="server" AutoPostBack="false" Text='<%# Eval("accountnumber") %>'></dx:BootstrapButton>

                        </DataItemTemplate>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="cif" Name="cif" Caption="CIF" VisibleIndex="2">
                        <PropertiesTextEdit DisplayFormatString="{0}" EnableClientSideAPI="True"></PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn Name="balance" Caption="Balance" FieldName="balance" VisibleIndex="9">
                        <PropertiesTextEdit DisplayFormatString="{0}"></PropertiesTextEdit>
                        <DataItemTemplate>

                            <asp:LinkButton ID="link1" runat="server" OnClick="link1_Click" AutoPostBack="false" Text='<%# Eval("balance") %>'>LinkButton</asp:LinkButton>
                        </DataItemTemplate>

                    </dx:BootstrapGridViewTextColumn>
                    
                </Columns>
                <TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Sum" FieldName="balance" ShowInColumn="balance" ShowInGroupFooterColumn="balance"></dx:ASPxSummaryItem>
                </TotalSummary>
            </dx:BootstrapGridView>
        </div>
    </div>

</asp:Content>
