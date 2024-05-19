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
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        private readonly IBookingRepository _bookRepo;
        public BookingController(ApplicationDBContext context, IBookingRepository bookRepo)
        {
            _bookRepo = bookRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var booking = await _bookRepo.GetAllAsync();
            var BookingDto = booking.Select(s => s.ToBookingDto());

            return Ok(booking);
        }

        [HttpGet("{id}")]

        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if(booking == null)
            {
                return NotFound();
            }

            return Ok(booking.ToBookingDto());
        }

        [HttpPost]

        public async Task <IActionResult> Create([FromBody] CreateBookingRequestDto BookingDTO)
        {
            var bookingModel = BookingDTO.ToBookingFromCreateDto();
            await _context.Booking.AddAsync(bookingModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = bookingModel.Booking_Id}, bookingModel.ToBookingDto());
        }
        
        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookingRequestDto updateDto)
        { 
            var bookingModel = await _context.Booking.FirstOrDefaultAsync(x => x.Booking_Id == id);
            
            
            if(bookingModel == null)
                {

                    return NotFound();
                }

            
            bookingModel.Ticket_amount  = updateDto.Ticket_amount;
            bookingModel.Booking_date = updateDto.Booking_date;
            await _context.SaveChangesAsync();
        

            return Ok(bookingModel.ToBookingDto());

        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var BookingModel = await _context.Booking.FirstOrDefaultAsync(x => x.Booking_Id == id);
            if (BookingModel == null)
            {
                return NotFound();
            }
            _context.Booking.Remove(BookingModel);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}