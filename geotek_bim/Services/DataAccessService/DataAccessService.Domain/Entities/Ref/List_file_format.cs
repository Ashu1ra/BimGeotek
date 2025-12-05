using System;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_file_format
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, object> Metadata { get; set; } // правила и настройки разбора файлов
        public string? Description { get; set; } = string.Empty;

        private List_file_format() { }

        public List_file_format(string mnemonic, string name, Dictionary<string, object> metadata, string? description = null)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Metadata = metadata ?? new Dictionary<string, object>();
            Description = description;
        }
    }
}