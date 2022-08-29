using System;
using System.Collections.Generic;
using System.Text;
using CommonCls;

namespace Doctors
{
    public class DoctorsClass:Commoncls
    {
        //public private and protected variables 
        public string highest_degree;
        private int salary;
        protected string registered_email;

        //Accessing protected variable using get/set 
        public string reg_email
        {
            get
            {
                return registered_email;
            }
            set
            {
                registered_email = value;
            }
        }

        //Accessing private variable using get/set
        public int salaryInfo
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
    }
}
