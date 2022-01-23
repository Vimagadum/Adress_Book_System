using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{

    // Created class Address Book
    public class Address_Book
    {
        List<Address_Book> allcontacts =  new List<Address_Book>();
        // Declaring variables
        string firstname, lastname, state, city, address, email;
        int zipcode;
        long mobilenumber;

        public Address_Book()
        {

        }
        //Creating a constructor ton initialize variables
        public Address_Book(string firstname, string lastname, string state, string city, string address, string email, int zipcode, long mobilenumber)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.state = state;
            this.city = city;
            this.address = address;
            this.email = email;
            this.zipcode = zipcode;
            this.mobilenumber = mobilenumber;
            
        }
        //Method to add contact details
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

            //adding the details in person
           Address_Book contacts = new Address_Book(firstname, lastname, state, city, address, email, zipcode, mobilenumber);

            // adding contacts in list
            allcontacts.Add(contacts);
            Console.WriteLine("Contact is Added");
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
                    if (key == "y")
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
            public String GetFirstName()
        {
            return firstname;
        }
        public void SetFirstName(string firstName)
        {
            this.firstname = firstName;
        }
        public String GetLastName()
        {
            return lastname;
        }
        public void SetLastName(string lastName)
        {
            this.lastname = lastName;
        }
        public String GetCity()
        {
            return city;
        }
        public void SetCity(string city)
        {
            this.city = city;
        }
        public String GetState()
        {
            return state;
        }
        public void SetState(string state)
        {
            this.state = state;
        }
        public String GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public String GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public int GetZipcode()
        {
            return zipcode;
        }
        public void SetZipcode(int zip)
        {
            this.zipcode = zipcode;
        }
        public long Getmobilenumber()
        {
            return mobilenumber;
        }
        public void Setmobilenumber(long mobilenumber)
        {
            this.mobilenumber = mobilenumber;
        }


        //Overrideing string method 
        public override string ToString()
        {
            return ("First Name: " + firstname + " Last Name: " + lastname + " City: " + city + " State: " + state + " Address" + address + " zip: " + zipcode + " Phone Number: " + mobilenumber);
        }

    }
}
