using System;
using System.Data;
using System.Data.SqlClient;
using franchise;
using Orders;
using Employee;

namespace Assessment3
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection string (db connection) 
            SqlConnection con = new SqlConnection("server=localhost;database=PizzaProjectDB;integrated security=true");
            Console.WriteLine("Enter the registered ID and Password for login");
            string loginID = Console.ReadLine();
            string password = Console.ReadLine(); 

            //creating a dataset and filling it with login details table for admin or franchise authentication
            SqlDataAdapter da = new SqlDataAdapter("select * from LoginDetails", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Login");
            int count = ds.Tables["Login"].Rows.Count;

            //object of common class for action delegate
            CommonCls obj = new CommonCls();
            franchiseCls franchiseObj = new franchiseCls();

            //try catch block for exception handeling
            try
            {
                //admin authentication
                if(loginID == ds.Tables["Login"].Rows[0][0].ToString())
                {
                    if (password == ds.Tables["Login"].Rows[0][1].ToString())
                    {
                        //action delegate for printing the message
                        Action<string> obj2 = new Action<string>(obj.showMsg);
                        obj2.Invoke("Admin successfully logged in!!");
                        Console.WriteLine();

                        // loop for process repeatition as per user's choice
                        string repeat = "Y";
                        while (repeat.ToUpper() == "Y")
                        {
                            Console.WriteLine("Enter 1 to register a franchise\nEnter 2 to get franchise details\nEnter 3 to get sales record date wise");

                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                //case 1 for registering a new franchise and adding it to the db
                                case 1:
                                    Console.WriteLine("Enter the new franchise name");
                                    franchiseObj.name = Console.ReadLine();

                                    Console.WriteLine("Enter the manager name of new franchise");
                                    franchiseObj.manager_name = Console.ReadLine();

                                    Console.WriteLine("Enter the contact number of new franchise");
                                    franchiseObj.contact_number = Console.ReadLine();

                                    Console.WriteLine("Enter the location of new franchise");
                                    franchiseObj.loaction = Console.ReadLine();

                                    //command creation
                                    SqlCommand cmd = new SqlCommand("insert into franchiseTable(franchise_name, manager_name, contact_number, location, salary_distribution) values( '" + franchiseObj.name + "'  , '" + franchiseObj.manager_name + "' , ' " + franchiseObj.contact_number + " ', ' " + franchiseObj.loaction + " ', 0)", con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Franchise Added Successfully!!!");
                                    break;

                                //case 2 for displaying a particular franchise details to admin using franchise's registered id
                                case 2:
                                    Console.WriteLine("Enter the franchise id whose details you want to display");
                                    franchiseObj.id = int.Parse(Console.ReadLine());

                                    SqlDataAdapter dataadap = new SqlDataAdapter("select * from franchiseTable", con);
                                    dataadap.Fill(ds, "franchiseTable");
                                    int num = ds.Tables["franchiseTable"].Rows.Count;
                                    for (int j = 0; j < num; j++)
                                    {
                                        if (franchiseObj.id.ToString() == ds.Tables["franchiseTable"].Rows[j][0].ToString())
                                        {
                                            Console.WriteLine("Franchise Id: " + ds.Tables["franchiseTable"].Rows[j][0].ToString());
                                            Console.WriteLine("Franchise Name: " + ds.Tables["franchiseTable"].Rows[j][1].ToString());
                                            Console.WriteLine("Franchise Manager: " + ds.Tables["franchiseTable"].Rows[j][2].ToString());
                                            Console.WriteLine("Franchise Contact Number: " + ds.Tables["franchiseTable"].Rows[j][3].ToString());
                                            Console.WriteLine("Location: " + ds.Tables["franchiseTable"].Rows[j][4].ToString());
                                            Console.WriteLine("Salary ditribution: " + ds.Tables["franchiseTable"].Rows[j][5].ToString());

                                        }
                                    }

                                    break;

                                //case 3 for displaying the total sales of a particular franchise of a particular date
                                case 3:
                                    Console.WriteLine("Enter the franchise ID whose sales you want to display");
                                    franchiseObj.id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the date in dd-mm-yyyy format");
                                    string date = Console.ReadLine();

                                    if (ds.Tables.CanRemove(ds.Tables["salesDetails"]))
                                    {
                                        ds.Tables.Remove(ds.Tables["salesDetails"]);
                                    }

                                    SqlDataAdapter dataadapnew = new SqlDataAdapter("select e.franchiseId, sum(o.price) from OrderDetails o inner join Employee e on o.employee_id = e.emp_id where o.orderDate = '" + date + "' and e.franchiseId = " + franchiseObj.id + " group by e.franchiseId", con);
                                    dataadapnew.Fill(ds, "salesDetails");

                                    int count2 = ds.Tables["salesDetails"].Rows.Count;

                                    for (int j = 0; j < count2; j++)
                                    {
                                        Console.WriteLine("Franchise Id: " + ds.Tables["salesDetails"].Rows[j][0].ToString());
                                        Console.WriteLine("Total Sales: " + ds.Tables["salesDetails"].Rows[j][1].ToString());
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Invalid Input, please check your input again");

                                    break;
                            }

                            //considering user's choice of process repeatition
                            Console.WriteLine("Do you want to start again? (Y/N)");
                            repeat = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong password");
                    }
                }
                //else block is for franchise login
                else
                {
                    for (int i = 1; i < count; i++)
                    {
                        //franchise authentication using registered id and passwprd
                        if (loginID == ds.Tables["Login"].Rows[i][0].ToString())
                        {
                            if (password == ds.Tables["Login"].Rows[i][1].ToString())
                            {
                                Console.WriteLine("Franchise manager logged in successfully!");

                                string repeat = "Y";
                                while (repeat.ToUpper() == "Y")
                                {
                                    Console.WriteLine("Enter 1 to register an employee\nEnter 2 for taking orders\nEnter 3 to distribute salaries\nEnter 4 to get sales record\nEnter 5 for total sales based on the type - dine In/Take away");

                                    int choice = int.Parse(Console.ReadLine());

                                    employeeCls emp = new employeeCls();
                                    OrdersCls order = new OrdersCls();

                                    switch (choice)
                                    {
                                        //case 1 is for registering an employee by franchise manager
                                        case 1:
                                            Console.WriteLine("Enter the employee name");
                                            emp.emp_name = Console.ReadLine();

                                            Console.WriteLine("Enter the employee's email id");
                                            emp.email = Console.ReadLine();

                                            Console.WriteLine("Enter the employee's contact number");
                                            emp.phone = Console.ReadLine();

                                            Console.WriteLine("Enter the id of the employee's franchise");
                                            emp.franchiseId = int.Parse(Console.ReadLine());

                                            //command creation
                                            SqlCommand cmd = new SqlCommand("insert into Employee (emp_name, email, phone, franchiseId) values( '" + emp.emp_name + "'  , '" + emp.email + "' , ' " + emp.phone + " ',  " + emp.franchiseId + ")", con);
                                            con.Open();
                                            cmd.ExecuteNonQuery();
                                            con.Close();
                                            Console.WriteLine("Employee Added Successfully!!!");

                                            break;

                                        //case 2 is for taking pizza's orders
                                        case 2:
                                            Console.WriteLine("Enter Ordered Pizza Name");
                                            order.pizza = Console.ReadLine();

                                            Console.WriteLine("Enter the medium - Dine In/Take Away? ");
                                            order.type = Console.ReadLine();

                                            Console.WriteLine("Enter the id of employee who's taking the order");
                                            order.employee_id = Console.ReadLine();

                                            Console.WriteLine("Enter the date of order");
                                            order.orderDate = Console.ReadLine();

                                            Console.WriteLine("Enter the Customer's Name");
                                            order.customer_name = Console.ReadLine();

                                            Console.WriteLine("Enter the order's price");
                                            order.price = int.Parse(Console.ReadLine());

                                            //command creation
                                            SqlCommand cmd2 = new SqlCommand("insert into OrderDetails (type, customer_name, employee_id, orderDate, pizza_name, price) values( '" + order.type + "'  , '" + order.customer_name + "' ,  " + order.employee_id + " ,  '" + order.orderDate + "' , '" + order.pizza + "' ,  " + order.price + ")", con);
                                            con.Open();
                                            cmd2.ExecuteNonQuery();
                                            con.Close();
                                            Console.WriteLine("Order Added Successfully!!!");

                                            break;

                                        //case 3 is for salary distribution
                                        case 3:
                                            Console.WriteLine("Enter your franchise id");
                                            franchiseObj.id = int.Parse(Console.ReadLine());

                                            SqlCommand cmd3 = new SqlCommand("UPDATE franchiseTable SET salary_distribution = (salary_distribution + 1) WHERE franchise_id = " + franchiseObj.id + "", con);

                                            con.Open();
                                            cmd3.ExecuteNonQuery();
                                            con.Close();
                                            Console.WriteLine("Record updated successfully!!");

                                            break;

                                        //case 4 is to get the sales record of the current logged in franchise for a particulare day
                                        case 4:
                                            string LoggedinFranchiseID = ds.Tables["Login"].Rows[i][2].ToString();
                                            int id = int.Parse(LoggedinFranchiseID);
                                            Console.WriteLine("Enter the date in dd-mm-yyyy format");
                                            string day = Console.ReadLine();

                                            if (ds.Tables.CanRemove(ds.Tables["salesDetails"]))
                                            {
                                                ds.Tables.Remove(ds.Tables["salesDetails"]);
                                            }

                                            SqlDataAdapter dataadapnew = new SqlDataAdapter("select e.franchiseId, sum(o.price) from OrderDetails o inner join Employee e on o.employee_id = e.emp_id where o.orderDate = '" + day + "' and e.franchiseId = " + id + " group by e.franchiseId", con);
                                            dataadapnew.Fill(ds, "salesDetails");
                                            int count2 = ds.Tables["salesDetails"].Rows.Count;

                                            if (count2 > 0)
                                            {
                                                for (int j = 0; j < count2; j++)
                                                {
                                                    Console.WriteLine("Franchise Id: " + ds.Tables["salesDetails"].Rows[j][0].ToString());
                                                    Console.WriteLine("Total Sales: " + ds.Tables["salesDetails"].Rows[j][1].ToString());
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Oops! we have no sale for this day");
                                            }

                                            break;

                                        //case 5 is for displaying the order type wise total sales record - like dine in / take away type
                                        case 5:

                                            Console.WriteLine("Press 1 for displaying total sales of dine in type, press 2 for displaying total sales for take away type");
                                            int inp = int.Parse(Console.ReadLine());

                                            if (inp == 1) order.type = "Dine in";
                                            else order.type = "Take away";

                                            string LoggedinFranchiseId = ds.Tables["Login"].Rows[i][2].ToString();
                                            int fid = int.Parse(LoggedinFranchiseId);

                                            if (ds.Tables.CanRemove(ds.Tables["salesDetails"]))
                                            {
                                                ds.Tables.Remove(ds.Tables["salesDetails"]);
                                            }

                                            SqlDataAdapter dataadapnew2 = new SqlDataAdapter("select e.franchiseId, sum(o.price) from OrderDetails o inner join Employee e on o.employee_id = e.emp_id where o.type = '" + order.type + "'and e.franchiseId = " + fid + " group by e.franchiseId", con);
                                            dataadapnew2.Fill(ds, "salesDetails");
                                            int countRows = ds.Tables["salesDetails"].Rows.Count;

                                            if (countRows > 0)
                                            {
                                                for (int x = 0; x < countRows; x++)
                                                {

                                                    Console.WriteLine("Franchise Id: " + ds.Tables["salesDetails"].Rows[x][0].ToString());
                                                    Console.WriteLine("Total Sales: " + ds.Tables["salesDetails"].Rows[x][1].ToString());
                                                    Console.WriteLine();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Oops! we have no sale for this day");
                                            }

                                            break;

                                        default:
                                            Console.WriteLine("Invalid Input, please check your input again!");
                                            break;
                                    }
                                    Console.WriteLine("Do you want to start again? (Y/N)");
                                    repeat = Console.ReadLine();

                                }


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            
        }

        
    }
}
