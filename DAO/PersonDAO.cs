using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DayCare.Models;


namespace DayCare.DAO
{
    public class PersonDAO
    {
       
       
         
       static string path = @".\student.csv";
        public static void save(Person p)
        {
          
            Type t = p.GetType();
            if (t.Equals(typeof(Student))){
                PersonDAO.saveStudent(p);
            }
           else if(t.Equals(typeof(Teacher)))

            {
                saveTeacher(p);
            }
        }

        private static void saveTeacher(Person p)
        {
            

        }

        private static void saveStudent(Person p)

        {
            Student s = (Student)p;

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.Write(s.id+ ",");
                    sw.Write(p.firstName + ",");
                    sw.Write(p.lastName + ",");
                    sw.Write(p.age + ",");
                    sw.Write(p.email + ",");
                    sw.Write(p.phone + ",");
                    sw.Write(p.date_of_birth + ",");
                    sw.WriteLine(s.date_of_joining + ",");


                }
            }
             else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(s.id + ",");
                    sw.Write(p.firstName + ",");
                    sw.Write(p.lastName + ",");
                    sw.Write(p.age + ",");
                    sw.Write(p.email + ",");
                    sw.Write(p.phone + ",");
   
                    sw.Write(p.date_of_birth + ",");
                    sw.WriteLine(s.date_of_joining + ",");


                }
            }
            ImmunizationRecordModels irm = new ImmunizationRecordModels();


        }
    }
    }

