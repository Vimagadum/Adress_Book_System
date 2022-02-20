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
                            Console.WriteLine(cdb.firstname+" "+cdb.lastname+" "+cdb.city+" "+cdb.phone+" "+cdb.phone+" "+cdb.B_Name+" "+cdb.B_Type);
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
    }
}
