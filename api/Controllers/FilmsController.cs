using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
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

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(films.ToFilmsDto());
        }

        
    }
}