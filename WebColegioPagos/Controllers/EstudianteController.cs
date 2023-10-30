using WebColegioPagos.Models;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Services;

namespace WebColegioPagos.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IApiService _apiService;

        public EstudianteController(IApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: EstudianteController
        public async Task<IActionResult> Index()
        {
            List<Estudiante> estudiantes = await _apiService.GetEstudiantes();  
            return View(estudiantes);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cedula)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            Estudiante est = _apiService.GetEstudiante(cedula).Result;
            estudiantes.Add(est);
            return View(estudiantes);
        }

        // GET: EstudianteController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudianteController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        

        // GET: EstudianteController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }
        //Metodo edicion pago
        public IActionResult EditPago (int id)
        {
            return View();
        }
        // POST: EstudianteController/Edit/5


        // GET: EstudianteController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

      
    }
}
