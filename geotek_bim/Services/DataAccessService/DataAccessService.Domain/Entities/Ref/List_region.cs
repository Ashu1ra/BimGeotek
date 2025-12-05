using System;

namespace DataAccessService.Domain.Entities.Ref
{
    public class List_region
    {
        public long Id { get; set; }
        public string Mnemonic { get; set; } = string.Empty; // уникальный код сущности
        public string Code { get; set; } = string.Empty; // код региона
        public string Name { get; set; } = string.Empty; // название региона

        private List_region() { }

        public List_region(string mnemonic, string code, string name)
        {
            Mnemonic = mnemonic ?? throw new ArgumentNullException(nameof(mnemonic));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}