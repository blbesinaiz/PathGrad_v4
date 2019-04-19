<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomizePath.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.CustomizePath" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customize Path</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        .blacktext {
            color: black;
        }
    </style>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
    $( function() {
        $( "#tabs" ).tabs();
    } );
    </script>


</head>
<body>
    <form runat="server">
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">User Profile</a></li>
                <li><a href="#tabs-2">The Road So Far</a></li>
                <li><a href="#tabs-4">Contact Advisor</a></li>
            </ul>
            <div id="tabs-1">
                <div class="row">
                    <div class="col-md-6">
                        <h2 style=<strong>Profile</h2>
                        <asp:Image ID="Image_Profile" runat="server" ImageUrl="~/Images/profile_icon.png" Width="125px" Style="margin-left: 55px; padding-right: 15px; padding-top: 20px;" Height="125px" ImageAlign="Middle" /><br />
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>

                <h2>Account Info</h2>
                <div class="row">
                    <div class="col-md-6" style="text-align: center">
                        <asp:TextBox ID="Txt_name" runat="server" CssClass="form-control">Name</asp:TextBox>
                        <br />
                        <asp:TextBox ID="Txt_ID" runat="server" CssClass="form-control">Student ID Number</asp:TextBox>
                        <br />
                        <asp:TextBox ID="Txt_classification" runat="server" CssClass="form-control">Classification</asp:TextBox><br />
                        <asp:TextBox ID="Txt_graduation" runat="server" CssClass="form-control">Expected Graduation Date</asp:TextBox><br />
                        <asp:TextBox ID="Txt_advisor" runat="server" CssClass="form-control">Advisor</asp:TextBox>
                    </div>
                </div>
                <h2>Change Password</h2>
                <div class="row">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control">New Password</asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control">Confirm Password</asp:TextBox>
                    <br />
                    <asp:Button ID="Butt_Submit" runat="server" CssClass="btn-default" Text="Submit" /><br />
                </div>
            </div>
            <div id="tabs-2">
                <asp:TextBox ID="Txt_Search" runat="server" CssClass="form-control" Width="286px" Height="33px">Search</asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/search.png" Height="36px" Style="margin-right: 0px" Width="52px" />
                <br />
                <br />
                <asp:ListBox ID="ListBox_Search" runat="server" CssClass="list-group" Width="350px">
                    <asp:ListItem>No Results</asp:ListItem>
                </asp:ListBox>
                <h3>Courses Previously Taken</h3>
                <asp:Panel ID="Panel_Taken" runat="server" ScrollBars="Vertical" Height="300" Width="500">
                    <asp:GridView ID="GridView_Previous" runat="server" Width="500px" BackColor="White"></asp:GridView>
                </asp:Panel>
            </div>
        <div id="tabs-4">
            <h3>Contact Advisor Content</h3>
            <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Width="230px">LAST NAME, FIRST NAME</asp:TextBox><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="   To:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Width="230px" Style="margin-left: 23px">LAST NAME, FIRST NAME</asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Height="30px" Width="488px">Subject</asp:TextBox><br />
            <br />
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Height="155px" Width="484px">Type Message Here</asp:TextBox><br />
            <br />

            <asp:CheckBox ID="CheckBox1" runat="server" />
            <asp:Label ID="Label3" runat="server" Text="Label">Send me a copy</asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="Save as Draft" />
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" Text="Send!" /><br />
            <br />

            <asp:ListBox ID="ListBox1" runat="server" Width="490px">
                <asp:ListItem>DRAFTS</asp:ListItem>
                <asp:ListItem>(no subject)</asp:ListItem>
                <asp:ListItem>Hello, Dr.Graham</asp:ListItem>
                <asp:ListItem>Fall Semester 2019</asp:ListItem>
                <asp:ListItem>Forensics Project</asp:ListItem>

            </asp:ListBox>
        </div>
        </div>
    </form>
</body>
</html>
