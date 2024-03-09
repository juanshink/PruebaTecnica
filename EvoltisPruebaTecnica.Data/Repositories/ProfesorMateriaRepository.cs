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
    public class ProfesorMateriaRepository : GenericRepository<ProfesorMateria>, IProfesorMateriaRepository
    {
        private MyDbContext context;
        private DbSet<ProfesorMateria> entities;

        public ProfesorMateriaRepository(MyDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<ProfesorMateria>();
        }
    }
}
