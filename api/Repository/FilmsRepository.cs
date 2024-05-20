using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Films;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace api.Repository
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly ApplicationDBContext _context;
        public FilmsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Films?> CreateAsync(Films filmsModel)
        {
            await _context.AddAsync(filmsModel);
            await _context.SaveChangesAsync();
            return filmsModel;
        }

        public async Task<Films?> DeleteAsync(int id)
        {
            var filmsModel = await _context.Films.FirstOrDefaultAsync(x => x.Id_films == id);
            if (filmsModel == null)
            {
                return null;
            }

            _context.Films.Remove(filmsModel);
            await _context.SaveChangesAsync();
            return filmsModel;
        }

        public async Task<List<Films>> GetAllAsync(QueryObject query)
        {
            var films = _context.Films.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Genre))
            {

            films = films.Where(s => s.Genre.Contains(query.Genre));
            }
            return await films.ToListAsync();
        }

        public async Task<Films?> GetByIdAsync(int id)
        {
           return await _context.Films.FindAsync(id);
        }

        public async Task<Films?> UpdateAsync(int id, UpdateFilmsRequestDto FilmsDto)
        {
            var exixstingFilms = await _context.Films.FirstOrDefaultAsync(x => x.Id_films == id);

            if (exixstingFilms == null)
            {
                return null;
            }

            exixstingFilms.Name = FilmsDto.Name;
            exixstingFilms.Genre = FilmsDto.Genre;
            exixstingFilms.Producer = FilmsDto.Producer;
            exixstingFilms.Description = FilmsDto.Description;
            exixstingFilms.Duration = FilmsDto.Duration;
            exixstingFilms.Release_Date = FilmsDto.Release_Date;
            exixstingFilms.Country = FilmsDto.Country;
            exixstingFilms.Age_rating = FilmsDto.Age_rating;

            await _context.SaveChangesAsync();
            
            return exixstingFilms;
        }
    }
}