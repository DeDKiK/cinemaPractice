using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Booking
    {
    public int Booking_Id { get; set; }
    public int? User_Id { get; set; }
    public int? Session_Id { get; set; }
    public int Ticket_amount { get; set; }
    public DateTime Booking_date { get; set; }= DateTime.Now;
    public int? Hall_Id { get; set; }




    public Session? Session { get; set; }
    public Hall? Hall { get; set; }
    public Users? Users { get; set; }



    }
}