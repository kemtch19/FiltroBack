using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Data;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;

namespace FiltroBack.Services.Repositories
{
    public class VetRepository : IVetRepository
    {
        private readonly FiltroBackContext _context;
        public VetRepository(FiltroBackContext context)
        {
            _context = context;
        }

        public IEnumerable<Vet> GetAll()
        {
            return _context.Vets.ToList();
        }
        public Vet GetOne(int id)
        {
            return _context.Vets.FirstOrDefault(v => v.Id == id);
        }
    }
}