using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Booking;

namespace api.Mappers
{
    public static class BookingMapper
    {
        public static BookingDto ToBookingDto (this Booking bookingModel)
        {
            return new BookingDto
            {
                Booking_Id = bookingModel.Booking_Id,
                User_Id = bookingModel.User_Id,
                Session_Id = bookingModel.Session_Id,
                Ticket_amount = bookingModel.Ticket_amount,
                Booking_date = bookingModel.Booking_date,
                Hall_Id = bookingModel.Hall_Id
            };
        }

        public static Booking ToBookingFromCreateDto(this CreateBookingRequestDto BookingDto)
        {
            return new Booking
            {
                User_Id = BookingDto.User_Id,
                Session_Id = BookingDto.Session_Id,
                Ticket_amount = BookingDto.Ticket_amount,
                Booking_date = BookingDto.Booking_date,
                Hall_Id = BookingDto.Hall_Id
            };
        }
    }
}