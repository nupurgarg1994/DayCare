

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace DayCare.Models
{
    public class ImmunizationReminder
    {
        public ImmunizationReminder()
        {
            readFile();
        }

        //read the studentImmune file and take date of birth


        static string path = @"./studentImmune.csv";
        public String[] str;
        public DateTime date_of_birth;
        string receiver_email;
        int age;
        string vaccine;
        public void readFile()
        {

            if (File.Exists(path))
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    string s;

                    while ((s = sr.ReadLine()) != null)
                    {
                        str = s.Split(",");
                        receiver_email = str[4];
                        age = Convert.ToInt16(str[3]);
                        date_of_birth = Convert.ToDateTime(str[5]);
                        reminder(date_of_birth);
                    }
                }
            }

           
        }

        public void reminder(DateTime dob)
        {
            int years = DateTime.Today.Year - dob.Year;
            dob = dob.AddYears(years);
            DateTime check = DateTime.Today.AddMonths(1);
            try { 
            if (check >= dob && dob > DateTime.Today)
            {
                age++;
                using (MailMessage mm = new MailMessage("gargnupur740@gmail.com", receiver_email))
                {

                    // ImmunizationRecordModels imrm = new ImmunizationRecordModels();
                    // ImmunizationModel im = imrm.checking(age);
                    // vaccine = im.vaccination;

                    mm.Subject = "Immunization Remainder";
                    mm.Body = string.Format("It's time to give vaccine to your child  as your chilid is going to be {0}",age,"Please give the following vaccines.{0}", vaccine);

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                    credentials.UserName = "gargnupur740@gmail.com";
                    credentials.Password = "Nupur@0330";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credentials;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    //WriteToFile("Email sent successfully to: " + name + " " + email);
                }
            }
            
        }
    catch (Exception ex)
    {
                Console.WriteLine("ErrorEventArgs");
       
    }
}

            }
        }
    
