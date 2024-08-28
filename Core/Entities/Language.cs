using Core.Entities.Base;

namespace Core.Entities
{
    public class Language : BaseEntity
    {
        public required string Name { get; set; }
        public required string EnName { get; set; }
    }
}
