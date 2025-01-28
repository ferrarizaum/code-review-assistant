namespace CodeReviewAssistant.DTO
{
    public class CodeSubmissionDTO
    {
        public string Code { get; set; } // The actual code snippet being submitted.
        public string Language { get; set; } // Optionally, the programming language (C#, Java, etc.).

        // You can add other fields as necessary, such as:
        // public string UserId { get; set; } // Optional user info for tracking who submitted the code.
        // public string FileName { get; set; } // Optional file name or identifier.
    }
}
