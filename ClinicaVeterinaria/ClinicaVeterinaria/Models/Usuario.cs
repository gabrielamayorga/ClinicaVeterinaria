﻿
using Microsoft.AspNetCore.Identity;
using System;

namespace ClinicaVeterinaria.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario() => CriadoEm = DateTime.Now;
        public DateTime CriadoEm { get; set; }
    }
}
