using CommentService.DTO;
using CommentService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentDTO comment) 
        {
            var result = await _commentService.PostComment(comment);
            return Ok(result);
        }
    }
}
