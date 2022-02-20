// See https://aka.ms/new-console-template for more information
using AddressBookSystem;
using Adress_Book_System;
using System.Collections;

namespace Adress_Book_System
{
    class Program
    {
        //fileIO path
        public static string filePath = @"D:\Adress_Book\Adress_Book_System\Adress_Book_System\Adress_Book_System\Contactss.txt";
       
        //Method to perform all operation on contacts
        public static void AddressBook(Address_Book cont)
        {
            bool flag = true;
            int choice;
            //Menu to display for the user
            while (flag)
            {
                //tryblock to check if any  exception occur
                try
                {
                    Console.WriteLine("\n1. Display All Contacts\n2. Add New Contact\n3. Edit Contact\n4. Delete Contact\n5.sortBYNmae\n6.SortByCity\n7.SortByState\n8.SortByZipCode\n9.Exit");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        cont.view();
                    }
                    else if (choice == 2)
                    {
                        cont.AddDetails();
                    }
                    else if (choice == 3)
                    {
                        cont.EditContact();
                    }
                    else if (choice == 4)
                    {
                        cont.DeleteContact();
                    }
                    else if (choice == 5)
                    {
                        cont.SortByName();
                    }
                    else if (choice == 6)
                    {
                        cont.SortByCity();
                    }
                    else if (choice == 7)
                    {
                        cont.SortByState();
                    }
                    else if (choice == 8)
                    {
                        cont.SortByZipCode();
                    }
                    else if (choice == 9)
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                //handling the occured exception And print to console
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message + "\n" + e.StackTrace);
                }
            }
        }
        public static void Main(string[] args)
        {
            AddressBookRepo repo = new AddressBookRepo();
            repo.GetAllContacts();
            AddressDetails addressDetails = new AddressDetails();

            bool flag = true;
            int choice;
            while (flag)
            {
                //Exception Handling
                try
                {
                    Console.WriteLine("\n1. Create New Address Book \n2. Use Existing Address Book   \n3. Display all Address book \n4. person by city \n5. person by state \n6. write Contacts to Text File \n7. read from text file \n8. Add In CSV\n9.write and read in Json\n10.GetAllContactsFromDataBase\n11.update contact in data base\n12.AddDateField\n13. RetrieveByCityOrState\n14.AddNewContact\n15. Exit");
                    choice = int.Parse(Console.ReadLine());
                    //creating new address book
                    if (choice == 1)
                    {
                        Address_Book contact = new Address_Book();
                        Console.WriteLine("\nEnter New Address Book Name: ");
                        string addressBookName = Console.ReadLine();
                        addressDetails.AddNewAddressBook(addressBookName, contact);
                        Console.WriteLine("created " + addressBookName + "\tusing Address Book " + addressBookName);
                        AddressBook(contact);

                    }
                    //using existing address book
                    else if (choice == 2)
                    {
                        Console.Write("\nEnter Address Book Name: ");
                        string addressBookName = Console.ReadLine();
                        Address_Book contact = addressDetails.GetAddressBook(addressBookName);
                        if (contact != null)
                        {
                            Console.WriteLine("using Address Book " + addressBookName);
                            AddressBook(contact);
                        }
                        else
                        {
                            Console.WriteLine("There is no book with name " + addressBookName);
                        }

                    }
                    else if (choice == 3)
                    {
                        addressDetails.DisplayAllAddressBook();
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("enter city to search contacts by city");
                        string city = Console.ReadLine();
                        addressDetails.SetContactByCityDictionary(city);
                        //count of contacts in each city
                        foreach (var conByCity in addressDetails.ContactByCity)
                        {
                            Console.WriteLine("City :" + conByCity.Key + "   Count :" + conByCity.Value.Count);

                        }
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("enter state to search contacts by state");
                        string state = Console.ReadLine();
                        addressDetails.SetContactByStateDictionary(state);
                        //count of contacts in each state
                        foreach (var conByState in addressDetails.ContactByState)
                        {
                            Console.WriteLine("State :" + conByState.Key + "   Count :" + conByState.Value.Count);

                        }
                    }
                    // writing to text file if file exists
                    else if (choice == 6)
                    {
                        if (File.Exists(filePath))
                        {
                            using (StreamWriter stw = File.CreateText(filePath))
                            {
                                foreach (KeyValuePair<string, Address_Book> kv in addressDetails.getAllAddressBook())
                                {
                                    string a = kv.Key;

                                    stw.WriteLine("Address Book Name: " + a);
                                    foreach (Address_Book c in kv.Value.getContacts())
                                    {
                                        stw.WriteLine(c);
                                    }
                                }
                                Console.WriteLine("Address Book written into the file successfully!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                    }
                    else if (choice == 7)
                    {
                        //reading from text file if Exists
                        if (File.Exists(filePath))
                        {
                            using (StreamReader str = File.OpenText(filePath))
                            {
                                string s = "";
                                while ((s = str.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("File doesn't exist!!!");
                        }
                    }
                    else if (choice == 8)
                    {
                        Console.WriteLine("Enter the Address Book Name:");
                        string name = Console.ReadLine();
                        var allbooks = addressDetails.getAllAddressBook();
                        if (allbooks.ContainsKey(name))
                        {
                            CSVHandler.WriteIntoCSVFile(allbooks, name);
                            Console.WriteLine("Data inserted successfully");
                            CSVHandler.ReadFromCSVFile();
                            Console.WriteLine("Data read successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                    }
                    else if (choice == 9)
                    {
                        Console.WriteLine("Enter the Address Book Name:");
                        string nameJSON = Console.ReadLine();
                        var allbooks = addressDetails.getAllAddressBook();
                        if (allbooks.ContainsKey(nameJSON))
                        {
                            JsonHandler.WriteIntoJSONFile(allbooks, nameJSON);
                            Console.WriteLine("Data inserted successfully");
                            JsonHandler.ReadFromJSONFile();
                            Console.WriteLine("Data read successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book Name Not Found");
                        }
                    }
                    
                    else if(choice == 10)
                    {
                        AddressBookRepo ad = new AddressBookRepo();
                        ad.GetAllContacts();
                    }
                    else if (choice == 11)
                    {
                        AddressBookRepo ad = new AddressBookRepo();
                        ad.UpdateContactToDatabase();
                    }
                    else if (choice == 12)
                    {
                        AddressBookRepo ad = new AddressBookRepo();
                        ad.AddDateField();
                    }
                    else if (choice == 13)
                    {
                        AddressBookRepo ad = new AddressBookRepo();
                        ad.RetrieveByCityOrState();
                    }
                    else if (choice == 14)
                    {
                        AddressBookRepo ad = new AddressBookRepo();
                        ad.AddNewContact();
                    }
                    else if (choice == 15)
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                // catch block to handle exception
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data entered. Error: " + e.Message + "\n" + e.StackTrace);
                }
            }
        }
    } 
}


