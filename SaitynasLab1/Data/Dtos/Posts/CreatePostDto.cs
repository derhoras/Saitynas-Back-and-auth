using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SaitynasLab1.Data.Dtos.Posts
{
    public record CreatePostDto(int Id, [Required] string Header, [Required] string Body);
}
