using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiltroBack.Models
{
    [Table("Owners")]
    public class Owner
    {
        [Key]
        [Column("id_owners")]
        [Required]
        public int Id { get; set; }

        [Column("Names")]
        [Required(ErrorMessage ="Possible null value for Name of owner")]
        public string? Names { get; set; }

        [Column("LastNames")]
        [Required(ErrorMessage ="Possible null value for Lastname of owner")]
        public string? Lastnames { get; set; }

        [Column("Email")]
        [Required(ErrorMessage ="Possible null value for Email of owner")]
        public string? Email { get; set; }

        [Column("Address")]
        [Required(ErrorMessage ="Possible null value for Address of owner")]
        public string? Address { get; set; }

        [Column("Phone")]
        [Required(ErrorMessage ="Possible null value for Phone of owner")]
        public string? Phone { get; set; }


        // me recibe una lista de mascotas desde el modelo
        [JsonIgnore]
        public List<Pet>? Pets { get; set; }
    }
}