using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace StaffMan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            while (b)
            {
           
                Console.WriteLine("-----------------------------");
                Console.WriteLine("|  Staff Management System  |");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Continue \n2. Exit\n");
                var home = Console.ReadLine();
                //    int home = Convert.ToInt32(h);
                //    Console.WriteLine(home);
                switch (home)
                {
                    case "1":
                        Console.WriteLine("Choose the Service from Menu");
                        Console.WriteLine("1. Add New Staff \n2. List All Staff \n3. Find a Staff with Id, Name, Designation \n" +
                            "4. Enter Staff Salary for a Month \n5. Salary Statment of a Staff \n6. Exit ");
                        var option = Console.ReadLine();
                        //        Console.WriteLine(option);
                        // Cases for selecting the options.
                        switch (option)
                        {
                            //Add new staff
                            case "1":
                                {
                                    Console.WriteLine("Enter Staff ID");
                                    var id = Console.ReadLine();
                                    int staffid = Convert.ToInt32(id);
                                    Console.WriteLine("Enter Staff Name");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Enter Designation");
                                    var desig = Console.ReadLine();
                                    AddStaff(staffid, name, desig);


                                }
                                break;
                            //List all staff
                            case "2":
                                {
                                    Console.WriteLine("Sort by: \n1. Name \n2. Designation");
                                    var sort = Console.ReadLine();
                                    switch (sort)
                                    {
                                        case "1":
                                            {

                                                string s = "Name";
                                                ListStaff(s);

                                            }
                                            break;
                                        case "2":
                                            {
                                                string s = "Designation";
                                                ListStaff(s);
                                            }
                                            break;
                                        default:
                                            {
                                                Console.WriteLine("Invalid Input");
                                            }
                                            break;

                                    }

                                }
                                break;
                            //search staff
                            case "3":
                                {
                                    Console.WriteLine("Enter Staff ID");
                                    var id = Console.ReadLine();
                                    int staffid = Convert.ToInt32(id);
                                    Console.WriteLine("Enter Staff Name");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Enter Designation");
                                    var desig = Console.ReadLine();
                                    SearchStaff(staffid, name, desig);
                                }
                                break;
                            //enter salary
                            case "4":
                                {
                                    Console.WriteLine("Sort by: \n1. New Entry \n2. Update Existing Record");
                                    var enter = Console.ReadLine();
                                    switch (enter)
                                    {
                                        case "1":
                                            {
                                                Console.WriteLine("Use the Staff Id shown in th list");
                                                ListID();
                                                Console.WriteLine("\n");
                                                Console.WriteLine("Enter Staff ID");
                                                var id = Console.ReadLine();
                                                int staffid = Convert.ToInt32(id);
                                                Console.WriteLine("Enter Salary");
                                                var salary = Console.ReadLine();
                                                decimal salary1 = Convert.ToDecimal(salary);
                                                Console.WriteLine("Enter Month and Year \n PLEASE USE THE FORMAT MMM-YYYY");
                                                var date = Console.ReadLine();

                                                Console.WriteLine("Confirm Y/N");
                                                var c1 = Console.ReadLine();
                                                char c2 = Char.Parse(c1);
                                                char confirm = char.ToUpper(c2);
                                                string confirm1 = confirm.ToString();
                                                //    Console.WriteLine(confirm);
                                                //if (confirm[0]="Y")
                                                switch (confirm1)
                                                {
                                                    case "Y":
                                                        {
                                                            //Console.WriteLine(confirm);
                                                            AddSalary(staffid, salary1, date);
                                                            CheckDup();
                                                            TotalPaid(staffid);
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            return;
                                                        }
                                                }


                                            }
                                            break;
                                        case "2":
                                            {
                                                Console.WriteLine("Give Details to get updated:");
                                                Console.WriteLine("Enter Staff ID");
                                                var id = Console.ReadLine();
                                                int staffid = Convert.ToInt32(id);
                                                Console.WriteLine("Enter Month and Year");
                                                var date = Console.ReadLine();
                                                Console.WriteLine("Enter Salary");
                                                var sal = Console.ReadLine();
                                                decimal salary = Convert.ToDecimal(sal);



                                                Console.WriteLine("Give Final Details to get SAVED:");
                                                Console.WriteLine("Enter Staff ID");
                                                var idf = Console.ReadLine();
                                                int staffidf = Convert.ToInt32(id);
                                                Console.WriteLine("Enter Month and Year");
                                                var datef = Console.ReadLine();
                                                Console.WriteLine("Enter Salary");
                                                var salf = Console.ReadLine();
                                                decimal salaryf = Convert.ToDecimal(salf);
                                                Console.WriteLine("Confirm Y/N");
                                                var c1 = Console.ReadLine();
                                                char c2 = Char.Parse(c1);
                                                char confirm = char.ToUpper(c2);
                                                string confirm1 = confirm.ToString();
                                                switch (confirm1)
                                                {
                                                    case "Y":
                                                        {
                                                            //Console.WriteLine(confirm);
                                                            UpdateSalary(staffid, salary, date, staffidf, salaryf, datef);
                                                            CheckDup();
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }

                                            }
                                            break;
                                        default:
                                            {
                                                Console.WriteLine("Invalid Input");
                                            }
                                            break;
                                    }
                                }
                                break;
                            //salary statement
                            case "5":
                                {
                                    Console.WriteLine("Use the Staff Id shown in th list");
                                    ListID();
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Enter Staff ID");
                                    var id = Console.ReadLine();
                                    int staffid = Convert.ToInt32(id);
                                    Console.WriteLine("Enter Year");
                                    var year = Console.ReadLine();
                                    //   int year = Convert.ToInt32(y);
                                    Console.WriteLine("Salary Statement of {0}", staffid);
                                    Statemet(staffid, year);
                                    TotalPaidperYear(staffid, year);
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine("Thank you");
                                    b = false;
                                }
                                break;

                        }
                        break;


                    default:
                        Console.WriteLine("Thank you");
                        b = false;
                        break;

                }

            }
        }


        //funtions
        //to add staff
        public static void AddStaff(int staffId, string name, string designation)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = string.Format("insert into Staff values({0},'{1}','{2}')", staffId, name, designation);

                SqlCommand cm = new SqlCommand(command, con);  
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Added Staff Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


        //to list all staff (sortby name or designation)
        public static void ListStaff(string sortby)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = "SELECT * FROM Staff ORDER BY " + sortby;

                SqlCommand cm = new SqlCommand(command, con);
             //   SqlDataAdapter da = new SqlDataAdapter(command, con);
              //  DataSet ds = new DataSet();
              ///  da.Fill(ds);
                
                
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                while (rd.Read())
                {
                    string o = rd[0].ToString();
                    string u = rd[1].ToString();
                    string t = rd[2].ToString();
                    Console.WriteLine("ID={0}, Name= {1}, Designation= {2}", o, u, t);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


        //filtering a staff

        public static void SearchStaff(int staffId, string name, string designation)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = string.Format("SELECT * FROM Staff WHERE StaffId={0} AND Name='{1}' AND Designation='{2}'", staffId, name, designation);

                SqlCommand cm = new SqlCommand(command, con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                if (rd.Read())
                {
                    string o = rd[0].ToString();
                    string u = rd[1].ToString();
                    string t = rd[2].ToString();
                    Console.WriteLine ("DATA FOUND ID={0}, Name= {1}, Designation= {2}",o, u, t);
                    
                }
                  else
                {
                    Console.WriteLine("Data Not Found!!!");
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }






        //to list all staffID 
        public static void ListID()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = "SELECT StaffID FROM Staff";

                SqlCommand cm = new SqlCommand(command, con);
                //   SqlDataAdapter da = new SqlDataAdapter(command, con);
                //  DataSet ds = new DataSet();
                ///  da.Fill(ds);


                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                while (rd.Read())
                {
                    string o = rd[0].ToString();
                    // string u = rd[1].ToString();
                    //  string t = rd[2].ToString();
                    // Console.WriteLine("ID={0}, Name= {1}, Designation= {2}", o);
                    Console.Write("'{0}'"  , o);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        //to add salary
        public static void AddSalary(int staffId, decimal salary, string date)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = string.Format("insert into Salary values({0},{1},'{2}')", staffId, salary, date);

                SqlCommand cm = new SqlCommand(command, con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Salary Added Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }



        //to check duplication

        public static void CheckDup()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = string.Format("With del AS(Select *, ROW_NUMBER() over(Partition by StaffID, Salary, Date order by StaffID) as count From Salary)delete from del where count > 1");

                SqlCommand cm = new SqlCommand(command, con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Duplicate entry check processed and completed. ");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }



        //update salary

        public static void UpdateSalary(int staffId, decimal salary, string date, int staffIdf, decimal salaryf, string datef)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = string.Format("update salary set StaffID={0}, Salary={1}, Date= '{2}' where StaffID={3} and Salary={4} and date='{5}'",staffIdf, salaryf, datef, staffId, salary, date);

                SqlCommand cm = new SqlCommand(command, con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Salary Updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


        //to find total paid

        public static void TotalPaid(int staffId)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = "select sum(salary) from Salary where StaffID="+staffId;

                SqlCommand cm = new SqlCommand(command, con);
       

                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                while (rd.Read())
                {
                    string o = rd[0].ToString();
              
                    Console.WriteLine("Total Paid: '{0}'", o);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


        //print statement


        public static void Statemet(int staffId, string year)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
              // string command = ("select * from Salary where StaffID="+staffId+" and date like '%"+year+"'" );
                string command = String.Format("select * from Salary where StaffID= {0} AND Date LIKE '%{1}'", staffId, year);

                SqlCommand cm = new SqlCommand(command, con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                while (rd.Read())
                {
                    string o = rd[0].ToString();
                    string u = rd[1].ToString();
                    string t = rd[2].ToString();
                    
                    Console.WriteLine(" ID={0}, Salary= {1}, Month and Year= {2}", o, u, t);

                }
              

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


        // total paid in an year

        public static void TotalPaidperYear(int staffId, string year)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=Staffman; integrated security=SSPI");
                // writing sql query  
                string command = String.Format("select sum(salary) from Salary where StaffID= {0} AND Date LIKE '%{1}'", staffId, year);

                SqlCommand cm = new SqlCommand(command, con);


                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader rd = cm.ExecuteReader();
                // Displaying a message
                while (rd.Read())
                {
                    string o = rd[0].ToString();

                    Console.WriteLine("Total Paid: '{0}'", o);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }


    }
}
