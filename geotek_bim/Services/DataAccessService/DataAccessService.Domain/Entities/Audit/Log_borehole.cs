using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessService.Domain.Entities.Audit
{
    public class Log_borehole
    {
        public long Id { get; set; }
        public long Link_borehole { get; set; } // FK на выработку
        public Dictionary<string, object> Old_data { get; set; } // предыдущие значения записи
        public string Operation_type { get; set; } = string.Empty; // тип изменения (“INSERT”, “UPDATE”, “DELETE”)
        public long Changed_by { get; set; } // пользователь, внесший изменение
        public DateTime? Changed_at { get; set; } // дата изменения
    }
}
