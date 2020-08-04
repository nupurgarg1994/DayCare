using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class Student : Person
    {
        public static  int x = 200101;
        public static int id { get { return x; } set { id = x++; } }
        public string parent;
        public DateTime date_of_joining { get; set; } = DateTime.Today;
        

        public Student() { 
        }


        public override string ToString()
        {
            return $"{firstName},{lastName}";
        }
    }
}
