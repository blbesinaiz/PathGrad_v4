<%@ Page Title="" Language="C#" MasterPageFile="~/Student_View/StudentSite.Master" AutoEventWireup="true" CodeBehind="PerfectPath.aspx.cs" Inherits="PathGrad_v4_web_.Student.PerfectPath" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Perfect Path Generation Page</h1>
    <asp:Panel ID="Panel_Settings" runat="server">
        <h3> Fill in Settings</h3>
        <asp:Label ID="Label1" runat="server" Text="Max Credit Hours per Semester: "></asp:Label>
        <asp:TextBox ID="txt_maxCH" runat="server"></asp:TextBox> <br/>
        <asp:Button ID="Butt_Generate" runat="server" Text="Generate" OnClick="Butt_Generate_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel_Path" runat="server">
        <asp:TextBox ID="txt_Path" runat="server" Height="292px" Width="514px"></asp:TextBox>
    </asp:Panel>
</asp:Content>
