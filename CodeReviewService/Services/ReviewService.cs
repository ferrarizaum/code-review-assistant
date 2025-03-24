namespace CodeReviewService.Services
{
    public interface ICodeReviewService
    {
        Task<string> ReviewCodeAsync(string code);
    }

    public class ReviewService : ICodeReviewService
    {
        //private readonly IAIReviewEngine _aiReviewEngine;

        public ReviewService(/*IAIReviewEngine aiReviewEngine*/)
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
