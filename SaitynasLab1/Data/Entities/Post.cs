using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Auth.Model;
using SaitynasLab1.Data.Dtos.Auth;

namespace SaitynasLab1.Data.Entities
{
    public class Post : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public string UserId { get; set; }
        public SaitynasUser User { get; set; }
    }
}
