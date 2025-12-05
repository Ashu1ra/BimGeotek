using System;

namespace DataAccessService.Domain.Entities.Auth
{
    public class User_group
    {
        public long Id { get; set; }
        public long Link_user_account {  get; set; } // FK на пользователя
        public long Link_group_list {  get; set; } // FK на группу
    }
}
