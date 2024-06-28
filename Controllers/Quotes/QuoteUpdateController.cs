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
    [Route("api/quote/update")]
    public class QuoteUpdateController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteUpdateController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateQuote(Quote quote)
        {
            if (quote == null)
            {
                return BadRequest("Se esta creando la cita con datos nulos o erroneos");
            }
            try
            {
                _quoteRepository.Update(quote);
                return Ok($"La cita con id {quote.Id} fue actualizada exitosamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al intentar actualizar la cita: {e.Message}");
            }
        }
    }
}