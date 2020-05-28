using Domain.Model;
using Domain.Model.Interfaces.Services;
using Domain.Model.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMVC.HttpServices
{
    public class ProfileHttpService : IProfileService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptionsMonitor<UserHttpOptions> _userHttpOptions;
        private readonly HttpClient _httpClient;

        public ProfileHttpService(
            IHttpClientFactory httpClientFactory,
            IOptionsMonitor<UserHttpOptions> userHttpOptions)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _userHttpOptions = userHttpOptions ?? throw new ArgumentNullException(nameof(userHttpOptions));
            _httpClient = httpClientFactory.CreateClient(userHttpOptions.CurrentValue.Name); _httpClient.Timeout = TimeSpan.FromMinutes(_userHttpOptions.CurrentValue.Timeout);
        }
        public async Task<IEnumerable<ProfileEntity>> GetAllAsync()
        {
            var result = await _httpClient.GetStringAsync(_userHttpOptions.CurrentValue.ProfilePath); 
            return JsonConvert.DeserializeObject<List<ProfileEntity>>(result);
        }

        public async Task<ProfileEntity> GetByIdAsync(int id)
        {
            var pathWithId = $"{_userHttpOptions.CurrentValue.ProfilePath}/{id}"; 
            var result = await _httpClient.GetStringAsync(pathWithId); 
            return JsonConvert.DeserializeObject<ProfileEntity>(result);
        }

        public async Task InsertAsync(ProfileEntity insertedEntity)
        {
            var uriPath = $"{_userHttpOptions.CurrentValue.ProfilePath}"; 
            var httpContent = new StringContent(JsonConvert.SerializeObject(insertedEntity), Encoding.UTF8, "application/json"); 
            await _httpClient.PostAsync(uriPath, httpContent);
        }

        public async Task UpdateAsync(ProfileEntity updatedEntity)
        {
            var pathWithId = $"{_userHttpOptions.CurrentValue.ProfilePath}/{updatedEntity.Id}"; 
            var httpContent = new StringContent(JsonConvert.SerializeObject(updatedEntity), Encoding.UTF8, "application/json"); 
            await _httpClient.PutAsync(pathWithId, httpContent);
        }
    }
}
