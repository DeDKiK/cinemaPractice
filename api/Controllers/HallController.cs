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
using System.Drawing;

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
        public async Task <IActionResult> GetAll()
        {
            var hall = await _context.Hall.ToListAsync();
            var HallDto = hall.Select(s => s.ToHallDto());

            return Ok(hall);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var hall = await _context.Hall.FindAsync(id);

            if(hall == null)
            {
                return NotFound();
            }

            return Ok(hall.ToHallDto());
        }

        [HttpPost]

        public async Task <IActionResult> Create([FromBody] CreateHallRequestDto HallDTO)
        {
            var hallModel = HallDTO.ToHallFromCreateDto();
            await _context.Hall.AddAsync(hallModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = hallModel.Hall_Id}, hallModel.ToHallDto());
        }



        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateHallRequestDto updateDto)
        { 
            var hallModel = await _context.Hall.FirstOrDefaultAsync(x => x.Hall_Id == id);
            
            
            if(hallModel == null)
                {

                    return NotFound();
                }

            
            hallModel.Row_amount = updateDto.Row_amount;
            hallModel.Amount_seats_in_a_row = updateDto.Amount_seats_in_a_row;
            await _context.SaveChangesAsync();
        

            return Ok(hallModel.ToHallDto());

        }


    [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var HallModel = await _context.Hall.FirstOrDefaultAsync(x => x.Hall_Id == id);
    if (HallModel == null)
    {
        return NotFound();
    }
    _context.Hall.Remove(HallModel);

    await _context.SaveChangesAsync();

    return NoContent();
}
    }
}