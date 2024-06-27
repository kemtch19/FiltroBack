using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroBack.Data
{
    public class FiltroBackContext : DbContext
    {
        public FiltroBackContext(DbContextOptions<FiltroBackContext> options) : base(options){}

        public DbSet<Owner> Owners{ get; set;}
        public DbSet<Pet> Pets{ get; set;}
        public DbSet<Quote> Quotes{ get; set;}
        public DbSet<Vet> Vets{ get; set;}
    }
}