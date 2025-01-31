using CodeReviewAssistant.DTO;

namespace CodeReviewAssistant.Services
{
    public interface ICodeReviewService
    {
        //Task<Guid> ReviewCodeAsync(string code);
        Task<string> ReviewCodeAsync(string code);
        Task<ReviewResultDTO> GetReviewResultDTOsAsync(Guid id);
    }

    public class CodeReviewService : ICodeReviewService
    {
        private readonly IAIReviewEngine _aiReviewEngine;

        public CodeReviewService(IAIReviewEngine aiReviewEngine)
        {
            _aiReviewEngine = aiReviewEngine;
        }

        public async /*Task<Guid>*/Task<string> ReviewCodeAsync(string code)
        {
            var result = await _aiReviewEngine.AnalyzeCodeAsync(code);
            var resultId = Guid.NewGuid();

            return result.Feedback;
        }

        public async Task<ReviewResultDTO> GetReviewResultDTOsAsync(Guid id)
        {

            return await Task.FromResult<ReviewResultDTO>(null); // Placeholder
        }
    }

}
