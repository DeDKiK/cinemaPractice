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
            var hall = _context.Hall.ToList();

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

            return Ok(hall);
        }

    }
}