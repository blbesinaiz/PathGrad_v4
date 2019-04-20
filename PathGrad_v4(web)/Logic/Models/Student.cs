using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathGrad_v4_web_.Logic.Models
{
    public static class Student1
    {
        //Profile Information
        public static int ID { get; set; } = 0;
        public static string name { get; set; } = null;
        public static string email { get; set; } = null;
        public static int Initial_Login { get; set; } = 1;
        public static string track { get; set; } = null;
        public static string advisor { get; set; } = "Dr. Claude Turner";

        //List of classes
        public static List<Course> courseList;
        public static List<Course> takenCourses;
        public static List<Course> currentSemester { get; set; }
        public static List<Course> nextSemester { get; set; }

        //Calculations
        public static float GPA { get; set; } = 0;
        public static int chCompleted { get; set; } = 0;
        public static int chRemaining { get; set; } = 120;
        public static int completedPercentage { get; set; } = 0;
        public static string ranking { get; set; } = null;    //Freshman, Sophomore, Junior Senior
        public static string expectedGradutation { get; set; } = "TBD";
    }

    public class tempStudent
    {
        //Profile Information
        public int tempID { get; set; } 
        public string tempName { get; set; } = null;
        public string tempEmail { get; set; } = null;
        public int tempInitial_Login { get; set; }
        public string tempTrack { get; set; } = null;
        public string tempAdvisor { get; set; } = null;

        //List of classes
        public List<Course> tempCourseList;
        public List<Course> tempTakenCourses;
        public List<Course> tempCurrentSemester;
        public List<Course> tempNextSemester;

        //Calculations
        public float GPA { get; set; } = 0;
        public int chCompleted { get; set; } = 0;
        public int chRemaining { get; set; } = 120;
        public int completedPercentage { get; set; } = 0;
        public string ranking { get; set; } = null;    //Freshman, Sophomore, Junior Senior
        public string expectedGradutation { get; set; } = "TBD";

    }
}