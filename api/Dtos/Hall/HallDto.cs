using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Booking;

namespace api.Dtos.Hall
{
    public class HallDto
    {
        public int Hall_Id { get; set; }
        public int Row_amount { get; set; }
        public int Amount_seats_in_a_row{ get; set; }

        public List<api.Dtos.Booking.BookingDto> Bookings { get; set; } = new List<api.Dtos.Booking.BookingDto>();

    }
}