using WebColegioPagos.Models.Data;
using WebColegioPagos.Models;

namespace WebColegioPagos.Services
{
    public interface IApiService
    {
        /* Servicios del estudiante */
        public Task<List<Estudiante>> GetEstudiantes();
        public Task<Estudiante> GetEstudiante(int id);
        public Task<Estudiante> GetEstudiante(string cedula);
        public Task<Estudiante> AddEstudiante(RegistroEstudiante est);
        public Task<Estudiante> UpdateEstudiante(string cedula, ActualizacionEstudiante datos);
        public Task<Estudiante> UpdateEstudiante(int id, ActualizacionEstudiante datos);
        public Task<Estudiante> desactivarEstudiante(int id);
        public Task<Estudiante> activarEstudiante(int id, bool paga);

        /* Global - Cuota*/
        public Task<Global> obtenerCuota();
        public Task<Global> actualizarValor(int valor);

        /* Pago */
        public Task<List<Pago>> GetPagos();
        public Task<List<Pago>> GetPagosEstudiante(int id);
        public Task<List<ImpagoEstudiante>> GetImpagos();
        public Task<Pago> encontrarPago(int id);
        public Task<Pago> revertirUltimoPago(int id);
        public Task<List<Pago>> pagar(int id, int cantidad);

        /* Pensiones */
        public Task<List<Pension>> GetPensiones();
        public Task<Pension> GetPension(int id);
        public Task<Pension> AddPension(Pension pension);
        public Task<Pension> UpdatePension(int id, string nombre);
        public Task<Pension> DeletePension(int id);
    }
}
