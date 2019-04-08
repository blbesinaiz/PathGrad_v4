<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="LandingPage-def.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.LandingPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <!-- Open Settings popup window!! -->
    <script type ="text/javascript">
        function OpenNewWindow() {
            window.open("Initialize.aspx","mywindow","location=100,status=1,scrollbars=1,width=500,height=500");
        }
    </script>

    <div class="jumbotron">
        <h1> style=<strong>Snapshot</strong></h1>
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <h2> style=<strong>Expected Graduation: </strong></h2>
        <asp:TextBox ID="Txt_ExpectedGradauation" runat="server"></asp:TextBox>
     </div>
    <div class="row">
        <h1> style=<strong>Your Perfect Path</strong></h1>
    </div>
    <div class="row">
        <h1> style=<strong>Your Perfect Path</strong></h1>
        <div class="col-md-6">
            <h2>Courses Being Taken</h2>
            <asp:Table ID="Table_CurrentCourses" runat="server"></asp:Table>
            <asp:Button ID="Button1" runat="server" OnClientClick="OpenNewWindow();" Text="Customize Path" />
        </div>
        <div class="col-md-6">
            <h2>Next Semester's Courses</h2>
            <asp:Table ID="Table_NextCoureses" runat="server"></asp:Table>
            <asp:Button ID="Butt_Perfect" runat="server" Text="Perfect Path" />
            <asp:Button ID="Butt_Alternate" runat="server" Text="Alternate Path" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h3>Profile</h3>
            <asp:Panel ID="Panel_Profile" runat="server">
                <asp:Image ID="Image_Profile" runat="server" ImageUrl="~/Images/profile_icon.png" width="125px" style="padding-right: 15px; padding-top: 20px;" Height="125px" ImageAlign="Left"/>
                <asp:Button ID="Upload" runat="server" Text="Upload" />
                <asp:Button ID="Delete" runat="server" Text="Delete" />
                <br /><br />
                <asp:Label ID="StudentID" runat="server" Text="Student ID: "></asp:Label>
                <asp:TextBox ID="txt_ID" runat="server" Text="Student ID"></asp:TextBox> <br/>
                <asp:Label ID="Email" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txt_Email" runat="server" Text="Student Email"></asp:TextBox> <br/>
                <asp:Button ID="Customize" runat="server" OnClientClick="OpenNewWindow();" Text="Customize" />

            </asp:Panel>
        </div>
        <div class="column">
            <h3>Roadmap</h3>
            <asp:Panel ID="Panel_Roadmap" runat="server">
                 <asp:Image ID="Panel_Progress" runat="server" ImageUrl="~/Images/4 - Roadmap FINAL - Chart.png" width="350px" style="padding-right: 15px; padding-top: 20px;" Height="125px"/>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
