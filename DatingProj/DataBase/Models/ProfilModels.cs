using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingProj.Models;

namespace DatingProj.Models
{
    public class ProfilViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Posts> Posts { get; set; }
        public Posts Post { get; set; }
    }
}
