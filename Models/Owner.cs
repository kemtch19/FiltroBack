using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    public class Owner
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Possible null value for Name of owner")]
        public string? Names { get; set; }

        [Required(ErrorMessage ="Possible null value for Lastname of owner")]
        public string? Lastnames { get; set; }

        [Required(ErrorMessage ="Possible null value for Address of owner")]
        public string? Address { get; set; }

        [Required(ErrorMessage ="Possible null value for Phone of owner")]
        public string? Phone { get; set; }


        // me recibe una lista de mascotas desde el modelo
        [JsonIgnore]
        public List<Pet>? Pets { get; set; }
    }
}