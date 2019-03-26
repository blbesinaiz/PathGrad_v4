<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.LandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <!-- Open Settings popup window!! -->
    <script type ="text/javascript">
        function OpenNewWindow() {
            window.open("Initialize.aspx","mywindow","location=100,status=1,scrollbars=1,width=500,height=500");
        }
    </script>

    <div class="jumbotron">
        <h1 style=<strong>Snapshot</strong></h1>
        <hr width="450" align="left" color="Gainsboro" />
        <!-- Table -->
        <asp:Table ID="Table1" 
            runat="server" 
            Font-Size="Small" 
            Width="550" 
            Font-Names="Palatino"
            BackColor="Orange"
            BorderColor="DarkRed"
            BorderWidth="2"
            ForeColor="Snow"
            CellPadding="2"
            CellSpacing="2"
            >
            <asp:TableHeaderRow 
                runat="server" 
                ForeColor="Snow"
                BackColor="OliveDrab"
                Font-Bold="true"
                >
                <asp:TableHeaderCell>Categories</asp:TableHeaderCell>
                <asp:TableHeaderCell>Required</asp:TableHeaderCell>
                <asp:TableHeaderCell>Current Earned</asp:TableHeaderCell>
                <asp:TableHeaderCell>Current Remaining</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow 
                ID="TableRow1" 
                runat="server" 
                BackColor="OrangeRed"
                >
                <asp:TableCell>Institutional Credits: </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="30.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="0.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="30.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow2" 
                runat="server" 
                BackColor="DarkOrange"
                >
                <asp:TableCell>Institutional GPA: </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="2.0"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="4.0"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Met"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow3" 
                runat="server" 
                BackColor="OrangeRed"
                >
                <asp:TableCell>Overall Credits:</asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="120.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label8" runat="server" Text="0.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="120.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow4" 
                runat="server" 
                BackColor="DarkOrange"
                >
                <asp:TableCell>Overall GPA:</asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label10" runat="server" Text="2.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="4.00"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label12" runat="server" Text="Met"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
     </div>
    <div class="row">
        <div class="column">
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
