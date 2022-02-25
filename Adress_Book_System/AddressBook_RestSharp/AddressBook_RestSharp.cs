using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace AddressBook_RestSharp
{
    public class Contacts
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
    [TestClass]
    public class AddressBook_RestSharp
    {
        
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:3000");
        }
        private RestResponse GetAddressList()
        {
            // arrange
            RestRequest request = new RestRequest("/AddressBook", Method.Get);

            // act
            RestResponse response = client.ExecuteAsync(request).Result;
            return response;
        }

        [TestMethod]
        public void OnCallingGETApi_ReturnAddressList()
        {
            RestResponse response = GetAddressList();

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook_RestSharp> dataResponse = JsonConvert.DeserializeObject<List<AddressBook_RestSharp>>(response.Content);
            Assert.AreEqual(1, dataResponse.Count);
        }
    }
}
