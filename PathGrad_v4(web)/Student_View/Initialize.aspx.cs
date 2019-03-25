using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
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
            if(!IsPostBack)
            {
                Initialize_MultiView.ActiveViewIndex = 0; 
            }
        }

        protected void Step2_Click(object sender, EventArgs e)
        {
            //Setup Student track
            Student1.track = TrackList.Text;
            loadTrack(Student1.track);
            Initialize_MultiView.ActiveViewIndex = 1;

        }

        public static void loadTrack(string track)
        {
            string path;        //Variable will hold path

            //Find file
            path = "~/Tracks/";
            path = path + track + ".csv";

            try
            {
                // List<Course> values = File.ReadAllLines(path)
                Student1.courseList = File.ReadAllLines(path)
                                        .Skip(1)
                                        .Select(v => Course.FromCsv(v))
                                        .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }

        protected void PreviousList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempCourse;
            foreach (var Course in Student1.courseList)
            {
                tempCourse = Course.charac + Course.num + Course.lab;
                PreviousList.Items.Add(tempCourse);
            }
            
        }

        protected void Step3_Click(object sender, EventArgs e)
        {
            Initialize_MultiView.ActiveViewIndex = 2;
        }
    }
}