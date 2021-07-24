<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="addAccount.aspx.vb" Inherits="TWEB.addAccount" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
  <%--  <link rel="stylesheet" href="~/Content/Custom/css/validationEngine.jquery.css" type="text/css" />--%>
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
                    <div class="row">
                        <div class="col-md-3">
                            <label>Account ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control " ID="accIdTb" runat="server" placeholder="Account ID"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Balance</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="balanceTb" runat="server" placeholder="00" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Account Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="AccStatustb" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-success mr-1" ID="AccountStatusApproveBtn" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning mr-1" ID="AccountStatusPendingBtn" runat="server"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-danger mr-1" ID="AccountStatusFreezBtn" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>

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
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="User Details" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card ">
                                        <div class="card-body">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Cif</label>
                                                    <div class="input-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="ciftb" runat="server" placeholder="CIF ID" ReadOnly="true"></asp:TextBox>
                                                        <asp:LinkButton class="btn btn-primary" ID="LinkButton5" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Account Holder Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="nametb" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Second Account Holder Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="name2tb" runat="server" placeholder="Joint Acc Holder Name" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label>Nomini Register</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="nominiregcb" runat="server" placeholder="Nomini" Enabled="False" OnTextChanged="nominiregcb_TextChanged" AutoPostBack="true">
                                                             <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Product</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ProductCb" runat="server" placeholder="Account Type" Enabled="false" OnTextChanged="ProductCb_TextChanged" AutoPostBack="true">
                                                            <%--https://www.aspsnippets.com/Articles/Disable-DropDownList-Item-Option-in-ASPNet-using-C-and-VBNet.aspx--%>
                                                            <%--example--%>
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                             <asp:ListItem Text="Saving" Value="Saving" />
                                                            <asp:ListItem Text="RD" Value="RD" />
                                                            <asp:ListItem Text="SSA" Value="SSA" />
                                                            <asp:ListItem Text="TD" Value="TD" />
                                                            <asp:ListItem Text="RPLI" Value="RPLI" />
                                                            <asp:ListItem Text="NSC" Value="NSC" />
                                                            <asp:ListItem Text="PPF" Value="PPF" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Mode Of Operation</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="Modetb" runat="server" placeholder="Mode" Enabled="false" OnTextChanged="Modetb_textChanged1" AutoPostBack="true">
                                                             <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Self" Value="Self" />
                                                            <asp:ListItem Text="Minor" Value="Minor" />
                                                            <asp:ListItem Text="JointA" Value="JointA" />
                                                            <asp:ListItem Text="JointB" Value="JointB" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Guardian Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="Guardiantb" runat="server" placeholder="Guardian Name" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <hr />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </div>

            <div class="row">
                <div class="col">

                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="CIF Details" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <center>
                           <h4>CIF Details</h4>
                        </center>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <center>
                                    <dx:ASPxImage ID="photophoto" runat="server" ShowLoadingImage="true" Width="100px" Height="100px" AlternateText="Photo">
                                        <Border BorderColor="#33CC33" BorderStyle="Solid" BorderWidth="2px" />
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
                                                             <asp:ListItem Text="Chose .." Value="" />
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
                                   <dx:ASPxImage ID="signphoto" runat="server" ShowLoadingImage="true" Width="100px" Height="50px" AlternateText="Signiture">
                                       <Border BorderColor="#99FF99" BorderStyle="Solid" BorderWidth="2px" />
                                      </dx:ASPxImage>
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
            </div>

             <div class="row">
                <div class="col">

                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body ">


                    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Mode Of Operation" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Account Operate Mode</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="AcModetb" runat="server" placeholder="Mode" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Guardian Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="GuardianNametb" runat="server" placeholder="Guardian" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Relation</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="Relationtb" runat="server" placeholder="relation" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                </div>
            </div>
            <div class="row">
                <div class="col">

                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Product Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Account Type</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="ActypeInfotb" runat="server" placeholder="Type" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Term</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="Actermtb" runat="server" placeholder="Term" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Value</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="AccValuetb" runat="server" placeholder="Value" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>

                </div>
            </div>

             <div class="row">
                <div class="col">

                    <hr />
                </div>
            </div>


            <div class="card ">
                <div class="card-body ">
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel5" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Nomini Information" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">

                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Nomini Register</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="NominiRegInfo" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Nomini Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="NominiNameInfotb" runat="server" placeholder="Name" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Relation</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="NominiRelationInfotb" runat="server" placeholder="Relation" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label>Nomini DOB</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="NominiAgeInfotb" runat="server" placeholder="Age" type="Date" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <label>Nomini Address</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="NominiAddressInfotb" runat="server" placeholder="Address" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>

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
                                    <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Enabled="false" Text="Add" />
                                </div>
                                <div class="col-4 mx-auto">
                                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Enabled="false" Text="Update" />
                                </div>
                                <div class="col-4 mx-auto">
                                    <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Enabled="false" Text="Delete" />
                                </div>
                            </div>
                        </div>
                    </div>
             <div class="row">
                <div class="col">

                    <hr />
                </div>
            </div>
                
                <div class="card-body ">
                    <div class="form-group  ">
                        <asp:TextBox CssClass="form-control" ID="Errortb" runat="server" placeholder="Type" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

    
</asp:Content>
