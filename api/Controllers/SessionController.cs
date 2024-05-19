using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Mappers;
using api.Dtos.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Repository;

namespace api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ISessionRepository _sessRepo;

        public SessionController(ApplicationDBContext context, ISessionRepository sessRepo)
        {
            _sessRepo = sessRepo;
            _context = context;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var session = await _sessRepo.GetAllAsync();
            var SessionDto = session.Select(s => s.ToSessionDto());

            return Ok(session);
        }

        [HttpGet("{id}")]

        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var session = await _sessRepo.GetByIdAsync(id);

            if(session == null)
            {
                return NotFound();
            }

            return Ok(session.ToSessionDto());
        }

        [HttpPost]

        public async Task <IActionResult> Create([FromBody] CreateSessionRequestDto SessionDTO)
        {
            var sessionModel = SessionDTO.ToSessionFromCreateDto();
            await _sessRepo.CreateAsync(sessionModel);

            return CreatedAtAction(nameof(GetById), new { id = sessionModel.Session_Id}, sessionModel.ToSessionDto());
        }
         
         
         [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateSessionRequestDto updateDto)
        { 
            var sessionModel = await _sessRepo.UpdateAsync(id, updateDto);
            
            
            if(sessionModel == null)
                {

                    return NotFound();
                }


        

            return Ok(sessionModel.ToSessionDto());

        }
    
        [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var SessionModel = await _context.Session.FirstOrDefaultAsync(x => x.Session_Id == id);
    if (SessionModel == null)
    {
        return NotFound();
    }
    _context.Session.Remove(SessionModel);

    await _context.SaveChangesAsync();

    return NoContent();
}
    
    }
}