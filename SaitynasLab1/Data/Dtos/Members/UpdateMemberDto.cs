using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaitynasLab1.Data.Dtos.Members
{
    public record UpdateMemberDto([Required]string Goal);
}
