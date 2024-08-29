using Core.Entities;

namespace Core.Specificatios
{
    public class BookFilterSortPaginationSpecification : BaseSpecification<Book>
    {
        public BookFilterSortPaginationSpecification(BookSpecParams bookSpecParams) : base(p =>
            (string.IsNullOrEmpty(bookSpecParams.Search) || p.Title.ToLower().Contains(bookSpecParams.Search)) &&
            (bookSpecParams.GenreIds == null || bookSpecParams.GenreIds.Count == 0 || 
                           p.Genre!.Any(x => bookSpecParams.GenreIds.Contains(x.Id))) &&
            (bookSpecParams.AuthorIds == null || bookSpecParams.AuthorIds.Count == 0 || 
                           p.Author!.Any(x => bookSpecParams.AuthorIds.Contains(x.Id))) &&
            (bookSpecParams.PublisherIds == null || bookSpecParams.PublisherIds.Count == 0 || 
                           bookSpecParams.PublisherIds.Contains(p.PublisherId)) &&
            (bookSpecParams.LanguageIds == null || bookSpecParams.LanguageIds.Count == 0 ||
                           bookSpecParams.LanguageIds.Contains(p.LanguageId))
        )
        {
            AddInclude(p => p.Author!);
            AddInclude(p => p.Genre!);
            AddInclude(p => p.Publisher!);
            AddInclude(p => p.Language!);

            ApplyPaging(bookSpecParams.PageSize * (bookSpecParams.PageIndex - 1),  bookSpecParams.PageSize);

            switch (bookSpecParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Title);
                    break;
            }
        }
    }
}