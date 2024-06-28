using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using FiltroBack.Services;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Owners
{
    [ApiController]
    [Route("api/owner/create")]
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
                private readonly SlackNotifier _slackNotifier;
        public OwnerCreateController(IOwnerRepository ownerRepository, SlackNotifier slackNotifier)
        {
            _ownerRepository = ownerRepository;
            _slackNotifier = slackNotifier;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner(Owner owner)
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
                await _slackNotifier.NotifyAsync(e.StackTrace);
                return BadRequest($"Error al intentar crear el propietario: {e.Message}");
            }
        }
    }
}