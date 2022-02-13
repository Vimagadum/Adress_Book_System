using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adress_Book_System;

namespace Adress_Book_System
{   
    public class AddressDetails
    {
        //Dictonary to add address book to dictionary    
        Dictionary<string, Address_Book>  addressBookDict = new Dictionary<string, Address_Book>();
        public Dictionary<string, List<Address_Book>> ContactByCity;
        public Dictionary<string, List<Address_Book>> ContactByState;
        public List<string> cities;
        public List<string> states;
        List<Address_Book> con = new List<Address_Book>();

        public AddressDetails()
        {
            addressBookDict = new Dictionary<string, Address_Book>();
            ContactByCity = new Dictionary<string, List<Address_Book>>();
            ContactByState = new Dictionary<string, List<Address_Book>>();
            cities = new List<string>();
            states = new List<string>();

        }
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
        public void DisplayAllAddressBook()
        {

            foreach (var item in addressBookDict)
            {

                Console.WriteLine(item.Key);

            }

        }
        public Dictionary<string, Address_Book> getAllAddressBook()
        {
            return addressBookDict;

        }
        //search contact over multiple addressbook
        public void GetByCityOrState(string cityOrstate)
        {
            //iterate over each addressbook to & search contact by city or state 
            foreach (var item in addressBookDict)
            {
                //assign all address book matching lists to new list
                foreach (Address_Book contact in item.Value.SearchContactByCityOrState(cityOrstate))
                {
                    if (cities.Contains(contact.city) == false)
                    {
                        cities.Add(contact.city);
                    }
                    if (states.Contains(contact.state) == false)
                    {
                        states.Add(contact.state);
                    }
                }

            }
        }
        //set contacts in city dictionary with specific cities
        public void SetContactByCityDictionary(string city)
        {
            GetByCityOrState(city);

            foreach (string c in cities)
            {
                List<Address_Book> contact = new List<Address_Book>();
                foreach (var addressBook in addressBookDict)
                {
                    contact.AddRange(addressBook.Value.SearchContactByCityOrState(city));
                }
                Address_Book.SortByName(contact);
                if (ContactByCity.ContainsKey(c))
                {
                    ContactByCity[c] = contact;
                }
                else
                {
                    ContactByCity.Add(c, contact);
                }
            }
            ViewPersonsByCity(city);
        }
        //set contacts in state dictionary with specific state
        public void SetContactByStateDictionary(string state)
        {
            GetByCityOrState(state);

            foreach (string s in states)
            {
                List<Address_Book> contact = new List<Address_Book>();
                foreach (var addressBook in addressBookDict)
                {
                    contact.AddRange(addressBook.Value.SearchContactByCityOrState(state));
                }
                Address_Book.SortByName(contact);
                if (ContactByState.ContainsKey(s))
                {
                    ContactByState[s] = contact;
                }
                else
                {
                    ContactByState.Add(s, contact);
                }
            }
            ViewPersonsByState(state);
        }
        //view all contacts from city dictionary matching the city key
        public void ViewPersonsByCity(string city)
        {
            Console.WriteLine("Contacts By City");
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Address_Book contact in ContactByCity[city])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zipcode + "\nPhone No :" + contact.mobilenumber + "   Email :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        //view all contacts from state dictionary matching the state key
        public void ViewPersonsByState(string state)
        {
            Console.WriteLine("Contacts By State");
            if (ContactByState.ContainsKey(state))
            {
                foreach (Address_Book contact in ContactByState[state])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zipcode + "\nPhone No :" + contact.mobilenumber + "   Email :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
    }
}
