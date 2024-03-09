using EvoltisPruebaTecnica.Data;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoltisPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController :GenericController<Materia, MateriaDTO>
    {
        private IMateriaService _services;

        public MateriaController(IMateriaService service) : base(service)
        {
            _services = service;
        }
    }
}
