using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Session;

namespace api.Mappers
{
    public static class SessionMapper
    {
        public static SessionDto ToSessionDto (this Session sessionModel)
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

        public static Session ToSessionFromCreateDto(this CreateSessionRequestDto SessionDto)
        {
            return new Session
            {
                Id_film = SessionDto.Id_film,
                Session_date = SessionDto.Session_date,
                Session_time = SessionDto.Session_time,
                Hall = SessionDto.Hall,
                Price = SessionDto.Price,
                Amount_of_empty_seats = SessionDto.Amount_of_empty_seats
            };
        }
    }
}