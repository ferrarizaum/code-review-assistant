using CodeReviewAssistant.DTO;

namespace CodeReviewAssistant.Services
{
    public interface ICodeReviewService
    {
        Task<string> ReviewCodeAsync(string code);
    }

    public class CodeReviewService : ICodeReviewService
    {
        //private readonly IAIReviewEngine _aiReviewEngine;

        public CodeReviewService(/*IAIReviewEngine aiReviewEngine*/)
        {
            // _aiReviewEngine = aiReviewEngine;
        }

        public async Task<string> ReviewCodeAsync(string code)
        {
            var result = "This is the result";

            return result;
        }
    }

}
