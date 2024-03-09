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
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesorRepository
    {
        private MyDbContext context;
        private DbSet<Profesor> entities;

        public ProfesorRepository(MyDbContext context) : base(context)
        {
            this.context = context;
            entities = context.Set<Profesor>();
        }
    }
}