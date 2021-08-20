<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="rpliIndex.aspx.vb" Inherits="TWEB.rpliIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
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

    <label>RPLI / PLI Index</label>
    <div class="card ">
        <div class="card-body ">
            <div class="row">
                <div class="col-md-3">
                    <label>Enter Proposal No To search </label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="psearchtb" runat="server" placeholder="Proposal No"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
                 <div class="col-md-3">
                    <label>Enter ID  To search </label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Proposal ID"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary" ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" ><i class="fas fa-check-circle"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Agent Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="row ">
                                    <div class="col-md-3">
                                        <label>Agent ID</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="agentidtb" runat="server" placeholder="Agent ID"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label>BO ID</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="boidtb" runat="server" placeholder="BO ID"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Date of Rec</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="rcdatetb" runat="server" placeholder="" type="date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3">
                                        <label>Sum Assured</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="agentsa" runat="server" placeholder="Sum Assured"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <label>Premium Paid</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="agentpremtb" runat="server" placeholder="Premium amount "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <label>Agent Mobile </label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="agentmobile" runat="server" placeholder="Agent Mobile "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Customor Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="row">
                                    <div class="col-md-4">

                                        <label>Custmor Name</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="custnametb" runat="server" placeholder="Custmor Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <label>Custmor DOB</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="custdobtb" runat="server" type="date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Custmor Mobile</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="custmobiletb" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3">
                                        <label>Custmor Notes</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="custnotestb" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Custmor Address </label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="custaddresstb" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="card">

            <div class="card-body ">
                <%--  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Proposal Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                            <PanelCollection>
                                <dx:PanelContent>
                                    <div class="row ">
                                        <div class="col-md-3">
                                            <label>Proposal Date</label>
                                            <div class="form-group">
                                                <div class="input-group ">
                                                    <asp:TextBox ID="proposaldatetb" CssClass="form-control " placeholder="Date" type="date" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 ">
                                            <label>Proposal Type </label>
                                            <asp:DropDownList CssClass="form-control" ID="producttype" runat="server" placeholder="Product Type" Enabled="true" OnTextChanged="trtype_TextChanged" AutoPostBack="true">
                                                <asp:ListItem Text="Choose Product" Value="" />
                                                <asp:ListItem Text="PLI" Value="PLI" />
                                                <asp:ListItem Text="RPLI" Value="RPLI" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-3 ">
                                            <label>Product Catagory </label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" placeholder="Product Type" Enabled="true" OnTextChanged="trtype_TextChanged1" AutoPostBack="true">
                                                <asp:ListItem Text="Choose Product" Value="" />
                                                <asp:ListItem Text="WLA" Value="WLA" />
                                                <asp:ListItem Text="CWLA" Value="CWLA" />
                                                <asp:ListItem Text="EA" Value="EA" />
                                                <asp:ListItem Text="AEA" Value="AEA" />
                                                <asp:ListItem Text="GY" Value="GY" />
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-3 ">
                                            <label>Premium Frequency </label>
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" placeholder="Product Type" Enabled="true" OnTextChanged="trtype_TextChanged1" AutoPostBack="true">
                                                <asp:ListItem Text="Choose Frequency" Value="" />
                                                <asp:ListItem Text="Monthly" Value="Monthly" />
                                                <asp:ListItem Text="Quaterly" Value="Quaterly" />
                                                <asp:ListItem Text="Half Yearly" Value="HalfYearly" />
                                                <asp:ListItem Text="Yearly" Value="Yearly" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Maturity Age </label>
                                            <div class="form-group">
                                                <div class="input-group ">
                                                    <asp:TextBox ID="matagetb" CssClass="form-control " placeholder="Maturity Age" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <hr />
        </div>
    </div>
    <div class="card">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Account Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                        <PanelCollection>
                            <dx:PanelContent>

                                <%--<dx:ASPxTextBox ID="LastNameTextBox" runat="server" Width="100%">
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="true" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText">
                                        <RequiredField IsRequired="true" ErrorText="Last name is required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>--%>

                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Proposal No</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="propnotb" CssClass="form-control " placeholder=" Enter Proposal No" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Rec No</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="recnotb" CssClass="form-control " placeholder=" Enter Rec No" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-3 ">
                                        <label>Sum Assured</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="satb" CssClass="form-control " placeholder=" Enter SA In rs" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 ">
                                        <label>Premium</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="premtb" CssClass="form-control " placeholder=" Enter Premium In rs" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Indexing BO</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="officeidtb" CssClass="form-control " placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <label>User</label>
                                        <div class="form-group">
                                            <div class="input-group ">
                                                <asp:TextBox ID="usernametb" CssClass="form-control " placeholder="" ReadOnly="true" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                    <br />
                    <div class="card-body ">

                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Next" OnClick="ASPxButton1_Click" AutoPostBack="False" Enabled="true"></dx:ASPxButton>
                         <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Submit" OnClick="ASPxButton4_Click" AutoPostBack="False" Enabled="false"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Paid" OnClick="ASPxButton2_Click" AutoPostBack="False" Enabled="false"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Print"  AutoPostBack="False" Enabled="false"></dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="New" OnClick="ASPxButton3_Click" AutoPostBack="False" Enabled="true"></dx:ASPxButton>
                    </div>
                    <br />
                    <div class="row ">
                        <dx:ASPxMemo ID="logtb" runat="server" Height="71px" Width="100%" ReadOnly="true"></dx:ASPxMemo>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>