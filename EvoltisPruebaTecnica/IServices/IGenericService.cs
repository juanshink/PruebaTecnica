using EvoltisPruebaTecnica.Model;

namespace EvoltisPruebaTecnica.IServices
{
    public interface IGenericService<TEntity, TDto> where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetByDni(int dni);
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> DeleteById(int id);

    }
}
