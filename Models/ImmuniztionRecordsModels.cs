using System;
using System.Collections.Generic;
using System.IO;

namespace DayCare.Models
{
    public class ImmunizationRecordModels
    {
        static string path = @"./studentImmune.csv";

        List<ImmunizationModel> Lmi;
        List<Student> smi;
        public ImmunizationRecordModels()
        {
            Immunization im = new Immunization();
             Lmi = im.L_IM;
            smi = im.std;
            Student_records();
        }
        //write the studentdata
        public void Student_records()
        {
            foreach(Student item in smi)
            {
                ImmunizationModel mn = checking(item.age);
                try
                {


                    if (!(mn.Equals(null)))
                    {

                        if (!File.Exists(path))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.Write(item.id + ",");
                                sw.Write(item.firstName + ",");
                                sw.Write(item.lastName + ",");
                                sw.Write(item.age + ",");
                                sw.Write(item.email + ",");
                                sw.Write(item.date_of_birth + ",");

                                sw.WriteLine("Vaccination" + mn.vaccination);

                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.Write(item.id + ",");
                                sw.Write(item.firstName + ",");
                                sw.Write(item.lastName + ",");
                                sw.Write(item.age + ",");
                                sw.Write(item.email + ",");
                                sw.Write(item.date_of_birth + ",");
                                sw.WriteLine(mn.vaccination);


                            }
                        }

                    }
                    

                }
                catch (NullReferenceException e)
                {
                    
                }
             }
            ImmunizationReminder imr = new ImmunizationReminder();
        }
        //checking with the im record
        public ImmunizationModel checking(int S_age)
        {
            foreach(var immune in Lmi)
            {
                if (S_age<= immune.age)
                {
                    return immune;
                }
            }
            return null;
        }

    }
}
