using AutoMapper;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Services
{
    public class AlumnoService : GenericService<IAlumnoRepository, Alumno, AlumnoDTO>, IAlumnoService
    {
        public AlumnoService(IAlumnoRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public async Task<bool> InscribirAlumno(int idalumno, int idmateria)
        {
            return true;
        }
        public async Task<bool> BajaAlumno(int idalumno, int idmateria)
        {
            return true;
        }

        //public async Task<IEnumerable<Alumno>> GetAlumnosByCurso(int idCurso)
        //{
        //    return true;
        //}

        //public async Task<IEnumerable<Alumno>> GetAlumnosByProfesor(int idProfesor)
        //{
        //    return true;
        //}
    }
}