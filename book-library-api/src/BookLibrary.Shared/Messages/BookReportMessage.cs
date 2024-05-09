namespace BookLibrary.Shared.Messages
{
    public class BookReportMessage
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string? Category { get; set; }
    }
}
