using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Context
{
    public class VeterinariaContext :  IdentityDbContext<Usuario>
    {
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options){}

        public DbSet<Bichinho> Bichinhos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<BanhoTosa> BanhoTosa { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");

            base.OnModelCreating(modelBuilder);
            

        }
    }
}
