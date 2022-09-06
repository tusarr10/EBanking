<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/admin/Admin.Master" CodeBehind="AddBO.aspx.vb" Inherits="TWEB.AddBO" %>

<%@ Register Assembly="DevExpress.Dashboard.v21.2.Web.WebForms, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
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
                            <label>Office ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control " ID="tb_employeeId" runat="server" placeholder="Office ID"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Office Name </label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="tb_employeeName" runat="server" placeholder="Office Name" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Office Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="tbEmployeeStatus" runat="server" placeholder="Office Status" ReadOnly="True"></asp:TextBox>
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
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Office Details" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card ">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <center>
                                                        <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" Width="100px" Height="100px" AlternateText="Photo">
                                                            <border bordercolor="#33CC33" borderstyle="Solid" borderwidth="2px" />
                                                        </dx:ASPxImage>
                                                       
                                                        <%--<img width="100px" src="../Resour/Images/generaluser.png" alt="Photo" />--%>

                                                    </center>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col">
                                                    <hr/>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Office ID</label>
                                                    <div class="input-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_userid" runat="server" placeholder="Office ID" ReadOnly="true"></asp:TextBox>
                                                        <%--<asp:LinkButton class="btn btn-primary" ID="LinkButton5" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>--%>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Number of staff</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_fathername" runat="server" placeholder="Number of Staff" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Date Of Est.</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Date" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label>Circle</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_Circle" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Odisha" Value="Odisha" />
                                                            <asp:ListItem Text="Delhi" Value="Delhi" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Region</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Sambalpur" Value="Sambalpur" />
                                                            <asp:ListItem Text="Bhubaneswar" Value="Bhubaneswar" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Division</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList6" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Rourkela" Value="Rourkela" />
                                                            <asp:ListItem Text="Delhi" Value="Delhi" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Sub Division</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList7" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Bonaigarh" Value="Bonaigarh" />
                                                            <asp:ListItem Text="Bhubaneswar" Value="Bhubaneswar" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Account Office</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList8" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="Bonaigarh" Value="Bonaigarh" />
                                                            <asp:ListItem Text="Bhubaneswar" Value="Bhubaneswar" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Office Code</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="Guardiantb" runat="server" placeholder="Office Code" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Office Code 2</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Office Code 2" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Remarks</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email Address" ReadOnly="true"></asp:TextBox>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Office Location Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>District</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Districts" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Subdivision</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="SUb Div" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Block</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="Relationtb" runat="server" placeholder="Block" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Panchyat</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Panchyat" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Number Of Village</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="0" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Approx Population</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="0" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>lONG</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Current Post" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <label>lat</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Remarks" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Google Link" NavigateUrl="https://maps.google.com/?q=<lat>,<lng>">
                                                </dx:ASPxHyperLink>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel5" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Available Villege Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="sn" Name="sn" Caption="Sn" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="villegename" Name="villegelgname" Caption="Villege Name" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="officecode" Name="officecode" Caption="Office Code" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="totalpopuation" Name="totalpopulation" Caption="Total Population" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="accountopen" Name="accountopen" Caption="accountopen" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="5star" Name="5star" Caption="5*" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ssg" Name="ssg" Caption="ssg" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="sbg" Name="sbg" Caption="sbg" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Available Employee Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="sn" Name="sn" Caption="Sn" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Name" Name="name" Caption=" name" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="officecode" Name="officecode" Caption="Office Code" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="designation" Name="designation" Caption="designation" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="post" Name="post" Caption="post" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="fromdate" Name="frondate" Caption="from date" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="remark" Name="remark" Caption="remark" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="other" Name="other" Caption="other" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Available Service Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>IPPB Id</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" placeholder="Ippb" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>



                                                <div class="col-md-3">
                                                    <label>UIDAI</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" placeholder="Uidai" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>



                                                </div>

                                                <div class="col-md-3">
                                                    <label>CSC ID</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" placeholder="CSC" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>


                                                </div>

                                                <div class="col-md-3">
                                                    <label>PLI</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="DropDownList5" runat="server" placeholder="CSC" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Office Account Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>SB</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>RD</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>SSA</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                   <div class="col-md-3">
                                                    <label>TD</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="row">
                                                <div class="col-md-3">
                                                    <label>IPPB</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="0" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    <label>RPLI</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="col-md-3">
                                                    <label>PLI</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                              
                                                <div class="col-md-3">
                                                    <label>TOTAL</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" placeholder="00" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 <dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="MIS " NavigateUrl="#">
                                                     
                                                 </dx:ASPxHyperLink>
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

           <%-- <div class="card-body ">
                <div class="form-group  ">
                    <asp:TextBox CssClass="form-control" ID="Errortb" runat="server" placeholder="Type" ReadOnly="True"></asp:TextBox>
                </div>
            </div>--%>
        </div>
    </div>

</asp:Content>
