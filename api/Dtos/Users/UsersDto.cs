using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Booking;

namespace api.Dtos.Users
{
    public class UsersDto
    {
        public int User_Id { get; set; }
        public string Nickname { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Pass { get; set; }= string.Empty;
        public DateTime Regestration_date { get; set; }= DateTime.Now;

        public List<api.Dtos.Booking.BookingDto> Bookings { get; set; } = new List<api.Dtos.Booking.BookingDto>();

    }
}