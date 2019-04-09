<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.LandingPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <!-- Open Settings popup window!! -->
    <script type ="text/javascript">
        function OpenNewWindow() {
            window.open("CustomizePath.aspx","mywindow","location=100,status=1,scrollbars=1,width=1000,height=1000");
        }
    </script>

    <div class="jumbotron">
        <h1 style=<strong>Snapshot</strong></h1>
            <h3>TABLE/BAR CHART</h3>
        <h2 style=<strong>Expected Graduation: </strong></h2>
        <asp:TextBox ID="Txt_ExpectedGradauation" runat="server"></asp:TextBox>
     </div>
    <div class="row">
        <center>
            <h1 style=<strong>Your Perfect Path</strong></h1>
        </center>
        <div class="col-md-6">
            <h2>Courses Being Taken</h2>
            <h3>Courses Taken Table</h3>
            <asp:GridView ID="GridView_Current" runat="server"></asp:GridView>
            <asp:Button ID="Button1" runat="server" OnClientClick="OpenNewWindow();" Text="Customize Path" />
        </div>
        <div class="col-md-6">
            <h2>Next Semester's Courses</h2>
            <h3>Next Semester's Courses Table</h3> 
            <div style="width: 600px; height: 400px; overflow: auto;"><br /><br />
                <asp:GridView ID="GridView_Next" runat="server"></asp:GridView>
            </div>
            <asp:Button ID="Butt_Perfect" runat="server" Text="Generate Perfect Path" OnClick="Butt_Perfect_Click" />
            <asp:Button ID="Butt_Alternate" runat="server" Text="Alternate Path" />
        </div>
    </div>
    <div
    <div class="row">
        <div class="col-md-6">
            <h3>Profile</h3>
            <div class="row">
                <asp:Image ID="Image_Profile" runat="server" ImageUrl="~/Images/profile_icon.png" width="125px" style="margin-left: 55px; padding-right: 15px; padding-top: 20px;" Height="125px" ImageAlign="Middle"/>
                
            </div>
                <asp:TextBox ID="txt_ID" runat="server" Text="Student ID"></asp:TextBox> <br/>
                <asp:TextBox ID="txt_Email" runat="server" Text="Student Email"></asp:TextBox> <br />
                <!--<asp:Button ID="Customize" runat="server" OnClientClick="OpenNewWindow();" Text="Customize" /> -->
        </div>
        <div class="col-md-6">
            <h3>Current Roadmap</h3>
            <asp:Image ID="Panel_Progress" runat="server" ImageUrl="~/Images/4 - Roadmap FINAL - Chart.png" width="350px" style="padding-right: 15px; padding-top: 20px;" Height="125px"/><br><br />
            <asp:Label ID="Lab_Complete" runat="server" Text="Degree Complete: "></asp:Label>
            <asp:TextBox ID="Txt_Complete" runat="server" Text=" "></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="%"></asp:Label>
        </div>
    </div>
</asp:Content>
