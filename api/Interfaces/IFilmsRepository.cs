using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Films;
using api.Models;

namespace api.Interfaces
{
    public interface IFilmsRepository
    {
        Task<List<Films>> GetAllAsync();

        Task<Films?> GetByIdAsync(int id);

        Task<Films?> CreateAsync(Films filmsModel);
        
        Task<Films?> UpdateAsync(int id, UpdateFilmsRequestDto FilmsDto);

        Task<Films?> DeleteAsync(int id);
    }
}