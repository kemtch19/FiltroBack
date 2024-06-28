using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Data;
using FiltroBack.Models;
using FiltroBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiltroBack.Services.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly FiltroBackContext _context;
        private readonly int records = 2;
        public PetRepository(FiltroBackContext context)
        {
            _context = context;
        }

        public object GetAll([FromQuery] int? page)
        {
            int _page = page ?? 1;
            decimal totalRecords = _context.Pets.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / records));

            var pet = _context.Pets
                .Skip((_page - 1) * records)
                .Take(records)
                .Include(o => o.Owner)
                .ToList();

            var data = new
            {
                pages = totalPages,
                currentPage = _page,
                data = pet
            };

            return data;
        }

        public Pet GetOne(int id)
        {
            return _context.Pets.Include(o => o.Owner).FirstOrDefault(p => p.Id == id);
        }

        public void Create(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }
        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        
    }
}