using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathGrad_v4_web_.Logic.Models
{
    public class Student1
    {
        public static int ID;
        public static string name;
        public static string email;
        public static string track;
        public static List<Course> courseList;
        public static List<Course> takenCourses;
    }

    public class tempStudent
    {
        public int tempID;
        public string tempName;
        public string tempTrack;
        public List<Course> tempCourses;
        public List<Course> tempTaken;

    }
}