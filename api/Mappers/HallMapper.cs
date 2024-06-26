using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Hall;

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
                Amount_seats_in_a_row = hallModel.Amount_seats_in_a_row
            
         };
       }

       public static Hall ToHallFromCreateDto(this CreateHallRequestDto HallDto)
       {
          return new Hall
          {
            Row_amount = HallDto.Row_amount,
            Amount_seats_in_a_row = HallDto.Amount_seats_in_a_row
          };
       }
    }
}