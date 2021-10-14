using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaitynasLab1.Data.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Goal { get; set; }
        public DateTime JoinDate { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; } 
    }
}
