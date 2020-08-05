﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using DayCare.DAO;
using static System.Net.Mime.MediaTypeNames;

namespace DayCare.Models
{
   
    public class Immunization
    {   
        List<string> imuneDetails = ImmunizationDAO.readFile();
        List<string> stu_Details = StudentDAO.readFile();
        ImmunizationModel im ;
        public List<ImmunizationModel> L_IM = new List<ImmunizationModel>();
        public HashSet<Person> std = DayCare.getInstance().students;
          public  Immunization()
            {
                read_I_Details();
            }

       public void read_I_Details()
        {
            foreach(var imd in imuneDetails)
            {
                string[] I_details = imd.Split(",");
                im = new ImmunizationModel();
                im.age = Convert.ToInt32(I_details[0]);
                im.vaccination = I_details[1];
                L_IM.Add(im);

            }
            foreach(var stu in stu_Details)
            {
                string[] s_details = stu.Split(",");
                Student st = (Student)Factory.Get("STUDENT");
                st.age = Convert.ToInt32(s_details[3]);
                st.date_of_birth = Convert.ToDateTime(s_details[6]);
                st.firstName = s_details[1];
                st.lastName = s_details[2];
                st.email = s_details[4];
                std.Add(st);

                
            }
        }

       
      


    }

     

      


    
}
