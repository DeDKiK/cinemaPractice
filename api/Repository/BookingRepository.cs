using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Booking;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace api.Repository
{
    public class BookingRepository : IBookingRepository
    {
    
    private readonly ApplicationDBContext _context;

    public BookingRepository(ApplicationDBContext context)
    {
        _context = context;
    }

        public async Task<Booking> CreateAsync(Booking bookingModel)
        {
           await _context.Booking.AddAsync(bookingModel);
           await _context.SaveChangesAsync();
           return bookingModel;
        }

        public async Task<Booking?> DeleteAsync(int id)
        {
           var bookingModel = await _context.Booking.FirstOrDefaultAsync(x=> x.Booking_Id == id);
           if (bookingModel == null)
           {
            return null;
           }

           _context.Booking.Remove(bookingModel);
           await _context.SaveChangesAsync();
           return bookingModel;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Booking.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Booking.FindAsync(id);
        }

        public async Task<Booking?> UpdateAsync(int id, UpdateBookingRequestDto bookingDto)
        {
            var existingBooking = await _context.Booking.FirstOrDefaultAsync(x=> x.Booking_Id == id);
            if(existingBooking == null)
            {
                return null;
            }
            existingBooking.Ticket_amount  = bookingDto.Ticket_amount;
            existingBooking.Booking_date = bookingDto.Booking_date;

            await _context.SaveChangesAsync();
            return existingBooking;
        }
    }
}