using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models.DTO;

namespace WebApp.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/Banking";//TO DO: Move to appsettings
            var content = new StringContent(
                JsonConvert.SerializeObject(transferDto),
                System.Text.Encoding.UTF8,
                "application/json"
                );
            var response = await _apiClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
