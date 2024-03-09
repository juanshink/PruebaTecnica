using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model.DTOs;
using EvoltisPruebaTecnica.Model;

public class AlumnoMateriaService : GenericService<IAlumnoMateriaRepository, AlumnoMateria, AlumnoMateriaDTO>, IAlumnoMateriaService
{
    public AlumnoMateriaService(IAlumnoMateriaRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
    {
    }
}