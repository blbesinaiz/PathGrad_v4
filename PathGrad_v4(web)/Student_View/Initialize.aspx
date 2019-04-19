﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Initialize.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.Initialize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Initialize Account</title>    <asp:PlaceHolder runat="server">
    <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        .blacktext {
            color: black;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
            
        <div class="row">
            <center>
            <asp:MultiView ID="Initialize_MultiView" runat="server">
                <asp:View ID="Welcome" runat="server">
                    <h1> Welcome to Path to Grad</h1>
                    <h2> Let's Begin by Setting up Your Account</h2>
                    <asp:Button ID="Butt_Next1" runat="server" Text="Next"  CssClass="btn btn-default" OnClick="Butt_Next1_Click" />
                </asp:View>
                
                <asp:View ID="Track" runat="server">
                    <h1> Setup Curriculum Track</h1>
                    <asp:Label ID="CurriculumTrack" runat="server" Text="Curriculum Track"></asp:Label>
                    <asp:DropDownList ID="TrackList" runat="server">
                        <asp:ListItem>BS.CSC.IA</asp:ListItem>
                    </asp:DropDownList> 
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  CssClass="btn btn-default" Text="Submit" />
                    <br />
                    <asp:Button ID="Step2" runat="server" Text="Next"  CssClass="btn btn-default" OnClick="Step2_Click" />
                </asp:View>
                <asp:View ID="PreviousCourses" runat="server">
                    <h1>Previous Courses Taken</h1>
                    <h3>Please check all previous coureses taken: </h3>
                    <asp:CheckBoxList ID="PreviousList" runat="server" OnSelectedIndexChanged="PreviousList_SelectedIndexChanged">

                    </asp:CheckBoxList> <br /><br />
                    <asp:Button ID="Step3" runat="server" Text="Next"  CssClass="btn btn-default" OnClick="Step3_Click" />
                </asp:View>
                <asp:View ID="SaveProfile" runat="server">
                    <h1>Summary</h1>
                    <h3>Review Profile. Click submit when finished.</h3>
                    <asp:Label ID="Label1" runat="server" Text="Curriculum: "></asp:Label>
                    <asp:TextBox ID="txt_curriculum" runat="server" CssClass="form-control" ></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Previous Classes Chosen: "></asp:Label>
                    <asp:TextBox ID="txt_previous" runat="server" CssClass="form-control" Height="58px" Width="274px">No classes selected</asp:TextBox> 
                    <br /><br /><br />
                    <asp:Button ID="Submit" runat="server"  CssClass="btn btn-default" Text="Submit" OnClick="Submit_Click" />
                </asp:View>
            </asp:MultiView>
            </center>
        </div>
    </form>
</body>
</html>
