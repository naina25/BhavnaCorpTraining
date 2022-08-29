using System;
using System.Collections.Generic;
using System.Text;
using CommonCls;

namespace Patients
{
    public class Patientscls : Commoncls
    {
        public string isVaccinated;
        protected string address;
        protected string patient_department;
        public string getAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string patientDepartment
        {
            get
            {
                return patient_department;
            }
            set
            {
                patient_department = value;
            }
        } 
    }
}
