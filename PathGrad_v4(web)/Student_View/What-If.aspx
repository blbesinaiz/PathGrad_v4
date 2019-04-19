<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="What-If.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.What_If" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <center>
                <h2 align="center"><em>What-If Central Feature Coming Soon!</em></h2>
                <asp:Button ID="Butt_Peek" runat="server" Text="Preview" CssClass="btn btn-default" OnClick="Butt_Peek_Click"/><br /><br />
                <asp:Panel ID="Panel_WhatIf" runat="server" Visible="false" BackImageUrl="~/Images/whatIf-background.JPG" align="center" Height="350px" Width="550px">
                <asp:Image ID="WhatIf" runat="server" ImageUrl="~/Images/What-If.JPG" width="375px" style="padding-right: 15px; padding-top: 20px;" Height="300px"/><br><br />
                <br /><br />
                </asp:Panel>
            </center>
        </div>
   <br /><br />
</asp:Content>
