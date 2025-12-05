using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_borehole_interval_type
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, object> Metadata { get; set; } // дополнительные параметры для типа интервала
        public string? Description { get; set; } = string.Empty;

        private List_borehole_interval_type() { }

        public List_borehole_interval_type(string mnemonic, string name, Dictionary<string, object> metadata, string? description = null)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Metadata = metadata ?? new Dictionary<string, object>();
            Description = description;
        }
    }
}