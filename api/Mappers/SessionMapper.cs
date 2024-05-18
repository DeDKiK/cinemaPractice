using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Mappers
{
    public static class SessionMapper
    {
        pablic static SessionDto ToSessionDto (this Session sessionModel)
        {
            return new SessionDto
            {
            Session_Id = sessionModel.Session_Id,
            Id_film = sessionModel.Id_film,
            Session_date = sessionModel.Session_date,
            Session_time = sessionModel.Session_time,
            Hall = sessionModel.Hall,
            Price = sessionModel.Price,
            Amount_of_empty_seats = sessionModel.Amount_of_empty_seats
            
            };
       
        }
    }
}