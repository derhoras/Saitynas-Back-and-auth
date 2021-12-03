using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Auth.Model;
using SaitynasLab1.Data.Dtos.Auth;

namespace SaitynasLab1.Data.Entities
{
    public class Clan : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string UserId { get; set; }
        public SaitynasUser User { get; set; }
    }
}
        