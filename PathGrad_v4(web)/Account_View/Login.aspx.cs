using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using PathGrad_v4_web_.Logic.Models;

namespace PathGrad_v4_web_.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Displays forgot password link
            ForgotPasswordHyperLink.NavigateUrl = "Reset";
        }

        protected void LogIn(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(txt_ID.Text);
            string userPassword = txt_Password.Text;

            //Call Verify Login Function
            if (verifyLogin(userID, userPassword) == true)
            {
                //Initialize Session with Student Values
                Student1.ID = userID;
                //updateAttempts(userID);

                //After settingup/restore session, transition to student profile page
                Response.Redirect("~/Student_View/AlternatePaths.aspx");
            }
            else
            {
                //Login Fail
                FailureText.Text = "Invalid login attempt";
                ErrorMessage.Visible = true;
            }
        }

        //Function verfies if user in database
        public static bool verifyLogin(int ID, string Password)
        {
            //Search Login Database
            bool success = false;

            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");

            //Create filter to search through DB
            var filter = new BsonDocument
            {
                {"_id", ID},
                {"password", Password}
            };

            //Search for desired elements
            //If specified user found then add to list
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                success = true;
            }
            else
                success = false;
            return success;
        }
        /*
        //Function determines if intial login
        //If initial, then initialize student profile
        //If not, update login attempt and restore session
        public static void updateAttempts(int ID)
        {
            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");


            var filter = new BsonDocument
            {
                {"_id", ID},
                {"Initial_Login", 1}
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                //Initialize Account
                Console.Clear();
                Initialize.setupProfile();

                //Take off initial login
                string param = "{$set: { 'Initial_Login' : '0' } }";
                string filter2 = "{ '_id' : " + ID + " }";

                BsonDocument filterDoc = BsonDocument.Parse(filter2);
                BsonDocument document = BsonDocument.Parse(param);
                collection.UpdateOne(filterDoc, document);

            }
            else
            {
                //Restore Account
                db.restoreSession();

            }
            */
    }
}