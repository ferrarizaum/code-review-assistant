using CommentService.DTO;

namespace CommentService.Services
{
    public interface ICommentService
    {
        Task<string> PostComment(CommentDTO comment);

    }

    public class CommentService : ICommentService
    {
        public CommentService()
        {
            
        }

        public Task<string> PostComment(CommentDTO comment)
        {
            //add logic for comment posting
            throw new NotImplementedException();
        }
    }
}
