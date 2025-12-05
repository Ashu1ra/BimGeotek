using System;

namespace DataAccessService.Domain.Entities.Auth
{
    public class User_account
    {
        public long Id { get; set; }
        public string Login {  get; set; } = string.Empty; // логин пользователя
        public string Password { get; set; } = string.Empty; // хеш пароля
        public string Email { get; set; } = string.Empty; // почта
        public string Full_name { get; set; } = string.Empty; // пользователя
        public DateTime Created_at { get; set; } // дата регистрации
        public DateTime Last_login { get; set; } // последнее посещение
        public Dictionary<string, object> Metadata { get; set; } // расширенные данные (настройки)

        public User_account(string login, string password, string email, string full_name, Dictionary<string, object> metadata)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Full_name = full_name ?? throw new ArgumentNullException(nameof(full_name));
            Metadata = metadata ?? new Dictionary<string, object>();
            Created_at = DateTime.UtcNow;
            Last_login = DateTime.UtcNow;
        }
    }
}
