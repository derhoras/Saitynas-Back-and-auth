using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaitynasLab1.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
