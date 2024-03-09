using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Services
{
    public class MateriaService : GenericService<IMateriaRepository, Materia, MateriaDTO>, IMateriaService
    {
        public MateriaService(IMateriaRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}