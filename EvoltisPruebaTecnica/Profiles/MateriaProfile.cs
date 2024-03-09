using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Profiles
{
    public class MateriaProfile : GenericProfile<Materia, MateriaDTO>
    {
        public MateriaProfile() 
        {
            CreateMap<Materia, MateriaDTO>();
        }
    }
}
