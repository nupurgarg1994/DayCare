using System;
using System.Collections.Generic;
using System.IO;
using DayCare.Models;
namespace DayCare.DAO
{
    public class StudentDAO
    {
        public StudentDAO()
        {
        }
        public static List<string> s_readData { get; set; }

        static string path = @".\student.csv";

        public static List<string> readFile()
        {
           s_readData = new List<string>();
            if (File.Exists(path))
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    string s;

                    while ((s = sr.ReadLine()) != null)
                    {
                        s_readData.Add(s);

                    }
                }
            }
            return s_readData;
        }
    }
}
