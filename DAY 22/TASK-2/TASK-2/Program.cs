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
            SqlConnection con = new SqlConnection("server=localhost;database=fashionStore;integrated security=true");

            try
            {
                Console.WriteLine("Enter your registered id and password to login");
                int loginId = int.Parse(Console.ReadLine());
                string loginPWD = Console.ReadLine();

                SqlDataAdapter da = new SqlDataAdapter("select * from AdminLogin", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "AdminLogin");
                int x = ds.Tables[0].Rows.Count;

                for(int i=0; i < x; i++)
                {
                    if(loginId.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (loginPWD.ToString() == ds.Tables[0].Rows[i][1].ToString())
                        {
                            string isRepeat = "Y";

                            while (isRepeat.ToUpper() == "Y")
                            {
                                Console.WriteLine("Successfully logged in!!");
                                Console.WriteLine("Enter your choice: 1 for products data insertion, 2 for data deletion, 3 for data updation, 4 for displaying all products details");

                                int choice = int.Parse(Console.ReadLine());
                                Productcls product = new Productcls();

                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the products details as following - product name, product price, product quantity, category id");

                                        product.prod_name = Console.ReadLine();
                                        product.prod_price = int.Parse(Console.ReadLine());
                                        product.prod_qty = int.Parse(Console.ReadLine());
                                        product.c_id = int.Parse(Console.ReadLine());

                                        //command creation
                                        SqlCommand cmd = new SqlCommand("insert into products values( '" + product.prod_name + "'  , " + product.prod_price + " ," + product.prod_qty + ", " + product.c_id + ")", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record Inserted Successfully");

                                        break;

                                    case 2:
                                        Console.WriteLine("Enter the id of a product which is to be deleted");
                                        product.prod_id = int.Parse(Console.ReadLine());
                                        SqlCommand cmd1 = new SqlCommand("delete from products where prod_id=" + product.prod_id + " ", con);
                                        con.Open();
                                        cmd1.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record deleted successfully!!");
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter the product id which is to be updated");
                                        product.prod_id = int.Parse(Console.ReadLine());

                                        Console.WriteLine("Enter the products details for updation as following - product name, product price, product quantity, category id");

                                        product.prod_name = Console.ReadLine();
                                        product.prod_price = int.Parse(Console.ReadLine());
                                        product.prod_qty = int.Parse(Console.ReadLine());
                                        product.c_id = int.Parse(Console.ReadLine());

                                        SqlCommand cmd2 = new SqlCommand("update products set prod_name= '" + product.prod_name + "'  , price= " + product.prod_price + " , quantity= " + product.prod_qty + " , cat_id =  " + product.c_id + " where prod_id=" + product.prod_id + "", con);

                                        con.Open();
                                        cmd2.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record updated successfully!!");
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        break;
                                }
                                Console.WriteLine("Do you want to repeat? Y/N");
                                isRepeat = Console.ReadLine();
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
