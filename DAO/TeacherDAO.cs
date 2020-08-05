using DayCare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.DAO
{
    public class TeacherDAO
    {

        public static void readFile()
        {
            string path = @".\teachers.csv";
            List<string> teacher_readData = new List<string>();

            if (File.Exists(path))
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        teacher_readData.Add(s);
                    }
                }
            }

            GroupByAge res;
            DayCare.Models.DayCare daycare = DayCare.Models.DayCare.getInstance();
            daycare.groups.TryGetValue("availableResources", out res);

            for (int i = 1; i < teacher_readData.Count; i++) // Loop through List with for
            {
                string[] line = teacher_readData[i].Split(",");
                Teacher t = (Teacher)Factory.Get("TEACHER");
                t.id = Convert.ToInt32(line[0]);
                t.firstName = line[1];
                t.lastName = line[2];
                t.age = Convert.ToInt32(line[3]);

                DayCare.Models.DayCare.getInstance().teachers.Add(t);
                res.teachers.Add(t);
            }

        }
    }
}
