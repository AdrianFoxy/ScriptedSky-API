using Core.Entities;

namespace Core.Specificatios
{
    public class BookFilterSortPaginationSpecification : BaseSpecification<Book>
    {
        public BookFilterSortPaginationSpecification(string? title, string? sort, List<int>? GenreIds) : base(p =>
             (string.IsNullOrEmpty(title) || p.Title.ToLower().Contains(title)) &&
             (GenreIds == null || GenreIds.Count == 0 || p.Genre!.Any(x => GenreIds.Contains(x.Id)))
        )
        {
            AddInclude(p => p.Author!);
            AddInclude(p => p.Genre!);
            AddInclude(p => p.Publisher!);
            AddInclude(p => p.Language!);

            switch (sort)
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