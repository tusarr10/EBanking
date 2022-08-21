<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/admin/Admin.Master" CodeBehind="EmployeeInfo.aspx.vb" Inherits="TWEB.EmployeeInfo" %>
<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
                            <label>Employee ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control " ID="tb_employeeId" runat="server" placeholder="Employee ID"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary" ID="btnSearchEmployee" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Name </label>
                            <div class="form-group  ">
                                <asp:TextBox CssClass="form-control" ID="tb_employeeName" runat="server" placeholder="Employee Name" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Employee Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="tbEmployeeStatus" runat="server" placeholder="Employee Status" ReadOnly="True"></asp:TextBox>
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
                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Employee Details" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
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
                                                    <hr>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>User ID</label>
                                                    <div class="input-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_userid" runat="server" placeholder="User ID" ReadOnly="true"></asp:TextBox>
                                                        <%--<asp:LinkButton class="btn btn-primary" ID="LinkButton5" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>--%>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Father Name</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_fathername" runat="server" placeholder="Father Name" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Date Of Birth</label>
                                                     <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_DOB" runat="server" placeholder="Date" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label>Gender</label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_gender" runat="server" placeholder="Nomini" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Male" Value="Male" />
                                                            <asp:ListItem Text="Female" Value="Female" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="col-md-2">
                                                    <label>Blood Group</label>
                                                   <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_bloodGroup" runat="server" placeholder="Blood" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Chose .." Value="" />
                                                            <asp:ListItem Text="B+" Value="B+" />
                                                            <asp:ListItem Text="O+" Value="O+" />
                                                            <asp:ListItem Text="A+" Value="A+" />
                                                            <asp:ListItem Text="O-" Value="O-" />
                                                            <asp:ListItem Text="B-" Value="B-" />
                                                            <asp:ListItem Text="A-" Value="A-" />
                                                            <asp:ListItem Text="AB+" Value="AB+" />
                                                            <asp:ListItem Text="AB-" Value="AB-" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Address</label>
                                                     <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_address" runat="server" placeholder="Enter Your Address" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>Pramanent Address</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_address2" runat="server" placeholder="Enter Your Parmanent Address" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                              
                                            </div>
                                            <div class="row">
                                                  <div class="col-md-3">
                                                    <label>Mobile Number</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_mobile" runat="server" placeholder="Mobile Number" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Alternate Mobile</label>
                                                     <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_mobile2" runat="server" placeholder="Alternative Mobile Number" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Email</label>
                                                     <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" placeholder="Email Address" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                              
                                            </div>
                                            <div class="row">
                                                   <div class="col-md-3">
                                                    <label>Aadhaar Number</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_aadhaar" runat="server" placeholder="Aadhar Number" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                               <div class="col-md-3">
                                                    <label>PAN</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_pan" runat="server" placeholder="PAN" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>PRAN</label>
                                                     <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_pran" runat="server" placeholder="PRAN" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                                <div class="col-md-3">
                                                    <label>Remark</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_remarks" runat="server" placeholder="Remarks" ReadOnly="true"></asp:TextBox>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" Office Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>Date Of Joining</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_joindate" runat="server" placeholder="Date Of Join" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Date Of Retair</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_retair" runat="server" placeholder="Date Of Ret" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>Post</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_post" runat="server" placeholder="Post" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                   <div class="col-md-3">
                                                    <label>TRCA Lavel</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_trca" runat="server" placeholder="TRCA lavel" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="row">
                                                <div class="col-md-3">
                                                    <label>Original Place of post</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_originalPost" runat="server" placeholder="Original" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    <label>Current Place of Post</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_currentPlacePost" runat="server" placeholder="Cu" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="col-md-3">
                                                    <label>Current Post</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_currentPost" runat="server" placeholder="Current Post" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                              
                                                <div class="col-md-3">
                                                    <label>Remarks</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_PostRemark" runat="server" placeholder="Remarks" ReadOnly="True"></asp:TextBox>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText=" User Service Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <label>IPPB Id</label>
                                                   <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_ippb" runat="server" placeholder="Ippb" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>If yes</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_ippb" runat="server" placeholder="Enter IPPB User ID"  ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                             <div class="row">
                                                <div class="col-md-3">
                                                    <label>UIDAI</label>
                                                     <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_uidai" runat="server" placeholder="Uidai" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    <label>If yes</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_uidai" runat="server" placeholder="Enter ID" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                             <div class="row">
                                                <div class="col-md-3">
                                                    <label>CSC ID</label>
                                                  <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_cscid" runat="server" placeholder="CSC" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <label>If Yes</label>
                                                   <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_cscid" runat="server" placeholder="CSC Id "  ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                             <div class="row">
                                                <div class="col-md-3">
                                                    <label>PLI</label>
                                                   <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="cb_pli" runat="server" placeholder="CSC" Enabled="False" AutoPostBack="true">
                                                            <asp:ListItem Text="Choose .." Value="" />
                                                            <asp:ListItem Text="Yes" Value="Yes" />
                                                            <asp:ListItem Text="No" Value="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    <label>IF Yes</label>
                                                    <div class="form-group  ">
                                                        <asp:TextBox CssClass="form-control" ID="tb_pli" runat="server" placeholder="Enter ID" ReadOnly="True"></asp:TextBox>
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

                    <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="User Transfer Details " AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="false" EnableAnimation="True">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="content">
                                    <div class="card">
                                        <div class="card-body">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="sn" Name="sn" Caption="sn" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="date" Name="date" Caption="Date" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="from" Name="from" Caption="From" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="To" Name="To" Caption="To" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="trnsftype" Name="trnsftype" Caption="TransfType" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="memono" Name="Memono" Caption="MemoNumber" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="remarks" Name="remarks" Caption="Remarks" VisibleIndex="6"></dx:GridViewDataTextColumn>
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
                <div class="card-body">
                    <div class="row">
                        <div class="col-4 mx-auto">
                            <asp:Button ID="btn_add" class="btn btn-lg btn-block btn-success" runat="server" Enabled="false" Text="Add" />
                        </div>
                        <div class="col-4 mx-auto">
                            <asp:Button ID="btn_update" class="btn btn-lg btn-block btn-info" runat="server" Enabled="false" Text="Update" />
                        </div>
                        <div class="col-4 mx-auto">
                            <asp:Button ID="btn_delete" class="btn btn-lg btn-block btn-danger" runat="server" Enabled="false" Text="Delete" />
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
