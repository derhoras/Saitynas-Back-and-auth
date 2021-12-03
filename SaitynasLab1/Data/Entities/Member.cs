using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Auth.Model;
using SaitynasLab1.Data.Dtos.Auth;

namespace SaitynasLab1.Data.Entities
{
    public class Member : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Goal { get; set; }
        public DateTime JoinDate { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public string UserId { get; set; }
        public SaitynasUser User { get; set; }
    }
}
