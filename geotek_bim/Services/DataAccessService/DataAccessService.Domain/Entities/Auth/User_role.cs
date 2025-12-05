using System;

namespace DataAccessService.Domain.Entities.Auth
{
    public class User_role
    {
        public long Id { get; set; }
        public long Link_user_account {  get; set; } // FK на пользователя
        public long Link_role_list {  get; set; } // FK на роль
    }
}
