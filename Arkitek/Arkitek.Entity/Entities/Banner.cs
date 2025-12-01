using Arkitek.Entity.Entities.Common;

namespace Arkitek.Entity.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
