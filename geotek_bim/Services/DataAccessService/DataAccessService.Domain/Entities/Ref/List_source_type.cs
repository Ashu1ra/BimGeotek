using System;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_source_type
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Name { get; set; } = string.Empty;
        public string? Description {  get; set; } = string.Empty;

        private List_source_type() { }

        public List_source_type(string mnemonic, string name, string? description = null)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }
    }
}