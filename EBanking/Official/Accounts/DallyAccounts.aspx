<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="DallyAccounts.aspx.vb" Inherits="TWEB.DallyAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightPanelContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageToolbar" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div>
            <h4>Daily Account</h4>
        </div>

        <div class="col-sm-6">
            <div class="card">
                <div class="card-header ">Reciepts</div>
                <div class="card-body">
                    <h5 class="card-title">Day Ends Deposits</h5>
                    <p class="card-text">
                    </p>
                    <div class="row">
                        <label>Date </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="datetb" runat="server" placeholder="" type="date"></asp:TextBox>
                                <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <label>Opening Balance</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="obtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <label>Cash Receive From SO</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="crdtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Saving Account Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="sbdtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>RD Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rddtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>RD Fine</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rdftb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>SSA Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="ssadtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>SSA Fine</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="ssaftb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>TD Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="tddtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>RPLI Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rplidtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>RPLI Fine Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rpliftb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>RPLI Tax Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rplittb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>VPP Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="vppdtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>IPPB Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="ippbdtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                        <div class="row">
                        <label>CSC Deposit</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="cscdtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="card-footer">
                    <label>Total Deposit :  </label><dx:ASPxLabel ID="totaldtb" runat="server" Text="00"></dx:ASPxLabel>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card">
                <div class="card-header ">
                    Payments
                </div>
                <div class="card-body">
                    <h5 class="card-title">Day End Payments</h5>
                    <p class="card-text">
                    </p>


                    <div class="row">
                        <label>Cash Remitance To So</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="crwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <label>Saving Withdrawal</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="sbwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>RD Withdrawal</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="rdwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>SSA Withdrawal</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="ssawtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>TD Withdrawal</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="tdwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>RPLI Withdrawal</label>
                        <div class="form-group">
                            <div class="input-group"> 
                                <asp:TextBox CssClass="form-control" ID="rpliwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Moneyorder Withdraw </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="monwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Ippb Withdradal</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="ippbwtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                  <div class="card-footer">
                <label>Total Payments :  </label>
                <dx:ASPxLabel ID="totalwithtb" runat="server" Text="00"></dx:ASPxLabel>
            </div>
            </div>
           <div class="card">
                <div class="card-header ">
                    Payments
                </div>
               <div class="card-body">
                   
                    <div class="row">
                        <label>Cash </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="cashtb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Stamp </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="stamptb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Revinue </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="stamp2tb" runat="server" placeholder="Sum Assured" type="number" step="any"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <label>Available Balance </label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="baltb" runat="server" placeholder="Sum Assured" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>
                    </div>

               </div>
               <div class ="card-footer ">
                   <label>Available Balance </label>
                <dx:ASPxLabel ID="avbtb" runat="server" Text="00"></dx:ASPxLabel>
               </div>
               </div>
        </div>
    </div>
    <div class="row">
        <dx:ASPxButton ID="btnnew" runat="server" Text="New"></dx:ASPxButton>
        <dx:ASPxButton ID="btncalculate" runat="server" Text="Calculate"></dx:ASPxButton>
        <dx:ASPxButton ID="btnsave" runat="server" Text="Save"></dx:ASPxButton>
        <dx:ASPxButton ID="btnupdate" runat="server" Text="Update"></dx:ASPxButton>
        <dx:ASPxButton ID="btndelete" runat="server" Text="Delete"></dx:ASPxButton>
        <dx:ASPxButton ID="btnprint" runat="server" Text="Print"></dx:ASPxButton>
    </div>


</asp:Content>
