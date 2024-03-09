using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Profiles
{
    public class ProfesorMateriaProfile : GenericProfile<ProfesorMateria, ProfesorMateriaDTO>
    {
        public ProfesorMateriaProfile()
        {
            CreateMap<ProfesorMateria, ProfesorMateriaDTO>();
        }
    }
}
