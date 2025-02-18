using CodeReviewAssistant.DTO;
using OpenAI.Chat;

namespace CodeReviewAssistant.Services
{
    public interface IGitHubReviewService
    {
        void PostReviewAsComment(string comment);
    }

    public class GitHubReviewService : IGitHubReviewService
    {
        public GitHubReviewService()
        {            
        }

        public void PostReviewAsComment(string comment)
        {
            throw new NotImplementedException();
        }
    }
}
