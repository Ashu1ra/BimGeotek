using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public static class JsonValueConverter
    {
        public static ValueConverter<T, string> Create<T>() where T : new()
        {
            return new ValueConverter<T, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<T>(v, (JsonSerializerOptions)null) ?? new T()
            );
        }
    }
}