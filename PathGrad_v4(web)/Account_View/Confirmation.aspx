<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="PathGrad_v4_web_.Account.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Thank you for confirming your account. Click <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account_View/Login">here</asp:HyperLink>  to login             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                An error has occurred.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
