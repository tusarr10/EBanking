<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Official/official.Master" CodeBehind="transction.aspx.vb" Inherits="TWEB.transction" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


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


        <div class="card ">
            <div class="card-body ">
                <div class="row">
                    control here
                </div>

            </div>

        </div>


        <div class="row">
            <div class="col">
                <hr>
            </div>
        </div>

        <%-- For all transction --%>
        <div class="card ">
            <div class="card-body ">
               
                <div class="content">
                    <div class="card-body">
                        <dx:BootstrapButton ID="BootstrapButton1" runat="server" AutoPostBack="false" Text="Verify All"></dx:BootstrapButton>
                    </div>
                    <div class="col-md-8 col-md-offset-2">
                        <dx:ASPxGridView ID="journalGridView" runat="server" CssClass="table " AutoGenerateColumns="False">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="da_te" Name="da_te" Caption="Date" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="accounttype" Name="accounttype" Caption="Account Type" VisibleIndex="1"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="accountnumber" Name="accountnumber" Caption="Account Number" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="na_me" Name="na_me" Caption="Name" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="deposit" Name="deposit" Caption="Deposit" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="withdraw" Name="withdraw" Caption="Withdraw" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="trid" Name="trid" Caption="Transction Id" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="dlt" Name="dlt" Caption="DLT" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="balance" Name="balance" Caption="Balance" VisibleIndex="8"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="status" Name="status" Caption="Status" VisibleIndex="9"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="office" Name="office" Caption="Office" Visible="true" VisibleIndex="10"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="u_ser" Name="u_ser" Caption="User" Visible="true" VisibleIndex="11"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataButtonEditColumn Name="BtnShowData" Caption="Show" VisibleIndex="12">

                                    <DataItemTemplate>
                                        <dx:BootstrapButton ID="btnAction2" runat="server" AutoPostBack="false" Text="Verify" OnClick="btnAction_Click2"></dx:BootstrapButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataButtonEditColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>

                </div>
            </div>
        </div>

        <%--    For Saving Journal--%>
        <div class="card">
            <div class="card-body">

                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="Saving Transction" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                    <PanelCollection>
                        <dx:PanelContent>


                            <div class="content">
                                <dx:BootstrapGridView ID="sbjournalGridView" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <dx:BootstrapGridViewTextColumn FieldName="accountnumber" Name="accountnumber" Caption="account number" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="depositername" Name="depositername" Caption="depositer name" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="da_te" Name="da_te" Caption="Date" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="bbt" FieldName="bbt" Caption="Balance Before Transction" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="transctiontype" Name="transctiontype" Caption="transction type" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="amount" Name="amount" Caption="Amount" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="bat" Name="bat" Caption="Balance After Transction" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="trid" Name="trid" Caption="Transction ID" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="status" Name="status" Caption="status" VisibleIndex="9"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="office" Name="office" Caption="office" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="u_ser" Name="u_ser" Caption="User" Visible="False" VisibleIndex="11"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="Details" Name="Details" Caption="Details" Visible="true" VisibleIndex="12"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="ActionClick" Caption="Action" VisibleIndex="0">

                                            <DataItemTemplate>
                                                <dx:BootstrapButton ID="btnAction" runat="server" AutoPostBack="false" Text="Verify" OnClick="btnAction_Click"></dx:BootstrapButton>
                                            </DataItemTemplate>

                                        </dx:BootstrapGridViewTextColumn>
                                    </Columns>

                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="780" AllowOnlyOneAdaptiveDetailExpanded="true" AdaptiveDetailColumnCount="2"></SettingsAdaptivity>

                                </dx:BootstrapGridView>
                            </div>

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

            </div>
        </div>

        <%-- For Rd Journal --%>
        <div class="card">
            <div class="card-body">
                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="RD Transction" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                    <PanelCollection>
                        <dx:PanelContent>


                            <div class="content">
                                <dx:BootstrapGridView ID="RdJournalGridView" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <dx:BootstrapGridViewTextColumn FieldName="accountnumber" Name="accountnumber" Caption="account number" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="depositername" Name="depositername" Caption="depositer name" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="da_te" Name="da_te" Caption="Date" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="bbt" FieldName="bbt" Caption="Balance Before Transction" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="transctiontype" Name="transctiontype" Caption="transction type" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="amount" Name="amount" Caption="Amount" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="bat" Name="bat" Caption="Balance After Transction" VisibleIndex="9"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="trid" Name="trid" Caption="Transction ID" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="status" Name="status" Caption="status" VisibleIndex="11"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="office" Name="office" Caption="office" VisibleIndex="12" Visible="false"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="u_ser" Name="u_ser" Caption="User" Visible="False" VisibleIndex="13"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="Details" Name="Details" Caption="Details" Visible="true" VisibleIndex="14"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="ActionClick" Caption="Action" VisibleIndex="0">

                                            <DataItemTemplate>
                                                <dx:BootstrapButton ID="BootstrapButton2" runat="server" AutoPostBack="false" Text="Verify" OnClick="btnAction_Click1"></dx:BootstrapButton>
                                            </DataItemTemplate>

                                        </dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="fine" Name="fine" Caption="Fine" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="mo_nth" Name="mo_nth" Caption="Month" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                                    </Columns>
                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="780" AllowOnlyOneAdaptiveDetailExpanded="true" AdaptiveDetailColumnCount="2"></SettingsAdaptivity>
                                </dx:BootstrapGridView>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

            </div>
        </div>

        <%-- For SSA Journal --%>
        <div class="card">
            <div class="card-body">
                <dx:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="SSA Transction" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                    <PanelCollection>
                        <dx:PanelContent>

                            <div class="content">
                                <dx:BootstrapGridView ID="ssaJournalGridView" runat="server" AutoGenerateColumns="False">

                                    <%--  <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" />--%>
                                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="780" AllowOnlyOneAdaptiveDetailExpanded="true" AdaptiveDetailColumnCount="2"></SettingsAdaptivity>


                                    <Columns>
                                        <dx:BootstrapGridViewTextColumn FieldName="accountnumber" Name="accountnumber" Caption="account number" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="depositername" Name="depositername" Caption="depositer name" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="da_te" Name="da_te" Caption="Date" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="bbt" FieldName="bbt" Caption="Balance Before Transction" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="transctiontype" Name="transctiontype" Caption="transction type" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="amount" Name="amount" Caption="Amount" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="bat" Name="bat" Caption="Balance After Transction" VisibleIndex="9"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="trid" Name="trid" Caption="Transction ID" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="status" Name="status" Caption="status" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="office" Name="office" Caption="office" VisibleIndex="11"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="u_ser" Name="u_ser" Caption="User" Visible="False" VisibleIndex="12"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="Details" Name="Details" Caption="Details" Visible="true" VisibleIndex="13"></dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn Name="ActionClick" Caption="Action" VisibleIndex="0">

                                            <DataItemTemplate>
                                                <dx:BootstrapButton ID="BootstrapButton3" runat="server" AutoPostBack="false" Text="Verify" OnClick="btnAction_Click3"></dx:BootstrapButton>
                                            </DataItemTemplate>

                                        </dx:BootstrapGridViewTextColumn>
                                        <dx:BootstrapGridViewTextColumn FieldName="fine" Name="fine" Caption="Fine" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                                    </Columns>
                                    <SettingsPager PageSize="30" NumericButtonCount="6" />


                                </dx:BootstrapGridView>
                            </div>

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
        </div>

        <%-- For TD Journal --%>
        <div class="card">
            <div class="card-body">

                <dx:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" Width="100%" ClientInstanceName="roundpanel" HeaderText="TD Transction" AllowCollapsingByHeaderClick="True" ShowCollapseButton="True" LoadContentViaCallback="True" Collapsed="true">
                    <PanelCollection>
                        <dx:PanelContent>

                            <div class="content">
                                Not DONE Yet
                <dx:BootstrapGridView ID="BootstrapGridView3" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <dx:BootstrapGridViewTextColumn FieldName="accountnumber" Name="accountnumber" Caption="account number" VisibleIndex="0"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="depositername" Name="depositername" Caption="depositer name" VisibleIndex="1"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="da_te" Name="da_te" Caption="Date" VisibleIndex="2"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Name="bbt" FieldName="bbt" Caption="Balance Before Transction" VisibleIndex="3"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="transctiontype" Name="transctiontype" Caption="transction type" VisibleIndex="4"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="amount" Name="amount" Caption="Amount" VisibleIndex="5"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="bat" Name="bat" Caption="Balance Before Transction" VisibleIndex="6"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="trid" Name="trid" Caption="Transction ID" VisibleIndex="7"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="status" Name="status" Caption="status" VisibleIndex="8"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="office" Name="office" Caption="office" VisibleIndex="9"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="u_ser" Name="u_ser" Caption="User" Visible="False" VisibleIndex="10"></dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Name="ActionClick" Caption="Action" VisibleIndex="11">

                            <DataItemTemplate>
                                <%--  <dx:BootstrapButton ID="btnAction" runat="server" AutoPostBack="false" Text="Verify"  OnClick="btnAction_Init"></dx:BootstrapButton>

                                <asp:Button ID="Button1" OnClick="btnAction_Init"  runat="server" Text="Button" />--%>
                            </DataItemTemplate>

                        </dx:BootstrapGridViewTextColumn>
                    </Columns>
                </dx:BootstrapGridView>
                            </div>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

            </div>
        </div>

    </div>


</asp:Content>
