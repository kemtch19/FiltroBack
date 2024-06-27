using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Owners
{
    [ApiController]
    [Route("api/owner/create")]
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerCreateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpPost]
        public IActionResult CreateOwner(Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try
            {
                _ownerRepository.Create(owner);
                return Ok($"El propietario {owner.Names} fue creado exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar crear el propietario: {e.Message}");
            }
        }
    }
}