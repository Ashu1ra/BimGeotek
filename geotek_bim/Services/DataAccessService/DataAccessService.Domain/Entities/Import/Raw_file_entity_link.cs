using System;

namespace DataAccessService.Domain.Entities.Import
{
    public class Raw_file_entity_link
    {
        public long Id { get; set; }
        public long Link_raw_file { get; set; } // FK на исходный файл
        public string Entity_schema { get; set; } = string.Empty; // схема сущности
        public string Entity_name { get; set; } = string.Empty; // название таблицы
        public long Object_id { get; set; } // ID объекта
        public DateTime Created_at { get; set; } // дата создания связи
    }
}