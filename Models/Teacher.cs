using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    class Teacher : Person
    {
        public static int x = 500101;
        public int id { get; set; }

        public Teacher()
        {

        }
        
        public Teacher(int id, int age, string fname, string lname)
        {
            this.id = x++;
            this.age = age;
            this.firstName = fname;
            this.lastName = lname;
        }

        public override string ToString()
        {
            return $"# {id}";
        }
    }
}
