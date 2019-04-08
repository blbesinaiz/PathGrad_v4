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
    <div id="tabs">
      <ul>
        <li><a href="#tabs-1">User Profile</a></li>
        <li><a href="#tabs-2">The Road So Far</a></li>
        <li><a href="#tabs-3">Path Customization</a></li>
        <li><a href="#tabs-4">Contact Advisor</a></li>
      </ul>
      <div id="tabs-1">
        <p> User Profile Content</p>
      </div>
      <div id="tabs-2">
        <p> The Road So Far Content</p>
      </div>
      <div id="tabs-3">
        <p> Path Customization Content</p>
      </div>
      <div id="tabs-4">
        <p> Contact Advisor Content</p>
      </div>
    </div>
</body>
</html>
