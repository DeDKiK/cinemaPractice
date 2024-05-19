using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Dtos.Films;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup;
using System.Runtime.CompilerServices;


namespace api.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public FilmsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var films = await _context.Films.ToListAsync();
           
           var FilmsDTO = films.Select(s => s.ToFilmsDto());

            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var films = await _context.Films.FindAsync(id);

            if(films == null)
            {
                return NotFound();
            }

            return Ok(films.ToFilmsDto());
        }

        [HttpPost]
        
        public async Task <IActionResult> Create([FromBody] CreateFilmsRequestDto FilmsDTO)
        {
            var filmsModel = FilmsDTO.ToFilmsFromCreateDto();
            await _context.Films.AddAsync(filmsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = filmsModel.Id_films}, filmsModel.ToFilmsDto());
        }

        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateFilmsRequestDto updateDto)
        { 
            var filmsModel = await _context.Films.FirstOrDefaultAsync(x => x.Id_films == id);
            
            
            if(filmsModel == null)
                {

                    return NotFound();
                }

            filmsModel.Name = updateDto.Name;
            filmsModel.Genre = updateDto.Genre;
            filmsModel.Producer = updateDto.Producer;
            filmsModel.Description = updateDto.Description;
            filmsModel.Duration = updateDto.Duration;
            filmsModel.Release_Date = updateDto.Release_Date;
            filmsModel.Country = updateDto.Country;
            filmsModel.Age_rating = updateDto.Age_rating;

            await _context.SaveChangesAsync();

            return Ok(filmsModel.ToFilmsDto());

        }
    [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var FilmsModel = await _context.Films.FirstOrDefaultAsync(x => x.Id_films == id);
    if (FilmsModel == null)
    {
        return NotFound();
    }
    _context.Films.Remove(FilmsModel);
    
    await _context.SaveChangesAsync();

    return NoContent();
}

    }
}

  