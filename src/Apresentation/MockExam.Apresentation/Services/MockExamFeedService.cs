using Common.Shared.Responses;
using System.Text.Json;

namespace MockExam.Apresentation.Services
{
    public interface IMockExamFeedService
    {
    }

    public class MockExamFeedService
    {
        protected readonly HttpClient _client;
        public MockExamFeedService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<DefaultResponse> GetMockExams(string filter)
        {
            var response = await _client.GetAsync($"mockexams?filter={filter}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
