using System;

namespace DataAccessService.Domain.Entities.Auth
{
    public class Access_control
    {
        public long Id { get; set; }
        public string Entity_schema { get; set; } = string.Empty; // название схемы, к которой применяется правило
        public string Entity_name { get; set; } = string.Empty; // название таблицы, которой применяется правило
        public long? Object_id { get; set; } // ID на конкретный объект (Если == Null – права на всю таблицу)
        public long? Link_user_account { get; set; } // FK на пользователя
        public long? Link_group_list { get; set; } // FK на группу
        public long? Link_role_list { get; set; } // FK на роль
        public bool Can_read { get; set; } // можно читать
        public bool Can_write { get; set; } // можно читать
        public bool Can_delete { get; set; } // можно удалять
        public Dictionary<string, object> Metadata { get; set; } // дополнительные настройки

        private Access_control() { }

        public Access_control(string entitySchema, string entityName, bool canRead = false, bool canWrite = false, bool canDelete = false, long? objectId = null, long? linkUser = null, long? linkGroup = null, long? linkRole = null, Dictionary<string, object> metadata = null)
        {
            Entity_schema = entitySchema ?? throw new ArgumentNullException(nameof(entitySchema));
            Entity_name = entityName ?? throw new ArgumentNullException(nameof(entityName));
            Object_id = objectId;
            Link_user_account = linkUser;
            Link_group_list = linkGroup;
            Link_role_list = linkRole;
            Can_read = canRead;
            Can_write = canWrite;
            Can_delete = canDelete;
            Metadata = metadata ?? new Dictionary<string, object>();
        }
    }
}
