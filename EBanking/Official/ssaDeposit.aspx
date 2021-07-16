<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="ssaDeposit.aspx.vb" Inherits="TWEB.ssaDeposit" %>

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
            <label>Deposit SSA Account</label>

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
                            <asp:LinkButton class="btn btn-primary" ID="btnFindAccount" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <label>Balance</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="balanceTb" runat="server" placeholder="00" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <label>Account Type</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control mr-1" ID="Acctypetb" runat="server" placeholder="Account Type " ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Account Status</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control mr-1" ID="AccStatustb" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Cif</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="ciftb" runat="server" placeholder="Cif" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-3">
                    <label>Name</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="nametb" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Guardian Name</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control mr-1" ID="Gnametb" runat="server" placeholder="Name " ReadOnly="True"></asp:TextBox>
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

        <div class="card-body">
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="User Details" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                <PanelCollection>
                    <dx:PanelContent>

                        <div class="content">

                            <div class="card ">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                           <h4>Details</h4>
                        </center>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                   
                                     <dx:ASPxImage ID="photophoto" runat="server" ShowLoadingImage="true" Theme="Material" AlternateText="Photo" Height="100px" Width="100px">
                                         <Border BorderColor="#33CC33" BorderStyle="Solid" BorderWidth="1px" />
                                     </dx:ASPxImage> 
                                   
                           <%--<img width="100px" src="../Resour/Images/generaluser.png" alt="Photo" />--%>
                        </center>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <hr>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>Cif ID</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" ID="CifInfo" runat="server" placeholder="CIF ID" ReadOnly="True"></asp:TextBox>


                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Full Name</label>
                                            <div class="form-group  ">
                                                <asp:TextBox CssClass="form-control" ID="NameInfo" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <label>CIF Status</label>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control mr-1" ID="CifStatustb" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <label>DOB</label>
                                            <div class="form-group  ">
                                                <asp:TextBox CssClass="form-control" ID="dobtb" runat="server" placeholder="Date" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Gender</label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="genderlb" runat="server" placeholder="Gender" ReadOnly="True" Enabled="False">
                                                    <asp:ListItem Text="Male" Value="Male" />
                                                    <asp:ListItem Text="Female" Value="Female" />
                                                    <asp:ListItem Text="Other" Value="Other" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Contact No</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="mobiletb" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label>Email ID</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="emailtb" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Pan</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="pantb" runat="server" placeholder="PAN No" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <label>Aadhar No</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="adhartb" runat="server" placeholder="Adhar Card No" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <label>Full Postal Address</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="addresstb" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                      <%--  <img width="100px" src="../Resour/Images/generalSign.png" alt="Signiture" />--%>
                                    <dx:ASPxImage ID="photosign" runat="server" ShowLoadingImage="true" AlternateText="Signiture" Theme="Material" Border-BorderColor="#33CC33" Border-BorderStyle="Solid" Border-BorderWidth="1px" Width="100px" Height="50px"></dx:ASPxImage>
                                   </center>
                                        </div>

                                    </div>

                                </div>
                            </div>

                        </div>


                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>

        </div>

        <div class="row">
            <div class="col">
                <hr>
            </div>
        </div>

        <div class="card-body ">
            <div class="row">
                <div class="col-md-6">
                    <label>Deposit Amount</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="DepositAmounttb" runat="server" placeholder="Enter Ammount In INR. "></asp:TextBox>

                            <asp:TextBox CssClass="form-control" ID="DepositFine" runat="server" placeholder="Enter Fine In INR. "></asp:TextBox>

                            <asp:LinkButton class="btn btn-primary" ID="Calculatebtn" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <label>New Balance</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="newbalancetb" runat="server" placeholder="00" ReadOnly="true"></asp:TextBox>
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
                <%-- <div class="col-md-2">
                    <label>Till Date</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="tillDateTB" runat="server" placeholder="Date" type="Date" ReadOnly="false"></asp:TextBox>
                    </div>
                </div>--%>
                <div class="col-md-3">
                    <label>Date Of Last Traqnsction</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="dlttb" runat="server" placeholder="DLT" type="Date" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Date Of last 2 Transction</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="dlttb2" runat="server" placeholder="DLT2" type="Date" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <label>Details</label>
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="detailstb" runat="server" placeholder="Transction Details" ReadOnly="false"></asp:TextBox>
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
