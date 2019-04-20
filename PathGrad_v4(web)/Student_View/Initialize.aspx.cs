using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Database;
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
        //Response.Redirect(Request.RawUrl)
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_curriculum.Text = Student1.track;

            //Needed as won't load otherwise!
            loadTrack("BS.CSC.IA");
            if(!IsPostBack)
            {
                Initialize_MultiView.ActiveViewIndex = 0; 
            }
            
        }
        protected void Butt_Next1_Click(object sender, EventArgs e)
        {
            //Switch to Track View
            Initialize_MultiView.ActiveViewIndex = 1;
        }
        protected void Step2_Click(object sender, EventArgs e)
        {
            //Setup Student track
            Student1.track = TrackList.Text;
            loadTrack(Student1.track);

            //Create previous classes taken gridview
            Bind_CheckList();

            //Switch to Previous Classes taken view
            Initialize_MultiView.ActiveViewIndex = 2;

        }
        protected void Step3_Click(object sender, EventArgs e)
        {
            //Collect checked boxes

            /*//Not setting selected classes to TRUE!!!
            for (int i = 0; i < PreviousList.Items.Count; i++)
            {
                if (PreviousList.Items[i].Selected == true)// getting selected value from CheckBox List  
                {

                    previousClasses += PreviousList.Items[i].Text + " ," + "\n"; // add selected Item text to the String 
                    //Find in student course list and set assigned to true
                    foreach(var Course in Student1.courseList)
                    {
                        if (PreviousList.Items[i].Text == (Course.charac + " " + Course.num + Course.lab))
                            Course.assigned = true;
                    }
                }
            }*/

            //Response.Redirect(Request.RawUrl);
            Initialize_MultiView.ActiveViewIndex = 3;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            //Make calculations and Assignments
            calculations();
            //Save to Database
            saveInitialDB();

            //Close Window
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
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

            Student1.courseList = temp.tempCourseList;
        }

        protected void Bind_CheckList() // Method for Binding The Checkbox List  
        {
            string tempCourse;
            List<string> listContents = new List<string>();// Create a List of String Elements 
            foreach (var Course in Student1.courseList)
            {
                tempCourse = Course.charac + " " + Course.num + Course.lab;
                listContents.Add(tempCourse);

                PreviousList.DataSource = listContents;//Set Datasource to CheckBox List  
                PreviousList.DataBind(); // Bind the checkboxList with String List.  
            }
        }

        public static void calculations()
        {
            //Have to come back and make calculations

            //Calculate CH Completed
            foreach (var Course in Student1.courseList)
            {
                if (Course.completed == true)
                {
                    Student1.chCompleted += Course.ch;
                }
            }

            //Calcualte Remamining
            Student1.chRemaining = 120 - Student1.chCompleted;

            //Calculate Percentage completed
            Student1.completedPercentage = (Student1.chCompleted / 120) * 100;

            //Compute Ranking
            //Determine Status
            if (Student1.chCompleted >= 0 && Student1.chCompleted < 29)
                Student1.ranking = "Freshman";
            else if (Student1.chCompleted > 29 && Student1.chCompleted < 59)
                Student1.ranking = "Sophomore";
            else if (Student1.chCompleted > 59 && Student1.chCompleted < 89)
                Student1.ranking = "Junior";
            else if (Student1.chCompleted > 89)
                Student1.ranking = "Senior";
        }

        public void saveInitialDB()
        {

            //Decrease number of logins
            Student1.Initial_Login--;

            tempStudent temp = new tempStudent();

            //Pass temp object to replicate function
            //db.Replicate_toDB(t);

            temp.tempID = Student1.ID;
            temp.tempName = Student1.name;
            temp.tempEmail = Student1.email;
            temp.tempInitial_Login = Student1.Initial_Login;
            temp.tempTrack = Student1.track;
            temp.tempAdvisor = Student1.advisor;

            temp.tempCourseList = Student1.courseList;
            temp.tempTakenCourses = Student1.takenCourses;
            temp.tempCurrentSemester = Student1.currentSemester;
            temp.tempNextSemester = Student1.nextSemester;

            temp.GPA = Student1.GPA;
            temp.chCompleted = Student1.chCompleted;
            temp.chRemaining = Student1.chRemaining;
            temp.completedPercentage = Student1.completedPercentage;
            temp.ranking = Student1.ranking;
            temp.expectedGradutation = Student1.expectedGradutation;

            //Serialize Object (JSON.NET method)
            string jsonData = JsonConvert.SerializeObject(temp);

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", Student1.ID},
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
        }

        protected void PreviousList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadTrack(TrackList.Text);
        }
    }
}