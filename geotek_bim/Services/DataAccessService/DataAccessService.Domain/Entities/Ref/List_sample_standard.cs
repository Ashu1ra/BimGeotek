using System;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_sample_standard
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        private List_sample_standard() { }

        public List_sample_standard(string mnemonic, string name, string? description = null)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }
    }
}