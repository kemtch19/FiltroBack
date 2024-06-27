using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Data;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Services.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly FiltroBackContext _context;
        private readonly int records = 2; /* número de páginas las cuales mostraremos en la paginación */
        public OwnerRepository(FiltroBackContext context)
        {
            _context = context;
        }

        /* Lógica de la páginación donde pasamos el número de páginas, contamos cuantas se pueden, eskipeamos las que sean necesarias y creamos el data con la información de las páginas */
        public object GetAll([FromQuery] int? page)
        {
            int _page = page ?? 1; 
            decimal totalRecords = _context.Owners.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));

            var owner = _context.Owners
                .Skip((_page - 1) * records)
                .Take(records)
                .ToList();

            var data = new
            {
                pages = totalPages,
                currentPage = _page,
                data = owner
            };

            return data;
        }
    }
}