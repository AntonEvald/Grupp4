using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingProj.Models;

namespace DataBase.Models
{
    public class ProfilViewModel
    {
        public ApplicationUser User { get; set; }
        public  ICollection<Posts> Posts { get; set; }
    }
}
