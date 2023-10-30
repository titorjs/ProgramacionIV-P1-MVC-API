using ApiColegioPagos.Models;
using ApiColegioPagos.Views;
using Microsoft.AspNetCore.Mvc;

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
        public Task<Pago> pagar(int id, int cantidad);
    }
}
