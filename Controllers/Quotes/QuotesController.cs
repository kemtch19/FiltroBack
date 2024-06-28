using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Controllers.Quotes
{
    [ApiController]
    [Route("/api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        public IActionResult GetQuotes()
        {
            try
            {
                var quote = _quoteRepository.GetAll();
                return Ok(new { Success = $"Estas son las citas actualmente: {quote.Count()} ", quote });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar encontrar a todas las citas: {e.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetQuotes(int id)
        {
            try
            {
                var quote = _quoteRepository.GetOne(id);
                if (quote == null)
                {
                    return NotFound($"No se encontró la cita con el id: {id}");
                }
                return Ok(new { Success = $"La cita con id {quote.Id} fue encontrada y estos son sus datos: ", quote });
            }
            catch (Exception e)
            {
                return BadRequest($"Error al obtener la cita de la base de datos, posiblemente no exista la cita con id: {id} y el mensaje es: {e.Message}");
            }
        }
        // vamos a listar las fechas en especifico de citas
        [HttpGet, Route("{Date}/date")]
        public ActionResult<IEnumerable<Quote>> GetQuoteDate(DateTime date)
        {
            var cita = _quoteRepository.dateSpecific(date);
            if (cita == null)
            {
                return NotFound($"las citas para esta fecha en especifico {date} no se encontraron");
            }
            try
            {
                return Ok(cita);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar obtener las citas para la fecha {date}: {e.Message}");
            }
        }
    }
}