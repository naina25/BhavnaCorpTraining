using System;
using System.Data.SqlClient;
using System.IO;

namespace TASK1
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection string (db connection) 
            SqlConnection con = new SqlConnection("server=localhost;database=Employee;integrated security=true");
            string isrepeat = "Y";
            employeeCls emp = new employeeCls();

            string empFile = @"C:\Bhavna training\BhavnaCorpTraining\DAY 28\TASK1\EmployeeDetails.txt";

            try
            {
                while (isrepeat.ToUpper() == "Y")
                { 
                    Console.WriteLine("Enter employee's id");
                    emp.emp_id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter employee's name");
                    emp.name = Console.ReadLine();

                    Console.WriteLine("Enter employee's department");
                    emp.department = Console.ReadLine();

                    Console.WriteLine("Enter employee's gender");
                    emp.gender = Console.ReadLine();

                    //insertion command creation
                    SqlCommand cmd = new SqlCommand("insert into emp_details values( " + emp.emp_id + "  , '" + emp.name + "' , ' " + emp.department + " ', ' " + emp.gender + " ')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Record Inserted Successfully in the database");

                    if (!File.Exists(empFile))
                    {
                        using (StreamWriter sw = File.CreateText(empFile))
                        {
                            sw.WriteLine($"Employee's Id = {emp.emp_id}, Employee's name = {emp.name}, Employee's department = {emp.department}, Employee's gender = {emp.gender}");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(empFile))
                        {
                            sw.WriteLine($"Employee's Id = {emp.emp_id}, Employee's name = {emp.name}, Employee's department = {emp.department}, Employee's gender = {emp.gender}");
                        }
                    }

                    //for reading the file--------------
                    using (StreamReader sr = File.OpenText(empFile))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    Console.WriteLine("Do you want to repeat? Y or N");
                    isrepeat =  Console.ReadLine();

                }
                Console.WriteLine("File Created Successfully!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
