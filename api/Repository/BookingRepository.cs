using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BookingRepository : IBookingRepository
    {
    
    private readonly ApplicationDBContext _context;

    public BookingRepository(ApplicationDBContext context)
    {
        context = _context;
    }
            public Task<List<Booking>> GetAllAsync()
        {
            return _context.Booking.ToListAsync();
        }
    }
}