using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;

namespace FiltroBack.Services.Interfaces
{
    public interface IVetRepository
    {
        public IEnumerable<Vet> GetAll();
        public Vet GetOne(int id);
    }
}