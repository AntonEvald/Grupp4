﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingProj.Controllers;
using DatingProj.Models;

namespace DataBase.Models
{
    public class ProfilViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Posts> Posts { get; set; }
        public List<string> FriendRequests { get; set; }
        public List<string> AcceptedFriends { get; set; }
    }
}

