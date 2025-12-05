using System;

namespace DataAccessService.Domain.Entities.Import
{
    public class Raw_file
    {
        public long Id { get; set; }
        public long Link_data_source { get; set; } // FK на источник данных
        public string Filename { get; set; } = string.Empty;
        public long Link_list_file_format { get; set; } // FK на формат файла
        public string Source_link { get; set; } = string.Empty; // ссылка на оригинальный источник данных
        public byte[] File_data { get; set; } // исходный файл
        public string Uploaded_by { get; set; } = string.Empty; // пользователь, загрузивший файл
        public DateTime Upload_at { get; set; } // дата загрузки файла в БД
        public long Owner_user_id { get; set; } // ID пользователя создавший сущность

        private Raw_file() { }

        public Raw_file(long linkDataSource, string filename, long linkFileFormat, byte[] fileData, string uploadedBy, long ownerUserId)
        {
            Link_data_source = linkDataSource;
            Filename = filename ?? throw new ArgumentNullException(nameof(filename));
            Link_list_file_format = linkFileFormat;
            File_data = fileData ?? throw new ArgumentNullException(nameof(fileData));
            Uploaded_by = uploadedBy ?? throw new ArgumentNullException(nameof(uploadedBy));
            Owner_user_id = ownerUserId;
            Upload_at = DateTime.UtcNow;
        }
    }
}