namespace Core.Specificatios
{
    public class BookSpecParams
    {
        public List<int>? AuthorIds { get; set; }
        public List<int>? GenreIds { get; set; }

        public List<int>? PublisherIds { get; set; }
        public List<int>? LanguageIds { get; set; }
        public string? Sort { get; set; }

        private string? _search;
        public string Search
        {
            get => _search ?? "";
            set => _search = value;
        }
    }
}
