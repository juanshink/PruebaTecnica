using AutoMapper;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Profiles
{
    public class AlumnoProfile : GenericProfile<Alumno, AlumnoDTO>
    {
        public AlumnoProfile() 
        {
            CreateMap<Alumno, AlumnoDTO>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"));

        }
    }
}
