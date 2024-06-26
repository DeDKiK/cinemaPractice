using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Films;
using api.Helpers;
using api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace api.Interfaces
{
    public interface IFilmsRepository
    {
        Task<List<Films>> GetAllAsync(QueryObject query);

        Task<Films?> GetByIdAsync(int id);

        Task<Films?> CreateAsync(Films filmsModel);
        
        Task<Films?> UpdateAsync(int id, UpdateFilmsRequestDto FilmsDto);

        Task<Films?> DeleteAsync(int id);
    }
}