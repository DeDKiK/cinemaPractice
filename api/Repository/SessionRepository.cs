using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SessionRepository : ISessionRepository
    {
        public readonly ApplicationDBContext _context;
        public SessionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Session>> GetAllAsync()
        {           
            return _context.Session.ToListAsync();
        }
    }
}