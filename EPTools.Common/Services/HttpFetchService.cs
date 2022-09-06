using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using EPTools.Common.Interfaces;

namespace EPTools.Common.Services
{
    public class HttpFetchService : IFetchService
    {
        private HttpClient httpClient { get; set; }

        public HttpFetchService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetTFromFileAsync<T>(string filename) where T : new()
        {
            filename = filename.ToLower();

            return await httpClient.GetFromJsonAsync<T>($"data/{filename}.json") ?? new T();
        }

        public async Task<T> GetTFromEPFileAsync<T>(string filename) where T : new()
        {
            filename = filename.ToLower();
            return await httpClient.GetFromJsonAsync<T>($"data/EP-Data/{filename}.json") ?? new T();
        }
    }
}
