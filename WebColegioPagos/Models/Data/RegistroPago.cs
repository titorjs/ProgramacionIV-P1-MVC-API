using System.ComponentModel.DataAnnotations;

namespace WebColegioPagos.Models.Data
{
    public class RegistroPago
    {

        [Required, Range(1, 10)]
        public int Pag_cuota { get; set; }

        [Required]
        public int Estudiante { get; set; }

        [Required]
        public int Pension { get; set; }
    }
}
