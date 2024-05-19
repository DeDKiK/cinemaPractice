using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Users;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDBContext _context;
        public UsersRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Users> CreateAsync(Users userModel)
        {
           await _context.User.AddAsync(userModel);
           await _context.SaveChangesAsync();
           return userModel;
        }

        public async Task<Users?> DeleteAsync(int id)
        {
           var userModel = await _context.User.FirstOrDefaultAsync(x=> x.User_Id == id);
           if (userModel == null)
           {
            return null;
           }

           _context.User.Remove(userModel);
           await _context.SaveChangesAsync();
           return userModel;
        }
        public async Task<List<Users>> GetAllAsync()
        {
             return await _context.User.ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
             return await _context.User.FindAsync(id);
        }

        public async Task<Users?> UpdateAsync(int id, UpdateUsersRequestDto usersDto)
        {
             var existingUsers = await _context.User.FirstOrDefaultAsync(x=> x.User_Id == id);
            if(existingUsers == null)
            {
                return null;
            }
            existingUsers.Nickname = usersDto.Nickname;
            existingUsers.Email = usersDto.Email;
            existingUsers.Pass = usersDto.Pass;
            existingUsers.Regestration_date = usersDto.Regestration_date;
            await _context.SaveChangesAsync();
            return existingUsers;
        }
    }
}