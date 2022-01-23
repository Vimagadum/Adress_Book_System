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
        //Dictonary to add address book to dictionary    
        Dictionary<string, Address_Book>  addressBookDict = new Dictionary<string, Address_Book>();
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
    }
}
