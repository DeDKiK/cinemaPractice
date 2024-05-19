using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Dtos.Users;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUsersRepository _useRepo;
        public UsersController(ApplicationDBContext context, IUsersRepository useRepo)
        {
            _useRepo = useRepo;
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var users = await _useRepo.GetAllAsync();
            var UsersDto = users.Select(s => s.ToUsersDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var users = await _useRepo.GetByIdAsync(id);

            if(users == null)
            {
                return NotFound();
            }

            return Ok(users.ToUsersDto());
        }

        [HttpPost]

        public async Task <IActionResult> Create([FromBody] CreateUsersRequestDto UsersDTO)
        {
            var usersModel = UsersDTO.ToUsersFromCreateDto();
            await _useRepo.CreateAsync(usersModel);

            return CreatedAtAction(nameof(GetById), new { id = usersModel.User_Id}, usersModel.ToUsersDto());
        }

        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
        { 
            var usersModel = await _useRepo.UpdateAsync(id, updateDto);
            
            if(usersModel == null)
                {

                    return NotFound();
                }



            return Ok(usersModel.ToUsersDto());

        }

        [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var UsersModel = await _useRepo.DeleteAsync(id);
    if (UsersModel == null)
    {
        return NotFound();
    }

    return NoContent();
}
   
    }
}