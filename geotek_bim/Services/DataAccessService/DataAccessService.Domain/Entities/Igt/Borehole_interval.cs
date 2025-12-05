using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Borehole_interval
    {
        public long Id { get; set; }
        public long Link_borehole { get; set; } // FK на выработку
        public DepthInterval Interval { get; set; } // интервал выработки
        public long Link_list_borehole_interval_type { get; set; } // FK на стандарт интервала
        public Dictionary<string, object> Metadata { get; set; } // дополнительные данные о интервале
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Borehole_interval() { }

        public Borehole_interval(DepthInterval interval, Dictionary<string, object> metadata, long linkBorehole, long linkBoreholeIntervalType, long ownerUserId)
        {
            Interval = interval ?? throw new ArgumentNullException(nameof(interval));
            Metadata = metadata ?? new Dictionary<string, object>();
            Link_borehole = linkBorehole;
            Link_list_borehole_interval_type = linkBoreholeIntervalType;
            Owner_user_id = ownerUserId;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }

        public void UpdateInterval(DepthInterval newInterval)
        {
            if (newInterval == null) throw new ArgumentNullException(nameof(newInterval));
            Interval = newInterval;
            Updated_at = DateTime.UtcNow;
        }
    }
}
