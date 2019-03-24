using MongoDB.Bson;
using MongoDB.Driver;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(StudentID.Text);
            string userName = Name.Text;
            string userEmail = Email.Text;
            string userPass = Password.Text;
            int InitialLogin = 1;

            //Initialize Session with Student Values
            Student1.ID = userID;
            Student1.name = userName;

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", userID},
              {"password", userPass},
              { "name", userName},
              { "email", userEmail},
              { "Initial_Login", InitialLogin}
            };

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");

            //Insert into Database
            collection.InsertOne(document);

            //Give Status Update, Redirect to Confirmation Page
            Response.Redirect("~/Account_View/Confirmation.aspx");
        }
    }
}