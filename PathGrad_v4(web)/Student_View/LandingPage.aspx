<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.LandingPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <!-- Open Settings popup window!! -->
    <script type ="text/javascript">
        function OpenNewWindow() {
            window.open("CustomizePath.aspx","mywindow","location=300,status=1,scrollbars=1,width=1000,height=700");
        }
    </script>

    <div class="jumbotron">
        <h1 style=<strong>Snapshot</strong></h1>
        <asp:Label ID="Label1" runat="server" Text="Completed Credits"></asp:Label>
        <asp:TextBox ID="Txt_completed1" runat="server" CssClass="form-control" Text="0/120" ></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Ranking"></asp:Label>
        <asp:TextBox ID="Txt_ranking" runat="server" CssClass="form-control" Text="Freshman" ></asp:TextBox>
        <h2 style=<strong>Expected Graduation: </strong></h2>
        <asp:TextBox ID="Txt_ExpectedGradauation" runat="server" CssClass="form-control"></asp:TextBox>
     </div>
    <div class="row">
        <center>
            <h1 style="text-decoration: underline"><strong>Your Pefect Path:</strong></h1>
        </center>
        <div class="col-md-6">
            <h2><em>Courses in Progress</em></h2>
            <asp:Panel ID="Panel_Current" runat="server" BackImageUrl="~/Images/No_Data-512.png" Height="300px" Width="500px">
                <asp:GridView ID="GridView_Current" runat="server" BackColor="White" Width="500px"></asp:GridView>
                <br /><br />
            </asp:Panel>
            <br /><br />
            <asp:Button ID="Button1" runat="server" OnClientClick="OpenNewWindow();" Text="Customize Path" CssClass="btn btn-default" />
        </div>
        <div class="col-md-6">
            <h2><em>Next Semester's Coureses</em></h2>
            <asp:Panel ID="Panel_Next" runat="server" BackImageUrl="~/Images/No_Data-512.png" Height="300px" Width="500px">
                <asp:GridView ID="GridView_Next" runat="server" BackColor="White" Width="500px"></asp:GridView>
                <br /><br />
            </asp:Panel>
            <br /><br />
            <asp:Button ID="Butt_Perfect" runat="server" Text="Generate Perfect Path" CssClass="btn btn-default" OnClick="Butt_Perfect_Click" />
            <asp:Button ID="Butt_Alternate" runat="server" Text="Alternate Path" CssClass="btn btn-default"/>
        </div>
    </div>
    <div
    <div class="row">
        <div class="col-md-6">
            <h3>Profile</h3>
            <div class="row">
                <asp:Image ID="Image_Profile" runat="server" ImageUrl="~/Images/profile_icon.png" width="125px" style="margin-left: 55px; padding-right: 15px; padding-top: 20px;" Height="125px" ImageAlign="Middle"/>
                
            </div>
                <asp:TextBox ID="txt_ID" runat="server" Text="Student ID" CssClass="form-control"></asp:TextBox> <br/>
                <asp:TextBox ID="txt_Email" runat="server" Text="Student Email" CssClass="form-control" ></asp:TextBox> <br />
                <!--<asp:Button ID="Customize" runat="server" OnClientClick="OpenNewWindow();" Text="Customize" /> -->
        </div>
        <div class="col-md-6">
            <h3>Current Roadmap</h3>
            <asp:Image ID="Panel_Progress" runat="server" ImageUrl="~/Images/4 - Roadmap FINAL - Chart.png" width="350px" style="padding-right: 15px; padding-top: 20px;" Height="125px"/><br><br />
            <asp:Label ID="Lab_Complete" runat="server" Text="Degree Complete: "></asp:Label>
            <asp:TextBox ID="Txt_Complete" runat="server" Text="0%" Width="55px" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>
</asp:Content>
