﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string Role { get; set; }

        //public PupilSession PupilSession { get; set; }
    }
}
