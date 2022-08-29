using System;
using System.Collections.Generic;
using Doctors;
using Patients;
using Beds;

namespace Assesment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string isrepeat = "Y";    //for repeating the process again and again
            int choice;

            List<DoctorsClass> doctorList = new List<DoctorsClass> { };
            List<Patientscls> patientList = new List<Patientscls> { };
            List<Bedscls> bedsList = new List<Bedscls> { };

            while (isrepeat =="Y" || isrepeat == "y")
            {
                Console.WriteLine("Enter 1 for regeistering doctors, 2 for registering patients, 3 for booking bed for patient");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    //case 1 for doctor registeration
                    case 1:
                        DoctorsClass docobj = new DoctorsClass();  //created doctor's class object

                        Console.WriteLine("Please enter the following mentioned details in sequence: ID, NAME, PHONE, AGE, HIGHEST QUALIFICATION, SALARY, EMAIL");

                        //taking input from user for doctor registeration
                        docobj.id = int.Parse(Console.ReadLine());
                        docobj.name = Console.ReadLine();
                        docobj.phone = Console.ReadLine();
                        docobj.age = int.Parse(Console.ReadLine());
                        docobj.highest_degree = Console.ReadLine();
                        docobj.salaryInfo = int.Parse(Console.ReadLine());
                        docobj.reg_email = Console.ReadLine();

                        doctorList.Add(docobj);

                        foreach (DoctorsClass doctor in doctorList)
                        {
                            Console.WriteLine("Your Entered information is: " + doctor.id + "/" + doctor.name + "/" + doctor.phone + "/" + doctor.age + "/" + doctor.highest_degree + "/" + doctor.salaryInfo + "/" + doctor.reg_email);
                        }
                        break;

                    //case 2 for patients registeration
                    case 2:
                        Patientscls patobj = new Patientscls();

                        Console.WriteLine("Please enter the following mentioned details in sequence: id, name, phone, age, isVaccinated, address, patient_department");

                        patobj.id = int.Parse(Console.ReadLine());
                        patobj.name = Console.ReadLine();
                        patobj.phone = Console.ReadLine();
                        patobj.age = int.Parse(Console.ReadLine());
                        patobj.isVaccinated = Console.ReadLine();
                        patobj.getAddress = Console.ReadLine();
                        patobj.patientDepartment = Console.ReadLine();

                        patientList.Add(patobj);
                        foreach (Patientscls patient in patientList)
                        {
                            Console.WriteLine("Your Entered information is: " + patient.id + "/" + patient.name + "/" + patient.phone + "/" + patient.age + "/" + patient.isVaccinated + "/" + patient.getAddress + "/" + patient.patientDepartment);
                        }
                        break;

                        //case 3 for beds
                    case 3:
                        Bedscls bedsObj = new Bedscls();

                        Console.WriteLine("Please enter the following mentioned details in sequence: ward name, bed number, patient id");
                        bedsObj.ward_name = Console.ReadLine();
                        bedsObj.bed_number = int.Parse(Console.ReadLine());
                        bedsObj.patient_id = int.Parse(Console.ReadLine());

                        bedsList.Add(bedsObj);
                        foreach (Bedscls bed in bedsList)
                        {
                            Console.WriteLine("Your Entered information is: " + bed.ward_name  + "/" + bed.bed_number + "/" + bed.patient_id);
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }

                Console.WriteLine("Do you want to repeat the process again? Y or N");
                isrepeat = Console.ReadLine();

            }
        }
    }
}
