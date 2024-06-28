using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Controllers.Mail;
using FiltroBack.Data;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiltroBack.Services.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly FiltroBackContext _context;
        public QuoteRepository(FiltroBackContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes.Include(p => p.Pet).Include(v => v.Vet).ToList();
        }

        public Quote GetOne(int id)
        {
            return _context.Quotes.Include(p => p.Pet).Include(v => v.Vet).FirstOrDefault(q => q.Id == id);
        }

        public void Create(Quote quote)
        {
            // funciones normales del crear
            _context.Quotes.Add(quote);
            _context.SaveChanges();

            // Obtenemos los datos necesarios que vamos a mandar al email
            var pet = _context.Pets.Find(quote.PetId);
            var vet = _context.Vets.Find(quote.VetId);
            var owner = _context.Owners.Find(pet.OwnerId);

            // instanciamos el email
            MailController Email = new MailController();
            Email.SendEmail(owner.Email, owner.Names, quote.Date, quote.Description, vet.Name, vet.Phone, vet.Email, pet.Name);
        }

        public void Update(Quote quote)
        {
            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }
        // Lista de citas para una fecha en especifico
        public IEnumerable<Quote> dateSpecific(DateTime date)
        {
            var date2 = _context.Quotes.Include(p => p.Pet).Include(v => v.Vet).Where(q=>q.Date==date);
            return date2;
        }
    }
}