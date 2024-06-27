using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    public class Quote
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Possible null value for Date of quote")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage ="Possible null value for Description of quote")]
        public string? Description { get; set; }


        // traemos los dos id de las tablas para que las podamos conectar
        [Required(ErrorMessage ="Possible null value for PetId of quote")]
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        [Required(ErrorMessage ="Possible null value for VetId of quote")]
        public int VetId { get; set; }
        public Vet? Vet { get; set; }
    }
}