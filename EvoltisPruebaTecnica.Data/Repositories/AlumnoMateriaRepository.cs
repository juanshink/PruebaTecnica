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
    public class AlumnoMateriaRepository : GenericRepository<AlumnoMateria>, IAlumnoMateriaRepository
    {
        private MyDbContext context;
        private DbSet<AlumnoMateria> entities;

        public AlumnoMateriaRepository(MyDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<AlumnoMateria>();
        }
    }
}
