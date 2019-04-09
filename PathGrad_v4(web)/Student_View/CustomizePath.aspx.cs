using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Student_View
{
    public partial class CustomizePath : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                restoreProfile();
                setupProfile();
                setupPreviousClasses();
            }
            
        }

        public void setupProfile()
        {
            Txt_name.Text = Student1.name;
            Txt_ID.Text = Student1.ID.ToString();

            //Determine Status
            if (Student1.chCompleted > 0 && Student1.chCompleted < 29)
                Student1.ranking = "Freshman";
            else if(Student1.chCompleted > 29 && Student1.chCompleted < 59)
                Student1.ranking = "Sophomore";
            else if (Student1.chCompleted > 59 && Student1.chCompleted < 89)
                Student1.ranking = "Junior";
            else if (Student1.chCompleted > 89)
                Student1.ranking = "Senior";

            Txt_classification.Text = Student1.ranking;
            Txt_graduation.Text = Student1.expectedGradutation;
            Txt_advisor.Text = Student1.advisor;
        }

        public void setupPreviousClasses()
        {
            //Create data table object
            DataTable dtCurrent = new DataTable();

            //Add columns
            dtCurrent.Columns.Add("Taken", typeof(bool));
            dtCurrent.Columns.Add("Course Number", typeof(string));
            dtCurrent.Columns.Add("Course Name", typeof(string));
            dtCurrent.Columns.Add("Credit Hours", typeof(int));

            //Create row object
            DataRow row = dtCurrent.NewRow();

            string courseName;
            //Loop through courses for CURRENT semester and add
            foreach(var Course in Student1.courseList)
            {
                //Add to row
                courseName = Course.num + Course.lab;
                dtCurrent.Rows.Add(false, courseName, Course.title, Course.ch);
                //Bind to Grid
                GridView_Previous.DataSource = dtCurrent;
                GridView_Previous.DataBind();
            }
            dtCurrent.Rows.Add(false, "CSC 101", "Computer Science Intro", 1);
            GridView_Previous.DataSource = dtCurrent;
            GridView_Previous.DataBind();
        }
        public void restoreProfile()
        {
            Student1.ID = 0451917;
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
            //Profile Information
            Student1.ID = temp.tempID;
            Student1.name = temp.tempName;
            Student1.email = temp.tempEmail;
            Student1.Initial_Login = temp.tempInitial_Login;
            Student1.track = temp.tempTrack;
            Student1.advisor = temp.tempAdvisor;

            //Course Lists
            Student1.courseList = temp.tempCourseList;
            Student1.takenCourses = temp.tempTakenCourses;
            Student1.currentSemester = temp.tempCurrentSemester;
            Student1.nextSemester = temp.tempNextSemester;

            //Calculations
            Student1.GPA = temp.GPA;
            Student1.chCompleted = temp.chCompleted;
            Student1.chRemaining = temp.chRemaining;
            Student1.ranking = temp.ranking;
            Student1.expectedGradutation = temp.expectedGradutation;
        }
    }
}