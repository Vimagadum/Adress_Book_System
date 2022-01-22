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
                        //adding contacts in list
            allcontacts.Add(contacts);
            Console.WriteLine("Contact is Added");
            view();

        }

        //Writing method to Display all contacts
        public void view()
        {
            foreach (Address_Book contactList in allcontacts)
            {
                Console.WriteLine(contactList);
            }
        }

        //Creating method to Edit the Contact
        public void EditContact()
        {
            //Taking first name as input from the user to check weather this name is existing in contact list or not
            Console.WriteLine("Enter the First Name of your contact that which contact you wants to Edit");
            string Fname = Console.ReadLine();
            foreach (Address_Book eachcontact in allcontacts)
            {
                //Comparing existing firts name to user entered first name
                if (Fname == eachcontact.GetFirstName())
                {
                    Console.WriteLine("Enter First Name");
                    string firstname = Console.ReadLine();

                    //Here Replacing Old contact to new details
                    eachcontact.SetFirstName(firstname);

                    Console.WriteLine("Enter Last Name");
                    string lastname = Console.ReadLine();
                    eachcontact.SetLastName(lastname);
                    Console.WriteLine("Enter State name");
                    string state = Console.ReadLine();
                    eachcontact.SetState(state);
                    Console.WriteLine("Enter City Name");
                    string city = Console.ReadLine();
                    eachcontact.SetCity(city);
                    Console.WriteLine("Enter Address ");
                    string address = Console.ReadLine();
                    eachcontact.SetAddress(address);
                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();
                    eachcontact.SetEmail(email);
                    Console.WriteLine("Enter Zip Code");
                    int zipcode = int.Parse(Console.ReadLine());
                    eachcontact.SetZipcode(zipcode);
                    Console.WriteLine("Enter Mobile Number");
                    long mobilenumber = Convert.ToInt64(Console.ReadLine());
                    eachcontact.Setmobilenumber(mobilenumber);
                    break;
                    Console.WriteLine("Contact is updated");
                    view();



                }
                else
                {
                    Console.WriteLine("Invalid contact name please try again");

                }
            }

        }

        //Creating method to Delete Contact
        public void DeleteContact()
        {
            //Taking first name as input from the user to check weather this name is existing in contacts list or not
            Console.WriteLine("Enter the First Name of your contact that which contact you wants to Delete");
            string Fname = Console.ReadLine();
            foreach (Address_Book eachcontact in allcontacts)
            {
               //Comparing existing firts name to user entered first name
                if (Fname == eachcontact.GetFirstName())
                {
                    Console.WriteLine("Do you really want to Delete this contact?? type y/n");
                    string key = Console.ReadLine();
                    if(key == "y")
                    {
                        //Removing Contact from the allcontacts list
                        allcontacts.Remove(eachcontact);
                        Console.WriteLine("Contact is Deleted");
                        break;
                        view();
                    }
                    else
                    {
                        Console.WriteLine("Contact does not exist please enter valid name");
                    }
                }
            }
        }
    }
}
