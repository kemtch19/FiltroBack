using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltroBack.Services.Interfaces
{
    public interface IPetRepository 
    {
        public object GetAll([FromQuery] int? page);
        public Pet GetOne(int id);
        public void Create(Pet pet);
        public void Update(Pet pet);
    }
}