using MongoDB.Bson;
using Newtonsoft.Json;
using PathGrad_v4_web_.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathGrad_v4_web_.Logic.Database
{

    public class db
    {
        //Function replicates student object as temp object TO send to database
        public void Replicate_toDB(tempStudent t)
        {
            //Create a duplicate of student object
            //tempStudent temp = new tempStudent();

            t.tempID = Student1.ID;
            t.tempName = Student1.name;
            t.tempEmail = Student1.email;
            t.tempInitial_Login = Student1.Initial_Login;
            t.tempTrack = Student1.track;
            t.tempAdvisor = Student1.advisor;

            t.tempCourseList = Student1.courseList;
            t.tempTakenCourses = Student1.takenCourses;
            t.tempCurrentSemester = Student1.currentSemester;
            t.tempNextSemester = Student1.nextSemester;

            t.GPA = Student1.GPA;
            t.chCompleted = Student1.chCompleted;
            t.chRemaining = Student1.chRemaining;
            t.ranking = Student1.ranking;
            t.expectedGradutation = Student1.expectedGradutation;

            //Passed in object should have values now
        }

        //Function replicates student object as temp object FROM database
        public void Replicate_fromDB()
        {

        }

    }
}