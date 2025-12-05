using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Sample
    {
        public long Id { get; set; }
        public long Link_borehole_interval { get; set; } // FK на интервал выработки
        public string Number { get; set; } = string.Empty; // уникальный номер пробы
        public DepthInterval Interval { get; set; } // интервал выработки
        public long Link_list_sample_standard { get; set; } // FK на стандарт отбора
        public string? Description { get; set; } = string.Empty;
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Sample() { }

        public Sample(string number, DepthInterval interval, long linkBoreholeInterval, long linkSampleStandard, long ownerUserId, string? description = null)
        {
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Interval = interval ?? throw new ArgumentNullException(nameof(interval));
            Link_borehole_interval = linkBoreholeInterval;
            Link_list_sample_standard = linkSampleStandard;
            Owner_user_id = ownerUserId;
            Description = description;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }

        public void UpdateInterval(DepthInterval newInterval)
        {
            Interval = newInterval ?? throw new ArgumentNullException(nameof(newInterval));
            Updated_at = DateTime.UtcNow;
        }
    }
}
