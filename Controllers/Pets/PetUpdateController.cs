using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Pets
{
    [ApiController]
    [Route("/api/pet/update")]
    public class PetUpdateController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetUpdateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpPut("{Id}")]
        public ActionResult UpdatePet(Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Se esta creando el animal con datos nulos o erroneos");
            }
            try
            {
                _petRepository.Update(pet);
                return Ok($"La mascota con id {pet.Id} y con nombre {pet.Name} fue actualizada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar actualizar la mascota: {e.Message}");
            }
        }
    }
}