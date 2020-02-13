using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    internal class PingService
    {
        private readonly HttpClient _client;
        private HttpClient _authClient;

        public PingService()
        {
            _authClient = new HttpClient();
            _client = new HttpClient();
        }

        public async Task<string> PingAsync()
        {
            var authUri = new Uri("https://mytog.auth0.com/oauth/token");
            HttpContent authContent = new StringContent("");
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type","authorization_code"));
            nvc.Add(new KeyValuePair<string, string>("client_id", ""));
            nvc.Add(new KeyValuePair<string, string>("code_verified", ""));
            nvc.Add(new KeyValuePair<string, string>("code", ""));
            nvc.Add(new KeyValuePair<string, string>("redirect_uri", ""));

            var authResponse = await _authClient.PostAsync(authUri, authContent); 


            var uri = new Uri(string.Format("https://mytog.localtunnel.me/ping", string.Empty));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }

            throw new ApplicationException("Ping error.");
        }
    }
}