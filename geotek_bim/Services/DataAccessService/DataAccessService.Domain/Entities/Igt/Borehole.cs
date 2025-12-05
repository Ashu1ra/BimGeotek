using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Borehole
    {
        public long Id { get; set; }
        public long Link_site {  get; set; } // FK на участок
        public Location Location { get; set; } = default!; // координаты бурения
        public long Link_list_borehole_type { get; set; } // FK на тип скважины
        public double Depth_min { get; set; } // минимальная глубина
        public double Depth_max { get; set; } // максимальная  глубина
        public long Link_list_borehole_standard { get; set; } // FK на стандарт скважины
        public DateTime Date_start { get; set; } // начало бурения
        public DateTime? Date_end { get; set; } // конец бурения
        public Dictionary<string, object> Metadata { get; set; } // дополнительные данные о бурении
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Borehole() { }

        public Borehole(Location location, long linkSite, long linkBoreholeType, double depthMin, double depthMax, long linkBoreholeStandard, Dictionary<string, object> metadata, long ownerUserId, DateTime dateStart, DateTime? dateEnd = null)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
            Link_site = linkSite;
            Link_list_borehole_type = linkBoreholeType;
            Depth_min = depthMin;
            Depth_max = depthMax;
            Link_list_borehole_standard = linkBoreholeStandard;
            Metadata = metadata ?? new Dictionary<string, object>();
            Owner_user_id = ownerUserId;
            Date_start = dateStart;
            Date_end = dateEnd;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
