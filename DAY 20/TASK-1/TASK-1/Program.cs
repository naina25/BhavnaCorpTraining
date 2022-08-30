using System;
using System.Data;
using System.Data.SqlClient;

namespace TASK_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------DB CRUD OPERATIONS------------

            string isRepeat = "Y";

            employeecls emp = new employeecls();

            //connection string (db connection) 
            SqlConnection con = new SqlConnection("server=localhost;database=Employee;integrated security=true");

            while (isRepeat == "Y" || isRepeat == "y")
            {
                Console.WriteLine("enter your choice -  1 for Data Insertion, 2 for Data Deletion, 3 for update, 4 for search");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the id");
                        emp.id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name of employee");
                        emp.name = Console.ReadLine();
                        Console.WriteLine("Enter department of employee");
                        emp.department = Console.ReadLine();
                        Console.WriteLine("Enter gender of employee");
                        emp.gender = Console.ReadLine();

                        //command creation
                        SqlCommand cmd = new SqlCommand("insert into emp_details values( " + emp.id + "  ,' " + emp.name + " ' , ' " + emp.department + " ', ' " + emp.gender + " ')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record Inserted Successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter id of an employee");
                        emp.id = int.Parse(Console.ReadLine());
                        SqlCommand cmd1 = new SqlCommand("delete from emp_details where id=" + emp.id + " ", con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record deleted successfully!!");
                        break;
                    case 3:
                        Console.WriteLine("Enter the id to be updated");
                        emp.id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name of employee");
                        emp.name = Console.ReadLine();
                        Console.WriteLine("Enter department of employee");
                        emp.department = Console.ReadLine();
                        Console.WriteLine("Enter gender of employee");
                        emp.gender = Console.ReadLine();

                        SqlCommand cmd2 = new SqlCommand("update emp_details set name= '" + emp.name + "', department= '" + emp.department + "',gender='" + emp.gender + "' where id=" + emp.id + "", con);

                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record updated successfully!!");
                        break;
                    case 4:
                        Console.WriteLine("Enter the id to be searched");
                        emp.id = int.Parse(Console.ReadLine());
                        SqlDataAdapter da = new SqlDataAdapter("select * from emp_details", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "emp_details");
                        int x = ds.Tables[0].Rows.Count;
                        Console.WriteLine("records found: " + x);

                        for (int i = 0; i < x; i++)
                        {
                            if (emp.id.ToString() == ds.Tables[0].Rows[i][0].ToString())
                            {
                                Console.WriteLine("Name: " + ds.Tables[0].Rows[i][1].ToString());
                                Console.WriteLine("Department: " + ds.Tables[0].Rows[i][2].ToString());
                                Console.WriteLine("Gender: " + ds.Tables[0].Rows[i][3].ToString());
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong Input!!");
                        break;

                }
                Console.WriteLine("Do you want to repeat? Y or N");
                isRepeat = Console.ReadLine();
            }
        }
    }
}
