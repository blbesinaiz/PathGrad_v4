# Path To Graduation

<img src="https://github.com/blbesinaiz/GradPath-web/blob/master/Path%20Grad%20v3%20(Web)/Img/Path%20To%20Grad%20Logo.png" align="right"
     title="Size Limit logo by Anton Lovchikov" width="120" height="178">

Path to Graduation is a tool for NSU students to use in conjunction
with the Program Evaulation to help aid the process of registering
for classes. This tool features an interactive degreement that allows
students to efficiently map out classes for upcoming semester. 

Although this is a prototype, Path To Grad has much future potential
as a tool to help students.

[comment]: <> (#Have Screenshot of Student View Page)
[comment]: <> (#Have Screenshot of perfect path generation, alternate paths, profile customization)

## Intended Audience

* Norfolk State University Students in Computer Science Degree
* Norfolk State University faculty advisors


## How It Works

You can find a video demo here:....

<Blurb on how it functions>


## Usage

1. Visual Studio 2017 
     * Install [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) verson 15.9
     * Within the Installer install: .NET Desktop Development, Universal Windows Platorm Development, ASP.NET and Web Development
     * Add MongoDB Driver nuget package
        ```sh
        $ Install-Package mongocsharpdriver
        ```
     * Add JSON nuget package
        ```sh
        $ Install-Package Newtonsoft.Json
        $ Install-Package System.Runtime.Serialization.Json -Version 4.3.0
        ```
     * Right click References and do Add Reference, then from Assemblies->Framework select System.Web.Extensions.
Now you should be able to add the following to your class file:
    using System.Web.Script.Serialization;
2. Mongo DB Server and Compass 
     * Install [MongoDB 4.0.6 Community Server](https://www.mongodb.com/download-center/community)
     * Install [MongoDB Compass 1.16.3 (stable)](https://www.mongodb.com/download-center/compass?jmp=hero)
     * Run Server on localhost:27107
     * Somehow clone database to your copy


# References
### MongoDB Guides
https://www.codeproject.com/Articles/656093/Connecting-MongoDB-with-ASP-NET

### Inspiratons
* [Course Road](https://github.com/dannybd/courseroad)
