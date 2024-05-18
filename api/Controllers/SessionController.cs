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
            [HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    var SessionModel = _context.Session.FirstOrDefault(x => x.Session_Id == id);
    if (SessionModel == null)
    {
        return NotFound();
    }
    _context.Session.Remove(SessionModel);
    _context.SaveChanges();

    return NoContent();
}
    }
}