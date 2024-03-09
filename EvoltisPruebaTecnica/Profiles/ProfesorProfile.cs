using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Profiles
{
    public class ProfesorProfile : GenericProfile<Profesor, ProfesorDTO>
    {
        public ProfesorProfile()
        {
            CreateMap<Profesor, ProfesorDTO>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"));
        }
    }
}
