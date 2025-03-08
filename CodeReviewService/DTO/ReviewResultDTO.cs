namespace CodeReviewAssistant.DTO
{
    public class ReviewResultDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Feedback { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
