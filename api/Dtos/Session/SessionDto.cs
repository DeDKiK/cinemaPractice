using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Films;
using api.Dtos.Booking;
using System.Text.RegularExpressions;

namespace api.Dtos.Session
{
    public class SessionDto
    {
     public int Session_Id { get; set; }
    public int? Id_film { get; set; }
    public DateTime Session_date { get; set; }
    public int Session_time { get; set; }
    public int Hall  { get; set; }
    public decimal Price { get; set; }
    public int Amount_of_empty_seats { get; set; }

        public api.Dtos.Films.FilmsDto? Films { get; set; }

        public List<api.Dtos.Booking.BookingDto> Bookings { get; set; } = new List<api.Dtos.Booking.BookingDto>();
    }
}