<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PathGrad_v4_web_.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
     <p><i><b>Path to Grad</b></i> is a web-based application that will serve as an additional tool to aid students in planning a 
        sequence of courses that lead to graduation. In general, each degree program and specialized track is designed around a 
        curriculum in which students take certain courses in a planned per-semester order, pass every course, and thus satisfy 
        all requirements in a fixed number of semesters (e.g. eight semesters or four years). In practice, many students deviate 
        from this idealized "path to graduation."</p>
    <p>Therefore, Path to Grad can serve as a bridge between an idealized path and an actual path to graduation. It centers 
        around an interactive degree map whose primary goal is to suggest which courses a student can take on a per-semester 
        basis to successfully complete all remaining degree requirerments, considering which courses the student has already 
        completed, and selected constraints such as maximum number of credit-hours per semester or a desired graduation date. 
        Furthermore, this version of Path to Grad incorporates limited "what-if?" scenario planning (e.g. failing a class, delaying 
        a class, etc) and projects how such changes will impact a student's progress toward graduating.</p>
    <p>Click Register or Login above to get started, or use the Contact link in the above navigation to drop us a question.</p>
</asp:Content>
