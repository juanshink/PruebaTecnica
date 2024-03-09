using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Data.Repositories
{
    public class AlumnoRepository : GenericRepository<Alumno>, IAlumnoRepository
    {
        private MyDbContext context;
        private DbSet<Alumno> entities;

        public AlumnoRepository(MyDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Alumno>();
        }
    }
}