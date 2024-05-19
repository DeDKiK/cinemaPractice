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
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/hall")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IHallRepository _hallRepo;
        public HallController(ApplicationDBContext context, IHallRepository hallRepo)
        {
            _hallRepo = hallRepo;
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var hall = await _hallRepo.GetAllAsync();
            var HallDto = hall.Select(s => s.ToHallDto());

            return Ok(hall);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var hall = await _hallRepo.GetByIdAsync(id);

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
            await _hallRepo.CreateAsync(hallModel);

            return CreatedAtAction(nameof(GetById), new { id = hallModel.Hall_Id}, hallModel.ToHallDto());
        }



        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateHallRequestDto updateDto)
        { 
            var hallModel = await _hallRepo.UpdateAsync(id, updateDto);
            
            
            if(hallModel == null)
                {

                    return NotFound();
                }

            
         
            return Ok(hallModel.ToHallDto());

        }


    [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var HallModel = await _hallRepo.DeleteAsync(id);
    if (HallModel == null)
    {
        return NotFound();
    }
    
    return NoContent();
}
    }
}