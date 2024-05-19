using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Migrations;
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
        public Task<List<Users>> GetAllAsync()
        {
            return _context.User.ToListAsync();
        }
    }
}