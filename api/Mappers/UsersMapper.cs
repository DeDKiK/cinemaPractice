using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Users;

namespace api.Mappers
{
    public static class UsersMapper
    {
        public static UsersDto ToUsersDto (this Users usersModel)
        {
        
         return new UsersDto
            {
                User_Id = usersModel.User_Id,
                Nickname = usersModel.Nickname,
                Email = usersModel.Email,
                Pass = usersModel.Pass,
                Regestration_date = usersModel.Regestration_date
    
            };
        }
    }
}