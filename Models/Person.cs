using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }

        public int phone { get; set; }
        public string email { get; set; }

        public string password { get; set; }
        public DateTime date_of_birth { get; set; }

    }
}
