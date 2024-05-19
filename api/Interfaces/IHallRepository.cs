using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.Hall;

namespace api.Interfaces
{
    public interface IHallRepository
    {
        Task<List<Hall>> GetAllAsync();
        Task<Hall?> GetByIdAsync(int id);

        Task<Hall?> CreateAsync(Hall hallModel);
        
        Task<Hall?> UpdateAsync(int id, UpdateHallRequestDto HallDto);

        Task<Hall?> DeleteAsync(int id);
    }
}