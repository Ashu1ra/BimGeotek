using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Project
    {
        public long Id { get; set; }
        public long Link_list_region {  get; set; } // FK на регион, где располагается проект
        public string Name { get; set; } = string.Empty;
        public long Link_data_source { get; set; } // FK на источник проекта
        public Location Center_location { get; set; } = default!; // координаты центра
        public Area Area { get; set; } = default!; // область охвата проекта
        public DateTime Date_start { get; set; } // дата начала проекта
        public string Description {  get; set; } = string.Empty;
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get;set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Project() { }

        public Project(Location centerLocation, Area area, string name, long linkRegion, long linkDataSource, long ownerUserId, string description = null, DateTime? dateStart = null)
        {
            Center_location = centerLocation ?? throw new ArgumentNullException(nameof(centerLocation));
            Area = area ?? throw new ArgumentNullException(nameof(area));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Link_list_region = linkRegion;
            Link_data_source = linkDataSource;
            Owner_user_id = ownerUserId;
            Description = description;
            Date_start = dateStart ?? DateTime.UtcNow;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
