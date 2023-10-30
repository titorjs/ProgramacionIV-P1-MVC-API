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
        public async Task<IActionResult> Edit(int Pag_id)
        {
            Pago pago = await _apiService.encontrarPago(Pag_id);
            if (pago != null)
            {
                return View(pago);
            }
            return RedirectToAction("Index");
        }

        // GET: PagoController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
