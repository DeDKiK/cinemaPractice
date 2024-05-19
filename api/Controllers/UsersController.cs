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
        public IActionResult GetAll()
        {
            var users = _context.User.ToList()
                .Select(s => s.ToUsersDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var users = _context.User.Find(id);

            if(users == null)
            {
                return NotFound();
            }

            return Ok(users.ToUsersDto());
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateUsersRequestDto UsersDTO)
        {
            var usersModel = UsersDTO.ToUsersFromCreateDto();
            _context.User.Add(usersModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usersModel.User_Id}, usersModel.ToUsersDto());
        }

        [HttpPut]
        [Route("{id}")]     
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
        { 
            var usersModel = _context.User.FirstOrDefault(x => x.User_Id == id);
            
            
            if(usersModel == null)
                {

                    return NotFound();
                }

            usersModel.Nickname = updateDto.Nickname;
            usersModel.Email = updateDto.Email;
            usersModel.Pass = updateDto.Pass;
            usersModel.Regestration_date = updateDto.Regestration_date;
            _context.SaveChanges();
        

            return Ok(usersModel.ToUsersDto());

        }

        [HttpDelete("{id}")]
public IActionResult Delete([FromRoute] int id)
{
    var UsersModel = _context.User.FirstOrDefault(x => x.User_Id == id);
    if (UsersModel == null)
    {
        return NotFound();
    }
    _context.User.Remove(UsersModel);
    _context.SaveChanges();

    return NoContent();
}
   
    }
}