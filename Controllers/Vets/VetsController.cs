using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Vets
{
    [ApiController]
    [Route("api/vets")]
    public class VetsController : ControllerBase
    {
        private readonly IVetRepository _vetRepository;
        public VetsController(IVetRepository vetsRepository)
        {
            _vetRepository = vetsRepository;
        }

        [HttpGet]
        public IActionResult GetVets()
        {
            try
            {
                var Vet = _vetRepository.GetAll();
                return Ok(new { Success = $"Estos son los veterinarios actualmente disponibles: {Vet.Count()} ", Vet });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los veterinarios: {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetVets(int id)
        {
            try
            {
                var vet = _vetRepository.GetOne(id);
                if (vet == null)
                {
                    return NotFound($"No se encontró el veterinario con el id: {id}");
                }
                return Ok(new { Success = $"El veterinario con id {vet.Id} y con nombre {vet.Name} fue encontrado y estos son sus datos: ", vet });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener el veterinario de la base de datos, posiblemente no exista el veterinario con id: {id} y el mensaje es: {e.Message}");
            }
        }
    }
}