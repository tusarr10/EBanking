<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="SignIn.aspx.vb" Inherits="TWEB.SignInModule" Title="Sign In" %>

<asp:Content runat="server" ContentPlaceHolderID="Head">
    <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/SignInRegister.css") %>' />
    <script type="text/javascript" src='<%# ResolveUrl("~/Content/SignInRegister.js") %>'></script>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
    <div class="formLayout-verticalAlign">
        <div class="formLayout-container">
            <dx:aspxtabcontrol id="SignInRegisterTabControl" runat="server" width="100%" tabalign="Justify" paddings-padding="0">
                <tabs>
                    <dx:tab text="Sign In" navigateurl="SignIn.aspx"></dx:tab>
                    <dx:tab text="Register" navigateurl="Register.aspx"></dx:tab>
                </tabs>
            </dx:aspxtabcontrol>

            <dx:aspxformlayout runat="server" id="FormLayout" clientinstancename="formLayout" usedefaultpaddings="false">
                <settingsadaptivity adaptivitymode="SingleColumnWindowLimit" />
                <settingsitemcaptions location="Top" />
                <styles layoutgroup-cell-paddings-padding="0" layoutitem-paddings-paddingbottom="8" />
                <items>
                    <dx:layoutgroup showcaption="False" groupboxdecoration="None" paddings-padding="16">
                        <items>
                            <dx:layoutitem caption="User name" helptext="Please, enter your user name">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxtextbox id="UserNameTextBox" runat="server" width="100%">
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <requiredfield isrequired="true" errortext="User name is required" />
                                            </validationsettings>
                                            <clientsideevents init="function(s, e){ s.Focus(); }" />
                                        </dx:aspxtextbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="Password">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxbuttonedit id="PasswordButtonEdit" runat="server" width="100%" password="true" clearbutton-displaymode="Never">
                                            <buttonstyle border-borderwidth="0" width="6" cssclass="eye-button" hoverstyle-backcolor="Transparent" pressedstyle-backcolor="Transparent">
                                            </buttonstyle>
                                            <buttontemplate>
                                                <div></div>
                                            </buttontemplate>
                                            <buttons>
                                                <dx:editbutton>
                                                </dx:editbutton>
                                            </buttons>
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <requiredfield isrequired="true" errortext="Password is required" />
                                            </validationsettings>
                                            <clientsideevents buttonclick="onPasswordButtonEditButtonClick" />
                                        </dx:aspxbuttonedit>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem showcaption="False" paddings-paddingtop="13">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxcheckbox id="RememberMeCheckBox" runat="server" text="Remember me" checked="true"></dx:aspxcheckbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem showcaption="False" name="GeneralError">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <div id="GeneralErrorDiv" runat="server" class="formLayout-generalErrorText"></div>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>
                        </items>
                    </dx:layoutgroup>

                    <dx:layoutgroup groupboxdecoration="HeadingLine" showcaption="False">
                        <paddings paddingtop="13" paddingbottom="13" />
                        <groupboxstyle cssclass="formLayout-groupBox" />
                        <items>
                            <dx:layoutitem showcaption="False" horizontalalign="Center" paddings-padding="0">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxbutton id="SignInButton" runat="server" width="200" text="Log In" onclick="SignInButton_Click"></dx:aspxbutton>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>
                        </items>
                    </dx:layoutgroup>
                </items>
            </dx:aspxformlayout>
        </div>
    </div>
</asp:Content>