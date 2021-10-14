using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaitynasLab1.Data.Dtos.Clans
{
    public record CreateClanDto([Required] string Name, [Required] string Description);
}
