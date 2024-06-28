using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;

namespace FiltroBack.Services.Interfaces
{
    public interface IQuoteRepository
    {
        public IEnumerable<Quote> GetAll();
        public Quote GetOne(int id);
        public void Create(Quote quote);
        public void Update(Quote quote);
        public IEnumerable<Quote> dateSpecific(DateTime date);
    }
}