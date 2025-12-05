using System;

namespace DataAccessService.Domain.Entities.Import
{
    public class Data_source
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Link_list_source_type { get; set; } // FK на тип источника
        public string Source_link { get; set; } = string.Empty; // ссылка на оригинальный источник данных
        public string? Description { get; set; } = string.Empty;
        public long Owner_user_id {  get; set; } // ID пользователя создавший сущность

        private Data_source() { }

        public Data_source(string name, long linkListSourceType, long ownerUserId, string sourceLink, string? description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Link_list_source_type = linkListSourceType;
            Owner_user_id = ownerUserId;
            Source_link = sourceLink;
            Description = description;
        }
    }
}