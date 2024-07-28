using Common.Shared.Helpers;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using System.Text.Json;

namespace MockExam.Aggregator.Services
{
    public interface IQuestionService
    {
        Task<DefaultResponse> PostAsync(QuestionRequest request);
        Task<DefaultResponse> PutAsync(UpdQuestionRequest request);
        Task<DefaultResponse> GetByIdAsync(Guid id);
        Task<DefaultResponse> DeleteByIdAsync(Guid id);
        Task<DefaultResponse> GetByMockExam(Guid mockExamId);
    }
    public class QuestionService : IQuestionService
    {
        protected readonly HttpClient _client;
        public QuestionService(HttpClient client)
        {
            _client = client;
        }
        public async Task<DefaultResponse> DeleteByIdAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"mockexams/questions/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"mockexams/questions/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByMockExam(Guid mockExamId)
        {
            var response = await _client.GetAsync($"mockexams/questions?mockExamId={mockExamId}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> PostAsync(QuestionRequest request)
        {
            var response = await _client.PostAsync("mockexams/questions", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> PutAsync(UpdQuestionRequest request)
        {
            var response = await _client.PutAsync("mockexams/questions", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
