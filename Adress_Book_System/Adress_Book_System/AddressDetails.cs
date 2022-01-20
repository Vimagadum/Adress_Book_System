using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{
    public class AddressDetails
    {
        public char y;
        public char n;
        ArrayList allcontacts = new ArrayList();
        public void AddDetails()
        {
            //Taking Input of Address Details

           Console.WriteLine("Enter First Name");
           string firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter State name");
            string state = Console.ReadLine();
            Console.WriteLine("Enter City Name");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Address ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Zip Code");
            int zipcode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Mobile Number");
            long mobilenumber = Convert.ToInt64(Console.ReadLine());

           // storing the details in person
            Address_Book contacts = new Address_Book(firstname, lastname, state, city, address, email, zipcode, mobilenumber);
            Console.WriteLine("Contact Added "+ contacts);

            //adding contacts in list
            allcontacts.Add(contacts);
           
        }
        
        //Writing method to Display all contacts
        public void view()
        {
            foreach(Address_Book contactList in allcontacts)
            {
                Console.WriteLine(contactList);
            }
        }
    }
}
