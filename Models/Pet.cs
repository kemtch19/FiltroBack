using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        [Column("id_pet")]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Possible null value for Name of pet")]
        public string? Name { get; set; }

        [Column("Specie")]
        [Required(ErrorMessage ="Possible null value for Specie of pet")]
        public string? Specie { get; set; }

        [Column("Race")]
        [Required(ErrorMessage ="Possible null value for Race of pet")]
        public string? Race { get; set; }

        [Column("DateBirth")]
        [Required(ErrorMessage ="Possible null value for DateBirth of pet")]
        public DateOnly? DateBirth { get; set; }

        [Column("Photo")]
        [Required(ErrorMessage ="Possible null value for Photo of pet")]
        public string? Photo { get; set; }

        [Column("OwnerId")]
        // Obtenemos el id para obetnerlo después
        [Required(ErrorMessage ="Possible null value for OwnerId of pet")]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }


        // Traemos la lista de las citas
        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}