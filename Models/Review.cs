using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    public class Review
    {
        public string reviewID { get; set; }
        public string studentID {get; set;}
        public string studentName { get; set; }
        public string teacherID { get; set; }
        public string teacherName { get; set; }
        public DateTime date_of_review { get; set; }
        public string feedback { get; set; }
        public Review()
        {
            date_of_review = DateTime.Now;
        }


    }
}
