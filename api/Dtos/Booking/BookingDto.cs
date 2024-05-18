using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Session;
using api.Dtos.Hall;
using api.Dtos.Users;


namespace api.Dtos.Booking
{
    public class BookingDto
    {

    public int Booking_Id { get; set; }
    public int? User_Id { get; set; }
    public int? Session_Id { get; set; }
    public int Ticket_amount { get; set; }
    public DateTime Booking_date { get; set; }= DateTime.Now;
    public int? Hall_Id { get; set; }




    public api.Dtos.Session.SessionDto? Session { get; set; }
    public api.Dtos.Hall.HallDto? Hall { get; set; }
    public api.Dtos.Users.UsersDto? Users { get; set; }

    }
}