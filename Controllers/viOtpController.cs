using faCodeAndImap.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Controllers
{
    public class viOtpController
    {
        Utils utils = new Utils();
        string Base_url = "https://api.viotp.com";

        public async Task<int> getBalance(string token)
        {
            var options = new RestClientOptions(Base_url + "/users/balance?token=" + token);
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                GetBalance balance = JsonConvert.DeserializeObject<GetBalance>(response.Content);
                return balance.data.balance;
            }
            else
            {
                return -1;
            }
        }

        public async Task<EmploySim> getEmployService(string token)
        {
            var options = new RestClientOptions(Base_url + "/request/getv2?token=" + token + "&serviceId=3");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                EmploySim employSim = JsonConvert.DeserializeObject<EmploySim>(response.Content);
                return employSim;
            }
            else
            {
                return null;
            }
        }

        public async Task<GetCodeOtp> getCodeOtp(string token, string request_id)
        {
            var options = new RestClientOptions(Base_url + "/session/getv2?requestId=" + request_id + "&token=" + token);
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                GetCodeOtp codeOtp = JsonConvert.DeserializeObject<GetCodeOtp>(response.Content);
                return codeOtp;
            }
            else
            {
                return null;
            }
        }
    }
}
