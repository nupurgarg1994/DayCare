using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DayCare.Models
{
    public class DayCare
    {
        private static DayCare dayCare;
        public HashSet<Person> students { get; set; }
        public HashSet<Person> teachers { get; set; }
        public Dictionary<string, HashSet<Room>> rooms { get; set; }

        public Dictionary<string, GroupByAge> groups { get; set; }

        private DayCare()
        {
            students = new HashSet<Person>();
            teachers = new HashSet<Person>();
            groups = GroupByAge.initializeGroups();
            rooms = Room.initializeRooms();

        }

        public static DayCare getInstance()
        {
           
            if (dayCare == null)
            {
                dayCare = new DayCare();
            }

            return dayCare;
        }
    }


}
