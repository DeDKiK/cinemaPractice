using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Booking
{
    public class CreateBookingRequestDto
    {
        public int? User_Id { get; set; }
        public int? Session_Id { get; set; }
        public int Ticket_amount { get; set; }
        public DateTime Booking_date { get; set; }= DateTime.Now;
        public int? Hall_Id { get; set; }
    }
}