using System.Text.Json.Serialization;
using Core.Entities.Base;

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
        [JsonIgnore]
        public List<BookAuthor>? BookAuthor { get; set; }
        public List<Author>? Author { get; set; }

        [JsonIgnore]
        public List<BookGenre>? BookGenre { get; set; }
        public List<Genre>? Genre { get; set; }
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }
        public Language? Language { get; set; }
        public int LanguageId { get; set; }

    }
}
