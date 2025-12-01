using Arkitek.Entity.Entities.Common;

namespace Arkitek.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
