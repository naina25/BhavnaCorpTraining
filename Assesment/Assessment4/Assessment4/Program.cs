using CarManufacturing;
using CommonCls;
using Employee;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Assessment4
{
    class Program
    { 
        static void Main(string[] args)
        {
            //db connection string-----------------
            SqlConnection con = new SqlConnection("server=localhost;database=CarManufacturingUnit;integrated security=true");

            string isrepeat = "Y";
            int choice;

            //objects------------------------------
            employee emp = new employee();
            manufacturingCost costObj = new manufacturingCost();
            commonCls com = new commonCls();

            //dataset------------------------------
            DataSet ds = new DataSet();
           
            //file path----------------------------
            string salaryRecord = @"C:\Bhavna training\BhavnaCorpTraining\Assesment\Assessment4\salaryRecord.txt";

            if (File.Exists(salaryRecord))
                File.Delete(salaryRecord);

            //exception handeling------------------
            try
            {
                while (isrepeat.ToUpper() == "Y")
                {
                    Console.WriteLine("Press 1 to distribute the salaries of employees\nPress 2 to see the salary distribution of the current month\nPress 3 to calculate the total cost of car repairing as well as maintaining the stocks\nPress 4 to calculate the total cost of car manufacturing");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        //this is for distributing the salary to a particular employee using its id----------------------------
                        case 1:
                            Console.WriteLine("Enter the id of an employee to whom you want to distribute the salary");
                            emp.id = int.Parse(Console.ReadLine());

                            //Extrating the required fields from department, employee and totalworkinghrs table from db using inner join---------- 
                            SqlDataAdapter data = new SqlDataAdapter("select hrs.*, e.employeeName , e.deptId, d.salaryPerHour " +
                                "from employeeWorkingHrs hrs inner join employee e " +
                                "on hrs.empId = e.empId " +
                                "inner join departmenrt d " +
                                "on d.departmentId = e.deptId", con);

                            if (ds.Tables.CanRemove(ds.Tables["employeeDetails"]))
                                ds.Tables.Remove(ds.Tables["employeeDetails"]);

                            data.Fill(ds, "employeeDetails");
                            
                            int num = ds.Tables["employeeDetails"].Rows.Count;

                            //taking the minimum working hrs in a month to be 184-------------------
                            emp.minWorkingHrs = 184;

                            for (int j = 0; j < num; j++)
                            {
                                if (emp.id.ToString() == ds.Tables["employeeDetails"].Rows[j][0].ToString())
                                {
                                    emp.totalSalary = 0;
                                    int totalworkinghrs = int.Parse(ds.Tables["employeeDetails"].Rows[j][1].ToString());
                                    int salaryPerHour = int.Parse(ds.Tables["employeeDetails"].Rows[j][4].ToString());

                                    //calculating the total salary of an employee----------------------------
                                    emp.totalSalary = totalworkinghrs > emp.minWorkingHrs ?
                                        (totalworkinghrs - emp.minWorkingHrs) * 2 * salaryPerHour + emp.minWorkingHrs * salaryPerHour :
                                        emp.minWorkingHrs * salaryPerHour;
                                    
                                    //writing to the salary record file--------------------------------------
                                    if (!File.Exists(salaryRecord))
                                        using (StreamWriter sw = File.CreateText(salaryRecord))
                                        {
                                            sw.WriteLine($"Employee Id: {ds.Tables["employeeDetails"].Rows[j][0].ToString()}, " +
                                                $"Employee Name: {ds.Tables["employeeDetails"].Rows[j][2].ToString()}, " +
                                                $"Employee's Salary of the Month: {emp.totalSalary} ");
                                        }
                                    else
                                        using (StreamWriter sw = File.AppendText(salaryRecord))
                                        {
                                            sw.WriteLine($"Employee Id: {ds.Tables["employeeDetails"].Rows[j][0].ToString()}, " +
                                                 $"Employee Name: {ds.Tables["employeeDetails"].Rows[j][2].ToString()}, " +
                                                 $"Employee's Salary of the Month: {emp.totalSalary} ");
                                        }
                                }
                            }

                            //action delegate to print message--------------------
                            Action<string> message = com.printMessage;
                            message("\nSalary distributed successfully!!\n");
                            break;

                        //Reading the salary records file (admin can see the salary records from here)--------
                        case 2:
                            if (!File.Exists(salaryRecord)){
                                Action<string> msg = com.printMessage;
                                msg("\nFile doesn't exist\n");
                            }
                            else
                            {
                                Console.WriteLine("\nHere are the existing salary records: \n");
                                using (StreamReader sr = File.OpenText(salaryRecord))
                                {
                                    string s = "";
                                     while ((s = sr.ReadLine()) != null)
                                     {
                                         Console.WriteLine(s);
                                     }
                                }
                            }
                            break;

                        //car repairing cost calculation
                        case 3:
                            Console.WriteLine("\nEnter the number of parts which are needed to be replaced");
                            int partsCount = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nEnter the names of parts which are needed to be replaced");

                            //array list to store the parts which are needed to be replaced
                            ArrayList partsList = new ArrayList();
                            
                            string part;

                            while (partsCount > 0)
                            {
                                part = Console.ReadLine();
                                partsList.Add(part);
                                partsCount--;
                            }

                            SqlDataAdapter dataadap = new SqlDataAdapter("select * from Products", con);
                            dataadap.Fill(ds, "parts");

                            int count = ds.Tables["parts"].Rows.Count;
                            int price = 0;
                            int id;

                            foreach (string item in partsList)
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    if (ds.Tables["parts"].Rows[i][1].ToString() == item)
                                    {
                                        //calculation of repairing cost-------------------------
                                        price = int.Parse(ds.Tables["parts"].Rows[i][2].ToString());
                                        costObj.totalPartsCost += price;

                                        //grabbing id of the part which is to be replaced in order to maintain the stocks
                                        id = int.Parse(ds.Tables["parts"].Rows[i][0].ToString());
                                        SqlCommand cmd = new SqlCommand("update stocks set quanity -=1 where productId = " + id + "", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                            }

                            //action delegate to display total repairing cost--------------------
                            Action<int> val = costObj.repairingCost;
                            val(costObj.totalPartsCost);
                            
                            Console.WriteLine("\nStocks updated successfully in the database!!\n");
                            break;

                        //calculating the car manufaturing cost-----------------------------------
                        case 4:
                            SqlDataAdapter da = new SqlDataAdapter("select * from Products", con); 
                            da.Fill(ds, "carParts"); 

                            int rowscount = ds.Tables["carParts"].Rows.Count;
                           
                            for (int i = 0; i < rowscount; i++)
                            {
                               if (ds.Tables["carParts"].Rows[i][1].ToString() == "tyre" ||
                               ds.Tables["carParts"].Rows[i][1].ToString() == "door" ||
                               ds.Tables["carParts"].Rows[i][1].ToString() == "window glass")
                                {
                                    costObj.totalManufactureCost += 4 * (int)ds.Tables["carParts"].Rows[i][2];
                                }
                                else if (ds.Tables["carParts"].Rows[i][1].ToString() == "Bumper")
                                {
                                    costObj.totalManufactureCost += 2 * (int)ds.Tables["carParts"].Rows[i][2];
                                }
                                else
                                {
                                    costObj.totalManufactureCost += (int)ds.Tables["carParts"].Rows[i][2];
                                }

                               //func delegate to calculate the total manpower cost - it will add manpower cost per part everytime to calculate totalManpowerCost
                                int manpowerCostPerPart = 1500;

                                Func<int,int> cost = costObj.ManpowerCostCal;
                                costObj.totalManpowerCost = cost(manpowerCostPerPart);
                            }
                            Console.WriteLine("\nTotal Cost to manufacture a car: " + (costObj.totalManufactureCost + costObj.totalManpowerCost));
                            break;

                        default:
                            Action<string> invalidOpt = com.printMessage;
                            invalidOpt("\nInvalid option!\n");
                            break;
                    }

                    //action delegate to print message----------------------
                    Action<string> repeatMsg = com.printMessage;
                    repeatMsg("\nDo you want to repeat the process? Y or N\n");
                    isrepeat = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
        }
    }
}
