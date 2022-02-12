using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{
    public class AddressDetails
    {      
        //Dictonary to add address book to dictionary    
        Dictionary<string, Address_Book>  addressBookDict = new Dictionary<string, Address_Book>();
        //method to add address book
        public void AddNewAddressBook(string addressName, Address_Book addressBook)
        {
            addressBookDict.Add(addressName, addressBook);
        }
        //Method to fetch single address book if it matches user input
        public Address_Book GetAddressBook(string name)
        {
            foreach(var item in addressBookDict)
            {
                if (item.Key== name)
                    return item.Value;
            }
            return null;
        }
        //search contact over multiple addressbook
        public void searchOverMultipleAddressBook()
        {
            Console.WriteLine("enter city or state to search contact");
            string cityOrstate = Console.ReadLine();
            List<Address_Book> con = new List<Address_Book>();
            //iterate over each addressbook to & search contact by city or state 
            foreach (var item in addressBookDict)
            {
                //assign all address book matching lists to new list
                con = item.Value.SearchContactByCityOrState(cityOrstate);

            }
            //iterate over new list & display contacts
            if (con.Count > 0)
            {
                foreach (var item in con)
                {
                    item.view();
                }
            }
        }
    }
}
