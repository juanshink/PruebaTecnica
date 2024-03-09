using EvoltisPruebaTecnica.Model.DTOs;
using EvoltisPruebaTecnica.Model;

namespace EvoltisPruebaTecnica.Profiles
{
    public class AlumnoMateriaProfile : GenericProfile<AlumnoMateria, AlumnoMateriaDTO>
    {
        public AlumnoMateriaProfile()
        {
            CreateMap<AlumnoMateria, AlumnoMateriaDTO>();
        }
    }
}
