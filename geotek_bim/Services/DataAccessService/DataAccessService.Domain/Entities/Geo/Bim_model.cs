using Domain.ValueObjects;
using System;


namespace DataAccessService.Domain.Entities.Geo
{
    public class Bim_model
    {
        public long Id { get; set; }
        public long Link_site { get; set; } // FK на участок
        public string Format { get; set; } = string.Empty; // формат файла модели (IFC, 3DTILES, DWG, DXF, DGN)
        public Area Area { get; set; } = default!; // область охвата участка
        public byte[] File_data { get; set; } // бинарные данные модели
        public Dictionary<string, object> Metadata { get; set; } // дополнительные данные о модели (LOD, bounding box, CRS, версия схемы и др.)
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Bim_model() { }

        public Bim_model(long linkSite, string format, byte[] fileData, Dictionary<string, object> metadata)
        {
            Link_site = linkSite;
            Format = format ?? throw new ArgumentNullException(nameof(format));
            File_data = fileData ?? throw new ArgumentNullException(nameof(fileData));
            Metadata = metadata ?? new Dictionary<string, object>();
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
