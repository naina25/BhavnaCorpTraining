using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class studentsDetails
    {
        public string name { get; set; }

        public int stuid { get; set; }

        public string branch { get; set; }

        public string email { get; set; }


        public void showDetails()
        {
            Console.WriteLine("Name: " + name + " ID: " + stuid + " Branch: " + branch + " Email: " + email);
        }
    }
}
