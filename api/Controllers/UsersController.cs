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

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var users = await _context.User.ToListAsync();
            var UsersDto = users.Select(s => s.ToUsersDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var users = await _context.User.FindAsync(id);

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
            await _context.User.AddAsync(usersModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = usersModel.User_Id}, usersModel.ToUsersDto());
        }

        [HttpPut]
        [Route("{id}")]     
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
        { 
            var usersModel = await _context.User.FirstOrDefaultAsync(x => x.User_Id == id);
            
            
            if(usersModel == null)
                {

                    return NotFound();
                }

            usersModel.Nickname = updateDto.Nickname;
            usersModel.Email = updateDto.Email;
            usersModel.Pass = updateDto.Pass;
            usersModel.Regestration_date = updateDto.Regestration_date;
            await _context.SaveChangesAsync();
        

            return Ok(usersModel.ToUsersDto());

        }

        [HttpDelete("{id}")]
public async Task <IActionResult> Delete([FromRoute] int id)
{
    var UsersModel = await _context.User.FirstOrDefaultAsync(x => x.User_Id == id);
    if (UsersModel == null)
    {
        return NotFound();
    }
    _context.User.Remove(UsersModel);
    await _context.SaveChangesAsync();

    return NoContent();
}
   
    }
}