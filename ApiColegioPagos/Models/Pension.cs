using System.ComponentModel.DataAnnotations;

namespace ApiColegioPagos.Models
{
    public class Pension
    {
        [Key]
        public int Pen_id { get; set; }

        [Required, MaxLength(50)]
        public string Pen_nombre { get; set; }

        [Required]
        [Range(0, 1000)]
        [RegularExpression(@"^\d+(\.\d{2})?$")]
        public float Pen_valor { get; set; }

        public virtual ICollection<Estudiante> Estudites { get; set;}
        public virtual ICollection<Pago> Pagos { get; set;}
    }
}
