using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Models;
using WebColegioPagos.Services;

namespace WebColegioPagos.Controllers
{
    public class GlobalController : Controller
    {
        private readonly IApiService _apiService;

        public GlobalController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> CuotaActualizada(int valor)
        {
            Global global= await _apiService.actualizarValor(valor);
            return View("Index", global);
        }
        // GET: EstudianteController
        public async Task<IActionResult> Index()
        {
            Global global = await _apiService.obtenerCuota();
            return View(global);
        }
        // GET: GlobalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GlobalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: GlobalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: GlobalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
