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
        //decclaring variabls
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int zipcode { get; set; }
        public long mobilenumber { get; set; }

       public List<Address_Book> allcontacts =  new List<Address_Book>();
                
        //Creating a constructor ton initialize variables
        public Address_Book(string firstName, string lastName, string state, string city, string address, string email, int zipcode, long mobilenumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.state = state;
            this.city = city;
            this.address = address;
            this.email = email;
            this.zipcode = zipcode;
            this.mobilenumber = mobilenumber;
            
        }
        public Address_Book()
        {

        }
        //Overrideing string method 
        public override string ToString()
        {
            return ("First Name: " + firstName + " Last Name: " + lastName + " City: " + city + " State: " + state + " Address" + address + " zip: " + zipcode + " Phone Number: " + mobilenumber);
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
                        
            if (CheckName(firstname, mobilenumber))
            {
                Console.WriteLine("contact already exists, please give another name or number");
                AddDetails();
            }
            else
            {
                //add contact to list if does not exist already
                Address_Book contact = new Address_Book(firstname, lastname, city, state, address, email, zipcode, mobilenumber);
                Console.WriteLine("contact added: " + contact);
                allcontacts.Add(contact);
                Console.WriteLine("Contact has been added successfully");

            }
            SortByName(allcontacts);
        }
        //Writing method to Display all contacts
        public void view()
        {
            if (allcontacts.Count == 0)
            {
                Console.WriteLine("there are no contacts to display");
            }
            else
            {
                //foreach loop to iterate all contacts from list & print
                Console.WriteLine("Displaying Contacts");
                foreach (Address_Book contact in allcontacts)
                {
                    Console.WriteLine(contact);
                }
            }           
        }
        public List<Address_Book> getContacts()
        {
            if (allcontacts.Count == 0)
            {
                return null;
            }
            else
            {
                //foreach loop to iterate all contacts from list & print
                return allcontacts;
            }
        }
        // method to edit contact
        public void EditContact()
        {
            Console.WriteLine("Enter first Name of contact u want to edit");
            string fName = Console.ReadLine();
            foreach (Address_Book eachContact in allcontacts)
            {
                //compare if user entered firtname exist in the contact-list if it exits then let user edit contact
                if (fName == eachContact.firstName)
                {
                    Console.WriteLine("Enter First Name : ");
                    string firstName = Console.ReadLine();
                    eachContact.firstName = firstName;
                    Console.WriteLine("Enter Last Name : ");
                    string lastName = Console.ReadLine();
                    eachContact.lastName = lastName;
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    eachContact.city = city;
                    Console.WriteLine("Enter state Name : ");
                    string state = Console.ReadLine();
                    eachContact.state = state;
                    Console.WriteLine("Enter Address Name : ");
                    string address = Console.ReadLine();
                    eachContact.address = address;
                    Console.WriteLine("Enter zip-code : ");
                    int zip = Convert.ToInt32(Console.ReadLine());
                    eachContact.zipcode = zip;
                    Console.WriteLine("Enter Phone number : ");
                    long phoneNumber = Convert.ToInt64(Console.ReadLine());
                    eachContact.mobilenumber = phoneNumber;
                    Console.WriteLine("Contact has been Updated successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("invalid contact name, Please check & try again");
                    break;
                }
            }
        }
        //method to delete Contact from Contact-list
        public void DeleteContact()
        {
            Console.WriteLine("Enter first Name of contact u want to delete");
            string fName = Console.ReadLine();
            foreach (Address_Book eachContact in allcontacts)
            {
                //compare if user entered firtname exist in the contact-list if it exits then delete the contact object from list
                if (fName == eachContact.firstName)
                {
                    Console.WriteLine("do u really want to delete this contact? Press y/n");
                    string key = Console.ReadLine();
                    if (key == "y")
                    {
                        allcontacts.Remove(eachContact);
                        Console.WriteLine("contact has been deleted");
                        break;
                    }
                }

                Console.WriteLine("contact does not exist, please enter valid contact First Name");
            }
        }
        // return true if contact already exists(check for duplicate)
        public bool CheckName(string frstName, long phhone)
        {
            foreach (Address_Book c in allcontacts)
            {
                if (c.firstName.Equals(frstName) || c.mobilenumber.Equals(phhone))
                {
                    return true;
                }
            }
            return false;
        }
        //serach contact by city or state
        public List<Address_Book> SearchContactByCityOrState(string cityOrstate)
        {
            List<Address_Book> con = new List<Address_Book>();
            foreach (var contact in allcontacts)
            {
                //check if city or state match
                if (contact.city == cityOrstate || contact.state == cityOrstate)
                {
                    //adding each contact to new list if matches
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zipcode + "\nPhone No :" + contact.mobilenumber + "   email Id :" + contact.email);
                    con.Add(contact);
                }
            }
            return con;
        }
        //sort by name default List
        public void SortByName()
        {
            allcontacts.Sort((contact1, contact2) => contact1.firstName.CompareTo(contact2.firstName));
            foreach (Address_Book c in allcontacts)
            {
                Console.WriteLine(c.ToString());

            }
        }

        //sort by Name with paramater list
        public static void SortByName(List<Address_Book> ContactList)
        {
            ContactList.Sort((contact1, contact2) => contact1.firstName.CompareTo(contact2.firstName));
            foreach (Address_Book c in ContactList)
            {
                Console.WriteLine(c.ToString());

            }
        }
        public void SortByCity()
        {
            allcontacts.Sort((contact1, contact2) => contact1.city.CompareTo(contact2.city));
            foreach (Address_Book c in allcontacts)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void SortByState()
        {
            allcontacts.Sort((contact1, contact2) => contact1.state.CompareTo(contact2.state));
            foreach (Address_Book c in allcontacts)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void SortByZipCode()
        {
            allcontacts.Sort((contact1, contact2) => contact1.zipcode.CompareTo(contact2.zipcode));
            foreach (Address_Book c in allcontacts)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}

