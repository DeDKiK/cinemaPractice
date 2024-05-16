using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public static class HallMapper
    {
       public static  HallDto ToHallDto(this Hall hallModel)
       {
         return new HallDto
         {
                Hall_Id = hallModel.Hall_Id,
                Row_amount = hallModel.Row_amount,
                Amount_seats_in_a_row = hallModel.Amount_seats_in_a_row,
            
         };
       }
    }
}