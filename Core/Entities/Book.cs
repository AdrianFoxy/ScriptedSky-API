namespace Core.Entities
{
    public class Book : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string PictureURL { get; set; }
        public int ReleaseYear { get; set; }
        public float Rating { get; set; }
        public required string SizeFormat { get; set; }
        public int PageNumber { get; set; }
        public int Weight { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public required string ISBN { get; set; }

        // Relationships
        public required string Author { get; set; } = string.Empty;
        public required string Publisher { get; set; } = string.Empty;
        public required string Language { get; set; } = string.Empty;
        public required string Genre { get; set; } = string.Empty;
    }
}
