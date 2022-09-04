using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using EPTools.Common.Interfaces;

namespace EPTools.Common.Services
{
    public class FileFetchService : IFetchService
    {
        public FileFetchService()
        {

        }

        public async Task<T> GetTFromFileAsync<T>(string filename)
        {
            filename = filename.ToLower();

            var textstream = new FileStream($"data/{filename}.json", FileMode.Open);

            var item = await JsonSerializer.DeserializeAsync<T>(textstream);

            if (item == null)
            {
                throw new NullReferenceException();
            }

            return item;
        }

        public async Task<T> GetTFromEPFileAsync<T>(string filename)
        {
            filename = filename.ToLower();

            var textstream = new FileStream($"data/EP-Data/{filename}.json", FileMode.Open);

            var item = await JsonSerializer.DeserializeAsync<T>(textstream);

            if (item == null)
            {
                throw new NullReferenceException();
            }

            return item;
        }
    }
}
