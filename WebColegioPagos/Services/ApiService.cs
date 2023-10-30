using WebColegioPagos.Models;
using Newtonsoft.Json;
using System.Text;
using WebColegioPagos.Models.Data;

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
            var respuesta = await _httpClient.PatchAsync($"Estudiante/activar/{id}/true", null);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante est = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return new Estudiante();
        }

        public async Task<Global> actualizarValor(int valor)
        {
            var respuesta = await _httpClient.PutAsync($"Global/cuota/{valor}", null);
            if (respuesta.IsSuccessStatusCode)
            {
                Global cuota = JsonConvert.DeserializeObject<Global>
                                (await respuesta.Content.ReadAsStringAsync());
                return cuota;
            }

            return null;
        }

        public async Task<Estudiante> AddEstudiante(RegistroEstudiante est)
        {
            var content = new StringContent(JsonConvert.SerializeObject(est), Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync($"Estudiante", content);
            if (respuesta.IsSuccessStatusCode)
            {
                Estudiante estudiante = JsonConvert.DeserializeObject<Estudiante>
                                (await respuesta.Content.ReadAsStringAsync());
                return estudiante;
            }
            return null;
        }

        public async Task<Pension> AddPension(Pension pension)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pension), Encoding.UTF8, "application/json");
            var respuesta = await _httpClient.PostAsync($"Pension", content);
            if (respuesta.IsSuccessStatusCode)
            {
                Pension p = JsonConvert.DeserializeObject<Pension>
                                (await respuesta.Content.ReadAsStringAsync());
                return p;
            }
            return null;
        }

        public async Task<Pension> DeletePension(int id)
        {
            var respuesta = await _httpClient.DeleteAsync($"Pension/id/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                Pension p = JsonConvert.DeserializeObject<Pension>
                                (await respuesta.Content.ReadAsStringAsync());
                return p;
            }

            return null;
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

        public async Task<Pago> encontrarPago(int id)
        {
            var respuesta = await _httpClient.GetAsync($"Pago/pago/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                Pago pago = JsonConvert.DeserializeObject<Pago>
                                (await respuesta.Content.ReadAsStringAsync());
                return pago;
            }

            return null;
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

        public async Task<List<ImpagoEstudiante>> GetImpagos()
        {
            var respuesta = await _httpClient.GetAsync($"Pago/impagos");
            if (respuesta.IsSuccessStatusCode)
            {
                List<ImpagoEstudiante> impagos = JsonConvert.DeserializeObject<List<ImpagoEstudiante>>
                                (await respuesta.Content.ReadAsStringAsync());
                return impagos;
            }

            return new List<ImpagoEstudiante>();
        }

        public async Task<List<Pago>> GetPagos()
        {
            var respuesta = await _httpClient.GetAsync($"Pago");
            if (respuesta.IsSuccessStatusCode)
            {
                List<Pago> est = JsonConvert.DeserializeObject<List<Pago>>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return new List<Pago>();
        }

        public async Task<List<Pago>> GetPagosEstudiante(int id)
        {
            var respuesta = await _httpClient.GetAsync($"Pago/estudiante/id/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                List<Pago> pagos = JsonConvert.DeserializeObject<List<Pago>>
                                (await respuesta.Content.ReadAsStringAsync());
                return pagos;
            }

            return new List<Pago>();
        }

        public async Task<Pension> GetPension(int id)
        {
            var respuesta = await _httpClient.GetAsync($"Pension/id/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                Pension est = JsonConvert.DeserializeObject<Pension>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return null;
        }

        public async Task<List<Pension>> GetPensiones()
        {
            var respuesta = await _httpClient.GetAsync($"Pension");
            if (respuesta.IsSuccessStatusCode)
            {
                List<Pension> est = JsonConvert.DeserializeObject<List<Pension>>
                                (await respuesta.Content.ReadAsStringAsync());
                return est;
            }

            return new List<Pension>();
        }

        public async Task<Global> obtenerCuota()
        {
            var respuesta = await _httpClient.GetAsync($"Global/cuota");
            if (respuesta.IsSuccessStatusCode)
            {
                Global cuota = JsonConvert.DeserializeObject<Global>
                                (await respuesta.Content.ReadAsStringAsync());
                return cuota;
            }

            return null;
        }

        public async Task<List<Pago>> pagar(int id, int cantidad)
        {
            var respuesta = await _httpClient.PostAsync($"Pago/pagar/{id}/{cantidad}", null);
            if (respuesta.IsSuccessStatusCode)
            {
                List<Pago> pagos = JsonConvert.DeserializeObject<List<Pago>>
                                (await respuesta.Content.ReadAsStringAsync());
                return pagos;
            }

            return new List<Pago>();
        }

        public async Task<Pago> revertirUltimoPago(int id)
        {
            var respuesta = await _httpClient.DeleteAsync($"Pago/revertir/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                Pago pago = JsonConvert.DeserializeObject<Pago>
                                (await respuesta.Content.ReadAsStringAsync());
                return pago;
            }

            return null;
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

        public async Task<Pension> UpdatePension(int id, string nombre)
        {
            var respuesta = await _httpClient.PutAsJsonAsync<ActualizacionEstudiante>($"Pension/id/{id}/{nombre}", null);
            if (respuesta.IsSuccessStatusCode)
            {
                Pension pension = JsonConvert.DeserializeObject<Pension>
                                (await respuesta.Content.ReadAsStringAsync());
                return pension;
            }

            return null;
        }
    }
}
