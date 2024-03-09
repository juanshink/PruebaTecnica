using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.IServices
{
    public interface IAlumnoService : IGenericService<Alumno, AlumnoDTO>
    {
        Task<bool> InscribirAlumno(int idalumno, int idmateria);
        Task<bool> BajaAlumno(int idalumno, int idmateria);
    }
}
