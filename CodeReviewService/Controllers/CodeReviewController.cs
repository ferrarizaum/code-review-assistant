using CodeReviewAssistant.DTO;
using CodeReviewAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeReviewAssistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeReviewController : ControllerBase
    {
        private readonly ICodeReviewService _codeReviewService;

        public CodeReviewController(ICodeReviewService codeReviewService)
        {
            _codeReviewService = codeReviewService;
        }

        [HttpPost("code")]
        public async Task<IActionResult> SubmitCode([FromBody] CodeSubmissionDTO submission)
        {
            var result = await _codeReviewService.ReviewCodeAsync(submission.Code);
            
            return Ok(new { result });
        }
    }

}
