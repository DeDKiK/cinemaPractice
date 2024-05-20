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
using api.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IFilmsRepository _filmsRepo;
        public FilmsController(ApplicationDBContext context, IFilmsRepository filmsRepo)
        {
            _filmsRepo = filmsRepo;
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll([FromQuery]QueryObject query)
        {
            var films = await _filmsRepo.GetAllAsync(query);
       
            var FilmsDTO = films.Select(s => s.ToFilmsDto());

            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var films = await _filmsRepo.GetByIdAsync(id);

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
            await _filmsRepo.CreateAsync(filmsModel);

            return CreatedAtAction(nameof(GetById), new { id = filmsModel.Id_films}, filmsModel.ToFilmsDto());
        }

        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateFilmsRequestDto updateDto)
        { 
            var filmsModel = await _filmsRepo.UpdateAsync(id, updateDto);
            
            
            if(filmsModel == null)
                {

                    return NotFound();
                }


            return Ok(filmsModel.ToFilmsDto());

        }
[HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var FilmsModel = await _filmsRepo.DeleteAsync(id);
    if (FilmsModel == null)
    {
        return NotFound();
    }

    return NoContent();
}

    }
}

  