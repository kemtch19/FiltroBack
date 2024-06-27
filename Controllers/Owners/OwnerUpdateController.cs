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
    [Route("api/owner/update")]
    public class OwnerUpdateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerUpdateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpPut("{id}")]
        public ActionResult UpdateOwner(Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Se esta creando el propietario con datos nulos o erroneos");
            }
            try
            {
                _ownerRepository.Update(owner);
                return Ok($"El propietario con id {owner.Id} y con nombre {owner.Names} fue actualizado exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar actualizar el propietario: {e.Message}");
            }
        }
    }
}