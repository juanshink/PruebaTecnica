using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EvoltisPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorMateriaController : GenericController<ProfesorMateria, ProfesorMateriaDTO>
    {
        private IProfesorMateriaService _services;

        public ProfesorMateriaController(IProfesorMateriaService service) : base(service)
        {
            _services = service;
        }
    }
}
