using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public static class FilmsMapper
    {
        public static FilmsDto ToFilmsDto (this Films filmsModel)
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
    }
}