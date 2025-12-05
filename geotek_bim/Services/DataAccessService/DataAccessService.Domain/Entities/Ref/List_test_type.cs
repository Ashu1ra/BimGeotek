using System;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_test_type
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Code { get; set; } = string.Empty; // короткое название типа
        public string Name { get; set; } = string.Empty; // название типа
        public string Category {  get; set; } = string.Empty; // field/lab
        public string? Description { get; set; } = string.Empty;

        private List_test_type() { }

        public List_test_type(string mnemonic, string code, string name, string category, string? description = null)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Description = description;
        }
    }
}