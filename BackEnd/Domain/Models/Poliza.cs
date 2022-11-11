using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Models
{
    public class Poliza
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string PlacaVehiculo { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string IdentificacionTomador { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaFin { get; set; }
        [Column(TypeName = "date")]
        public DateTime VencimientoPoliza { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int IDCiudad { get; set; }
    }
}
