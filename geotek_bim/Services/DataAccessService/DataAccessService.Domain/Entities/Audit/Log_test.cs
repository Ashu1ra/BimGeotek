using System;

namespace DataAccessService.Domain.Entities.Audit
{
    public class Log_test
    {
        public long Id { get; set; }
        public string Test_type { get; set; } = string.Empty; // тип испытания (lab/field)
        public long Link_test { get; set; } // FK на пробу
        public Dictionary<string, object> Old_data { get; set; } // предыдущие значения записи
        public string Operation_type { get; set; } = string.Empty; // тип изменения (“INSERT”, “UPDATE”, “DELETE”)
        public long Changed_by { get; set; } // пользователь, внесший изменение
        public DateTime? Changed_at { get; set; } // дата изменения
    }
}
