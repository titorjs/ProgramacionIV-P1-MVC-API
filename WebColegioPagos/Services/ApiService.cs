using ApiColegioPagos.Models;
using ApiColegioPagos.Views;
using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebColegioPagos.Services
{
    public class ApiService : IApiService
    {

        public static string _baseUrl;
        public HttpClient _httpClient;

        public ApiService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }


        public async Task<Estudiante> activarEstudiante(int id, bool paga)
        {
            var respuesta = await _httpClient.PatchAsync($"Estudiante/activar/{id}/{paga}", null);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public Task<Global> actualizarValor(int valor)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> AddEstudiante(RegistroEstudiante est)
        {
            throw new NotImplementedException();
        }

        public async Task<Estudiante> desactivarEstudiante(int id)
        {
            var respuesta = await _httpClient.PatchAsync($"Estudiante/desactivar/{id}", null);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public Task<Pago> encontrarPago(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Estudiante> GetEstudiante(int id)
        {
            var respuesta = await _httpClient.GetAsync($"Estudiante/id/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public async Task<Estudiante> GetEstudiante(string cedula)
        {
            var respuesta = await _httpClient.GetAsync($"Estudiante/cedula/{cedula}");
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            var respuesta = await _httpClient.GetAsync($"Estudiante");
            if (respuesta.IsSuccessStatusCode)
            {
                List<Estudiante> est = JsonConvert.DeserializeObject<List<Estudiante>>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return new List<Estudiante>();
        }

        public Task<List<ImpagoEstudiante>> GetImpagos()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pago>> GetPagos()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pago>> GetPagosEstudiante(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Global> obtenerCuota()
        {
            var respuesta = await _httpClient.GetAsync($"cuota");
            if (respuesta.IsSuccessStatusCode)
            {
                Global cuota = JsonConvert.DeserializeObject<Global>
                                (await respuesta.Content.ReadAsStringAsync());
                return cuota;
            }

            return null;
        }

        public Task<Pago> pagar(int id, int cantidad)
        {
            throw new NotImplementedException();
        }

        public Task<Pago> revertirUltimoPago(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Estudiante> UpdateEstudiante(string cedula, ActualizacionEstudiante datos)
        {
            var respuesta = await _httpClient.PutAsJsonAsync<ActualizacionEstudiante>($"Estudiante/cedula/{cedula}", datos);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public async Task<Estudiante> UpdateEstudiante(int id, ActualizacionEstudiante datos)
        {
            var respuesta = await _httpClient.PutAsJsonAsync<ActualizacionEstudiante>($"Estudiante/cedula/{id}", datos);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }
    }
}
