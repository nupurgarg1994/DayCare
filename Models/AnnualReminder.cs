

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
namespace DayCare.Models
{
    public class AnnualReminder
    {
        public AnnualReminder()
        {
            readFile();
        }

        //read the studentImmune file and take date of birth


        static string path = @"./student.csv";
        public String[] str;
        public DateTime date_of_joining;
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
                        date_of_joining = Convert.ToDateTime(str[6]);
                        reminder(date_of_joining);

                    }
                }
            }

        }

        public void reminder(DateTime doj)
        {
            int years = DateTime.Today.Year - doj.Year;
            doj = doj.AddYears(years);
            DateTime check = DateTime.Today.AddMonths(1);
            try
            {
                if (check >= doj && doj > DateTime.Today)
                {

                    using (MailMessage mm = new MailMessage("gargnupur740@gmail.com", receiver_email))
                    {

                        mm.Subject = "Annual fees Remainder";
                        mm.Body = string.Format("Hi ,<br> Thank you for being with us.If you want to continue with us please renew");

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