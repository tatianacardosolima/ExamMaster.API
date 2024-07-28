using Common.Shared.Helpers;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using System.Text.Json;

namespace MockExam.Aggregator.Services
{
    public interface IAnswerService
    {
        Task<DefaultResponse> PostAsync(AnswerRequest request);
        Task<DefaultResponse> PutAsync(UpdAnswerRequest request);
        Task<DefaultResponse> GetByIdAsync(Guid id);
        Task<DefaultResponse> DeleteByIdAsync(Guid id);
        Task<DefaultResponse> GetByQuestion(Guid questionId);
    }
    public class AnswerService : IAnswerService
    {
        protected readonly HttpClient _client;
        public AnswerService(HttpClient client)
        {
            _client = client;
        }
        public async Task<DefaultResponse> DeleteByIdAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"mockexams/questions/answers/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync($"mockexams/questions/answers/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByQuestion(Guid questionId)
        {
            var response = await _client.GetAsync($"mockexams/questions/answers/?questionId={questionId}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> PostAsync(AnswerRequest request)
        {
            var response = await _client.PostAsync("mockexams/questions/answers", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> PutAsync(UpdAnswerRequest request)
        {
            var response = await _client.PutAsync("mockexams/questions", JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
