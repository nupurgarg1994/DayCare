using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCare.Models
{
    class Teacher : Person
    {
        private static int x = 500101;
        private int id { get; set; }
        public HashSet<Person> students { get; set; }
        public Room room { get; set; }

        public Teacher()
        {
            id = x++;
        }
        
        public Teacher(int id, int age, string fname, string lname)
        {
            this.id = x++;
            this.age = age;
            this.firstName = fname;
            this.lastName = lname;
        }

        public static Room assignRoom(Person stu, Person t)
        {
            try
            {
                Student student = (Student)stu;
                Teacher teacher = (Teacher)t;
                int studentAgeInMonths = ((DateTime.Now.Year - student.date_of_birth.Year) * 12) + DateTime.Now.Month - student.date_of_birth.Month;
                Room r = Room.getRoom(studentAgeInMonths, t);
                //teacher.room = r;
                return r;
            }
            catch (NullReferenceException e) {
                Console.WriteLine();
            }
            return null;
        }

        public override string ToString()
        {
            return $"# {id}";
        }

        

        public static Person assignTeacher(Student student)
        {
            DayCare daycare = DayCare.getInstance();
            int studentAgeInMonths = ((DateTime.Now.Year - student.date_of_birth.Year) * 12) + DateTime.Now.Month - student.date_of_birth.Month;

            HashSet<Person> groupTeachers = null;
            String group = GroupByAge.findGroup(studentAgeInMonths);
            GroupByAge value;

            if (daycare.groups.TryGetValue(group, out value)) {
                groupTeachers = value.teachers;
            }

            foreach (Person teacher in groupTeachers) {
                Teacher t = (Teacher)teacher;
                if (t.students.Count < value.groupSize)
                {
                    t.students.Add(student);
                    return t;
                }
               
            }

            HashSet<Person> availableTeachers = null;
            // if the teacher was not assigned
            if (daycare.groups.TryGetValue("availableResources", out GroupByAge res)) {
                availableTeachers = res.teachers;
            }
            foreach (Person teacher in availableTeachers)
            {
                availableTeachers.Remove(teacher);
                groupTeachers.Add(teacher);
                Teacher t = (Teacher)teacher;
                t.students.Add(student);               
                return t;
            }

            return null;

        }
    }
}
