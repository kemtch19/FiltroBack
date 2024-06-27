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
    [Route("api/pet/create")]
    public class PetCreateController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetCreateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpPost]
        public IActionResult CreatePet(Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try
            {
                _petRepository.Create(pet);
                return Ok($"La mascota {pet.Name} fue creada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar crear la mascota: {e.Message}");
            }
        }
    }
}