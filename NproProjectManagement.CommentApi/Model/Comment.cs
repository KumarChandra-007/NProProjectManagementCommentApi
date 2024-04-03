namespace NproProjectManagement.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int TaskID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }

        public int UserID { get; set; }
    }
}
