using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{
    // Created class 
    public class Address_Book
    {
        // Declaring variables
        string firstname, lastname, state, city, address, email;
        int zipcode;
        long mobilenumber;

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

        //Implimenting seter and geter
        public string GetFirstName()
        {
            return firstname;
        }
        public void SetFirstName(string firstname)
        {
           this.firstname = firstname;
        }
        public string GetLastName()
        {
            return lastname;
        }
        public void SetLastName(string lastname)
        {
           this.lastname = lastname;
        }
        public string GetState()
        {
            return state;
        }
        public void SetState(string state)
        {
            this.state = state;
        }
        public string GetCity()
        {
            return city;
        }
        public void SetCity(string city)
        {
           this.city = city;
        }
        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
           this.address = address;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
           this.email = email;
        }
        public int GetZipCode()
        {
            return zipcode;
        }
        public void SetZipCode(int zipcode)
        {
           this.zipcode = zipcode;
        }
        public long GetMobileNumber()
        {
            return mobilenumber;
        }
        public void SetMobileNumber(long mobilenumber)
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
