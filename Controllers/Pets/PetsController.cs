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
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        public object GetPets([FromQuery] int? page)
        {
            try
            {
                var mascota = _petRepository.GetAll(page);
                return Ok(new { informacion = $"Estos son las mascotas actualmente: ", mascota });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los cursos: {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetPets(int id)
        {
            try
            {
                var mascota = _petRepository.GetOne(id);
                if (mascota == null)
                {
                    return NotFound($"No se encontró la mascota con el id: {id}");
                }
                return Ok(new { informacion = $"La mascota con id {mascota.Id} y con nombre {mascota.Name} fue encontrada y estos son sus datos: ", mascota });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener la mascota de la base de datos, posiblemente no exista la mascota con id: {id} y el mensaje es: {e.Message}");
            }
        }
    }
}