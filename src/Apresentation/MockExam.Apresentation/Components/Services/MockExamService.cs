using Common.Shared.Helpers;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using System.Text.Json;

namespace MockExam.Apresentation.Components.Services
{
    public interface IMockExamService
    {
        Task<DefaultResponse> PostAsync(MockRequest request);
        Task<DefaultResponse> PutAsync(UpdMockRequest request);
        Task<DefaultResponse> GetByIdAsync(Guid id);
        Task<DefaultResponse> DeleteByIdAsync(Guid id, string uri);

    }
    public class MockExamService
    {
        protected readonly HttpClient _client;
        public MockExamService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<DefaultResponse> PostAsync(MockRequest request)
        {
            var response = await _client.PostAsync("mockexmas", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<DefaultResponse> PutAsync(UpdMockRequest request)
        {
            var response = await _client.PutAsync("mockexams", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"mockexams/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> DeleteByIdAsync(Guid id, string uri)
        {
            var response = await _client.DeleteAsync($"{uri}/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
