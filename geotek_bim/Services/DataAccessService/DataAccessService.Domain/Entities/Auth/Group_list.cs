using System;

namespace DataAccessService.Domain.Entities.Auth
{
    public class Group_list
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty; // название группы
        public string Description { get; set; } = string.Empty; // описание

        public Group_list(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }
    }
}
