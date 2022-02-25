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
        [TestMethod]
        public void GivenAddressBook_DoPost_ShouldReturnAddedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/AddressBook", Method.Post);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
            new
            {

                firstname = "mac",
                lastname = "pillar",
                address = "chennai",
                city = "chennai",
                state = "TamilNadu",
                zip = "521654",
                phone = "987654321",
                email = "mac@gmail.com"

            });
            // act
            RestResponse response = client.ExecuteAsync(request).Result;

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("mac", dataResponse.firstName);
            Assert.AreEqual("pillar", dataResponse.lastName);
            Assert.AreEqual("chennai", dataResponse.address);
            Assert.AreEqual("chennai", dataResponse.city);
            Assert.AreEqual("TamilNadu", dataResponse.state);
            Assert.AreEqual("521654", dataResponse.zipCode);
            Assert.AreEqual("987654321", dataResponse.phoneNumber);
            Assert.AreEqual("mac@gmail.com", dataResponse.email);
        }
        [TestMethod]
        public void GivenAddressBook_OnPut_ShouldReturnUpdatedAddressDetails()
        {
            // arrange
            RestRequest request = new RestRequest("/AddressBook/2", Method.Put);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
            new
            {
                firstname = "rohit",
                lastname = "king",
                address = "mumbai",
                city = "mumbai",
                state = "maharashtra",
                zip = 567289,
                phone = 9988776655,
                email = "rohit@musk.com"

            });
            // act
            RestResponse response = client.ExecuteAsync(request).Result;

            // assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("rohit", dataResponse.firstName);
            Assert.AreEqual("rohit@musk.com", dataResponse.email);
        }
    }
}
