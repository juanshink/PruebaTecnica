using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Services
{
    public class ProfesorService : GenericService<IProfesorRepository, Profesor, ProfesorDTO>, IProfesorService
    {
        public ProfesorService(IProfesorRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}