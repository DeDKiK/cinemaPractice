using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Session
{
    public class UpdateSessionRequestDto
    {
      
    public int? Id_film { get; set; }
    public DateTime Session_date { get; set; }
    public int Session_time { get; set; }
    public int Hall  { get; set; }
    public decimal Price { get; set; }
    public int Amount_of_empty_seats { get; set; }
    }
}