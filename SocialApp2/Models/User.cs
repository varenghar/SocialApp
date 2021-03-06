﻿using Microsoft.AspNetCore.Identity;
using SocialApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp2.Models
{
    public class User : IdentityUser
    {
        public List<Post> Posts { get; set; }
        public List<Friend> Friends { get; set; }

        public List<Invitation> InvitationReceived { get; set; }
    }
}
