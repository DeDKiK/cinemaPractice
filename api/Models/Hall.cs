using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    public class Hall
    {
         [Key]
     public int Hall_Id { get; set; }
    public int Row_amount { get; set; }
    public int Amount_seats_in_a_row{ get; set; }

     public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}