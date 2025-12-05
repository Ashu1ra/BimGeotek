using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Site
    {
        public long Id { get; set; }
        public long Link_project { get; set; } // FK на проект
        public string Name { get; set; } = string.Empty;
        public Area Area { get; set; } = default!; // область охвата участка
        public string Description { get; set; } = string.Empty;
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Site() { }

        public Site(long linkProject, string name, Area area, long ownerUserId, string description = null)
        {
            Link_project = linkProject;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Area = area ?? throw new ArgumentNullException(nameof(area));
            Owner_user_id = ownerUserId;
            Description = description;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
