using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaitynasLab1.Data.Dtos.Clans
{
    public record UpdateClanDto([Required] string Name);
}
