using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Services.Interfaces
{
    public interface IOwnerRepository
    {
        public object GetAll([FromQuery] int? page);
        // public IEnumerable<Owner> GetAll();
    }
}