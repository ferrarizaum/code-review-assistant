using CodeReviewAssistant.DTO;
using CodeReviewAssistant.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeReviewAssistant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ICodeReviewService _codeReviewService;

        public ReviewController(ICodeReviewService codeReviewService)
        {
            _codeReviewService = codeReviewService;
        }

        [HttpPost("code")]
        public async Task<IActionResult> SubmitCode([FromBody] CodeSubmissionDTO submission)
        {
            var resultId = await _codeReviewService.ReviewCodeAsync(submission.Code);
            return Ok(new { resultId });
        }

        [HttpGet("results/{id}")]
        public async Task<IActionResult> GetReviewResultDTOs(Guid id)
        {
            var results = await _codeReviewService.GetReviewResultDTOsAsync(id);
            if (results == null)
                return NotFound();
            Console.WriteLine("teste");
            return Ok(results);
        }
    }

}
