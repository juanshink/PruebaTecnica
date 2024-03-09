using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model.DTOs;
using EvoltisPruebaTecnica.Model;

public class ProfesorMateriaService : GenericService<IProfesorMateriaRepository, ProfesorMateria, ProfesorMateriaDTO>, IProfesorMateriaService
{
    public ProfesorMateriaService(IProfesorMateriaRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}