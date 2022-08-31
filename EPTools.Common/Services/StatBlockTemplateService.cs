using EPTools.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPTools.Common.Services
{
    public class StatBlockTemplateService
    {
        private FetchService FetchService { get; set; }
        public StatBlockTemplateService(FetchService fetchService)
        {
            this.FetchService = fetchService;
        }

        public async Task<List<StatBlockTemplate>> GetStatBlockTemplates()
        {
            return await FetchService.GetTFromFileAsync<List<StatBlockTemplate>>("StatBlockTemplates");
        }
    }
}
