﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PathGrad_v4_web_._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-md-6">
            <h2 class="inlineBlock _3ma _6n _6s _6v" style="padding: 42px 0 24px; font-size: 28px; line-height: 36px"> Plan the ultimate course sequence<br>for gradutaion on Path to Grad </h2>
          <div style="float: left; clear: left"><img src="https://github.com/blbesinaiz/GradPath-web/blob/master/Path%20Grad%20v3%20(Web)/Img/Path%20To%20Grad%20Logo.png?raw=true" align="left" /></div>
        </div>

        <div class="col-md-6">
            <h2 class="inlineBlock _3ma _6n _6s _6v" style="padding: 42px 0 24px; font-size: 28px; line-height: 36px"> Create an Account </h2>
            <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <div class="form-horizontal">
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                            CssClass="text-danger" ErrorMessage="The Name field is required." />
                    </div>
                </div>
                 <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="StudentID" CssClass="col-md-2 control-label">Student ID</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="StudentID" CssClass="form-control" TextMode="Number" Width="282px" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="StudentID"
                            CssClass="text-danger" ErrorMessage="The Student ID field is required." />
                    </div>
                </div> 
                 <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">NSU Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>