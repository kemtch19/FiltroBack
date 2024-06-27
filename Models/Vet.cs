using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    public class Vet
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Possible null value for Name of vet")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Possible null value for Phone of vet")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="Possible null value for Address of vet")]
        public string? Address { get; set; }

        [Required(ErrorMessage ="Possible null value for YearsExperiencie of vet")]
        public int? YearsExperiencie { get; set; }

        [Required(ErrorMessage = "Possible null value for Email of vet")]
        public string? Email { get; set; }


        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}