using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using System.Collections.Generic;

public class GenericService<TRepository, TEntity, TDto> : IGenericService<TEntity, TDto>
    where TRepository : IGenericRepository<TEntity>
    where TEntity : GenericModel
    where TDto : class
{
    private readonly TRepository _genericRepository;
    private readonly IMapper _mapper;

    public GenericService(TRepository genericRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> GetAll()
    {
        var arrayEntities = await _genericRepository.GetAll();
        return _mapper.Map<IEnumerable<TDto>>(arrayEntities);
    }

    public async Task<TDto> GetByDni(int dni)
    {
        var entity = await _genericRepository.GetByDni(dni);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> Add(TEntity entity)
    {
        return await _genericRepository.Add(entity);
    }

    public async Task<bool> Update(TEntity entity)
    {
        return await _genericRepository.Update(entity);
    }

    public async Task<bool> DeleteById(int id)
    {
        return await _genericRepository.DeleteById(id);
    }
}
