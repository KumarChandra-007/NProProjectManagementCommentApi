namespace NproProjectManagement.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int TaskID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public int UserID { get; set; }
    }
}
