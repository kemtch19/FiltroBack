using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    [Table("Vets")]
    public class Vet
    {
        [Key]
        [Column("id_Vets")]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage ="Possible null value for Name of vet")]
        public string? Name { get; set; }

        [Column("Phone")]
        [Required(ErrorMessage ="Possible null value for Phone of vet")]
        public string? Phone { get; set; }

        [Column("Address")]
        [Required(ErrorMessage ="Possible null value for Address of vet")]
        public string? Address { get; set; }

        [Column("YearsExperiencie")]
        [Required(ErrorMessage ="Possible null value for YearsExperiencie of vet")]
        public int? YearsExperiencie { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "Possible null value for Email of vet")]
        public string? Email { get; set; }


        [JsonIgnore]
        public List<Quote>? Quotes { get; set; }
    }
}