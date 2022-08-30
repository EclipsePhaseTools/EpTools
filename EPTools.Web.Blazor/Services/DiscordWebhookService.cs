using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EPTools.Web.Blazor.Services
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
            var url = "https://discord.com/api/webhooks/771012739253534750/ewqVwBcfEFCRRezfP224UybSdFLnirh8B6_zPbB2dQwK6KGTKDhQDWa2XxjRR7wLrQKT";

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
