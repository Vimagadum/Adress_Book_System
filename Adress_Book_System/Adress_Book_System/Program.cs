// See https://aka.ms/new-console-template for more information
using Adress_Book_System;

Console.WriteLine("WELCOME TO ADRESS BOOK SYSTEM");

// Creating object of class to call the methods
AddressDetails addressdetails = new AddressDetails();


string key = "a";

//Creating while loop to repeat the process untill the user done with his work of adding and displaying
while (key != "n")
{
    //Asking user to select one option to Add or Display
    Console.WriteLine("Select option");
    Console.WriteLine("1-Add Contact, 2-Display Contact,3-Edit Contact,4-Delete Contact");
    // Creating num variable to store the use input of the option
   int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        //If the user selects for 1 the here we are calling AddDetails method to add contacts
        case 1:
            addressdetails.AddDetails();
            break;
        //If the user selects for 2 the here we are calling list method to list all contacts
        case 2:
            addressdetails.view();
            break;
        case 3:
            addressdetails.EditContact();
            break;
        case 4:
            addressdetails.DeleteContact();
            break;
    }
    Console.WriteLine("Do you want to Add, Edit, Delete or List the Contact?? preass y/n");
    key= Console.ReadLine();
}
Console.ReadLine();



