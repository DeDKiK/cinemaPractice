using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Users;
using api.Models;

namespace api.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();

        Task<Users?> GetByIdAsync(int id);

        Task<Users> CreateAsync(Users userModel);

        Task<Users?> UpdateAsync(int id, UpdateUsersRequestDto usersDto);

        Task<Users?> DeleteAsync(int id);
    }
}