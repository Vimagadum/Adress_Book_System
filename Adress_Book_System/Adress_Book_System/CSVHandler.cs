using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using CsvHelper;
using Adress_Book_System;

namespace AddressBookSystem
{
    public class CSVHandler
    {
        //CSV path
        static string filePathCSV = @"D:\Adress_Book\Adress_Book_System\Adress_Book_System\Adress_Book_System\Contactsss.csv";
        //
        public static void WriteIntoCSVFile(Dictionary<string, Address_Book> sorted, string bookName)
        {
            foreach (KeyValuePair<string, Address_Book> kv in sorted)
            {
                string bookpath = kv.Key;
                Address_Book contacts = kv.Value;
                
                //checkking path matches or not
                if (bookpath.Equals(bookName))
                {
                    using (StreamWriter stw = new StreamWriter(filePathCSV))
                    {
                        using (CsvWriter writer = new CsvWriter(stw, CultureInfo.InvariantCulture))
                        {
                            //write into csv
                            writer.WriteRecords(contacts.getContacts());
                        }
                    }
                }
            }
        }
        //
        public static void ReadFromCSVFile()
        {
            Console.WriteLine("Reading from CSV File");

            using (StreamReader str = new StreamReader(filePathCSV))
            {
                using (CsvReader reader = new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = reader.GetRecords<Address_Book>().ToList();

                    foreach (Address_Book c in records)
                    {
                        Console.WriteLine(c);
                    }
                }
            }
        }
    }
}
