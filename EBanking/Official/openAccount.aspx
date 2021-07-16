<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="openAccount.aspx.vb" Inherits="TWEB.openAccount" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">

       
    <h3 class="leftpanel-section section-caption">OPERATION</h3>
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
                        
                        <div class="col-md-4">
                            <label>Account Holder Name</label>
                            <div class="input-group  ">
                                <asp:TextBox CssClass="form-control" ID="nametb" runat="server" placeholder="Name" ReadOnly="false"></asp:TextBox>
                                 <asp:LinkButton class="btn btn-primary" ID="LinkButton1" runat="server">
                                     <i class="fas fa-check-circle">                                                                        </i>
                                 </asp:LinkButton>
                            </div>
                        </div>
                       <div class="col-md-8">
                           <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                               <Columns>
                                   <dx:BootstrapGridViewTextColumn FieldName="n_ame" Name="n_ame" Caption="Name" VisibleIndex="2" Width="36%" MinWidth="280" MaxWidth="450"></dx:BootstrapGridViewTextColumn>
                                 <%--  <dx:BootstrapGridViewTextColumn FieldName="address" Name="Address" Caption="Address" VisibleIndex="3" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>--%>
                                   <dx:BootstrapGridViewTextColumn FieldName="cif" Name="cif" Caption="cif" VisibleIndex="4" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>
                                   <dx:BootstrapGridViewTextColumn FieldName="accountnumber" Name="accountnumber" Caption="accountNumber" VisibleIndex="6" MinWidth="150" MaxWidth="250" Width="20%"></dx:BootstrapGridViewTextColumn>

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
                            
                           </dx:BootstrapGridView>
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
                                    <asp:TextBox CssClass="form-control" ID="reffNumberTb" runat="server" placeholder="Refference Number" ReadOnly="true" ></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>PR Number</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Pr Number ex. BookNumber,RecptNumber" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Date</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="accountTb" runat="server" placeholder="" ReadOnly="true" type="date"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <label>Account Opening Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="AccOpenStatustb" runat="server" placeholder="Account Open Status" Text="Pending" ReadOnly="True">

                                    </asp:TextBox>
                                    <asp:LinkButton class="btn btn-success mr-1" ID="AccountStatusApproveBtn" runat="server">
                                        <i class="fas fa-check-circle">

                                        </i>

                                    </asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning mr-1" ID="AccountStatusPendingBtn" runat="server">
                                        <i class="far fa-pause-circle">
      </i>

                                    </asp:LinkButton>
                                    <asp:LinkButton class="btn btn-danger mr-1" ID="AccountStatusFreezBtn" runat="server">
                                        <i class="fas fa-times-circle">

                                        </i>

                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label>Refference Number</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="acnotb" runat="server" placeholder="Account Number" ReadOnly="true" ></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="LinkButton2" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
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
                         
                        </center>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-3">
                            <label>Cif</label>
                            <div class="input-group  ">
                                <asp:TextBox CssClass="form-control" ID="ciftb" runat="server" placeholder="CIF ID" Text="" ReadOnly="true"></asp:TextBox>
                               <asp:LinkButton class="btn btn-primary" ID="LinkButton5" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
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
                                    <asp:TextBox CssClass="form-control mr-1" Text="Pending" ID="CifStatustb" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                     

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label>DOB</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="dobtb" runat="server" placeholder="Date" TextMode="Date" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Gender</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="genderlb" runat="server" placeholder="Gender" ReadOnly="false" >
                                    <asp:ListItem Text="Choose ..." Value="" />
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                    <asp:ListItem Text="Other" Value="Other" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Contact No</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="mobiletb" runat="server" placeholder="Contact No" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Email ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="emailtb" runat="server" placeholder="Email ID" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Pan</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="pantb" runat="server" placeholder="PAN No" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Aadhar No</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="adhartb" runat="server" placeholder="Adhar Card No" ReadOnly="false"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-12">
                            <label>Full Postal Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="addresstb" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2" ReadOnly="false"></asp:TextBox>
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



            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                         <div class="col-md-2">
                            <label>Mode Of Operation</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="Modetb" runat="server" placeholder="Mode" Enabled="true" OnTextChanged="Modetb_TextChanged" AutoPostBack="true">
                                    <asp:ListItem Value="">Choose Item</asp:ListItem>
                                    <asp:ListItem Text="Self" Value="Self" />
                                    <asp:ListItem Text="Minor" Value="Minor" />
                                    <asp:ListItem Text="JointA" Value="JointA" />
                                    <asp:ListItem Value="JointB" Text="JointB"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Guardian Name</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="GuardianNametb" runat="server" placeholder="Guardian" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>Second Account Holder Name</label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="name2tb" runat="server" placeholder="Joint Acc Holder Name" ReadOnly="true"></asp:TextBox>
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
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-2">
                            <label>Product</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ProductCb" runat="server" placeholder="Account Type" Enabled="true" OnTextChanged="ProductCb_TextChanged" AutoPostBack="true">
                                    <%--https://www.aspsnippets.com/Articles/Disable-DropDownList-Item-Option-in-ASPNet-using-C-and-VBNet.aspx--%>
                                    <%--example--%>
                                    <asp:ListItem Text="Choose Product" Value="" />
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

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                       <div class="col-md-2">
                            <label>Nomini Register</label>
                            <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="nominiregcb" runat="server" placeholder="Nomini" Enabled="true" OnTextChanged="nominiregcb_TextChanged1" AutoPostBack="true">
                                    <asp:ListItem Text="Choose Here" Value="" />
                                    <asp:ListItem Text="Yes" Value="Yes" />
                                    <asp:ListItem Text="No" Value="No" />
                                </asp:DropDownList>
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

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <div class="card ">
                <div class="card-body">
                    <div class="row">
                      
                        <div class="col-4 mx-auto">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Enabled="true" Text="Print" />
                        </div>
                          <div class="col-4 mx-auto">
                            <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Enabled="false" Text="Add" />
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
