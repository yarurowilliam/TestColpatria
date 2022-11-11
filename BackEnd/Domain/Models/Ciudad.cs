using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string NombreCiudad { get; set; }
    }
}
