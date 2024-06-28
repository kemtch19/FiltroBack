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
    [Route("/api/quote/create")]
    public class QuoteCreateController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteCreateController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpPost]
        public IActionResult CreateQuote(Quote quote)
        {
            if (quote == null)
            {
                return BadRequest("Error, ingresaste datos nulos o diferentes en los campos asignados");
            }
            try
            {
                _quoteRepository.Create(quote);
                return Ok($"La cita con id {quote.Id} y con nombre {quote.Description} fue creada exitosamente, revisa tu correo.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar crear la cita: {e.Message}");
            }
        }
    }
}