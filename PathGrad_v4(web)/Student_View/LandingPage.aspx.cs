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
//using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PathGrad_v4_web_.Student_View
{
    public partial class LandingPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Possibly add a  query and return back to user if account setup or not
            if(Student1.ID == 0)
            {
                Student1.ID = 0451917;
                Student1.Initial_Login = 0;
            }
            if (Student1.Initial_Login == 1)
            {
                //Initialize Account
                initializeAccount();
            }
            else if (Student1.Initial_Login == 0)
            {
                //Restore Session
                //Retrieve data from database
               restoreSession();
                
            }
            //Reset values in form
            setFormValues();



        }

        public void initializeAccount()
        {
            //Open Initialize Account Popup Window
            string url = "Initialize.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=500,height=600,left=300,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

            //Decrease login counter
            Student1.Initial_Login--;
        }

        public static void restoreSession()
        {
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

        public void setFormValues()
        {
            txt_ID.Text = Student1.ID.ToString();
            txt_Email.Text = Student1.email;
            Txt_ExpectedGradauation.Text = Student1.expectedGradutation;

            DataGrid_CurrentPopulate();
            DataGrid_NextPopulate();
        }

        public void DataGrid_CurrentPopulate()
        {
            //Create data table object
            DataTable dtCurrent = new DataTable();

            //Add columns
            dtCurrent.Columns.Add("IsMarried", typeof(bool));
            dtCurrent.Columns.Add("Course Number", typeof(string));
            dtCurrent.Columns.Add("Course Name", typeof(string));
            dtCurrent.Columns.Add("Credit Hours", typeof(int));

           /* DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "CheckBox";
            GridView_Current.Columns.Add(dgvCmb);*/

            //Create row object
            DataRow row = dtCurrent.NewRow();

            //Loop through courses for CURRENT semester and add
            dtCurrent.Rows.Add(false, "CSC 101", "Computer Science Intro", 1);

            //Bind to database
            GridView_Current.DataSource = dtCurrent;
            GridView_Current.DataBind();
        }

        public void DataGrid_NextPopulate()
        {
            /*
            //Create data table object
            DataTable dt = new DataTable();

            //Add columns
            dt.Columns.Add("Course Number");
            dt.Columns.Add("Name");
            dt.Columns.Add("Credit Hours");

            //Create row object
            DataRow row = dt.NewRow();

            //fill rows
            //For loop that goes through NEXT semester list
            row["Course Number"] = "CSC 101";
            dt.Rows.Add(row);
            //dt.Rows.InsertAt(row, index);     //if you want a specific position

            //Bind to database
            GridView_Current.DataSource = dt;
            GridView_Current.DataBind();
            */
        }

        protected void Butt_Perfect_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfectPath.aspx");
        }
    }
}