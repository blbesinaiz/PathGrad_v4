using MongoDB.Bson;
using MongoDB.Driver;
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
            string myPath;

            maxCH = Convert.ToInt32(txt_maxCH.Text);
            myPath = Generate_Perfect();
            myPath = myPath.Replace("\n", Environment.NewLine);
            txt_Path.Text = myPath;
        }

        public static string Generate_Perfect()
        {
            string pathString = "";
            //Get Student Input

            //Sort by Ascending Order
            Sort_By_Ascending();

            var originalConsoleOut = Console.Out; // preserve the original stream
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                //Group and Print By Semester
                Group_By_Semester();

                //Console.WriteLine("some stuff"); // or make your DLL calls :)

                writer.Flush(); // when you're done, make sure everything is written out

                pathString = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut); // restore Console.Out

          

            //Save Path Generation
            Save_Path();

            return pathString;
        }

        public static void Sort_By_Ascending()
        {
            //Sort courses by numerical sequence (Lower sequence at top)
            Student1.courseList.Sort((s1, s2) => s1.num.CompareTo(s2.num));
        }

        public static void Group_By_Semester()
        {


            //every console write needs to be saved to stream string
            int creditCounter = 0;

            //While all assigned = false
            while (checkAssigned() == false)
            {
                //Output Starting Semester
                Console.WriteLine("\n{0} {1}", currentSemester, year);
                Console.WriteLine("--------------");

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

                Console.WriteLine("Credit Total: {0}", creditCounter);

                //Reset/Update Values
                creditCounter = 0;
                yearCounter++;

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

        public static void Section_Semester(Course c)
        {
            //If Course is offered in fall or any other semester
            if ((currentSemester == "Fall") && (c.offered == "FO" || c.offered == "FS" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {
                if(semesterCounter == 1)

                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }

            else if ((currentSemester == "Spring") && (c.offered == "SO" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {
                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }
        }

        public static void Save_Path()
        {
            /*Console.WriteLine("Press any key");
            Console.ReadKey();
            var originalConsoleOut = Console.Out; // preserve the original stream

            string savedPath = originalConsoleOut.ToString();

            Console.WriteLine(originalConsoleOut);*/
        }
    }
}