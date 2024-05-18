using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Users
{
    public class UpdateUsersRequestDto
    {
       public string Nickname { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Pass { get; set; }= string.Empty;
        public DateTime Regestration_date { get; set; }= DateTime.Now; 
    }
}