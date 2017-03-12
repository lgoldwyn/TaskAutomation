using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APITesing

{
    class Program
  {
        private static string Key => "fnCCsYqby0RTFHyouYNGjhqkKhaW2BprneElNcDmCW06EpOsZ0dq1o9HcwaoNFib6biP2ce72jGlgN1yZF6oQ==";
        private static string APIid ="9dcf114f-702d-49da-9455-ad95e7a7d241";
      
        static void Main(string[] args)
            {
               Task.WaitAll(
                        ExecuteAPITests()
                    );
                Console.WriteLine("Test Completed");
                Console.ReadLine();
            }


        //Testing only Get method in API
    static async Task ExecuteAPITests()
    {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.unleashedsoftware.com");
            var getResponse = await ListDeliveryMethod(client);
                getResponse = await ListPaginatedPurchaseOrders(client);
                getResponse = await ListAllSuppliersWithCode(client);
    }

 
        //Executing test on list Delivery Methods
        private static async Task<Customer> ListDeliveryMethod(HttpClient client)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/DeliveryMethods");
            request = CreateHeaders(request);
             var response = await client.SendAsync(request);
            try
            {
                Assert.AreNotEqual(response.StatusCode, HttpStatusCode.NotFound);
                Console.WriteLine("List Delivery Methods Testcase :Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("List Delivery Methods test case: Failed");

            }
                return JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
           
        }


        private static async Task<Customer> ListPaginatedPurchaseOrders(HttpClient client)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/PurchaseOrders/{1}");
            request = CreateHeaders(request);
            var response = await client.SendAsync(request);
            try
            {
                Assert.AreNotEqual(response.StatusCode, HttpStatusCode.NotFound);
                Console.WriteLine("List Purchase Order First Page Testcase :Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("List Purchase Order First Page: Failed");

            }
            return JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

        }

        private static async Task<Customer> ListAllSuppliersWithCode(HttpClient client)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/Customers?customerCode=001");
            request = CreateHeaders(request);

            var response = await client.SendAsync(request);
            try
            {
                Assert.AreNotEqual(response.StatusCode, HttpStatusCode.NotFound);
                Console.WriteLine("List Customers with code 001 :Passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("List Customers with code 001: Failed");

            }
                return JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());

        }

        //Helper Methods
        private static string GetSignature(string args, string privatekey)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] key = encoding.GetBytes(privatekey);
            var myhmacsha256 = new HMACSHA256(key);
            byte[] hashValue = myhmacsha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myhmacsha256.Clear();
            return hmac64;
        }

        public static HttpRequestMessage CreateHeaders(HttpRequestMessage req)
        {
            req.Headers.Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            req.Headers.Add("api-auth-id", APIid);
            req.Headers.Add("api-auth-signature", GetSignature(string.Empty, Key));
            return req;
        }
    }
}
