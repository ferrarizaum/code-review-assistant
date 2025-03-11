namespace CommentService.DTO
{
    public class CommentDTO
    {
        public string Owner { get; set; }
        public string Repository { get; set; }
        public int PullRequestNumber { get; set; }
        public string Comment{ get; set; }

    }
}
