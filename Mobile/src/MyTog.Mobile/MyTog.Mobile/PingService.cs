using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;
using Newtonsoft.Json;

namespace Kalinkin.MyTog.Mobile
{
    internal class PingService
    {
        private readonly IAccessTokenLifetimeStore _tokenLifetimeStore;
        private readonly HttpClient _client;
        private HttpClient _authClient;

        public PingService(IAccessTokenLifetimeStore tokenLifetimeStore)
        {
            _tokenLifetimeStore = tokenLifetimeStore;
            _client = new HttpClient();
        }

        public async Task<string> PingAsync()
        {
            var url = string.Format("https://mytog.localtunnel.me/ping");
            var tokens = await _tokenLifetimeStore.GetAllItems();
            if (!tokens.Any())
            {
                throw new ApplicationException("There is no access token to call API");
            }

            var token = tokens.OrderByDescending(t => t.AuthenticationTime).First();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);


            var resp = await client.GetAsync(url);

            return resp.Content.ToString();
        }
    }
}