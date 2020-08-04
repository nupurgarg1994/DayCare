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
        //private int maxRooms { get; set; }

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
            if(groups == null)
            {
                groups = new Dictionary<string, GroupByAge>();
                groups.Add("6-12", new GroupByAge("6-12"));
                groups.Add("13-24", new GroupByAge("13-24"));
                groups.Add("25-35", new GroupByAge("25-35"));
                groups.Add("36-47", new GroupByAge("36-47"));
                groups.Add("48-59", new GroupByAge("48-59"));
                groups.Add("60-2147483647", new GroupByAge("60-"));
                groups.Add("availableResources", new GroupByAge("availableResources"));
            }
            return groups;
        }
    }
}
