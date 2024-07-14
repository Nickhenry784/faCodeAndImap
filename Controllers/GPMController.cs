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
    public class GPMController
    {

        Utils utils = new Utils();
        public async Task<CreateProfileResult> createProfile(string proxy, int thread)
        {
            string Base_url = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Data\apiURL.txt");
            var options = new RestClientOptions(Base_url + "/api/v3/profiles/create");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = RestSharp.DataFormat.Json;
            CreateProfile createProfile = new CreateProfile();
            string name = utils.RemoveSpecialCharacters(Faker.Name.First()) + " " + utils.RemoveSpecialCharacters(Faker.Name.Last());
            createProfile.profile_name = name;
            createProfile.raw_proxy = proxy;
            string rawJson = JsonConvert.SerializeObject(createProfile);
            request.AddParameter("application/json", rawJson, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                CreateProfileResult createProfileResult = JsonConvert.DeserializeObject<CreateProfileResult>(response.Content);
                while (!createProfileResult.success)
                {
                    Thread.Sleep(1000 * thread);
                    response = await client.ExecuteAsync(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        createProfileResult = JsonConvert.DeserializeObject<CreateProfileResult>(response.Content);
                    }
                }
                return createProfileResult;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> changeProxy(string id, string proxy)
        {
            string Base_url = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Data\apiURL.txt");
            var options = new RestClientOptions(Base_url + "/api/v3/profiles/update/" + id);
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = RestSharp.DataFormat.Json;
            ChangeProxyModel changeProxy = new ChangeProxyModel();
            string name = utils.RemoveSpecialCharacters(Faker.Name.First()) + " " + utils.RemoveSpecialCharacters(Faker.Name.Last());
            changeProxy.profile_name = name;
            changeProxy.raw_proxy = proxy;
            string rawJson = JsonConvert.SerializeObject(changeProxy);
            request.AddParameter("application/json", rawJson, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<OpenProfileResult> openBrowser(string profileId, string win_pos)
        {
            string Base_url = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Data\apiURL.txt");
            var options = new RestClientOptions(Base_url + "/api/v3/profiles/start/" + profileId + "?win_scale=0.8&win_pos=" + win_pos + "&win_size=400,400&addination_args=--blink-settings=imagesEnabled=false");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                OpenProfileResult openProfileResult = JsonConvert.DeserializeObject<OpenProfileResult>(response.Content);
                return openProfileResult;
            }
            else
            {
                return null;
            }
        }

        public async Task<CreateProfileResult> closeBrowser(string profileId)
        {
            string Base_url = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Data\apiURL.txt");
            var options = new RestClientOptions(Base_url + "/api/v3/profiles/close/" + profileId);
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                CreateProfileResult createProfileResult = JsonConvert.DeserializeObject<CreateProfileResult>(response.Content);
                return createProfileResult;
            }
            else
            {
                return null;
            }
        }

        public async Task<DeleteProfileResult> deleteProfile(string profileId)
        {
            string Base_url = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Data\apiURL.txt");
            var options = new RestClientOptions(Base_url + "/api/v3/profiles/delete/" + profileId + "?mode=2");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                DeleteProfileResult deleteProfileResult = JsonConvert.DeserializeObject<DeleteProfileResult>(response.Content);
                return deleteProfileResult;
            }
            else
            {
                return null;
            }
        }
    }
}
