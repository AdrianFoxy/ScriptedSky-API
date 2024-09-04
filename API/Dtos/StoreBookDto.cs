using Core.Entities;

namespace API.Dtos
{
    public class StoreBookDto
    {
        public int Id { get; set; }
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
        public List<Author>? Author { get; set; }
        public List<Genre>? Genre { get; set; }
        public Publisher? Publisher { get; set; }
        public Language? Language { get; set; }
    }
}
