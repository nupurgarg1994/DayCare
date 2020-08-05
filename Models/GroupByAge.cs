using DayCare.DAO;
using DayCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class GroupByAge
    {
        private string groupId;

        private static Dictionary<string, GroupByAge> groups;

        public HashSet<Person> teachers { get; set; }
        public int groupSize { get; set; }
        public int maxGroupsInRoom { get; set; }

        private GroupByAge(string gName)
        {
            this.groupId = gName;
            teachers = new HashSet<Person>();
        }

        public static string findGroup(int months)
        {
            foreach (string group in groups.Keys)
            {
                int start = -1;
                int end = -1;
                string[] range = group.Split("-");
                try
                {
                    start = Int32.Parse(range[0]); 
                    end = Int32.Parse(range[1]); 
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{range}'");
                }
                
                if(months >= start && months <= end)
                {
                    return group;
                }
            }
            return null;
        }

        public static Dictionary<string, GroupByAge> initializeGroups()
        {

            //if(DayCare.getInstance().groups != null)
            //{
            //    return DayCare.getInstance().groups;
            //}

            List<string> rules_data = RulesDAO.readFile();
            Dictionary<string, GroupByAge> temp = new Dictionary<string, GroupByAge>();

            for (int i = 1; i < rules_data.Count; i++) // Loop through List with for
            {
                string[] line = rules_data[i].Split(",");
                GroupByAge t = new GroupByAge(line[0]);
                t.groupSize = Convert.ToInt32(line[1]);
                t.maxGroupsInRoom = Convert.ToInt32(line[3]);
                temp.Add(line[0], t);
            }
            temp.Add("availableResources", new GroupByAge("availableResources"));
            groups = temp;
            return groups;
      
        }
    }
}
