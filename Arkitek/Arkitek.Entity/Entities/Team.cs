using Arkitek.Entity.Entities.Common;

namespace Arkitek.Entity.Entities
{
    public class Team : BaseEntity
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public IList<TeamSocial> TeamSocials { get; set; }
    }
}
