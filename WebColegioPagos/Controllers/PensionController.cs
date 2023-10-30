using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Models;
using WebColegioPagos.Services;

namespace WebColegioPagos.Controllers
{
    public class PensionController : Controller
    {
        private readonly IApiService _apiService;

        public PensionController(IApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: PagoController
        public async Task<IActionResult> Index()
        {
            List<Pension> pensiones = await _apiService.GetPensiones();
            return View(pensiones);
        }

        // GET: PensionController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PensionController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pension pension)
        {
            Pension p = _apiService.AddPension(pension).Result;

            return RedirectToAction("Index");
        }

        // GET: PensionController/Edit/5
        public async Task<IActionResult> Edit(int Pen_id)
        {
            Pension pension = await _apiService.GetPension(Pen_id);
            if (pension != null)
            {
                return View(pension);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Pension p)
        {
            await _apiService.UpdatePension(p.Pen_id, p.Pen_nombre);
            return RedirectToAction("Index");
        }


        // GET: PensionController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        public async Task<IActionResult> buscarPorId(int id)
        {
            List<Pension> pagos = _apiService.GetPensiones().Result.FindAll(x => x.Pen_id == id);
            return View("Index", pagos);
        }
    }
}
