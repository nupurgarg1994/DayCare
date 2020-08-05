using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.DAO
{
    public class RulesDAO
    {
        public static List<string> readFile()
        {
            string path = @".\Rules.csv";
            List<string> rules_data = new List<string>();

            if (File.Exists(path))
            {

                using (System.IO.StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        rules_data.Add(s);
                    }
                }
            }
            return rules_data;
        }
    }
}
