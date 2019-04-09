<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="PerfectPath.aspx.cs" Inherits="PathGrad_v4_web_.Student.PerfectPath" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" Visible="False">
    <style type="text/css">
        .inlineBlock { display: inline-block; }
    </style>
    <h1> Perfect Path Generation Page</h1>
    <asp:Panel ID="Panel_Settings" runat="server">
        <h3> Fill in Settings</h3>
        <asp:Label ID="Label1" runat="server" Text="Max Credit Hours per Semester: "></asp:Label>
        <asp:TextBox ID="txt_maxCH" runat="server" TextMode="Number"></asp:TextBox> <br/>
        <asp:Button ID="Butt_Generate" runat="server" Text="Generate" OnClick="Butt_Generate_Click" />
    </asp:Panel>
    <br /><br />
    <asp:Label ID="Label_Graduation" runat="server" Text="Expected Graduation:" Visible="False">
        <asp:TextBox ID="Txt_Graduation" runat="server">Semester xxxx</asp:TextBox>
    </asp:Label>
    <asp:Panel ID="Panel_Path" runat="server">
        <asp:Panel ID="Panel_Freshman" runat="server" CssClass="inlineBlock" BackColor="#996633" Height="500px" Width="250px">
            <asp:Label ID="Label4" runat="server" Text="Label">Freshman</asp:Label><br /><br />
            <asp:ListBox ID="ListBox_Fresh1" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Fresh2" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Fresh3" runat="server" Width="210px"></asp:ListBox><br />
        </asp:Panel>
        <asp:Panel ID="Panel_Sophomore" runat="server" CssClass="inlineBlock" BackColor="Red" Height="500px" Width="250px">
            <asp:Label ID="Label5" runat="server" Text="Label">Sophomore</asp:Label><br /><br />
            <asp:ListBox ID="ListBox_Soph1" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Soph2" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Soph3" runat="server" Width="210px"></asp:ListBox><br />
        </asp:Panel>
        <asp:Panel ID="Panel_Junior" runat="server" CssClass="inlineBlock" BackColor="Blue" Height="500px" Width="250px">
            <asp:Label ID="Label3" runat="server" Text="Label">Junior</asp:Label><br /><br />
            <asp:ListBox ID="ListBox_Jun1" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Jun2" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Jun3" runat="server" Width="210px"></asp:ListBox><br />
        </asp:Panel>
        <asp:Panel ID="Panel_Senior" runat="server" CssClass="inlineBlock" BackColor="#00CC00" Height="500px" Width="250px">
            <asp:Label ID="Label6" runat="server" Text="Label">Senior</asp:Label><br /><br />
            <asp:ListBox ID="ListBox_Sen1" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Sen2" runat="server" Width="210px"></asp:ListBox><br />
            <asp:ListBox ID="ListBox_Sen3" runat="server" Width="210px"></asp:ListBox><br />
        </asp:Panel>
        <!--<asp:TextBox ID="txt_Path" runat="server" Height="292px" Width="514px"></asp:TextBox>-->
    </asp:Panel>
</asp:Content>
