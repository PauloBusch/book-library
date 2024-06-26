﻿namespace BookLibrary.Domain.Models
{
    public class BookSearch
    {
        public int Take { get; set; } = 10;
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string? Category { get; set; }
    }
}
