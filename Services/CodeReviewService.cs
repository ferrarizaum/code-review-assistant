using CodeReviewAssistant.DTO;

namespace CodeReviewAssistant.Services
{
    public interface ICodeReviewService
    {
        Task<Guid> ReviewCodeAsync(string code);
        Task<ReviewResultDTO> GetReviewResultDTOsAsync(Guid id);
    }

    public class CodeReviewService : ICodeReviewService
    {
        private readonly IAIReviewEngine _aiReviewEngine;

        public CodeReviewService(IAIReviewEngine aiReviewEngine)
        {
            _aiReviewEngine = aiReviewEngine;
        }

        public async Task<Guid> ReviewCodeAsync(string code)
        {
            var result = await _aiReviewEngine.AnalyzeCodeAsync(code);
            var resultId = Guid.NewGuid();

            // Save result to the database (not shown here)
            // ...
            Console.WriteLine(result.Feedback);
            return resultId;
        }

        public async Task<ReviewResultDTO> GetReviewResultDTOsAsync(Guid id)
        {
            // Fetch results from the database (not shown here)
            // ...

            return await Task.FromResult<ReviewResultDTO>(null); // Placeholder
        }
    }

}
