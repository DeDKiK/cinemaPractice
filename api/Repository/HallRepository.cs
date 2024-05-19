using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Hall;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Repository
{
    public class HallRepository : IHallRepository
    {
        private readonly ApplicationDBContext _context;
        public HallRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Hall?> CreateAsync(Hall hallModel)
        {
            await _context.AddAsync(hallModel);
            await _context.SaveChangesAsync();
            return hallModel;
        }

        public async Task<Hall?> DeleteAsync(int id)
        {
             var hallModel = await _context.Hall.FirstOrDefaultAsync(x => x.Hall_Id == id);
            if (hallModel == null)
            {
                return null;
            }

            _context.Hall.Remove(hallModel);
            await _context.SaveChangesAsync();
            return hallModel;
        }

        public async Task<List<Hall>> GetAllAsync()
        {
            return await _context.Hall.ToListAsync();
        }

        public async Task<Hall?> GetByIdAsync(int id)
        {
            return await _context.Hall.FindAsync(id);
        }

        public async Task<Hall?> UpdateAsync(int id, UpdateHallRequestDto HallDto)
        {
            var exixstingHall = await _context.Hall.FirstOrDefaultAsync(x => x.Hall_Id == id);

            if (exixstingHall == null)
            {
                return null;
            }

            exixstingHall.Row_amount = HallDto.Row_amount;
            exixstingHall.Amount_seats_in_a_row = HallDto.Amount_seats_in_a_row;

            await _context.SaveChangesAsync();
            
            return exixstingHall;
        }
    }

  
}