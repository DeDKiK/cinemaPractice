using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Session;
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

        public async Task<Session> CreateAsync(Session sessionModel)
        {
           await _context.Session.AddAsync(sessionModel);
           await _context.SaveChangesAsync();
           return sessionModel;
        }

        public async Task<Session?> DeleteAsync(int id)
        {
        var sessionModel = await _context.Session.FirstOrDefaultAsync(x => x.Session_Id == id);
        if (sessionModel == null)
        {
        return null;
        }

           _context.Session.Remove(sessionModel);
           await _context.SaveChangesAsync();
           return sessionModel;
        }

        public async Task<List<Session>> GetAllAsync()
        {
         return await _context.Session.ToListAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
      {
             return await _context.Session.FindAsync(id);
        }

        public async Task<Session?> UpdateAsync(int id, UpdateSessionRequestDto sessionDto)
        {
            var existingSesion = await _context.Session.FirstOrDefaultAsync(x=> x.Session_Id == id);
            if(existingSesion == null)
            {
                return null;
            }
            existingSesion.Session_date = sessionDto.Session_date;
            existingSesion.Session_time = sessionDto.Session_time;
            existingSesion.Hall = sessionDto.Hall;
            existingSesion.Price = sessionDto.Price;
            existingSesion.Amount_of_empty_seats = sessionDto.Amount_of_empty_seats;

            await _context.SaveChangesAsync();
            return existingSesion;
        }
    }
}