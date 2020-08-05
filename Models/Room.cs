using DayCare.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class Room
    {
        private static int x = 1;
        private string id{ get; set; }

        private static Dictionary<string, HashSet<Room>> rooms = null;
        public HashSet<Person> teachers { get; set; }
        public int maxGroups { get; set; }


        
        public Room()
        {

            id = "" + x++ + "A";
            teachers = new HashSet<Person>();            
        }


        public override string ToString()
        {
            return $"Room number = {id}";
        }

        public static Room getRoom(int studentAgeInMonths, Person tc)
        {
            DayCare daycare = DayCare.getInstance();
            Teacher t = (Teacher)tc;
            String group = GroupByAge.findGroup(studentAgeInMonths);

            HashSet<Room> RoomsInCurrGroup;
            daycare.rooms.TryGetValue(group, out RoomsInCurrGroup);

            foreach (Room room in RoomsInCurrGroup)
            {
                if (room.teachers.Count < room.maxGroups)
                {
                    room.teachers.Add(t);
                    return room;
                }

            }

            Room newRoom = new Room();
            GroupByAge value;
            daycare.groups.TryGetValue(group, out value);
            newRoom.maxGroups = value.maxGroupsInRoom;
            newRoom.teachers.Add(t);
            RoomsInCurrGroup.Add(newRoom);
            
            return newRoom;
        }

        public static Dictionary<string, HashSet<Room>> initializeRooms()
        {
            //if (DayCare.getInstance().rooms != null)
            //{
            //    return DayCare.getInstance().rooms;
            //}

            List<string> rules_data = RulesDAO.readFile();
            Dictionary<string, HashSet<Room>> temp = new Dictionary<string, HashSet<Room>>();

            for (int i = 1; i < rules_data.Count; i++) 
            {
                string[] line = rules_data[i].Split(",");
                temp.Add(line[0], new HashSet<Room>());
            }
            rooms = temp;
            return rooms;
        }


    }
}
