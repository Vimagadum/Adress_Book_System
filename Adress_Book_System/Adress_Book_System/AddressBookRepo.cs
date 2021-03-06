using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=LAPTOP-DI3UPG04;Initial Catalog=AddressBookService;Integrated Security=True";
        public static SqlConnection connection = null;

        //getting all details of person from the data base
        public ContactsModel GetAllContacts()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    ContactsModel cdb = new ContactsModel();

                    string query = @"select c.first_name, c.last_name, c.city, c.phone_no, b.bk_name, b.bk_type 
                                 from contact c inner join booknametype b on c.book_id = b.book_id WHERE LOWER(c.first_name)='rosa';";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cdb.firstname = reader.GetString(0);
                            cdb.lastname = reader.GetString(1);
                            cdb.city = reader.GetString(2);
                            cdb.phone = reader.GetString(3);
                            cdb.B_Name = reader.GetString(4);
                            cdb.B_Type = reader.GetString(5);
                            Console.WriteLine(cdb.firstname + " " + cdb.lastname + " " + cdb.city + " " + cdb.phone + " " + cdb.phone + " " + cdb.B_Name + " " + cdb.B_Type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Rows doesn't exist!");
                    }
                    reader.Close();
                    return cdb;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        //updating contact
        public string UpdateContactToDatabase()
        {
            SqlConnection connection = null;
            string state = "";
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    string query = "update contact set State = 'California' where first_name = 'rosa';" +
                                    "select * from contact where first_name = 'rosa';";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            state = reader.GetString(4);
                        }
                        Console.WriteLine("Contact is updated");
                    }
                    else
                    {
                        Console.WriteLine("Updated rows doesn't exist!");
                    }
                    reader.Close();
                    return state;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return state;
            }
            finally
            {

                connection.Close();
            }
        }
        //adding new column to the table
        public void AddDateField()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "ALTER TABLE contact ADD StartDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP; ";


                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                command.ExecuteReader();
                Console.WriteLine("adding colum to the data base");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //retrive data from the data base based on city or state
        public void RetrieveByCityOrState()
        {
            try
            {
                ContactsModel cdb = new ContactsModel();
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "select * from contact where city = 'New York' or state = 'Maharashtra';";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        cdb.firstname = reader.GetString(0);
                        cdb.lastname = reader.GetString(1);
                        cdb.city = reader.GetString(3);
                        cdb.state = reader.GetString(4);
                        cdb.phone = reader.GetString(6);
                        Console.WriteLine(cdb.firstname + " " + cdb.lastname + " " + cdb.city + " " + cdb.state + " " + cdb.phone);
                    }

                }
                else
                {
                    Console.WriteLine("No contacts match the City or State");
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //Adding New contact to the data base
        public void  AddNewContact()
        {
            try
            {
                ContactsModel cdb = new ContactsModel();
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "Insert INTO contact(first_name, last_name, address, city, state, zip, phone_no, email, book_id) VALUES('Krish', 'Rao', 'mahadevpura','banglore', 'Karnatak', 591214, '2354618520', 'krish@gmail.com', 'BK3');" +
                    "select * from contact where first_name = 'Krish';";


                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        string first_name = reader.GetString(0);
                        Console.WriteLine("Fisrt Name "+ first_name);
                    }
                    Console.WriteLine("Contact is added");
                }
                else
                {
                    Console.WriteLine("contact adding failed");
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
    

