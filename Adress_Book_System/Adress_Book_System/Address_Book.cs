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
