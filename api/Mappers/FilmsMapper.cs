using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Films;

namespace api.Mappers
{
    public static class FilmsMapper
    {
        public static FilmsDto ToFilmsDto(this Films filmsModel)
        {
            return new FilmsDto
            {
                Id_films = filmsModel.Id_films,
                Name = filmsModel.Name,
                Genre = filmsModel.Genre,
                Producer = filmsModel.Producer,
                Description = filmsModel.Description,
                Duration = filmsModel.Duration,
                Release_Date = filmsModel.Release_Date,
                Country = filmsModel.Country,
                Age_rating = filmsModel.Age_rating
            };
        }

        public static Films ToFilmsFromCreateDto(this CreateFilmsRequestDto FilmsDto)
        {
            return new Films
            {
                Name = FilmsDto.Name,
                Genre = FilmsDto.Genre,
                Producer = FilmsDto.Producer,
                Description = FilmsDto.Description,
                Duration = FilmsDto.Duration,
                Release_Date = FilmsDto.Release_Date,
                Country = FilmsDto.Country,
                Age_rating = FilmsDto.Age_rating
            };
        }
    }
}
