<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomizePath.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.CustomizePath" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customize Path</title>
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
            <li><a href="#tabs-3">Path Customization</a></li>
            <li><a href="#tabs-4">Contact Advisor</a></li>
          </ul>
          <div id="tabs-1">
              <div class="row">
                  <div class="col-md-6">
                  <h2>Profile Picture</h2>
                    <asp:Image ID="Image_Profile" runat="server" ImageUrl="~/Images/profile_icon.png" width="125px" style="margin-left: 55px; padding-right: 15px; padding-top: 20px;" Height="125px" ImageAlign="Middle"/><br />
                   </div>
                  <div class="col-md-6">
                      <asp:FileUpload ID="FileUpload1" runat="server" /> <br />
                    <asp:Button ID="ChangePic" runat="server" Text="Change Profile Image" /><br />
                    <asp:Button ID="RemovePic" runat="server" Text="Remove Image" /><br />
                   </div>
              </div>
              <h2>Account Info</h2>
              <div class="row">
                  <asp:TextBox ID="Txt_name" runat="server">Name</asp:TextBox> <br />
                  <asp:TextBox ID="Txt_ID" runat="server">Student ID Number</asp:TextBox> <br />
                  <asp:TextBox ID="Txt_classification" runat="server">Classification</asp:TextBox><br />
                  <asp:TextBox ID="Txt_graduation" runat="server">Expected Graduation Date</asp:TextBox><br />
                  <asp:TextBox ID="Txt_advisor" runat="server">Advisor</asp:TextBox>
              </div>
              <h2>Change Password</h2>
              <div class="row">
                  <asp:TextBox ID="TextBox1" runat="server">New Password</asp:TextBox> <br />
                  <asp:TextBox ID="TextBox2" runat="server">Confirm Password</asp:TextBox> <br />
                  <asp:Button ID="Butt_Submit" runat="server" Text="Submit" /><br />
              </div>
          <div id="tabs-2">
            <p> Search by sequence for class previosuly taken: </p>
              <asp:TextBox ID="Txt_Search" runat="server">Search</asp:TextBox>
              <asp:ListBox ID="ListBox_Search" runat="server">
                  <asp:ListItem>No Results</asp:ListItem>
              </asp:ListBox>
            <p> Table of Classes Previously Taken</p>
              <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                    </Columns>
                </asp:GridView>
              <asp:GridView ID="GridView_Previous" runat="server" Width="332px">
              </asp:GridView>
          </div>
          <div id="tabs-3">
            <p> Path Customization Content</p>
            <div class="row">
                <h2>Current Semester</h2>

            </div>
          </div>
          <div id="tabs-4">
            <p> Contact Advisor Content</p>
          </div>
        </div>
    </form>
</body>
</html>
