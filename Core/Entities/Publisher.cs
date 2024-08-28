using Core.Entities.Base;

namespace Core.Entities
{
    public class Publisher : BaseEntity
    {
        public required string Name { get; set; }
        public required string MediaUrl { get; set; }
    }
}
