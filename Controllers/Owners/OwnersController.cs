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
                return Ok(new { informacion = $"Estos son los propietarios actualmente: ", propietarios });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los cursos: {e.Message}");
            }
        }

        /* [HttpGet]
        public IActionResult GetOwners()
        {
            try
            {
                var propietarios = _ownerRepository.GetAll();
                return Ok(new { informacion = $"Estos son los propietarios actualmente: {propietarios.Count()}", propietarios });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todos los cursos: {e.Message}");
            }
        }  */

        [HttpGet("{Id}")]
        public ActionResult GetOwner(int id)
        {
            try
            {
                var propietario = _ownerRepository.GetOne(id);
                if (propietario == null)
                {
                    return NotFound($"No se encontró el propietario con el id: {id}");
                }
                return Ok(new { informacion = $"El propietario con id {propietario.Id} y con nombre {propietario.Names} fue encontrado y estos son sus datos: ", propietario });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener el propietario de la base de datos, posiblemente no exista el propietario con id: {id} y el mensaje es: {e.Message}");
            }
        }

        // listar mascotas que tiene una persona
        [HttpGet, Route("{iD}/Owner")]
        public ActionResult<IEnumerable<Pet>> GetPetByOneOwner(int id)
        {
            var mascota = _ownerRepository.GetPetsByOwner(id);
            if (mascota == null)
            {
                return NotFound($"mascotas por este id {id} no encontradas");
            }
            try{
                return Ok(mascota);
            }catch(Exception e){
                return BadRequest($"Error al intentar obtener las mascotas de la base de datos, posiblemente no existan mascotas para el propietario con id: {id} y el mensaje es: {e.Message}");
            }
        }
    }
}