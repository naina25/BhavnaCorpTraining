using System;
using System.Data;
using System.Data.SqlClient;

namespace Assessment5
{
    class Program
    {
        static void Main(string[] args)
        {
            //db connection string-----------------
            SqlConnection con = new SqlConnection("server=localhost;database=OnlineVotingSystem1;integrated security=true");
            DataSet ds = new DataSet();

            //creating object of voter class
            voter voterobj = new voter();
            party partyobj = new party();

            string isrepeat = "Y";
            int choice;
            try
            {
                while (isrepeat.ToUpper() == "Y")
                {
                    Console.WriteLine("Press 1 to register a new voter\nPress 2 to cast your vote\nPress 3 to view the votes");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter voter's aadhaar number");
                            voterobj.aadhaar_no = long.Parse(Console.ReadLine());

                            Console.WriteLine("Enter voter's name as per the aadhaar card");
                            voterobj.name = Console.ReadLine();

                            Console.WriteLine("Enter voter's votercard number");
                            voterobj.votercard_no = long.Parse(Console.ReadLine());

                            Console.WriteLine("Enter voter's contact number");
                            voterobj.contact_no = long.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the voter's address");
                            voterobj.address = Console.ReadLine();

                            Console.WriteLine("Enter the dob of the voter in dd-mm-yyyy format only");
                            voterobj.dob = Console.ReadLine();

                            Console.WriteLine("Enter the voting area id for the voter");
                            voterobj.votingAreaId = long.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the status of the voter - active/inactive");
                            voterobj.status = Console.ReadLine();

                            Console.WriteLine("Enter the mode of the voter - online/offline");
                            voterobj.mode = Console.ReadLine();

                            //inserting a record in db

                            SqlCommand cmd = new SqlCommand("insert into voter_registration values( '" + voterobj.name + "'  , " + voterobj.aadhaar_no + " ,  " + voterobj.votercard_no + " ,  " + voterobj.contact_no + " , '" + voterobj.address + "', '" + voterobj.dob + "',"+voterobj.votingAreaId + ",'"+voterobj.status+"','"+voterobj.mode+"')", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            
                            //-------------we can add dot animation here for few seconds-----------------

                            Console.WriteLine("Voter Added Successfully!!");
                            break;
                        case 2:
                            Console.WriteLine("Please enter your voter card id:");
                            voterobj.votercard_no = int.Parse(Console.ReadLine());

                            SqlDataAdapter dataadap = new SqlDataAdapter("select votercard_no, vote_casted, status from voter_registration where votercard_no = " + voterobj.votercard_no + "", con);

                            if (ds.Tables.CanRemove(ds.Tables["voteCasted"]))
                                ds.Tables.Remove(ds.Tables["voteCasted"]);

                            dataadap.Fill(ds, "voteCasted");

                            if (ds.Tables["voteCasted"].Rows[0][1].ToString() == "False")
                            {
                                if (ds.Tables["voteCasted"].Rows[0][2].ToString() == "active")
                                {
                                    Console.WriteLine("Congratulations! You are eligible for online vote casting\n" +
                                    "Welcome to the online voting system.\n" +
                                    "Below are the political parties list. Please cast your vote by entering the correct party symbol name below\n Press 4 for party registration");

                                    //printing the parties names to the console -
                                    SqlDataAdapter data = new SqlDataAdapter("select party_name, party_symbol from Party_info", con);

                                    if (ds.Tables.CanRemove(ds.Tables["Parties"]))
                                        ds.Tables.Remove(ds.Tables["Parties"]);

                                    data.Fill(ds, "Parties");

                                    int num = ds.Tables["Parties"].Rows.Count;

                                    if (num > 0)
                                    {
                                        for (int i = 0; i < num; i++)
                                        {
                                            Console.WriteLine("Party: " + ds.Tables["Parties"].Rows[i][0].ToString() + ", Symbol: " + ds.Tables["Parties"].Rows[i][1].ToString() + "\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't find any information related to parties in db\n");
                                    }

                                    //storing the vote of voter
                                    string vote = Console.ReadLine();

                                    //updating the voter's vote in the database
                                    SqlCommand cmd3 = new SqlCommand("UPDATE Party_info SET total_votes = (total_votes + 1) WHERE party_symbol = '" + vote + "'", con);

                                    con.Open();
                                    cmd3.ExecuteNonQuery();
                                    con.Close();

                                    //updating the votecasted to true in the database
                                    SqlCommand cmd4 = new SqlCommand("UPDATE voter_registration SET vote_casted = 1 where votercard_no = " + voterobj.votercard_no + "", con);

                                    con.Open();
                                    cmd4.ExecuteNonQuery();
                                    con.Close();

                                    Console.WriteLine("Congratulations, You've successfully casted your vote!!\n" +
                                        "Proud to have a citizen like yours\n" +
                                        "Thank You for using online voting system\n");
                                }
                                else
                                {
                                    Console.WriteLine("You're not eligible for online voting. Please visit you nearby polling booth to cast your vote. Thank You!\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You've already casted your vote. Thank You!!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter the symbol of party whose total votes you want to see or Enter ALL to see the all parties votes");
                            string partyName = Console.ReadLine();

                            if(partyName.ToUpper() == "ALL")
                            {
                                SqlDataAdapter newdata = new SqlDataAdapter("select party_name, party_symbol, total_votes from Party_info", con);

                                if (ds.Tables.CanRemove(ds.Tables["parties_votes"]))
                                    ds.Tables.Remove(ds.Tables["parties_votes"]);

                                newdata.Fill(ds, "parties_votes");

                                int num = ds.Tables["parties_votes"].Rows.Count;

                                if(num > 0)
                                {
                                    for(int i=0; i<num; i++)
                                    {
                                        Console.WriteLine($"Party Name: {ds.Tables["parties_votes"].Rows[i][0].ToString()}, " +
                                            $"Party Symbol: {ds.Tables["parties_votes"].Rows[i][1].ToString()}, " +
                                            $"Votes recieved: {ds.Tables["parties_votes"].Rows[i][2].ToString()}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Couldn't find any information related to parties in db\n");
                                }
                            }
                            else
                            {
                                SqlDataAdapter newdata = new SqlDataAdapter("select party_name, party_symbol, total_votes from Party_info where party_symbol = '"+ partyName +"'", con);

                                if (ds.Tables.CanRemove(ds.Tables["party_votes"]))
                                    ds.Tables.Remove(ds.Tables["party_votes"]);

                                newdata.Fill(ds, "party_votes");

                                int num = ds.Tables["party_votes"].Rows.Count;
                                if (num > 0)
                                {
                                    for (int i = 0; i < num; i++)
                                    {
                                        Console.WriteLine($"Party Name: {ds.Tables["party_votes"].Rows[i][0].ToString()}, " +
                                            $"Party Symbol: {ds.Tables["party_votes"].Rows[i][1].ToString()}, " +
                                            $"Votes recieved: {ds.Tables["party_votes"].Rows[i][2].ToString()}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Party doesn't exist in db\n");
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the name of the party");
                            partyobj.party_name = Console.ReadLine();

                            Console.WriteLine("Enter the symbol name for the party");
                            partyobj.party_symbol = Console.ReadLine();

                            Console.WriteLine("Enter the area id for the party where voting will be held");
                            partyobj.area_id = int.Parse(Console.ReadLine());

                            //inserting party record in db------------------------------------------------
                            SqlCommand partycmd = new SqlCommand("insert into Party_info (party_name, party_symbol, total_votes, voting_areaID) values( '" + partyobj.party_name + "'  , '" + partyobj.party_symbol + "' , 0 , " + partyobj.area_id + ")", con);
                            con.Open();
                            partycmd.ExecuteNonQuery();
                            con.Close();

                            //we can add dot animation here for few seconds-------------------------------
                            Console.WriteLine("Party info inserted sucessfully in the database");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
            

        }
    }
}
