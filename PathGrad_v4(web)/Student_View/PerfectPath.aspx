<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="PerfectPath.aspx.cs" Inherits="PathGrad_v4_web_.Student.PerfectPath" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" Visible="False">
    <style type="text/css">
        .inlineBlock { display: inline-block; }
    </style>
    <h1> Perfect Path Generation</h1>
    <asp:Panel ID="Panel_Settings" CssClass="panel-default" runat="server">
        <h3> Fill in Settings</h3>
        <asp:Label ID="Label1" runat="server" Text="Max Credit Hours per Semester: "></asp:Label>
        <asp:TextBox ID="txt_maxCH" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox> <br/>
        <asp:Button ID="Butt_Generate" runat="server" Text="Generate" CssClass="btn btn-default" OnClick="Butt_Generate_Click" />
        <br />
    </asp:Panel>
    <br /><br />
    <asp:Label ID="Label_Graduation" runat="server"  Text="Expected Graduation:" Visible="False">
        <asp:TextBox ID="Txt_Graduation" runat="server" CssClass="form-control">Semester xxxx</asp:TextBox><br /><br />
    </asp:Label>
    <asp:Panel ID="Panel_Path" runat="server">
        <asp:ListBox ID="ListBox_Path" runat="server" Width="511px" Height="389px" Visible="False"></asp:ListBox><br />
    </asp:Panel>
</asp:Content>
