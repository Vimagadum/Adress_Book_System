using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress_Book_System
{
    public class JsonHandler
    {
        static string filePathJSON = @"D:\Adress_Book\Adress_Book_System\Adress_Book_System\Adress_Book_System\Contactsss.json";

        // method to write into json
        public static void WriteIntoJSONFile(Dictionary<string, Address_Book> allbooks, string bookName)
        {
            Console.WriteLine("Writing Data into JSON File");
            //iterate over all address books
            foreach (KeyValuePair<string, Address_Book> kv in allbooks)
            {
                string book = kv.Key;
                var contacts = kv.Value.getContacts();

                //check if book matches
                if (book.Equals(bookName))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                    using (StreamWriter stw = new StreamWriter(filePathJSON))
                    {
                        //write into json file
                        using (JsonTextWriter writer = new JsonTextWriter(stw))
                        {
                            serializer.Serialize(writer, contacts);
                        }
                    }
                }
            }
        }

        //read from json file
        public static void ReadFromJSONFile()
        {
            Console.WriteLine("Reading Data from JSON File");

            //JsonConvert is from JSON.NET Library, deserialize objects & mapping to list of Contacts objects
            List<Address_Book> records = JsonConvert.DeserializeObject<List<Address_Book>>(File.ReadAllText(filePathJSON));

            foreach (Address_Book record in records)
            {
                Console.WriteLine(record);
            }
        }

    }
}
