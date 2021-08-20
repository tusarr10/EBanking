<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="Register.aspx.vb" Inherits="TWEB.RegisterModule" Title="Register" %>

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

            <dx:aspxformlayout runat="server" id="FormLayout" clientinstancename="formLayout" cssclass="formLayout" usedefaultpaddings="false">
                <settingsadaptivity adaptivitymode="SingleColumnWindowLimit" />
                <settingsitemcaptions location="Top" />
                <styles layoutgroup-cell-paddings-padding="0" layoutitem-paddings-paddingbottom="8" />
                <items>
                    <dx:layoutgroup showcaption="False" groupboxdecoration="None" paddings-padding="16">
                        <items>
                            <dx:layoutitem caption="User name">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxtextbox id="RegisterUserNameTextBox" runat="server" width="100%">
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <requiredfield isrequired="true" errortext="User name is required" />
                                            </validationsettings>
                                            <clientsideevents init="function(s, e){ s.Focus(); }" />
                                        </dx:aspxtextbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="First name">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxtextbox id="FirstNameTextBox" runat="server" width="100%">
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <requiredfield isrequired="true" errortext="First name is required" />
                                            </validationsettings>
                                        </dx:aspxtextbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="Last name">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxtextbox id="LastNameTextBox" runat="server" width="100%">
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <requiredfield isrequired="true" errortext="Last name is required" />
                                            </validationsettings>
                                        </dx:aspxtextbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="Email">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxtextbox id="EmailTextBox" runat="server" width="100%">
                                            <validationsettings display="Dynamic" setfocusonerror="true" errortextposition="Bottom" errordisplaymode="ImageWithText">
                                                <regularexpression errortext="Invalid e-mail" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                <requiredfield isrequired="true" errortext="Email is required" />
                                            </validationsettings>
                                        </dx:aspxtextbox>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="Password">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxbuttonedit id="PasswordButtonEdit" runat="server" clientinstancename="passwordButtonEdit" width="100%" password="true" clearbutton-displaymode="Never">
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
                                            <clientsideevents buttonclick="onPasswordButtonEditButtonClick" validation="onPasswordValidation" />
                                        </dx:aspxbuttonedit>
                                    </dx:layoutitemnestedcontrolcontainer>
                                </layoutitemnestedcontrolcollection>
                            </dx:layoutitem>

                            <dx:layoutitem caption="Confirm password">
                                <layoutitemnestedcontrolcollection>
                                    <dx:layoutitemnestedcontrolcontainer>
                                        <dx:aspxbuttonedit id="ConfirmPasswordButtonEdit" runat="server" clientinstancename="confirmPasswordButtonEdit" width="100%" password="true" clearbutton-displaymode="Never">
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
                                                <requiredfield isrequired="true" errortext="Confirm your password" />
                                            </validationsettings>
                                            <clientsideevents buttonclick="onPasswordButtonEditButtonClick" validation="onPasswordValidation" />
                                        </dx:aspxbuttonedit>
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
                                        <dx:aspxbutton id="RegisterButton" runat="server" width="200" text="Create an account" onclick="RegisterButton_Click"></dx:aspxbutton>
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