using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorsDetails
{
    public class Professor
    {
        public string name { get; set; }

        public int profId { get; set; }

        public string subject { get; set; }

        public string email { get; set; }


        public void showDetails()
        {
            Console.WriteLine("Name: " + name + " ID: " + profId + " Subject: " + subject + " Email: " + email);
        }
    }

}
