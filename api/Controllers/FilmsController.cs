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
        public IActionResult GetAll()
        {
            var films = _context.Films.ToList()
                .Select(s => s.ToFilmsDto());

            return Ok(films);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var films = _context.Films.Find(id);

            if (films == null)
            {
                return NotFound();
            }

            return Ok(films.ToFilmsDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFilmsRequestDto FilmsDTO)
        {
            var filmsModel = FilmsDTO.ToFilmsFromCreateDto();
            _context.Films.Add(filmsModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = filmsModel.Id_films }, filmsModel.ToFilmsDto());
        }

[HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    var FilmsModel = _context.Films.FirstOrDefault(x => x.Id_films == id);
    if (FilmsModel == null)
    {
        return NotFound();
    }
    _context.Films.Remove(FilmsModel);
    _context.SaveChanges();

    return NoContent();
}

    }
}
