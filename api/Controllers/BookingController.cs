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
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public BookingController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var booking = _context.Booking.ToList();

            return Ok(booking);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRouter] int id)
        {
            var booking = _context.Booking.Find(id)

            if(booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
    }
}