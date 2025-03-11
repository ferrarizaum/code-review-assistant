using CommentService.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<string> PostComment(CommentDTO comment)
        {
            //add logic for comment posting
            var result = comment.Comment;
            return result;
        }
    }
}
