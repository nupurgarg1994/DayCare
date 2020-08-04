using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public static class Factory
    {
        public static Person Get(string type)
        {
            switch (type)
            {
                case "STUDENT": return new Student();
                case "TEACHER": return new Teacher();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
