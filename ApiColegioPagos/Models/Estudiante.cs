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

        public static Boolean validarCedula(string cedula)
        {
            if(cedula.Length != 10) return false;

            try
            {
                int sumaI = 0;
                int sumaP = 0;
                int aux = 0;

                for(int i = 0; i < cedula.Length; i+++)
                {
                    aux = int.Parse(cedula[i]);

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
