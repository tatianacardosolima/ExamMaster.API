using Common.Shared.Helpers;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using System.Text.Json;

namespace MockExam.Aggregator.Services
{
    public interface IMockExamService
    {
        Task<DefaultResponse> PostAsync(MockRequest request);
        Task<DefaultResponse> PutAsync(MockRequest request);
        Task<DefaultResponse> GetByIdAsync(Guid id);
        Task<DefaultResponse> DeleteByIdAsync(Guid id);
        Task<DefaultResponse> GetByFilter(string filter);

    }
    public class MockExamService: IMockExamService
    {
        protected readonly HttpClient _client;
        public MockExamService(HttpClient client)
        {
            _client = client;
        }
        public async Task<DefaultResponse> PostAsync(MockRequest request)
        {
            var response = await _client.PostAsync("mockexams", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<DefaultResponse> PutAsync(MockRequest request)
        {
            var response = await _client.PutAsync("mockexams", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"mockexams/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByFilter(string filter)
        {
            var response = await _client.GetAsync($"mockexams?filter={filter}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> DeleteByIdAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"mockexams/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }

    
}
