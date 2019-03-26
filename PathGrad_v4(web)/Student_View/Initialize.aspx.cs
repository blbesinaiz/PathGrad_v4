using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Student_View
{
    public partial class Initialize : System.Web.UI.Page
    {

        //On page load, allow student to pick curriculum track
        //On step 2: populate table w/ checkboxes of courses student may have taken in past
        //On step 3: Save profile/Summary Page
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTrack("BS.CSC.IA");
            Bind_CheckList();
            if(!IsPostBack)
            {
                Initialize_MultiView.ActiveViewIndex = 0; 
            }
            
        }

        protected void Step2_Click(object sender, EventArgs e)
        {
            //Setup Student track
            Student1.track = TrackList.Text;
            //loadTrack(Student1.track);
            Initialize_MultiView.ActiveViewIndex = 1;

        }

        public static void loadTrack(string track)
        {
            tempStudent temp = new tempStudent();

            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Tracks");


            var filter = new BsonDocument
            {
                {"_id", "BS.CSC.IA"}
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();

            //Deserealize
            var holder = list[0]["curriculum"].ToString();
            temp = JsonConvert.DeserializeObject<tempStudent>(holder);

            Student1.courseList = temp.tempCourses;
        }

        protected void Bind_CheckList() // Method for Binding The Checkbox List  
        {
            string tempCourse;
            List<string> listContents = new List<string>();// Create a List of String Elements 
            foreach (var Course in Student1.courseList)
            {
                tempCourse = Course.charac + " " + Course.num + Course.lab;
                listContents.Add(tempCourse);
            }

            PreviousList.DataSource = listContents;//Set Datasource to CheckBox List  
            PreviousList.DataBind(); // Bind the checkboxList with String List.  

        }

        protected void PreviousList_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        protected void Step3_Click(object sender, EventArgs e)
        {
            //Collect checked boxes
            string str = "";

            for (int i = 0; i < PreviousList.Items.Count; i++)
            {
                if (PreviousList.Items[i].Selected == true)// getting selected value from CheckBox List  
                {
                    
                    str += PreviousList.Items[i].Text + " ," + "<br/>"; // add selected Item text to the String 
                    //Find in student course list and set assigned to true
                    foreach(var Course in Student1.courseList)
                    {
                        if (PreviousList.Items[i].Text == (Course.charac + " " + Course.num + Course.lab))
                            Course.assigned = true;
                    }
                }
            }

            txt_curriculum.Text = Student1.track;
            //Not Working
            txt_previous.Text = str;

            Initialize_MultiView.ActiveViewIndex = 2;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Create instance of class and assign values
            tempStudent t = new tempStudent();

            t.tempID = Student1.ID;
            t.tempName = Student1.name;
            t.tempTrack = Student1.track;
            t.tempCourses = Student1.courseList;
            t.tempTaken = Student1.takenCourses;

            //Serialize Object (JSON.NET method)
            string jsonData = JsonConvert.SerializeObject(t);

            //Console.WriteLine("Serialized Student Object:\n {0}", JsonConvert.SerializeObject(t, Formatting.Indented));

            //Insert into database

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", t.tempID},
              {"profile", jsonData}
            };

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Student_Profiles");

            //Insert into Database
            collection.InsertOne(document);

            //Close Window
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

            /*
            //Take off initial login

            //Make a connection with DB for Login collection
            var collection2 = DB.GetCollection<BsonDocument>("Login");

            string param = "{$set: { 'Initial_Login' : '0' } }";
            string filter2 = "{ '_id' : " + Student1.ID + " }";

            BsonDocument filterDoc = BsonDocument.Parse(filter2);
            BsonDocument document2 = BsonDocument.Parse(param);
            collection2.UpdateOne(filterDoc, document);*/
        }
    }
}