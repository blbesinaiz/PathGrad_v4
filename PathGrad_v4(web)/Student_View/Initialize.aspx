<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Initialize.aspx.cs" Inherits="PathGrad_v4_web_.Student_View.Initialize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Initialize Account</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="Initialize_MultiView" runat="server">
                <asp:View ID="Track" runat="server">
                    <h1> Setup Curriculum Track</h1>
                    <asp:Label ID="CurriculumTrack" runat="server" Text="Curriculum Track"></asp:Label>
                    <asp:DropDownList ID="TrackList" runat="server">
                        <asp:ListItem>BS.CSC.IA</asp:ListItem>
                    </asp:DropDownList> <br />
                    <asp:Button ID="Step2" runat="server" Text="Step 2" OnClick="Step2_Click" />
                </asp:View>
                <asp:View ID="PreviousCourses" runat="server">
                    <h1>Previous Courses Taken</h1>
                    <h3>Please check all previous coureses taken: </h3>
                    <asp:CheckBoxList ID="PreviousList" runat="server" OnSelectedIndexChanged="PreviousList_SelectedIndexChanged">

                    </asp:CheckBoxList> <br /><br />
                    <asp:Button ID="Step3" runat="server" Text="Step3" OnClick="Step3_Click" />
                </asp:View>
                <asp:View ID="SaveProfile" runat="server">
                    <h1>Summary</h1>
                    <h3>Review Profile. Click submit when finished.</h3>
                    <asp:Button ID="Submit" runat="server" Text="Submit" />
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
