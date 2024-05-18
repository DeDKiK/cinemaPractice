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

namespace api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SessionController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var session = _context.Session.ToList()
            .Select(s => s.ToSessionDto());

            return Ok(session);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var session = _context.Session.Find(id);

            if(session == null)
            {
                return NotFound();
            }

            return Ok(session.ToSessionDto());
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateSessionRequestDto SessionDTO)
        {
            var sessionModel = SessionDTO.ToSessionFromCreateDto();
            _context.Session.Add(sessionModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = sessionModel.Session_Id}, sessionModel.ToSessionDto());
        }
         
         
         [HttpPut]
        [Route("{id}")]     
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateSessionRequestDto updateDto)
        { 
            var sessionModel = _context.Session.FirstOrDefault(x => x.Session_Id == id);
            
            
            if(sessionModel == null)
                {

                    return NotFound();
                }

            sessionModel.Session_date = updateDto.Session_date;
            sessionModel.Session_time = updateDto.Session_time;
            sessionModel.Hall = updateDto.Hall;
            sessionModel.Price = updateDto.Price;
            sessionModel.Amount_of_empty_seats = updateDto.Amount_of_empty_seats;
            _context.SaveChanges();
        

            return Ok(sessionModel.ToSessionDto());

        }
    
    
    
    }
}