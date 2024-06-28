using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    [Table("Quotes")]
    public class Quote
    {
        [Key]
        [Column("id_quotes")]
        [Required]
        public int Id { get; set; }

        [Column("Date")]
        [Required(ErrorMessage ="Possible null value for Date of quote")]
        public DateTime? Date { get; set; }

        [Column("Description")]
        [Required(ErrorMessage ="Possible null value for Description of quote")]
        public string? Description { get; set; }


        // traemos los dos id de las tablas para que las podamos conectar
        [Column("PetId")]
        [Required(ErrorMessage ="Possible null value for PetId of quote")]
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        [Column("VetID")]
        [Required(ErrorMessage ="Possible null value for VetId of quote")]
        public int VetId { get; set; }
        public Vet? Vet { get; set; }
    }
}