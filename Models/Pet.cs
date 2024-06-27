using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    public class Pet
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Possible null value for Name of pet")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Possible null value for Specie of pet")]
        public string? Specie { get; set; }

        [Required(ErrorMessage ="Possible null value for Race of pet")]
        public string? Race { get; set; }

        [Required(ErrorMessage ="Possible null value for DateBirth of pet")]
        public DateOnly? DateBirth { get; set; }

        [Required(ErrorMessage ="Possible null value for Photo of pet")]
        public string? Photo { get; set; }


        // Obtenemos el id para obetnerlo después
        [Required(ErrorMessage ="Possible null value for OwnerId of pet")]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }


        // Traemos la lista de las citas
        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}