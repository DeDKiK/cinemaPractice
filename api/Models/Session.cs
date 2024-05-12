using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Session
    {
     public int Session_Id { get; set; }
    public int? Id_film { get; set; }
    public DateTime Session_date { get; set; }
    public TimeSpan Session_time { get; set; }
    public int Hall  { get; set; }
    public decimal Price { get; set; }
    public int Amount_of_empty_seats { get; set; }

        public Films? Films { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}