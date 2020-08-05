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
            newRoom.teachers.Add(t);
            RoomsInCurrGroup.Add(newRoom);
            
            return newRoom;
        }

        public static Dictionary<string, HashSet<Room>> initializeRooms()
        {
            if (rooms == null)
            {
                rooms = new Dictionary<string, HashSet<Room>>();
                rooms.Add("6-12", new HashSet<Room>());
                rooms.Add("13-24", new HashSet<Room>());
                rooms.Add("25-35", new HashSet<Room>());
                rooms.Add("36-47", new HashSet<Room>());
                rooms.Add("48-59", new HashSet<Room>());
                rooms.Add("60-2147483647", new HashSet<Room>());

            }
            return rooms;
        }


    }
}
