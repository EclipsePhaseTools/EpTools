using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EPTools.Common.Services
{
    public class DiscordWebhookService
    {
        private HttpClient HttpClient { get; set; }

        public DiscordWebhookService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async Task SendWebhook()
        {
            var url = "";

            var payload = new StringContent(
                            @"{""content"": ""TEST"", 
	                            ""username"": ""Praxia2"",
	                            ""embeds"":[
		                            {
			                            ""title"":""Rolled Result 5"",
                                        ""description"":""Rolled a thing"",
                                        ""author"": { ""name"": ""Rolled Freefall""},
                                        ""footer"": { ""text"":""Something""}
		                            }
                                ]
                            }", Encoding.UTF8, "application/json"); 
            await HttpClient.PostAsync(url, payload);
        }
    }
}
