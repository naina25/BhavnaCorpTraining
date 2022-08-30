using System;
using System.Data;
using System.Data.SqlClient;

namespace TASK_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection string (db connection) 
            SqlConnection con = new SqlConnection("server=localhost;database=Bank;integrated security=true");

            try
            {
                Console.WriteLine("Enter your registered id and password to login");
                int loginId = int.Parse(Console.ReadLine());
                string loginPWD = Console.ReadLine();

                SqlDataAdapter da = new SqlDataAdapter("select * from AdminLogin", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "AdminLogin");
                int x = ds.Tables[0].Rows.Count;

                for (int i = 0; i<x; i++)
                {
                    if(loginId.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if(loginPWD.ToString() == ds.Tables[0].Rows[i][1].ToString())
                        {
                            string isRepeat = "Y";

                            while (isRepeat.ToUpper() == "Y")
                            {
                                Console.WriteLine("Successfully logged in!!");
                                Console.WriteLine("Enter your choice: 1 for customer data insertion, 2 for data deletion, 3 for data updation, 4 for displaying all customers details");

                                int choice = int.Parse(Console.ReadLine());

                                customerCls customer = new customerCls();

                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter customer's name");
                                        customer.name = Console.ReadLine();
                                        Console.WriteLine("Enter customer's age");
                                        customer.age = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter customer's address");
                                        customer.address = Console.ReadLine();
                                        Console.WriteLine("Enter customer's phone");
                                        customer.phone = Console.ReadLine();
                                        Console.WriteLine("Enter customer's email");
                                        customer.email = Console.ReadLine();

                                        //command creation
                                        SqlCommand cmd = new SqlCommand("insert into CustomerDetails values( '" + customer.name + "'  , " + customer.age + " , ' " + customer.address + " ', ' " + customer.phone + " ', ' " + customer.email + " ')", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record Inserted Successfully");
                                        break;
                                    case 2:
                                            Console.WriteLine("Enter the id of a customer which is to be deleted");
                                            customer.id = int.Parse(Console.ReadLine());
                                            SqlCommand cmd1 = new SqlCommand("delete from CustomerDetails where custId=" + customer.id + " ", con);
                                            con.Open();
                                            cmd1.ExecuteNonQuery();
                                            con.Close();
                                            Console.WriteLine("Record deleted successfully!!");
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter the customer id which is to be updated");
                                        customer.id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter customer's name");
                                        customer.name = Console.ReadLine();
                                        Console.WriteLine("Enter customer's age");
                                        customer.age = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter customer's address");
                                        customer.address = Console.ReadLine();
                                        Console.WriteLine("Enter customer's phone");
                                        customer.phone = Console.ReadLine();
                                        Console.WriteLine("Enter customer's email");
                                        customer.email = Console.ReadLine();

                                        SqlCommand cmd2 = new SqlCommand("update CustomerDetails set name= '" + customer.name + "'  , age= " + customer.age + " , address=' " + customer.address + " ',phone= ' " + customer.phone + " ', email=' " + customer.email + " ' where custId=" + customer.id + "", con);

                                        con.Open();
                                        cmd2.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record updated successfully!!");
                                        break;
                                    case 4:
                                        SqlDataAdapter dataadap = new SqlDataAdapter("select * from CustomerDetails", con);
                                        dataadap.Fill(ds, "CustomerDetails");
                                        int num = ds.Tables[1].Rows.Count;
                                        for(int j=0; j < num; j++)
                                        {
                                            Console.Write("Name: " + ds.Tables[1].Rows[j][1].ToString()+"/");
                                            Console.Write("Age: " + ds.Tables[1].Rows[j][2].ToString()+"/");
                                            Console.Write("Address: " + ds.Tables[1].Rows[j][3].ToString()+"/");
                                            Console.Write("Phone: " + ds.Tables[1].Rows[i][4].ToString()+"/");
                                            Console.Write("Email: " + ds.Tables[1].Rows[i][5].ToString());
                                            Console.WriteLine();
                                        }
                                        break;
                                    default:
                                        break;
                                }


                                Console.WriteLine("Do you want to repeat the process? Y/N ");
                                isRepeat = Console.ReadLine();
                            }
                        }
                    }


                }

            }
            catch
            {

            }
        }
    }
}
