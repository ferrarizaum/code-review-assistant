using CodeReviewAssistant.DTO;
using CodeReviewService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeReviewAssistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeReviewController : ControllerBase
    {
        private readonly ICodeReviewService _codeReviewService;
        private readonly IQueueService _queueService;

        public CodeReviewController(ICodeReviewService codeReviewService, IQueueService queueService)
        {
            _codeReviewService = codeReviewService;
            _queueService = queueService;
        }

        [HttpPost("code")]
        public async Task<IActionResult> SubmitCode([FromBody] CodeSubmissionDTO submission)
        {
            var result = await _codeReviewService.ReviewCodeAsync(submission.Code);
            
            _queueService.PublishMessageAsync(submission.Code);
            
            return Ok(new { result });
        }
    }

}
