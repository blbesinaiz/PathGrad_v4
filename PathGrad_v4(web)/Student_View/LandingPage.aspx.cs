using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Student_View
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_ID.Text = Student1.ID.ToString();
            txt_Email.Text = Student1.email;

            updateAttempts(Student1.ID);
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }


        //Function determines if intial login
        //If initial, then initialize student profile
        //If not, update login attempt and restore session
        public void updateAttempts(int ID)
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
                //Initialize.setupProfile();
                string myStringVariable = "Due to this being your first login\n " +
                    "Click on CUSTOMIZE under profile to initialize account!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                
                //Take off initial login
                //Currently not working!!
                string param = "{$set: { 'Initial_Login' : '0' } }";
                string filter2 = "{ '_id' : " + ID + " }";

                BsonDocument filterDoc = BsonDocument.Parse(filter2);
                BsonDocument document = BsonDocument.Parse(param);
                collection.UpdateOne(filterDoc, document);
            }
            else if(list.Count == 0)
            {
                //Restore Account
                restoreSession();

            }
        }

        public static void restoreSession()
        {
            //string filename = Student.ID.ToString() + ".txt";
            //var reader = new StreamReader(File.OpenRead(filename));
            //string contents = File.ReadAllText(filename);

            //Make Instance of tempStudent Object
            tempStudent temp = new tempStudent();

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Student_Profiles");

            //Query Database
            var filter = new BsonDocument
            {
                {"_id", Student1.ID}
            };
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();

            //Deserealize
            var holder = list[0]["profile"].ToString();
            temp = JsonConvert.DeserializeObject<tempStudent>(holder);

            //Reasign to Student in program
            Student1.ID = temp.tempID;
            Student1.name = temp.tempName;
            Student1.track = temp.tempTrack;
            Student1.courseList = temp.tempCourses;
            Student1.takenCourses = temp.tempTaken;
        }

    }
}