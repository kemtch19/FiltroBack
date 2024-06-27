using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public object GetOwners([FromQuery] int? page)
        {
            try
            {
                var propietarios = _ownerRepository.GetAll(page);
                return Ok(new { información = $"Estos son propietarios actualmente: ", propietarios });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los cursos: {e.Message}");
            }
        }
    }
}