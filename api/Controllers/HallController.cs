using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Dtos.Hall;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/hall")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public HallController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hall = _context.Hall.ToList()
                .Select(s => s.ToHallDto());

            return Ok(hall);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var hall = _context.Hall.Find(id);

            if(hall == null)
            {
                return NotFound();
            }

            return Ok(hall.ToHallDto());
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateHallRequestDto HallDTO)
        {
            var hallModel = HallDTO.ToHallFromCreateDto();
            _context.Hall.Add(hallModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = hallModel.Hall_Id}, hallModel.ToHallDto());
        }
    [HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    var HallModel = _context.Hall.FirstOrDefault(x => x.Hall_Id == id);
    if (HallModel == null)
    {
        return NotFound();
    }
    _context.Hall.Remove(HallModel);
    _context.SaveChanges();

    return NoContent();
}
    }
}