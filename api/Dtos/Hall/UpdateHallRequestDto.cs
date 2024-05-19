using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Hall
{
    public class UpdateHallRequestDto
    {
        public int Row_amount { get; set; }
        public int Amount_seats_in_a_row{ get; set; }
    }
}