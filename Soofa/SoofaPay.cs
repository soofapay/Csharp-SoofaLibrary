using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Soofa
{
    public class SoofaPay : ISoofaPay
    {

        private readonly Method method;
        private string Url;
        private readonly string _client_secret;
        private readonly string _till_no;
        public Balance GetBalance()
        {
            Url = "https://api.soofapay.com/v1/balance/";
            var response = ServiceRequest();
            return JsonConvert.DeserializeObject<Balance>(response.Item1);
        }
        public Transaction GetTransaction(string transaction_Id)
        {
            Url = $"https://api.soofapay.com/v1/transactions/{transaction_Id}/";
            var response = ServiceRequest();
            return response.Item2==false?null: JsonConvert.DeserializeObject<Transaction>(response.Item1);
        }
        private (string, bool) ServiceRequest()
        {
            var client = new RestClient(Url);
            var request = new RestRequest(method);
            request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Token {_client_secret}");
            request.AddHeader("X-TILL", _till_no);
            IRestResponse response = client.Execute(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return (response.Content, false);
                case HttpStatusCode.OK:
                    return (response.Content, true);
                case HttpStatusCode.Created:
                    return (response.Content, true);
                case HttpStatusCode.Forbidden:
                    throw new SoofaPayException("Authentication Credentials are wrong or Not Provided");
                default:
                    throw new SoofaPayException(response.Content);
            }

        }
        //Check Balance
        public SoofaPay( string till_no, string client_secret)
        {
            _client_secret = client_secret;
            _till_no = till_no;
            method = Method.GET;
        }



    }
}
