using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Session;
using api.Models;

namespace api.Interfaces
{
    public interface ISessionRepository
    {
             Task<List<Session>> GetAllAsync();

        Task<Session?> GetByIdAsync(int id);

        Task<Session> CreateAsync(Session sessionModel);

        Task<Session?> UpdateAsync(int id, UpdateSessionRequestDto sessionModel);

        Task<Session?> DeleteAsync(int id);

    }
}