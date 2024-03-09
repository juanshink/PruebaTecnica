using EvoltisPruebaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Data.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : GenericModel
    {
        public Task<List<TEntity>> GetAll();
        public Task<TEntity> GetByDni(int dni);
        public Task<bool> Add(TEntity entity);
        public Task<bool> Update(TEntity entity);
        public Task<bool> DeleteById(int Id);

    }
}

