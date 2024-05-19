using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Mappers;
using api.Dtos.Booking;
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
        private readonly IBookingRepository BookRepo;
        public BookingController(ApplicationDBContext context, IBookingRepository BookRepo)
        {
            _BookRepo = BookRepo;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var booking = BookRepo.GetAllAsync();
            .Select(s => s.ToBookingDto());

            return Ok(booking);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var booking = _context.Booking.Find(id);

            if(booking == null)
            {
                return NotFound();
            }

            return Ok(booking.ToBookingDto());
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateBookingRequestDto BookingDTO)
        {
            var bookingModel = BookingDTO.ToBookingFromCreateDto();
            _context.Booking.Add(bookingModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = bookingModel.Booking_Id}, bookingModel.ToBookingDto());
        }
    [HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    var BookingModel = _context.Booking.FirstOrDefault(x => x.Booking_Id == id);
    if (BookingModel == null)
    {
        return NotFound();
    }
    _context.Booking.Remove(BookingModel);
    _context.SaveChanges();

    return NoContent();
}
    [HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    varBookingModel = _context.Booking.FirstOrDefault(x => x.Booking_Id == id);
    if (BookingModel == null)
    {
        return NotFound();
    }
    _context.Booking.Remove(BookingModel);
    _context.SaveChanges();

    return NoContent();
}
    }
}