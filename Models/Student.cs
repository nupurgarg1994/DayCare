using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class Student : Person
    {
        private static int x = 200101;
        private int id { get; set; }

        private string parent;
        public Person teacher { get; set; }
        public Room room { get; set; }
        public DateTime date_of_joining { get; set; } 

        public Student() {
            id = x++;
            date_of_joining = DateTime.Today;
            teacher = assignTeacher();
            room = assignRoom(teacher);           
        }

        public Person assignTeacher()
        {
            return Teacher.assignTeacher(this);           
        }

        public Room assignRoom(Person teacher)
        {
            return Teacher.assignRoom(this, teacher);
        }


        public override string ToString()
        {
            return $"{firstName},{lastName}";
        }
    }
}
