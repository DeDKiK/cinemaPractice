using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Films
{
    public class CreateFilmsRequestDto
    {
    public string Name { get; set; }= string.Empty;
    public string Genre { get; set; }= string.Empty;
    public string Producer { get; set; }= string.Empty;
    public string Description { get; set; }= string.Empty;
    public int Duration { get; set; }
    public DateTime Release_Date { get; set; }
    public string Country { get; set; } = string.Empty;
    public int Age_rating { get; set; }
    }
}