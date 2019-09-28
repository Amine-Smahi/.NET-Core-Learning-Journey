using System;

namespace HelloBox.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category.Categories Category { get; set; }
        public string DatePublished { get; set; }
        public string PicturePath { get; set; }
        public string Content { get; set; }
    }
}