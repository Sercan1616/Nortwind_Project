using RestSharp;
using System;
using System.Collections.Generic;

namespace WebApi
{
    public class NorthwindApi
    {
        public List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();

            RestClient getClient = new RestClient("https://northwind.vercel.app/");
            getClient.UseJson();
            RestRequest getRequest = new RestRequest("/api/Products/");
            var getRespons = getClient.Get<Product>(getRequest);

            if (getRespons.StatusCode == System.Net.HttpStatusCode.OK)
            {

                products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(getRespons.Content);

            }

            return products;

        }

        public string PostProduct(Product product)
        {
            var client = new RestClient("https://northwind.vercel.app/api/products");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var cevapData = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            request.AddJsonBody(cevapData);
            request.AddParameter("application/json", cevapData, ParameterType.RequestBody);
            IRestResponse response = client.Post(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception(response.Content);

            return response.Content;


        }

        public string GetProductsById(int id)
        {
            var client = new RestClient(string.Format("https://northwind.vercel.app/api/products/{0}", id));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Get<Product>(request);
            var cevapData = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(response.Content);
            Console.WriteLine(cevapData);

            return cevapData.name;
        }

        public void DeleteProduct(int id)
        {
            var client = new RestClient(string.Format("https://northwind.vercel.app/api/products/{0}", id));
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute<Product>(request);
            // var cevapData = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(response.Content);
            //Console.WriteLine(cevapData);            

        }

        public void UpdateProduct(Product product)
        {
            var client = new RestClient(string.Format("https://northwind.vercel.app/api/products/{0}", product.id));
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            var cevapData = Newtonsoft.Json.JsonConvert.SerializeObject(product);

            request.AddJsonBody(cevapData);
            request.AddParameter("application/json", cevapData, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);


        }
        
    }
}
