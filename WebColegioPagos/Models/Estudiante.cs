using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiColegioPagos.Models
{
    public class Estudiante
    {
        [Key]
        public int Est_id { get; set; }

        [Required, MaxLength(10)]
        public string Est_cedula { get; set; }

        [Required, MaxLength(100)]
        public string Est_nombre { get; set; }

        [Required, MaxLength(150)]
        public string Est_direccion { get; set; }

        [Required]
        public bool Est_activo { get; set; }

        [Required]
        public int Pension { get; set; }

    }
}
