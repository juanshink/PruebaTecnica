using AutoMapper;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;

namespace EvoltisPruebaTecnica.Profiles
{
    public class GenericProfile<TModel, TDto> : Profile
        where TModel : GenericModel
        where TDto : GenericModelDTO
    {
        public GenericProfile()
        {
            
        }
    }
}