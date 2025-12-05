using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccessService.Domain.Entities.Audit
{
    public class Log_borehole_interval
    {
        public long Id { get; set; }
        public long Link_borehole_interval { get; set; } // FK на интервал
        public Dictionary<string, object> Old_data { get; set; } // предыдущие значения записи
        public string Operation_type { get; set; } = string.Empty; // тип изменения (“INSERT”, “UPDATE”, “DELETE”)
        public long Changed_by { get; set; } // пользователь, внесший изменение
        public DateTime? Changed_at { get; set; } // дата изменения
    }
}
