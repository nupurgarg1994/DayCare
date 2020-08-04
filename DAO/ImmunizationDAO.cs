using System;
using System.Collections.Generic;
using System.IO;

namespace DayCare.DAO
{
    public class ImmunizationDAO
    {
       public static List<string> readData { get; set; }
        public ImmunizationDAO()
        {
           
        }

        static string path = @".\Immunization.csv";
       
        public static List<string> readFile()
        {
          readData  = new List<string>();
            if (File.Exists(path))
            {

                using (StreamReader sr = File.OpenText(path))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    readData.Add(s);
                    
                }
            }
                
        }
            return readData;
        }

    }
}

