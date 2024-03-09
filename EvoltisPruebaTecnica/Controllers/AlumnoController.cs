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
    public class AlumnoController : GenericController<Alumno, AlumnoDTO>
    {
        private IAlumnoService _services;

        public AlumnoController(IAlumnoService service) : base(service)
        {
            _services = service;
        }
    }
}
