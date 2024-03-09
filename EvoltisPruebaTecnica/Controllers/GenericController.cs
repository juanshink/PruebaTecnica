using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Model.DTOs;
using EvoltisPruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvoltisPruebaTecnica.Controllers
{
    public class GenericController<T, TDto> : Controller 
            where T : GenericModel
            where TDto : GenericModelDTO
    {
        private readonly IGenericService<T, TDto> _service;

        public GenericController(IGenericService<T, TDto> service)
        {
            _service = service;
        }

        [HttpGet, Route("getAll")]
        public async Task<ActionResult<List<TDto>>> GetAll()
        {
            var data = await _service.GetAll();
            return Json(data);
        }

        [HttpGet, Route("getByDNI")]
        public async Task<ActionResult<TDto>> GetByDni(int dni)
        {
            var data = await _service.GetByDni(dni);
            return Json(data);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.LastModifiedDate = DateTime.UtcNow;

            var data = await _service.Add(entity);
            return Json(data);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(T entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            var data = await _service.Update(entity);
            return Json(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int Id)
        {
            var data = await _service.DeleteById(Id);
            return Ok(data);
        }
    }
}
