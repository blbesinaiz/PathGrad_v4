using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Student
{
    public partial class PerfectPath : System.Web.UI.Page
    {
        //DEFAULTS
        public static string currentSemester = "Fall";
        public static int year = DateTime.Now.Year;
        public static int maxCH = 0;
        public static int yearCounter = 0;
        public static int semesterCounter = 0;
        public static List<Course> currentList = new List<Course>();
        public static List<Course> nextList = new List<Course>();
        public static List<List<string>> perfectList = new List<List<string>>();
        public static int index = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            restoreProfile();
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
        protected void Butt_Generate_Click(object sender, EventArgs e)
        {
            //Take in Max CH per semester
            maxCH = Convert.ToInt32(txt_maxCH.Text);

            //Generate perfect path
            Generate_Perfect();

            //Make visible expected graduation
            Label_Graduation.Visible = true;
            Txt_Graduation.Text = Student1.expectedGradutation;
            Txt_Graduation.Visible = true;
            ListBox_Path.Visible = true;
        }

        public string Generate_Perfect()
        {
            //Clear previous perfect paths
            if(yearCounter != 0)
            {
                currentSemester = "Fall";
                yearCounter = 0;
            }

            string pathString = "";
            //Get Student Input

            //Sort by Ascending Order
            Sort_By_Ascending();

            
            //Group and Print By Semester
            Group_By_Semester();

            //Save semester lists
            Student1.currentSemester = currentList;
            Student1.nextSemester = nextList;

            //Save Path Generation
            Update_Profile();

            return pathString;
        }

        public static void Sort_By_Ascending()
        {
            //Sort courses by numerical sequence (Lower sequence at top)
            Student1.courseList.Sort((s1, s2) => s1.num.CompareTo(s2.num));
        }

        public void Group_By_Semester()
        {
            //every console write needs to be saved to stream string
            int creditCounter = 0;
            
            //While all assigned = false
            while (checkAssigned() == false)
            {
                
                ListBox_Path.Items.Add(currentSemester + " " + year);
                ListBox_Path.Items.Add("--------------");

                //Save expected semester
                Student1.expectedGradutation = currentSemester + " " + year;

                foreach (var Course in Student1.courseList)
                {
                    //if ((Course.assigned == false) && (Constraints.Check_Constraints(Course) == true))
                    if (Course.assigned == false)
                    {
                        Section_Semester(Course);
                        Course.assigned = true;
                        creditCounter += Course.ch;
                    }

                    if (creditCounter + 3 > maxCH)
                        break;
                }

                //Console.WriteLine("Credit Total: {0}", creditCounter);
                //perfectList[index].Add("Credit Total: " + creditCounter);
                ListBox_Path.Items.Add("Credit Total: " + creditCounter);
                ListBox_Path.Items.Add(" ");
                ListBox_Path.Items.Add(" ");

                //Reset/Update Values
                creditCounter = 0;
                yearCounter++;
                semesterCounter++;
                index++;

                if (currentSemester == "Fall")
                    currentSemester = "Spring";
                else if (currentSemester == "Spring")
                    currentSemester = "Fall";

                if (yearCounter % 2 == 0)
                    year++;
            }
        }

        //Function Checks to see if course has been previously assigned
        public static bool checkAssigned()
        {
            bool allAssigned = false;

            foreach (var Course in Student1.courseList)
            {
                if (Course.assigned == false)
                {
                    allAssigned = false;
                    break;
                }
                else
                    allAssigned = true;
            }
            return allAssigned;
        }

        public void Section_Semester(Course c)
        {
            //If Course is offered in fall or any other semester
            if ((currentSemester == "Fall") && (c.offered == "FO" || c.offered == "FS" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {

                //perfectList[index].Add(c.charac + " " + c.num + c.ch);
                ListBox_Path.Items.Add(c.charac + " " + c.num + c.lab + "    " + c.ch);
                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }

            else if ((currentSemester == "Spring") && (c.offered == "SO" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {
                //perfectList[index].Add(c.charac + " " + c.num + c.ch);
                ListBox_Path.Items.Add(c.charac + " " + c.num + "    " + c.ch);
                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }

            //Add to current or next semester list
            if (semesterCounter == 0)
            {
                currentList.Add(c);
            }
            else if(semesterCounter == 1)
            {
                nextList.Add(c);
            }
        }

        public static void Update_Profile()
        {
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

            //Erase original Profile
            //Create filter to search through DB
            var filter = new BsonDocument
            {
                {"_id", Student1.ID},
            };

            //Search for desired elements
            //If specified user found then add to list
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                //deleting single record
                var Deleteone = collection.DeleteOneAsync(
                                Builders<BsonDocument>.Filter.Eq("_id", Student1.ID));
            }

            //Reinsert new profile
            collection.InsertOne(document);
        }
    }
}