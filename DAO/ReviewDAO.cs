using DayCare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.DAO
{
    public class ReviewDAO
    {
        public static void save(Review r)
        {
            string path = @".\reviews.csv";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    //adding titles
                    sw.Write("ReviewID,");
                    sw.Write("StudentID,");
                    sw.Write("StudentName,");
                    sw.Write("TeacherID,");
                    sw.Write("TeacherName,");
                    sw.Write("DateOfReview,");
                    sw.WriteLine("Feedback");

                    //adding values
                    sw.Write(r.reviewID + ",");
                    sw.Write(r.studentID + ",");
                    sw.Write(r.studentName + ",");
                    sw.Write(r.teacherID + ",");
                    sw.Write(r.teacherName + ",");
                    sw.Write(r.date_of_review + ",");
                    sw.WriteLine(r.feedback);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(r.reviewID + ",");
                    sw.Write(r.studentID + ",");
                    sw.Write(r.studentName + ",");
                    sw.Write(r.teacherID + ",");
                    sw.Write(r.teacherName + ",");
                    sw.Write(r.date_of_review + ",");
                    sw.WriteLine(r.feedback);
                }
            }

        }

    }
}
