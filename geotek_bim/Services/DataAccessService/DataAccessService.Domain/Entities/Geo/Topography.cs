using Domain.ValueObjects;
using System;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Topography
    {
        public long Id { get; set; }
        public long Link_site { get; set; } // FK на участок
        public long Link_data_source { get; set; } // FK на источник данных
        public Area Area { get; set; } = default!; // область охвата участка
        public string Description { get; set; } = string.Empty;
        public byte[] Raster_file {  get; set; } // растровый файл с данными рельефа
        public Dictionary<string, object> Metadata { get; set; } // дополнительные данные о рельефе
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Topography() { }

        public Topography(long linkSite, long linkDataSource, Area area, byte[] rasterFile, Dictionary<string, object> metadata, long ownerUserId)
        {
            Link_site = linkSite;
            Link_data_source = linkDataSource;
            Area = area ?? throw new ArgumentNullException(nameof(area));
            Raster_file = rasterFile ?? throw new ArgumentNullException(nameof(rasterFile));
            Metadata = metadata ?? new Dictionary<string, object>();
            Owner_user_id = ownerUserId;
            Created_at = DateTime.UtcNow;
            Updated_at = DateTime.UtcNow;
        }
    }
}
