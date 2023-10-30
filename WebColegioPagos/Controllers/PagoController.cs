using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Models;
using WebColegioPagos.Models.Data;
using WebColegioPagos.Services;

namespace WebColegioPagos.Controllers
{
    public class PagoController : Controller
    {
        private readonly IApiService _apiService;

        public PagoController(IApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: PagoController
        public async Task<IActionResult> Index()
        {
            List<Pago> pagos = await _apiService.GetPagos();
            return View(pagos);
        }
        // GET: PagoController
        public async Task<IActionResult> Inpago()
        {
            List<ImpagoEstudiante> inpagos = await _apiService.GetImpagos();
            return View(inpagos);
        }

        // GET: PagoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: PagoController/Edit/5
        public async Task<IActionResult> Edit(int Est_id)
        {
            Pago pago = await _apiService.encontrarPago(Est_id);
            Global cuota = await _apiService.obtenerCuota();
            if (pago != null)
            {
                return View(
                    new EditPago
                    {
                        Global = cuota,
                        Pago = pago
                    });
            }
            return RedirectToAction("Inpago");
        }

        public async Task<IActionResult> Pagar(int id, int cantidad)
        {
            _ = _apiService.pagar(id, cantidad).Result;
            return RedirectToAction("Inpago");
        }

        // GET: PagoController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        public async Task<IActionResult> BusquedaId(int id)
        {
            List<Pago> pagos = _apiService.GetPagosEstudiante(id).Result;
            return View("Index", pagos);
        }

        public async Task<IActionResult> buscarInpagoId(int id)
        {
            List<ImpagoEstudiante> pagos = _apiService.GetImpagos().Result.FindAll(x => x.Est_id == id);
            return View("Inpago", pagos);
        }
    }
}
