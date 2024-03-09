using System;
using System.Collections.Generic;
using System.Linq;
using EvoltisPruebaTecnica.Model;
using Microsoft.EntityFrameworkCore;

namespace EvoltisPruebaTecnica.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<AlumnoMateria> AlumnoMateria { get; set; }
        public DbSet<ProfesorMateria> ProfesorMateria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlumnoMateria>()
                .HasKey(am => new { am.AlumnoId, am.MateriaId });

            modelBuilder.Entity<AlumnoMateria>()
                .HasOne(am => am.Alumno)
                .WithMany(a => a.AlumnoMaterias)
                .HasForeignKey(am => am.AlumnoId);

            modelBuilder.Entity<AlumnoMateria>()
                .HasOne(am => am.Materia)
                .WithMany(m => m.AlumnoMateria)
                .HasForeignKey(am => am.MateriaId);

            modelBuilder.Entity<ProfesorMateria>()
                .HasKey(pm => new { pm.ProfesorId, pm.MateriaId });

            modelBuilder.Entity<ProfesorMateria>()
                .HasOne(pm => pm.Profesor)
                .WithMany(p => p.ProfesorMaterias)
                .HasForeignKey(pm => pm.ProfesorId);

            modelBuilder.Entity<ProfesorMateria>()
                .HasOne(pm => pm.Materia)
                .WithMany(m => m.ProfesorMaterias)
                .HasForeignKey(pm => pm.MateriaId);

     
        }
    }
}
