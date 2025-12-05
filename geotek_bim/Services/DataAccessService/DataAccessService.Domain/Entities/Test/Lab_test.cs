using System;

namespace DataAccessService.Domain.Entities.Test
{
    public class Lab_test
    {
        public long Id { get; set; }
        public long Link_sample { get; set; } // FK на пробу
        public long Link_list_test_type { get; set; } // FK на тип испытания
        public Dictionary<string, object> Results { get; set; } // результаты испытания
        public DateTime Test_date { get; set; } // дата проведения
        public Dictionary<string, object> Metadata { get; set; } // дополнительные сведения
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Lab_test() { }

        public Lab_test(long linkSample, long linkTestType, Dictionary<string, object> results, Dictionary<string, object> metadata, long ownerUserId, DateTime testDate)
        {
            Link_sample = linkSample;
            Link_list_test_type = linkTestType;
            Results = results ?? new Dictionary<string, object>();
            Metadata = metadata ?? new Dictionary<string, object>();
            Owner_user_id = ownerUserId;
            Test_date = testDate;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
