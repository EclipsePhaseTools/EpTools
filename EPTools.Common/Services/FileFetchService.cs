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

        public async Task<T> GetTFromFileAsync<T>(string filename) where T : new()
        {
            filename = filename.ToLower();

            if (!System.IO.File.Exists($"data/{filename}.json"))
            {
                return new T();
            }

            var item = new T();

            using (var textstream = new FileStream($"data/{filename}.json", FileMode.Open))
            {
                item = await JsonSerializer.DeserializeAsync<T>(textstream);

                if (item == null)
                {
                    throw new NullReferenceException();
                }
            }

            return item;
        }

        public async Task<T> GetTFromEPFileAsync<T>(string filename) where T : new()
        {
            filename = filename.ToLower();

            if (!System.IO.File.Exists($"./data/EP-Data/{filename}.json"))
            {
                return new T();
            }

            var item = new T();

            using (var textstream = new FileStream($"data/EP-Data/{filename}.json", FileMode.Open))
            {
                item = await JsonSerializer.DeserializeAsync<T>(textstream);

                if (item == null)
                {
                    throw new NullReferenceException();
                }
            }

            return item;
        }
    }
}
